using SoundPadv2.Classes;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace SoundPadv2
{
    public partial class MainWindow : Window
    {
        // Коллекция для хранения файлов
        public ObservableCollection<FileModels> Files { get; set; } = new ObservableCollection<FileModels>();

        public MainWindow()
        {
            InitializeComponent();
            FilesGrid.ItemsSource = Files; // Привязка данных
        }

        // Загрузка файлов при старте приложения
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            LoadFilesFromFolder(@".\sounds"); // Путь к папке
        }

        // Метод для загрузки файлов
        private void LoadFilesFromFolder(string folderPath)
        {
            try
            {
                Files.Clear();

                if (Directory.Exists(folderPath))
                {
                    foreach (string filePath in Directory.GetFiles(folderPath))
                    {
                        Files.Add(new FileModels
                        {
                            FileName = System.IO.Path.GetFileName(filePath)
                        });
                    }
                }
                else
                {
                    MessageBox.Show("Папка не найдена!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка: {ex.Message}");
            }
        }

        // Обработчик кнопки воспроизведения
        private void BtnPlay_Click(object sender, RoutedEventArgs e)
        {
            if (FilesGrid.SelectedItem is FileModels selectedFile)
            {
                string filePath = System.IO.Path.Combine(@".\sounds", selectedFile.FileName);
                // Ваш код для воспроизведения файла
                MessageBox.Show($"Playing: {filePath}");
                SoundPlayer sound = new SoundPlayer();
                sound.Play();
            }
        }
    }
}
