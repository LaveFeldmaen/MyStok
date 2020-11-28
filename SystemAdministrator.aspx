<%@ Page Title="" Language="C#" MasterPageFile="~/admin/MainMaster.Master" AutoEventWireup="true" CodeBehind="SystemAdministrator.aspx.cs" Inherits="Msmf.admin.SystemAdministrator" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>מנהל המערכת</title>
     <style type="text/css">
    .wrap { white-space: normal; width: 100px;  }
   </style>
    
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainConten" runat="server">
    <asp:ScriptManager runat="server">
        <Scripts>

        </Scripts>
    </asp:ScriptManager>
    <asp:UpdatePanel ID="UpMeng" runat="server">
        <ContentTemplate>
            <div class="row">
           
                <div class="col-md-3">

                 
             
             
                    <div class="row">
       
                    <asp:Button ID="Category" runat="server"  Width="135px" Height="80px" BackColor="#33cc33"  OnClick="Category_Click" Font-Size="Large"  Text="הוסף קטגוריה" />
   
                    </div> <br />
         
                <div class="row" id="Rcategory"  runat="server" visible="false">
      
                    <div class="col-md-3  ">
       
                        <h6>הזן כאן קטגוריה</h6>
        
                        <asp:TextBox ID="NameCategory" runat="server" Width="135px" Height="42px"/><br />
      
                        <asp:Button ID="AddNewCategory" runat="server" BackColor="#00ff00" Width="135px" Height="42px"  Text="הוסף" OnClick="AddNewCategory_Click" />
      
                        </div>
            
         
             </div>
            
                <div class="row">
         
                    <asp:Button ID="Model" runat="server" Width="135px" Height="80px" BackColor="#33cc33"  OnClick="Model_Click" Font-Size="Large" Text="הוסף מוצר" />
     
                
                    </div><br />
             
                <div class="row" id="Rmodel"  runat="server" visible="false">
      
              
                  <div class="col-md-3">
                     <h6>בחר קטגוריה</h6>
                      <asp:DropDownList  ID="listCatgory1"  runat="server"  Font-Size="Large" BackColor="YellowGreen" Width="170px" AutoPostBack="true"/>
                     <h6>הזן כאן שם מוצר</h6>
                     <asp:TextBox ID="NameModel" runat="server" Width="170px" Height="42px"/><br />
         
                     <h6>הזן כאן מחיר מוצר</h6>
                     <asp:TextBox ID="PrisModel" runat="server" Width="170px" Height="42px"/><br />
                      <h6>הזן כאן חדשי אחריות מוצר</h6>
                     <asp:TextBox ID="ModelWernty" runat="server" Width="170px" Height="42px"/><br />
                       <asp:Button ID="AddNewModl" runat="server" BackColor="#00ff00" Width="170px" Height="42px"  Text="הוסף" OnClick="AddNewModl_Click" />
     
     
                </div>
       
    
             </div>
             <div class="row">
                <asp:Button ID="Property" runat="server" Width="135px" Height="80px" BackColor="#33cc33"  OnClick="Property_Click" Font-Size="Large" Text="מאפייני קטגוריה   " />
           </div><br />
             <div class="row" id="Rproperty"  runat="server" visible="false">
                 <div class="col-md-3">
                      <h6>בחר קטגוריה</h6>
                      <asp:DropDownList  ID="listCatgory2"  runat="server"  Font-Size="Large" BackColor="YellowGreen" Width="170px" AutoPostBack="true"/>
                      <h6>הזן כאן שם מאפיין</h6>
                      <asp:TextBox ID="TpropName" runat="server" Width="170px" Height="42px"/><br />
                      <h6>הזן כאן שם מאפיין למנהל</h6>
                      <asp:TextBox ID="TproperNameAdmin" runat="server" Width="170px" Height="42px"/><br />
                     
                     <asp:Button ID="AddAnotherProp" runat="server" Width="170px" Height="42px" BackColor="#00ff00" OnClick="AddAnotherProp_Click" Text="הוסף עוד מאפיין" /><br />
                       
                     <asp:listBox ID="LstNewProperty" runat="server" BackColor="#33cc33" Width="170px" Rows="6" />  
                    
                     <asp:Button ID="AddProperty" runat="server" Width="170px" Height="42px" BackColor="#00ff00" OnClick="AddProperty_Click" Text="הוסף" /><br />
                 
             </div>
          </div>
             <div class="row">
                <asp:Button ID="valuproperty" runat="server" Width="135px" Height="80px" BackColor="#33cc33" CssClass="wrap"  OnClick="valuproperty_Click" Font-Size="Large" Text="הוספת ערכי מאפיינים" />
             </div><br />
             <div class="row" id="Rvaluproperty"  runat="server" visible="false">
                 <div class="col-md-3">
                     <h6>בחר קטגוריה</h6>
                      <asp:DropDownList  ID="ListCatgoryToProp"  runat="server"  Font-Size="Large" BackColor="YellowGreen" Width="170px" AutoPostBack="true" OnSelectedIndexChanged="ListCatgoryToProp_SelectedIndexChanged"/>
                     <h6>בחר מאפיין</h6>
                      <asp:DropDownList  ID="LstProps"  runat="server"  Font-Size="Large" BackColor="YellowGreen" Width="170px" AutoPostBack="true"/>
                 
                      <h6>הזן כאן ערך למאפיין</h6>
                      <asp:TextBox ID="ValProperty" runat="server" Width="170px" Height="42px"/><br />
                     
                     <asp:Button ID="AddAnotherValProp" runat="server" Width="170px" Height="42px" BackColor="#00ff00" OnClick="AddAnotherValProp_Click" Text="הוסף עוד ערך  למאפיין" /><br />
                       
                     <asp:listBox ID="LstValPropAndProp" runat="server" BackColor="#33cc33" Width="170px" Rows="6" />  
                    
                     <asp:Button ID="AddValProp" runat="server" Width="170px" Height="42px" BackColor="#00ff00" OnClick="AddValProp_Click" Text="הוסף" /><br />
                 
             </div>
                 
              
          </div>
             <div class="row">
             
                 <asp:Button ID="Match" runat="server" Width="135px" Height="80px" BackColor="#33cc33" CssClass="wrap"  OnClick="Match_Click" Font-Size="Large" Text="התאמת מאפיינים למוצר" />  
            </div><br />
             <div class="row" id="MatchingProductToPrope"  runat="server" visible="false">
                  <div class="col-md-3">
                       <h6>בחר קטגוריה</h6>
                      <asp:DropDownList  ID="LstCatToModel"  runat="server"  Font-Size="Large" BackColor="YellowGreen" Width="170px" AutoPostBack="true" OnSelectedIndexChanged="LstCatToModel_SelectedIndexChanged"/><br />
                      <h6>בחר מוצר</h6>
                    <asp:DropDownList ID="listModels"   runat="server" Font-Size="Large" BackColor="YellowGreen" Width="170px" AutoPostBack="true" /><br />
                      <h6>בחר מאפיין</h6>
                      <asp:DropDownList  ID="LstPropss"  runat="server"  Font-Size="Large" BackColor="YellowGreen" Width="170px" AutoPostBack="true"/><br />  

                      <asp:Button ID="AddPropAndModel" runat="server" Width="170px" Height="42px" BackColor="#00ff00" OnClick="AddPropAndModel_Click" Text="התאם עוד מאפיין למוצר" /><br />
                      
                       <asp:listBox ID="ListModelAndProps" runat="server" BackColor="#33cc33" Width="170px" Rows="6" /><br />  
                       <asp:listBox ID="ListModelAndPropsValue" runat="server" BackColor="#33cc33" Width="170px" Visible="false"/>  
                      
                        <asp:Button ID="AddPropAndModelToData" runat="server" Width="170px" Height="42px" BackColor="#00ff00" OnClick="AddPropAndModelToData_Click" Text="הוסף" /><br />
                 
                 </div>
              </div>
           </div>
            
                <div class="col-md-3">
                     <div class="row" >
                        <asp:Button ID="UpdateOrDeleteCat" runat="server"  Width="135px" Height="80px" BackColor="#33cc33" OnClick="UpdateOrDeleteCat_Click" Font-Size="Large" Text="עדכן/מחק קטגוריה" />
                    </div>
                     <div class="row" id="RcatUpdandDell" runat="server" visible="false">
                         <div class="col-md-3">
                              <h6>בחר קטגוריה</h6>
                              <asp:DropDownList  ID="LstCatToDellUp"  runat="server"  Font-Size="Large" BackColor="YellowGreen" Width="170px" AutoPostBack="true" OnSelectedIndexChanged="LstCatToDellUp_SelectedIndexChanged" />
                            <div>

                            </div> <br />
                             <div>
                                <asp:TextBox ID="NameCat" runat="server" Width="170px" Height="42px"/><br />
                            </div><br /> 
                             <div>
                                  <asp:LinkButton CommandArgument="1" Width="170px" Height="42px" ID="UpdateCategory" runat="server" class="btn btn-primary" BackColor="#00ff00" OnCommand="UpdateCategory_Command" ><i class="fa fa-pencil" aria-hidden="true"></i></asp:LinkButton><br />
                             </div><br />
                             <div>
                                   <asp:LinkButton Width="170px" CommandArgument="0" Height="42px" ID="DeleteCatgory" OnCommand="UpdateCategory_Command" BackColor="#ff0000"  class="btn btn-primary" runat="server"><i class="fa fa-trash-o" aria-hidden="true"></i></asp:LinkButton><br />
                             </div><br />
                         </div>
                    </div><br />
                     <div class="row" >
                            <asp:Button ID="UpdateOrDeleteModel" runat="server"  Width="135px" Height="80px" BackColor="#33cc33" OnClick="UpdateOrDeleteModel_Click" Font-Size="Large" Text="עדכן/מחק מוצר" />
                     </div>
                  <div class="row" id="ReUpDeletModel" runat="server" visible="false" >
                                 <div class="col-md-3" >
                                      
                                     <h6>בחר קטגוריה</h6>
                                      
                                     <asp:DropDownList  ID="LSTcam"  runat="server"  Font-Size="Large" BackColor="YellowGreen" Width="170px" AutoPostBack="true" OnSelectedIndexChanged="LSTcam_SelectedIndexChanged"/>
                                      
                                     <h6>בחר מוצר</h6>
                                  
                                     <asp:DropDownList  ID="LstModelToUp"  runat="server"  Font-Size="Large" BackColor="YellowGreen" Width="170px" AutoPostBack="true" OnSelectedIndexChanged="LstModelToUp_SelectedIndexChanged"/>
                                 
                                      <h6> שם מוצר</h6>
            
                                     <asp:TextBox Visible="false" ID="ModelNameUp" runat="server" Width="170px" Height="42px"/><br />
         
           
                                     <h6> מחיר מוצר</h6>
             
                                     <asp:TextBox Visible="false" ID="ModelPrrisUp" runat="server" Width="170px" Height="42px"/><br />

        
                                     <h6> חדשי אחריות מוצר</h6>
             
                                     <asp:TextBox Visible="false" ID="ModelWerntyUp" runat="server" Width="170px" Height="42px"/><br />

                                      <div>
                                  
                                          <asp:LinkButton Visible="false" CommandArgument="1" Width="170px" Height="42px" ID="UpdateModelDelete" runat="server" class="btn btn-primary" BackColor="#00ff00" OnCommand="UpdateModelDelete_Command" ><i class="fa fa-pencil" aria-hidden="true"></i></asp:LinkButton><br />
                           
                                          </div><br />
                          
                                     <div>
                                  
                                         <asp:LinkButton Visible="false" Width="170px" CommandArgument="0" Height="42px" ID="DeleteModel" OnCommand="UpdateModelDelete_Command" BackColor="#ff0000"  class="btn btn-primary" runat="server"><i class="fa fa-trash-o" aria-hidden="true"></i></asp:LinkButton><br />
                             
                                     </div><br />
            
                                
                                     </div>
                            </div><br />
                  <div class="row">
                       <asp:Button ID="UpdateOrDeleteProp" runat="server"  Width="135px" Height="80px" BackColor="#33cc33" CssClass="wrap" OnClick="UpdateOrDeleteProp_Click" Font-Size="Large" Text="עדכן מאפייני קטגוריה" />
                 </div>
                  <div class="row" id="RePropToUp" runat="server" visible="false" >
                       <div class="col-md-3">
                           <div>
                                <asp:DropDownList  ID="LsPrToUp"  runat="server"  Font-Size="Large" BackColor="YellowGreen" Width="170px" AutoPostBack="true" OnSelectedIndexChanged="LsPrToUp_SelectedIndexChanged"/>
                           </div><br />
                           <div>
                               <asp:DropDownList  ID="LsPrnameAndAdminName"  runat="server"  Font-Size="Large" BackColor="YellowGreen" Width="170px" AutoPostBack="true" OnSelectedIndexChanged="LsPrnameAndAdminName_SelectedIndexChanged"/>
                          </div><br />
                            <h6> שם מאפיין</h6>
                            <asp:TextBox ID="Nprop" runat="server" Width="170px" Height="42px"/>
                           <div>
                            <h6> שם מאפיין למנהל</h6>
                            <asp:TextBox ID="NpropAdmin" runat="server" Width="170px" Height="42px"/>
                           
                           </div><br />
                           <div>
                                <asp:Button ID="AddPtoLs" runat="server"  Width="135px" Height="80px" BackColor="#33cc33" OnClick="AddPtoLs_Click" Font-Size="Large" Text="הוסף" />
                          </div>   <br />      
                             <asp:listBox ID="LstPropNameToUp" runat="server" BackColor="#33cc33" Width="170px" Rows="6" />  
                           
                           <div>
                                <asp:Button ID="UpdatNamAndAdminNameProp" runat="server"  Width="135px" Height="80px" BackColor="#33cc33" OnClick="UpdatNamAndAdminNameProp_Click" Font-Size="Large" Text="עדכן" />
                          </div>         

                          

                    
                              
                      </div>

                   </div> <br /> 
                 
                    <div class="row">
                      <asp:Button ID="UpdValProp" runat="server"  Width="135px" Height="80px" BackColor="#33cc33" OnClick="UpdValProp_Click" Font-Size="Large" Text="עדכן ערכי מאפיינים" />
                  </div> 
                    <div class="row" id="RoValProp" runat="server" visible="false">
                        <div class="col-md-3">
                             <h6>בחר קטגוריה</h6>
                              <asp:DropDownList  ID="LsCatToProp"  runat="server"  Font-Size="Large" BackColor="YellowGreen" Width="170px" AutoPostBack="true" OnSelectedIndexChanged="LsCatToProp_SelectedIndexChanged" />
                              <asp:DropDownList  ID="LsPropToVal"  runat="server"  Font-Size="Large" BackColor="YellowGreen" Width="170px" AutoPostBack="true" OnSelectedIndexChanged="LsPropToVal_SelectedIndexChanged"/>
                              <asp:DropDownList  ID="LsValProp"  runat="server"  Font-Size="Large" BackColor="YellowGreen" Width="170px" AutoPostBack="true" OnSelectedIndexChanged="LsValProp_SelectedIndexChanged"/>
                              <h6> שם ערך מאפיין</h6>
                              <asp:TextBox ID="ValPropName" runat="server" Width="170px" Height="42px"/>
                              <asp:Button ID="AddToLsValProp" runat="server"  Width="135px" Height="80px" BackColor="#33cc33" OnClick="AddToLsValProp_Click" Font-Size="Large" Text="הוסף" />
                              <asp:listBox ID="LsValPropNameToUp" runat="server" BackColor="#33cc33" Width="170px" Rows="6" /> 
                              <asp:Button ID="UpdateValPropName" runat="server"  Width="135px" Height="80px" BackColor="#33cc33" OnClick="UpdateValPropName_Click" Font-Size="Large" Text="עדכן" />
                              
                     
                       </div>
                    </div>
                </div>
                <div class="col-md-3" >
                       <div class="row" >
                        <asp:Button ID="AddBranc" runat="server"  Width="135px" Height="80px" BackColor="#33cc33" OnClick="AddBranc_Click" Font-Size="Large" Text="הוסף סניף חדש" />
                      </div>
                     <div class="row" id="RowBranc" runat="server" visible="false">
                         <div class="col-md-3">
                              <h6>שם סניף</h6>
                              <asp:TextBox ID="TextBrancName" runat="server" Width="170px" Height="42px"/><br />
                              <h6>כתובת סניף</h6>
                              <asp:TextBox ID="TextBrancAdrsse" runat="server" Width="170px" Height="42px"/><br />
                              <asp:Button ID="AddNewBranc" runat="server" Width="170px" Height="42px" BackColor="#00ff00" Text="הוסף סניף" OnClick="AddNewBranc_Click" />

                         
                            
                                
                            
                  </div>
                </div>            

            
               
                            

            </div>
         
               
            
        </ContentTemplate>
    </asp:UpdatePanel>
  
    
    
</asp:Content>