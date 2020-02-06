using CRM_Bunny.Controller;
using System.Windows;


namespace CRM_UI
{
    /// <summary>
    /// Логика взаимодействия для DialogYesNo.xaml
    /// </summary>
    public partial class DialogYesNo : Window
    {
        public DialogYesNo()
        {
            InitializeComponent();
        }

        private void Delete_Customer(object sender, RoutedEventArgs e)
        {
            var controller = Controller.controller;

            var customer = controller.GetCustomer();

            controller.DeleteCustomer(customer);
            MessageShowUi.ShowSave();
            Close();
        }

        private void Cancel(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
