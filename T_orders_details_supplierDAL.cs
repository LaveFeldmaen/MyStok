using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Data;
using BLL;

namespace DAL
{
    public class T_orders_details_supplierProps
    {
        public string ProperName { get; set; }
        public string ProperValue { get; set; }


    }
    public class T_orders_details_supplierDAL
    {
        public List<T_orders_details_supplierProps> LstProps { get; set; }
        public string Model_Name { get; set; }
        public string Supplier_Name { get; set; }
        public int  Supplier_order_id { get; set; }
        public int Model_id { get; set; }
        public int Quantity { get; set; }
        public int Unit_pris { get; set; }
        public int Total { get; set; }
        public string Json_property { get; set; }
        public int Supplier_waernty { get; set; }


        public string AddDedelsOrders(List<T_orders_details_supplierBLL>Temp)
        {
            string Success = "";
            for (int i = 0; i < Temp.Count; i++)
            {
                string sql = "insert into T_orders_details_supplier (Supplier_order_id,Model_id,Quantity,Unit_pris,Json_property) values('" + Temp[i].Supplier_order_id + "','" + Temp[i].Model_id + "','" + Temp[i].Quantity +"','"+Temp[i].Unit_pris+ "','" + Temp[i].Json_property + "')";
                Database Db = new Database();
                int NumRows;
                NumRows = Db.ExecuteNonQuery(sql);
                if (NumRows > 0)
                {
                    Success = "ההזמנה נקלטה במערכת";
                }

            }

            return Success;
        }
        public static List<T_orders_details_supplierBLL> GetOrdersDedelsSopliier(T_orders_details_supplierBLL Temp)
        {
            string sql = "select Todsop.Supplier_order_id,Todsop.Json_property, Todsop.Model_id,Todsop.Unit_pris,Todsop.Quantity,Todsop.Unit_pris,T_model.Model_name from T_orders_details_supplier AS Todsop join T_model on T_model.Model_id = Todsop.Model_id where Todsop.Supplier_order_id ='" + Temp.Supplier_order_id+"'";
            Database Db = new Database();
            var dt = Db.Execute(sql);
            List<T_orders_details_supplierBLL> LstSopDetels = new List<T_orders_details_supplierBLL>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                T_orders_details_supplierBLL temp = new T_orders_details_supplierBLL()
                {
                   Model_Name = dt.Rows[i]["Model_Name"].ToString(),
                   Quantity=(int)dt.Rows[i]["Quantity"],
                   Unit_pris = (int)dt.Rows[i]["Unit_pris"],
                  Json_property =dt.Rows[i]["Json_property"].ToString(),
                   Supplier_order_id= (int)dt.Rows[i]["Supplier_order_id"]
                };
                LstSopDetels.Add(temp);
            }
            return LstSopDetels;
        }
        public static List<T_orders_details_supplierBLL> CompareSuppliersOrders(List<T_orders_details_supplierBLL> Temp)
        {
            List<T_orders_details_supplierBLL> LstPrisAndWerntyy = new List<T_orders_details_supplierBLL>();
            for (int i = 0; i < Temp.Count; i++)
            {
                string sql = "select Tms.Stock_buying_pric,Tms.Supplier_waernty,Supplier_name,Model_name from T_model_supplier AS Tms join T_supplier on T_supplier.Supplier_id = Tms.Supplier_id join T_model on Tms.Model_id = T_model.Model_id where Tms.Model_id = '" + Temp[i].Model_id + "'";
                Database Db = new Database();
                var dt = Db.Execute(sql);
                for (int c = 0; c < dt.Rows.Count; c++)
                {
                    T_orders_details_supplierBLL temp = new T_orders_details_supplierBLL()
                    {
                        Model_Name = dt.Rows[c]["Model_Name"].ToString(),
                        Quantity = Temp[i].Quantity,
                        Unit_pris = (int)dt.Rows[c]["Stock_buying_pric"],
                        Supplier_Name = dt.Rows[c]["Supplier_Name"].ToString(),
                         Supplier_waernty= (int)dt.Rows[c]["Supplier_waernty"]

                    };
                    LstPrisAndWerntyy.Add(temp);
                }

            }
            return LstPrisAndWerntyy;
        }


    }
}