using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DAL;

namespace BLL
{
    public class T_orders_supplierBLL
    {
        public int Supplier_order_id { get; set; }
        public string Supplier_order_date { get; set; }
        public string Supplier_name { get; set; }
        public int Supplier_id { get; set; }
        public int Branches_id { get; set; }
        public T_orders_supplierBLL AddNewOrderSupplier(T_orders_supplierBLL Temp)
        {
            T_orders_supplierDAL t_Orders_SupplierDAL = new T_orders_supplierDAL();
            return t_Orders_SupplierDAL.AddNewOrderSupplier(this);


        }
        public static List<T_orders_supplierBLL> GetallOrders(int Soid, int fleg)
        {
            return T_orders_supplierDAL.GetallOrders(Soid, fleg);

        }
    }
}