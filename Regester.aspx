<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Regester.aspx.cs" Inherits="Msmf.admin.Regester" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
     <!-- Bootstrap Core CSS -->
    <link href="css/rtl/bootstrap.min.css" rel="stylesheet"/>
    
    <!-- not use this in ltr -->
    <link href="css/rtl/bootstrap.rtl.css" rel="stylesheet"/>

    <!-- MetisMenu CSS -->
    <link href="css/plugins/metisMenu/metisMenu.min.css" rel="stylesheet"/>

    <!-- Timeline CSS -->
    <link href="css/plugins/timeline.css" rel="stylesheet"/>

    <!-- Custom CSS -->
    <link href="css/rtl/sb-admin-2.css" rel="stylesheet"/>

    <!-- Morris Charts CSS -->
    <link href="css/plugins/morris.css" rel="stylesheet"/>

    <!-- Custom Fonts -->
    <link href="css/font-awesome/font-awesome.min.css" rel="stylesheet" type="text/css"/>

    <!-- HTML5 Shim and Respond.js IE8 support of HTML5 elements and media queries -->
    <!-- WARNING: Respond.js doesn't work if you view the page via file:// -->
    <!--[if lt IE 9]>
        <script src="https://oss.maxcdn.com/libs/html5shiv/3.7.0/html5shiv.js"></script>
        <script src="https://oss.maxcdn.com/libs/respond.js/1.4.2/respond.min.js"></script>
    <![endif]-->
   
      <title>דף הרשמה</title>
   
</head>
<body>
    <form id="form1" runat="server">
          <div class="container">
        <div class="row">
            <div class="col-md-4 col-md-offset-4">
                <div class="login-panel panel panel-default">
                    <div class="panel-heading">
                        <h3 class="panel-title">הרשם למערכת</h3>
                    </div>
                    <div class="panel-body">
                        
                            <fieldset>
                                 <div class="row">
                                    <div class="col-md-3">

                                    </div>
                                    <div class="col">

                                        <img src="images/mystock.png" width="170"/>
                                    </div>

                                </div>
                                  <div class="form-group">
                                   
                                      שם משתמש<asp:TextBox ID="TextUserName" runat="server" CssClass="form-control" placeholder="שם משתמש" /><br />
                                </div> 
                                 <div class="form-group">
                                     דוא"ל<asp:TextBox ID="TextEmail" runat="server" CssClass="form-control" placeholder="מייל" /><br />
                                </div> 
                                 
                                <div class="form-group">
                                   פלאפון<asp:TextBox ID="TextFon" runat="server" CssClass="form-control" placeholder="פלאפון" /><br />
                                </div>
                                
                                <div class="form-group">
                                    סיסמה:<asp:TextBox ID="TextPassword" runat="server" TextMode="Password" CssClass="form-control" placeholder="סיסמה" /><br />
                                </div>
                                 <div class="form-group">
                                    שם חנות ראשית:<asp:TextBox ID="TextMainStore" runat="server" CssClass="form-control" placeholder="שם חנות ראשית" /><br />
                                </div>
                                
                               
                               
                                <a href="Login.aspx">משתמש קיים? התחבר</a>
                                <!-- Change this to a button or input when using this as a form -->
                                 <asp:Button runat="server" ID="BtnReg" OnClick="BtnReg_Click"  Text="הרשם" CssClass="btn btn-lg btn-success btn-block"/>
                                <%--<a href="index.html" class="btn btn-lg btn-success btn-block">התחבר</a>--%>

                            </fieldset>
                        
                    </div>
                </div>
            </div>
        </div>
    </div>
        <div>
        </div>
    </form>
    <!-- jQuery Version 1.11.0 -->
    <script src="js/jquery-3.3.1.js"></script>

    <!-- Bootstrap Core JavaScript -->
    <script src="js/bootstrap.min.js"></script>

    <!-- Metis Menu Plugin JavaScript -->
    <script src="js/metisMenu/metisMenu.min.js"></script>

    <!-- Custom Theme JavaScript -->
    <script src="js/sb-admin-2.js"></script>
</body>
</html>
