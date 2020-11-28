using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DAL;

namespace BLL
{
    public class TvalpropertyIdBLL
    {
        public int ValProp_id { get; set; }
    }
    public class T_property_stueckBLL
    {
        public int Model_id { get; set; }
        public int Proprtey_stueck_id { get; set; }
        public int Stueck_id { get; set; }
        public int Proper_id { get; set; }
        public int ValProp_id { get; set; }
        public int Branches_id { get; set; }
        public List<TvalpropertyIdBLL> lstValPropId { get; set; }
        public void PropertyStueckInser()
        {
            T_property_stueckDAL t_Property_StueckDAL = new T_property_stueckDAL();
            t_Property_StueckDAL.PropertyStueckInser(this);

        }
        public List<T_property_stueckBLL> ContOfSto(T_property_stueckBLL Temp)
        {
            T_property_stueckDAL temp = new T_property_stueckDAL();
            List<T_property_stueckBLL> LstPropCobt = temp.ContOfSto(this);
            return LstPropCobt;
        }

    }
}