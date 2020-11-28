using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DAL;

namespace BLL
{
    public class ReportsBLL
    {
        public string FirstDate { get; set; }
        public string SecondDate { get; set; }
        public int Custom_id { get; set; }
        public int Supplier_id { get; set; }
        public int Branches_id { get; set; }
        public int Main_store_id { get; set; }

        public List<T_orders_customersBLL>GetOrdrrsBetwinDate(ReportsBLL reportsBLL)
        {
            ReportsDAL reportsDAL = new ReportsDAL();
            List<T_orders_customersBLL> t_Orders_CustomersBLLs = new List<T_orders_customersBLL>();
            t_Orders_CustomersBLLs = reportsDAL.GetOrdrrsBetwinDate(this);
            return t_Orders_CustomersBLLs;
        }   
        public List<T_orders_customersBLL> GetOrdersAndCustomBetwinDate(List<ReportsBLL>reportsBLL)
        {
            ReportsDAL reportsDAL = new ReportsDAL();
            List<T_orders_customersBLL> t_Orders_CustomersBLLs = new List<T_orders_customersBLL>();
            t_Orders_CustomersBLLs = reportsDAL.GetOrdersAndCustomBetwinDate(reportsBLL);
            return t_Orders_CustomersBLLs;
        }
        public int GetProfitsBetwinDate(ReportsBLL reportsBLL)
        {
            ReportsDAL reportsDAL = new ReportsDAL();
            int TotProfits = reportsDAL.GetProfitsBetwinDate(this);
            return TotProfits;
        }
        public int GetProfitsCustomersBetwinDat(ReportsBLL reportsBLL)
        {
            ReportsDAL reportsDAL = new ReportsDAL();
            int TotProfits = reportsDAL.GetProfitsCustomersBetwinDat(this);
            return TotProfits;
        }
        public  int SowProfitsFromTheBeginningOfTheMonth(int Branches_id)
        {
            ReportsDAL reportsDAL = new ReportsDAL();
             return reportsDAL.SowProfitsFromTheBeginningOfTheMonth( Branches_id);
            
        }
        public int SowProfitsFromThisDay(ReportsBLL reportsBLL)
        {
            ReportsDAL reportsDAL = new ReportsDAL();
            return reportsDAL.SowProfitsFromThisDay(this);
        }
        public int GetPaymebyBetwinDate(ReportsBLL reportsBLL)
        {
            ReportsDAL reportsDAL = new ReportsDAL();
            int TotProfits = reportsDAL.GetPaymenBetwinDate(this);
            return TotProfits;
        }
        public int GetPaymentToSoplieBetwinDat(ReportsBLL reportsBLL)
        {
            ReportsDAL reportsDAL = new ReportsDAL();
            int TotProfits = reportsDAL.GetPaymentToSoplieBetwinDat(this);
            return TotProfits;
        }
         public int GetPaymentFromTheBeginningOfTheMonth(ReportsBLL reportsBLL)
         {
            ReportsDAL reportsDAL = new ReportsDAL();
            return reportsDAL.GetPaymentFromTheBeginningOfTheMonth(this);

         }
        public int GetPaymentToSoplFromTheBeginningOfTheMonth(ReportsBLL Temp)
        {
            ReportsDAL reportsDAL = new ReportsDAL();
            return reportsDAL.GetPaymentToSoplFromTheBeginningOfTheMonth(this);

        }
        public int GetPaymentToSoplFromAll(ReportsBLL Temp)
        {
            ReportsDAL reportsDAL = new ReportsDAL();
            return reportsDAL.GetPaymentToSoplFromAll(this);

        }
        

    }
}