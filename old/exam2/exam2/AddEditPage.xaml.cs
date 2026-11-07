using System;
using System.Collections.Generic;
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

namespace exam2
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
            if(selectedPurchases != null) 
                _currentPurchase = selectedPurchases;
            DataContext = _currentPurchase;
            ComboProducts.ItemsSource = demoexamEntities.GetContext().Products.ToList();
            ComboPartners.ItemsSource = demoexamEntities.GetContext().Partners.ToList();
        }

        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder errors = new StringBuilder();
            if (_currentPurchase.Products == null)
                errors.AppendLine("Выберите продукт!");
            if (_currentPurchase.Partners == null)
                errors.AppendLine("Выберите партнёра!");
            if (_currentPurchase.PurchasesQuantity <= 0)
                errors.AppendLine("Число товаров должно быть больше 0!");
            if (_currentPurchase.PurchasesDate == null)
                errors.AppendLine("Выберите дату!");
            if(errors.Length > 0)
            {
                MessageBox.Show(errors.ToString());
                return;
            }
            if(_currentPurchase.PurchasesId == 0)
                demoexamEntities.GetContext().Purchases.Add(_currentPurchase);
            try
            {
                demoexamEntities.GetContext().SaveChanges();
                MessageBox.Show("Изменения сохранены");
                Manager.MainFrame.GoBack();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка: {ex.Message}\nInnerException: {ex.InnerException?.Message}");
            }
        }
    }
}
