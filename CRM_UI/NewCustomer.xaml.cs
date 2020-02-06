using CRM_Bunny.Controller;
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
    /// Логика взаимодействия для NewCustomer.xaml
    /// </summary>
    public partial class NewCustomer : Window
    {
        public NewCustomer()
        {
            InitializeComponent();
        }

        private void New_Exit(object sender, RoutedEventArgs e)
        {
            Close();
        }

        /// <summary>
        /// Обработчик создания нового Покупателя.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void New_Save(object sender, RoutedEventArgs e)
        {
            var controller = Controller.controller;
            var name = NameCustomer.Text;
            long telefon = 0;
            long.TryParse(TelefonNumberCustomer.Text, out telefon);
            DateTime birdh;

            var result = true;

            if (name == "")
            {
                MessageShowUi.ShowNoneName();

            }

            if (telefon == 0)
            {
                MessageShowUi.ShowNoneTelefon();
                result = false;

            }

            if (!DateTime.TryParse(DateOfBirdhCustomer.Text, out birdh))
            {
                MessageShowUi.ShowNoneDateOfBirdth();

                result = false;
            }

            if (birdh == null)
            {
                MessageShowUi.ShowNoneDateOfBirdth();

                result = false;
            }



            if (result == true)
            {
                string bird = birdh.ToString("dd/MM/yyyy");

                var customerNew = controller.NewCustomer(name, telefon, bird);
                if(customerNew == null)
                {
                    MessageShowUi.ShowPhoneIsInDatabase();
                    return;
                }
                
                MessageShowUi.ShowSave();
                Close();
            }


        }
    }
}
