using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DAL;



namespace BLL
{
    public class CustomBLL
    {

        public int CustomId { get; set; }

        public string CustomEmail { get; set; }
        public string CustomFollName { get; set; }
        public string CustomPhone { get; set; }
        public string CustomAdrss { get; set; }
        public int Branches_id { get; set; }


        public CustomBLL()
        {

        }
        public CustomBLL(int id)
        {
            CustomId = id;
        }
        public CustomBLL(int id, string email, string follname, string Phone,string adrss)
        {
            CustomId = id;
            CustomEmail = email;

            CustomFollName = follname;
            CustomPhone = Phone;
            CustomAdrss = adrss;


        }

        public CustomBLL addcust()//הוספת לקוח
        {
            CustomBLL customBLL = new CustomBLL(); 
            CustomDAL cust = new CustomDAL();
            customBLL= cust.addcust(this);
            return customBLL;
        }
        public  CustomBLL getCustById(int id)
        {
            CustomDAL customDAL = new CustomDAL();
            CustomBLL customBLL = new CustomBLL();
            customBLL= customDAL.getCustById(this);
            return customBLL;
        } 
       
        public static List<CustomBLL> getaollcust(CustomBLL Temp)//קבלת רשימת לקוחות מלאה
        {
            return CustomDAL.getaollcust(Temp);
        }
        public int delcust()//מחיקת לקוח
        {
            CustomDAL dcust = new CustomDAL();
          return  dcust.delcust(this);
        }
        public int UpdateCust()
        {
            CustomDAL custom = new CustomDAL();
           return custom.UpdateCust(this);
        }
        
        




    }
}


