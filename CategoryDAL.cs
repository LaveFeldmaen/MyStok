using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BLL;
using System.Data.SqlClient;
using Data;
namespace DAL
{
    public class CategoryDAL
    {
        public int Cat_id { get; set; }

        public string Cat_name { get; set; }

        public int Cat_father_id { get; set;}
        public int Status_category { get; set; }
        public int Main_store_id { get; set; }


        public CategoryDAL()
        {

        }
        public CategoryDAL(CategoryBLL categoryBLL)
        {
         
        }
        public CategoryDAL(int id,string name,int father_id)
        {
            Cat_id = id;
            Cat_name = name;
            Cat_father_id = father_id;

        }
        public CategoryDAL(int id ,string name)
        {
            Cat_id = id;
            Cat_name = name;
           
        }
        
        public static List<CategoryBLL> GetNameCategory(CategoryBLL T)
        {
           
            string sql = "select * from T_catgory where T_catgory.Status_category=1 AND T_catgory.Main_store_id='"+ T.Main_store_id + "'";
            Database Db = new Database();
            var dt = Db.Execute(sql);
            List<CategoryBLL> NameCategory = new List<CategoryBLL>();
            for(int i = 0; i < dt.Rows.Count; i++)
            {
                int Cat_id = (int)dt.Rows[i]["Cat_id"]; 
                string Cat_name = dt.Rows[i]["Cat_name"].ToString();
                CategoryBLL temp = new CategoryBLL(Cat_id, Cat_name);
                NameCategory.Add(temp);
               
            }
            return NameCategory;
        }
        public int AddNewCategory(CategoryBLL Temp)
        {
            string sql;
            Database Db = new Database();
            int NumRows;
            sql = "select * from T_catgory where T_catgory.Cat_name='"+ Temp.Cat_name + "'AND T_catgory.Main_store_id='" + Temp.Main_store_id+"'";
            var dt = Db.Execute(sql);
            if(dt.Rows.Count>0)
            {
                NumRows = 0;
            }
            else
            {
                sql = "insert into T_catgory(Cat_name,Main_store_id,Status_category) values('" + Temp.Cat_name + "','" + Temp.Main_store_id + "','" + 1+"')";
                NumRows = Db.ExecuteNonQuery(sql);

            }
            return NumRows;
        }
        string s;
        public string UpdateOrDeleteCat(CategoryBLL Temp, int Ch)
        {
            int NumRows;
            Database Db = new Database();
            
            if (Ch == 1)
            {
                string sql = "UPDATE T_catgory SET Cat_name ='" + Temp.Cat_name + "'  WHERE Cat_id='" + Temp.Cat_id + "'";
                NumRows = Db.ExecuteNonQuery(sql);
                if (NumRows > 0)
                {
                    s = "העדכון עבר בהצלחה";
                }
               
            }
            else
            {
                string sql = "UPDATE T_catgory SET Status_category ='" + Ch + "'  WHERE Cat_id='" + Temp.Cat_id + "'";
                NumRows = Db.ExecuteNonQuery(sql);
                if (NumRows > 0)
                {
                    s = "הקטגוריה נמחקה בהצלחה";
                }
            }
            return s;


        }



    }

}