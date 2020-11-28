using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using DAL;
using Data;
namespace BLL
{
    public class T_model_supplierBLL
    {
        public string NameWaernty { get; set; }
        public int Model_id { get; set; }
        public int Supplier_id { get; set; }
        public int Supplier_waernty { get; set; }
        public int Stock_buying_pric { get; set; }
        public string Supplier_name { get; set; }
        public T_model_supplierBLL getwaerntyBymodel()
        {
            T_model_supplierDAL t_Model_SupplierDAL = new T_model_supplierDAL();
            T_model_supplierBLL t_Model_SupplierBLLs = new T_model_supplierBLL();
            t_Model_SupplierBLLs = t_Model_SupplierDAL.getwaerntyBymodel(this);
            return t_Model_SupplierBLLs;
        }
        public List<T_model_supplierBLL> GetModelPrisSupplier()
        {
            T_model_supplierDAL t_Model_SupplierDAL = new T_model_supplierDAL();
            List<T_model_supplierBLL> t_Model_SupplierBLLs = new List<T_model_supplierBLL>();
            t_Model_SupplierBLLs = t_Model_SupplierDAL.GetModelPrisSupplier(this);
            return t_Model_SupplierBLLs;

        }
    }
}