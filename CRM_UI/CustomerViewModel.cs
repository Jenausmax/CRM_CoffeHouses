using CRM_Bunny.Controller;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Windows;
using System.Windows.Data;

namespace CRM_UI
{
    class CustomerViewModel : DependencyObject, INotifyPropertyChanged
    {


        public ICollectionView Items
        {
            get { return (ICollectionView)GetValue(MyPropertyProperty); }
            set { SetValue(MyPropertyProperty, value); }
        }

        // Using a DependencyProperty as the backing store for MyProperty.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty MyPropertyProperty =
            DependencyProperty.Register("Items", typeof(ICollectionView), typeof(CustomerViewModel), new PropertyMetadata(null));

        public event PropertyChangedEventHandler PropertyChanged;




        public ICollectionView ItemsVisit
        {
            get { return (ICollectionView)GetValue(ItemsVisitProperty); }
            set { SetValue(ItemsVisitProperty, value); }
        }

        // Using a DependencyProperty as the backing store for ItemsVisit.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ItemsVisitProperty =
            DependencyProperty.Register("ItemsVisit", typeof(ICollectionView), typeof(CustomerViewModel), new PropertyMetadata(null));



        public CustomerViewModel()
        {
            Items = CollectionViewSource.GetDefaultView(Controller.controller.GetCustomersIsBase());
            ItemsVisit = CollectionViewSource.GetDefaultView(Controller.controller.GetVisitCustomers());
        }


    }
}
