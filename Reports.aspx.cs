using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;

namespace Msmf.admin
{
    public partial class Reports : System.Web.UI.Page
    {
        string date;
        protected void Page_Load(object sender, EventArgs e)
        {
            Main_store_id = (int)Session["Main_store_id"];
            if (!IsPostBack)
            {
                RptAllCustomers();
                
                date = DateTime.Now.ToString("s");
                FirstDateProfits.Text = date.Substring(0, 10);
                SowCatgoryName();
                RptSupler();
                RPTbranch();

            }


        }
        int Main_store_id;
        public void RPTbranch()
        {
            T_branchesBLL Temp = new T_branchesBLL() { Main_store_id = Main_store_id };
            DDLBranch.DataSource = T_branchesBLL.GetAllBranches(Temp);
            DDLBranch.DataTextField = "Branches_name";
            DDLBranch.DataValueField = "Branches_id";
            DDLBranch.DataBind();
            DLbranc.DataSource = T_branchesBLL.GetAllBranches(Temp);
            DLbranc.DataTextField = "Branches_name";
            DLbranc.DataValueField = "Branches_id";
            DLbranc.DataBind();
        }


        protected void SowOrdersBetwinDate_Click(object sender, EventArgs e)
        {
            int big = FirstDate.Text.CompareTo(SecondDate.Text);
            if (big >= 0)
            {
                string date = FirstDate.Text;
                FirstDate.Text = SecondDate.Text;
                SecondDate.Text = date;
            }
            ReportsBLL reportsBLL = new ReportsBLL() { FirstDate = FirstDate.Text, SecondDate = SecondDate.Text };
            List<T_orders_customersBLL> t_Orders_CustomersBLLs = new List<T_orders_customersBLL>();
            t_Orders_CustomersBLLs = reportsBLL.GetOrdrrsBetwinDate(reportsBLL);
            Rptbetwindateordr(t_Orders_CustomersBLLs);



        }
        public void Rptbetwindateordr(List<T_orders_customersBLL> t_Orders_CustomersBLLs)
        {
            RPTallordersbetwindate.DataSource = t_Orders_CustomersBLLs;
            RPTallordersbetwindate.DataBind();
        }



        protected void BetwinDateOrd_Click(object sender, EventArgs e)
        {

            BetwinDateOrd.Visible = false;
            OrdrDate.Visible = true;
            FirstDate.Visible = true;
            SecondDate.Visible = true;
            SowOrdersBetwinDate.Visible = true;
        }

        protected void clireOrdeDate_Click(object sender, EventArgs e)
        {
            BetwinDateOrd.Visible = true;
            OrdrDate.Visible = false;
            FirstDate.Visible = false;
            SecondDate.Visible = false;
            SowOrdersBetwinDate.Visible = false;
            RPTallordersbetwindate.Visible = false;
        }

        protected void BetwinDateOrdCustom_Click(object sender, EventArgs e)
        {
            OrdrDate.Visible = true;
            FirstDate.Visible = true;
            SecondDate.Visible = true;
            BetwinDateOrdCustomSow.Visible = true;
            Lscustomers.Visible = true;
        }
        public void RptAllCustomers()
        {
            CustomBLL Temp = new CustomBLL() { };
            AllCustlLs.DataSource = CustomBLL.getaollcust(Temp);
            AllCustlLs.DataTextField = "CustomFollName";
            AllCustlLs.DataValueField = "CustomId";
            AllCustlLs.DataBind();
            AllCustlLs.Visible = true;
        }

