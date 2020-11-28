using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Data;
using BLL;
namespace DAL
{
    public class T_properteyDAL
    {
        public int Proper_id { get; set; }
        public string Proper_name { get; set; }
        public string Proper_name_admien { get; set; }

        public int Cat_id { get; set; }
        public int Sec_id { get; set; }

        public T_properteyDAL()
        {

        }
        public T_properteyDAL(int Proper_id, string Proper_name_admien)
        {
            this.Proper_id = Proper_id;
            this.Proper_name_admien = Proper_name_admien;
        }
        public List<T_properteyBLL> ListProperty(T_properteyBLL temp)
        {
            string Sql = "select*from T_propertey where Cat_id='" + temp.Cat_id + "'";
            Database Db = new Database();
            var dt = Db.Execute(Sql);
            List<T_properteyBLL> listProperty = new List<T_properteyBLL>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                int Proper_id = (int)dt.Rows[i]["Proper_id"];
                string Proper_name_admien = dt.Rows[i]["Proper_name_admien"].ToString();
                string Proper_name = dt.Rows[i]["Proper_name"].ToString();
                T_properteyBLL Temp = new T_properteyBLL() { Proper_id = Proper_id, Proper_name_admien= Proper_name_admien, Proper_name= Proper_name };
                listProperty.Add(Temp);

            }
            return listProperty;

        }

        int v;
        public List<T_properteyBLL> AddNewProperty(List<T_properteyBLL> LstProp)
        {
           
            string sql;
            Database Db = new Database();
            for (int i = 0; i < LstProp.Count; i++)
            {
                sql = "select * from  T_propertey where T_propertey.Cat_id='" + LstProp[i].Cat_id + "' and T_propertey.Proper_name='" + LstProp[i].Proper_name + "'";//בדיקה שהמאפיין לא מוםיע כבר בדאטא
                var dt = Db.Execute(sql);
                if (dt.Rows.Count > 0)
                {
                    LstProp.RemoveAt(i);
                    i--;
                }
            }
            for (int i = 0; i < LstProp.Count; i++)
            {
                sql = "insert into T_propertey(Cat_id,Proper_name,Proper_name_admien) values('" + LstProp[i].Cat_id + "','" + LstProp[i].Proper_name + "','" + LstProp[i].Proper_name_admien + "')";
                int NumRows = Db.ExecuteNonQuery(sql);


            }
            return LstProp;
        }
        string s;
        public string UpdateProprety(List<T_properteyBLL> LstProp)
        {
            Database Db = new Database();
            for(int i=0;i< LstProp.Count; i++)
            {
                string sql = "UPDATE T_propertey SET Proper_name ='" +LstProp[i].Proper_name + "', Proper_name_admien ='" +LstProp[i].Proper_name_admien+ "' WHERE T_propertey.Proper_id= '" + LstProp[i].Proper_id+ "'";
                var dt= Db.ExecuteNonQuery(sql);
                if (dt > 0)
                {
                     s = "שמות המאפיינים עוגכנו בהצלחה";
                }
            }
            return s;
        }


    }
}