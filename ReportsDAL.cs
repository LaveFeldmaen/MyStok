using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BLL;
using Data;

namespace DAL
{
    public class ReportsDAL
    {
        public string FirstDate { get; set; }
        public string SecondDate { get; set; }
        public int Custom_id { get; set; }
        public int Supplier_id { get; set; }
        public int Branches_id { get; set; }
        public int Main_store_id { get; set; }


        public List<T_orders_customersBLL> GetOrdrrsBetwinDate(ReportsBLL Temp)
        {
      
            string sql= "   select T_orders_customers.Custom_id,T_orders_customers.Order_cust_id,T_orders_customers.Order_date,T_customers.Custom_foull_name from T_orders_customers join T_customers on T_orders_customers.Custom_id=T_customers.Custom_id where Order_date between '" + Temp.FirstDate +"' and '"+Temp.SecondDate +"'";
            Database Db = new Database();
            var dt= Db.Execute(sql);
            List<T_orders_customersBLL> t_Orders_CustomersBLLs = new List<T_orders_customersBLL>();
            for(int i = 0; i < dt.Rows.Count; i++)
            {

                int Custom_id = (int)dt.Rows[i]["Custom_id"];
                string Order_date = dt.Rows[i]["Order_date"].ToString();
                string Custom_foull_name = (dt.Rows[i]["Custom_foull_name"]).ToString();
                int Order_cust_id = (int)dt.Rows[i]["Order_cust_id"];

                T_orders_customersBLL temp = new T_orders_customersBLL() { Custom_id = Custom_id, Order_date = Order_date, Custom_foull_name = Custom_foull_name, Order_cust_id = Order_cust_id };
                t_Orders_CustomersBLLs.Add(temp);
            }
            return t_Orders_CustomersBLLs;
        }
        
        public List<T_orders_customersBLL> GetOrdersAndCustomBetwinDate(List<ReportsBLL>Temp)
        {
            int i;
            int c;
            List<T_orders_customersBLL> t_Orders_CustomersBLLs = new List<T_orders_customersBLL>();
          
            for (i = 0; i < Temp.Count; i++)
            {
                    string sql = "select T_orders_customers.Custom_id,T_orders_customers.Order_cust_id,T_orders_customers.Order_date,T_customers.Custom_foull_name from T_orders_customers join T_customers on T_orders_customers.Custom_id=T_customers.Custom_id  where Order_date between '" + Temp[i].FirstDate + "' and '" + Temp[i].SecondDate + "' and T_orders_customers.Custom_id = '" + Temp[i].Custom_id + "'";
                    Database Db = new Database();
                    var dt = Db.Execute(sql);

                    for (c = 0; c < dt.Rows.Count; c++)
                    {

                        int Custom_id = (int)dt.Rows[c]["Custom_id"];
                        string Order_date = dt.Rows[c]["Order_date"].ToString();
                        string Custom_foull_name = (dt.Rows[c]["Custom_foull_name"]).ToString();
                        int Order_cust_id = (int)dt.Rows[c]["Order_cust_id"];
                        T_orders_customersBLL temp = new T_orders_customersBLL() { Custom_id = Custom_id, Order_date = Order_date, Custom_foull_name = Custom_foull_name, Order_cust_id = Order_cust_id };
                        t_Orders_CustomersBLLs.Add(temp);
                    }
            }
            
            return t_Orders_CustomersBLLs;
        }
        string Tpropils;
        int TotPropils;
        public int GetProfitsBetwinDate(ReportsBLL Temp)
        {
            string sql = "SELECT SUM(TOSC.Unit_pris*TOSC.Quantity) AS Tprofils FROM T_orders_details_customers AS TOSC join T_orders_customers AS TOS on TOS.Order_cust_id = TOSC.Order_cust_id where Order_date between'" + Temp.FirstDate +"'and '"+Temp.SecondDate + "'and Branches_id='"+Temp.Branches_id+"'";
            Database Db = new Database();
            var dt = Db.Execute(sql);
            Tpropils = dt.Rows[0]["Tprofils"].ToString();
            if (Tpropils == "")
            {
                TotPropils = 0;
            }
            else
            {
                TotPropils = (int)dt.Rows[0]["Tprofils"];
            }
            return TotPropils;   
        }
        public int GetProfitsCustomersBetwinDat(ReportsBLL Temp)
        {
            string sql = "SELECT SUM(TOSC.Unit_pris* TOSC.Quantity)AS Tprofils FROM T_orders_details_customers AS TOSC join T_orders_customers AS TOS on TOS.Order_cust_id = TOSC.Order_cust_id where Order_date between '" + Temp.FirstDate + "' and '" + Temp.SecondDate + "' and TOS.Custom_id = '"+Temp.Custom_id+ "'and Branches_id='" + Temp.Branches_id + "'";
            Database Db = new Database();
            var dt = Db.Execute(sql);
            Tpropils = dt.Rows[0]["Tprofils"].ToString();
            if (Tpropils!="")
            {
                TotPropils = (int)dt.Rows[0]["Tprofils"];
            }
            else
            {
                TotPropils = 0;
            }
           
            
            return TotPropils;

        }
        
