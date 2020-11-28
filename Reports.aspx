<%@ Page Title="" Language="C#" MasterPageFile="~/admin/MainMaster.Master" AutoEventWireup="true" CodeBehind="Reports.aspx.cs" Inherits="Msmf.admin.Reports" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>דוחות</title>
    <style type="text/css">
    .wrap { white-space: normal; width: 100px;  }
   </style>
    <script>
         $(document).ready(function () {
             $('#tableOrdersbetwindate').DataTable();
         });
     </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainConten" runat="server">
    <!-- Button trigger modal -->
    <div class="row">
        <div class="col-md-4">
            <button  type="button" id="BtnProfilsFromCustomers" style="background-color:#33cc33;color:black;font-size:x-large" data-toggle="modal" data-target="#Reports">
              דוחות רווחים
            </button>
     
        </div>
        <div class="col-md-4">
            <button type="button" id="CountOfStock" style="background-color:#33cc33;color:black;font-size:x-large" data-toggle="modal" data-target="#myModal">
            דו"ח כמות מוצר במלאי
            </button>
        </div>
        <div class="col-md-4">
             <button type="button" id="ReportOfSoplier" style="background-color:#33cc33;color:black;font-size:x-large" data-toggle="modal" data-target="#Rsoplier">
              דוחות ספקים
           </button>
        </div>
    </div>

   
  
 
<!-- Modal -->
<div class="modal fade" id="Reports" tabindex="-1" role="dialog" aria-labelledby="exampleModalLabel" aria-hidden="true">
  <div class="modal-dialog" role="document">
    <div class="modal-content">
      <div class="modal-header">
        <h5 class="modal-title" id="exampleModalLabel">דוחות רווחים</h5>
        <button type="button" class="close" data-dismiss="modal" aria-label="Close">
          <span aria-hidden="true">&times;</span>
        </button>
     </div>
        <asp:ScriptManager runat="server">
            <Scripts>

            </Scripts>
        </asp:ScriptManager>
        <asp:UpdatePanel ID="OrdUpPanel" runat="server">
            <ContentTemplate>
                <div class="row">
                    <div class="col">
                        <p1>בחר סניף</p1><br />
                        <asp:DropDownList  ID="DDLBranch"  runat="server"  Font-Size="Large" BackColor="YellowGreen" Width="190px" Height="40px" AutoPostBack="true" OnSelectedIndexChanged="DDLBranch_SelectedIndexChanged"/>
                    </div>
                     
               </div>
                <br />
                <div class="row" >
                    <div class="col">
                            <asp:Button ID="ProfitsBetwinDate" Width="205px" runat="server" OnClick="ProfitsBetwinDate_Click" class="btn btn-primary"  Text="הצג רווחים בין תאריכים" />
                    </div>
                    <div class="col">
                         <asp:Button ID="ProfitsCustomersBetwinDat" Width="205px" runat="server" OnClick="ProfitsCustomersBetwinDat_Click" class="btn btn-primary" Text="הצג רווחי לקוחות בין תאריכים"  />
            
                    </div>
               
                </div>
                    
                <br />
                <div class="row">
                    <div class="col">
                        <asp:Button ID="ProfitsFromTheBeginningOfTheMonth"  Width="205px" runat="server" OnClick="ProfitsFromTheBeginningOfTheMonth_Click"  class="btn btn-primary" Text="הצג רוחים מתחילת חודש נוכחי" /> 
           
                    </div>
                    <div class="col">
                         <asp:Button ID="ProfitsFromThisDay"  Width="205px" runat="server" OnClick="ProfitsFromThisDay_Click"  class="btn btn-primary" Text="הצג רווחים ליום זה/יום אחר" />  
           
                    </div>
                </div>
                <div class="row">
                    <div class="col">
                        <asp:TextBox ID="FirstDateProfits" runat="server" TextMode="Date" Width="160px" Visible="false"/>
                    </div>
                   
                    <div class="col">
                         <asp:TextBox ID="SecondDateProfits" runat="server" TextMode="Date" Width="160px" Visible="false"/>
                    </div>
                </div>
                    
                  
                   <asp:DropDownList runat="server" Width="160px" ID="AllCustlList" Visible="false" Font-Size="Large"   BackColor="YellowGreen" />
             <br />
                <div class="row">
                   
                    <div class="col">
                     <i class="fa fa-ils" aria-hidden="true"></i>   <asp:TextBox ID="TotalOfProfits" runat="server"  Width="160px"  Visible="false"/>
                                                                                                                                               
                   </div>
                  
                
                 
              </div>
                
                <asp:Button ID="SowProfitsBetwinDate" runat="server" OnClick="SowProfitsBetwinDate_Click" class="btn btn-primary"  Text="הצג" Visible="false" />
                <asp:Button  ID="SowProfitsCustomersBetwinDat" runat="server" OnClick="SowProfitsCustomersBetwinDat_Click" class="btn btn-primary"  Visible="false" Text="הצג" />
                 <asp:Button ID="SowProfitsFromTheBeginningOfTheMonth" runat="server" OnClick="SowProfitsFromTheBeginningOfTheMonth_Click" class="btn btn-primary" Visible="false" Text="הצג " />
                  <asp:Button ID="SowProfitsFromThisDay" runat="server" OnClick="SowProfitsFromThisDay_Click" Visible="false" class="btn btn-primary" Text="הצג" /> 
               </ContentTemplate>
        </asp:UpdatePanel>
      <div class="modal-footer">
        <button type="button" class="btn btn-secondary" data-dismiss="modal">סגור</button>
        
      </div>
    </div>
  </div>
