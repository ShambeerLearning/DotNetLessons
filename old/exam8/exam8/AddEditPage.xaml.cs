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

namespace exam8
{
    /// <summary>
    /// Логика взаимодействия для AddEditPage.xaml
    /// </summary>
    public partial class AddEditPage : Page
    {
        private Purchases _currentPurchases = new Purchases();
        public AddEditPage(Purchases selectedPurchases)
        {
            InitializeComponent();
            if (selectedPurchases != null) 
                _currentPurchases = selectedPurchases;
            DataContext = _currentPurchases;
            ComboProducts.ItemsSource = demoexamEntities.GetContext().Products.ToList();
            ComboPartners.ItemsSource = demoexamEntities.GetContext().Partners.ToList();
        }

        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder errors = new StringBuilder();
            if (_currentPurchases.Products == null)
                errors.AppendLine("Выберите продукт!");
            if (_currentPurchases.Partners == null)
                errors.AppendLine("Выберите партнёра!");
            if (_currentPurchases.PurchasesQuantity <= 0)
                errors.AppendLine("Количество продуктов должно быть больше 0!");
            if (_currentPurchases.PurchasesDate == null)
                errors.AppendLine("Выберите дату!");
            if (errors.Length > 0)
            {
                MessageBox.Show(errors.ToString());
                return;
            }
            if (demoexamEntities.GetContext().Entry(_currentPurchases).State == EntityState.Detached)
            {
                demoexamEntities.GetContext().Purchases.Add(_currentPurchases);
            }
            try
            {
                demoexamEntities.GetContext().SaveChanges();
                MessageBox.Show("Изменения сохранены");
                Manager.MainFrame.GoBack();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }
    }
}
