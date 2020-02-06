using CRM_Bunny.Core;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CRM_Bunny.Controller
{
    public class CustomerController : BaseController
    {
        /// <summary>
        /// Переменная Базы.
        /// </summary>
        private CrmContext db { get; set; }

        public static ICollection<Customer> Customers { get; set; } = new List<Customer>();
        public static ICollection<VisitCustomers> Visits { get; set; } = new List<VisitCustomers>();
        private static ICollection<User> Users { get; set; } = new List<User>();

        /// <summary>
        /// Переменная Покупатель.
        /// </summary>
        private static Customer Customer { get; set; }

        

        /// <summary>
        /// Метод создания экземпляра Базы данных.
        /// </summary>
        /// <typeparam name="T">Класс создания базы.</typeparam>
        /// <param name="save">Интерфейс загрузки базы.</param>
        /// <returns>Возвращает класс базы.</returns>
        public override T GetT<T>(ILoad save)
        {
            var db = save.Load<T>();

            return db;
        }

        public CustomerController()
        {
            db = GetT<CrmContext>(new DataSave());
        }

        /// <summary>
        /// Метод создания списка пользователей из базы.
        /// </summary>
        /// <returns>Возвращает коллекцию покупателей.</returns>
        public override  ICollection<Customer> GetCustomersIsBase()
        {
            Customers.Clear();

            foreach (var cust in db.Customers)
            {
                Customers.Add(cust);
            }
            return Customers;
        }

        

        public override ICollection<VisitCustomers> GetVisitCustomers()
        {
            Visits.Clear();
            foreach(var vis in db.VisitCustomers)
            {
                Visits.Add(vis);
            }

            return Visits;
        }

        public override ICollection<User> GetUsers()
        {
            var users = new List<User>();

            foreach (var us in db.Users)
            {
                users.Add(us);
            }
            return users;

            //Users.Clear();
            //foreach(var us in db.Users)
            //{
            //    Users.Add(us);
            //}
            //return Users;
        }

        /// <summary>
        /// Метод устанавливает новое поле покупателя.
        /// </summary>
        /// <param name="customer">Покупатель.</param>
        public override void SetCustomer(Customer customer)
        {
            if (customer == null)
            {
                throw new ArgumentNullException("Customer not null.");
            }
            else
            {
                Customer = customer;
            }
        }

        /// <summary>
        /// Метод чтения поля Покупателя.
        /// </summary>
        /// <returns>Покупатель.</returns>
        public override Customer GetCustomer()
        {
            return Customer;
        }

        /// <summary>
        /// Метод создания покупателя.
        /// </summary>
        /// <param name="name">Имя покупателя.</param>
        /// <param name="telefonNumber">Телефон покупателя(Основной критерий поиска).</param>
        /// <param name="dateOfBirdh">Дата рождения.</param>
        /// <returns></returns>
        public override Customer NewCustomer(string name, long telefonNumber, string dateOfBirdh)
        {
            Customer result = null;
            double allSalePrice = 0;
            int totalVisits = 0;
            int discount = 0;
            int numberOfDrunkGlasses = 0;
            int glassesOfShares = 0;

            if (name != null && telefonNumber != 0 && dateOfBirdh != null && name != "")
            {
                var customer = SearchCustomer(telefonNumber);
                if (customer == false)
                {
                    result = new Customer()
                    {
                        Name = name,
                        TelefonNumber = telefonNumber,
                        DateOfBirdh = dateOfBirdh,
                        AllSalePrice = allSalePrice,
                        TotalVisits = totalVisits,
                        Discount = discount,
                        NumberOfDrunkGlasses = numberOfDrunkGlasses,
                        GlassesOfShares = glassesOfShares
                    };
                }
            }
            if (result != null)
            {
                db.Customers.Add(result);
                Save(new DataSave());
                GetCustomersIsBase();
            }
            return result;
        }

        /// <summary>
        /// Метод изменения пользователя в Базе.
        /// </summary>
        /// <param name="customer">Покупатель.</param>
        public override void ChangeCustomer(Customer customer)
        {
            Customer changeCustomer = null;

            changeCustomer = db.Customers.FirstOrDefault(x => x.CustomerId == Customer.CustomerId);
            changeCustomer.Name = customer.Name;
            changeCustomer.DateOfBirdh = customer.DateOfBirdh;
            changeCustomer.GlassesOfShares = customer.GlassesOfShares;
            changeCustomer.NumberOfDrunkGlasses = customer.NumberOfDrunkGlasses;
            changeCustomer.TelefonNumber = customer.TelefonNumber;
            changeCustomer.TotalVisits = customer.TotalVisits;
            changeCustomer.Visits = customer.Visits;

            Save(new DataSave());

            SetCustomer(changeCustomer);
            GetCustomersIsBase();
        }


        /// <summary>
        /// Поиск пользователя в Базе по телефонному номеру.
        /// </summary>
        /// <param name="telefonNumber">Телефон.</param>
        /// <returns>true - пользователь найден</returns>
        public override bool SearchCustomer(long telefonNumber)
        {
            var result = db.Customers.FirstOrDefault(x => x.TelefonNumber == telefonNumber);
            var result2 = false;

            if (result != null)
            {
                result2 = true;
                Customer = result;
            }
            return result2;
        }

        public override bool Search(long telefonNumber)
        {
            var result = db.Customers.FirstOrDefault(x => x.TelefonNumber == telefonNumber);
            var result2 = false;

            if (result != null)
            {
                result2 = true;
            }
            return result2;
        }

        /// <summary>
        /// Метод удаления Покупателя из Базы.
        /// </summary>
        /// <param name="customer">Покупатель.</param>
        public override void DeleteCustomer(Customer customer)
        {
            if (customer != null)
            {
                var delCustomer = db.Customers.Find(customer.CustomerId);
                Customer = null;
                db.Customers.Remove(delCustomer);
                Save(new DataSave());
            }
        }

        public override bool NewVisit(Customer customer, double visitSale, int visitNumberOfDrunkGlasses)
        {
            var visit = new VisitCustomers();
            bool result = false;
            //string format = "dd/MM/yyyy HH:mm";
            var dataString = DateTime.Now.ToString("dd/MM/yyyy HH:mm");
            visit.DateVisit = dataString;
            visit.Customer = customer;
            visit.VisitSalePrice = visitSale;
            visit.VisitNumberOfDrunkGlasses = visitNumberOfDrunkGlasses;
            visit.NameCustomer = customer.Name;

            if (visit != null)
            {
                db.VisitCustomers.Add(visit);
                Save(new DataSave());
                customer.NumberOfDrunkGlasses = customer.NumberOfDrunkGlasses + visitNumberOfDrunkGlasses;
                customer.TotalVisits++;
                customer.AllSalePrice = customer.AllSalePrice + visitSale;
                ChangeCustomer(customer);
                result = true;
            }
            else
            {
                result = false;
            }

            return result;
        }

        /// <summary>
        /// Метод работы со скидкой. Увеличивает на указанное количество скидочные стаканчики
        /// </summary>
        /// <param name="glasses">Количество скидочных стаканчиков.</param>
        /// <returns></returns>
        public override bool SetDiscount(int glasses)
        {
            bool getResult = true;
            
            if (glasses >= 0 && glasses <=100000)
            {
                Customer.GlassesOfShares = Customer.GlassesOfShares + glasses;
                ChangeCustomer(Customer);
                
            }
            Discount();
            return getResult;
        }

        private void Discount()
        {

           
            int result = Customer.GlassesOfShares;
            if(result < 5)
            {
                Customer.Discount = 0;
            }
            if (result >= 5 && result <= 10)
            {
                Customer.Discount = 5;
            }
            if (result >= 10)
            {
                Customer.Discount = 10;
            }

            
        }

        public override void SetDiscountChange(int glasses)
        {
            if (glasses >= 0 && glasses <= 100000)
            {
                Customer.GlassesOfShares = glasses;
                ChangeCustomer(Customer);
            }
            Discount();
        }

        /// <summary>
        /// Метод сохранения изменений в Базе.
        /// </summary>
        /// <param name="save">Экземпляр класса сохранения.</param>
        public override void Save(ISave save)
        {
            db.SaveChanges();
        }

        
    }
}
