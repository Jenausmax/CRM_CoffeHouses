using CRM_Bunny.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace CRM_Bunny.Controller
{
    public abstract class BaseController
    {
        public abstract T GetT<T>(ILoad load) where T : class;

        public abstract void Save(ISave save);

        public abstract Customer NewCustomer(string name, long telefonNumber, string dateOfBirdh);
        public abstract void ChangeCustomer(Customer customer);
        public abstract bool SearchCustomer(long telefonNumber);
        public abstract bool Search(long telefonNumber);
        public abstract void DeleteCustomer(Customer customer);
        public abstract bool NewVisit(Customer customer, double visitSale, int visitNumberOfDrunkGlasses);
        public abstract bool SetDiscount(int glasses);
        public abstract void SetDiscountChange(int glasses);
        public abstract void SetCustomer(Customer customer);
        public abstract Customer GetCustomer();
        public abstract ICollection<Customer> GetCustomersIsBase();
        public abstract ICollection<VisitCustomers> GetVisitCustomers();
        public abstract ICollection<User> GetUsers();


    }
}
