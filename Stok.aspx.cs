using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;

namespace Msmf.admin
{
    public partial class Stok : System.Web.UI.Page
    {
        public static int w;
        string date;

        public int getCat(int catId)
        {
            var x = catId;
            return x;
        } 
        protected void Page_Load(object sender, EventArgs e)
        {
            Main_store_id = (int)Session["Main_store_id"];
            if (!IsPostBack)
            {
                //RPTstucks();
                SowCatgoryName();
                RPTbranch();
                listUnic.Items.Add("האם זהו מוצר יחודי?");
                listUnic.Items.Add("כן");
                listUnic.Items.Add("לא");
                date= DateTime.Now.ToString("s");
                TStock_buying_date.Text = date.Substring(0,10);  


            }
           
        }
        int Main_store_id;
        public void RPTstucks(int BranchId)
        {
            T_branchesBLL Temp = new T_branchesBLL() { Branches_id= BranchId };
            List<StuckBLL> LSTstuck = StuckBLL.Getallstock(Temp);
            RPTallstuck.DataSource = LSTstuck;
            RPTallstuck.DataBind();
        }

       
        public void SowCatgoryName()
        {
            CategoryBLL T = new CategoryBLL() { Main_store_id = Main_store_id, };
            List<CategoryBLL> ListCatgory = CategoryBLL.GetNameCategory(T);

            ListCatgory.Insert(0, new CategoryBLL() {
                Cat_id = 0,
                Cat_name="בחר קטגוריה"
            });
            listCatgory1.DataSource = ListCatgory;
            listCatgory1.DataTextField = "Cat_name";
            listCatgory1.DataValueField = "Cat_id";
            listCatgory1.DataBind();
            

        }
       
        public void Supplier()
        {
            var Cat_id = listModels.SelectedValue.ToString();
            T_model_supplierBLL supplier = new T_model_supplierBLL() { Model_id=int.Parse(listModels.SelectedValue.ToString())};
            List<T_model_supplierBLL> Supplier = new List<T_model_supplierBLL>();
            Supplier = supplier.GetModelPrisSupplier();
            Supplier.Insert(0, new T_model_supplierBLL() {
             Supplier_id = 0, Supplier_name="בחר ספק"
            });
            lisSoplier.DataSource = Supplier;
            lisSoplier.DataTextField = "Supplier_name";
            lisSoplier.DataValueField = "Supplier_id";
            lisSoplier.DataBind();
         


        }
        

