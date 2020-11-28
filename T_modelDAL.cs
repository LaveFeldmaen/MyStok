using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Data;
using BLL;

namespace DAL
{
    public class T_modelDAL
    {
        public int Model_id { get; set; }
        public int ValProp_id { get; set; }
        public string Model_name { get; set; }
        public int Cat_id { get; set; }
        public string PicMode_name { get; set; }
        public int Model_pris { get; set; }
        public int Model_werrnty { get; set; }
        public int Status_model { get; set; }

        
        public T_modelDAL()
        {

        }
       
        public T_modelDAL(int catId)
        {
            Cat_id = catId;
        }
        public T_modelDAL(int model_id, int valProp_id, string model_name)
        {
            Model_id = model_id;
            ValProp_id = valProp_id;
            Model_name = model_name;
        }
        public  List<T_modelBLL> ListModelName (T_modelBLL temp)
        {
            string Sql = "select*from T_model where Cat_id='" + temp.Cat_id + "'AND Status_model='"+1+"'";
            Database Db = new Database();
            var dt = Db.Execute(Sql);
            List <T_modelBLL>modelName = new List<T_modelBLL>();
            for(int i = 0; i < dt.Rows.Count; i++)
            {
                int Model_id = (int)dt.Rows[i]["Model_id"];
               // int ValProp_id = (int)dt.Rows[i]["ValProp_id"];
                string Model_name = dt.Rows[i]["Model_name"].ToString();
                T_modelBLL Temp = new T_modelBLL(Model_id,/* ValProp_id,*/ Model_name);
                modelName.Add(Temp);
              
            }
            return modelName;
           
           
        }
        public List<T_modelBLL> SowModel()
        {
            string Sql = "select Tm.Model_id,Tm.Model_name,Tm.PicMode_name,T_model_werrnty.Model_pris  from  T_model Tm join T_model_werrnty on Tm.Model_id=T_model_werrnty.Model_id ";
            Database Db = new Database();
            var dt = Db.Execute(Sql);
            List<T_modelBLL> sowModel = new List<T_modelBLL>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                int Model_id = (int)dt.Rows[i]["Model_id"];
                string PicMode_name = dt.Rows[i]["PicMode_name"].ToString();
                string Model_name = dt.Rows[i]["Model_name"].ToString();
                int Model_pris = (int)dt.Rows[i]["Model_pris"];
                T_modelBLL Temp = new T_modelBLL() { Model_id = Model_id, Model_name = Model_name, PicMode_name = PicMode_name, Model_pris = Model_pris };
                sowModel.Add(Temp);

            }
            return sowModel;
        }
        T_modelBLL NewTemp;
        public T_modelBLL AddNewModel(T_modelBLL Temp)
        {
            string sql;
            Database Db = new Database();
            int NumRows;
            sql = "select * from T_model where T_model.Model_name='"+ Temp.Model_name + "'AND T_model.Cat_id='"+Temp.Cat_id+"'";
            var dt = Db.Execute(sql);
            if (dt.Rows.Count > 0)
            {
                NewTemp= new T_modelBLL() {  Model_id = 0 };
                return NewTemp;
            }
            
            sql = "insert into T_model(Cat_id,Model_name,Status_model) values('" + Temp.Cat_id + "','"+Temp.Model_name + "','" +1+ "')";
            NumRows = Db.ExecuteNonQuery(sql);
            if (NumRows > 0)
            {
                sql = "select * from T_model where T_model.Model_name='"+Temp.Model_name+"'";
                dt = Db.Execute(sql);
                for(int i = 0; i < dt.Rows.Count; i++)
                {
                    NewTemp = new T_modelBLL()
                    {
                        Model_id = (int)dt.Rows[i]["Model_id"],
                        Model_pris = Temp.Model_pris,
                        Model_werrnty=Temp.Model_werrnty
                    };
                }
                sql = "insert into T_model_werrnty(Model_id,Model_pris,Model_werrnty)values('" + NewTemp.Model_id + "','" + NewTemp.Model_pris + "','" + NewTemp.Model_werrnty + "')";
                NumRows = Db.ExecuteNonQuery(sql);
                if (NumRows > 0)
                {
                    NewTemp.Model_id = 1;
                }

            }
            return NewTemp;



        }
        string s;
        public string UpdateOrDeleteModel(T_modelBLL Temp, int Ch)
        {
            int NumRows;
            Database Db = new Database();
            if (Ch == 1)
            {
                string sql = "UPDATE T_model SET Model_name ='" + Temp.Model_name + "'  WHERE Model_id='" + Temp.Model_id + "'UPDATE T_model_werrnty SET Model_pris ='" + Temp.Model_pris + "', Model_werrnty = '" + Temp.Model_werrnty + "' WHERE Model_id = '" + Temp.Model_id + "'";
                NumRows = Db.ExecuteNonQuery(sql);
                if (NumRows > 0)
                {
                    s = "העדכון בוצע בהצלחה";
                }

            }
            else
            {
                string sql = "UPDATE T_model SET Status_model ='" + Ch+ "'  WHERE Model_id='" + Temp.Model_id+"'";
                NumRows = Db.ExecuteNonQuery(sql);
                if (NumRows > 0)
                {
                    s = "המחיקה בוצעה בהצלחה";
                }
            }
            return s;
        }
    }
}