using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
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

namespace exam13
{
    /// <summary>
    /// Логика взаимодействия для AddEditPage.xaml
    /// </summary>
    public partial class AddEditPage : Page
    {
        private Purchases _currentPurchase = new Purchases();
        public AddEditPage(Purchases selectedPurchases)
        {
            InitializeComponent();
            if (selectedPurchases != null)
                _currentPurchase = selectedPurchases;
            DataContext = _currentPurchase;
            ComboPartners.ItemsSource = demoexamEntities.GetContext().Partners.ToList();
            ComboProducts.ItemsSource = demoexamEntities.GetContext().Products.ToList();
        }

        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder errors = new StringBuilder();
            if (_currentPurchase.Products == null)
                errors.AppendLine("Выберите продукт!");
            if (_currentPurchase.Partners == null)
                errors.AppendLine("Выберите партнёра!");
            if (_currentPurchase.PurchasesQuantity == null && _currentPurchase.PurchasesQuantity <= 0)
                errors.AppendLine("Количество продукта должно быть больше 0 и быть числом!");
            if (_currentPurchase.PurchasesDate == null)
                errors.AppendLine("Выберите дату!");
            if (errors.Length > 0)
            {
                MessageBox.Show(errors.ToString());
            }
            if (demoexamEntities.GetContext().Entry(_currentPurchase).State == EntityState.Detached)
            {
                demoexamEntities.GetContext().Purchases.Add(_currentPurchase);
            }
            try
            {
                demoexamEntities.GetContext().SaveChanges();
                MessageBox.Show("Данные сохранены!");
                Manager.MainFrame.GoBack();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }
    }
}
