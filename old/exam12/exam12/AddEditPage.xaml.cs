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

namespace exam12
{
    /// <summary>
    /// Логика взаимодействия для AddEditPage.xaml
    /// </summary>
    public partial class AddEditPage : Page
    {
        private Purchases _currentPurchase = new Purchases();
        public AddEditPage(Purchases selectedPurchase)
        {
            InitializeComponent();
            if (selectedPurchase != null) 
                _currentPurchase = selectedPurchase;
            DataContext = _currentPurchase;
            ComboProducts.ItemsSource = demoexamEntities.GetContext().Products.ToList();
            ComboPartners.ItemsSource = demoexamEntities.GetContext().Partners.ToList();
        }

        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder error = new StringBuilder();
            if (_currentPurchase.Products == null)
                error.AppendLine("Выберите продукт!");
            if (_currentPurchase.Partners == null)
                error.AppendLine("Выберите партнёра");
            if (_currentPurchase.PurchasesQuantity == null && _currentPurchase.PurchasesQuantity <= 0)
                error.AppendLine("Впишите число продукта которое больше 0!");
            if (_currentPurchase.PurchasesDate == null)
                error.AppendLine("Выберите дату!");
            if (error.Length > 0)
            {
                MessageBox.Show(error.ToString());
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