        protected void BetwinDateOrdCustomSow_Click(object sender, EventArgs e)
        {
            int i;
            ReportsBLL reportsBLL;
            List<ReportsBLL> RpdateOrdCustom = new List<ReportsBLL>();
            for (i = 0; i < Lscustomers.Items.Count; i++)
            {
                reportsBLL = new ReportsBLL() { Custom_id = int.Parse(Lscustomers.Items[i].Value), FirstDate = FirstDate.Text, SecondDate = SecondDate.Text };
                RpdateOrdCustom.Add(reportsBLL);

            }

            List<T_orders_customersBLL> TordAndCustom = new List<T_orders_customersBLL>();
            reportsBLL = new ReportsBLL();
            TordAndCustom = reportsBLL.GetOrdersAndCustomBetwinDate(RpdateOrdCustom);
            if (TordAndCustom.Count == 0)
            {
                zxzx.Text = "לא נמצאו הזמנות בין תאריכים הנל";
            }
            Rptbetwindateordr(TordAndCustom);


        }


        protected void AllCustlLs_SelectedIndexChanged(object sender, EventArgs e)
        {

            Lscustomers.Items.Add(AllCustlLs.SelectedItem);
        }
        protected void ProfitsBetwinDate_Click(object sender, EventArgs e)
        {
            SowProfitsCustomersBetwinDat.Visible = false;
            SowProfitsFromTheBeginningOfTheMonth.Visible = false;
            SowProfitsFromThisDay.Visible = false;
            ProfitsCustomersBetwinDat.Visible = false;
            FirstDateProfits.Visible = true;
            SecondDateProfits.Visible = true;
            SowProfitsBetwinDate.Visible = true;
            ProfitsFromThisDay.Visible = false;
            ProfitsFromTheBeginningOfTheMonth.Visible = false;
        }
        protected void SowProfitsBetwinDate_Click(object sender, EventArgs e)
        {
            int big = FirstDateProfits.Text.CompareTo(SecondDateProfits.Text);
            if (big >= 0)
            {
                string date = FirstDateProfits.Text;
                FirstDateProfits.Text = SecondDateProfits.Text;
                SecondDateProfits.Text = date;
            }
            ReportsBLL reportsBLL = new ReportsBLL() { FirstDate = FirstDateProfits.Text, SecondDate = SecondDateProfits.Text, Branches_id=int.Parse(DDLBranch.SelectedValue)};
            int TotProfits = reportsBLL.GetProfitsBetwinDate(reportsBLL);

            TotalOfProfits.Text = TotProfits.ToString();
            TotalOfProfits.Visible = true;
        }
        public void RptAllCustomerss(int Branches_id)
        {
            CustomBLL Temp = new CustomBLL() { Branches_id= Branches_id};
            AllCustlList.DataSource = CustomBLL.getaollcust(Temp);
            AllCustlList.DataTextField = "CustomFollName";
            AllCustlList.DataValueField = "CustomId";
            AllCustlList.DataBind();
            AllCustlList.Visible = false;
        }
        protected void ProfitsCustomersBetwinDat_Click(object sender, EventArgs e)
        {
            SowProfitsCustomersBetwinDat.Visible = true;
            AllCustlList.Visible = true;
            FirstDateProfits.Visible = true;
            SecondDateProfits.Visible = true;
            SowProfitsFromTheBeginningOfTheMonth.Visible = false;
            SowProfitsFromThisDay.Visible = false;
            SowProfitsBetwinDate.Visible = false;
            ProfitsBetwinDate.Visible = false;
            ProfitsFromThisDay.Visible = false;
            ProfitsFromTheBeginningOfTheMonth.Visible = false;
        }
        protected void SowProfitsCustomersBetwinDat_Click(object sender, EventArgs e)
        {
            int big = FirstDateProfits.Text.CompareTo(SecondDateProfits.Text);
            if (big >= 0)
            {
                string date = FirstDateProfits.Text;
                FirstDateProfits.Text = SecondDateProfits.Text;
                SecondDateProfits.Text = date;
            }
            ReportsBLL reportsBLL = new ReportsBLL() { Custom_id = int.Parse(AllCustlList.SelectedValue), FirstDate = FirstDateProfits.Text, SecondDate = SecondDateProfits.Text, Branches_id = int.Parse(DDLBranch.SelectedValue) };
            int ProfitsCustomersBetwinDat = reportsBLL.GetProfitsCustomersBetwinDat(reportsBLL);
           
            TotalOfProfits.Text = ProfitsCustomersBetwinDat.ToString();
            TotalOfProfits.Visible = true;
        }
        protected void ProfitsFromTheBeginningOfTheMonth_Click(object sender, EventArgs e)
        {
           SowProfitsFromTheBeginningOfTheMonth.Visible = true;
            SowProfitsFromThisDay.Visible = false;
            SowProfitsBetwinDate.Visible = false;
            ProfitsBetwinDate.Visible = false;
            SowProfitsCustomersBetwinDat.Visible = false;
            ProfitsCustomersBetwinDat.Visible = false;
            ProfitsFromThisDay.Visible = false;
        }
        protected void SowProfitsFromTheBeginningOfTheMonth_Click(object sender, EventArgs e)
        {
            ReportsBLL reportsBLL = new ReportsBLL();
            int TotProfils = reportsBLL.SowProfitsFromTheBeginningOfTheMonth(int.Parse(DDLBranch.SelectedValue));
            TotalOfProfits.Text = TotProfils.ToString();
            TotalOfProfits.Visible = true;
        }
        protected void ProfitsFromThisDay_Click(object sender, EventArgs e)
        {
            FirstDateProfits.Visible = true;
            SowProfitsFromThisDay.Visible = false;
            SowProfitsBetwinDate.Visible = false;
            ProfitsBetwinDate.Visible = false;
            SowProfitsCustomersBetwinDat.Visible = false;
            ProfitsCustomersBetwinDat.Visible = false;
            ProfitsFromThisDay.Visible = false;
            ProfitsFromTheBeginningOfTheMonth.Visible = false;
            SowProfitsFromThisDay.Visible = true;

        }
        protected void SowProfitsFromThisDay_Click(object sender, EventArgs e)
        {
            ReportsBLL reportsBLL = new ReportsBLL() { FirstDate=FirstDateProfits.Text, Branches_id=int.Parse(DDLBranch.SelectedValue)};
            int Total = reportsBLL.SowProfitsFromThisDay(reportsBLL);
            TotalOfProfits.Text = Total.ToString();
            TotalOfProfits.Visible = true;
        }
        public void SowCatgoryName()
        {
            CategoryBLL T = new CategoryBLL() { Main_store_id = Main_store_id, };
            List<CategoryBLL> ListCatgory = CategoryBLL.GetNameCategory(T);

            ListCatgory.Insert(0, new CategoryBLL()
            {
                Cat_id = 0,
                Cat_name = "בחר קטגוריה"
            });
            listCatgory1.DataSource = ListCatgory;
            listCatgory1.DataTextField = "Cat_name";
            listCatgory1.DataValueField = "Cat_id";
            listCatgory1.DataBind();


        }

