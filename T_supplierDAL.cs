using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using BLL;
using Data;


namespace DAL
{
    public class T_supplierDAL
    {
        public int Supplier_id { get; set; }
        public string Supplier_name { get; set;}
        public int Cat_id { get; set; }
        public int Main_store_id { get; set; }
        

        public List<T_supplierBLL> ListSupplireName(T_supplierBLL temp)
        {
            string Sql;
            if (temp.Cat_id != 0)
            {
                 Sql= "select*from T_supplier where Cat_id='" + temp.Cat_id + "'";
            }
            else
            {
                Sql = "select*from T_supplier where Main_store_id='" + temp.Main_store_id + "'";
            }
          
            Database Db = new Database();
            var dt = Db.Execute(Sql);
            List<T_supplierBLL> SupplireName = new List<T_supplierBLL>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                int Supplier_id = (int)dt.Rows[i]["Supplier_id"];
                string Supplier_name = dt.Rows[i]["Supplier_name"].ToString();
                int Cat_id = (int)dt.Rows[i]["Cat_id"];
                T_supplierBLL Temp = new T_supplierBLL() { Supplier_id = Supplier_id, Supplier_name=Supplier_name, Cat_id= Cat_id};
                SupplireName.Add(Temp);

            }
            return SupplireName;


        }
    }
}