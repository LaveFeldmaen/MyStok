using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DAL;

namespace BLL
{
    public class T_model_werrntyBLL
    {
        public int Model_id { get; set; }
        public int Model_werrnty { get; set; }
        public int Model_pris { get; set; }
        public T_model_werrntyBLL GetPrisModel() 
        {
            T_model_werrntyDAL t_Model_WerrntyDAL = new T_model_werrntyDAL();
            T_model_werrntyBLL t_Model_WerrntyBLL = new T_model_werrntyBLL();
            t_Model_WerrntyBLL = t_Model_WerrntyDAL.GetPrisModel(this);
            return t_Model_WerrntyBLL;

        }
    }
}