        protected void listCatgory1_SelectedIndexChanged(object sender, EventArgs e)
        {

            T_modelBLL model = new T_modelBLL(int.Parse(listCatgory1.SelectedValue));
            List<T_modelBLL> Model = new List<T_modelBLL>();
            Model = model.nameModel();
            Model.Insert(0, new T_modelBLL()
            {
                Model_id = 0,
                Model_name = "בחר מוצר"
            });
            listModels.DataSource = Model;
            listModels.DataTextField = "Model_name";
            listModels.DataValueField = "Model_id";
            listModels.DataBind();
        }
        static List<T_model_propertyBLL> PropertyName;
        protected void listModels_SelectedIndexChanged(object sender, EventArgs e)
        {

            T_model_propertyBLL m = new T_model_propertyBLL() { Model_id = int.Parse(listModels.SelectedValue) };
            PropertyName = new List<T_model_propertyBLL>();
            PropertyName = m.idmodel();
            PropertyName.Insert(0, new T_model_propertyBLL()
            {
                Proper_id = 0,
                Proper_name = "בחר מאפייני מוצר"
            });
            lstProperty.DataSource = PropertyName;
            lstProperty.DataTextField = "Proper_name";
            lstProperty.DataValueField = "Proper_id";
            lstProperty.DataBind();
        }

