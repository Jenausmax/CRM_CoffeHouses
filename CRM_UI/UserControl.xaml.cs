using CRM_Bunny.Controller;
using System.Windows;


namespace CRM_UI
{
    /// <summary>
    /// Логика взаимодействия для UserControl.xaml
    /// </summary>
    public partial class UserControl : Window
    {
        private int _flag = 1;
       
        public UserControl()
        {
            InitializeComponent();
        }

   

        private void InputNew(object sender, RoutedEventArgs e)
        {
            var controller = new ControllerUser();
            var result = false;
            
                var login = controller.SearchUser(UserLogin.Text);
                if (login)
                {
                    var password = controller.PasswordControl(PassUser.Text);
                    if (!password)
                    {
                        MessageShowUi.PassFalse();
                        _flag++;
                        //var main = new MainWindow();
                        //Close();
                    }
                    else
                    {
                    result = true;

                    }
                }
                else
                {
                    MessageShowUi.UserNone();
                    _flag++;
                }

            if (result)
            {
                var main = new MainWindow();
                Close();
            }

            if(_flag >= 6)
            {
                System.Environment.Exit(0);
            }
          
           
            //System.Environment.Exit(0);
        }

        private void NewExit(object sender, RoutedEventArgs e)
        {
            System.Environment.Exit(0);
        }
    }
}
