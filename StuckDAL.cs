using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using BLL;
using Data;

namespace DAL
{
    public class StuckDAL
    {
        public int Stock_id { get; set; }

        public int Model_id { get; set; }
        public string Model_name { get; set; }
        public int Stock_unique { get; set; }
        public int Stock_quantity { get; set; }

        public int Supplier_id { get; set; }
        public string Supplier_name { get; set; }
       
        public string Status_prod { get; set; }

        public string Stock_SN { get; set; }

        public int Stock_buying_pric { get; set; }

        public string Stock_buying_date { get; set; }


        public string Stock_selling_date { get; set; }
        public int Stock_selling_pric { get; set; }

        public int Supplier_waernty { get; set; }

        public int Custom_waernty { get; set; }

        public string Custom_foull_name { get; set; }
        public int Custom_id { get; set; }
        public int Branches_id { get; set; }

        

        public StuckDAL()
        {

        }
        public StuckDAL(string Stock_SN)
        {
            this.Stock_SN = Stock_SN;

        }
        public StuckDAL(int Stock_id, string Model_name, int Stock_unique, int Stock_quantity, string Supplier_name, string Status_prod, string Stock_SN, int Stock_buying_pric, string Stock_buying_date, string Stock_selling_date, int Stock_selling_pric, int Supplier_waernty, int Custom_waernty, string Custom_foull_name)
        {
            this.Stock_id = Stock_id;
            this.Model_name = Model_name;
            this.Stock_unique = Stock_unique;
            this.Stock_quantity = Stock_quantity;
            this.Supplier_name = Supplier_name;
            this.Status_prod = Status_prod;
            this.Stock_SN = Stock_SN;
            this.Stock_buying_pric = Stock_buying_pric;
            this.Stock_buying_date = Stock_buying_date;
            this.Stock_selling_date = Stock_selling_date;
            this.Stock_selling_pric = Stock_selling_pric;
            this.Supplier_waernty = Supplier_waernty;
            this.Custom_waernty = Custom_waernty;
            this.Custom_foull_name = Custom_foull_name="-";

        }
        public StuckDAL(int Stock_id, string Model_name, int Stock_unique, int Stock_quantity, string Supplier_name, string Status_prod, string Stock_SN, int Stock_buying_pric, string Stock_buying_date, int Supplier_waernty)
        {
            this.Stock_id = Stock_id;
            this.Model_name = Model_name;
            this.Stock_unique = Stock_unique;
            this.Stock_quantity = Stock_quantity;
            this.Supplier_name = Supplier_name;
            this.Status_prod = Status_prod;
            this.Stock_SN = Stock_SN;
            this.Stock_buying_pric = Stock_buying_pric;
            this.Stock_buying_date = Stock_buying_date;
            this.Supplier_waernty = Supplier_waernty;
        }
        public StuckDAL(int Stock_id, int Model_id, int Stock_unique, int Stock_quantity, int Supplier_id,string Status_prod, string Stock_SN, int Stock_buying_pric, string Stock_buying_date, int Supplier_waernty)
        {
            this.Stock_id = Stock_id;
            this.Model_id = Model_id;
            this.Stock_unique = Stock_unique;
            this.Stock_quantity = Stock_quantity;
            this.Supplier_id = Supplier_id;
            this.Status_prod = Status_prod;
            this.Stock_SN = Stock_SN;
            this.Stock_buying_pric = Stock_buying_pric;
            this.Stock_buying_date = Stock_buying_date;
            this.Supplier_waernty = Supplier_waernty;

        }







