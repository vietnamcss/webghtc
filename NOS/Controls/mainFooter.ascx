<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="mainFooter.ascx.cs" Inherits="NOS.Controls.mainFooter" %>
<footer class="main-footer">
    <div class="pull-right d-none d-sm-inline-block">
        <ul class="nav nav-primary nav-dotted nav-dot-separated justify-content-center justify-content-md-end">
            <li class="nav-item"></li>
        </ul>
    </div>
    &copy;
    <script>document.write(new Date().getFullYear())</script>
    <a href="https://laula.media/">laula.media</a>. All Rights Reserved.
</footer>
<script src="../assets/vendor_components/select2/dist/js/select2.full.js"></script>

<script type="text/javascript">
    function pageLoad() {
        $(".fs-2").select2({ allowClear: false }); $(".fs-2-disabled").prop("disabled", true);
    } 
    function formatCurrency(n, currency) {
        var str = $(n).val();
        var res = str.replaceAll(",", "").replaceAll(".", "").trim();
        if (checkNumber(res)) { var num = new Number(res); var data = Math.round(num).toLocaleString().replaceAll(".", ",").trim(); $(n).val(data); }
        else {
            $(n).val("")
        }
    }
    function checkNumber(value) {
        return $.isNumeric(value);
    }
</script>
