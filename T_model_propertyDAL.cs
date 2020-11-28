using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using BLL;
using Data;
namespace DAL

{
    public class T_model_propertyDAL
    {
      public  int Model_id { get; set; }
        public int Proper_id { get; set; }

        public string Proper_name { get; set; }

        public List<T_model_propertyBLL>getProprtyByProd(T_model_propertyBLL temp)
        {
            string Sql = " select T_model_property.Proper_id ,T_propertey.Proper_name from T_model_property join T_propertey on T_model_property.Proper_id=T_propertey.Proper_id   where Model_id = '" + temp.Model_id + "'";
            Database Db = new Database();
            var dt = Db.Execute(Sql);
            List<T_model_propertyBLL> IDproperty = new List<T_model_propertyBLL>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
               
                int Proper_id = (int)dt.Rows[i]["Proper_id"];
                string Proper_name = dt.Rows[i]["Proper_name"].ToString();
                T_model_propertyBLL Temp = new T_model_propertyBLL() {  Proper_id=Proper_id, Proper_name= Proper_name };
                IDproperty.Add(Temp);

            }
            return IDproperty;
        }
        int NumRows;
        public int AddMatchModelToProp(List<T_model_propertyBLL> LstPm)
        {

            string sql;
            Database Db = new Database();
            for (int i = 0; i < LstPm.Count; i++)
            {
                sql = "select * from  T_model_property where T_model_property.Model_id='" + LstPm[i].Model_id+"' and T_model_property.Proper_id = '"+LstPm[i].Proper_id +"'";//בדיקה שהמאפיין לא מוםיע כבר בדאטא
                var dt = Db.Execute(sql);
                if (dt.Rows.Count > 0)
                {
                    LstPm.RemoveAt(i);//אם המאפיין מופיע הסרתו מהרשימה
                    i--;
                }
            }
            for (int i = 0; i < LstPm.Count; i++)
            {
                sql = "insert into T_model_property(Model_id,Proper_id) values('" + LstPm[i].Model_id + "','" + LstPm[i].Proper_id + "')";
                NumRows = Db.ExecuteNonQuery(sql);
            }
            return NumRows;
        }
    }
}