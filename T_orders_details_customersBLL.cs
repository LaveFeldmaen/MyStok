using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DAL;

namespace BLL
{
    public class T_orders_details_customersBLL
    {
        public int Order_cust_id { get; set; }
        public int Model_id { get; set; }
        public int Quantity { get; set; }
        public int Unit_pris { get; set; }
        public string Model_name { get; set; }
        public string SN { get; set; }
        public void addNewDitelsOrder()
        {
            T_orders_details_customersDAL t_Orders_Details_CustomersDAL = new T_orders_details_customersDAL();
            t_Orders_Details_CustomersDAL.addNewDitelsOrder(this);
        }
        public List<T_orders_details_customersBLL>getOrderstetels(T_orders_details_customersBLL temp)
        {
            List<T_orders_details_customersDAL> t_Orders_Details_CustomersDAL = new List<T_orders_details_customersDAL>();
            List<T_orders_details_customersBLL>t_Orders_Details_CustomersBLL = new List<T_orders_details_customersBLL>();
            t_Orders_Details_CustomersBLL = T_orders_details_customersDAL.getOrderstetels(this);
            return t_Orders_Details_CustomersBLL;
        }
        public string UpdeteDetelsOrders (T_orders_details_customersBLL Temp)
        {
            T_orders_details_customersDAL Todc = new T_orders_details_customersDAL();
          string s=Todc.UpdeteDetelsOrders(this);
            return s;
        }
        public string deleteDetelsOrders(T_orders_details_customersBLL Temp)
        {
            T_orders_details_customersDAL Todc = new T_orders_details_customersDAL();
            string s = Todc.deleteDetelsOrders(this);
            return s;
        }
    }
       
}