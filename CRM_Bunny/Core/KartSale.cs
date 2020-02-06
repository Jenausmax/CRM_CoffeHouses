using System;
using System.Collections.Generic;
using System.Text;

namespace CRM_Bunny.Core
{
    public class KartSale
    {
        public int? Id { get; set; }
        public string KartName { get; set; }
        public long KartNumber { get; set; }
        public string NameCustomer { get; set; }

        public int? CustomerId { get; set; }
        public Customer Customer { get; set; }
    }
   
}
