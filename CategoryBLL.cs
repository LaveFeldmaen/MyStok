using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DAL;

namespace BLL
{
    public class CategoryBLL
    {
        public int Cat_id { get; set; }

        public string Cat_name { get; set; }

        public int Cat_father_id { get; set; }
        public int Status_category { get; set; }
        public int Main_store_id { get; set; }



        public CategoryBLL()
        {

        }
       
        public CategoryBLL(int id, string name, int father_id)
        {
            Cat_id = id;
            Cat_name = name;
            Cat_father_id = father_id;

        }
        public CategoryBLL(int id,string name)
        {
            Cat_id = id;
            Cat_name = name;
        }
        public static List<CategoryBLL> GetNameCategory(CategoryBLL T)
        {
            return CategoryDAL.GetNameCategory(T); 
        }
        public int AddNewCategory(CategoryBLL Temp)
        {
            CategoryDAL temp = new CategoryDAL();
            return temp.AddNewCategory(this);
        }
        public string UpdateOrDeleteCat(CategoryBLL Temp,int Ch)
        {
            CategoryDAL temp = new CategoryDAL();
            return temp.UpdateOrDeleteCat(this,Ch);
        }

    }
}