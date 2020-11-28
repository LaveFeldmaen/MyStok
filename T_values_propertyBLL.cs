using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DAL;


namespace BLL
{
    public class T_values_propertyBLL
    {
        public int ValProp_id { get; set; }

        public int Proper_id { get; set; }
        public string Proper_name { get; set; }
        public List<T_values_propertyBLL> ValuepropertyName()
        {
            List<T_values_propertyBLL> ValuepropertyName = new List<T_values_propertyBLL>();
            T_values_propertyDAL ip = new T_values_propertyDAL();
            ValuepropertyName = ip.ValuepropertyName(this);
            return ValuepropertyName;
        }
        public int AddNewValueProperty(List<T_values_propertyBLL> Lstnp)
        {
            T_values_propertyDAL Temp = new T_values_propertyDAL();
            return Temp.AddNewValueProperty(Lstnp);
        }
        public string UpdateValPropName(List<T_values_propertyBLL> LstT)
        {
            T_values_propertyDAL Temp = new T_values_propertyDAL();
            return Temp.UpdateValPropName(LstT);
        }
    }
}