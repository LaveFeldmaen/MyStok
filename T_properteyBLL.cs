using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DAL;

namespace BLL
{
    public class T_properteyBLL
    {
        public int Proper_id { get; set; }
        public string Proper_name { get; set; }
        public string Proper_name_admien { get; set; }

        public int Cat_id { get; set; }
        public int Sec_id { get; set; }

        public T_properteyBLL()
        {

        }
        public T_properteyBLL(int Cat_id)
        {
            this.Cat_id = Cat_id; 
        }
        public T_properteyBLL(int Proper_id, string Proper_name_admien)
        {
            this.Proper_id = Proper_id;
            this.Proper_name_admien = Proper_name_admien;
        }
        public List<T_properteyBLL> ListProperty()
        {
            T_properteyDAL property = new T_properteyDAL();
            List<T_properteyBLL> Propety = property.ListProperty(this);
            return Propety;
        }
        public List<T_properteyBLL> AddNewProperty(List<T_properteyBLL>LstProp)
        {
            List<T_properteyBLL> LLstProp = LstProp; 
            T_properteyDAL Temp = new T_properteyDAL(); 
            return Temp.AddNewProperty(LLstProp);
        }
        public string UpdateProprety(List<T_properteyBLL> LstProp)
        {
            T_properteyDAL Temp = new T_properteyDAL();
            return Temp.UpdateProprety(LstProp);
        }
    }
}