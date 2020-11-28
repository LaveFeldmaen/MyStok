using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DAL;

namespace BLL
{
    public class T_usersBLL
    {
        public int User_id { get; set; }
        public string User_name { get; set; }
        public string User_email { get; set; }
        public string User_fon { get; set; }
        public string User_pass { get; set; }
        public int Main_store_id { get; set; }
        public T_usersBLL RegUser(T_usersBLL Temp)
        {
            T_usersDAL temp = new T_usersDAL();
            T_usersBLL Tempp = new T_usersBLL();
            Tempp = temp.RegUser(this);
            return Tempp;
        }
        public T_usersBLL LogUser(T_usersBLL Temp)
        {
            T_usersDAL temp = new T_usersDAL();
            T_usersBLL Tempp = new T_usersBLL();
            Tempp = temp.LogUser(this);
            return Tempp;
        }
        public T_usersBLL forGadPass(T_usersBLL Temp)
        {
            T_usersDAL temp = new T_usersDAL();
            T_usersBLL Tempp = new T_usersBLL();
            Tempp = temp.forGadPass(this);
            return Tempp;
        }

    }
}