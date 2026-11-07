using exam1.ClassesForAll;
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

namespace exam1
{
    /// <summary>
    /// Логика взаимодействия для AddEditPage.xaml
    /// </summary>
    public partial class AddEditPage : Page
    {
        private PartnerProducts _currentPurchase = new PartnerProducts();
        public AddEditPage(PartnerProducts selectedPartnersProducts)
        {
            InitializeComponent();
            if (selectedPartnersProducts != null)
                _currentPurchase = selectedPartnersProducts;
            DataContext = _currentPurchase;
            ComboProducts.ItemsSource = demoexamEntities.GetContext().Products.ToList();
            ComboPartners.ItemsSource = demoexamEntities.GetContext().Partners.ToList();
        }

        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder errors = new StringBuilder();
            if (_currentPurchase.Products == null)
                errors.AppendLine("Выберите продукт");
            if (_currentPurchase.Partners == null)
                errors.AppendLine("Выберите партнёра");
            if (_currentPurchase.PartnersProductsQuantity <= 0)
                errors.AppendLine("Цена должна быть больше 0");
            if (_currentPurchase.PartnersProductsDate == null)
                errors.AppendLine("Выберите дату");
            if (errors.Length > 0)
            {
                MessageBox.Show(errors.ToString());
                return;
            }
            if (_currentPurchase.PartnersProductsId == 0)
                demoexamEntities.GetContext().PartnerProducts.Add(_currentPurchase);
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
