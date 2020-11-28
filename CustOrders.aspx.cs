using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;

using Msmf.App_Code;

namespace Msmf.admin
{
    public partial class CustOrders : System.Web.UI.Page
    {
        
        protected void Page_Load(object sender, EventArgs e)
        {
            Main_store_id = (int)Session["Main_store_id"];
            if (!IsPostBack)
            {
                RPTbranch();
                
                SowCatgoryName();
              
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
            DDlBranach.DataSource = T_branchesBLL.GetAllBranches(Temp);
            DDlBranach.DataTextField = "Branches_name";
            DDlBranach.DataValueField = "Branches_id";
            DDlBranach.DataBind();
        }
            public void RptAllOrders(int BrancId)
            {
            T_orders_customersBLL Temp = new T_orders_customersBLL() { Branches_id= BrancId };
            List<T_orders_customersBLL> AllOrders =T_orders_customersBLL.GetAllOrders(Temp);  
            RPTallorders.DataSource = AllOrders;
            RPTallorders.DataBind();
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
            Cat.DataSource = ListCatgory;
            Cat.DataTextField = "Cat_name";
            Cat.DataValueField = "Cat_id";
            Cat.DataBind();


        }



        protected void Cat_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            T_modelBLL model = new T_modelBLL(int.Parse(Cat.SelectedValue));
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

        protected void listModels_SelectedIndexChanged(object sender, EventArgs e)
        {
            T_model_werrntyBLL t_Model_WerrntyBLL = new T_model_werrntyBLL() { Model_id = int.Parse(listModels.SelectedValue) };
             t_Model_WerrntyBLL= t_Model_WerrntyBLL.GetPrisModel();
            Unit_pris.Text = t_Model_WerrntyBLL.Model_pris.ToString();
        }

        protected void ExistingCustomer_Click(object sender, EventArgs e)
        {
            CustomBLL Temp = new CustomBLL() { Branches_id=int.Parse(DDlBranach.SelectedValue) };
            AllCustlLs.DataSource = CustomBLL.getaollcust(Temp);
            AllCustlLs.DataTextField = "CustomFollName";
            AllCustlLs.DataValueField = "CustomId";
            AllCustlLs.DataBind();
            AllCustlLs.Visible = true;
           
            
        }

        protected void NewCustom_Click(object sender, EventArgs e)
        {
            TxtCustAdress.Visible = true;
            TxtCustFolName.Visible = true;
            TxtCustNail.Visible = true;
            TxtCustPone.Visible = true;
        }
        string[] OrderDetls;

        public object ExcelFile { get; private set; }

        protected void MakeOrder_Click(object sender, EventArgs e)
        {
            List<T_orders_details_customersBLL> lstOd = new List<T_orders_details_customersBLL>();   
            if (TxtCustNail.Text != "")//במידה וזה לקוח חדש
            {
                CustomBLL customBLL = new CustomBLL() { CustomAdrss = TxtCustAdress.Text, CustomEmail = TxtCustNail.Text, CustomFollName = TxtCustFolName.Text, CustomId = -1, CustomPhone = TxtCustPone.Text, Branches_id=int.Parse(DDlBranach.SelectedValue) };//יצירת לקוח
                customBLL = customBLL.addcust();
               
                T_orders_customersBLL t_Orders_CustomersBLL = new T_orders_customersBLL() { Custom_id = customBLL.CustomId, Order_cust_id = -1, Order_date = TorderCustSellingDate.Text.ToString(), Branches_id=int.Parse(DDlBranach.SelectedValue) };//יצירת הזמנה חדשה
                t_Orders_CustomersBLL = t_Orders_CustomersBLL.addNewOrder();
                for (int i = 0; i < MyCart.Items.Count; i++)//מעבר על סל המוצרים
                {
                    OrderDetls = MyCart.Items[i].Text.Split('-');//הפרדת שורות הסל ונכנסתו למערך פרטי הזמנות
                    int z = 0;
                    
                        lstOd.Add(new T_orders_details_customersBLL//  הוספת ויצירת אובייקט פרטי הזמנות לקוחות
                        {
                            Order_cust_id = t_Orders_CustomersBLL.Order_cust_id,
                            Model_id = int.Parse(OrderDetls[z + 3]),
                            Quantity = int.Parse(OrderDetls[z + 2]),
                            Unit_pris = int.Parse(OrderDetls[z + 1]),
                            SN = OrderDetls[z + 4]
                            
                        });
                        
                    
                    
                   
                }
                List<StuckBLL> lstStatusUp = new List<StuckBLL>();
                for (int i = 0; i <lstOd.Count; i ++)//מעבר על רשימת פרטי הזמנות לקוחות
                {
                  //יצירת אובייקט מלאי והשלמת הפרטים החסרים 
                     StuckBLL Temp = new StuckBLL() { Stock_selling_date = t_Orders_CustomersBLL.Order_date, Stock_selling_pric = lstOd[i].Unit_pris, Custom_waernty = -1, Custom_id = t_Orders_CustomersBLL.Custom_id, Model_id =lstOd[i].Model_id, Stock_SN=lstOd[i].SN };
                    Temp.Updatestatus();
                    lstOd[i].addNewDitelsOrder();
                   
                }
                Tsrn.Text = null;
                Tquantity.Text = null;
                Unit_pris.Text = null;
                TorderCustSellingDate.Text = null;
                MyCart.Items.Clear();
                TxtCustFolName.Text = null;
                TxtCustAdress.Text = null;
                TxtCustNail.Text = null;
                TxtCustPone.Text = null;

                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('ההזמנה נקלטה במערכת')", true);



            }
            else
            {
                int x = 0;
                T_orders_customersBLL t_Orders_CustomersBLL = new T_orders_customersBLL() { Custom_id = int.Parse(AllCustlLs.SelectedValue), Order_cust_id = -1, Order_date = TorderCustSellingDate.Text.ToString(), Branches_id = int.Parse(DDlBranach.SelectedValue) };
                t_Orders_CustomersBLL = t_Orders_CustomersBLL.addNewOrder();
                for (int i = 0; i < MyCart.Items.Count; i++)
                {
                    OrderDetls = MyCart.Items[i].Text.Split('-');
                    
                    lstOd.Add(new T_orders_details_customersBLL { Order_cust_id = t_Orders_CustomersBLL.Order_cust_id,
                        Model_id = int.Parse(OrderDetls[x + 3]),
                        Quantity = int.Parse(OrderDetls[x + 2]),
                        Unit_pris = int.Parse(OrderDetls[x + 1])
                        , SN = OrderDetls[x + 4] });
                }
                List<StuckBLL> lstStatusUp = new List<StuckBLL>();
                for (int i = 0; i < lstOd.Count; i++)
                {

                    StuckBLL Temp = new StuckBLL() { Stock_selling_date = t_Orders_CustomersBLL.Order_date, Stock_selling_pric = lstOd[i].Unit_pris, Custom_waernty = -1, Custom_id = t_Orders_CustomersBLL.Custom_id, Model_id = lstOd[i].Model_id, Stock_SN = lstOd[i].SN };
                    Temp.Updatestatus();
                    lstOd[i].addNewDitelsOrder();

                }
                Tsrn.Text = null;
                Tquantity.Text = null;
                Unit_pris.Text = null;
                TorderCustSellingDate.Text = null;
                MyCart.Items.Clear();
                TxtCustFolName.Text = null;
                TxtCustAdress.Text = null;
                TxtCustNail.Text = null;
                TxtCustPone.Text = null;

                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('ההזמנה נקלטה במערכת')", true);


            }
        }

        protected void AddToCart_Click(object sender, EventArgs e)
        {

            MyCart.Items.Add(listModels.SelectedItem+"  -   "+Unit_pris.Text+"  -  "+Tquantity.Text+"  -  "+listModels.SelectedValue +"-"+Tsrn.Text);
            MyCart.Visible = true;
            Tsrn.Text = null;
            Tsrn.Focus();
           

        }
        protected void SowdetelsOrders_Command(object sender, CommandEventArgs e)
        {
            int id = Convert.ToInt32(e.CommandArgument);
            //T_orders_details_customersBLL Todc = new T_orders_details_customersBLL() { Order_cust_id= id };
            List<T_orders_details_customersBLL> t_Orders_Details_CustomersBLLs = new List<T_orders_details_customersBLL>();
            T_orders_details_customersBLL Todc = new T_orders_details_customersBLL() { Order_cust_id = id };
            t_Orders_Details_CustomersBLLs = Todc.getOrderstetels(Todc);
            RPTordersdetels.DataSource = t_Orders_Details_CustomersBLLs;
            RPTordersdetels.DataBind();
            Rtodc.Visible = true;
            //point.Focus();
        }

       
        protected void AdetdetelsOrderss_Command(object sender, CommandEventArgs e)
        {
            string[] detelsorders;
            detelsorders = e.CommandArgument.ToString().Split(';');
            Order_cust_id.Text = detelsorders[0];
            Model_id.Text = detelsorders[1];
            Quantity.Text = detelsorders[2];
            UnitPris.Text = detelsorders[3];
            NameMidel.Text = detelsorders[4];
            ScriptManager.RegisterStartupScript(this, GetType(), "Pop", "openModal();", true);
        }

     

        protected void UpdateDetelsOrder_Click(object sender, EventArgs e)
        {
            T_orders_details_customersBLL Todc = new T_orders_details_customersBLL()
            {
                Order_cust_id = int.Parse(Order_cust_id.Text),
                Model_id = int.Parse(Model_id.Text),
                Quantity = int.Parse(Quantity.Text),
                Unit_pris = int.Parse(UnitPris.Text)
            };
            string s = Todc.UpdeteDetelsOrders(Todc);
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('העדכון בוצע בהצלחה')", true);
        }


        protected void deleteDetelsOrderss_Click(object sender, EventArgs e)
        {
            T_orders_details_customersBLL Todc = new T_orders_details_customersBLL()
            {
                Order_cust_id = int.Parse(Order_cust_id.Text),
                Model_id = int.Parse(Model_id.Text),
                Quantity = int.Parse(Quantity.Text),
                Unit_pris = int.Parse(UnitPris.Text)
            };
            string s = Todc.deleteDetelsOrders(Todc);
            if (s != "")
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('המוצר נמחק בהצלחה')", true);
            }
        }



        protected void ClearMakeOrders_Click(object sender, EventArgs e)
        {
            Tsrn.Text = null;
            Tquantity.Text = null;
            Unit_pris.Text = null;
            TorderCustSellingDate.Text = null;
            MyCart.Items.Clear();
            TxtCustFolName.Text = null;
            TxtCustAdress.Text = null;
            TxtCustNail.Text = null;
            TxtCustPone.Text = null;
        }

        protected void DDLBranch_SelectedIndexChanged(object sender, EventArgs e)
        {
            RptAllOrders(int.Parse(DDLBranch.SelectedValue));
            RtableOrderCustomers.Visible = true;
        }

        protected void SowOrdersByBranch_Click(object sender, EventArgs e)
        {
            DDLBranch.Visible = true;
        }
    }
  
       


}