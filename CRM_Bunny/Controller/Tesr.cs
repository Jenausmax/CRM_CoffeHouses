using System;
using System.Collections.Generic;
using System.Text;

namespace CRM_Bunny.Controller
{
    class Tesr
    {

        public void Tres()
        {
            BaseController cont = new CustomerController();


            var d = new CustomerController();

            var s = d.GetCustomer();
            var a = cont.GetCustomer();
        }
    }
}
