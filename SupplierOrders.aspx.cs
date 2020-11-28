using BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Newtonsoft.Json;
using System.Web.Script.Serialization;
using Msmf.App_Code;
using System.IO;

namespace Msmf.admin
{
    public partial class SupplierOrders : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Main_store_id = (int)Session["Main_store_id"];
            if (!IsPostBack)
            {
                SowCatgoryName();
                //RPTstucks(Main_store_id);
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
            DDlbrnach.DataSource = T_branchesBLL.GetAllBranches(Temp);
            DDlbrnach.DataTextField = "Branches_name";
            DDlbrnach.DataValueField = "Branches_id";
            DDlbrnach.DataBind();
            
        }
        public void RPTAOS(int Soid,int fleg)
        {
            List<T_orders_supplierBLL> LSTsOrders = T_orders_supplierBLL.GetallOrders(Soid, fleg);
            RPTallOrdersSoplier.DataSource = LSTsOrders;
            RPTallOrdersSoplier.DataBind();
            ReTabelsSupplierOrdrers.Visible = true;
        }
        protected void SowAso_Click(object sender, EventArgs e)
        {
            RPTAOS(Main_store_id, 0);
        }
        protected void DDLBranch_SelectedIndexChanged(object sender, EventArgs e)
        {
            RPTAOS(Main_store_id, int.Parse(DDLBranch.SelectedValue));
        }
        protected void SowDetels_Command(object sender, CommandEventArgs e)
        {
           
            T_orders_details_supplierBLL temp = new T_orders_details_supplierBLL() { Supplier_order_id = int.Parse(e.CommandArgument.ToString()) };
            List<T_orders_details_supplierProps> LstPropss = new List<T_orders_details_supplierProps>();
            List<T_orders_details_supplierBLL> LstSopDetels = temp.GetOrdersDedelsSopliier(temp);

            for (int i = 0; i < LstSopDetels.Count; i++)
            {

                detels = LstSopDetels[i].Json_property.Split(new string[] { ":::" }, StringSplitOptions.None);
                for (int z = 0; z < detels.Length - 1; z++)
                {
                    string[] Str = detels[z].Split('@');
                    T_orders_details_supplierProps Tprops = new T_orders_details_supplierProps() { ProperName = Str[0], ProperValue = Str[1] };
                    LstPropss.Add(Tprops);
                }

                LstSopDetels[i].LstProps = new List<T_orders_details_supplierProps>(LstPropss);
                LstSopDetels[i].Total = LstSopDetels[i].Quantity * LstSopDetels[i].Unit_pris;
                LstPropss.Clear();

            }
            RptQynttyAndName.DataSource = LstSopDetels;
            RptQynttyAndName.DataBind();

        }
        protected void RptQynttyAndName_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            var data = ((T_orders_details_supplierBLL)e.Item.DataItem).LstProps;
            var RptPropAndVal = (Repeater)e.Item.FindControl("RptPropAndVal");
            RptPropAndVal.DataSource = data;
            RptPropAndVal.DataBind();

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
            T_modelBLL model = new T_modelBLL(int.Parse(listCatgory1.SelectedValue.ToString()));
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
            Supplier();
           
           
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
            ModelPrisBySuppler();

        }
        public void Supplier()
        {
            T_supplierBLL supplier = new T_supplierBLL() { Cat_id=int.Parse(listCatgory1.SelectedValue.ToString()) };
            List<T_supplierBLL> Supplier = new List<T_supplierBLL>();
            Supplier = supplier.NameSupplire();
            Supplier.Insert(0, new T_supplierBLL()
            {
                Supplier_id = 0,
                Supplier_name = "בחר ספק"

            });
            lisSoplier.DataSource = Supplier;
            lisSoplier.DataTextField = "Supplier_name";
            lisSoplier.DataValueField = "Supplier_id";
            lisSoplier.DataBind();



        }
        public void ModelPrisBySuppler()
        {
            if (lisSoplier.SelectedValue != "0")
            {
                T_model_supplierBLL Temp = new T_model_supplierBLL() { Supplier_id = int.Parse(lisSoplier.SelectedValue), Model_id = int.Parse(listModels.SelectedValue) };
                Temp = Temp.getwaerntyBymodel();
                SoplPris.Text = Temp.Stock_buying_pric.ToString();
            }
            
        } 
       

        protected void lisSoplier_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listModels.SelectedValue == "0")
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('עליך לבחור מוצר תחילה')", true);
               
            }
            else
            {
                T_model_supplierBLL Temp = new T_model_supplierBLL() { Supplier_id = int.Parse(lisSoplier.SelectedValue), Model_id = int.Parse(listModels.SelectedValue) };
                Temp = Temp.getwaerntyBymodel();
                SoplPris.Text = Temp.Stock_buying_pric.ToString();
            }
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
        protected void NextStupp_Click(object sender, EventArgs e)
        {
            string a = lstProperty.SelectedValue + "@-" + llstProperty.SelectedValue;
            string b = lstProperty.SelectedItem + "@-" + llstProperty.SelectedItem;
            if (llstProperty.SelectedValue != "" && lstProperty.SelectedValue != "")
            {
                lstProperty.Items.Remove(lstProperty.SelectedItem);
                llstProperty.Items.Remove(llstProperty.SelectedItem);

                ValProp.Items.Add(a);
                VeuProp.Items.Add(b);

            }
        }
       
        string[] detels;
        string[] Subdetels;
        string[] ddddetels;
        string aa;
        string a;
        string w;
        List<T_orders_details_supplierBLL> LstSod = new List<T_orders_details_supplierBLL>();
        protected void MaecOrderFromSuppliers_Click(object sender, EventArgs e)
        {
           
            
            
            T_orders_supplierBLL Tos = new T_orders_supplierBLL() {  Supplier_id = int.Parse(TsuplierId.Text), Supplier_order_date = DateTime.Now.ToString("yyyy - MM - dd"), Branches_id=int.Parse(DDlbrnach.SelectedValue) };
            
            Tos = Tos.AddNewOrderSupplier(Tos);
            for (int i = 0; i < MyCartFromSupplier.Items.Count; i++)
            {
                detels = MyCartFromSupplier.Items[i].Text.Split(new string[] { "@#" }, StringSplitOptions.None);
                string[] St = detels[3].Split(new string[] { "@-" }, StringSplitOptions.None);
                List<T_orders_details_supplierProps> LstProps=new List<T_orders_details_supplierProps>();
                for (int z=4;z< detels.Length-1; z++)
                {
                  
                    string[] Str = detels[z].Split(new string[] { "@-" }, StringSplitOptions.None);
                    aa += Str[0] + '@' + Str[1] +":::";
                    //string pname = Str[0];
                    //string Vpname = Str[1];
                    //var q = new Dictionary<string, string>
                    //{
                    //     { "pname", pname }, { "Vpname", Vpname }
                    //};
                    
                    T_orders_details_supplierProps Tprops = new T_orders_details_supplierProps() { ProperName=Str[0], ProperValue=Str[1]};
                    LstProps.Add(Tprops);
                }
                LstSod.Add(new T_orders_details_supplierBLL() { Supplier_order_id= Tos.Supplier_order_id,Quantity =int.Parse(detels[1]) , Unit_pris= int.Parse(detels[2]), Json_property=aa, Model_id=int.Parse(St[1])});
                aa = "";
                
            }
            T_orders_details_supplierBLL Temp = new T_orders_details_supplierBLL();
            a = Temp.AddDedelsOrders(LstSod);
            Response.Redirect("VeuOrdersSup.aspx?Soid=" + Tos.Supplier_order_id);
            
           
           
            //RptQynttyAndName.DataSource = LstSod;
            //RptQynttyAndName.DataBind();


            // string v= Temp.AddDedelsOrders(LstSod);
            // Response.Redirect("OrderVue.aspx?Osid=" + Tos.Supplier_order_id);//נסיון
            //   Globfunc.SendEmail("fldmanmnchm@gmail.com", "מנחם ומשה ניהול מלאי", "fmm4312628@gmail.com", "הזמנה חדשה", "reader.ReadToEnd()");// "כמות:'" + a + "'"
        }
        
        protected void AddTocart_Click(object sender, EventArgs e)
        {
            TsuplierId.Text = lisSoplier.SelectedValue;
            string[] sa;
            string data = string.Empty;
            foreach (ListItem item in VeuProp.Items)
             data = string.Concat(data, item.Text, "@#");
           // sa = data.Split('-');
            MyCartFromSupplier.Items.Add(listModels.SelectedItem + "  @#   "  + SupllierQwentty.Text + "  @#  " + SoplPris.Text +"  @#  " + "קוד מוצר"+ "@-" + listModels.SelectedValue+ "@#" + data );
            MyCartFromSupplier.Visible = true;
            VeuProp.Items.Clear();
        }
        string[] Temp;
        
        protected void Cncel_Click(object sender, EventArgs e)
        {

            Temp = VeuProp.SelectedItem.Text.Split(new string[] { "@-" }, StringSplitOptions.None);
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

        protected void SowDataOfSouply_Click(object sender, EventArgs e)
        {
            ReportsBLL Temp = new ReportsBLL() { Supplier_id= int.Parse(lisSoplier.SelectedValue)};
            int MontPayment = Temp.GetPaymentToSoplFromTheBeginningOfTheMonth(Temp);
            int AllPayment = Temp.GetPaymentToSoplFromAll(Temp);
            PaymentToSoplyMonth.Text = MontPayment.ToString();
            AllpaymentToSuplay.Text = AllPayment.ToString();
            PaymentToSoplyMonth.Visible = true;
            AllpaymentToSuplay.Visible = true;
        }
        
        protected void CompareSuppliersOrders_Click(object sender, EventArgs e)
        {
            int Sum=0;
            int Cuont = 0;
            for (int i = 0; i < MyCartFromSupplier.Items.Count; i++)
            {
                detels = MyCartFromSupplier.Items[i].Text.Split(new string[] { "@#" }, StringSplitOptions.None);
                string[] St = detels[3].Split(new string[] { "@-" }, StringSplitOptions.None);
                LstSod.Add(new T_orders_details_supplierBLL() { Quantity = int.Parse(detels[1]), Model_id = int.Parse(St[1]) });
            }
            LstSod = T_orders_details_supplierBLL.CompareSuppliersOrders(LstSod);
            List<T_orders_details_supplierBLL> LLstSod = LstSod.OrderBy(o => o.Supplier_Name).ToList();//מיון הרשימה
            for (int z=0;z < LLstSod.Count; z++)
            {
                LLstSod[z].Total = LLstSod[z].Unit_pris * LLstSod[z].Quantity;
                Sum += LLstSod[z].Total;
                if (z == LLstSod.Count - 1||LLstSod[z].Supplier_Name!= LLstSod[z+1].Supplier_Name)
                {
                    LLstSod[z].Json_property = Sum.ToString();
                    Sum = 0;
                }
               
            }
            RptRpt.DataSource = LLstSod;
            RptRpt.DataBind();
        }

       
    }
}