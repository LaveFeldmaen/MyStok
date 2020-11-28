using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Data;
using BLL;

namespace DAL
{
    public class T_values_propertyDAL
    {
        public int ValProp_id { get; set; }
        
        public int Proper_id { get; set; }
        public string Proper_name { get; set; }
        public List<T_values_propertyBLL> ValuepropertyName(T_values_propertyBLL temp)
        {
            string Sql = "select*from T_values_property where Proper_id='" + temp.Proper_id + "'";
            Database Db = new Database();
            var dt = Db.Execute(Sql);
            List<T_values_propertyBLL> ValuepropertyName = new List<T_values_propertyBLL>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                string Proper_name = dt.Rows[i]["Proper_name"].ToString();
                int ValProp_id =(int) dt.Rows[i]["ValProp_id"];
                T_values_propertyBLL Temp = new T_values_propertyBLL() { Proper_name = Proper_name, ValProp_id=ValProp_id  };
                ValuepropertyName.Add(Temp);
            }
            return ValuepropertyName;


        }
        int NumRows;
        public int AddNewValueProperty(List<T_values_propertyBLL> Lstnp)
        {
            
            string sql;
            Database Db = new Database();
            for (int i = 0; i < Lstnp.Count; i++)
            {
                sql = "select * from  T_values_property where T_values_property.Proper_name='" + Lstnp[i].Proper_name+ "'and T_values_property.Proper_id='" + Lstnp[i].Proper_id+ "'";//בדיקה שהמאפיין לא מוםיע כבר בדאטא
                var dt = Db.Execute(sql);
                if (dt.Rows.Count > 0)
                {
                    Lstnp.RemoveAt(i);//אם המאפיין מופיע הסרתו מהרשימה
                    i--;
                }
            }
            for (int i = 0; i < Lstnp.Count; i++)
            {
                sql = "insert into T_values_property(Proper_id,Proper_name) values('" + Lstnp[i].Proper_id + "','" + Lstnp[i].Proper_name +"')";
                NumRows = Db.ExecuteNonQuery(sql);
            }
            return NumRows;



        }
        string V;
        public string UpdateValPropName(List<T_values_propertyBLL> LstTemp)
        {
           
            Database Db = new Database();
            for(int i = 0; i < LstTemp.Count; i++)
            {
                string Sql = "UPDATE T_values_property SET Proper_name ='" + LstTemp[i].Proper_name + "' WHERE T_values_property.ValProp_id= '" + LstTemp[i].ValProp_id + "'";
                NumRows = Db.ExecuteNonQuery(Sql);
                if (NumRows > 0)
                {
                     V = "ערכי המאפיינים עודכנו בהצלחה";
                }
            }
            return V;
        }

    }
}