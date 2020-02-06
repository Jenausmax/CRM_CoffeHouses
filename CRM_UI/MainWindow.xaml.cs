using CRM_Bunny.Controller;
using System;
using System.Windows;


namespace CRM_UI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private bool _flag;
 

        public MainWindow()
        {
            InitializeComponent();
            _flag = new FlagRole().Role;
            if(_flag == false)
            {
                Change.IsEnabled = false;
                DiscountChange.IsEnabled = false;
            }
            
        }

  
        private void NewCustomerButton(object sender, RoutedEventArgs e)
        {
            var newCustomer = new NewCustomer();
            newCustomer.Owner = this;
            newCustomer.Show();
        }

        private void NewVisitCustomer(object sender, RoutedEventArgs e)
        {
            var newVisit = new NewVisit();
            if(Info.Visibility == Visibility.Visible)
            {
                newVisit.Telefon.Text = TextTelefon.Text;
            }

            if(SearchInfoCustomer.Visibility == Visibility.Collapsed)
            {
                newVisit.Telefon.Text = " ";
                newVisit.VisitSale.Text = " ";
                newVisit.NumberOfDrunk.Text = " ";
            }

            newVisit.Show();
        }

        private void CloseApplication(object sender, RoutedEventArgs e)
        {
            System.Environment.Exit(0);
        }

        private void Search_Info(object sender, RoutedEventArgs e)
        {
            CanvasGrid.Visibility = Visibility.Collapsed;
            CanvasGrid.Visibility = Visibility.Collapsed;
            var textSearch = SearchText.Text;
            var result = true;

            if (textSearch == null)
            {
                SearchInfoCustomer.Visibility = Visibility.Collapsed;
                MessageShowUi.ShowNoneSearch();
                result = false;
                SearchText.Text = "";
            }

            if (result)
            {
                var controller = Controller.controller;
                long telefon = 0;
                long.TryParse(textSearch, out telefon);

                if (controller.SearchCustomer(telefon))
                {
                    GetCustomerInfo();
                    SearchText.Text = "";
                }
                else
                {
                    SearchInfoCustomer.Visibility = Visibility.Collapsed;
                    MessageShowUi.ShowNoneCustomer();
                }

            }


        }

        private void GetCustomerInfo()
        {
            var customer = Controller.controller.GetCustomer();
            TextFIO.Text = customer.Name;
            TextTelefon.Text = Convert.ToString(customer.TelefonNumber);
            TextBirdth.Text = customer.DateOfBirdh;
            TextAllSale.Text = Convert.ToString(customer.AllSalePrice);
            TextAllVisit.Text = Convert.ToString(customer.TotalVisits);
            TextDrunkGlasses.Text = Convert.ToString(customer.NumberOfDrunkGlasses);
            TextGlasses.Text = Convert.ToString(customer.GlassesOfShares);
            TextDiscount.Text = Convert.ToString(customer.Discount);
            SearchInfoCustomer.Visibility = Visibility.Visible;
        }

        private void GetChangeInfo()
        {
            var customer = Controller.controller.GetCustomer();
            FIO.Text = customer.Name;
            Telefon.Text = Convert.ToString(customer.TelefonNumber);
            Birdth.Text = customer.DateOfBirdh;
            AllSale.Text = Convert.ToString(customer.AllSalePrice);
            AllVisit.Text = Convert.ToString(customer.TotalVisits);
            DrunkGlasses.Text = Convert.ToString(customer.NumberOfDrunkGlasses);
            Glasses.Text = Convert.ToString(customer.GlassesOfShares);
            Discount.Text = Convert.ToString(customer.Discount);
        }

        private void Change_Customer(object sender, RoutedEventArgs e)
        {
            Info.Visibility = Visibility.Collapsed;
            SaveInfo.Visibility = Visibility.Visible;

            Change.Visibility = Visibility.Visible;
            DiscountChange.Visibility = Visibility.Visible;

            DiscountChangeSave.Visibility = Visibility.Collapsed;
            CancelSaveDiscount.Visibility = Visibility.Collapsed;

            Save.Visibility = Visibility.Visible;
            Cancel.Visibility = Visibility.Visible;

            FIO.IsEnabled = true;
            Telefon.IsEnabled = true;
            Birdth.IsEnabled = true;
            AllSale.IsEnabled = false;
            AllVisit.IsEnabled = false;
            DrunkGlasses.IsEnabled = false;
            Glasses.IsEnabled = false;
            Discount.IsEnabled = false;

            GetChangeInfo();

        }

 

        private void Save_Customer(object sender, RoutedEventArgs e)
        {
            var customer = Controller.controller.GetCustomer();
            var controller = Controller.controller;
            long telefon = 0;
            DateTime birdth;
            

            var result = true;

            if (FIO.Text != "")
            {
                customer.Name = FIO.Text;
            }
            else
            {
                MessageShowUi.ShowNoneName();
                result = false;
            }

            if (long.TryParse(Telefon.Text, out telefon))
            {
                var flag = controller.Search(telefon);
                if (flag == false)
                {
                    customer.TelefonNumber = telefon;
                }
                else
                {
                    MessageShowUi.ShowPhoneIsInDatabase();
                    result = false;
                }
                
            }
            else
            {
                MessageShowUi.ShowNoneTelefon();
                result = false;
            }

            if (DateTime.TryParse(Birdth.Text, out birdth))
            {
                string bird = birdth.ToString("dd/MM/yyyy");
                customer.DateOfBirdh = bird;
            }
            else
            {
                MessageShowUi.ShowNoneDateOfBirdth();
                result = false;
            }

            if (result)
            {
                controller.ChangeCustomer(customer);
                Info.Visibility = Visibility.Visible;
                SaveInfo.Visibility = Visibility.Collapsed;
                GetCustomerInfo();

            }



        }

        private void Cancel_Change_Customer(object sender, RoutedEventArgs e)
        {

            Info.Visibility = Visibility.Visible;
            SaveInfo.Visibility = Visibility.Collapsed;
            GetCustomerInfo();
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Register_Discount(object sender, RoutedEventArgs e)
        {
            var customer = Controller.controller.GetCustomer();
            Info.Visibility = Visibility.Collapsed;
            SaveInfo.Visibility = Visibility.Visible;

            Change.Visibility = Visibility.Collapsed;
            DiscountChange.Visibility = Visibility.Collapsed;

            DiscountChangeSave.Visibility = Visibility.Visible;
            CancelSaveDiscount.Visibility = Visibility.Visible;
            

            GetChangeInfo();
            FIO.IsEnabled = false;
            Telefon.IsEnabled = false;
            Birdth.IsEnabled = false;
            AllSale.IsEnabled = false;
            AllVisit.IsEnabled = false;
            DrunkGlasses.IsEnabled = false;
            Glasses.IsEnabled = true;
            Glasses.Text = Convert.ToString(customer.GlassesOfShares);
            Discount.IsEnabled = false;

        }

        #region Discount Обработчики скидок
        private void Close_Kart(object sender, RoutedEventArgs e)
        {
            var controller = Controller.controller;
            var val = controller.SetDiscount(1);
            if (val)
            {
                MessageShowUi.ShowKart();
            }

            GetCustomerInfo();

        }
        private void Discount_Change(object sender, RoutedEventArgs e)
        {
            int glasses = 0;
            var result = true;
            var controller = Controller.controller;

            if (!int.TryParse(Glasses.Text, out glasses))
            {
                MessageShowUi.ShowNonePole();
                result = false;
            }

            if (result)
            {
                controller.SetDiscountChange(glasses);

           
                Info.Visibility = Visibility.Visible;
                SaveInfo.Visibility = Visibility.Collapsed;

                Change.Visibility = Visibility.Visible;
                DiscountChange.Visibility = Visibility.Visible;
                

                GetCustomerInfo();
            }


        }

        private void Cancel_ChangeDisount_Customer(object sender, RoutedEventArgs e)
        {
            Info.Visibility = Visibility.Visible;
            SaveInfo.Visibility = Visibility.Collapsed;

            DiscountChangeSave.Visibility = Visibility.Collapsed;
            CancelSaveDiscount.Visibility = Visibility.Collapsed;
            

            Change.Visibility = Visibility.Visible;
            DiscountChange.Visibility = Visibility.Visible;

            GetCustomerInfo();

        }
        #endregion

        private void CustomerBase(object sender, RoutedEventArgs e)
        {
            SearchInfoCustomer.Visibility = Visibility.Collapsed;
            CanvasGridVisit.Visibility = Visibility.Collapsed;
            CanvasGrid.Visibility = Visibility.Visible;

            DataContext = new CustomerViewModel();

            
            CustomerGrid.Items.Refresh();

            
        }

        private void NewKart(object sender, RoutedEventArgs e)
        {

        }

        private void VisitCustomerGrid(object sender, RoutedEventArgs e)
        {
            SearchInfoCustomer.Visibility = Visibility.Collapsed;
            CanvasGrid.Visibility = Visibility.Collapsed;
            CanvasGridVisit.Visibility = Visibility.Visible;

            DataContext = new CustomerViewModel();
            CustomerGridVisit.Items.Refresh();

        }

        private void DeleteCustomer(object sender, RoutedEventArgs e)
        {
            var customer = Controller.controller.GetCustomer();

            if(customer != null)
            {
                var yesNo = new DialogYesNo();
                yesNo.Owner = this;
                yesNo.Text.Text = $"Хотите удалить {customer.Name} ?";
                yesNo.Show();
                SearchInfoCustomer.Visibility = Visibility.Collapsed;
            }


            
        }
    }
}
