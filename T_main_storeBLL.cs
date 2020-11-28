using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DAL;

namespace BLL
{
    public class T_main_storeBLL
    {
        public int Main_store_id { get; set; }
        public string Main_store_name { get; set; }
        public string Main_store_adrass { get; set; }
        public int User_id { get; set; }
        public int AddNewStor(T_main_storeBLL Store)
        {
            T_main_storeDAL Storee = new T_main_storeDAL();
            return Storee.AddNewStor(this);
        }
        public static List<T_main_storeBLL> GetAllStore()
        {
            return T_main_storeDAL.GetAllStore();
        }

    }
}