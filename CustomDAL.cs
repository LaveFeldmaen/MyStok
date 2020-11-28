using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using BLL;
using Data;
namespace DAL
{
    public class CustomDAL

    {
        
        
            public int CustomId { get; set; }

            public string CustomEmail { get; set; }
            public string CustomFollName { get; set; }
            public string CustomPhone { get; set; }
            public string CustomAdrss { get; set; }
            public int Branches_id { get; set; }

            public CustomDAL()
            {

            }
            public CustomDAL(int id)
            {
            CustomId = id;
            }
        public CustomDAL(int id, string email, string follname, string Phone, string adrss)
        {
            CustomId = id;
            CustomEmail = email;
            CustomFollName = follname;
            CustomPhone = Phone;
            CustomAdrss = adrss;


        }
        public CustomBLL addcust(CustomBLL custom)
        {
            string Sql = "select * from T_customers where Custom_mail='"+custom.CustomEmail + "'  and Custom_foull_name = '" +custom.CustomFollName + "' and Custom_phone ='" + custom.CustomPhone+ "' and Custom_adrss='" +custom.CustomAdrss+ "'and Branches_id='" + custom.Branches_id + "' ";
            Database Db = new Database();
            SqlDataReader Dr = Db.ExecuteReader(Sql);
            if (Dr.Read())
            {
                custom.CustomFollName = "לקוח זה כבר קיים במערכת";
                Dr.Close();
                Db.Close();

            }
            else
            {
                Dr.Close();

               Sql = "insert into T_customers (Custom_mail,Custom_foull_name,Custom_phone,Custom_adrss,Branches_id) values('" + custom.CustomEmail + "','" +custom.CustomFollName + "','" + custom.CustomPhone + "','" + custom.CustomAdrss + "','" +custom.Branches_id+"')";
                int NumRows;
                NumRows = Db.ExecuteNonQuery(Sql);
                if (NumRows > 0)
                {
                    custom.CustomId = Db.GetMaxId("Custom_id", "T_customers");
                    Db.Close();
                    
                }

            }
            return custom;

        }

        public static List<CustomBLL> getaollcust(CustomBLL Temp)// CustomBLLפונקצי שמחזירה רשימה מקושרת של אובייקטים מסוג
        {
            string sql = "select * from T_customers where T_customers.Branches_id='"+Temp.Branches_id+"'";
            Database db = new Database();
            var dt= db.Execute(sql);
           
            List<CustomBLL> LSTcustoms = new List<CustomBLL>();//הגדרת רשימה מקושרת של אובייקטים מסוג   

            for (int i=0; i < dt.Rows.Count; i++)
            {
                

                int Custom_id = (int)dt.Rows[i]["Custom_id"];
                string Custom_mail =(string) dt.Rows[i]["Custom_mail"];
                string Custom_foull_name = (dt.Rows[i]["Custom_foull_name"]).ToString();
                string Custom_phone = (dt.Rows[i]["Custom_phone"]).ToString();
                string Custom_adrss = (dt.Rows[i]["Custom_adrss"]).ToString();

                CustomBLL temp = new CustomBLL(Custom_id, Custom_mail, Custom_foull_name, Custom_phone, Custom_adrss);

                LSTcustoms.Add(temp);
            }
            return LSTcustoms;

        }
        public int delcust(CustomBLL dcust)
        {
            string sql = "DELETE FROM T_customers WHERE T_customers.Custom_id= '" + dcust.CustomId + "'";
            Database db = new Database();
            var Dt = db.ExecuteNonQuery(sql);
            if (Dt > 0)
            {
                a = 1;
            }
            return a;


        }
        int a;
        public int UpdateCust(CustomBLL custom)
        {
            string sql = "UPDATE T_customers SET Custom_mail ='" + custom.CustomEmail + "', Custom_foull_name ='" + custom.CustomFollName + "', Custom_phone='" + custom.CustomPhone + "', Custom_adrss= '" + custom.CustomAdrss + "' WHERE T_customers.Custom_id= '"+custom.CustomId+"'";
            Database db = new Database();
            db.ExecuteNonQuery(sql);
            var Dt= db.ExecuteNonQuery(sql);
            if (Dt > 0)
            {
                a = 1;
            }
            return a;

        }
        public CustomBLL getCustById(CustomBLL Temp)
        {
            string sql = "select * from T_customers  where Custom_id='" + Temp.CustomId + "' ";
            Database db = new Database();
            var dt = db.Execute(sql);
            CustomBLL customBLL=null;
            if (dt.Rows.Count > 0)
            {
                int Custom_id = (int)dt.Rows[0]["Custom_id"];
                string Custom_mail = (string)dt.Rows[0]["Custom_mail"];
                string Custom_foull_name = (dt.Rows[0]["Custom_foull_name"]).ToString();
                string Custom_phone = (dt.Rows[0]["Custom_phone"]).ToString();
                string Custom_adrss = (dt.Rows[0]["Custom_adrss"]).ToString();
                customBLL = new CustomBLL(Custom_id, Custom_mail, Custom_foull_name, Custom_phone, Custom_adrss);

            }



            return customBLL;


        }







    }
   

}    
      
    
