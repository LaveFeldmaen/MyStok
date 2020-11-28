using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;

namespace Msmf.admin
{
    public partial class VeuOrdersSup : System.Web.UI.Page
    {
        string Id;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.QueryString["Soid"] != null)
                Id= Request.QueryString["Soid"];
                 RPTstucks(int.Parse(Id));
            }
        }
        public void RPTstucks(int Soid)
        {
            List<T_orders_supplierBLL> LSTsOrders = T_orders_supplierBLL.GetallOrders(Soid,1);
            RPTallOrdersSoplier.DataSource = LSTsOrders;
            RPTallOrdersSoplier.DataBind();
        }
        string[] detels;
        protected void SowDetels_Command(object sender, CommandEventArgs e)
        {
           T_orders_details_supplierBLL temp = new T_orders_details_supplierBLL() { Supplier_order_id = int.Parse(e.CommandArgument.ToString()) };
            List<T_orders_details_supplierProps> LstPropss = new List<T_orders_details_supplierProps>();  
            List<T_orders_details_supplierBLL> LstSopDetels = temp.GetOrdersDedelsSopliier(temp);
             
            for (int i=0;i< LstSopDetels.Count; i++)
            {
               
                detels = LstSopDetels[i].Json_property.Split(new string[] { ":::" }, StringSplitOptions.None);
                for (int z=0;z< detels.Length - 1; z++)
                {
                    string [] Str= detels[z].Split('@');
                    T_orders_details_supplierProps Tprops = new T_orders_details_supplierProps() { ProperName = Str[0], ProperValue = Str[1] };
                    LstPropss.Add(Tprops);
                }
                
                LstSopDetels[i].LstProps = new List<T_orders_details_supplierProps>(LstPropss); ;
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


    }
}