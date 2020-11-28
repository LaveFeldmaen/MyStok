using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BLL;
using Data;

namespace DAL
{
    public class T_orders_supplierDAL
    {
        public int Supplier_order_id { get; set; }
        public string Supplier_order_date { get; set; }
        public string Supplier_name { get; set; }
        public int Supplier_id { get; set; }
        public int Branches_id { get; set; }
        public T_orders_supplierBLL AddNewOrderSupplier(T_orders_supplierBLL Temp)
        {
            string sql = "insert into T_orders_supplier (Supplier_order_date,Supplier_id,Branches_id) values('" + Temp.Supplier_order_date + "','" + Temp.Supplier_id +"','"+Temp.Branches_id+ "')";
            Database Db = new Database();
            int NumRows;
            NumRows = Db.ExecuteNonQuery(sql);
            if (NumRows > 0)
            {
                Temp.Supplier_order_id = Db.GetMaxId("Supplier_order_id", "T_orders_supplier");
                Db.Close();

            }
            return Temp;
        }
        public static List<T_orders_supplierBLL> GetallOrders(int Soid, int fleg)
        {
            string Sql;
            Database Db = new Database();
            if (fleg == 0)
            {
                Sql = "select Tosr.Supplier_id,Tosr.Supplier_order_date,Tosr.Supplier_order_id,T_supplier.Supplier_name from T_orders_supplier As Tosr join T_supplier on Tosr.Supplier_id = T_supplier.Supplier_id where T_supplier.Main_store_id='" + Soid + "'"; //
            }
            else
            {
                 Sql = "select Tosr.Supplier_id,Tosr.Supplier_order_date,Tosr.Supplier_order_id,T_supplier.Supplier_name from T_orders_supplier As Tosr join T_supplier on Tosr.Supplier_id = T_supplier.Supplier_id where T_supplier.Main_store_id='" + Soid + "'and  Tosr.Branches_id='"+fleg+"'";
            }
               var dt = Db.Execute(Sql);
                List<T_orders_supplierBLL> AllOrders = new List<T_orders_supplierBLL>();
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    T_orders_supplierBLL Temp = new T_orders_supplierBLL()
                    {
                        Supplier_order_id = (int)dt.Rows[i]["Supplier_order_id"],
                        Supplier_id = (int)dt.Rows[i]["Supplier_id"],
                        Supplier_order_date = dt.Rows[i]["Supplier_order_date"].ToString(),
                        Supplier_name = dt.Rows[i]["Supplier_name"].ToString()

                    };
                    AllOrders.Add(Temp);
                }
                return AllOrders;
            
            
        }
    }
}