        protected void listCatgory1_SelectedIndexChanged(object sender, EventArgs e)
        {
           
            var  Cat_id = listCatgory1.SelectedValue.ToString();
             w = int.Parse(Cat_id);
            T_modelBLL model = new T_modelBLL(w);
            List<T_modelBLL> Model = new List<T_modelBLL>();
            Model= model.nameModel();
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
        static  List<T_model_propertyBLL> PropertyName;
        protected void listModels_SelectedIndexChanged(object sender, EventArgs e)
        {
            var idmodel  = listModels.SelectedValue.ToString();
            int a = getCat(w);
            T_model_propertyBLL m = new T_model_propertyBLL() { Model_id=int.Parse(idmodel) };
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
            Supplier();

        }
        public int SupplierWaernty()
        {
            T_model_supplierBLL t_Model_SupplierBLL = new T_model_supplierBLL() { Model_id =int.Parse( listModels.SelectedValue), Supplier_id= int.Parse (lisSoplier.SelectedValue) };
            t_Model_SupplierBLL = t_Model_SupplierBLL.getwaerntyBymodel();
            return t_Model_SupplierBLL.Supplier_waernty;
        }



        protected void lstProperty_SelectedIndexChanged(object sender, EventArgs e)
        {
            var propid = lstProperty.SelectedValue.ToString();
            int idprop = int.Parse(propid);
            List<T_values_propertyBLL> ValuProperty = new List<T_values_propertyBLL>();
            ValuProperty= lstValueproperty(idprop);

            ValuProperty.Insert(0, new T_values_propertyBLL()
            {
                ValProp_id = 0,
                Proper_name="בחר ערכי מאפיינים"
                
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


        string[] Temp;
        protected void Cncel_Click(object sender, EventArgs e)
        {
            Temp = VeuProp.SelectedItem.Text.Split('-');
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

      
      

        protected void VeuProp_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }
        string[] Stocs;
        string a;
         int s = 1;
        protected void AddStock_Click(object sender, EventArgs e)
        {
            
            for (int i = 0; i < ValProp.Items.Count; i++)
            {
               
               a+= ValProp.Items[i].Text.ToString() + "-";
               

            }
            Stocs =a. Split('-');
            for (int i = 0; i < lstsn.Items.Count; i++)
            {
                StuckBLL stuckBLL = new StuckBLL();
                stuckBLL.Stock_id = -1;
                stuckBLL.Model_id = int.Parse(listModels.SelectedValue);
                stuckBLL.Stock_unique = listUnic.SelectedIndex;
                stuckBLL.Stock_quantity =int.Parse(Tqwntty.Text);
                stuckBLL.Supplier_id = int.Parse(lisSoplier.SelectedValue);
                stuckBLL.Status_prod = "1";
                stuckBLL.Stock_SN = lstsn.Items[i].Text.ToString();
                stuckBLL.Stock_buying_pric = int.Parse(TStock_buying_pric.Text.ToString());
                stuckBLL.Stock_buying_date = TStock_buying_date.Text;
                stuckBLL.Supplier_waernty = SupplierWaernty();
                stuckBLL.Branches_id = int.Parse(LstBranch.SelectedValue);
                stuckBLL.AddProdInStuck();
                for(int z = 0; z < Stocs.Length-1; z++)
                {
                    T_property_stueckBLL t_Property_StueckBLL = new T_property_stueckBLL() {
                        Stueck_id = stuckBLL.Stock_id,
                        Proper_id =int.Parse(Stocs[z]),
                        ValProp_id =int.Parse(Stocs[z+1])};
                        z++;
                    t_Property_StueckBLL.PropertyStueckInser();
                }
                


            }
            
        }
        
          protected void lisSoplier_SelectedIndexChanged(object sender, EventArgs e)
          {
            SupplierWaernty();
          }
       

        protected void addsn_Click(object sender, EventArgs e)
        {
            if (listUnic.SelectedItem.Text=="כן")
            {
                Tsn.Visible = true;
                addandersn.Visible = true;
                Tqwntty.Text = "1";
            }
            else
            {
                Tsn.Visible = true;
                Tqwntty.Visible = true;
                addandersn.Visible = true;
            }
            
        }

        protected void addandersn_Click(object sender, EventArgs e)
        {
            if (Tsn.Text != "")
            {
                lstsn.Items.Add(Tsn.Text);
                Tsn.Text = null;
                Tsn.Focus();
            }
            




        }

        protected void UpStock_Click(object sender, EventArgs e)
        {

        }

       

        protected void NextStup_Click(object sender, EventArgs e)
        {
            string a = lstProperty.SelectedValue + "-" + llstProperty.SelectedValue;
            string b = lstProperty.SelectedItem + "-" + llstProperty.SelectedItem;
            if (llstProperty.SelectedValue != "" && lstProperty.SelectedValue != "")
            {
                lstProperty.Items.Remove(lstProperty.SelectedItem);
                llstProperty.Items.Remove(llstProperty.SelectedItem);

                ValProp.Items.Add(a);
                VeuProp.Items.Add(b);
            }
        }

        protected void SowLstBranch_Click(object sender, EventArgs e)
        {
            T_branchesBLL Temp = new T_branchesBLL() { Main_store_id= Main_store_id};
            LstBranch.DataSource = T_branchesBLL.GetAllBranches(Temp);
            LstBranch.DataTextField = "Branches_name";
            LstBranch.DataValueField = "Branches_id";
            LstBranch.DataBind();
        }
        public void RPTbranch()
        {
            T_branchesBLL Temp = new T_branchesBLL() { Main_store_id = Main_store_id };
            DDLbranch.DataSource = T_branchesBLL.GetAllBranches(Temp);
            DDLbranch.DataTextField = "Branches_name";
            DDLbranch.DataValueField = "Branches_id";
            DDLbranch.DataBind();
        }
        protected void DDLbranch_SelectedIndexChanged(object sender, EventArgs e)
        {

            RPTstucks(int.Parse(DDLbranch.SelectedValue));
            Rstok.Visible = true;
        }

        protected void SowStok_Click(object sender, EventArgs e)
        {
            DDLbranch.Visible = true;
        }







        //   protected void lisSoplier_SelectedIndexChanged(object sender, EventArgs e)
        //  {

        //   }
    }



}



