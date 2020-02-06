using CRM_Bunny.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace CRM_Bunny.Controller
{
    class DataSave : ISave, ILoad
    {
        private CrmContext db { get; set; }

        public T Load<T>() where T : class
        {

            var db = new CrmContext() as T;

            return db;
        }

        public void Save()
        {
            db.SaveChanges();
        }
    }


}
