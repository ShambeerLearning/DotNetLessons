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
    /// Логика взаимодействия для AddEditPage.xaml
    /// </summary>
    public partial class AddEditPage : Page
    {
        private Partners _currentPartners = new Partners();
        public AddEditPage(Partners selectedPartners)
        {
            InitializeComponent();
            
            if(selectedPartners != null)
                _currentPartners = selectedPartners;

            DataContext = _currentPartners;
        }

        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder errors = new StringBuilder();
            if (string.IsNullOrEmpty(_currentPartners.PartnersType))
                errors.AppendLine("Укажите тип партнёра");
            if (string.IsNullOrEmpty(_currentPartners.PartnersName))
                errors.AppendLine("Укажите имя партнёра");
            if (string.IsNullOrEmpty(_currentPartners.PartnersCeoName))
                errors.AppendLine("Укажите директора партнёра");
            if (string.IsNullOrEmpty(_currentPartners.PartnersEmail))
                errors.AppendLine("Укажите почту партнёра");
            if (string.IsNullOrEmpty(_currentPartners.PartnersNumber))
                errors.AppendLine("Укажите номер партнёра");
            if (string.IsNullOrEmpty(_currentPartners.PartnersAddress))
                errors.AppendLine("Укажите адрес партнёра");
            if (_currentPartners.PartnersInn == null)
                errors.AppendLine("Укажите инн партнёра");
            if (_currentPartners.PartnersRaiting == null)
                errors.AppendLine("Укажите рейтинг партнёра");

            if(errors.Length > 0)
            {
                MessageBox.Show(errors.ToString());
                return;
            }

            if (_currentPartners.PartnersId == 0)
                demoexamEntities.GetContext().Partners.Add(_currentPartners);

            try
            {
                demoexamEntities.GetContext().SaveChanges();
                MessageBox.Show("Информация сохранена");
                Manager.MainFrame.GoBack();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }
    }
}
