<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="NOS.Default" %> 
 
<%@ Register Src="~/Controls/mainHeader.ascx" TagPrefix="uc1" TagName="mainHeader" %>
<%@ Register Src="~/Controls/mainSidebar.ascx" TagPrefix="uc1" TagName="mainSidebar" %>
<%@ Register Src="~/Controls/contentWrapper.ascx" TagPrefix="uc1" TagName="contentWrapper" %>
<%@ Register Src="~/Controls/mainFooter.ascx" TagPrefix="uc1" TagName="mainFooter" %>
<%@ Register Src="~/Controls/panel/controlSidebar.ascx" TagPrefix="uc1" TagName="controlSidebar" %>
<%@ Register Src="~/Controls/panel/quickUserToggle.ascx" TagPrefix="uc1" TagName="quickUserToggle" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="utf-8" />
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <meta name="viewport" content="width=device-width, initial-scale=1" />
    <meta name="description" content="" />
    <meta name="author" content="" />
    <link rel="icon" href="images/favicon.ico" />
    <title>Nhang Lộc Thành | Mùi thơm êm dịu </title>
    <!-- Vendors Style-->
    <link rel="stylesheet" href="css/vendors_css.css" />
    <!-- Style-->
    <link rel="stylesheet" href="css/style.css" />
    <link rel="stylesheet" href="css/skin_color.css" />
</head>
<body class="hold-transition light-skin sidebar-mini theme-primary fixed">
    <form id="form1" runat="server">
        <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>

        <asp:HiddenField ID="hf_ORG" runat="server" />
        <asp:HiddenField ID="hf_WAREHOUSE" runat="server" />
        <asp:HiddenField ID="hf_AspHttpUser" runat="server" />
        <asp:HiddenField ID="hf_TokenKey" runat="server" />
        <asp:HiddenField ID="hf_Language" runat="server" />

        <div id="div_main_error" runat="server" visible="false" style="margin: 15px auto;">
            <div class="col-xl-12">
                <div class="alert alert-danger solid alert-dismissible fade show">
                    <div class="media">
                        <div class="media-body">
                            <h5 class="mt-1 mb-1">
                                <asp:Label ID="lbl_main_title" runat="server" Text="Thông báo"></asp:Label></h5>
                            <p>
                                <asp:Label ID="lbl_main_body" runat="server" Text="Bạn không có quyền truy cập trang này"></asp:Label>
                            </p>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <div class="wrapper" id="divMain" runat="server">
            <div id="loader"></div>
            <asp:ScriptManager ID="InSmartScriptManager" runat="server"></asp:ScriptManager>
            <uc1:mainHeader runat="server" ID="mainHeader" />
            <uc1:mainSidebar runat="server" ID="mainSidebar" />
            <uc1:contentWrapper runat="server" ID="contentWrapper" />
            <uc1:mainFooter runat="server" ID="mainFooter" />
            <uc1:controlSidebar runat="server" ID="controlSidebar" />
            <uc1:quickUserToggle runat="server" ID="quickUserToggle" />
            <div class="control-sidebar-bg"></div>
        </div>
        <!-- ./wrapper -->
        <!-- Vendor JS -->
        <script src="js/vendors.min.js"></script>
        <script src="js/pages/chat-popup.js"></script>
        <script src="assets/icons/feather-icons/feather.min.js"></script>
        <script src="assets/vendor_components/apexcharts-bundle/dist/apexcharts.js"></script>
        <!-- InvestX App -->
        <script src="js/demo.js"></script>
        <script src="js/template.js"></script>
        <script src="js/pages/dashboard.js"></script>
    </form>
</body>
</html>
