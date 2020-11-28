using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DAL;

namespace BLL
{
    public class T_supplierBLL
    {
        public int Supplier_id { get; set; }
        public string Supplier_name { get; set; }
        public int Cat_id { get; set; }
        public int Main_store_id { get; set; }

        public List<T_supplierBLL> NameSupplire()
        {
            T_supplierDAL supplire = new T_supplierDAL();
            List<T_supplierBLL> Supplire = supplire.ListSupplireName(this);
            return Supplire;
        }

    }
}