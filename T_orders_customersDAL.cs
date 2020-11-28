using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BLL;
using Data;

namespace DAL
{
    public class T_orders_customersDAL
    {
        public string Order_date { get; set; }
        public int Custom_id { get; set; }
        public int Order_cust_id { get; set; }
        public string Custom_foull_name { get; set; }
        public string SN { get; set; }
        public int Branches_id { get; set; }
        public T_orders_customersBLL addNewOrder(T_orders_customersBLL Temp)
        {
            string sql = "insert into T_orders_customers (Order_date,Custom_id,Branches_id) values('" + Temp.Order_date + "','" + Temp.Custom_id + "','"+Temp.Branches_id+"')";
            Database Db = new Database();
            int NumRows;
            NumRows = Db.ExecuteNonQuery(sql);
            if (NumRows > 0)
            {
                Temp.Order_cust_id = Db.GetMaxId("Order_cust_id", "T_orders_customers");
                Db.Close();

            }
            return Temp;

        }
        public static List<T_orders_customersBLL>Getallorders(T_orders_customersBLL Temp)
        {
            string sql = " select T_orders_customers.Custom_id,T_orders_customers.Order_cust_id,T_orders_customers.Order_date,T_customers.Custom_foull_name from T_orders_customers join T_customers on T_orders_customers.Custom_id=T_customers.Custom_id where T_orders_customers.Branches_id='" + Temp.Branches_id+"' ";
            Database Db = new Database();
            var dt = Db.Execute(sql);

            List<T_orders_customersBLL> LSTorders = new List<T_orders_customersBLL>();//הגדרת רשימה מקושרת של אובייקטים מסוג   

            for (int i = 0; i < dt.Rows.Count; i++)
            {


                int Custom_id = (int)dt.Rows[i]["Custom_id"];
                string Order_date =dt.Rows[i]["Order_date"].ToString();
                string Custom_foull_name = (dt.Rows[i]["Custom_foull_name"]).ToString();
                int Order_cust_id = (int)dt.Rows[i]["Order_cust_id"];

                T_orders_customersBLL temp = new T_orders_customersBLL() {  Custom_id= Custom_id, Order_date = Order_date,Custom_foull_name = Custom_foull_name, Order_cust_id = Order_cust_id};

                LSTorders.Add(temp);
            }
            return LSTorders;

        }
    }
    
}