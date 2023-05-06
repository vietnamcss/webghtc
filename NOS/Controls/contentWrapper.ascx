<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="contentWrapper.ascx.cs" Inherits="NOS.Controls.contentWrapper" %>

<!-- Content Wrapper. Contains page content -->
<div class="content-wrapper">
    <div class="container-full">
        <!-- Main content -->
        <section class="content">
            <div class="row">
                <div class="col-xl-9 col-12">
                    <div class="box"> 
                        <div class="box-body pb-lg-0">
                            <div class="row">
                                <div class="col-lg-3 col-12 be-1">
                                    <div class="d-flex justify-content-between align-items-center">
                                        <p class="mb-0 text-fade">Đã trả tiền</p>
                                        <p class="mb-0 text-success">6210</p>
                                    </div>
                                    <div>
                                        <h1 class="mb-0 fw-600">60,021.21 <small class="ms-10 me-5"><i class="text-success fa fa-caret-up"></i>1.42%</small></h1>
                                    </div>
                                </div>
                                <div class="col-lg-9 col-12">
                                    <div class="ms-lg-20 mt-20 mt-lg-0 d-flex justify-content-between align-items-center">
                                        <div>
                                            <p class="mb-0 text-fade">Chờ trả tiền</p>
                                            <h2 class="mb-0 fw-600">$8,032</h2>
                                        </div>
                                        <div>
                                            <p class="mb-0 text-fade">Chờ đối soát</p>
                                            <h2 class="mb-0 fw-600 text-success">$10,125</h2>
                                        </div>
                                        <div>
                                            <p class="mb-0 text-fade">Tỷ lệ phát thành công</p>
                                            <h2 class="mb-0 fw-600 text-success">+90.2%</h2>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div class="row mt-30">
                                <div class="col-lg-7 col-12">
                                    <h3 class="box-title">Thống kê đơn hàng</h3>
                                    <div id="investment-chart"></div>
                                </div>
                                <div class="col-lg-5 col-12">
                                    <h3 class="box-title"> Top đơn hàng </h3>
                                    <div class="d-flex justify-content-start align-items-center mt-md-20 mt-0">
                                        <div id="portfolio-chart"></div>
                                        <ul class="list-unstyled" style="margin-left: -21px;">
                                            <li><span class="badge badge-primary badge-dot me-10"></span>Hà Nội</li>
                                            <li><span class="badge badge-info badge-dot me-10"></span>Hồ Chí Minh</li>
                                            <li><span class="badge badge-success badge-dot me-10"></span>Đà Nẵng</li>
                                        </ul>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="box pull-up">
                        <div class="box-body">
                            <div class="d-md-flex justify-content-between align-items-center">
                                <div>
                                    <p><span class="text-primary">Equity</span> | <span class="text-fade">Consumption</span></p>
                                    <h3 class="mb-0 fw-500">ĐƠN HÀNG CẦN XỬ LÝ</h3>
                                </div>
                                <div class="mt-10 mt-md-0">
                                    <a href="invest.html" class="waves-effect waves-light btn btn-outline btn-primary">Invest Now</a>
                                </div>
                            </div>
                            <hr>
                            <div class="d-md-flex justify-content-between align-items-center">
                                <div class="d-flex justify-content-start align-items-center">
                                    <div class="min-w-100">
                                        <p class="mb-0 text-fade">Fund Size</p>
                                        <h6 class="mb-0">1,189.60cr</h6>
                                    </div>
                                    <div class="mx-lg-50 mx-20 min-w-70">
                                        <p class="mb-0 text-fade">Return(P.A.)</p>
                                        <h6 class="mb-0 text-success">+3.29%</h6>
                                    </div>
                                    <div>
                                        <p class="mb-0 text-fade">Risk</p>
                                        <h6 class="mb-0">High</h6>
                                    </div>
                                </div>
                                <div class="mt-10 mt-md-0">
                                    <a href="#" class="waves-effect waves-light btn btn-primary btn-flat"><i class="fa fa-shopping-cart me-10"></i>Add To Cart</a>
                                </div> 
                            </div>
                             <hr>
                            <div class="d-md-flex justify-content-between align-items-center">
                                <div class="d-flex justify-content-start align-items-center">
                                    <div class="min-w-100">
                                        <p class="mb-0 text-fade">Fund Size</p>
                                        <h6 class="mb-0">1,189.60cr</h6>
                                    </div>
                                    <div class="mx-lg-50 mx-20 min-w-70">
                                        <p class="mb-0 text-fade">Return(P.A.)</p>
                                        <h6 class="mb-0 text-success">+3.29%</h6>
                                    </div>
                                    <div>
                                        <p class="mb-0 text-fade">Risk</p>
                                        <h6 class="mb-0">High</h6>
                                    </div>
                                </div>
                                <div class="mt-10 mt-md-0">
                                    <a href="#" class="waves-effect waves-light btn btn-primary btn-flat"><i class="fa fa-shopping-cart me-10"></i>Add To Cart</a>
                                </div>

                            </div>
                        </div>
                    </div> 
                </div>

                <div class="col-xl-3 col-12">
                    <div class="mb-20">
                        <a href="#" class="waves-effect waves-light btn w-p100 btn-success mb-5">Invest Now <i class="ms-15 fa fa-angle-right"></i></a>
                    </div>
                    <div class="box bg-transparent no-shadow">
                        <div class="box-header ps-0 pb-0">
                            <h3 class="box-title no-border">Upcoming SIP
                            </h3>
                        </div>
                    </div>
                    <div class="box">
                        <div class="box-body">
                            <p class="mb-15">25 Dec 2021</p>
                            <div class="d-flex pb-15 mb-15 bb-1 bb-dashed">
                                <div class="" style="width: 50px; margin-right: 13px;">
                                    <img src="images/logo/logo-1.jpg" class="avatar b-1" alt="" />
                                </div>
                                <div class="text-overflow" style="margin-left: 5px;">
                                    <a href="#">
                                        <p class="mb-0 fw-500 text-overflow">Prudential FMCG Fund - Growth</p>
                                        <p class="mb-0 fw-500">$500</p>
                                    </a>
                                </div>
                            </div>
                            <div class="d-flex pb-15 mb-15 bb-1 bb-dashed">
                                <div class="me-10" style="width: 50px;">
                                    <img src="images/logo/logo-2.jpg" class="avatar b-1" alt="" />
                                </div>
                                <div class="text-overflow" style="margin-left: 5px;">
                                    <a href="#">
                                        <p class="mb-0 fw-500 text-overflow">Market Fund Direct-Growth</p>
                                        <p class="mb-0 fw-500">$500</p>
                                    </a>
                                </div>
                            </div>
                            <div class="d-flex pb-15 mb-15 bb-1 bb-dashed">
                                <div class="me-10 modal-1">
                                    <img src="images/logo/logo-3.jpg" class="avatar b-1" alt="" />
                                </div>
                                <div class="text-overflow overflow_box">
                                    <a href="#">
                                        <p class="mb-0 fw-500 text-overflow">ABCD Money Market Fund Direct Plan-Growth</p>
                                        <p class="mb-0 fw-500">$500</p>
                                    </a>
                                </div>
                            </div>
                            <p class="mb-15">01 Jan 2022</p>
                            <div class="d-flex pb-15 mb-15 bb-1 bb-dashed">
                                <div class="me-10 modal-1 ">
                                    <img src="images/logo/logo-4.jpg" class="avatar b-1" alt="" />
                                </div>
                                <div class="text-overflow overflow_box">
                                    <a href="#">
                                        <p class="mb-0 fw-500 text-overflow">A&D Money Market Fund Direct-Growth</p>
                                        <p class="mb-0 fw-500">$500</p>
                                    </a>
                                </div>
                            </div>
                            <div class="d-flex">
                                <div class="me-10" style="width: 50px;">
                                    <img src="images/logo/logo-5.jpg" class="avatar b-1" alt="" />
                                </div>
                                <div class="text-overflow" style="margin-left: 5px;">
                                    <a href="#">
                                        <p class="mb-0 fw-500 text-overflow">Index Sensex Direct</p>
                                        <p class="mb-0 fw-500">$500</p>
                                    </a>
                                </div>
                            </div>
                        </div>
                    </div> 
                </div>
            </div>
        </section>
        <!-- /.content -->
    </div>
</div>
<!-- /.content-wrapper -->
