<%@ Page Title="" Language="C#" MasterPageFile="~/admin/MainMaster.Master" AutoEventWireup="true" CodeBehind="Stok.aspx.cs" Inherits="Msmf.admin.Stok" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title> מלאי </title>
     <script>
         $(document).ready(function () {
             $('#tableStucks').DataTable({
                 
             });
         });
         

     </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainConten"  runat="server">
    <div class="tow" id="Rstok" runat="server" visible="false">
         <div class="panel-body">
        <div class="table-responsive">
            <table class="table" id="tableStucks"  class="table table-striped table-bordered" style="width:100%">
                <thead>
                    <tr>
                        <th>מס' מוצר במלאי </th>
                        <th>מוצר ייחודי</th>
                        <th>כמות מוצר במלאי</th>
                        <th>שם ספק</th> 
                        <th>שם מוצר</th>
                        <th>סטטוס מוצר</th>
                        <th>מספר סידורי</th>
                        <th>מחיר קניה</th>
                        <th>תאריך קניה</th>
                        <th>אחריות ספק </th>
                        <th>עריכה</th>
                    </tr>
                </thead>
            
                <tbody>
                    <asp:Repeater  ID="RPTallstuck"   runat="server">
                        <ItemTemplate>

                            <tr class="success">
                                <td><%#Eval("Stock_id") %></td>
                                <td><%#Eval("Stock_unique") %></td>
                                <td><%#Eval("Stock_quantity") %></td>
                                <td><%#Eval("Supplier_name") %></td>
                                <td><%#Eval("Model_name") %></td>
                                <td><%#Eval("Status_prod") %></td>
                                <td><%#Eval("Stock_SN") %></td>
                                <td><%#Eval("Stock_buying_pric") %></td>
                                <td><%#Eval("Stock_buying_date") %></td>
                                <td><%#Eval("Supplier_waernty") %></td>
                                <td><asp:ImageButton id="EdetStok" runat="server" ImageUrl="~/admin/images/pencil.png" Width="15px" Height="15px" /> </td>             
                             </tr>
                        </ItemTemplate>
                    </asp:Repeater>

                  
                </tbody>
            </table>    
        </div>  
        <!-- /.table-responsive --> 
    </div>
    </div>
       
  
  <div class="container">
      
  </div>
    <asp:Literal runat="server" ID="stocssss"></asp:Literal>
    
 <div class="row">
     <div class="col-md-3">
         <asp:Button ID="SowStok" runat="server" Font-Size="x-large" Width="170px" Height="100px" BackColor="#33cc33" Text="הצג מלאי" OnClick="SowStok_Click" /><br />
         <h5>בחר סניף</h5>
         <asp:DropDownList  ID="DDLbranch"  runat="server"  Font-Size="x-large" Visible="false" BackColor="#33cc33" Width="170px" AutoPostBack="true" OnSelectedIndexChanged="DDLbranch_SelectedIndexChanged"/>
     </div>
     <div class="col-md-3">
          <button style="width:170px; height:100px; background-color:#33cc33;font-size:x-large; color:black" type="button" id="AddStok" class="btn btn-primary" data-toggle="modal" data-target="#myModal">
          הוסף מוצר במלאי
          </button>
    </div>
 </div>   


    

    
    

  <!-- The Modal -->
  <div class="modal fade" id="myModal">
    <div class="modal-dialog">
      <div class="modal-content">
      
        <!-- Modal Header -->
        <div class="modal-header">
          <h4 class="modal-title">עדכן מלאי</h4>
          <button type="button" class="close" data-dismiss="modal">&times;</button>
        </div>
          <asp:ScriptManager runat="server">
               <Scripts>

               </Scripts>
          </asp:ScriptManager>
        <asp:UpdatePanel runat="server" ID="upPan">
            <ContentTemplate>
        <!-- Modal body -->
        <div class="modal-body">
            <div class="container">
                    <div class="row">
                        <div class="col">
                        
                            <asp:Button ID="SowLstBranch" runat="server" BackColor="YellowGreen" Width="170px" Height="35px" OnClick="SowLstBranch_Click" Text="הצג סניפים" />
                        
                        </div>
                        <div class="col">

                             <asp:DropDownList  ID="LstBranch"  runat="server"  Font-Size="Large" BackColor="YellowGreen" Width="170px" AutoPostBack="true"/>
                        </div>
                         <div class="col">
                             <asp:DropDownList  ID="listCatgory1"  runat="server"  Font-Size="Large" BackColor="YellowGreen" Width="170px" AutoPostBack="true" OnSelectedIndexChanged="listCatgory1_SelectedIndexChanged" />
               
                         </div>
                          <div class="col">
                           <asp:DropDownList ID="listModels"   runat="server" Font-Size="Large" BackColor="YellowGreen" Width="170px" AutoPostBack="true" OnSelectedIndexChanged="listModels_SelectedIndexChanged" />
                        </div>
                           
                </div>
                <div class="row">
                    <div class="col">
                           <asp:DropDownList ID="listUnic" runat="server" Font-Size="Large"  Width="170px" BackColor="YellowGreen" />
                        </div>
                    <div class="col">
                          <asp:DropDownList ID="lisSoplier" runat="server" Font-Size="Large" BackColor="YellowGreen"  Width="170px" AutoPostBack="true" OnSelectedIndexChanged="lisSoplier_SelectedIndexChanged" />
                        </div>


               </div>
                <div class="row">
                    <div class="col">
                         <asp:TextBox ID="TStock_buying_pric" runat="server" placeholder="מחיר קניה מהספק" Height="30px"  Width="170px"/>
            
                    </div>
                    <div class="col">
                        
                   <asp:TextBox ID="TStock_buying_date" runat="server" placeholder="תאריך קניה מהספק"  Height="30px" TextMode="Date" Width="170px"/>
             
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
                   
               
                <asp:LinkButton runat="server" ID="NextStup" OnClick="NextStup_Click" CssClass="btn btn-lg btn-success btn-block" ><i class="fa fa-arrow-down" aria-hidden="true"></i></asp:LinkButton>
              

                   <asp:listbox runat="server" ID="VeuProp" Width="170px"  Rows="6" SelectionMode="Single" Font-Size="Large"   BackColor="YellowGreen" AutoPostBack="true" OnSelectedIndexChanged="VeuProp_SelectedIndexChanged" /> 
               <div class="row">
                   <div class="col">
                       <asp:LinkButton runat="server" ID="Cncel" Width="170px" BackColor="#ff0000" Height="40px" OnClick="Cncel_Click"><i class="fa fa-times" aria-hidden="true"></i></asp:LinkButton> 
                       
                   </div>
                  
               </div>
                
                
                
           </div>   
                 
            <asp:Button ID="addsn" runat="server" Text="הוסף מספר סידורי"  OnClick="addsn_Click" CssClass="btn btn-lg btn-success btn-block" />
            <div class="row">
                <div class="col">
                    <asp:TextBox ID="Tsn" runat="server" placeholder="הזן מספר סידורי" Visible="false" Height="40px"  Width="170px"/>
             
                    <asp:TextBox ID="Tqwntty" runat="server" placeholder="כמות" Visible="false" Height="40px"  Width="170px"/>
             
                </div>

            </div>   
              <asp:Button ID="addandersn" runat="server" Text="הוסף מספר סידורי נוסף" OnClick="addandersn_Click" Visible="true" CssClass="btn btn-lg btn-success btn-block" />
               <asp:listbox runat="server" Rows="5"  Width="170px" ID="lstsn" SelectionMode="Single" Font-Size="Large"   BackColor="YellowGreen"/>         
               <asp:Button runat="server" ID="AddStock" Text="הוסף מוצר במלאי" OnClick="AddStock_Click" CssClass="btn btn-lg btn-success btn-block"/> 
              
              

                                                  


                

             
               


           

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
  

      

    
   
