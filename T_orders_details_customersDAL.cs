using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BLL;
using Data;

namespace DAL
{
    public class T_orders_details_customersDAL
    {
        public int Order_cust_id { get; set; }
        public int Model_id { get; set; }
        public int Quantity { get; set; }
        public int Unit_pris { get; set; }
        public string Model_name { get; set;}
        public string SN { get; set; }
        public void addNewDitelsOrder(T_orders_details_customersBLL Temp)
        {
          string sql ="insert into T_orders_details_customers (Order_cust_id,Model_id,Quantity,Unit_pris) values('" + Temp.Order_cust_id + "','" + Temp.Model_id + "','" + Temp.Quantity + "','" + Temp.Unit_pris + "')";
            Database Db = new Database();
            int NumRows;
            NumRows= Db.ExecuteNonQuery(sql);
            if (NumRows > 0)
            {
               
                Db.Close();
            }
        }
        public static List<T_orders_details_customersBLL> getOrderstetels(T_orders_details_customersBLL Temp)
        {
            string sql = "select Todcust.Order_cust_id,Todcust.Model_id,Todcust.Quantity,Todcust.Unit_pris,T_model.Model_name from T_orders_details_customers AS Todcust join T_model on T_model.Model_id = Todcust.Model_id where Todcust.Order_cust_id ='"+Temp.Order_cust_id +"'";
            Database Db = new Database();
            var dt = Db.Execute(sql);
            List<T_orders_details_customersBLL> t_Orders_Details_CustomersBLLs = new List<T_orders_details_customersBLL>();
            for(int i = 0; i < dt.Rows.Count; i++)
            {
                int Order_cust_id = (int)dt.Rows[i]["Order_cust_id"];
                int Model_id = (int)dt.Rows[i]["Model_id"];
                int Quantity = (int)dt.Rows[i]["Quantity"];
                int Unit_pris = (int)dt.Rows[i]["Unit_pris"];
                string Model_name = dt.Rows[i]["Model_name"].ToString();
                T_orders_details_customersBLL t_Orders_Details_CustomersBLL = new T_orders_details_customersBLL() {  Order_cust_id= Order_cust_id, Model_id = Model_id, Quantity= Quantity, Unit_pris= Unit_pris, Model_name= Model_name };
                t_Orders_Details_CustomersBLLs.Add(t_Orders_Details_CustomersBLL);
            }
            return t_Orders_Details_CustomersBLLs;
        }
        string s;
        public string UpdeteDetelsOrders(T_orders_details_customersBLL Temp)
        {
            string sql = "UPDATE T_orders_details_customers SET Quantity ='"+Temp.Quantity+ "',Unit_pris = '"+Temp.Unit_pris+ "' WHERE Order_cust_id='"+Temp.Order_cust_id+ "'and Model_id='"+Temp.Model_id+"'";
            Database Db = new Database();
            int NumRows;
            NumRows= Db.ExecuteNonQuery(sql);
            if (NumRows > 0)
            {
                 s= "העדכון עבר בהצלחה";
            }

            return s;
        }
       
        public string deleteDetelsOrders(T_orders_details_customersBLL Temp)
        {
            
            Database Db = new Database();
            string Sql = "select * from T_orders_details_customers WHERE T_orders_details_customers.Order_cust_id='" + Temp.Order_cust_id + "'"; 
            var dt = Db.Execute(Sql);
            if (dt.Rows.Count == 1)
            {
                string sql = "delete from T_orders_details_customers where T_orders_details_customers.Order_cust_id='" + Temp.Order_cust_id + "' and T_orders_details_customers.Model_id='" + Temp.Model_id + "' delete from T_orders_customers where T_orders_customers.Order_cust_id = '" + Temp.Order_cust_id + "'";
                var Dt = Db.Execute(sql);
                if (Dt.Rows.Count > 0)
                {
                    s = "המוצר נמחק מההזמנה";
                }
            }
            else
            {
                string sql = "delete from T_orders_details_customers where T_orders_details_customers.Order_cust_id='" + Temp.Order_cust_id + "' and T_orders_details_customers.Model_id='" + Temp.Model_id + "'";
                var t = Db.Execute(sql);
                if (t.Rows.Count > 0)
                {
                    s = "המוצר נמחק מההזמנה";
                }
            
            }

            return s;
        }



    }
}