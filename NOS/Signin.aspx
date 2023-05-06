<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Signin.aspx.cs" Inherits="NOS.Signin" %>
 
<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="utf-8" />
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <meta name="viewport" content="width=device-width, initial-scale=1" />
    <meta name="description" content="" />
    <meta name="author" content="" />
    <link rel="icon" href="images/favicon.ico" />
    <!-- Vendors Style-->
    <link rel="stylesheet" href="css/vendors_css.css" />
    <!-- Style-->
    <link rel="stylesheet" href="css/style.css" />
    <link rel="stylesheet" href="css/skin_color.css" />
   
    <title>Đăng nhập - Chuẩn là giao - Giao là chuẩn</title>
</head>
<body class="hold-transition theme-primary bg-img" style="background-image: url(/images/auth-bg/bg-16.jpg)" data-overlay="5">
    <div class="container h-p100">

        <div class="row align-items-center justify-content-md-center h-p100">
            <div class="col-12" style="margin-left: 55%;">
                <div class="row justify-content-center g-0">
                    <div class="col-lg-5 col-md-5 col-12">
                        <div class="bg-white rounded10 shadow-lg">
                            <div class="content-top-agile p-20 pb-0">
                                <h2 class="text-primary fw-600">Một ngày làm việc hiệu quả nào!</h2>
                                <p class="mb-0 text-fade">Đăng nhập để sử dụng hệ thống.</p>
                            </div>
                            <div class="p-40">
                                <form id="form_login" runat="server">
                                      <asp:HiddenField ID="hf_aspHttpsguid" runat="server" Value="1"/>
                                    <div class="form-group">
                                        <div class="input-group mb-3">
                                            <span class="input-group-text bg-transparent"><i class="text-fade ti-user"></i></span>
                                            <asp:TextBox ID="txt_user" runat="server" class="form-control ps-15 bg-transparent" placeholder="Username" ></asp:TextBox>
                                        </div>
                                    </div> 

                                    <div class="form-group">
                                        <div class="input-group mb-3">
                                            <span class="input-group-text  bg-transparent"><i class="text-fade ti-lock"></i></span>
                                            <asp:TextBox ID="txt_pass" type="password" runat="server" class="form-control ps-15 bg-transparent" placeholder="Password"></asp:TextBox>
                                        </div>
                                    </div> 

                                    <div class="row">
                                        <div class="col-6">
                                            <div class="checkbox">
                                                <input type="checkbox" id="basic_checkbox_1" />
                                                <label for="basic_checkbox_1">Ghi nhớ </label>
                                            </div>
                                        </div>
                                        <!-- /.col -->
                                        <div class="col-6">
                                            <div class="fog-pwd text-end">
                                                <a href="javascript:void(0)" class="text-primary fw-500 hover-primary"><i class="fa fa-lock" aria-hidden="true"></i> Quên mật khẩu?</a><br />
                                            </div>
                                        </div>
                                        <!-- /.col -->
                                        <div class="col-12 text-center">
                                            <asp:Button ID="bt_sumit" runat="server" Text="ĐĂNG NHẬP" class="btn btn-primary w-p100 mt-10" OnClick="bt_sumit_Click" />

                                        </div>
                                        <div class="col-12 text-center" style=" padding: 10px; font-weight: bold; color: red; ">
                                            <asp:Label ID="lbl_error" runat="server" Text=""></asp:Label>
                                        </div>
                                        <!-- /.col -->
                                    </div>
                                </form> 
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <script src="js/vendors.min.js"></script>
    <script src="js/pages/chat-popup.js"></script>
    <script src="assets/icons/feather-icons/feather.min.js"></script>  
  
</body>
</html>
