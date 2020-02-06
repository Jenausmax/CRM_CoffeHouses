using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CRM_Bunny.Core
{
    public class VisitCustomers
    {
        [Key]
        public int? VisitId { get; set; }
        /// <summary>
        /// Дата визита.
        /// </summary>
        public string DateVisit { get; set; }
        /// <summary>
        /// Сумма чека визита покупателя.
        /// </summary>
        public double VisitSalePrice { get; set; }
        /// <summary>
        /// Количество купленных стаканов покупателя.
        /// </summary>
        public int VisitNumberOfDrunkGlasses { get; set; }

        public string NameCustomer { get; set; }


        public int? CustomerId { get; set; }
        public Customer Customer { get; set; }
    }
}
