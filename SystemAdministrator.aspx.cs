using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;


namespace Msmf.admin
{
    public partial class SystemAdministrator : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string name = Session["User_name"].ToString(); 
             Main_store_id=(int)Session["Main_store_id"];
            if (!IsPostBack)
            {
                SowCatgoryName();
            }
        }
        int Main_store_id;
        public void SowCatgoryName()
        {
            CategoryBLL T = new CategoryBLL() { Main_store_id= Main_store_id,}; 
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
            listCatgory2.DataSource = ListCatgory;
            listCatgory2.DataTextField = "Cat_name";
            listCatgory2.DataValueField = "Cat_id";
            listCatgory2.DataBind();
            ListCatgoryToProp.DataSource = ListCatgory;
            ListCatgoryToProp.DataTextField = "Cat_name";
            ListCatgoryToProp.DataValueField = "Cat_id";
            ListCatgoryToProp.DataBind();
            LstCatToModel.DataSource = ListCatgory;
            LstCatToModel.DataTextField = "Cat_name";
            LstCatToModel.DataValueField = "Cat_id";
            LstCatToModel.DataBind();
            LstCatToDellUp.DataSource = ListCatgory;
            LstCatToDellUp.DataTextField = "Cat_name";
            LstCatToDellUp.DataValueField = "Cat_id";
            LstCatToDellUp.DataBind();
            LSTcam.DataSource = ListCatgory;
            LSTcam.DataTextField = "Cat_name";
            LSTcam.DataValueField = "Cat_id";
            LSTcam.DataBind();
            LsPrToUp.DataSource = ListCatgory;
            LsPrToUp.DataTextField = "Cat_name";
            LsPrToUp.DataValueField = "Cat_id";
            LsPrToUp.DataBind();
            LsCatToProp.DataSource = ListCatgory;
            LsCatToProp.DataTextField = "Cat_name";
            LsCatToProp.DataValueField = "Cat_id";
            LsCatToProp.DataBind();
        }
       


        protected void Category_Click(object sender, EventArgs e)
        {
            Rcategory.Visible = true;
        }

        protected void AddNewCategory_Click(object sender, EventArgs e)
        {
            CategoryBLL Temp = new CategoryBLL() { Cat_name = NameCategory.Text, Main_store_id= Main_store_id };
            int NumRows = Temp.AddNewCategory(Temp);
            if (NumRows != 0)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('הקטגוריה נוספה בהצלחה')", true);
            }
            else
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('קטגוריה זו כבר קיימת במערכת')", true);
            }
        }

        protected void Model_Click(object sender, EventArgs e)
        {
            Rmodel.Visible = true;
        }
       
        protected void AddNewModl_Click(object sender, EventArgs e)
        {
             T_modelBLL Temp;
            if (listCatgory1.SelectedValue == "0")
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('עליך לבחור קטגוריה')", true);
            }
            else
            {
                Temp = new T_modelBLL() { Cat_id = int.Parse(listCatgory1.SelectedValue), Model_name = NameModel.Text, Model_pris = int.Parse(PrisModel.Text), Model_werrnty = int.Parse(ModelWernty.Text) };
                Temp = Temp.AdNewModel(Temp);
                if (Temp.Model_id == 1)
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('המוצר נוסף בהצלחה')", true);
                }
                else
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('מוצר זה קיים במערכת')", true);

                }
            }
            
            
           
        }

        protected void Property_Click(object sender, EventArgs e)
        {
            Rproperty.Visible = true;
        }

       

        protected void AddAnotherProp_Click(object sender, EventArgs e)
        {
            if(TpropName.Text != ""&& TproperNameAdmin.Text != "")
            {
                string a = TpropName.Text + "#" + TproperNameAdmin.Text;
                LstNewProperty.Items.Add(a);
                TpropName.Text = null;
                TproperNameAdmin.Text = null;
                TpropName.Focus();
                TproperNameAdmin.Focus();
               
            }
            else
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('עליך להזין שם מאפיין/מאפיין ניהול')", true);

            }
            
        }
        T_properteyBLL Temp;
        protected void AddProperty_Click(object sender, EventArgs e)
        {
            
                string[] property;
                List<T_properteyBLL> LstProp = new List<T_properteyBLL>();


                for (int i = 0; i < LstNewProperty.Items.Count; i++)
                {
                    property = LstNewProperty.Items[i].Text.Split('#');
                    Temp = new T_properteyBLL() { Proper_name = property[0], Proper_name_admien = property[1], Cat_id = int.Parse(listCatgory2.SelectedValue) };
                    LstProp.Add(Temp);
                }
            LstProp = Temp.AddNewProperty(LstProp);
            if (LstProp.Count==0)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('המאפיינים האלו קיימים כבר במערכת')", true);
            }
            else
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('המאפיינים נוספו בהצלחה')", true);

            }




        }

       
        protected void valuproperty_Click(object sender, EventArgs e)
        {
            Rvaluproperty.Visible = true;
        }

        protected void ListCatgoryToProp_SelectedIndexChanged(object sender, EventArgs e)
        {
           
            T_properteyBLL Prop= new T_properteyBLL { Cat_id=int.Parse(ListCatgoryToProp.SelectedValue)};
            List<T_properteyBLL> LstProp = new List<T_properteyBLL>();
            LstProp=Prop.ListProperty();
            LstProps.DataSource = LstProp;
            LstProps.DataTextField = "Proper_name_admien";
            LstProps.DataValueField = "Proper_id";
            LstProps.DataBind();
        }

        protected void AddAnotherValProp_Click(object sender, EventArgs e)
        {
           
            string items = LstProps.SelectedItem.Text + '@' + ValProperty.Text+'@'+ LstProps.SelectedValue;
            if (!LstValPropAndProp.Items.Contains(new ListItem(items)))
            {
                LstValPropAndProp.Items.Add(items);
            }
            ValProperty.Text = null;
            ValProperty.Focus();
        }
       
        protected void AddValProp_Click(object sender, EventArgs e)
        {
            List<T_values_propertyBLL> Lstpandv = new List<T_values_propertyBLL>();
            T_values_propertyBLL Temp;
            string[] valProp;
            
           
            for (int i = 0; i < LstValPropAndProp.Items.Count; i++)
            {
                valProp = LstValPropAndProp.Items[i].Value.Split('@');
                Temp = new T_values_propertyBLL() { Proper_id =int.Parse(valProp[2]), Proper_name= valProp[1] };
                Lstpandv.Add(Temp);
            }
            Temp = new T_values_propertyBLL();  
            int v=Temp.AddNewValueProperty(Lstpandv);
            if (v != 0)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert(' ערכי המאפיינים נוספו בהצלחה')", true);
            }
            else
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert(' ערכי המאפיינים קיימים במערכת')", true);
            }
        }


        protected void Match_Click(object sender, EventArgs e)
        {
            MatchingProductToPrope.Visible = true;
        }

        protected void LstCatToModel_SelectedIndexChanged(object sender, EventArgs e)
        {
            
                T_modelBLL model = new T_modelBLL() { Cat_id=int.Parse(LstCatToModel.SelectedValue) };
                List<T_modelBLL> Model = new List<T_modelBLL>();
                Model = model.nameModel();
                listModels.DataSource = Model;
                listModels.DataTextField = "Model_name";
                listModels.DataValueField = "Model_id";
                listModels.DataBind();
            T_properteyBLL Prop = new T_properteyBLL { Cat_id = int.Parse(LstCatToModel.SelectedValue) };
            List<T_properteyBLL> LstProp = new List<T_properteyBLL>();
            LstProp = Prop.ListProperty();
            LstPropss.DataSource = LstProp;
            LstPropss.DataTextField = "Proper_name_admien";
            LstPropss.DataValueField = "Proper_id";
            LstPropss.DataBind();
        }

        protected void AddPropAndModel_Click(object sender, EventArgs e)
        {
            string Texst = listModels.SelectedItem.Text+'@'+LstPropss.SelectedItem.Text;
            string Value = listModels.SelectedValue + '@' + LstPropss.SelectedValue;
            if (!ListModelAndProps.Items.Contains(new ListItem(Texst)))
            {
                ListModelAndProps.Items.Add(Texst);
            }
            if (!ListModelAndPropsValue.Items.Contains(new ListItem(Value)))
            {
                ListModelAndPropsValue.Items.Add(Value);
            }
        }

        protected void AddPropAndModelToData_Click(object sender, EventArgs e)
        {
            List<T_model_propertyBLL> lstPropToModel = new List<T_model_propertyBLL>();
            T_model_propertyBLL Temp;
            string[] Value;
            for(int i=0;i< ListModelAndPropsValue.Items.Count; i++)
            {
                Value = ListModelAndPropsValue.Items[i].Value.Split('@');
                Temp = new T_model_propertyBLL() { Model_id=int.Parse(Value[0]), Proper_id=int.Parse(Value[1])};
                lstPropToModel.Add(Temp);
            }
            Temp = new T_model_propertyBLL();
            int v = Temp.AddMatchModelToProp(lstPropToModel);
            if(v != 0)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('ההתאמות עודכנו במערכת')", true);

            }
            else
            {

                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('ההתאמות קיימות כבר במערכת')", true);

            }
        }

        protected void UpdateOrDeleteCat_Click(object sender, EventArgs e)
        {
            RcatUpdandDell.Visible = true;
        }

        protected void LstCatToDellUp_SelectedIndexChanged(object sender, EventArgs e)
        {
            NameCat.Text = LstCatToDellUp.SelectedItem.Text;
        }

       
        protected void UpdateCategory_Command(object sender, CommandEventArgs e)
        {
            string T = e.CommandArgument.ToString();
            int Chck = int.Parse(T);
            CategoryBLL Temp = new CategoryBLL() { Cat_id=int.Parse(LstCatToDellUp.SelectedValue), Cat_name=NameCat.Text };
            String v = Temp.UpdateOrDeleteCat(Temp, Chck);

            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('"+v+"')", true);

        }

        protected void UpdateOrDeleteModel_Click(object sender, EventArgs e)
        {
            ReUpDeletModel.Visible = true;
        }

        protected void LSTcam_SelectedIndexChanged(object sender, EventArgs e)
        {

            T_modelBLL model = new T_modelBLL() { Cat_id = int.Parse(LSTcam.SelectedValue) };
            List<T_modelBLL> Model = new List<T_modelBLL>();
            Model = model.nameModel();
            LstModelToUp.DataSource = Model;
            LstModelToUp.DataTextField = "Model_name";
            LstModelToUp.DataValueField = "Model_id";
            LstModelToUp.DataBind();
        }

        protected void LstModelToUp_SelectedIndexChanged(object sender, EventArgs e)
        {
            T_model_werrntyBLL Temp = new T_model_werrntyBLL() { Model_id=int.Parse(LstModelToUp.SelectedValue)};
            Temp=Temp.GetPrisModel();
            ModelNameUp.Text = LstModelToUp.SelectedItem.Text;
            ModelPrrisUp.Text = Temp.Model_pris.ToString();
            ModelWerntyUp.Text = Temp.Model_werrnty.ToString();
            ModelNameUp.Visible = true;
            ModelPrrisUp.Visible = true;
            ModelWerntyUp.Visible = true;
            UpdateModelDelete.Visible = true;
            DeleteModel.Visible = true;
        }

        protected void UpdateModelDelete_Command(object sender, CommandEventArgs e)
        {
            string T = e.CommandArgument.ToString();
            int Chck = int.Parse(T);
            T_modelBLL Temp = new T_modelBLL() 
            { Model_id= int.Parse(LstModelToUp.SelectedValue),
            Model_name=ModelNameUp.Text,
            Model_pris=int.Parse(ModelPrrisUp.Text),
            Model_werrnty= int.Parse(ModelWerntyUp.Text)
            };
            string v = Temp.UpdateOrDeleteModel(Temp, Chck);
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('" + v + "')", true);
        }

        protected void UpdateOrDeleteProp_Click(object sender, EventArgs e)
        {
            RePropToUp.Visible = true;
        }

        protected void LsPrToUp_SelectedIndexChanged(object sender, EventArgs e)
        {
            T_properteyBLL Prop = new T_properteyBLL { Cat_id = int.Parse(LsPrToUp.SelectedValue) };
            List<T_properteyBLL> LstProp = new List<T_properteyBLL>();
            LstProp = Prop.ListProperty();
            for(int i=0;i< LstProp.Count; i++)
            {
                LstProp[i].Proper_name_admien += '@' + LstProp[i].Proper_name;
            }
            LsPrnameAndAdminName.DataSource = LstProp;
            LsPrnameAndAdminName.DataTextField = "Proper_name_admien";
            LsPrnameAndAdminName.DataValueField = "Proper_id";
            LsPrnameAndAdminName.DataBind();
        }

        protected void LsPrnameAndAdminName_SelectedIndexChanged(object sender, EventArgs e)
        {
            string[] T = LsPrnameAndAdminName.SelectedItem.Text.Split('@');
            Nprop.Text = T[0];
            NpropAdmin.Text = T[1];
        }

        protected void AddPtoLs_Click(object sender, EventArgs e)
        {
            string p = Nprop.Text + '@' + NpropAdmin.Text+'@'+ LsPrnameAndAdminName.SelectedValue;
            LstPropNameToUp.Items.Add(p);
        }

        protected void UpdatNamAndAdminNameProp_Click(object sender, EventArgs e)
        {
            T_properteyBLL Temp = new T_properteyBLL();
            List<T_properteyBLL> LstNameProp = new List<T_properteyBLL>();
            for(int i=0;i< LstPropNameToUp.Items.Count; i++)
            {
              string[] T = LstPropNameToUp.Items[i].Text.Split('@');
              Temp = new T_properteyBLL() { Proper_id=int.Parse(T[2]), Proper_name_admien=T[0], Proper_name=T[1]};
              LstNameProp.Add(Temp);
            }
            string v = Temp.UpdateProprety(LstNameProp);
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('" + v + "')", true);

        }

        protected void UpdValProp_Click(object sender, EventArgs e)
        {
            RoValProp.Visible = true;
        }

        protected void LsCatToProp_SelectedIndexChanged(object sender, EventArgs e)
        {
            T_properteyBLL Prop = new T_properteyBLL { Cat_id = int.Parse(LsCatToProp.SelectedValue) };
            List<T_properteyBLL> LstProp = new List<T_properteyBLL>();
            LstProp = Prop.ListProperty();
            LsPropToVal.DataSource = LstProp;
            LsPropToVal.DataTextField = "Proper_name_admien";
            LsPropToVal.DataValueField = "Proper_id";
            LsPropToVal.DataBind();
        }

        protected void LsPropToVal_SelectedIndexChanged(object sender, EventArgs e)
        {
            var propid = LsPropToVal.SelectedValue.ToString();
            int idprop = int.Parse(propid);
            List<T_values_propertyBLL> ValuProperty = new List<T_values_propertyBLL>();
            ValuProperty = lstValueproperty(idprop);

            ValuProperty.Insert(0, new T_values_propertyBLL()
            {
                ValProp_id = 0,
                Proper_name = "בחר ערכי מאפיינים"

            });
            LsValProp.DataSource = ValuProperty;
            LsValProp.DataTextField = "Proper_name";
            LsValProp.DataValueField = "ValProp_id";
            LsValProp.DataBind();
        }
        public List<T_values_propertyBLL> lstValueproperty(int propid)
        {
            int propId = propid;
            T_values_propertyBLL Propid = new T_values_propertyBLL() { Proper_id = propId };
            List<T_values_propertyBLL> ValuepropertyName = new List<T_values_propertyBLL>();
            ValuepropertyName = Propid.ValuepropertyName();
            return ValuepropertyName;
        }

        protected void LsValProp_SelectedIndexChanged(object sender, EventArgs e)
        {
            ValPropName.Text = LsValProp.SelectedItem.Text;
        }

        protected void AddToLsValProp_Click(object sender, EventArgs e)
        {
            LsValPropNameToUp.Items.Add(ValPropName.Text+'@'+ LsValProp.SelectedValue);
        }

        protected void UpdateValPropName_Click(object sender, EventArgs e)
        {
            string[] T;
            T_values_propertyBLL Temp = new T_values_propertyBLL();
            List<T_values_propertyBLL> LsValPropName = new List<T_values_propertyBLL>();
            for(int i=0;i< LsValPropNameToUp.Items.Count; i++)
            {
                T = LsValPropNameToUp.Items[i].Text.Split('@');
                Temp = new T_values_propertyBLL() { Proper_name = T[0], ValProp_id=int.Parse(T[1])};
                LsValPropName.Add(Temp);
            }
            string v = Temp.UpdateValPropName(LsValPropName);
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('" + v + "')", true);

        }
      
        protected void AddBranc_Click(object sender, EventArgs e)
        {
            RowBranc.Visible = true;
        }

        protected void AddNewBranc_Click(object sender, EventArgs e)
        {
            T_branchesBLL Temp = new T_branchesBLL() { Main_store_id = Main_store_id, Branches_name = TextBrancName.Text, Branches_adrss = TextBrancAdrsse.Text };
            int a = Temp.AddNewBrnncher(Temp);
            if (a == 0)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('סניף זה כבר קיים במערכת')", true);

            }
            else
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('הסניף נוסף בהצלחה')", true);

            }
        }
    }
}