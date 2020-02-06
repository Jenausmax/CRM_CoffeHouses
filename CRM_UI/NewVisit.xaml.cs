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
    /// Логика взаимодействия для NewVisit.xaml
    /// </summary>
    public partial class NewVisit : Window
    {
        public NewVisit()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Обработчик создания нового визита.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void New_SaveVisit(object sender, RoutedEventArgs e)
        {
            var controlCustomer = Controller.controller;


            var result = true;
            var searchResult = false;
            long search = 0;
            long.TryParse(Telefon.Text, out search);
            double visitSale = 0;
            double.TryParse(VisitSale.Text, out visitSale);
            int drink = 0;
            int.TryParse(NumberOfDrunk.Text, out drink);
            if (search != 0)
            {
                searchResult = controlCustomer.SearchCustomer(search);
            }
            else
            {
                result = false;
            }

            if (visitSale == 0)
            {
                MessageShowUi.ShowSaleVisit();

                result = false;
            }

            if (result)
            {
                if (searchResult == true)
                {

                    var customer = controlCustomer.GetCustomer();
                    var visit = controlCustomer.NewVisit(customer, visitSale, drink);
                    var customerChange = controlCustomer.GetCustomer();
                    
                    
                    if (visit == true)
                    {
                        MessageShowUi.ShowSave();
                        Telefon.Text = "";
                        VisitSale.Text = "";
                        NumberOfDrunk.Text = "";
                    }
                    Close();

                }
                else
                {
                    MessageShowUi.ShowNoneCustomer();

                }
            }


        }

        private void New_Exit(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
