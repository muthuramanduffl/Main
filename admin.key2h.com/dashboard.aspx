<%@ Page Title="" Language="C#" MasterPageFile="AdminKey2h.master" AutoEventWireup="true" CodeFile="dashboard.aspx.cs" Inherits="adminkey2hcom_Dashboard" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
        <div class="content">
        <div class="panel-header bg-primary-gradient">
            <div class="page-inner py-5">
                <div class="d-flex pb-2 align-items-left align-items-sm-center flex-column flex-sm-row justify-content-between">
                    <div>
                        <h2 class="text-white pb-2 fw-bold text-uppercase">Dashboard</h2> 
                    </div> 
                </div>
            </div>
        </div>
        <div class="page-inner mt--5">
            <div class="row mt--2">
                <div class="col-md-12">
                    <div class="card full-height">
                        <div class="card-body">
                            <div class="card-title lit-blue text-uppercase">Overall</div> 
                            <div class="d-flex flex-wrap justify-content-around pb-2 pt-4">
                                <div class="px-2 pb-2 pb-md-0 text-center">
                                    <div id="circles-1"></div>
                                    <h6 class="fw-bold mt-3 mb-0">Total Leads</h6>
                                </div>
                                <div class="px-2 pb-2 pb-md-0 text-center">
                                    <div id="circles-2"></div>
                                    <h6 class="fw-bold mt-3 mb-0">Active</h6>
                                </div>
                                <div class="px-2 pb-2 pb-md-0 text-center">
                                    <div id="circles-3"></div>
                                    <h6 class="fw-bold mt-3 mb-0">Admitted</h6>
                                </div>
                                <div class="px-2 pb-2 pb-md-0 text-center">
                                    <div id="circles-4"></div>
                                    <h6 class="fw-bold mt-3 mb-0">Dropped</h6>
                                </div> 
                            </div>
                        </div>
                    </div>
                </div>
            </div>

            <div class="row">
                <div class="col-md-12">
                    <div class="card full-height">
                        <div class="card-body">
                            <div class="card-title lit-blue text-uppercase">Today</div> 
                            <div class="d-flex flex-wrap justify-content-around pb-2 pt-4">
                                <div class="px-2 pb-2 pb-md-0 text-center">
                                    <div id="circles-11"></div>
                                    <h6 class="fw-bold mt-3 mb-0">Total Leads</h6>
                                </div>
                                <div class="px-2 pb-2 pb-md-0 text-center">
                                    <div id="circles-22"></div>
                                    <h6 class="fw-bold mt-3 mb-0">Active</h6>
                                </div>
                                <div class="px-2 pb-2 pb-md-0 text-center">
                                    <div id="circles-33"></div>
                                    <h6 class="fw-bold mt-3 mb-0">Admitted</h6>
                                </div>
                                <div class="px-2 pb-2 pb-md-0 text-center">
                                    <div id="circles-44"></div>
                                    <h6 class="fw-bold mt-3 mb-0">Dropped</h6>
                                </div> 
                            </div>
                        </div>
                    </div>
                </div>
            </div>

            <div class="row row-card-no-pd">
                <div class="col-md-12">
                    <div class="card">
                        <div class="card-header">
                            <div class="card-head-row card-tools-still-right">
                                <h4 class="card-title text-warning text-uppercase">Source of Leads</h4>
                                <!-- <div class="card-tools">
									<button class="btn btn-icon btn-link btn-primary btn-xs"><span class="fa fa-angle-down"></span></button>
									<button class="btn btn-icon btn-link btn-primary btn-xs btn-refresh-card"><span class="fa fa-sync-alt"></span></button>
									<button class="btn btn-icon btn-link btn-primary btn-xs"><span class="fa fa-times"></span></button>
								</div> -->
                            </div>
                            <p class="card-category">
                                <!-- Lorem ipsum dolor sit amet</p> -->
                            </div>
                            <div class="card-body">
                                <div class="row">
                                    <div class="col-lg-5">
                                        <div class="table-responsive table-hover table-sales">
                                            <table class="table">
                                                <thead>
                                                    <tr>
                                                        <th></th>
                                                        <th></th>
                                                        <th class=" px-0">Today</th>
                                                        <th class=" px-0">Overall</th>
                                                    </tr>
                                                </thead>
                                                <tbody>
                                                    <tr>
                                                        <td>
                                                            <div class="flag">
                                                                <img src="assets/img/line-chart.png"
                                                                style="width: 30px; height: 30px;"
                                                                alt="indonesia">
                                                            </div>
                                                        </td>
                                                        <td class="text-dark f-15">Facebook</td>
                                                        <td class="">
                                                            20
                                                        </td>
                                                        <td class="">
                                                            42
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <div class="flag">
                                                                <img src="assets/img/line-chart.png"
                                                                style="width: 30px; height: 30px;"
                                                                alt="indonesia">
                                                            </div>
                                                        </td>
                                                        <td class="text-dark f-15">Instagram</td>
                                                        <td class="">
                                                            20
                                                        </td>
                                                        <td class="">
                                                            42
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <div class="flag">
                                                                <img src="assets/img/line-chart.png"
                                                                style="width: 30px; height: 30px;"
                                                                alt="united states">
                                                            </div>
                                                        </td>
                                                        <td class="text-dark f-15">Google Ads</td>
                                                        <td class="">
                                                            23
                                                        </td>
                                                        <td class="">
                                                            36
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <div class="flag">
                                                                <img src="assets/img/line-chart.png"
                                                                style="width: 30px; height: 30px;"
                                                                alt="united states">
                                                            </div>
                                                        </td>
                                                        <td class="text-dark f-15">Other Websites</td>
                                                        <td class="">
                                                            23
                                                        </td>
                                                        <td class="">
                                                            36
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <div class="flag">
                                                                <img src="assets/img/line-chart.png"
                                                                style="width: 30px; height: 30px;"
                                                                alt="united states">
                                                            </div>
                                                        </td>
                                                        <td class="text-dark f-15">Print</td>
                                                        <td class="">
                                                            23
                                                        </td>
                                                        <td class="">
                                                            36
                                                        </td>
                                                    </tr>
                                                    
                                                <!-- <tr>
													<td>
														<div class="flag">
															<img src="assets/img/flags/br.png" alt="brazil">
														</div>
													</td>
													<td>Brasil</td>
													<td class="text-right">
														640
													</td>
													<td class="text-right">
														11.63%
													</td>
												</tr> -->
                                            </tbody>
                                        </table>
                                    </div>
                                </div>
                                <div class="col-lg-7 my-auto">
                                    <h4 class="card-title text-warning text-uppercase mx-4 mb-4">Overall Status
                                    </h4>
                                    <div id="chart-container">
                                        <canvas id="totalIncomeChart"></canvas>
                                    </div>
                                    
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <div class="row d-none">
            <div class="col-lg-6">
                <div class="card">
                    <div class="card-header">
                        <div class="card-title purple text-uppercase">Top Courses Enquired</div>
                    </div>
                    <div class="card-body pb-0">
                        <div class="row mx-0">
                            <div class="avatar mt-3">
                                <img src="assets/img/percentage.png" style="width: 30px; height: 30px;"
                                alt="..." class="avatar-img rounded-circle my-auto d-block">
                            </div>
                            <div class="w-50 my-auto ml-2">
                                <h6 class="fw-bold mb-1">Mechanical Engineering</h6>
                                <!-- <small class="text-muted">Cascading Style Sheets</small> -->
                            </div>
                            <div class="flex-1 my-auto">
                                <strong>110</strong>
                            </div>
                            <div class="d-flex ml-auto align-items-center">
                                <h3 class="text-info fw-bold">98%</h3>
                            </div>
                        </div>
                        <div class="separator-dashed"></div>
                        <div class="row mx-0">
                            <div class="avatar mt-3">
                                <img src="assets/img/percentage.png" style="width: 30px; height: 30px;"
                                alt="..." class="avatar-img rounded-circle my-auto d-block">
                            </div>
                            <div class="w-50 my-auto ml-2">
                                <h6 class="fw-bold mb-1">Civil Engineering</h6>
                                <!-- <small class="text-muted">The Best Donuts</small> -->
                            </div>
                            <div class="flex-1 my-auto">
                                <strong>78</strong>
                            </div>
                            <div class="d-flex ml-auto align-items-center">
                                <h3 class="text-info fw-bold">95%</h3>
                            </div>
                        </div>
                        <div class="separator-dashed"></div>
                        <div class="row mx-0">
                            <div class="avatar mt-3">
                                <img src="assets/img/percentage.png" style="width: 30px; height: 30px;"
                                alt="..." class="avatar-img rounded-circle my-auto d-block">
                            </div>
                            <div class="w-50 my-auto ml-2">
                                <h6 class="fw-bold mb-1">Aerospace Engineering</h6>
                                <!-- <small class="text-muted">Bootstrap 4 Admin Dashboard</small> -->
                            </div>
                            <div class="flex-1 my-auto">
                                <strong>90</strong>
                            </div>
                            <div class="d-flex ml-auto align-items-center">
                                <h3 class="text-info fw-bold">90%</h3>
                            </div>
                        </div>
                        <div class="separator-dashed"></div>
                        <div class="row mx-0">
                            <div class="avatar mt-3">
                                <img src="assets/img/percentage.png" style="width: 30px; height: 30px;"
                                alt="..." class="avatar-img rounded-circle my-auto d-block">
                            </div>
                            <div class="w-50 my-auto ml-2">
                                <h6 class="fw-bold mb-1">Aerospace Engineering</h6>
                                <!-- <small class="text-muted">Bootstrap 4 Admin Dashboard</small> -->
                            </div>
                            <div class="flex-1 my-auto">
                                <strong>90</strong>
                            </div>
                            <div class="d-flex ml-auto align-items-center">
                                <h3 class="text-info fw-bold">90%</h3>
                            </div>
                        </div>
                        <div class="separator-dashed"></div>
                        <div class="row mx-0">
                            <div class="avatar mt-3">
                                <img src="assets/img/percentage.png" style="width: 30px; height: 30px;"
                                alt="..." class="avatar-img rounded-circle my-auto d-block">
                            </div>
                            <div class="w-50 my-auto ml-2">
                                <h6 class="fw-bold mb-1">Aerospace Engineering</h6>
                                <!-- <small class="text-muted">Bootstrap 4 Admin Dashboard</small> -->
                            </div>
                            <div class="flex-1 my-auto">
                                <strong>90</strong>
                            </div>
                            <div class="d-flex ml-auto align-items-center">
                                <h3 class="text-info fw-bold">90%</h3>
                            </div>
                        </div>
                        <div class="pull-in" style="display: none;">
                            <canvas id="topProductsChart"></canvas>
                        </div>
                    </div>
                </div>
            </div>
            <div class="col-lg-6 d-none">
                <div class="card">
                    <div class="card-body" id="accordion">
                        <div class="card-title fw-mediumbold purple text-uppercase">Tele Team Performance
                        </div>
                        <div class="card-list">
                            <div class="">
                                <a data-toggle="collapse" href="#collapseOne" class="item-list">
                                    <div class="avatar">
                                        <img src="assets/img/jm_denis.jpg" alt="..."
                                        class="avatar-img rounded-circle">
                                    </div>
                                    <div class="info-user ml-3">
                                        <div class="username">Thamizhvanan</div>
                                        <!-- <div class="status">Graphic Designer</div> -->
                                    </div>
                                    <button class="btn btn-icon btn-primary btn-round btn-xs">

                                        <i class="fa fa-plus text-white"></i>
                                    </button>
                                </a>
                            </div>
                            <div id="collapseOne" class="collapse" data-parent="#accordion">
                                <div class="card-body tele-team-acc pt-1 pb-0 px-1">
                                    <div class="d-md-flex justify-content-between">
                                        <h6 class="font-weight-bold text-center mb-0 text-uppercase mt-1">
                                        Overall:</h6>
                                        <p class="text-muted font-weight-bold">
                                            <strong class="text-danger"> Leads Handled :</strong> 8223232
                                            &nbsp;|&nbsp; <strong class="text-danger">Active :</strong> 103
                                            &nbsp;|&nbsp; <strong class="text-danger">Admitted :</strong> 80
                                            &nbsp;|&nbsp; <strong class="text-danger">Dropped :</strong>10
                                        </p>
                                    </div>
                                    <div class="d-md-flex justify-content-between">
                                        <h6 class="font-weight-bold text-center mb-0 text-uppercase mt-1">
                                        Today:</h6>
                                        <p class="text-muted font-weight-bold">
                                            <strong class="text-danger"> Leads Handled :</strong> 8
                                            &nbsp;|&nbsp; <strong class="text-danger">Active :</strong> 103
                                            &nbsp;|&nbsp; <strong class="text-danger">Admitted :</strong> 80
                                            &nbsp;|&nbsp; <strong class="text-danger">Dropped :</strong>10
                                        </p>
                                    </div>
                                </div>
                            </div>
                            <div>
                                <a data-toggle="collapse" href="#collapseTwo" class="item-list">
                                    <div class="avatar">
                                        <img src="assets/img/chadengle.jpg" alt="..."
                                        class="avatar-img rounded-circle">
                                    </div>
                                    <div class="info-user ml-3">
                                        <div class="username">Ramesh</div>
                                        <!-- <div class="status">CEO Zeleaf</div> -->
                                    </div>
                                    <button class="btn btn-icon btn-primary btn-round btn-xs">
                                        <i class="fa fa-plus text-white"></i>
                                    </button>
                                </a>
                            </div>
                            <div id="collapseTwo" class="collapse" data-parent="#accordion">
                                <div class="card-body tele-team-acc pt-1 pb-0 px-1">
                                    <div class="d-md-flex justify-content-between">
                                        <h6 class="font-weight-bold text-center mb-0 text-uppercase mt-1">
                                        Overall:</h6>
                                        <p class="text-muted font-weight-bold">
                                            <strong class="text-danger"> Leads Handled :</strong> 8223232
                                            &nbsp;|&nbsp; <strong class="text-danger">Active :</strong> 103
                                            &nbsp;|&nbsp; <strong class="text-danger">Admitted:</strong> 80
                                            &nbsp;|&nbsp; <strong class="text-danger">Dropped :</strong>10
                                        </p>
                                    </div>
                                    <div class="d-md-flex justify-content-between">
                                        <h6 class="font-weight-bold text-center mb-0 text-uppercase mt-1">
                                        Today:</h6>
                                        <p class="text-muted font-weight-bold">
                                            <strong class="text-danger"> Leads Handled :</strong> 8
                                            &nbsp;|&nbsp; <strong class="text-danger">Active :</strong> 103
                                            &nbsp;|&nbsp; <strong class="text-danger">Admitted :</strong> 80
                                            &nbsp;|&nbsp; <strong class="text-danger">Dropped :</strong>10
                                        </p>
                                    </div>
                                </div>
                            </div>
                            <div>
                                <a data-toggle="collapse" href="#collapseThree" class="item-list">
                                    <div class="avatar">
                                        <img src="assets/img/talha.jpg" alt="..."
                                        class="avatar-img rounded-circle">
                                    </div>
                                    <div class="info-user ml-3">
                                        <div class="username">Lakshmi</div>
                                        <!-- <div class="status">Front End Designer</div> -->
                                    </div>
                                    <button class="btn btn-icon btn-primary btn-round btn-xs">
                                        <i class="fa fa-plus text-white"></i>
                                    </button>
                                </a>
                            </div>
                            <div id="collapseThree" class="collapse" data-parent="#accordion">
                                <div class="card-body tele-team-acc pt-1 pb-0 px-1">
                                    <div class="d-md-flex justify-content-between">
                                        <h6 class="font-weight-bold text-center mb-0 text-uppercase mt-1">
                                        Overall:</h6>
                                        <p class="text-muted font-weight-bold">
                                            <strong class="text-danger"> Leads Handled :</strong> 8223232
                                            &nbsp;|&nbsp; <strong class="text-danger">Active :</strong> 103
                                            &nbsp;|&nbsp; <strong class="text-danger">Admitted :</strong> 80
                                            &nbsp;|&nbsp; <strong class="text-danger">Dropped :</strong>10
                                        </p>
                                    </div>
                                    <div class="d-md-flex justify-content-between">
                                        <h6 class="font-weight-bold text-center mb-0 text-uppercase mt-1">
                                        Today:</h6>
                                        <p class="text-muted font-weight-bold">
                                            <strong class="text-danger"> Leads Handled :</strong> 8
                                            &nbsp;|&nbsp; <strong class="text-danger">Active :</strong> 103
                                            &nbsp;|&nbsp; <strong class="text-danger">Admitted :</strong> 80
                                            &nbsp;|&nbsp; <strong class="text-danger">Dropped :</strong>10
                                        </p>
                                    </div>
                                </div>
                            </div>
                            <div>
                                <a data-toggle="collapse" href="#collapseFour" class="item-list">
                                    <div class="avatar">
                                        <img src="assets/img/mlane.jpg" alt="..."
                                        class="avatar-img rounded-circle">
                                    </div>
                                    <div class="info-user ml-3">
                                        <div class="username">Nithya</div>
                                        <!-- <div class="status">Back End Developer</div> -->
                                    </div>
                                    <button class="btn btn-icon btn-primary btn-round btn-xs">
                                        <i class="fa fa-plus text-white"></i>
                                    </button>
                                </a>
                            </div>
                            <div id="collapseFour" class="collapse" data-parent="#accordion">
                                <div class="card-body tele-team-acc pt-1 pb-0 px-1">
                                    <div class="d-md-flex justify-content-between">
                                        <h6 class="font-weight-bold text-center mb-0 text-uppercase mt-1">
                                        Overall:</h6>
                                        <p class="text-muted font-weight-bold">
                                            <strong class="text-danger"> Leads Handled :</strong> 8223232
                                            &nbsp;|&nbsp; <strong class="text-danger">Active :</strong> 103
                                            &nbsp;|&nbsp; <strong class="text-danger">Admitted :</strong> 80
                                            &nbsp;|&nbsp; <strong class="text-danger">Dropped :</strong>10
                                        </p>
                                    </div>
                                    <div class="d-md-flex justify-content-between">
                                        <h6 class="font-weight-bold text-center mb-0 text-uppercase mt-1">
                                        Today:</h6>
                                        <p class="text-muted font-weight-bold">
                                            <strong class="text-danger"> Leads Handled :</strong> 8
                                            &nbsp;|&nbsp; <strong class="text-danger">Active :</strong> 103
                                            &nbsp;|&nbsp; <strong class="text-danger">Admitted :</strong> 80
                                            &nbsp;|&nbsp; <strong class="text-danger">Dropped :</strong>10
                                        </p>
                                    </div>
                                </div>
                            </div>
                            <div>
                                <a data-toggle="collapse" href="#collapseFive" class="item-list">
                                    <div class="avatar">
                                        <img src="assets/img/talha.jpg" alt="..."
                                        class="avatar-img rounded-circle">
                                    </div>
                                    <div class="info-user ml-3">
                                        <div class="username">Suresh</div>
                                        <!-- <div class="status">Front End Designer</div> -->
                                    </div>
                                    <button class="btn btn-icon btn-primary btn-round btn-xs">
                                        <i class="fa fa-plus text-white"></i>
                                    </button>
                                </a>
                            </div>
                            <div id="collapseFive" class="collapse" data-parent="#accordion">
                                <div class="card-body tele-team-acc pt-1 pb-0 px-1">
                                    <div class="d-md-flex justify-content-between">
                                        <h6 class="font-weight-bold text-center mb-0 text-uppercase mt-1">
                                        Overall:</h6>
                                        <p class="text-muted font-weight-bold">
                                            <strong class="text-danger"> Leads Handled :</strong> 8223232
                                            &nbsp;|&nbsp; <strong class="text-danger">Active :</strong> 103
                                            &nbsp;|&nbsp; <strong class="text-danger">Admitted :</strong> 80
                                            &nbsp;|&nbsp; <strong class="text-danger">Dropped :</strong>10
                                        </p>
                                    </div>
                                    <div class="d-md-flex justify-content-between">
                                        <h6 class="font-weight-bold text-center mb-0 text-uppercase mt-1">
                                        Today:</h6>
                                        <p class="text-muted font-weight-bold">
                                            <strong class="text-danger"> Leads Handled :</strong> 8
                                            &nbsp;|&nbsp; <strong class="text-danger">Active :</strong> 103
                                            &nbsp;|&nbsp; <strong class="text-danger">Admitted :</strong> 80
                                            &nbsp;|&nbsp; <strong class="text-danger">Dropped :</strong>10
                                        </p>
                                    </div>
                                </div>
                            </div>
                            <div>
                                <a data-toggle="collapse" href="#collapseSix" class="item-list">
                                    <div class="avatar">
                                        <img src="assets/img/jm_denis.jpg" alt="..."
                                        class="avatar-img rounded-circle">
                                    </div>
                                    <div class="info-user ml-3">
                                        <div class="username">Thomas</div>
                                        <!-- <div class="status">Graphic Designer</div> -->
                                    </div>
                                    <button class="btn btn-icon btn-primary btn-round btn-xs">
                                        <i class="fa fa-plus text-white"></i>
                                    </button>
                                </a>
                            </div>
                            <div id="collapseSix" class="collapse" data-parent="#accordion">
                                <div class="card-body tele-team-acc pt-1 pb-0 px-1">
                                    <div class="d-md-flex justify-content-between">
                                        <h6 class="font-weight-bold text-center mb-0 text-uppercase mt-1">
                                        Overall:</h6>
                                        <p class="text-muted font-weight-bold">
                                            <strong class="text-danger"> Leads Handled :</strong> 8223232
                                            &nbsp;|&nbsp; <strong class="text-danger">Active :</strong> 103
                                            &nbsp;|&nbsp; <strong class="text-danger">Admitted :</strong> 80
                                            &nbsp;|&nbsp; <strong class="text-danger">Dropped :</strong>10
                                        </p>
                                    </div>
                                    <div class="d-md-flex justify-content-between">
                                        <h6 class="font-weight-bold text-center mb-0 text-uppercase mt-1">
                                        Today:</h6>
                                        <p class="text-muted font-weight-bold">
                                            <strong class="text-danger"> Leads Handled :</strong> 8
                                            &nbsp;|&nbsp; <strong class="text-danger">Active :</strong> 103
                                            &nbsp;|&nbsp; <strong class="text-danger">Admitted :</strong> 80
                                            &nbsp;|&nbsp; <strong class="text-danger">Dropped :</strong>10
                                        </p>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>

    </div>
