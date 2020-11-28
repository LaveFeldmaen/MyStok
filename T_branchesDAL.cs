using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BLL;
using Data;

namespace DAL
{
    public class T_branchesDAL
    {
        public int Branches_id { get; set; }
        public int Main_store_id { get; set; }
        public string Branches_name { get; set; }
        public string Branches_adrss { get; set; }
        int a;
        public int AddNewBrnncher(T_branchesBLL Temp)
        {
            string sql;
            Database Db = new Database();
            sql = "select * from T_branches where T_branches.Branches_name='"+Temp.Branches_name+"'";
            var Dt = Db.Execute(sql);
            if (Dt.Rows.Count > 0)
            {
                a = 0;
            }
            else
            {
                sql = "insert into T_branches(Main_store_id, Branches_name,Branches_adrss) values('" + Temp.Main_store_id+ "', '" +Temp.Branches_name + "', '"+Temp.Branches_adrss+"')";
                Db.ExecuteNonQuery(sql);
                a = 1;
            }
            return a;
        }
        public static List<T_branchesBLL> GetAllBranches(T_branchesBLL Temp)
        {
            List<T_branchesBLL> LstBranch = new List<T_branchesBLL>();
            T_branchesBLL Tempp;
            string sql;
            Database Db = new Database();
            sql = "select * from T_branches where T_branches.Main_store_id='" + Temp.Main_store_id + "'";
            var Dt = Db.Execute(sql);
            for(int i = 0; i < Dt.Rows.Count; i++)
            {
                Tempp = new T_branchesBLL()
                {
                    Branches_name =Dt.Rows[i]["Branches_name"].ToString(),
                    Branches_adrss= Dt.Rows[i]["Branches_adrss"].ToString(),
                    Branches_id = (int)Dt.Rows[i]["Branches_id"]
                };
                LstBranch.Add(Tempp);

            }

            return LstBranch;

        }
    }
}