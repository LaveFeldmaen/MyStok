using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DAL;

namespace BLL
{
    public class T_statusBLL
    {
        public int Status_id { get; set; }
        public string Status_prod { get; set; }
        public List<T_statusBLL> GetNameStatus()
        {
            T_statusDAL stt = new T_statusDAL();
            List<T_statusBLL> NameSststus = new List<T_statusBLL>();
            NameSststus=stt.GetNameStatus();
            return NameSststus;
        }
    }
}