        protected void lstProperty_SelectedIndexChanged(object sender, EventArgs e)
        {
            List<T_values_propertyBLL> ValuProperty = new List<T_values_propertyBLL>();
            ValuProperty = lstValueproperty(int.Parse(lstProperty.SelectedValue));
            ValuProperty.Insert(0, new T_values_propertyBLL()
            {
                ValProp_id = 0,
                Proper_name = "בחר ערכי מאפיינים"

            });
            llstProperty.DataSource = ValuProperty;
            llstProperty.DataTextField = "Proper_name";
            llstProperty.DataValueField = "ValProp_id";
            llstProperty.DataBind();
        }
        public List<T_values_propertyBLL> lstValueproperty(int propid)
        {
            int propId = propid;
            T_values_propertyBLL Propid = new T_values_propertyBLL() { Proper_id = propId };
            List<T_values_propertyBLL> ValuepropertyName = new List<T_values_propertyBLL>();
            ValuepropertyName = Propid.ValuepropertyName();
            return ValuepropertyName;
        }

     
        protected void NexxtSyup_Click(object sender, EventArgs e)
        {
            string a = llstProperty.SelectedValue + "@";
            string b = lstProperty.SelectedItem + "@" + llstProperty.SelectedItem;
            if (llstProperty.SelectedValue != "" && lstProperty.SelectedValue != "")
            {
                lstProperty.Items.Remove(lstProperty.SelectedItem);
                llstProperty.Items.Remove(llstProperty.SelectedItem);

                ValProp.Items.Add(a);
                VeuProp.Items.Add(b);
            }
        }
        string a;
        string[] ValusProp;
        protected void CounterOfStock_Click(object sender, EventArgs e)
        {

            List<TvalpropertyIdBLL> lstvpid = new List<TvalpropertyIdBLL>();
            for (int i = 0; i < ValProp.Items.Count; i++)
            {
                a += ValProp.Items[i].Value;

            }
            
            ValusProp = a.Split('@');
            //Array.Sort(ValusProp);
            for (int i = 0; i < ValusProp.Length - 1; i++)
            {
                TvalpropertyIdBLL Temp = new TvalpropertyIdBLL() { ValProp_id = int.Parse(ValusProp[i]) };
                lstvpid.Add(Temp);
               
            }

            List<TvalpropertyIdBLL> SortedList = lstvpid.OrderBy(o => o.ValProp_id).ToList();


            
            int Count = 0;
            T_property_stueckBLL ValPrpertyOfStoc = new T_property_stueckBLL() {Model_id=int.Parse(listModels.SelectedValue), lstValPropId = SortedList, Branches_id=int.Parse(DLbranc.SelectedValue) };//הגדרת אובביקט מאפייני מלאי עם רשימה מקושרת של מאפיינים
            List<T_property_stueckBLL> LstPropCont = ValPrpertyOfStoc.ContOfSto(ValPrpertyOfStoc);//רשימה מקושרת של כל המוצרים ומאפייניהם עך םי קוד מוצר
            List<T_property_stueckBLL> SortedListStock = LstPropCont.OrderBy(o => o.Stueck_id).ThenBy(oo => oo.ValProp_id).ToList();//מיון הרשימה
            int avg = LstPropCont.Count / ValPrpertyOfStoc.lstValPropId.Count;//מספר הפעמים שיש לעבור על הרשימה
          
            for(int i=0;i< avg; i++)
            {
                int p;
                int flegt = 0;
                for ( p=0;p< ValPrpertyOfStoc.lstValPropId.Count; p++)
                {
                    if(SortedListStock[p].ValProp_id== ValPrpertyOfStoc.lstValPropId[p].ValProp_id)//השוואה בין מאפיינים
                    {
                          flegt++;
                       
                    }
                 
                }
                if (p == ValPrpertyOfStoc.lstValPropId.Count)
                {
                    SortedListStock.RemoveRange(0, ValPrpertyOfStoc.lstValPropId.Count);//מחיקת חלק הרשימה שכבר לא נצרכת והחלפתה בשיטת הכוסות
                    List<T_property_stueckBLL> Temp = SortedListStock;
                    SortedListStock = Temp;
                }
                if (flegt== ValPrpertyOfStoc.lstValPropId.Count)
                {
                    Count++;//סכום הפעמים שהמוצר נמצא
                }
            }
            CountProdByStock.Text = Count.ToString();
           

        }

