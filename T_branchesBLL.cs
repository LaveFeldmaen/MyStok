using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DAL;

namespace BLL
{
    public class T_branchesBLL
    {
        public int Branches_id { get; set; }
        public int Main_store_id { get; set; }
        public string Branches_name { get; set; }
        public string Branches_adrss { get; set; }
        public int AddNewBrnncher(T_branchesBLL Temp)
        {
            T_branchesDAL Tem = new T_branchesDAL();
            return Tem.AddNewBrnncher(this);
        }
        public static List<T_branchesBLL> GetAllBranches(T_branchesBLL Temp)
        {
            return T_branchesDAL.GetAllBranches(Temp);
        }

    }
}