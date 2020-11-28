<%@ Page Title="" Language="C#" MasterPageFile="~/admin/MainMaster.Master" AutoEventWireup="true" CodeBehind="Customers.aspx.cs" Inherits="Msmf.admin.Customers" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>לקוחות</title>
    <style type="text/css">
    #Button1 {
        color: yellow;
        background-color: blue;
    }
  </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainConten" runat="server">
    
    <div class="row">
                  <div class="col-md-3">
                      <button id="Button1" style="color:Background,brown" runat="server"><img src="images/customer-satisfaction.png"   width="150" height="100" /><h1>לקוחות</h1></button>
             
    </div>
   </div><br />
    
     <div class="row">
        <div class="col-md-3">
             <asp:Button ID="NewCustome" runat="server" OnClick="NewCustome_Click" BackColor="#33cc33" Width="150px" Font-Size="X-Large" Height="100px" Text="לקוח חדש" />
 
        </div>
        <div class="col-md-3">
             <asp:Button ID="CustomersFromBranch" runat="server" OnClick="CustomersFromBranch_Click" BackColor="#33cc33" Width="150px" Font-Size="X-Large"  Height="100px" Text="הצג פרטי לקוחות" /> 
               
        </div>
        <div class="col-md-3">
            <asp:Button ID="SendSms" runat="server" BackColor="#33cc33" Width="150px" Font-Size="X-Large"  Height="100px"  Text="שלח sms" OnClick="SendSms_Click" />
        </div>

    </div><br /><br />

       <asp:ScriptManager runat="server">
        <Scripts>

        </Scripts>
    </asp:ScriptManager>
     <asp:UpdatePanel runat="server">
        <ContentTemplate>
            
        <div class="row" id="Rbranch" runat="server" visible="false">
            <div class="col">
                 <asp:DropDownList  ID="DDLBranch"  runat="server"  Font-Size="Large" BackColor="YellowGreen" Width="170px" AutoPostBack="true"  OnSelectedIndexChanged="DDLBranch_SelectedIndexChanged"/>
     
                   <div class="table-responsive">
            <table class="table" id="TabelCustomers"  class="table table-striped table-bordered" style="width:100%">
                <thead>
                    <tr>
                        <th>מס' לקוח </th>
                        <th>שם לקוח</th>
                        <th>מייל</th>
                        <th>מס' פלאפן</th> 
                        <th>כתובת לקוח</th>
                         <th>עריכה/מחיקה</th>
                        
                    </tr>
                </thead>
            
                <tbody>
                    <asp:Repeater  ID="RPTallcustoers"   runat="server">
                        <ItemTemplate>

                            <tr class="success">
                                <td><%#Eval("CustomId") %></td>
                                <td><%#Eval("CustomFollName") %></td>
                                <td><%#Eval("CustomEmail") %></td>
                                <td><%#Eval("CustomPhone") %></td>
                                <td><%#Eval("CustomAdrss") %></td>
                                <td><asp:Button ID="AditCustomers" runat="server" CommandArgument='<%#Eval("CustomId")+";"+Eval("CustomFollName")+";"+Eval("CustomEmail")+";"+Eval("CustomPhone")+";"+Eval("CustomAdrss")%>' OnCommand="AditCustomers_Command" Text="ערוך פרטי לקוח" /></td>
                                   
                                    
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
   
   

   
   
              <div class="modal fade" id="DetelsCustomersModal" tabindex="-1" role="dialog" aria-labelledby="exampleModalLabel" aria-hidden="true">
  <div class="modal-dialog" role="document">
    <div class="modal-content">
      <div class="modal-header">
        <h5 class="modal-title" id="exampleModalLabel">עריכת פרטי לקוח</h5>
        <button type="button" class="close" data-dismiss="modal" aria-label="Close">
          <span aria-hidden="true">&times;</span>
        </button>
      </div>
       
    <asp:UpdatePanel ID="UpCust" runat="server" >
        <ContentTemplate>
      <div class="modal-body">
           <asp:Button ID="NewCustom" runat="server" OnClick="NewCustom_Click"  class="btn btn-primary" Text="הוסף לקוח חדש" />
       <div class="row">
           <div class="col">
               <h6>בחר סניף</h6>
            <asp:DropDownList  ID="DDDLBranc"  runat="server" Visible="false"  Font-Size="Large" BackColor="YellowGreen" Width="170px" AutoPostBack="true" />
  
           </div>
               </div>
     <div class="row" id="Rditlscustomers" runat="server" visible="false">
                      <asp:TextBox ID="TxtCustId" runat="server"  Visible="false"  />
         <div class="row">
            
                     <div class="col-md-4">
                          <h6>כתובת מייל</h6>
                         <asp:TextBox ID="TxtCustNail" runat="server" placeholder="כתובת מייל" class="form-control" Visible="false" Width="160px"  /></div>
                <div class="col-md-2">

                </div>   
             <div class="col-md-4">
                 <h6>שם מלא</h6>  
                 <asp:TextBox ID="TxtCustFolName" runat="server" placeholder="נא להזין שם מלא" class="form-control" Visible="false" Width="160px" /></div>
                  
         </div>
      
         <div class="row">
            
                <div class="col-md-4">
                     <h6>מס' פלאפון</h6>
                    <asp:TextBox ID="TxtCustPone" runat="server" placeholder="נא להזין פלאפון" class="form-control" Visible="false" Width="160px"/></div>
             <div class="col-md-2">

             </div>
             <div class="col-md-4">
                  <h6>כתובת מגורים</h6>   
                 <asp:TextBox ID="TxtCustAdress" runat="server" placeholder="נא להזין כתובת" class="form-control" Visible="false" Width="160px"/></div>
              
         </div>
         
     </div>
  
  </div>
            </ContentTemplate>
    </asp:UpdatePanel>
      <div class="modal-footer">
        <button type="button" class="btn btn-secondary" data-dismiss="modal">סגור</button>
        <asp:Button ID="UpdateCustomers" runat="server" class="btn btn-primary" Text="עדכן" OnClick="UpdateCustomers_Click"/>
       <asp:Button ID="DeleteCustomers" runat="server" class="btn btn-primary" Text="מחק" OnClick="DeleteCustomers_Click"/>
        <asp:Button ID="AddCustom" runat="server" OnClick="AddCustom_Click"  class="btn btn-primary"  Text="הוסף" />
      </div>
    </div>
  </div>
</div>
    
        
   
    <script>
        function openModal() {
            $('#DetelsCustomersModal').modal('show');
        };
   </script>
   
   
 
</asp:Content>