        public  int SowProfitsFromTheBeginningOfTheMonth(int Branches_id)
        {
            
            string sql = "SELECT SUM(TOSC.Unit_pris*TOSC.Quantity) AS Tprofils FROM T_orders_details_customers AS TOSC join T_orders_customers AS TOS on TOS.Order_cust_id = TOSC.Order_cust_id where Order_date >= GETDATE() - DAY(GETDATE()) + 1 and Branches_id='"+ Branches_id+"'";
            Database Db = new Database();
            var dt = Db.Execute(sql);
            Tpropils = dt.Rows[0]["Tprofils"].ToString();
            if (Tpropils != "")
            {
                TotPropils = (int)dt.Rows[0]["Tprofils"];
            }
            else
            {
                TotPropils = 0;
            }

            return TotPropils;


        }
        public int SowProfitsFromThisDay(ReportsBLL Temp)
        {
            string sql = "SELECT SUM(TOSC.Unit_pris*TOSC.Quantity) AS Tprofils FROM T_orders_details_customers AS TOSC join T_orders_customers AS TOS on TOS.Order_cust_id = TOSC.Order_cust_id where Order_date ='"+Temp.FirstDate+"' and Branches_id = '"+Temp.Branches_id+"'";
            Database Db = new Database();
            var dt = Db.Execute(sql);
            Tpropils = dt.Rows[0]["Tprofils"].ToString();
            if (Tpropils != "")
            {
                TotPropils = (int)dt.Rows[0]["Tprofils"];
            }
            else
            {
                TotPropils = 0;
            }

            return TotPropils;
        }
        public int GetPaymenBetwinDate(ReportsBLL Temp)
        {
            string sql = "SELECT SUM(TODS.Unit_pris * TODS.Quantity) AS Tprofils FROM T_orders_details_supplier AS TODS join T_orders_supplier AS TOS on TODS.Supplier_order_id = TOS.Supplier_order_id join T_supplier on T_supplier.Supplier_id=TOS.Supplier_id where TOS.Supplier_order_date between '" + Temp.FirstDate+"' and '"+Temp.SecondDate+ "'and  T_supplier.Main_store_id ='"+Temp.Main_store_id+"'"; 
            Database Db = new Database();
            var dt = Db.Execute(sql);
            Tpropils = dt.Rows[0]["Tprofils"].ToString();
            if (Tpropils != "")
            {
                TotPropils = (int)dt.Rows[0]["Tprofils"];
            }
            else
            {
                TotPropils = 0;
            }

            return TotPropils;

        }
        public int GetPaymentToSoplieBetwinDat(ReportsBLL Temp)
        {
            string sql = "SELECT SUM(TODS.Unit_pris * TODS.Quantity) AS Tprofils FROM T_orders_details_supplier AS TODS join T_orders_supplier AS TOS on TODS.Supplier_order_id = TOS.Supplier_order_id join T_supplier on Tos.Supplier_id = T_supplier.Supplier_id where TOS.Supplier_order_date between '" + Temp.FirstDate + "' and '" + Temp.SecondDate + "'and TOS.Supplier_id = '" + Temp.Supplier_id + "'and T_supplier.Main_store_id='"+Temp.Main_store_id+"'";

            Database Db = new Database();
            var dt = Db.Execute(sql);
            Tpropils = dt.Rows[0]["Tprofils"].ToString();
            if (Tpropils != "")
            {
                TotPropils = (int)dt.Rows[0]["Tprofils"];
            }
            else
            {
                TotPropils = 0;
            }

            return TotPropils;

        }
        public int GetPaymentFromTheBeginningOfTheMonth(ReportsBLL reportsBLL)
        {
            string sql = "SELECT SUM(TODS.Unit_pris * TODS.Quantity) AS Tprofils FROM T_orders_details_supplier AS TODS join T_orders_supplier AS TOS on TOS.Supplier_order_id = TODS.Supplier_order_id join T_supplier on TOS.Supplier_id = T_supplier.Supplier_id  where TOS.Supplier_order_date >= GETDATE() - DAY(GETDATE()) + 1 and T_supplier.Main_store_id='"+ reportsBLL.Main_store_id+"'";
            Database Db = new Database();
            var dt = Db.Execute(sql);
            Tpropils = dt.Rows[0]["Tprofils"].ToString();
            if (Tpropils != "")
            {
                TotPropils = (int)dt.Rows[0]["Tprofils"];
            }
            else
            {
                TotPropils = 0;
            }

            return TotPropils;

        }
        public int GetPaymentToSoplFromTheBeginningOfTheMonth(ReportsBLL Temp)
        {
            string sql = "SELECT SUM(TODS.Unit_pris * TODS.Quantity) AS Tprofils FROM T_orders_details_supplier AS TODS join T_orders_supplier AS TOS on TOS.Supplier_order_id = TODS.Supplier_order_id where TOS.Supplier_order_date >= GETDATE() - DAY(GETDATE()) + 1 and TOS.Supplier_id = '" + Temp.Supplier_id + "'";
            Database Db = new Database();
            var dt = Db.Execute(sql);
            if (dt.Rows.Count > 0)
            {
                string TTotPropils= dt.Rows[0]["Tprofils"].ToString();
                if (TTotPropils == "")
                {
                    TotPropils = 0;//בדיקה שחזרו תוצאות
                    return TotPropils;
                }
                else
                {
                    TotPropils = (int)dt.Rows[0]["Tprofils"];
                }
                
            }
            return TotPropils;

        }
        public int GetPaymentToSoplFromAll(ReportsBLL Temp)
        {
            string sql = "SELECT SUM(TODS.Unit_pris * TODS.Quantity) AS Tprofils FROM T_orders_details_supplier AS TODS join T_orders_supplier AS TOS on TOS.Supplier_order_id = TODS.Supplier_order_id where TOS.Supplier_id = '" + Temp.Supplier_id + "'";
            Database Db = new Database();
            var dt = Db.Execute(sql);
            Tpropils = dt.Rows[0]["Tprofils"].ToString();
            if (Tpropils != "")
            {
                TotPropils = (int)dt.Rows[0]["Tprofils"];
            }
            else
            {
                TotPropils = 0;
            }

            return TotPropils;

        }



    }
}