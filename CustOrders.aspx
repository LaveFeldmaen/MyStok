<%@ Page Title="" Language="C#" MasterPageFile="~/admin/MainMaster.Master" AutoEventWireup="true" CodeBehind="CustOrders.aspx.cs" Inherits="Msmf.admin.CustOrders" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>הזמנות לקוחות</title>
       <script>
         $(document).ready(function () {
             $('#tableOrders').DataTable();
         });



           
     </script>

  
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainConten" runat="server">
     <asp:ScriptManager runat="server">
               <Scripts>

               </Scripts>
          </asp:ScriptManager>
   <asp:UpdatePanel runat="server">
       <ContentTemplate>
  <div class="row">
        <div class="col">
            <asp:Button ID="SowOrdersByBranch" OnClick="SowOrdersByBranch_Click" runat="server" Width="170px" Height="80px" BackColor="#33cc33"   font-size=x-large Text="הצג הזמנות לקוחות" />
            <asp:DropDownList  ID="DDLBranch" Visible="false"  runat="server"  Font-Size="Large" BackColor="YellowGreen" Width="170px" AutoPostBack="true"  OnSelectedIndexChanged="DDLBranch_SelectedIndexChanged"/>
       </div>
    </div>
  <div class="row" visible="false" runat="server" id="RtableOrderCustomers">
               <div class="panel-body">
       
                 <div class="table-responsive">
      
                     <div class="table-responsive">
           
                         <table class="table" id="tableOrders"  class="table table-striped table-bordered" style="width:100%">
                <thead>
                    <tr>
                        <th>מספר הזמנה</th>
                        <th>שם לקוח</th>
                        <th>תאריך הזמנה</th>
                        <th>פרטי הזמנה</th>
                    </tr>
                </thead>
            
                <tbody>
                    <asp:Repeater  ID="RPTallorders"   runat="server">
                        <ItemTemplate>

                            <tr class="success">
                                <td><%#Eval("Order_cust_id") %></td>
                                <td><%#Eval("Custom_foull_name") %></td>
                                <td><%#Eval("Order_date") %></td>
                                <td><%--<a href="javascript:editOrders(<%#Eval("Order_cust_id") %>)">עריכה </a>--%>
                                <asp:Button ID="SowdetelsOrders" runat="server" CommandArgument='<%# Eval("Order_cust_id")%>' Text="הצג פרטי הזמנות"  OnCommand="SowdetelsOrders_Command" />         
                                </td>
                                 
                                  
                                 
                                    
                                   
                                   
                                   
                                    
                            </tr>
                        </ItemTemplate>
                    </asp:Repeater>
                 
                  
                </tbody>
            </table>    
        </div> 
       </div> 
      </div>
           </div>
<div class="row" runat="server" id="Rtodc" visible="false">
     <div class="table-responsive">
       <div class="table-responsive">
            <table class="table" id="tableOrdersDetels"  class="table table-striped table-bordered" style="width:100%">
                <thead>
                    <tr>
                        <th>מספר הזמנה</th>
                        <th>קוד מוצר</th>
                        <th>כמות</th>
                        <th>מחיר ליחידה</th>
                        <th>שם מוצר</th>
                        <th>עריכה</th>
                    </tr>
                </thead>
            
                <tbody>
                    <asp:Repeater  ID="RPTordersdetels"   runat="server">
                        <ItemTemplate>

                            <tr class="success">
                                <td><%#Eval("Order_cust_id") %></td>
                                <td><%#Eval("Model_id") %></td>
                                <td><%#Eval("Quantity") %></td>
                                <td><%#Eval("Unit_pris") %></td>
                                <td><%#Eval("Model_name") %></td>
                                <td><%--<a href="javascript:editOrders(<%#Eval("Order_cust_id") %>)">עריכה </a>--%>
                                  <asp:LinkButton class="btn btn-primary" ID="AdetdetelsOrderss" runat="server" CommandArgument='<%# Eval("Order_cust_id")+";"+Eval("Model_id")+";"+Eval("Quantity")+";"+Eval("Unit_pris")+";"+Eval("Model_name")%>' Text="עדכון/מחיקה"  OnCommand="AdetdetelsOrderss_Command" BackColor="#00ff00"><i class="fa fa-pencil" aria-hidden="true"></i></asp:LinkButton>
                                </td>
                                 
                                  
                                 
                                    
                                   
                                   
                                   
                                    
                            </tr>
                        </ItemTemplate>
                    </asp:Repeater>
                 
                  
                </tbody>
            </table>    
        </div> 
       </div> 
   
