<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="quickUserToggle.ascx.cs" Inherits="NOS.Controls.panel.quickUserToggle" %>
<!-- quick_user_toggle -->
<div class="modal modal-right fade" id="quick_user_toggle" tabindex="-1">
    <div class="modal-dialog">
        <div class="modal-content slim-scroll3">
            <div class="modal-body p-30 bg-white">
                <div class="d-flex align-items-center justify-content-between pb-30">
                    <h4 class="m-0">User Profile
                       <small class="text-fade fs-12 ms-5">12 messages</small>
                    </h4>
                    <a href="#" class="btn btn-icon btn-primary-light btn-sm no-shadow" data-bs-dismiss="modal">
                        <span class="fa fa-close"></span>
                    </a>
                </div>
                <div>
                    <div class="d-flex flex-row">
                        <div class="">
                            <asp:Image ID="img_avatar" runat="server" alt="user" class="rounded bg-primary-light w-150" Width="100" />
                        </div>
                        <div class="ps-20">
                            <h5 class="mb-0">
                                <asp:Label ID="lbl_userName" runat="server" Text=""></asp:Label>
                            </h5>
                            <p class="my-5 text-fade">
                                <asp:Label ID="lbl_position" runat="server" Text=""></asp:Label>
                            </p>

                            <asp:HyperLink ID="hpl_userEmail" runat="server">
                                <i class="fa fa-envelope-o" aria-hidden="true"></i>
                                <asp:Label ID="lbl_userMail" runat="server" Text=""></asp:Label>
                            </asp:HyperLink>
                            <asp:LinkButton ID="lb_signOut" class="btn btn-primary-light btn-sm mt-5" runat="server" OnClick="lb_signOut_Click"><i class="fa fa-sign-out" aria-hidden="true"></i> Đăng xuất</asp:LinkButton>

                        </div>
                    </div>
                </div>
                <div class="dropdown-divider my-30"></div>
   
            </div>
        </div>
    </div>
</div>
<!-- /quick_user_toggle -->