        protected void VeuProp_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        string[] Temp;
        protected void Cncel_Click(object sender, EventArgs e)
        {
            Temp = VeuProp.SelectedItem.Text.Split('@');
            for (int i = 0; i < PropertyName.Count; i++)
            {
                if (Temp[0] == PropertyName[i].Proper_name)
                {

                    VeuProp.Items.Remove(VeuProp.SelectedItem);
                    lstProperty.Items.Add(new ListItem(Temp[0], PropertyName[i].Proper_id.ToString()));
                    break;
                }
            }
        }

        protected void PaymentsToSopliersBetwinDate_Click(object sender, EventArgs e)
        {
            PaymentsToSopliBetwinDate.Visible = false;
            PaymentsToSopiersFromTheBeginningOfTheMont.Visible = false;
            PaymentsToSopliFromTheBeginningOfTheMont.Visible = false;
            AllPaymentsToSopli.Visible = false;
            PaymentsFersDate.Visible = true;
            PaymentsSecondDate.Visible = true;
            PaymentTotal.Visible = true;
            Tnumber.Text = "1";
        }

        protected void PaymentsToSopliBetwinDate_Click(object sender, EventArgs e)
        {
            AllPaymentsToSopli.Visible = false;
            PaymentsToSopliersBetwinDate.Visible = false;
            PaymentsToSopiersFromTheBeginningOfTheMont.Visible = false;
            PaymentsToSopliFromTheBeginningOfTheMont.Visible = false;
            PaymentsFersDate.Visible = true;
            PaymentsSecondDate.Visible = true;
            LstAllSoplier.Visible = true;
            PaymentTotal.Visible = true;
            Tnumber.Text = "2";


        }
        public void RptSupler()
        {
            T_supplierBLL Temp = new T_supplierBLL() { Main_store_id= Main_store_id};
            List<T_supplierBLL> LstSupl = new List<T_supplierBLL>();
            LstSupl = Temp.NameSupplire();
            LstAllSoplier.DataSource = LstSupl;
            LstAllSoplier.DataTextField = "Supplier_name";
            LstAllSoplier.DataValueField = "Supplier_id";
            LstAllSoplier.DataBind();
        }
        protected void PaymentsToSopiersFromTheBeginningOfTheMont_Click(object sender, EventArgs e)
        {
            PaymentsToSopliersBetwinDate.Visible = false;
            PaymentsToSopliBetwinDate.Visible = false;
            PaymentsToSopliFromTheBeginningOfTheMont.Visible = false;
            PaymentsFersDate.Visible = false;
            PaymentsSecondDate.Visible = false;
            LstAllSoplier.Visible = false;
            PaymentTotal.Visible = true;
            AllPaymentsToSopli.Visible = false;
            Tnumber.Text = "3";
        }

