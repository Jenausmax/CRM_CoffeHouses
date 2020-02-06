using System;
using System.Collections.Generic;
using System.Text;

namespace CRM_Bunny.Controller
{
    public class Controller
    {
        public static BaseController controller { get; set; } = new CustomerController();
    }
}
