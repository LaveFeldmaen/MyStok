using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;

namespace Msmf.admin
{
    public partial class Regester : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void BtnReg_Click(object sender, EventArgs e)
        {
            T_usersBLL Temp = new T_usersBLL() { User_email=TextEmail.Text, User_fon=TextFon.Text, User_name=TextUserName.Text, User_pass=TextPassword.Text };
            Temp=Temp.RegUser(Temp);
            if (Temp.User_email == "")
            {
                Response.Write("<script>alert('מייל זה קיים כבר במערכת בחר לך מייל אחר');</script>");
            }
            else
            {
                T_main_storeBLL Stor = new T_main_storeBLL() { Main_store_name=TextMainStore.Text, User_id=Temp.User_id };
                int a=Stor.AddNewStor(Stor);
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('נרשמתה בהצלחה')", true);
                Response.Redirect("Stok.aspx");
            }
        }
    }
}