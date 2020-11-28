using BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Data;


namespace DAL
{
    public class T_main_storeDAL
    {
        public int Main_store_id { get; set; }
        public string Main_store_name { get; set; }
        public string Main_store_adrass { get; set; }
        public int User_id { get; set; }
        int a;
        public int AddNewStor(T_main_storeBLL Store)
        {
           
            Database Db = new Database();
            string sql= "select * from T_main_store where Main_store_name='"+Store.Main_store_name+"'";
            var dt = Db.Execute(sql);
            if (dt.Rows.Count > 0)
            {
                 a = 0;
            }
            else
            {
                sql = "insert into T_main_store (Main_store_name,User_id) values('" + Store.Main_store_name+ "','" + Store.User_id +"')";
                var dtt = Db.Execute(sql);
                if (dtt.Rows.Count > 0)
                {
                     a = 1;
                }

            }
            return a;
        }
        public static List<T_main_storeBLL> GetAllStore()
        {
            T_main_storeBLL Temp;
            List<T_main_storeBLL> LstStor = new List<T_main_storeBLL>();
            string sql = "Select*from T_main_store";
            Database Db = new Database();
            var Dt = Db.Execute(sql);
            for(int i = 0; i < Dt.Rows.Count; i++)
            {
                Temp = new T_main_storeBLL()
                {
                    Main_store_name = Dt.Rows[i]["Main_store_name"].ToString(),
                     Main_store_id=(int)Dt.Rows[i]["Main_store_id"]
                };
                LstStor.Add(Temp);
            }
            return LstStor;
        }
    }
}