</div>
     
       </ContentTemplate>
   </asp:UpdatePanel>
  
    

      
    
    <button type="button"  style="background-color:#33cc33; width:170px; height:80px;  color:black;font-size:x-large"  class="BtnBtn" data-toggle="modal"  data-target="#myModalOrders">
   הזמנה חדשה
  </button>

  <!-- The Modal -->
  <div class="modal fade" id="myModalOrders" >
    <div class="modal-dialog">
      <div class="modal-content">
      
        <!-- Modal Header -->
        <div class="modal-header">
          <h4 class="modal-title">ביצוע הזמנות</h4>
          <button type="button" class="close" data-dismiss="modal">&times;</button>
        </div>
         
        <asp:UpdatePanel runat="server" ID="upPan">
            <ContentTemplate>
        <!-- Modal body -->
        <div class="modal-body">
                                                


      <asp:HiddenField ID="Oid" runat="server" /> 
            <div class="row">
                <div class="col">
                    <h6>רשימת סניפים</h6>
                    <asp:DropDownList  ID="DDlBranach"  runat="server"  Font-Size="Large" BackColor="YellowGreen" Width="170px" AutoPostBack="true"/>
          
                </div>
                    </div>
            <div class="row">
               
                <div class="col">
                    <asp:DropDownList runat="server" ID="Cat" OnSelectedIndexChanged="Cat_SelectedIndexChanged" AutoPostBack="true" Width="170px" Font-Size="Large" BackColor="YellowGreen" />
               </div>
                 <div class="col">

                </div>
                <div>
                      <asp:DropDownList ID="listModels"   runat="server" Font-Size="Large" BackColor="YellowGreen"  Width="170px" AutoPostBack="true" OnSelectedIndexChanged="listModels_SelectedIndexChanged" />
                </div>
                 <div class="col">

                </div>
                
            </div>
            <div class="row">
                <div class="col">
                     <asp:TextBox ID="Tsrn" runat="server"  placeholder="הזן מספר סידורי"  class="form-control" Width="170px"/>
  
                </div>
                <div class="col">
                      <asp:TextBox  ID="Tquantity" runat="server" placeholder="כמות מוצר"  class="form-control" Width="170px"/>
  
                </div>
                <div class="col">
                    <asp:TextBox ID="TorderCustSellingDate" runat="server" placeholder="תאריך מכירה " class="form-control" TextMode="Date" Width="170px"/>
    
                </div>
                <div class="col">
                    <asp:TextBox ID="Unit_pris" runat="server" placeholder="מחיר ליחידה" class="form-control"  Width="170px"/>
    
                </div>
            </div>
            <div class="row">
                <div class="col">
                     <asp:Button ID="ExistingCustomer" runat="server" OnClick="ExistingCustomer_Click"  Width="170px"  class="btn btn-primary" Text="לקוח קיים במערכת" />
                     
                </div>
                <div class="col"></div>
                <div class="col">
                    <asp:DropDownList runat="server" Width="170px" ID="AllCustlLs" Visible="false" Font-Size="Large" BackColor="YellowGreen" />
                </div>
                <div class="col"></div>
            </div>
            <br />
            <div class="row">
                <div class="col">
                 <asp:Button ID="NewCustom" runat="server" OnClick="NewCustom_Click"  class="btn btn-primary" Width="170px" Text="לקוח חדש" />
            </div>
            <div class="col"></div>
            <div class="col"></div>
           </div>
            
            

             <div class="row">
                     <div class="col"><asp:TextBox Width="170px" ID="TxtCustNail" runat="server" placeholder="כתובת מייל" class="form-control" Visible="false"  /></div>
                     <div class="col"><asp:TextBox Width="170px" ID="TxtCustFolName" runat="server" placeholder="נא להזין שם מלא" class="form-control" Visible="false" /></div>
                     <div class="col"><asp:TextBox Width="170px" ID="TxtCustPone" runat="server" placeholder="נא להזין פלאפון" class="form-control" Visible="false"/></div>
                     <div class="col"><asp:TextBox Width="170px" ID="TxtCustAdress" runat="server" placeholder="נא להזין כתובת" class="form-control" Visible="false"/></div>
             </div>

            <div class="row">
                <div class="col">
                    <asp:Button ID="AddToCart" runat="server"  OnClick="AddToCart_Click" Width="170px"  class="btn btn-primary" Text="הוסף לסל" />
                </div>
                <div class="col">

                </div>
                <div class="col">
                     <asp:listbox runat="server" Width="200px" BackColor="YellowGreen" ID="MyCart" Visible="false" />
                </div>
            </div>
          
      </div>
                 <asp:LinkButton ID="ClearMakeOrders" runat="server" OnClick="ClearMakeOrders_Click" class="btn btn-primary" ><i class="fa fa-refresh" aria-hidden="true"></i></asp:LinkButton>
              </ContentTemplate>
        </asp:UpdatePanel>
        <!-- Modal footer -->
        <div class="modal-footer">
          <button type="button" class="btn btn-danger" data-dismiss="modal">סגור</button>
            <asp:Button ID="MakeOrder" runat="server" OnClick="MakeOrder_Click" class="btn btn-primary" Text="בצע הזמנה" /> 
           
            
        </div>
        
      </div>
    </div>
  </div>
    
  


