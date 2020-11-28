using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using BLL;
using Data;
namespace DAL
{
    public class T_statusDAL
    {
        public int Status_id { get; set; }
        public string Status_prod { get; set; }
        public List<T_statusBLL> GetNameStatus()
        {
            string Sql = "select*from  T_status";
            Database Db = new Database();
            var dt = Db.Execute(Sql);
            List<T_statusBLL> NameSststus = new List<T_statusBLL>();
            for(int i = 0; i < dt.Rows.Count; i++)
            {
                int Status_id = (int)dt.Rows[i]["Status_id"];
                string Status_prod = dt.Rows[i]["Status_prod"].ToString();
                T_statusBLL temp = new T_statusBLL() { Status_id=Status_id, Status_prod= Status_prod  };
                NameSststus.Add(temp);
            }
            return NameSststus;
        }


    }
}