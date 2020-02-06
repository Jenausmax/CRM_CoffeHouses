using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace CRM_UI
{
    /// <summary>
    /// Логика взаимодействия для MessageUi.xaml
    /// </summary>
    public partial class MessageUi : Window
    {
        public MessageUi()
        {
            InitializeComponent();
        }
        private void Ok_Button(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
