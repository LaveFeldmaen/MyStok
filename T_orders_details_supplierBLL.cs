using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DAL;

namespace BLL
{
    public class T_orders_details_supplierProps
    {
        public string ProperName { get; set; }
        public string ProperValue { get; set; }


    }
    public class T_orders_details_supplierBLL
    {
        public List<T_orders_details_supplierProps>LstProps{get;set;}
        public string Model_Name { get; set; }
        public string Supplier_Name { get; set; }
        public int Supplier_order_id { get; set; }
        public int Model_id { get; set; }
        public int Quantity { get; set; }
        public int Unit_pris { get; set; }
        public int Total { get; set; }
        public string Json_property { get; set; }
        public int Supplier_waernty { get; set; }



        public string AddDedelsOrders(List<T_orders_details_supplierBLL>LstSod)
        {
            T_orders_details_supplierDAL t_Orders_Details_SupplierDAL = new T_orders_details_supplierDAL();
            return t_Orders_Details_SupplierDAL.AddDedelsOrders(LstSod);
        }
        public List<T_orders_details_supplierBLL>GetOrdersDedelsSopliier (T_orders_details_supplierBLL temp)
        {
            List<T_orders_details_supplierDAL> LSTOrdsDal = new List<T_orders_details_supplierDAL>();
            List<T_orders_details_supplierBLL> LSTOrdersBll = new List<T_orders_details_supplierBLL>();
            LSTOrdersBll = T_orders_details_supplierDAL.GetOrdersDedelsSopliier(this);
            return LSTOrdersBll;
        }
        public static List<T_orders_details_supplierBLL> CompareSuppliersOrders(List<T_orders_details_supplierBLL>Temp)
        {
           return T_orders_details_supplierDAL.CompareSuppliersOrders(Temp);
        }

        
    }
}