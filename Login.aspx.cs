using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;
using Msmf.App_Code;



namespace Msmf.admin
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

       
        protected void BtnLog_Click(object sender, EventArgs e)
        {
            T_usersBLL Temp = new T_usersBLL() { User_email=TextEmail.Text, User_pass=TextPass.Text};
            Temp = Temp.LogUser(Temp);
            if (Temp.User_id == 0)
            {
                Response.Write("<script>alert('כתובת מייל או סיסמא אינם תקינים ');</script>");
            }
            else
            {
                Session["User_name"] = Temp.User_name;
                Session["Main_store_id"] = Temp.Main_store_id;
                Response.Redirect("SystemAdministrator.aspx");
            }
        }

        protected void forGadPass_Click(object sender, EventArgs e)
        {
            T_usersBLL Temp = new T_usersBLL() { User_email = TextEmail.Text};
            Temp = Temp.forGadPass(Temp);
            if (Temp.User_pass == null)
            {

                Response.Write("<script>alert('מייל זה אינו מופיע במערכת עליך להזין את המייל שאיתו נרשמת ');</script>");
            }
            else
            {
               
                Globfunc.SendEmail("fldmanmnchm@gmail.com", "מנחם", "'" + Temp.User_email + "'", "שחזור סיסמא", "זו הסיסמא שלך '" + Temp.User_pass.ToString() + "'");
                Response.Write("<script>alert('הסיסמא נשלחה לך למייל אנא הקלד אותה כאן ');</script>");

            }
        }
    }
}