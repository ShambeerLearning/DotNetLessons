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

namespace examnet
{
    /// <summary>
    /// Логика взаимодействия для PartnersPage.xaml
    /// </summary>
    public partial class PartnersPage : Page
    {
        public PartnersPage()
        {
            InitializeComponent();
        }

        private void BtnEdit_Click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Navigate(new AddEditPage((sender as Button).DataContext as Partners));
        }

        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Navigate(new AddEditPage(null));
        }

        private void BtnDelete_Click(object sender, RoutedEventArgs e)
        {
            var PartnersForRemove = DGridPartners.SelectedItems.Cast<Partners>().ToList();
            if (MessageBox.Show($"Вы уверены, что хотите удалить следующие {PartnersForRemove.Count()} элементов?", "Внимание!",
                MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                try
                {
                    demoexamEntities.GetContext().Partners.RemoveRange(PartnersForRemove);
                    demoexamEntities.GetContext().SaveChanges();
                    MessageBox.Show("Данные удалены!");
                    DGridPartners.ItemsSource = demoexamEntities.GetContext().Partners.ToList();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                }
            }
        }

        private void Page_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if(Visibility == Visibility.Visible)
            {
                demoexamEntities.GetContext().ChangeTracker.Entries().ToList().ForEach(p => {p.Reload();});
                DGridPartners.ItemsSource = demoexamEntities.GetContext().Partners.ToList();
            }
        }
    }
}
