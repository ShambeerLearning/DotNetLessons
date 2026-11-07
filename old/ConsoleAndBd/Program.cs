using System;
using System.Data;
using System.Linq;
using Microsoft.Data.Sqlite;
using Microsoft.Data.SqlClient;
using Dapper;

namespace MultiDatabaseApp
{
    public class Client
    {
        public long ClientsId { get; set; }
        public string? ClientsName { get; set; }
        public string? ClientsMiss { get; set; }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // Включаем маппинг snake_case (в БД) на PascalCase (в C#)
            SqlMapper.AddTypeMap(typeof(string), DbType.AnsiString);
            Dapper.DefaultTypeMap.MatchNamesWithUnderscores = true;

            Console.WriteLine("Выберите режим работы с базой данных:");
            Console.WriteLine("1 - Локальная SQLite");
            Console.WriteLine("2 - SQL Server (удалённый сервер)");
            Console.Write("Ваш выбор (1 или 2): ");
            string choice = Console.ReadLine();

            if (choice == "1")
                RunSQLiteMode();
            else if (choice == "2")
                RunSqlServerMode();
            else
                Console.WriteLine("Некорректный выбор. Программа завершена.");
        }

        // ---------- Режим SQLite ----------
        static void RunSQLiteMode()
        {
            const string connectionString = "Data Source=clients.db";
            Func<IDbConnection> connectionFactory = () => new SqliteConnection(connectionString);

            try
            {
                using (var connection = connectionFactory())
                {
                    connection.Execute(@"
                        CREATE TABLE IF NOT EXISTS clients (
                            clients_id INTEGER PRIMARY KEY AUTOINCREMENT,
                            clients_name TEXT NOT NULL,
                            clients_miss TEXT
                        )");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка инициализации SQLite: {ex.Message}");
                return;
            }

            RunMainMenu(connectionFactory);
        }

        // ---------- Режим SQL Server ----------
        static void RunSqlServerMode()
        {
            const string connectionString =
                "Server=db41989.public.databaseasp.net; Database=db41989; User Id=db41989; Password=4q=CwH2-7_Xm; Encrypt=True; TrustServerCertificate=True; MultipleActiveResultSets=True;";

            try
            {
                using (var testConnection = new SqlConnection(connectionString))
                {
                    testConnection.Open(); // Строгая проверка подключения перед началом работы
                }
                Console.WriteLine("Подключение к SQL Server установлено. Нажмите любую клавишу...");
                Console.ReadKey();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка подключения к SQL Server: {ex.Message}");
                Console.ReadKey();
                return;
            }

            Func<IDbConnection> connectionFactory = () => new SqlConnection(connectionString);

            try
            {
                using (var connection = connectionFactory())
                {
                    connection.Execute("DELETE FROM clients WHERE clients_id = 0");
                    connection.Execute(@"
                    IF NOT EXISTS (SELECT * FROM sysobjects WHERE name='clients' AND xtype='U')
                    CREATE TABLE clients (
                    clients_id BIGINT IDENTITY(1,1) PRIMARY KEY,
                    clients_name NVARCHAR(100) NOT NULL,
                    clients_miss NVARCHAR(16)
                    )");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка при настройке таблицы на SQL Server: {ex.Message}");
                return;
            }

            RunMainMenu(connectionFactory);
        }

        // ---------- Общее меню ----------
        static void RunMainMenu(Func<IDbConnection> connectionFactory)
        {
            bool exit = false;
            while (!exit)
            {
                Console.Clear();
                Console.WriteLine("=== Управление клиентами ===");
                Console.WriteLine("1. Просмотреть всех клиентов");
                Console.WriteLine("2. Добавить нового клиента");
                Console.WriteLine("3. Редактировать клиента");
                Console.WriteLine("4. Удалить клиента");
                Console.WriteLine("0. Выход");
                Console.Write("Выберите пункт меню: ");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1": ViewClients(connectionFactory); break;
                    case "2": AddClient(connectionFactory); break;
                    case "3": EditClient(connectionFactory); break;
                    case "4": DeleteClient(connectionFactory); break;
                    case "0": exit = true; break;
                    default:
                        Console.WriteLine("Некорректный ввод. Нажмите любую клавишу...");
                        Console.ReadKey();
                        break;
                }
            }
        }

        // ---------- Вспомогательные методы (Валидация) ----------
        static long GetValidId(string prompt)
        {
            Console.Write(prompt);
            string input = Console.ReadLine();
            if (long.TryParse(input, out long id) && id > 0)
            {
                return id;
            }
            Console.WriteLine("Ошибка: Введено некорректное число. ID должен быть больше нуля.");
            return -1;
        }

        // ---------- 1. Просмотр ----------
        static void ViewClients(Func<IDbConnection> connectionFactory)
        {
            Console.Clear();
            Console.WriteLine("=== Список клиентов ===");
            try
            {
                using (var connection = connectionFactory())
                {
                    var clients = connection.Query<Client>("SELECT clients_id, clients_name, clients_miss FROM clients").ToList();
                    if (!clients.Any())
                        Console.WriteLine("В базе данных нет ни одного клиента.");
                    else
                        foreach (var client in clients)
                            Console.WriteLine($"ID: {client.ClientsId} | Имя: {client.ClientsName ?? "(пусто)"} | Miss: {client.ClientsMiss ?? "(пусто)"}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка при чтении данных: {ex.Message}");
            }

            Console.WriteLine("\nНажмите любую клавишу для возврата в меню...");
            Console.ReadKey();
        }

        // ---------- 2. Добавление ----------
        static void AddClient(Func<IDbConnection> connectionFactory)
        {
            Console.Clear();
            Console.WriteLine("=== Добавление нового клиента ===");

            Console.Write("Введите имя: ");
            string name = Console.ReadLine();

            // Валидация: имя не может быть пустым
            if (string.IsNullOrWhiteSpace(name))
            {
                Console.WriteLine("Ошибка: Имя не может быть пустым. Операция отменена.");
                Console.ReadKey();
                return;
            }

            Console.Write("Введите значение поля Miss (необязательно, Enter пропустить): ");
            string miss = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(miss))
                miss = null;

            try
            {
                using (var connection = connectionFactory())
                {
                    var insertSql = "INSERT INTO clients (clients_name, clients_miss) VALUES (@ClientsName, @ClientsMiss)";
                    connection.Execute(insertSql, new { ClientsName = name, ClientsMiss = miss });
                }
                Console.WriteLine("Клиент успешно добавлен!");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка при добавлении в БД: {ex.Message}");
            }

            Console.ReadKey();
        }

        // ---------- 3. Редактирование ----------
        static void EditClient(Func<IDbConnection> connectionFactory)
        {
            Console.Clear();
            Console.WriteLine("=== Редактирование клиента ===");

            long id = GetValidId("Введите ID клиента для редактирования: ");
            if (id == -1)
            {
                Console.ReadKey();
                return;
            }

            try
            {
                using (var connection = connectionFactory())
                {
                    // Проверяем, существует ли клиент
                    var client = connection.QuerySingleOrDefault<Client>(
                        "SELECT clients_id, clients_name, clients_miss FROM clients WHERE clients_id = @Id",
                        new { Id = id }
                    );

                    if (client == null)
                    {
                        Console.WriteLine($"Клиент с ID {id} не найден.");
                        Console.ReadKey();
                        return;
                    }

                    // Ввод новых данных
                    Console.Write($"Новое имя (текущее: {client.ClientsName}, нажмите Enter, чтобы оставить прежним): ");
                    string newName = Console.ReadLine();
                    if (string.IsNullOrWhiteSpace(newName))
                        newName = client.ClientsName; // Оставляем старое значение

                    Console.Write($"Новое значение Miss (текущее: {client.ClientsMiss ?? "пусто"}, нажмите Enter, чтобы оставить прежним): ");
                    string newMiss = Console.ReadLine();
                    if (string.IsNullOrWhiteSpace(newMiss))
                        newMiss = client.ClientsMiss;

                    // Обновление в БД
                    string updateSql = "UPDATE clients SET clients_name = @Name, clients_miss = @Miss WHERE clients_id = @Id";
                    connection.Execute(updateSql, new { Name = newName, Miss = newMiss, Id = id });

                    Console.WriteLine("Данные клиента успешно обновлены.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка при редактировании: {ex.Message}");
            }

            Console.ReadKey();
        }

        // ---------- 4. Удаление ----------
        static void DeleteClient(Func<IDbConnection> connectionFactory)
        {
            Console.Clear();
            Console.WriteLine("=== Удаление клиента ===");

            long id = GetValidId("Введите ID клиента для удаления: ");
            if (id == -1)
            {
                Console.ReadKey();
                return;
            }

            try
            {
                using (var connection = connectionFactory())
                {
                    string deleteSql = "DELETE FROM clients WHERE clients_id = @Id";
                    int rowsAffected = connection.Execute(deleteSql, new { Id = id });

                    if (rowsAffected > 0)
                        Console.WriteLine($"Клиент с ID {id} успешно удален.");
                    else
                        Console.WriteLine($"Ошибка: Клиент с ID {id} не найден.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка при удалении: {ex.Message}");
            }

            Console.ReadKey();
        }
    }
}