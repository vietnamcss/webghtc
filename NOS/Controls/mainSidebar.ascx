<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="mainSidebar.ascx.cs" Inherits="NOS.Controls.mainSidebar" %>
<aside class="main-sidebar">
    <!-- sidebar-->
    <section class="sidebar position-relative">
        <div class="multinav">
            <div class="multinav-scroll" style="height: 97%;">
                <!-- sidebar menu-->
                <ul class="sidebar-menu" data-widget="tree">
                    <li runat="server" id="liHome">
                        <asp:HyperLink ID="aHome" runat="server">
                            <i data-feather="home"></i>
                            <span>
                                <asp:Label ID="lbl_Home" runat="server" Text="Tổng quan"></asp:Label>
                            </span>
                        </asp:HyperLink>
                    </li>

                    <li runat="server" id="limanageFinance">
                        <a href="/manage-finance">
                            <i data-feather="dollar-sign"></i>
                            <span>
                                <asp:Label ID="lbl_manageFinance" runat="server" Text="Thống kê tài chính"></asp:Label></span>
                        </a>
                    </li>

                    <li runat="server" id="liManageOrders">
                        <a href="/manage-orders">
                            <i data-feather="plus-square"></i>
                            <span>
                                <asp:Label ID="lbl_ManageOrders" runat="server" Text="Quản lý đơn hàng"></asp:Label></span>
                        </a>
                    </li>
                    <li class="header">Quản lý</li>

                    <li class="treeview" id="liTransport" runat="server">
                        <a href="#">
                            <i data-feather="edit"></i>
                            <span>
                                <asp:Label ID="lbl_transport" runat="server" Text="Vận chuyển"></asp:Label></span>
                            <span class="pull-right-container">
                                <i class="fa fa-angle-right pull-right"></i>
                            </span>
                        </a>
                        <ul class="treeview-menu">
                            <li runat="server" id="liManageOrder">
                                <a href="/manage-order" class="d-light">
                                    <i class="fa fa-dot-circle-o" aria-hidden="true"></i>
                                    <asp:Label ID="lbl_ManageOrder" runat="server" Text="Quản lý đươn hàng"></asp:Label>
                                </a>
                            </li>
                            <li runat="server" id="liCreateOrder">
                                <a href="/create-order" class="d-light">
                                    <i class="fa fa-dot-circle-o" aria-hidden="true"></i>
                                    <asp:Label ID="lbl_CreateOrder" runat="server" Text="Tạo đơn lẻ"></asp:Label>
                                </a>
                            </li>
                            <li runat="server" id="liImportOrder">
                                <a href="/import-order" class="d-light">
                                    <i class="fa fa-dot-circle-o" aria-hidden="true"></i>
                                    <asp:Label ID="lbl_ImportOrder" runat="server" Text="Tạo đơn excel"></asp:Label>
                                </a>
                            </li>
                        </ul>
                    </li>

                    <li class="treeview" runat="server" id="liSetting">
                        <a href="#">
                            <i data-feather="settings"></i>
                            <span>
                                <asp:Label ID="lbl_Setting" runat="server" Text="Thiết lập"></asp:Label></span>
                            <span class="pull-right-container">
                                <i class="fa fa-angle-right pull-right"></i>
                            </span>
                        </a>
                        <ul class="treeview-menu">
                            <li runat="server" id="liManageUser">
                                <a href="/manage-user" class="d-light">
                                    <i class="fa fa-dot-circle-o" aria-hidden="true"></i>
                                    <asp:Label ID="lbl_ManageUser" runat="server" Text="Cài đặt tài khoản"></asp:Label>
                                </a>
                            </li>
                            <li runat="server" id="liManageAddress">
                                <a href="/manage-address" class="d-light">
                                    <i class="fa fa-dot-circle-o" aria-hidden="true"></i>
                                    <asp:Label ID="lbl_ManageAddress" runat="server" Text="Địa chỉ lấy hàng"></asp:Label>
                                </a>
                            </li>
                            <li runat="server" id="liManageCreateOrder">
                                <a href="/manage-create-order" class="d-light">
                                    <i class="fa fa-dot-circle-o" aria-hidden="true"></i>
                                    <asp:Label ID="lbl_ManageCreateOrder" runat="server" Text="Cài đặt tạo đơn"></asp:Label>
                                </a>
                            </li>

                            <li runat="server" id="liManageCustomer">
                                <a href="/manage-customer" class="d-light">
                                    <i class="fa fa-dot-circle-o" aria-hidden="true"></i>
                                    <asp:Label ID="lbl_ManageCustomer" runat="server" Text="Quản lý khách hàng"></asp:Label>
                                </a>
                            </li>

                        </ul>
                    </li>

                    <li class="treeview" runat="server" id="liSearch">
                        <a href="#">
                            <i data-feather="search"></i>
                            <span>
                                <asp:Label ID="lbl_Search" runat="server" Text="Tra cứu"></asp:Label></span>
                            <span class="pull-right-container">
                                <i class="fa fa-angle-right pull-right"></i>
                            </span>
                        </a>
                        <ul class="treeview-menu">
                            <li runat="server" id="liSearchPostage">
                                <a href="/search-postage" class="d-light">
                                    <i class="fa fa-dot-circle-o" aria-hidden="true"></i>
                                    <asp:Label ID="lbl_SearchPostage" runat="server" Text="Ước tính cước phí"></asp:Label>
                                </a>
                            </li>
                            <li runat="server" id="liNetwork">
                                <a href="/search-network" class="d-light">
                                    <i class="fa fa-dot-circle-o" aria-hidden="true"></i>
                                    <asp:Label ID="lbl_Network" runat="server" Text="Mạng lưới gửi hàng"></asp:Label>
                                </a>
                            </li>
                            <li runat="server" id="liSites">
                                <a href="/search-local" class="d-light">
                                    <i class="fa fa-dot-circle-o" aria-hidden="true"></i>
                                    <asp:Label ID="lbl_Sites" runat="server" Text="Địa danh hành chính"></asp:Label>
                                </a>
                            </li>

                        </ul>
                    </li>

                    <li runat="server" id="liSupport">
                        <a href="/support" class="d-light">
                            <i data-feather="headphones"></i>
                            <span>
                                <asp:Label ID="lbl_Support" runat="server" Text="Hỗ trợ"></asp:Label>
                            </span>
                        </a>
                    </li>
                    <li runat="server" id="liShare">
                        <a href="/connect-api" class="d-light">
                            <i data-feather="share-2"></i>
                            <span>
                                <asp:Label ID="lbl_Share" runat="server" Text="Kết nối hệ thống"></asp:Label>
                            </span>
                        </a>
                    </li>
                    <li runat="server" id="liFirewall">
                        <a href="/firewall" class="d-light">
                            <i data-feather="shield"></i>
                            <span>
                                <asp:Label ID="lbl_Firewall" runat="server" Text="Hỗ trợ"></asp:Label>
                            </span>
                        </a>
                    </li> 

                </ul>

                <div class="sidebar-widgets">
                    <div class="mx-25 mb-30 pb-20 side-bx bg-primary-light rounded20">
                        <div class="text-center">
                            <img src="images/svg-icon/color-svg/custom-32.svg" class="sideimg p-5" alt="" />
                            <h4 class="title-bx text-primary">Giao hàng tiêu chuẩn</h4>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </section>
</aside>
<!-- Side panel -->
