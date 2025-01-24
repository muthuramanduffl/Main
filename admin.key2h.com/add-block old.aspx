<%@ Page Language="C#" AutoEventWireup="true" CodeFile="add-block.aspx.cs" Inherits="admin_add_block" %>

<!DOCTYPE html>
<html lang="en">

<head runat="server">
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <title>Admin Dashboard | KEY2H</title>
    <meta content='width=device-width, initial-scale=1.0, shrink-to-fit=no' name='viewport' />
    <link rel="icon" href="assets/img/fav-icon.png" type="image/x-icon" />

    <!-- Fonts and icons -->
    <script src="assets/js/plugin/webfont/webfont.min.js"></script>
    <script>
        WebFont.load({
            google: { "families": ["Lato:300,400,700,900"] },
            custom: { "families": ["Flaticon", "Font Awesome 5 Solid", "Font Awesome 5 Regular", "Font Awesome 5 Brands", "simple-line-icons"], urls: ['assets/css/fonts.min.css'] },
            active: function () {
                sessionStorage.fonts = true;
            }
        });
    </script>

    <!-- FontAwesome (for icons) -->
    <link href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/4.7.0/css/font-awesome.min.css" rel="stylesheet">

    <!-- CSS Files -->
    <link rel="stylesheet" href="assets/css/bootstrap.min.css">
    <link rel="stylesheet" href="assets/css/atlantis.min.css">
    <link rel="stylesheet" href="assets/bootstrap-icons/bootstrap-icons.css">
    <link rel="stylesheet" href="assets/css/demo.css">
