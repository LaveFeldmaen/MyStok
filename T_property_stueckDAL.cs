using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using BLL;
using Data;


namespace DAL
{
    public class TvalpropertyIdDAl
    {
        public int ValProp_id { get; set; }
    }
    public class T_property_stueckDAL
    {
        public int Model_id { get; set; }
        public int Proprtey_stueck_id { get;set; }
        public int Stueck_id { get; set; }
        public int Proper_id { get; set; }
        public int ValProp_id { get; set; }
        public int Branches_id { get; set; }
        public List<TvalpropertyIdDAl> lstValPropId { get; set; }
        public void PropertyStueckInser(T_property_stueckBLL Temp)
        {
            int NumRows;
            string Sql = "insert into T_property_stueck(Stueck_id,Proper_id,ValProp_id)values('" + Temp.Stueck_id + "','" + Temp.Proper_id + "','" + Temp.ValProp_id+ "')";
            Database Db = new Database();
            NumRows = Db.ExecuteNonQuery(Sql);
            if (NumRows > 0)
            {
                int n;
                n = 10;

            }

        }
        public  List<T_property_stueckBLL> ContOfSto (T_property_stueckBLL Temp)
        {
            List<T_property_stueckBLL> LstPropStoc = new List<T_property_stueckBLL>();
            string sql = "select T_stuocks.Model_id ,T_stuocks.Stock_id,T_property_stueck.ValProp_id from T_stuocks join T_property_stueck on T_property_stueck.Stueck_id = T_stuocks.Stock_id where T_stuocks .Model_id = '"+Temp.Model_id+ "'And T_stuocks.Status_prod=1 AND Branches_id='"+Temp.Branches_id+"'";
            Database Db = new Database();
            var dt = Db.Execute(sql);
             for(int i = 0; i < dt.Rows.Count; i++)
             {
                Stueck_id =(int)dt.Rows[i]["Stock_id"];
                Model_id = (int)dt.Rows[i]["Model_id"];
                ValProp_id = (int)dt.Rows[i]["ValProp_id"];
                T_property_stueckBLL t_Property_StueckBLL = new T_property_stueckBLL() { Model_id= Model_id, Stueck_id= Stueck_id, ValProp_id= ValProp_id };
                LstPropStoc.Add(t_Property_StueckBLL);
             }
            return LstPropStoc;


        }
       


    }
}