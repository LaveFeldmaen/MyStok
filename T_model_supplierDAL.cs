using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using BLL;
using Data;


namespace DAL
{
    public class T_model_supplierDAL
    {
        public string NameWaernty { get; set; }
        public int Model_id { get; set; }
        public int Supplier_id { get; set; }
        public int Supplier_waernty { get; set; }
        public int Stock_buying_pric { get; set; }
        public string Supplier_name { get; set; }
        T_model_supplierBLL Temp;
        public T_model_supplierBLL getwaerntyBymodel(T_model_supplierBLL temp)
        {
            string Sql = "select * from T_model_supplier where Supplier_id='" + temp.Supplier_id + "' and Model_id = '" + temp.Model_id + "'";
            Database Db = new Database();
            var dt = Db.Execute(Sql);
           
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                int Model_id = (int)dt.Rows[i]["Model_id"];
                int Supplier_id = (int)dt.Rows[i]["Supplier_id"];
                int Supplier_waernty = (int)dt.Rows[i]["Supplier_waernty"];
                int Stock_buying_pric = (int)dt.Rows[i]["Stock_buying_pric"];
                Temp = new T_model_supplierBLL() { Model_id = Model_id, Supplier_id = Supplier_id, Supplier_waernty = Supplier_waernty, Stock_buying_pric = Stock_buying_pric };
            }

            return Temp;
        }
        public List<T_model_supplierBLL> GetModelPrisSupplier(T_model_supplierBLL temp)
        {
            string Sql = "select T_model_supplier.Supplier_id,T_model_supplier.Model_id, Supplier_waernty,Stock_buying_pric,Supplier_name from T_model_supplier join T_supplier on T_model_supplier.Supplier_id = T_supplier.Supplier_id where T_model_supplier.Model_id ='" + temp.Model_id + "'";
            Database Db = new Database();
            var dt = Db.Execute(Sql);
            List<T_model_supplierBLL> ModelPrisSupplier = new List<T_model_supplierBLL>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                int Model_id = (int)dt.Rows[i]["Model_id"];
                int Supplier_id = (int)dt.Rows[i]["Supplier_id"];
                int Supplier_waernty = (int)dt.Rows[i]["Supplier_waernty"];
                int Stock_buying_pric = (int)dt.Rows[i]["Stock_buying_pric"];
                string Supplier_name = dt.Rows[i]["Supplier_name"].ToString();

                T_model_supplierBLL Temp = new T_model_supplierBLL() { Model_id = Model_id, Supplier_id = Supplier_id, Supplier_waernty = Supplier_waernty, Stock_buying_pric = Stock_buying_pric, Supplier_name = Supplier_name };
                ModelPrisSupplier.Add(Temp);
            }
            return ModelPrisSupplier;


        }

    }
}

