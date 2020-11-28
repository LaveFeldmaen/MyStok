using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DAL;

namespace BLL
{
    public class T_orders_customersBLL
    {
        public string Order_date { get; set; }
        public int Custom_id { get; set; }
        public int Order_cust_id { get; set; }
        public string Custom_foull_name { get; set; }
        public string SN { get; set; }
        public int Branches_id { get; set; }
        
        public T_orders_customersBLL addNewOrder()
        {
            T_orders_customersBLL t_Orders_CustomersBLL = new T_orders_customersBLL();
            T_orders_customersDAL t_Orders_CustomersDAL = new T_orders_customersDAL();
            t_Orders_CustomersBLL = t_Orders_CustomersDAL.addNewOrder(this);
            return t_Orders_CustomersBLL;
        }
        public static List<T_orders_customersBLL> GetAllOrders(T_orders_customersBLL Temp)
        {
            return T_orders_customersDAL.Getallorders(Temp);
            
        } 
    }
}