</div>
 <div class="modal fade" id="Rsoplier" tabindex="-1" role="dialog" aria-labelledby="exampleModalLabel" aria-hidden="true">
  <div class="modal-dialog" role="document">
    <div class="modal-content">
      <div class="modal-header">
        <h5 class="modal-title" id="Tit">דוחות ספקים</h5>
        <button type="button" class="close" data-dismiss="modal" aria-label="Close">
          <span aria-hidden="true">&times;</span>
        </button>
     </div>
       
        <asp:UpdatePanel  runat="server">
            <ContentTemplate>
                <div class="row">
                    <div class="col">
                         <asp:Button ID="PaymentsToSopliersBetwinDate" Width="205px" runat="server" OnClick="PaymentsToSopliersBetwinDate_Click" BackColor="#3399ff" CssClass="wrap" Text=" תשלומים לספקים בין תאריכים" />
                    </div>
                    <div class="col">
                          <asp:Button ID="PaymentsToSopliBetwinDate" Width="205px" runat="server" OnClick="PaymentsToSopliBetwinDate_Click" BackColor="#3399ff" CssClass="wrap" Text=" תשלומים לספק בין תאריכים" />
                      
                    </div>
                </div>
                <br />
                <div class="row">
                    <div class="col">
                        <asp:Button ID="PaymentsToSopiersFromTheBeginningOfTheMont" Width="205px" runat="server" OnClick="PaymentsToSopiersFromTheBeginningOfTheMont_Click" BackColor="#3399ff" CssClass="wrap"  Text=" תשלומים לספקים מתחילת חודש נוכחי" />
           
                    </div>
                    <div class="col">
                       <asp:Button ID="PaymentsToSopliFromTheBeginningOfTheMont" Width="205px" runat="server" OnClick="PaymentsToSopliFromTheBeginningOfTheMont_Click" BackColor="#3399ff" CssClass="wrap"  Text=" תשלומים לספק מתחילת חודש נוכחי" />  
                     
                    </div>
                </div><br />
                <div class="row">
                    <div class="col">
                        <asp:Button ID="AllPaymentsToSopli" Width="105px" Height="105px" runat="server" OnClick="AllPaymentsToSopli_Click"  BackColor="#3399ff" Text="הצג את כל התשלומים ששולמו לספק זה" CssClass="wrap"/>  
                    </div>
                </div>
                <div class="row">
                    <div class="col">
                        <asp:TextBox ID="PaymentsFersDate" runat="server" TextMode="Date" Width="160px" Visible="false"/>
                    </div>
                   
                    <div class="col">
                         <asp:TextBox ID="PaymentsSecondDate" runat="server" TextMode="Date" Width="160px" Visible="false"/>
                    </div>
                </div>
                  <asp:DropDownList runat="server" Width="160px" ID="LstAllSoplier" Visible="false" Font-Size="Large"   BackColor="YellowGreen" />
                   <br />
                <div class="row">
                   
                    <div class="col">
                  <asp:TextBox ID="PaymentTotal" runat="server"  Width="160px"  Visible="false"/>
                                                                                                                                               
                   </div>
                    <asp:TextBox ID="Tnumber" runat="server" Visible="false"/>
                  
                
                 
              </div>
                <br />
                <div class="row">
                    <div class="col">
                        <asp:Button ID="SowAllPayment" Width="160px" runat="server" OnClick="SowAllPayment_Click" class="btn btn-primary"  Text="הצג" />  
                    </div>
                 </div>
                  
              
                
              </ContentTemplate>
        </asp:UpdatePanel>
      <div class="modal-footer">
        
        <button type="button" class="btn btn-secondary" data-dismiss="modal">סגור</button>
   
      </div>
    </div>
  </div>
