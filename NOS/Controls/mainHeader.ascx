<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="mainHeader.ascx.cs" Inherits="NOS.Controls.Headers.mainHeader" %>
<link href="../assets/vendor_components/select2/dist/css/select2.css" rel="stylesheet" />
<style>
        .box-header {
            padding: 1.5rem 1.5rem 0 1.5rem !important;
        }

        .sell-photos .sell-item {
            margin-left: 10px;
            width: calc(20% - 10px);
            text-align: center;
            float: left;
            border: 1px solid #f0f3f6;
            border-radius: 0.35rem;
            overflow: hidden;
            margin-bottom: 1.42rem;
            background: #ffffff;
            cursor: pointer;
        }

            .sell-photos .sell-item img {
                max-width: 100%;
            }

        .boxs {
            position: relative;
            width: 100%;
            background-color: #ffffff;
            border-radius: 5px;
            padding: 0px;
            -webkit-transition: .5s;
            transition: .5s;
            display: -ms-flexbox;
            display: flex;
            -ms-flex-direction: column;
            flex-direction: column;
            -webkit-box-shadow: 0 0 35px 0 rgb(154 161 171 / 15%);
            box-shadow: 0 0 35px 0 rgb(154 161 171 / 15%);
        }

        .dropzone {
            min-height: 150px;
            border: 1px solid rgba(0, 0, 0, 0.3) !important;
            background: white;
            padding: 0px !important;
        }
    </style>
<header class="main-header">
    <div class="d-flex align-items-center logo-box justify-content-start">
        <!-- Logo -->
        <asp:HyperLink ID="alogo" runat="server" class="logo">
                       <!-- logo-->
            <div class="logo-mini w-80">
                <span class="light-logo">
                    <img src="images/logo-letter.png" alt="logo" /></span>
                <span class="dark-logo">
                    <img src="images/logo-letter-white.png" alt="logo" /></span>
            </div>
            <div class="logo-lg">
                <span class="light-logo">
                    <img src="images/logo-dark-text.png" style="width: 155px;" alt="logo" /></span>
                <span class="dark-logo">
                    <img src="images/logo-light-text.png" style="width: 155px;" alt="logo" /></span>
            </div>     
         </asp:HyperLink>  
      
    </div>
    <!-- Header Navbar -->
    <nav class="navbar navbar-static-top">
        <!-- Sidebar toggle button-->
        <div class="app-menu">
            <ul class="header-megamenu nav">
                <li class="btn-group nav-item">
                    <a href="#" class="waves-effect waves-light nav-link push-btn btn-primary-light" data-toggle="push-menu" role="button">
                        <i data-feather="menu"></i>
                    </a>
                </li> 
                <li class="btn-group d-lg-inline-flex d-none">
                    <div class="app-menu">
                        <div class="search-bx mx-5">
                            <form>
                                <div class="input-group">
                                    <input type="search" class="form-control" placeholder="Search" />
                                    <div class="input-group-append">
                                        <button class="btn" type="submit" id="button-addon3"><i class="icon-Search"><span class="path1"></span><span class="path2"></span></i></button>
                                    </div>
                                </div>
                            </form>
                        </div>
                    </div>
                </li> 
            </ul>
        </div>

        <div class="navbar-custom-menu r-side">
            <ul class="nav navbar-nav">
                <li class="btn-group d-md-inline-flex d-none">
                    <label class="switch">
                        <span class="waves-effect skin-toggle waves-light">
                            <input type="checkbox" data-mainsidebarskin="toggle" id="toggle_left_sidebar_skin" />
                            <span class="switch-on"><i data-feather="moon"></i></span>
                            <span class="switch-off"><i data-feather="sun"></i></span>
                        </span>
                    </label>
                </li>
                <li class="btn-group d-xl-inline-flex d-none">
                    <a href="#" class="waves-effect waves-light nav-link btn-primary-light svg-bt-icon dropdown-toggle" data-bs-toggle="dropdown">
                        <img class="rounded" src="images/svg-icon/vn.svg" alt="">
                    </a>
                    <div class="dropdown-menu">
                        <a class="dropdown-item my-5" href="#">
                            <img class="w-20 rounded me-10" src="images/svg-icon/vn.svg" alt="">
                            VietNam</a>
                        <a class="dropdown-item my-5" href="#">
                            <img class="w-20 rounded me-10" src="images/svg-icon/usa.svg" alt="">
                            English</a> 
                    </div>
                </li>

                <li class="btn-group nav-item d-xl-inline-flex d-none">
                    <a href="#" data-provide="fullscreen" class="waves-effect waves-light nav-link btn-primary-light svg-bt-icon" title="Full Screen">
                        <i data-feather="maximize"></i>
                    </a>
                </li>
                <!-- Control Sidebar Toggle Button -->
                <li class="btn-group nav-item d-xl-inline-flex d-none">
                    <a href="#" data-toggle="control-sidebar" title="Setting" class="waves-effect waves-light nav-link btn-primary-light svg-bt-icon">
                        <i data-feather="sliders"></i>
                    </a>
                </li>

                <!-- User Account-->
                <li class="dropdown user user-menu">
                    <a href="#" class="waves-effect waves-light dropdown-toggle w-auto l-h-12 bg-transparent p-0 no-shadow" title="User" data-bs-toggle="modal" data-bs-target="#quick_user_toggle">
                        <asp:Image ID="img_avatar" runat="server" class="avatar rounded bg-primary-light" alt="" />
                    </a>
                </li>

            </ul>
        </div>
    </nav>
</header>
