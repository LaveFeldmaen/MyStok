using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DAL;


namespace BLL
{
    public class  StuckBLL
    {
        public int Stock_id { get; set; }
        public int Model_id { get; set; }


        public string Model_name { get; set; }
        public int Stock_unique { get; set; }
        public int Stock_quantity { get; set; }
        public int Supplier_id { get; set; }
        public string Supplier_name { get; set; }
        public string Status_prod { get; set; }

        public string Stock_SN { get; set; }

        public int Stock_buying_pric { get; set; }

        public string Stock_buying_date { get; set; }


        public string Stock_selling_date { get; set; }
        public int Stock_selling_pric { get; set; }

        public int Supplier_waernty { get; set; }

        public int Custom_waernty { get; set; }

        public string Custom_foull_name { get; set; }
        public int Custom_id { get; set; }
        public int Branches_id { get; set; }

        public  StuckBLL()
        {

        }
        public  StuckBLL(string Stock_SN)
        {
            this.Stock_SN = Stock_SN;

        }
        public  StuckBLL(int Stock_id, string Model_name, int Stock_unique, int Stock_quantity, string Supplier_name, string Status_prod, string Stock_SN, int Stock_buying_pric, string Stock_buying_date, string Stock_selling_date, int Stock_selling_pric, int Supplier_waernty, int Custom_waernty, string Custom_foull_name)
        {
            this.Stock_id = Stock_id;
            this.Model_name = Model_name;
            this.Stock_unique = Stock_unique;
            this.Stock_quantity = Stock_quantity;
            this.Supplier_name = Supplier_name;
            this.Status_prod = Status_prod;
            this.Stock_SN = Stock_SN;
            this.Stock_buying_pric = Stock_buying_pric;
            this.Stock_buying_date = Stock_buying_date;
            this.Stock_selling_date = Stock_selling_date;
            this.Stock_selling_pric = Stock_selling_pric;
            this.Supplier_waernty = Supplier_waernty;
            this.Custom_waernty = Custom_waernty;
            this.Custom_foull_name = Custom_foull_name;

        }
        public  StuckBLL(int Stock_id,  int Stock_unique, int Stock_quantity, string Supplier_name, string Model_name, string Status_prod, string Stock_SN, int Stock_buying_pric, string Stock_buying_date, int Supplier_waernty)
        {
            this.Stock_id = Stock_id;
            this.Stock_unique = Stock_unique;
            this.Stock_quantity = Stock_quantity;
            this.Supplier_name = Supplier_name;
            this.Model_name = Model_name;
            this.Status_prod = Status_prod;
            this.Stock_SN = Stock_SN;
            this.Stock_buying_pric = Stock_buying_pric;
            this.Stock_buying_date = Stock_buying_date;
            this.Supplier_waernty = Supplier_waernty;



        }
        public StuckBLL(int Stock_id, int Model_id, int Stock_unique, int Stock_quantity, int Supplier_id, string Status_prod, string Stock_SN, int Stock_buying_pric, string Stock_buying_date, int Supplier_waernty)
        {
            this.Stock_id = Stock_id;
            this.Model_id = Model_id;
            this.Stock_unique = Stock_unique;
            this.Stock_quantity = Stock_quantity;
            this.Supplier_id = Supplier_id;
            this.Status_prod = Status_prod;
            this.Stock_SN = Stock_SN;
            this.Stock_buying_pric = Stock_buying_pric;
            this.Stock_buying_date = Stock_buying_date;
            this.Supplier_waernty = Supplier_waernty;

        }

        public StuckBLL(int v1, int v2, int v3, int v4, int v5, object selectedValue, string v6, int v7, string v8, int v9)
        {
        }

        /* public  List<StuckBLL> Stockgetprod()
           {



               return StuckDAL.Stockgetprod(this);



           }*/

        public static List<StuckBLL> Getallstock(T_branchesBLL Temp)
        {
           return  StuckDAL.Getallstock(Temp);

        }
        public  void StuckSn()
        {
            StuckDAL stuck = new StuckDAL();
           stuck.StuckSn(this);
           
                
        }
        public StuckBLL AddProdInStuck()
        {
            StuckDAL stuckDAL = new StuckDAL();
            return stuckDAL.AddProdInStuck(this);
        }
        public StuckBLL Updatestatus()
        {
            StuckBLL stuckBLL = new StuckBLL();
            StuckDAL stuckDAL = new StuckDAL();
            stuckDAL.Updatestatus(this);
            return stuckBLL = stuckDAL.Updatestatus(this);
        }







    }
} 