</div>
<footer class="footer">
    <div class="container-fluid">
        <nav class="pull-left">
            &copy;
            <script type="text/javascript">
                var today = new Date()
                var year = today.getFullYear()
                document.write(year)
            </script>
        </nav>
        <div class="copyright ml-auto">
            Powered by <a class="text-uppercase" href="https://duffldigital.com/" target="_blank">Duffl
            Digital</a>
        </div>
    </div>
</footer>

    <!-- Chart JS -->
<script src="assets/js/plugin/chart.js/chart.min.js"></script>
      
<!-- Chart Circle -->
<script src="assets/js/plugin/chart-circle/circles.min.js"></script>

 
<!-- Atlantis DEMO methods, don't include it in your project! --> 
<script src="assets/js/demo.js"></script>
    <script>
        $("#accordion").on("hide.bs.collapse show.bs.collapse", e => {
            $(e.target)
                .prev()
                .find("i:last-child")
                .toggleClass("fa-minus fa-plus");
        });
</script>
<script>
    Circles.create({
        id: 'circles-1',
        radius: 45,
        value: 60,
        maxValue: 100,
        width: 7,
        text: 5,
        colors: ['#f1f1f1', '#FF9E27'],
        duration: 400,
        wrpClass: 'circles-wrp',
        textClass: 'circles-text',
        styleWrapper: true,
        styleText: true
    })

    Circles.create({
        id: 'circles-2',
        radius: 45,
        value: 70,
        maxValue: 100,
        width: 7,
        text: 36,
        colors: ['#f1f1f1', '#2BB930'],
        duration: 400,
        wrpClass: 'circles-wrp',
        textClass: 'circles-text',
        styleWrapper: true,
        styleText: true
    })

    Circles.create({
        id: 'circles-3',
        radius: 45,
        value: 40,
        maxValue: 100,
        width: 7,
        text: 12,
        colors: ['#f1f1f1', '#48abf7'],
        duration: 400,
        wrpClass: 'circles-wrp',
        textClass: 'circles-text',
        styleWrapper: true,
        styleText: true
    })

    Circles.create({
        id: 'circles-4',
        radius: 45,
        value: 40,
        maxValue: 100,
        width: 7,
        text: 8,
        colors: ['#f1f1f1', '#F25961'],
        duration: 400,
        wrpClass: 'circles-wrp',
        textClass: 'circles-text',
        styleWrapper: true,
        styleText: true
    })

    Circles.create({
        id: 'circles-11',
        radius: 45,
        value: 60,
        maxValue: 100,
        width: 7,
        text: 2,
        colors: ['#f1f1f1', '#FF9E27'],
        duration: 400,
        wrpClass: 'circles-wrp',
        textClass: 'circles-text',
        styleWrapper: true,
        styleText: true
    })

    Circles.create({
        id: 'circles-22',
        radius: 45,
        value: 70,
        maxValue: 100,
        width: 7,
        text: 6,
        colors: ['#f1f1f1', '#2BB930'],
        duration: 400,
        wrpClass: 'circles-wrp',
        textClass: 'circles-text',
        styleWrapper: true,
        styleText: true
    })

    Circles.create({
        id: 'circles-33',
        radius: 45,
        value: 40,
        maxValue: 100,
        width: 7,
        text: 4,
        colors: ['#f1f1f1', '#48abf7'],
        duration: 400,
        wrpClass: 'circles-wrp',
        textClass: 'circles-text',
        styleWrapper: true,
        styleText: true
    })

    Circles.create({
        id: 'circles-44',
        radius: 45,
        value: 40,
        maxValue: 100,
        width: 7,
        text: 1,
        colors: ['#f1f1f1', '#F25961'],
        duration: 400,
        wrpClass: 'circles-wrp',
        textClass: 'circles-text',
        styleWrapper: true,
        styleText: true
    })

    Circles.create({
        id: 'circles-5',
        radius: 45,
        value: 40,
        maxValue: 100,
        width: 7,
        text: 12,
        colors: ['#f1f1f1', '#F25961'],
        duration: 400,
        wrpClass: 'circles-wrp',
        textClass: 'circles-text',
        styleWrapper: true,
        styleText: true
    })


    var totalIncomeChart = document.getElementById('totalIncomeChart').getContext('2d');

    var mytotalIncomeChart = new Chart(totalIncomeChart, {
        type: 'bar',
        data: {
            labels: ["Facebook", "Instagram", "Google Ads", "Other Websites", "Print"],
            datasets: [{
                label: "Source of Leads",
                backgroundColor: '#ff9e27',
                borderColor: 'rgb(23, 125, 255)',
                data: [220, 230, 119, 181, 100, 60, 40, 30],
            }],
        },
        options: {
            responsive: true,
            maintainAspectRatio: false,
            legend: {
                display: false,
            },
            scales: {
                yAxes: [{
                    ticks: {
                        display: false //this will remove only the label
                    },
                    gridLines: {
                        drawBorder: false,
                        display: false
                    }
                }],
                xAxes: [{
                    gridLines: {
                        drawBorder: false,
                        display: false
                    }
                }]
            },
        }
    });

 
    </script>


</asp:Content>

