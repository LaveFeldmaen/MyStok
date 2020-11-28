using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BLL;
using Data;

namespace DAL
{
    public class T_model_werrntyDAL
    {
        public int Model_id { get; set;}
        public int Model_werrnty { get; set; }
        public int Model_pris { get; set; }
        public T_model_werrntyBLL GetPrisModel(T_model_werrntyBLL Temp)
        {
            string sql = "select * from T_model_werrnty  where Model_id='" + Temp.Model_id + "' ";
            Database db = new Database();
            var dt = db.Execute(sql);
            T_model_werrntyBLL t_Model_WerrntyBLL = null;

            if (dt.Rows.Count > 0)
            {
                int Model_id = (int)dt.Rows[0]["Model_id"];
                int Model_werrnty = (int)dt.Rows[0]["Model_werrnty"];
                int Model_pris = (int)dt.Rows[0]["Model_pris"];
                t_Model_WerrntyBLL = new T_model_werrntyBLL() { Model_id= Model_id, Model_pris= Model_pris, Model_werrnty= Model_werrnty};
                

            }
            return t_Model_WerrntyBLL;


        }
    }
}