</div>
  
    <div id="orderdiv" runat="server" visible="false" >
       <div class="table-responsive">
       <div class="table-responsive">
            <table class="table"  id="tableOrdersbetwindate"  class="table table-striped table-bordered" style="width:100%">
                <thead>
                    <tr>
                        <th>מספר הזמנה</th>
                        <th>שם לקוח</th>
                        <th>תאריך הזמנה</th>
                        <th>פרטי הזמנה</th>
                    </tr>
                </thead>
            
                <tbody>
                    <asp:Repeater  ID="RPTallordersbetwindate"   runat="server">
                        <ItemTemplate>

                            <tr class="success">
                                <td><%#Eval("Order_cust_id") %></td>
                                <td><%#Eval("Custom_foull_name") %></td>
                                <td><%#Eval("Order_date") %></td>
                                <td><a href="javascript:editOrders(<%#Eval("Order_cust_id") %>)">עריכה/מחיקה</a></td>
                                     
                                    
                            </tr>
                        </ItemTemplate>
                    </asp:Repeater>
                 
                  
                </tbody>
            </table>    
        </div> 
       </div>
        
    </div>
     <asp:Button Visible="false" ID="BetwinDateOrd" runat="server" OnClick="BetwinDateOrd_Click" class="btn btn-primary" Text="הצג הזמנה בין תאריכים"/>
    <asp:Button Visible="false" ID="BetwinDateOrdCustom" runat="server" OnClick="BetwinDateOrdCustom_Click" class="btn btn-primary" Text="הצג הזמנות לקוחות בין תאריכים" /> 
         <div  class="row" runat="server" id="OrdrDate" visible="false" >
           <asp:TextBox ID="FirstDate" runat="server" TextMode="Date" Width="160px" Visible="false"/>
           <asp:TextBox ID="SecondDate" runat="server" TextMode="Date" Width="160px" Visible="false"/>
           <asp:Button ID="SowOrdersBetwinDate" runat="server" OnClick="SowOrdersBetwinDate_Click" class="btn btn-primary" Text="הצג" Visible="false"  />
          <asp:Button ID="clireOrdeDate" runat="server" OnClick="clireOrdeDate_Click" class="btn btn-primary" Text="חזור" />  
          
     
             <asp:UpdatePanel runat="server">
              <ContentTemplate>
                  <asp:DropDownList runat="server" ID="AllCustlLs" Visible="false" Font-Size="Large"  BackColor="YellowGreen" OnSelectedIndexChanged="AllCustlLs_SelectedIndexChanged" AutoPostBack="true" />//רשימת לקוחות
                 <asp:listbox ID="Lscustomers" SelectionMode="Multiple" runat="server" Visible="false"  Rows="5" Font-Size="Large"   BackColor="YellowGreen"/>
              </ContentTemplate>
          </asp:UpdatePanel>
          
          <asp:Button  ID="BetwinDateOrdCustomSow" runat="server" Visible="false" OnClick="BetwinDateOrdCustomSow_Click" class="btn btn-primary" Text="הצג הזמנות לקוחות בין תאריכים" />
         </div>
      <asp:Literal ID="zxzx" runat="server"></asp:Literal>
    
  <!-- The Modal -->
  <div class="modal fade" id="myModal">
    <div class="modal-dialog">
      <div class="modal-content">
      
        <!-- Modal Header -->
        <div class="modal-header">
          <h4 class="modal-title">דוח כמות מלאי</h4>
          <button type="button" class="close" data-dismiss="modal">&times;</button>
        </div>
       
        <asp:UpdatePanel runat="server" ID="UpdatePanel1">
            <ContentTemplate>
        <!-- Modal body -->
        <div class="modal-body">
            <div class="container">
                <div class="row">
                    <div class="col">
                        <p1>בחר סניף</p1><br />
                         <asp:DropDownList  ID="DLbranc"  runat="server"  Font-Size="Large" BackColor="YellowGreen" Width="190px" Height="40px" AutoPostBack="true"/>
                    </div><br />

                </div>
                    <div class="row">
                         <div class="col">
                             <asp:DropDownList  ID="listCatgory1"  runat="server"  Font-Size="Large" BackColor="YellowGreen" Width="170px" AutoPostBack="true" OnSelectedIndexChanged="listCatgory1_SelectedIndexChanged" />
               
                         </div>
                          <div class="col">
                           <asp:DropDownList ID="listModels"   runat="server" Font-Size="Large" BackColor="YellowGreen" Width="170px" AutoPostBack="true" OnSelectedIndexChanged="listModels_SelectedIndexChanged" />
                        </div>
                           
                </div>
                
                
            
               <div  class="row">
                   <div class="col">

                       <asp:listbox runat="server"  Width="170px"  Rows="6" ID="lstProperty" SelectionMode="Multiple" Font-Size="Large"   BackColor="YellowGreen" AutoPostBack="true"  OnSelectedIndexChanged="lstProperty_SelectedIndexChanged"  />
                  </div>
                    <div class="col">
                        <asp:listbox runat="server"  Width="170px"  Rows="6"  ID="llstProperty" SelectionMode="Single" Font-Size="Large" BackColor="YellowGreen"  /> 
                      </div>  
              </div>
                
                 
                   
                      
                   
                   
                   <asp:listbox runat="server" ID="ValProp" Visible="false" /> 
                   
               
                 <asp:LinkButton runat="server" ID="NexxtSyup" OnClick="NexxtSyup_Click" CssClass="btn btn-lg btn-success btn-block"><i class="fa fa-arrow-down" aria-hidden="true"></i></asp:LinkButton>
              

                   <asp:listbox runat="server" ID="VeuProp" Width="170px"  Rows="6" SelectionMode="Single" Font-Size="Large"   BackColor="YellowGreen" AutoPostBack="true" OnSelectedIndexChanged="VeuProp_SelectedIndexChanged" /> 
               <div class="row">
                   <div class="col">
                       <asp:LinkButton runat="server" ID="Cncel" Width="170px" BackColor="#ff0000" Height="40px" OnClick="Cncel_Click"><i class="fa fa-times" aria-hidden="true"></i></asp:LinkButton> 
                     
                       </div>
                  
               </div>
               
                <div class="row">
                
                    <div class="col">
    
                    </div>
                    
                    <div class="col">
                        <asp:Button runat="server" ID="CounterOfStock" Width="170px" Height="40px" Text="הצג כמות מוצר" OnClick="CounterOfStock_Click" CssClass="btn btn-lg btn-success btn-block" />
                   
                    </div>
                    
                    <div class="col">
  
                    </div>
                     </div>
                <div class="row">
                    <div class="col">
                        <h4>כמות מוצר במלאי</h4>
                       <asp:TextBox ID="CountProdByStock" runat="server" Width="170px"/>
                    </div>
                </div>
                   </div>    
           </div>
              </ContentTemplate>
        </asp:UpdatePanel>
        <!-- Modal footer -->
        <div class="modal-footer">
          <button type="button" class="btn btn-danger" data-dismiss="modal">סגור</button>
            
        </div>
        
      </div>
    </div>
  </div>             
       
</asp:Content>
