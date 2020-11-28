<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="VeuOrdersSup.aspx.cs" Inherits="Msmf.admin.VeuOrdersSup" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script src="js/jquery-3.3.1.js"></script>//10
     <link href="vendor/bootstrap/css/bootstrap.min.css" rel="stylesheet"/>
     <link href="css/Tabel.css" rel="stylesheet"/>
</head>
<body>
    <form id="form1" runat="server">
        <div>
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
                                
                                <td><asp:Button ID="SowDetels" runat="server" CommandArgument='<%#Eval("Supplier_order_id")%>' OnCommand="SowDetels_Command" Text="פרטי הזמנה " /></td>
                                   
                                    
                            </tr>
                        </ItemTemplate>
                    </asp:Repeater>

                  
                </tbody>
            </table>    
          
        
           </div> 
        </div>
         <div class="table-responsive" >
             <table dir="rtl"   class="table" id="SuplereOrdersDrtels"   class="table table-striped table-bordered" style="width:100%">
                <thead>
                    <tr>
                        <th>שם מוצר </th>
                        <th>כמות </th>
                        <th>מאפיין </th>
                        <th>ערך מאםין </th>
                    </tr>
                </thead>
            
                <tbody>
                    <asp:Repeater ID="RptQynttyAndName" runat="server"   OnItemDataBound="RptQynttyAndName_ItemDataBound" >
                          <ItemTemplate>
                                     <td   ><%#Eval("Model_Name") %></td>
                                     <td  ><%#Eval("Quantity") %></td>
                                <asp:Repeater ID="RptPropAndVal" runat="server">
                                    
                                        <ItemTemplate>
                                             <tr>
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
    </form>
    <script src="js/bootstrap.min.js"></script>
    <script src="vendor/bootstrap/js/bootstrap.min.js"></script>
     
     
</body>
</html>