    /*    public static List<StuckBLL> Stockgetprod(StuckBLL Tmp)
        {
           string Sql = "select * from T_stock  where Stock_SN ='" + Tmp.Stock_SN + "'";
            Database Db = new Database();
            var dt = Db.Execute(Sql);
            List<StuckBLL> LSTstock = new List<StuckBLL>();

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                int Stock_id = (int)dt.Rows[i]["Stock_id"];
                string Model_name = dt.Rows[i]["Model_name"].ToString();
                int Stock_unique = (int)dt.Rows[i]["Stock_unique"];
                int Stock_quantity = (int)dt.Rows[i]["Stock_quantity"];
                string Supplier_name = dt.Rows[i]["Supplier_name"].ToString();
                string Status_prod = dt.Rows[i]["Status_prod"].ToString();
                string Stock_SN = dt.Rows[i]["Stock_SN"].ToString();
                int Stock_buying_pric = (int)dt.Rows[i]["Stock_buying_pric"];
                string Stock_buying_date = dt.Rows[i]["Stock_buying_date"].ToString();
                string Stock_selling_date = dt.Rows[i]["Stock_selling_date"].ToString();
                int Stock_selling_pric = (int)dt.Rows[i]["Stock_selling_pric"];
                int Supplier_waernty = (int)dt.Rows[i]["Supplier_waernty"];
                int Custom_waernty = (int)dt.Rows[i]["Custom_waernty"];
                string Custom_foull_name = dt.Rows[i][" Custom_foull_name "].ToString();

                if (Stock_selling_date != null)
                {
                    StuckBLL Temp = new StuckBLL(Stock_id, Model_name, Stock_unique, Stock_quantity, Supplier_name, Status_prod, Stock_SN, Stock_buying_pric, Stock_buying_date, Stock_selling_date, Stock_selling_pric, Supplier_waernty, Custom_waernty, Custom_foull_name);
                    LSTstock.Add(Temp);
                }
                else
                {
                    StuckBLL Temp = new StuckBLL(Stock_id, Model_name, Stock_unique, Stock_quantity, Supplier_name, Status_prod, Stock_SN, Stock_buying_pric, Stock_buying_date, Supplier_waernty);
                    LSTstock.Add(Temp);
                }


            }


            return LSTstock;


        }*/
        public static List<StuckBLL> Getallstock(T_branchesBLL Tempp)
        {
            string Sql = " select T_stuocks.Stock_id , T_stuocks.Stock_unique  , T_stuocks.Stock_quantity  ,T_supplier.Supplier_name , T_model.Model_name , T_status.Status_prod  , T_stuocks.Stock_SN,  T_stuocks.Stock_buying_pric ,  T_stuocks.Stock_buying_date , T_model_supplier.Supplier_waernty  FROM T_stuocks   INNER JOIN T_supplier ON T_stuocks.Supplier_id = T_supplier.Supplier_id  INNER JOIN T_model ON T_stuocks.Model_id = T_model.Model_id INNER JOIN T_model_supplier ON T_stuocks.Supplier_id = T_model_supplier.Supplier_id AND T_stuocks.Model_id = T_model_supplier.Model_id    INNER JOIN T_status ON T_stuocks.Status_prod = T_status.Status_id where T_stuocks.Branches_id='"+Tempp.Branches_id+"'";



            Database Db = new Database();
            var dt = Db.Execute(Sql);
            List<StuckBLL> AllLSTstock = new List<StuckBLL>();
          for (int i=0; i < dt.Rows.Count; i++)
          {

            int Stock_id = (int)dt.Rows[i]["Stock_id"];
            int Stock_unique = (int)dt.Rows[i]["Stock_unique"];
            int Stock_quantity = (int)dt.Rows[i]["Stock_quantity"];
            string Supplier_name = dt.Rows[i]["Supplier_name"].ToString();
            string Model_name = dt.Rows[i]["Model_name"].ToString();
            string Status_prod = dt.Rows[i]["Status_prod"].ToString();
            string Stock_SN = dt.Rows[i]["Stock_SN"].ToString();
            int Stock_buying_pric = (int)dt.Rows[i]["Stock_buying_pric"];
            string Stock_buying_date = dt.Rows[i]["Stock_buying_date"].ToString();
            int Supplier_waernty = (int)dt.Rows[i]["Supplier_waernty"];
            StuckBLL Temp = new StuckBLL(Stock_id, Stock_unique, Stock_quantity, Supplier_name, Model_name, Status_prod, Stock_SN, Stock_buying_pric, Stock_buying_date, Supplier_waernty);
            AllLSTstock.Add(Temp);


          }
            return AllLSTstock;




        }
     
