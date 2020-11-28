<%@ Page Title="" Language="C#" MasterPageFile="~/admin/MainMaster.Master" AutoEventWireup="true" CodeBehind="SupplierOrders.aspx.cs" Inherits="Msmf.admin.SupplierOrders" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
     <style type="text/css">
    .wrap { white-space: normal; width: 100px; }
   </style>
  
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainConten" runat="server">
    
      <asp:Button ID="SowAso" runat="server" Width="190px"   Height="80px" BackColor="#33cc33"   font-size=x-large Text="הצג כל הזמנות ספקים" OnClick="SowAso_Click" />    
      <asp:DropDownList  ID="DDLBranch"   runat="server"  Font-Size="Large" BackColor="YellowGreen" Width="170px" AutoPostBack="true" OnSelectedIndexChanged="DDLBranch_SelectedIndexChanged"/>
  <div class="row" visible="false" id="ReTabelsSupplierOrdrers" runat="server">
      <div class="table-responsive">
          
           
        <table dir="rtl" class="table" id="TabelOrders"  class="table table-striped table-bordered" style="width:100%">
                <thead id="HhderTabel">
                    <tr>
                        <th>מס' הזמנה </th>
                        <th>שם ספק</th>
                        <th>תאריך הזמנה</th>
                        <th>פרטי הזמנה</th> 
                       
                        
                    </tr>
                </thead>
            
                <tbody>
                    <asp:Repeater  ID="RPTallOrdersSoplier"   runat="server">
                        <ItemTemplate>

                            <tr class="success">
                                <td ><%#Eval("Supplier_order_id") %></td>
                                <td><%#Eval("Supplier_name") %></td>
                                <td><%#Eval("Supplier_order_date") %></td>
                                
                                <td><asp:Button ID="SowDetels" runat="server" CommandArgument='<%#Eval("Supplier_order_id")%>' OnCommand="SowDetels_Command" Text="הצג פרטי הזמנה " /></td>
                                   
                                    
                            </tr>
                        </ItemTemplate>
                    </asp:Repeater>

                  
                </tbody>
            </table>    
          
  
   </div> 
    <div class="table-responsive" >
             <table dir="rtl" id="SuplereOrdersDrtels"   class="table table-striped table-bordered" style="width:100%">
                <thead>
                    <tr>
                        <th>שם מוצר </th>
                        <th>מחיר ליחידה </th>
                        <th>כמות </th>
                        <th>סה"כ לתשלום </th>
                        <th>מאפיין </th>
                        <th>ערך מאפיין </th>
                         
                    </tr>
                </thead>
            
                <tbody>
                    <asp:Repeater ID="RptQynttyAndName" runat="server"   OnItemDataBound="RptQynttyAndName_ItemDataBound" >
                          <ItemTemplate>
                                     <td   ><%#Eval("Model_Name") %></td>
                                     <td   ><%#Eval("Unit_pris") %></td>
                                     <td  ><%#Eval("Quantity") %></td>
                                      <td  ><%#Eval("Total") %></td>
                                <asp:Repeater ID="RptPropAndVal" runat="server">
                                    
                                        <ItemTemplate>
                                             <tr>
                                                  <td class="td-modal"></td>
                                                <td class="td-modal"></td>
                                                  <td class="td-modal"></td>
                                                 <td class="td-modal"></td>
                                                   <td ><%#Eval("ProperName") %></td> 
                                                   <td  ><%#Eval("ProperValue") %></td>
                                            </tr>
                                          
                                            
                                                  
                                             
                                         
                                            
                                        
                                         </ItemTemplate>
                                       
                                </asp:Repeater>
                         </ItemTemplate>
                   </asp:Repeater>
                 </tbody>
             </table>
  </div>
  </div>            
    

      
    <!-- Button trigger modal -->
<button type="button"  style="background-color:#33cc33; height:80px; width:190px; color:black;font-size:x-large"  data-toggle="modal" data-target="#MySupplierOders">
  הזמן מספק
</button>