        protected void PaymentsToSopliFromTheBeginningOfTheMont_Click(object sender, EventArgs e)
        {
            PaymentsToSopliersBetwinDate.Visible = false;
            PaymentsToSopliBetwinDate.Visible = false;
            PaymentsToSopiersFromTheBeginningOfTheMont.Visible = false;
            LstAllSoplier.Visible = true;
            PaymentsFersDate.Visible = false;
            PaymentsSecondDate.Visible = false;
            PaymentTotal.Visible = true;
            AllPaymentsToSopli.Visible = false;
            Tnumber.Text = "4";
        }
        protected void AllPaymentsToSopli_Click(object sender, EventArgs e)
        {
            PaymentsToSopliFromTheBeginningOfTheMont.Visible = false;
            PaymentsToSopliersBetwinDate.Visible = false;
            PaymentsToSopliBetwinDate.Visible = false;
            PaymentsToSopiersFromTheBeginningOfTheMont.Visible = false;
            LstAllSoplier.Visible = true;
            PaymentsFersDate.Visible = false;
            PaymentsSecondDate.Visible = false;
            PaymentTotal.Visible = true;
            Tnumber.Text = "5";
        }

        protected void SowAllPayment_Click(object sender, EventArgs e)
        {
            if (Tnumber.Text == "1")
            {
                int big = PaymentsFersDate.Text.CompareTo(PaymentsSecondDate.Text);
                if (big >= 0)
                {
                    string date = PaymentsFersDate.Text;
                    PaymentsFersDate.Text = PaymentsSecondDate.Text;
                    PaymentsSecondDate.Text = date;
                }
                ReportsBLL reportsBLL = new ReportsBLL() { FirstDate= PaymentsFersDate.Text, SecondDate= PaymentsSecondDate.Text, Main_store_id= Main_store_id};
                int TotProfits = reportsBLL.GetPaymebyBetwinDate(reportsBLL);

                PaymentTotal.Text = TotProfits.ToString();
                PaymentTotal.Visible = true;
                
            }
            else if(Tnumber.Text == "2")
            {
                int big = PaymentsFersDate.Text.CompareTo(PaymentsSecondDate.Text);
                if (big >= 0)
                {
                    string date = PaymentsFersDate.Text;
                    PaymentsFersDate.Text = PaymentsSecondDate.Text;
                    PaymentsSecondDate.Text = date;
                }
                ReportsBLL reportsBLL = new ReportsBLL() { Supplier_id=int.Parse(LstAllSoplier.SelectedValue), FirstDate = PaymentsFersDate.Text, SecondDate = PaymentsSecondDate.Text, Main_store_id = Main_store_id };
                int TotProfits = reportsBLL.GetPaymentToSoplieBetwinDat(reportsBLL);

                PaymentTotal.Text = TotProfits.ToString();
                PaymentTotal.Visible = true;
            }
            
            else if (Tnumber.Text == "3")
            {
                ReportsBLL reportsBLL = new ReportsBLL() { Main_store_id = Main_store_id };
                int TotProfits = reportsBLL.GetPaymentFromTheBeginningOfTheMonth(reportsBLL);
                PaymentTotal.Text = TotProfits.ToString();
                PaymentTotal.Visible = true;
            }
            else if (Tnumber.Text == "4")
            {
                ReportsBLL reportsBLL = new ReportsBLL() { Supplier_id=int.Parse(LstAllSoplier.SelectedValue), Main_store_id = Main_store_id };
                int TotProfits = reportsBLL.GetPaymentToSoplFromTheBeginningOfTheMonth(reportsBLL);
                if (TotProfits != 0)
                {
                    PaymentTotal.Text = TotProfits.ToString();
                    PaymentTotal.Visible = true;

                }
                else
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('לא נמצאו תשלומים לספק זה מתחילת החודש')", true);
                }
            }
            else if (Tnumber.Text == "5")
            {
                ReportsBLL reportsBLL = new ReportsBLL() { Supplier_id = int.Parse(LstAllSoplier.SelectedValue), Main_store_id = Main_store_id };
                int TotProfits = reportsBLL.GetPaymentToSoplFromAll(reportsBLL);
                PaymentTotal.Text = TotProfits.ToString();
                PaymentTotal.Visible = true;
            }
        }

        protected void DDLBranch_SelectedIndexChanged(object sender, EventArgs e)
        {
            RptAllCustomerss(int.Parse(DDLBranch.SelectedValue));
        }
    }
}