<div class="modal fade" id="DetelsOrdersModal" tabindex="-1" role="dialog" aria-labelledby="exampleModalLabel" aria-hidden="true">
  <div class="modal-dialog" role="document">
    <div class="modal-content">
      <div class="modal-header">
        <h5 class="modal-title" id="exampleModalLabel">עריכת פרטי הזמנות</h5>
        <button type="button" class="close" data-dismiss="modal" aria-label="Close">
          <span aria-hidden="true">&times;</span>
        </button>
      </div>
      <div class="modal-body">
       
       <div class="row">
           <div class="col">
                  <h6>מספר הזמנה</h6>
                  <asp:TextBox ID="Order_cust_id" runat="server" Width="160px"/>
       
           </div>
              <div class="col">
                  <h6>קוד מוצר</h6>
                  <asp:TextBox ID="Model_id" runat="server" Width="160px"/>
       
           </div>
         
       

       </div>  
       <div class="row">
               <div class="col">
                  <h6>כמות</h6>
                  <asp:TextBox ID="Quantity" runat="server" Width="160px"/>
            </div>
           <div class="col">
               <h6>מחיר ליחידה</h6> 
           <asp:TextBox ID="UnitPris" runat="server" Width="160px"/>
           </div>
       </div>   
        
        
         
          <h6>שם מוצר</h6>
         <asp:TextBox ID="NameMidel" runat="server" Width="160px"/>
      </div>
      <div class="modal-footer">
        <button type="button" class="btn btn-secondary" data-dismiss="modal">סגור</button>
         <asp:LinkButton ID="UpdateDetelsOrder" runat="server" class="btn btn-primary" BackColor="#00ff00" OnClick="UpdateDetelsOrder_Click" ><i class="fa fa-pencil" aria-hidden="true"></i></asp:LinkButton>
         <asp:LinkButton ID="deleteDetelsOrderss" OnClick="deleteDetelsOrderss_Click" BackColor="#ff0000"  class="btn btn-primary" runat="server"><i class="fa fa-trash-o" aria-hidden="true"></i></asp:LinkButton>
          
      </div>
    </div>
  </div>
</div>
 <%-- <asp:TextBox ID="point" runat="server" Visible="false"/>--%>
    <script>
        function openModal() {
            $('#DetelsOrdersModal').modal('show');
        };
   </script>

   
   
</asp:Content>
