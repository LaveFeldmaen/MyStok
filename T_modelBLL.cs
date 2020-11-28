using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DAL;

namespace BLL
{
    public class T_modelBLL
    {
        public int Model_id { get; set; }
        public int ValProp_id { get; set; }
        public string Model_name { get; set; }
        public int Cat_id { get; set; }
        public string PicMode_name { get; set; }
        public int Model_pris { get; set; }
        public int Model_werrnty { get; set; }
        public int Status_model { get; set; }

        public T_modelBLL()
        {

        }
        public T_modelBLL(int catId)
        {
            Cat_id = catId;
        }
        public T_modelBLL(int model_id, int valProp_id, string model_name)
        {
            Model_id = model_id;
            ValProp_id = valProp_id;
            Model_name = model_name;
        }
        public T_modelBLL (int model_id,string model_name)
        {
            Model_id = model_id;
            Model_name = model_name;
        }
        public  List<T_modelBLL>  nameModel()
        {
            T_modelDAL model = new T_modelDAL();
            List<T_modelBLL> Model = model.ListModelName(this);
            return Model;
        }
        public List<T_modelBLL> SowModel()
        {
            T_modelDAL sowModel = new T_modelDAL();
            List<T_modelBLL> SSowModel = new List<T_modelBLL>();
            SSowModel= sowModel.SowModel();
            return SSowModel;
        }
        public T_modelBLL AdNewModel(T_modelBLL Temp)
        {
            T_modelDAL temp = new T_modelDAL();
            return temp.AddNewModel(this);
        }
        public string UpdateOrDeleteModel(T_modelBLL Temp,int Ch)
        {
            T_modelDAL temp = new T_modelDAL();
            return temp.UpdateOrDeleteModel(this,Ch);
        }

         


    }
}