        public StuckBLL StuckSn(StuckBLL stuck)
        {
            string Sql = " select T_stuocks.Stock_id , T_stuocks.Stock_unique  , T_stuocks.Stock_quantity  ,T_supplier.Supplier_name , T_model.Model_name , T_status.Status_prod  , T_stuocks.Stock_SN,  T_stuocks.Stock_buying_pric ,  T_stuocks.Stock_buying_date , T_model_supplier.Supplier_waernty  FROM T_stuocks   INNER JOIN T_supplier ON T_stuocks.Supplier_id = T_supplier.Supplier_id  INNER JOIN T_model ON T_stuocks.Model_id = T_model.Model_id INNER JOIN T_model_supplier ON T_stuocks.Supplier_id = T_model_supplier.Supplier_id AND T_stuocks.Model_id = T_model_supplier.Model_id    INNER JOIN T_status ON T_stuocks.Status_prod = T_status.Status_id  where T_stuocks.Stock_SN = '" + stuck.Stock_SN +"'" ;



            Database Db = new Database();
            SqlDataReader Dr = Db.ExecuteReader(Sql);

            if(Dr.Read())
            {

                stuck. Stock_id = (int)Dr["Stock_id"];
                stuck.Stock_unique = (int)Dr["Stock_unique"];
                stuck.Stock_quantity = (int)Dr["Stock_quantity"];
                stuck.Supplier_name = Dr["Supplier_name"].ToString();
                stuck.Model_name = Dr["Model_name"].ToString();
                stuck.Status_prod = Dr["Status_prod"].ToString();
                stuck.Stock_SN = Dr["Stock_SN"].ToString();
                stuck.Stock_buying_pric = (int)Dr["Stock_buying_pric"];
                stuck.Stock_buying_date = Dr["Stock_buying_date"].ToString();
                stuck.Supplier_waernty = (int)Dr["Supplier_waernty"];
                
                

            }
            return stuck;




        }
        int v;
        public StuckBLL AddProdInStuck(StuckBLL Temp)
        {
            string sql = "select * from T_stuocks where Stock_SN ='" +Temp.Stock_SN+ "'AND T_stuocks.Branches_id='"+Temp.Branches_id+"'";
            Database Db = new Database();
            SqlDataReader Dr = Db.ExecuteReader(sql);
            if (Dr.Read())
            {
                 v = 1;
                Dr.Close();
            }
            else
            {
                Dr.Close();
                int NumRows;
                string Sql = "insert into T_stuocks(Model_id,Stock_unique,Stock_quantity,Supplier_id,Status_prod,Stock_SN,Stock_buying_pric,Stock_buying_date,Supplier_waernty,Branches_id)values('" + Temp.Model_id+"','"+Temp.Stock_unique+"','"+Temp.Stock_quantity+"','"+Temp.Supplier_id+"','"+int.Parse(Temp.Status_prod)+ "','"+Temp.Stock_SN+"','"+Temp.Stock_buying_pric+"','"+Temp.Stock_buying_date+"','"+Temp.Supplier_waernty+ "','" +Temp.Branches_id+"')";
                Database DDb = new Database();
                NumRows = DDb.ExecuteNonQuery(Sql);
                if (NumRows > 0)
                {
                    Temp.Stock_id = DDb.GetMaxId("Stock_id", "T_stuocks");
                    DDb.Close();
                }
               
            }
            return Temp;

        }
        
        public StuckBLL Updatestatus(StuckBLL Temp)
        {
            string sql = "UPDATE T_stuocks SET Stock_selling_date='"+Temp.Stock_selling_date+ "',Stock_selling_pric='"+Temp.Stock_selling_pric+"',Custom_id='"+Temp.Custom_id+"',Model_id='"+Temp.Model_id+"', Status_prod ='2 ' WHERE T_stuocks.Stock_SN= '" + Temp.Stock_SN + "'";
            Database db = new Database();
            int NumRows;
            NumRows = db.ExecuteNonQuery(sql);
            if (NumRows>0)
            {
                Temp.Status_prod = "1";
               
            }
            return Temp;


        }



    }





}



   
        

    
        

        

        





   
