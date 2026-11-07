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
using System.Data.Entity;

namespace exam4
{
    /// <summary>
    /// Логика взаимодействия для PurchasesPage.xaml
    /// </summary>
    public partial class PurchasesPage : Page
    {
        public PurchasesPage()
        {
            InitializeComponent();
            DGridPurchases.ItemsSource = demoexamEntities.GetContext().Purchases.Include(p => p.Products).Include(p => p.Partners).ToList();
        }

        private void Page_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if(Visibility == Visibility.Visible)
            {
                demoexamEntities.GetContext().ChangeTracker.Entries().ToList().ForEach(p => p.Reload());
                DGridPurchases.ItemsSource = demoexamEntities.GetContext().Purchases.Include(p => p.Products).Include(p => p.Partners).ToList();
            }
        }

        private void BtnEdit_Click(object sender, RoutedEventArgs e)
        {
            var selectedItem = (sender as Button).DataContext as Purchases;
            var context = demoexamEntities.GetContext();
            var loadedItem = context.Purchases.Include(p => p.Products).FirstOrDefault(p => p.PurchasesId == selectedItem.PurchasesId);
            Manager.MainFrame.Navigate(new AddEditPage(loadedItem));
        }

        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Navigate(new AddEditPage(null));
        }

        private void BtnDelete_Click(object sender, RoutedEventArgs e)
        {
            var purchasesForRemoving = DGridPurchases.SelectedItems.Cast<Purchases>().ToList();
            if (MessageBox.Show($"Вы точно хотите удалить следующие {purchasesForRemoving} элементов?", "Внимание!",
                MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                try
                {
                    demoexamEntities.GetContext().Purchases.RemoveRange(purchasesForRemoving);
                    demoexamEntities.GetContext().SaveChanges();
                    MessageBox.Show("Данные сохранены!");
                    DGridPurchases.ItemsSource = demoexamEntities.GetContext().Purchases.ToList();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                }
            }
        }
    }
}
