using System;
using System.Collections.Generic;
using System.Text;

namespace CRM_Bunny.Controller
{
    public interface ILoad
    {
        T Load<T>() where T : class;
    }
}
