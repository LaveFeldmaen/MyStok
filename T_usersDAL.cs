using BLL;
using Data;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace  DAL
{
    public class T_usersDAL
    {
        public int User_id { get; set; }
        public string User_name { get; set; }
        public string User_email { get; set; }
        public string User_fon { get; set; }
        public string User_pass { get; set; }
        public int Main_store_id { get; set; }
        string sql;
        public  T_usersBLL RegUser(T_usersBLL Temp)
        {
            sql = "select * from T_users where User_email='" + Temp.User_email + "'";
            Database Db = new Database();
            SqlDataReader Dr = Db.ExecuteReader(sql);
            if (Dr.Read())
            {
                Temp.User_email = "";
                Dr.Close();
            }
            else
            {
                Dr.Close();
                int NumRows;
                sql = "insert into T_users(User_email,User_name,User_fon,User_pass) values('" + Temp.User_email + "','" + Temp.User_name+ "','" + Temp.User_fon + "','" + Temp.User_pass + "')";
                NumRows = Db.ExecuteNonQuery(sql);
                if (NumRows > 0)
                {
                   Temp.User_id = Db.GetMaxId("User_id", "T_users");
                   Db.Close();
                }
            }
            return Temp;
        }



        public T_usersBLL LogUser(T_usersBLL Temp)
        {

            string sql = "select*from T_users join T_main_store on T_users.User_id=T_main_store.User_id  where User_email='" + Temp.User_email + "'and User_pass ='" + Temp.User_pass + "'";
            Database Db = new Database();
            SqlDataReader Dr = Db.ExecuteReader(sql);
            if (Dr.Read())
            {
                Temp.User_id = (int)Dr["User_id"];
                Temp.User_name = Dr["User_name"].ToString();
                Temp.User_email = Dr["User_email"].ToString();
                Temp.User_fon = Dr["User_fon"].ToString();
                Temp.User_pass = Dr["User_pass"].ToString();
                Temp.Main_store_id=(int)Dr["Main_store_id"];
            }
            return Temp;

        }
        public T_usersBLL forGadPass(T_usersBLL Temp)
        {
            string Sql = "select * from T_users where User_email = '" + Temp.User_email + "'";
            Database Db = new Database();
            SqlDataReader Dr = Db.ExecuteReader(Sql);
            if (Dr.Read())
            {

                Temp.User_email = Dr["User_email"].ToString();
                Temp.User_pass = Dr["User_pass"].ToString();
            }
            return Temp;
        }
    }
}