</head>
<body>
    <form id="form1" runat="server">

        <div class="wrapper sidebar_minimize">
            <div class="main-header">

                <!-- Navbar Header -->
                <nav class="navbar navbar-header navbar-expand-lg" data-background-color="white">

                    <div class="container-fluid">
                        <div>

                            <a href="dashboard.html" class="logo">
                                <img src="assets/img/logo.png" width="150" alt="navbar brand" class="navbar-brand">
                            </a>
                        </div>
                        <div class="collapse" id="search-nav">
                        </div>
                        <ul class="navbar-nav topbar-nav ml-md-auto align-items-center">
                            <li class="nav-item toggle-nav-search hidden-caret">
                                <a class="nav-link" data-toggle="collapse" href="#search-nav" role="button"
                                    aria-expanded="false" aria-controls="search-nav">
                                    <i class="fa fa-search"></i>
                                </a>
                            </li>

                            <li class="nav-item dropdown hidden-caret">
                                <a class="nav-link dropdown-toggle" href="#" id="notifDropdown" role="button"
                                    data-bs-toggle="dropdown" aria-expanded="false">
                                    <i class="fa fa-bell"></i>
                                    <span class="notification">3</span>
                                </a>
                                <ul class="dropdown-menu notif-box animated fadeIn" aria-labelledby="notifDropdown">
                                    <li>
                                        <div class="dropdown-title">You have 3 new notification</div>
                                    </li>
                                    <li>
                                        <div class="notif-scroll scrollbar-outer">
                                            <div class="notif-center">
                                                <a href="#">
                                                    <div class="notif-icon notif-primary">
                                                        <i class="fa fa-user"></i>
                                                    </div>
                                                    <div class="notif-content">
                                                        <span class="block">2 Follow-ups have been closed
                                                        </span>
                                                        <span class="time">5 minutes ago</span>
                                                    </div>
                                                </a>
                                                <a href="#">
                                                    <div class="notif-icon notif-primary"><i class="fa fa-user"></i></div>
                                                    <div class="notif-content">
                                                        <span class="block">4 New leads have been received
                                                        </span>
                                                        <span class="time">12 minutes ago</span>
                                                    </div>
                                                </a>
                                                <a href="#">
                                                    <div class="notif-icon notif-primary"><i class="fa fa-user"></i></div>

                                                    <div class="notif-content">
                                                        <span class="block">A lead status has been updated
                                                        </span>
                                                        <span class="time">12 minutes ago</span>
                                                    </div>
                                                </a>
                                            </div>
                                        </div>
                                    </li>
                                </ul>
                            </li>

                            <li class="nav-item dropdown hidden-caret">
                                <a class="dropdown-toggle profile-pic" data-bs-toggle="dropdown" href="#" aria-expanded="false">
                                    <div class="avatar-sm">
                                        <i class="fa fa-user"></i>
                                    </div>
                                </a>
                                <ul class="dropdown-user dropdown-menu dropdown-menu-end animated fadeIn">
                                    <div class="dropdown-user-scroll scrollbar-outer">
                                        <li>
                                            <div class="user-box">
                                                <div class="avatar-lg">
                                                    <img src="assets/img/user.png" alt="image profile"
                                                        class="avatar-img rounded">
                                                </div>
                                                <div class="u-text">
                                                    <h4>XXXXX</h4>
                                                    <p class="text-muted">xxxx@gmail.com</p>
                                                </div>
                                            </div>
                                        </li>
                                        <li>
                                            <div class="dropdown-divider"></div>
                                            <a class="dropdown-item text-center" href="#">Logout</a>
                                        </li>
                                    </div>
                                </ul>
                            </li>
                        </ul>
                    </div>
                </nav>
                <!-- End Navbar -->
                <div id="dvadminmenu" class="menu-1" style="display: block;">
                    <div class="menu-tab nav nav-tabs">
                        <li class="nav-item">
                            <a class="nav-link " data-bs-toggle="tab" href="#tab-1">
                                <i class="fa fa-home" aria-hidden="true"></i>Projects
                            </a>
                        </li>
                        <li class="nav-item submenu">
                            <a class="nav-link active " data-bs-toggle="tab" href="#tab-2">
                                <i class="fa fa-users" aria-hidden="true"></i>Blocks
                            </a>
                        </li>
                        <li class="nav-item">
                            <a class="nav-link" data-bs-toggle="tab" href="#tab-3">
                                <i class="fa fa-building-o" aria-hidden="true"></i>Flats
                            </a>
                        </li>
                        <li class="nav-item">
                            <a class="nav-link" data-bs-toggle="tab" href="#tab-4">
                                <i class="fa fa-money" aria-hidden="true"></i>Customers
                            </a>
                        </li>
                        <li class="nav-item">
                            <a class="nav-link" data-bs-toggle="tab" href="#tab-5">
                                <i class="fa fa-bar-chart" aria-hidden="true"></i>Flat Customization
                            </a>
                        </li>
                        <li class="nav-item">
                            <a class="nav-link" data-bs-toggle="tab" href="#tab-6">
                                <i class="fa fa-line-chart" aria-hidden="true"></i>Reports
                            </a>
                        </li>
                    </div>

                    <div class="tab-content">
                        <div class="tab-pane fade" id="tab-1">
                            <!-- Content for Tab 1 -->
                            <ul class="sub-menu">
                                <li>
                                    <a href="add-project.html">
                                        <i class="fa fa-line-chart" aria-hidden="true"></i>
                                        Add Projects
                                    </a>
                                </li>
                                <li>
                                    <a href="view-project.html">
                                        <i class="fa fa-line-chart" aria-hidden="true"></i>
                                        View Projects
                                    </a>
                                </li>
                            </ul>
                        </div>
                        <div class="tab-pane fade show active" id="tab-2">
                            <ul class="sub-menu">
                                <li>
                                    <a href="add-block.html">
                                        <i class="fa fa-line-chart" aria-hidden="true"></i>
                                        Add Blocks
                                    </a>
                                </li>
                                <li>
                                    <a href="view-block.html">
                                        <i class="fa fa-line-chart" aria-hidden="true"></i>
                                        View Blocks
                                    </a>
                                </li>
                            </ul>
                        </div>
                        <div class="tab-pane fade" id="tab-3">
                            <ul class="sub-menu">
                                <li>
                                    <a href="add-flat.html">
                                        <i class="fa fa-line-chart" aria-hidden="true"></i>
                                        Add Flats
                                    </a>
                                </li>
                                <li>
                                    <a href="view-flat.html">
                                        <i class="fa fa-line-chart" aria-hidden="true"></i>
                                        View Flats
                                    </a>

                                </li>
                            </ul>
                        </div>
                        <div class="tab-pane fade" id="tab-4">
                            <ul class="sub-menu">
                                <li>
                                    <a href="add-customer.html">
                                        <i class="fa fa-line-chart" aria-hidden="true"></i>
                                        Add Customers
                                    </a>
                                </li>
                                <li>
                                    <a href="view-customer.html">
                                        <i class="fa fa-line-chart" aria-hidden="true"></i>
                                        View Customers
                                    </a>
                                </li>
                            </ul>
                        </div>
                        <div class="tab-pane fade" id="tab-5">
                            <ul class="sub-menu">
                                <li>
                                    <a href="">
                                        <i class="fa fa-line-chart" aria-hidden="true"></i>
                                        Add Flat
                                    </a>
                                </li>
                            </ul>
                        </div>
                        <div class="tab-pane fade" id="tab-6">
                            <ul class="sub-menu">
                                <li>
                                    <a href="">
                                        <i class="fa fa-line-chart" aria-hidden="true"></i>
                                        Add Report
                                    </a>
                                </li>
                            </ul>
                        </div>
                    </div>

                </div>
            </div>


            <div class="main-panel">
                <div class="content">
                    <div class="panel-header bg-primary-gradient">
                        <div class="page-inner py-5">
                            <div class="d-flex pb-2 align-items-left align-items-md-center flex-column flex-md-row justify-content-between">
                                <div class="d-flex">
                                    <h2 class="text-white mb-0 fw-bold text-uppercase">Add Blocks</h2>
                                    <ul class="breadcrumbs">
                                        <li class="nav-home pt-1">
                                            <a href="dashboard.html">
                                                <i class="fa fa-home"></i>
                                            </a>
                                        </li>
                                    </ul>
                                </div>
                                <div>
                                    <a href="view-block.html" data-bs-toggle="tooltip" title="View page">
                                        <img class="add-view-img" src="data:image/svg+xml;base64,PHN2ZyB4bWxucz0iaHR0cDovL3d3dy53My5vcmcvMjAwMC9zdmciIHZlcnNpb249IjEuMSIgeG1sbnM6eGxpbms9Imh0dHA6Ly93d3cudzMub3JnLzE5OTkveGxpbmsiIHdpZHRoPSI1MTIiIGhlaWdodD0iNTEyIiB4PSIwIiB5PSIwIiB2aWV3Qm94PSIwIDAgMzIgMzIiIHN0eWxlPSJlbmFibGUtYmFja2dyb3VuZDpuZXcgMCAwIDUxMiA1MTIiIHhtbDpzcGFjZT0icHJlc2VydmUiIGNsYXNzPSIiPjxnPjxnIGZpbGw9IiM2NjIxYmEiPjxwYXRoIGQ9Ik0yNS41MyAyMS41MzVhLjkuOSAwIDAgMC0uOS45di41NGMwIC42MDYtLjQ5NCAxLjEtMS4xIDEuMUg4LjE1Yy0uNjA2IDAtMS4xLS40OTQtMS4xLTEuMXYtMTguMWMwLS42MDYuNDk0LTEuMSAxLjEtMS4xaDE1LjM4Yy42MDYgMCAxLjEuNDk0IDEuMSAxLjF2Mi44YS45LjkgMCAwIDAgMS44IDB2LTIuOGMwLTEuNTk5LTEuMzAxLTIuOS0yLjktMi45SDguMTVhMi45MDMgMi45MDMgMCAwIDAtMi45IDIuOXYxLjI0NEg0YTIuOTAzIDIuOTAzIDAgMCAwLTIuOSAyLjl2MTguMTA2YzAgMS41OTkgMS4zMDEgMi45IDIuOSAyLjloMTUuMzc4YzEuNTk5IDAgMi45LTEuMzAxIDIuOS0yLjl2LTEuMjVoMS4yNTJjMS41OTkgMCAyLjktMS4zMDEgMi45LTIuOXYtLjU0YS45LjkgMCAwIDAtLjktLjl6bS01LjA1MiA1LjU5YzAgLjYwNi0uNDk0IDEuMS0xLjEgMS4xSDRjLS42MDYgMC0xLjEtLjQ5NC0xLjEtMS4xVjkuMDE5YzAtLjYwNi40OTQtMS4xIDEuMS0xLjFoMS4yNXYxNS4wNTdjMCAxLjU5OSAxLjMwMSAyLjkgMi45IDIuOWgxMi4zMjh6IiBmaWxsPSIjNjYyMWJhIiBvcGFjaXR5PSIxIiBkYXRhLW9yaWdpbmFsPSIjNjYyMWJhIiBjbGFzcz0iIj48L3BhdGg+PHBhdGggZD0iTTEzLjUgNy41ODFoLTIuMzQzYS45LjkgMCAwIDAgMCAxLjhIMTMuNWEuOS45IDAgMCAwIDAtMS44ek0xOC42NCAxMi4xMTVhLjkuOSAwIDAgMC0uOS0uOWgtNi41OGEuOS45IDAgMCAwIDAgMS44aDYuNThhLjkuOSAwIDAgMCAuOS0uOXpNMTEuMTYgMTQuODQ1YS45LjkgMCAwIDAgMCAxLjhoNmEuOS45IDAgMCAwIDAtMS44ek0xMS4xNiAyMC4yNzVoNy4zNmEuOS45IDAgMCAwIDAtMS44aC03LjM2YS45LjkgMCAwIDAgMCAxLjh6IiBmaWxsPSIjNjYyMWJhIiBvcGFjaXR5PSIxIiBkYXRhLW9yaWdpbmFsPSIjNjYyMWJhIiBjbGFzcz0iIj48L3BhdGg+PC9nPjxwYXRoIGZpbGw9IiNmOThhMTciIGQ9Im0zMC42MzYgMTkuODM5LTIuMDU1LTIuMDU1YzEuMjg5LTEuODg4IDEuMTAzLTQuNDg5LS41NzItNi4xNjNhNC44NiA0Ljg2IDAgMCAwLTYuODY0IDAgNC44NTkgNC44NTkgMCAwIDAgMCA2Ljg2MyA0Ljg0OCA0Ljg0OCAwIDAgMCA2LjE2My41NzJsMi4wNTQgMi4wNTRhLjg5Ny44OTcgMCAwIDAgMS4yNzIgMCAuODk1Ljg5NSAwIDAgMCAuMDAyLTEuMjcxem0tOC4yMTctMi42MjdhMy4wNTggMy4wNTggMCAwIDEgMC00LjMxOGMuNTk1LS41OTUgMS4zNzctLjg5MyAyLjE1OS0uODkzczEuNTY0LjI5OCAyLjE1OS44OTNhMy4wNTggMy4wNTggMCAwIDEgMCA0LjMxOGMtMS4xNTMgMS4xNTQtMy4xNjUgMS4xNTQtNC4zMTggMHoiIG9wYWNpdHk9IjEiIGRhdGEtb3JpZ2luYWw9IiNmOThhMTciIGNsYXNzPSIiPjwvcGF0aD48L2c+PC9zdmc+" />
                                    </a>
                                </div>


                            </div>
                        </div>
                    </div>
                    <div class="page-inner mt--5">
                        <div class="row">
                            <div class="col-md-12">
                                <div class="card">
                                    <div class="card-body">

                                        <div class="form-group">
                                            <div class="form-border margin-top20">
                                                <div class="form-title">
                                                    <h3>Block Details</h3>
                                                </div>
                                                <div class="row mx-0 margin-top20 mb-4">
                                                    <div class="col-md-4 pt-3">
                                                        <div class="input-icon input-icon-sm right">
                                                            <label>Project Name <span class="text-danger">*</span></label>
                                                            <i class="bi bi-journal-bookmark-fill b5-icon"></i>
                                                            <asp:DropDownList ID="ddlProName" class="bs-select form-control input-sm" runat="server">
                                                                <asp:ListItem Value=""></asp:ListItem>
                                                                <asp:ListItem Value="Project 1">Project 1</asp:ListItem>
                                                                <asp:ListItem Value="Project 2">Project 2</asp:ListItem>
                                                                <asp:ListItem Value="Project 3">Project 3</asp:ListItem>
                                                            </asp:DropDownList>
                                                        </div>
                                                        <span class="error">
                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ValidationGroup="projval"
                                                                ControlToValidate="ddlProName" InitialValue="" ErrorMessage="Select project name">
                                                            </asp:RequiredFieldValidator>
                                                        </span>
                                                    </div>
                                                    <div class="col-md-4 pt-3">
                                                        <div class="input-icon input-icon-sm right">
                                                            <label>Block Number <span class="text-danger">*</span></label>
                                                            <i class="bi bi-building b5-icon"></i>
                                                            <asp:TextBox ID="txtBlockNumber" onkeypress="return isAlphaNumeric(event)"
                                                                oninput="removeInvalidCharacters(this)" class="form-control input-sm " MaxLength="5" autocomplete="off" runat="server"></asp:TextBox>
                                                        </div>
                                                        <span class="error text-danger" id="errorMessage" style="display: none;">Enter at least one letter and one number</span>
                                                        <span class="error">
                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ValidationGroup="projval"
                                                                ControlToValidate="txtBlockNumber" ErrorMessage="Enter block no">
                                                            </asp:RequiredFieldValidator>
                                                        </span>
                                                        <span class="errorMessage error" style="display: none;">Please include at least one letter and one number.</span>
                                                    </div>


                                                </div>
                                            </div>
                                        </div>


                                    </div>
                                    <div class="card-footer">
                                        <div class="d-flex justify-content-end">
                                            <asp:Button
                                                ID="btnSave"
                                                runat="server" OnClick="btnSave_Click"
                                                Text="Submit" ValidationGroup="projval"
                                                class="btn btn-sm btn-success me-1 "
                                                OnClientClick="if (validatePage()) { this.value='Please wait..'; this.style.display='none'; document.getElementById('bWait').style.display = ''; } else { return false; }" />


                                            <button type="button" style="display: none" id="bWait" class="btn btn-secondary btn-sm me-1"><i class='fa fa-spinner fa-spin'></i>Please wait</button>

                                            <asp:Button
                                                ID="btnCancel" OnClientClick="showCancelConfirmation(); return false;"
                                                runat="server"
                                                Text="Cancel"
                                                class="btn btn-sm btn-danger" />
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
            </div>

            <div class="back-to-top" style="display: none;">
                <a href="#" data-bs-toggle="tooltip" title="Back to Top">
                    <img src="assets/img/back-to-top.png" class="w-50 px-1 d-flex mx-auto">
                </a>
            </div>


        </div>
        <!--   Core JS Files   -->
        <script src="assets/js/core/jquery.3.2.1.min.js"></script>
        <script src="assets/js/core/bootstrap.min.js"></script>
        <!-- Sweet Alert -->
        <script src="assets/js/plugin/sweetalert/sweetalert.min.js"></script>
        <script> 
            function validatePage() {
                var flag = window.Page_ClientValidate('projval');
                return flag;
            }
            function isAlphaNumeric(event) {
                var charCode = event.which ? event.which : event.keyCode;

                // Allow letters (A-Z, a-z) and numbers (0-9)
                if (
                    (charCode >= 48 && charCode <= 57) || // 0-9
                    (charCode >= 65 && charCode <= 90) || // A-Z
                    (charCode >= 97 && charCode <= 122)   // a-z
                ) {
                    return true; // Valid input
                }

                return false; // Block special characters
            }
            function removeInvalidCharacters(input) {
                // Replace any non-alphanumeric characters
                input.value = input.value.replace(/[^a-zA-Z0-9]/g, '');
            }
            //function validateAlphanumeric(input) {
            //    var value = input.value.trim(); // Get and trim the input value

            //    // Check for at least one letter and one number
            //    var hasLetter = /[a-zA-Z]/.test(value); // Matches any letter (a-z, A-Z)
            //    var hasNumber = /[0-9]/.test(value);    // Matches any number (0-9)

            //    var errorMessage = document.getElementById('errorMessage');

            //    if (hasLetter && hasNumber) {
            //        errorMessage.style.display = 'none'; // Hide error message if valid
            //        return true; // Validation passed
            //    } else {
            //        errorMessage.style.display = 'block'; // Show error message if invalid
            //        input.focus(); // Focus the input field
            //        return false; // Validation failed
            //    }
            //}
        </script>
        <script>


            //-- menu
            function updateNavBackground() {
                document.querySelectorAll('.menu-tab .nav-item').forEach(item => {
                    const link = item.querySelector('.nav-link');
                    if (link.classList.contains('active')) {
                        item.style.backgroundColor = '#2b2e32'; // Apply background for active
                    } else {
                        item.style.backgroundColor = 'transparent'; // Reset background for inactive
                    }
                });
            }

            // Run function when tab is clicked
            document.querySelectorAll('.menu-tab .nav-link').forEach(link => {
                link.addEventListener('shown.bs.tab', updateNavBackground); // Bootstrap tab event
            });

            // Initial run to set correct background
            updateNavBackground();
            //--// menu

            //-- tooltips Back to Top button
            document.addEventListener("DOMContentLoaded", function () {
                const tooltipTriggerList = [].slice.call(document.querySelectorAll('[data-bs-toggle="tooltip"]'));
                tooltipTriggerList.forEach(function (tooltipTriggerEl) {
                    new bootstrap.Tooltip(tooltipTriggerEl);
                });
            });

            document.addEventListener("scroll", function () {
                const backToTop = document.querySelector(".back-to-top");
                if (window.scrollY > 1000) {
                    backToTop.style.display = "block";
                } else {
                    backToTop.style.display = "none";
                }
            });

            document.querySelector(".back-to-top a").addEventListener("click", function (event) {
                event.preventDefault();
                window.scrollTo({ top: 0, behavior: "smooth" });
            });
            //--// tooltips Back to Top button


            //-- Select the Cancel button with the onclick 'showCancelConfirmation'
            function showCancelConfirmation() {
                Swal.fire({
                    title: 'Are you sure?',
                    text: 'Do you want to cancel and discard the changes?',
                    icon: 'warning',
                    showCancelButton: true,
                    confirmButtonColor: '#d33',
                    cancelButtonColor: '#3085d6',
                    confirmButtonText: 'Yes, cancel it!',
                    cancelButtonText: 'No, keep working'
                }).then((result) => {
                    if (result.isConfirmed) {
                        // Clear form fields
                        document.getElementById('<%= ddlProName.ClientID %>').selectedIndex = 0;
                        document.getElementById('<%= txtBlockNumber.ClientID %>').value = '';

                        // Show second SweetAlert
                        Swal.fire(
                            'Cancelled!',
                            'Your action has been canceled.',
                            'info'
                        );
                    }
                });
            }
            //--// Select the Cancel button with the onclick 'showCancelConfirmation'

        </script>

    </form>
</body>
</html>