<!-- Modal -->
<div class="modal fade" id="MySupplierOders" tabindex="-1" role="dialog" aria-labelledby="exampleModalLabel" aria-hidden="true">
   <div class="modal-dialog" role="document">
    <div class="modal-content">
      <div class="modal-header">
        <h5 class="modal-title" id="exampleModalLabel">הזמנות ספקים</h5>
        <button type="button" class="close" data-dismiss="modal" aria-label="Close">
          <span aria-hidden="true">&times;</span>
        </button>
      </div>
        <asp:ScriptManager runat="server">
            <Scripts>

            </Scripts>
        </asp:ScriptManager>
        <asp:UpdatePanel ID="OrdeBySupplier" runat="server">
             <ContentTemplate>
                   <div class="modal-body">
                       <div class="row">
                           <div class="col">
                                 <h6>רשימת סניפים</h6>
                                 <asp:DropDownList  ID="DDlbrnach"   runat="server"  Font-Size="Large" BackColor="YellowGreen" Width="170px" AutoPostBack="true"/>
                           </div>
                       </div>
                       <div class="row">
                           <div class="col">
                                <asp:DropDownList  ID="listCatgory1"  runat="server"  Font-Size="Large" Width="170px" BackColor="YellowGreen" AutoPostBack="true" OnSelectedIndexChanged="listCatgory1_SelectedIndexChanged" />
                       
                           </div>
                           <div class="col">
                                <asp:DropDownList ID="listModels"   runat="server" Font-Size="Large"  Width="170px" BackColor="YellowGreen" AutoPostBack="true"  OnSelectedIndexChanged="listModels_SelectedIndexChanged"/>
                           </div>
                       </div>
                      
                       <div class="row">
                           <div class="col">
                                 <asp:DropDownList ID="lisSoplier" runat="server"  Width="170px" Font-Size="Large" BackColor="YellowGreen" AutoPostBack="true" OnSelectedIndexChanged="lisSoplier_SelectedIndexChanged" />
                   
                           </div>
                           <div class="col">
                               <asp:TextBox ID="SoplPris"  Width="170px" runat="server" Font-Size="Large" BackColor="YellowGreen"/>
                          </div>

                       </div>
                       <div class="row">
                           <div class="col">
                               <asp:listbox runat="server"  Rows="6" ID="lstProperty" Width="170px" SelectionMode="Multiple" Font-Size="Large"   BackColor="YellowGreen" AutoPostBack="true" OnSelectedIndexChanged="lstProperty_SelectedIndexChanged" />
                       
                           </div>
                           <div class="col">
                                  <asp:listbox runat="server" Rows="6" ID="llstProperty"  Width="170px" SelectionMode="Single" Font-Size="Large"   BackColor="YellowGreen"  />
                           </div>
                       </div>
                       
                       <asp:LinkButton ID="NextStupp" runat="server" CssClass="btn btn-lg btn-success btn-block" OnClick="NextStupp_Click"><i class="fa fa-arrow-down" aria-hidden="true"></i></asp:LinkButton>
                        <asp:listbox runat="server" ID="VeuProp" Rows="6" Width="170px" SelectionMode="Single" Font-Size="Large"   BackColor="YellowGreen"/>
                        <asp:listbox runat="server" ID="ValProp" Visible="false" /> 
                         <div class="row">
                                  <div class="col">
                                     <asp:LinkButton runat="server" ID="Cncel" Width="170px" BackColor="#ff0000" Height="40px" OnClick="Cncel_Click"><i class="fa fa-times" aria-hidden="true"></i></asp:LinkButton> 
                       
                                 </div>
                  
                         </div>
                       <div class="row">
                           <div class="col">
                               <h6>כמות מוצרים</h6>
                              <asp:TextBox ID="SupllierQwentty"  runat="server" Width="170px"/>
                           </div>

                       </div>
                         <asp:Button runat="server" ID="AddTocart" OnClick="AddTocart_Click"  class="btn btn-primary"  Text="הוסף לסל" />
                       <asp:listbox runat="server"  Rows="10" ID="MyCartFromSupplier" SelectionMode="Multiple" Width="1500px" Visible="false" Font-Size="Large"  BackColor="YellowGreen"/>
                       <asp:TextBox ID="TsuplierId" runat="server" Visible="false"/>
                       <div class="row">
                           <div class="col-md-3">
                               <asp:Button ID="SowDataOfSouply" runat="server" OnClick="SowDataOfSouply_Click"  BackColor="#009900" Width="120px" Height="50px" CssClass="wrap" Text="נתוני תשלומים לספק" /> 
                               <h6>תשלומי חודש זה</h6>
                               <asp:TextBox ID="PaymentToSoplyMonth" runat="server" Visible="false" Width="120px" Height="50px"/>
                               <h6>סה"כ תשלומים</h6>
                               <asp:TextBox ID="AllpaymentToSuplay" runat="server" Visible="false" Width="120px" Height="50px"/>
                           </div>
                           <div class="col-md-3">
                                  <asp:Button ID="CompareSuppliersOrders" runat="server" OnClick="CompareSuppliersOrders_Click"  BackColor="#009900" Width="120px" Height="50px" CssClass="wrap" Text="בצע השוואה  להזמנה זו בין ספקים שונים" /> 
                          </div>
                       </div>
                      
                  
                   </div>
                   <div class="table-responsive" >
             <table dir="rtl"  class="table table-striped table-bordered" style="width:100%">
                <thead>
                    <tr>
                        <th>שם ספק </th>
                        <th>שם מוצר </th>
                        <th>כמות </th>
                        <th>מחיר ליחידה </th>
                        <th>מס' חדשי אחריות </th>
                        <th>סה"כ </th>
                        <th>סה"כ של הזמנה </th>
                      
                       
                         
                    </tr>
                </thead> 
                    
            
                <tbody>
                    <asp:Repeater ID="RptRpt" runat="server">
                          <ItemTemplate>
                              <tr>
                                    <td><%#Eval("Supplier_Name") %></td>
                                    <td><%#Eval("Model_Name") %></td>
                                     <td><%#Eval("Quantity") %></td>
                                     <td><%#Eval("Unit_pris") %></td>
                                     <td><%#Eval("Supplier_waernty") %></td>
                                     <td><%#Eval("Total") %></td>
                                     <td><%#Eval("Json_property") %></td>
                             </tr>
                       </ItemTemplate>
                   </asp:Repeater>
                         
                 </tbody>
             </table>
        </div>

             </ContentTemplate>
        </asp:UpdatePanel>
    
      <div class="modal-footer">
          <asp:Button ID="MaecOrderFromSuppliers" class="btn btn-primary" OnClick="MaecOrderFromSuppliers_Click" Text="בצע הזמנה" runat="server" />   
        <button type="button" class="btn btn-secondary" data-dismiss="modal">Close</button>
       
      </div>
    </div>
  </div>
</div>
   




     
          

</asp:Content>
