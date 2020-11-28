using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DAL;


namespace BLL
{
    public class T_model_propertyBLL
    {
        public int Model_id { get; set; }
        public int Proper_id { get; set; }

        public string Proper_name { get; set; }

        public List<T_model_propertyBLL> idmodel()
        {
            T_model_propertyDAL a = new T_model_propertyDAL();
            List<T_model_propertyBLL> PropertyName = new List<T_model_propertyBLL>();
            PropertyName = a.getProprtyByProd(this);
            return PropertyName;
        }
        public int AddMatchModelToProp(List<T_model_propertyBLL> LstPm)
        {
            T_model_propertyDAL Temp = new T_model_propertyDAL();
            return Temp.AddMatchModelToProp(LstPm);
        }
    }
}