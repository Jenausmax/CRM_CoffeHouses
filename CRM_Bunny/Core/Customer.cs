using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CRM_Bunny.Core
{
    public class Customer
    {
        [Key]
        /// <summary>
        /// Id.
        /// </summary>
        public int? CustomerId { get; set; }
        /// <summary>
        /// Имя покупателя.
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Телефонный номер покупателя.
        /// </summary>
        public long TelefonNumber { get; set; }
        /// <summary>
        /// Дата рождения покупателя.
        /// </summary>
        public string DateOfBirdh { get; set; }
        /// <summary>
        /// Общая сумма покупок конкретного покупателя.
        /// </summary>
        public double AllSalePrice { get; set; } //общая сумма покупок этого пользователя
        /// <summary>
        /// Общее количество посещений.
        /// </summary>
        public int TotalVisits { get; set; }
        /// <summary>
        /// Скидка конкретного покупателя.
        /// </summary>
        public int Discount { get; set; }
        /// <summary>
        /// Количество выпитых стаканов покупателя.
        /// </summary>
        public int NumberOfDrunkGlasses { get; set; }
        /// <summary>
        /// Количество выпитых стаканов по акции. Количество сданных карт по акции 6+1.
        /// </summary>
        public int GlassesOfShares { get; set; }

        public ICollection<VisitCustomers> Visits { get; set; }
        public ICollection<KartSale> KartSales { get; set; }

        public Customer() { }
        public Customer(string name, long telefonNumber, string dateOfBirdh)
        {
            this.Name = name;
            this.TelefonNumber = telefonNumber;
            this.DateOfBirdh = dateOfBirdh;
        }



        public override string ToString()
        {
            return Name;
        }
    }
}
