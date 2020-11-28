using BLL;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Msmf.App_Code;

namespace Msmf.admin
{
    public partial class Customers : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Main_store_id = (int)Session["Main_store_id"];
            if (!IsPostBack)
            {
               RPTbranch();

            }
        }
        int Main_store_id;
        public void RptAllCusomers(int BranchId)
        {
            int Branches_id = BranchId;
            CustomBLL Temp = new CustomBLL() { Branches_id= Branches_id };
            List<CustomBLL> LstCustomers = new List<CustomBLL>();
            LstCustomers = CustomBLL.getaollcust(Temp);
            RPTallcustoers.DataSource = LstCustomers;
            RPTallcustoers.DataBind();
        }
        protected void NewCustom_Click(object sender, EventArgs e)
        {
            TxtCustAdress.Visible = true;
            TxtCustFolName.Visible = true;
            TxtCustNail.Visible = true;
            TxtCustPone.Visible = true;
            NewCustom.Visible = false;
            Rditlscustomers.Visible = true;
            DDDLBranc.Visible = true;
        }

        protected void AddCustom_Click(object sender, EventArgs e)
        {
            CustomBLL customBLL = new CustomBLL() { CustomAdrss = TxtCustAdress.Text, CustomEmail = TxtCustNail.Text, CustomFollName = TxtCustFolName.Text, CustomPhone = TxtCustPone.Text, Branches_id=int.Parse(DDDLBranc.SelectedValue)};
            customBLL = customBLL.addcust();
            if (customBLL.CustomId == -1)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('לקוח זה כבר קיים במערכת')", true);
            }
            else
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('הלקוח נוסף בהצלחה')", true);
            }
        }

        protected void AditCustomers_Command(object sender, CommandEventArgs e)
        {
            AddCustom.Visible = false;
            NewCustom.Visible = false;
            string[] detelsCustomers;
            detelsCustomers = e.CommandArgument.ToString().Split(';');
            TxtCustId.Text = detelsCustomers[0];
            TxtCustFolName.Text = detelsCustomers[1];
            TxtCustNail.Text = detelsCustomers[2];
            TxtCustPone.Text = detelsCustomers[3];
            TxtCustAdress.Text = detelsCustomers[4];
            TxtCustAdress.Visible = true;
            TxtCustFolName.Visible = true;
            TxtCustNail.Visible = true;
            TxtCustPone.Visible = true;
            Rditlscustomers.Visible = true;
            ScriptManager.RegisterStartupScript(this, GetType(), "Pop", "openModal();", true);
        }

        
        string nmb;
        protected void SendSms_Click(object sender, EventArgs e)
        {

            CustomBLL c = new CustomBLL() { CustomAdrss = "ניהול מלאי", CustomPhone = "0584312628", CustomFollName = "שלום העני" };
            CustomBLL cc = new CustomBLL() { CustomAdrss = "ניהול מלאי", CustomPhone = "0584477012", CustomFollName = "שלום דוס" };
             List<CustomBLL> t = new List<CustomBLL>();
            t.Add(c);
            t.Add(cc);
         
            for (int i = 0; i < t.Count; i++)
            {
                nmb += t[i].CustomPhone + ';';
            }
            Globfunc.SendSMS(nmb, "שלום לכולם ערב טוב");



        }
        public void RPTbranch()
        {
            T_branchesBLL Temp = new T_branchesBLL() { Main_store_id = Main_store_id };
            DDLBranch.DataSource = T_branchesBLL.GetAllBranches(Temp);
            DDLBranch.DataTextField = "Branches_name";
            DDLBranch.DataValueField = "Branches_id";
            DDLBranch.DataBind();
            DDDLBranc.DataSource = T_branchesBLL.GetAllBranches(Temp);
            DDDLBranc.DataTextField = "Branches_name";
            DDDLBranc.DataValueField = "Branches_id";
            DDDLBranc.DataBind();


        }

        protected void DDLBranch_SelectedIndexChanged(object sender, EventArgs e)//החזרת רשימה של סניפים לפי קוד מחסן ראשי
        {
            RptAllCusomers(int.Parse(DDLBranch.SelectedValue));
        }

        protected void CustomersFromBranch_Click(object sender, EventArgs e)
        {
            Rbranch.Visible = true;
        }

       
        protected void NewCustome_Click(object sender, EventArgs e)
        {
            ScriptManager.RegisterStartupScript(this, GetType(), "Pop", "openModal();", true);
        }

        protected void UpdateCustomers_Click(object sender, EventArgs e)
        {
            CustomBLL customBLL = new CustomBLL() { CustomAdrss = TxtCustAdress.Text, CustomEmail = TxtCustNail.Text, CustomFollName = TxtCustFolName.Text, CustomId = int.Parse(TxtCustId.Text), CustomPhone = TxtCustPone.Text };
            int a = customBLL.UpdateCust();
            if(a==1)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('העדכון הושלם בהצלחה')", true);
            }
           
           
        }

        protected void DeleteCustomers_Click(object sender, EventArgs e)
        {
            CustomBLL customBLL = new CustomBLL() {CustomId = int.Parse(TxtCustId.Text),};
            int a = customBLL.delcust();
            if (a == 1)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('הלקוח נמחק בהצלחה')", true);
            }
        }
    }
}
