<%@ Page Title="" Language="C#" MasterPageFile="AdminKey2h.master" AutoEventWireup="true" CodeFile="add-user.aspx.cs" Inherits="adminkey2hcom_AddRM" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
     
    <div class="content">
        <div class="panel-header bg-primary-gradient">
            <div class="page-inner py-5">
                <div class="d-flex pb-2 align-items-left align-items-sm-center flex-column flex-sm-row justify-content-between">
                    <div class="d-flex">
                        <h2 class="text-white mb-0 fw-bold text-uppercase">
                            <asp:Label ID="lbldisplaymsg" runat="server" Text=""></asp:Label>
                        </h2>
                        <ul class="breadcrumbs">
                            <li class="nav-home pt-1">
                                <a href="dashboard.html">
                                    <i class="fa fa-home"></i>
                                </a>
                            </li>
                        </ul>
                    </div>
                    <div class="text-end d-none">
                        <a href="view-rm.aspx" data-bs-toggle="tooltip" title="View page">
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
                                        <h3>User Details</h3>
                                    </div>
                                    <div class="row mx-0 margin-top20 mb-4">
                                         
                                        <div class="col-sm-4 col-lg-3 pt-3">
                                            <div class="input-icon input-icon-sm right">
                                                <label>Name <span class="text-danger">*</span></label>
                                                <i class="bi bi-person-square b5-icon"></i>
                                                <asp:TextBox ID="txtName" class="form-control input-sm capitalize-input" MaxLength="50" autocomplete="off" placeholder="" runat="server"></asp:TextBox>
                                            </div>
                                            <span class="error">
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" Display="Dynamic" runat="server" ControlToValidate="txtName" ValidationGroup="RMVal" ErrorMessage="Enter name"></asp:RequiredFieldValidator>
                                                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtName" ValidationGroup="RMVal"
                                                    ValidationExpression="^[A-Za-z ]+(\.)?$" ErrorMessage="Enter vaid name" Display="Dynamic"></asp:RegularExpressionValidator>
                                            </span>
                                        </div>
                                        <div class="col-sm-4 col-lg-2 pt-3">
                                            <div class="input-icon input-icon-sm right">
                                                <label>Contact Number <span class="text-danger">*</span></label>
                                                <i class="bi bi-telephone b5-icon"></i> 
                                                <asp:TextBox ID="txtContactNumber" MaxLength="10" class="form-control input-sm" autocomplete="off" runat="server"></asp:TextBox>
                                            </div>
                                            <span class="error">
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator6" Display="Dynamic" runat="server" ControlToValidate="txtContactNumber" ValidationGroup="RMVal" ErrorMessage="Enter contact no."></asp:RequiredFieldValidator>
                                                <asp:RegularExpressionValidator ID="RegularExpressionValidator7" runat="server" ControlToValidate="txtContactNumber" ValidationGroup="RMVal"
                                                    ValidationExpression="^(?![0-5])\d{10}$" ErrorMessage="Enter valid contact no." Display="Dynamic"></asp:RegularExpressionValidator>
                                            </span>
                                        </div>  
                                        <div class="col-sm-4 col-lg-2 pt-3">
                                            <div class="input-icon input-icon-sm right">
                                                <label>Email ID <span class="text-danger">*</span></label>
                                                <i class="bi bi-envelope b5-icon"></i>
                                                <asp:TextBox ID="txtEmailid" class="form-control input-sm" MaxLength="50" autocomplete="off" runat="server"></asp:TextBox> 
                                            </div>
                                            <span class="error">
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator5" Display="Dynamic" runat="server" ControlToValidate="txtEmailid" ValidationGroup="RMVal" ErrorMessage="Enter email id"></asp:RequiredFieldValidator> 
                                                <asp:RegularExpressionValidator ID="RegularExpressionValidator6" runat="server" ControlToValidate="txtEmailid" ValidationGroup="RMVal"
                                                    ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" ErrorMessage="Enter valid email id" Display="Dynamic"></asp:RegularExpressionValidator> 
                                            </span>
                                        </div>

                                        <div class="col-sm-4 col-lg-2 pt-3">
                                            <div class="input-icon input-icon-sm right">
                                                <label>WhatsApp Number <span class="text-danger">*</span></label>
                                                <i class="bi bi-whatsapp b5-icon"></i> 
                                                <asp:TextBox ID="txtwhatsappnumber" MaxLength="10" class="form-control input-sm" autocomplete="off" runat="server"></asp:TextBox> 
                                            </div>
                                            <span class="error">
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator9" Display="Dynamic" runat="server" ControlToValidate="txtwhatsappnumber" ValidationGroup="RMVal" ErrorMessage="Enter whatsapp no."></asp:RequiredFieldValidator>
                                                <asp:RegularExpressionValidator ID="RegularExpressionValidator9" runat="server" ControlToValidate="txtwhatsappnumber" ValidationGroup="RMVal"
                                                    ValidationExpression="^(?![0-5])\d{10}$" ErrorMessage="Enter valid whatsapp number" Display="Dynamic"></asp:RegularExpressionValidator>
                                            </span>
                                        </div>

                                        <div class="col-sm-4 col-lg-2 pt-3">
                                            <div class="input-icon input-icon-sm right">
                                                <label>Gender </label>
                                                <i class="bi bi-gender-female b5-icon"></i> 
                                                <asp:DropDownList ID="ddlGender" runat="server" CssClass="form-control input-sm" autocomplete="off">
                                                    <asp:ListItem Value=""></asp:ListItem>
                                                    <asp:ListItem Value="Male">Male</asp:ListItem>
                                                    <asp:ListItem Value="Female">Female</asp:ListItem>
                                                    <asp:ListItem Value="Others">Others</asp:ListItem>
                                                </asp:DropDownList>
                                            </div>
                                            <span class="error">
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator10" Display="Dynamic" runat="server" ControlToValidate="ddlGender" ValidationGroup="RMVal" ErrorMessage="Select gender"></asp:RequiredFieldValidator> 
                                            </span>
                                        </div>

                                        <div class="col-sm-4 col-lg-2 pt-3">
                                            <div class="input-icon input-icon-sm right">
                                                <label>Role </label>
                                                <i class="bi bi-person-workspace b5-icon"></i> 
                                                <asp:DropDownList ID="ddlRole" runat="server" CssClass="form-control input-sm" autocomplete="off">
                                                    <asp:ListItem Value=""></asp:ListItem>
                                                    <asp:ListItem Value="Admin">Admin</asp:ListItem>
                                                    <asp:ListItem Value="Manager">Manager</asp:ListItem>
                                                    <asp:ListItem Value="RM">RM</asp:ListItem>
                                                </asp:DropDownList>
                                            </div>
                                            <span class="error">
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator20" Display="Dynamic" runat="server" ControlToValidate="ddlRole" ValidationGroup="RMVal" ErrorMessage="Select role"></asp:RequiredFieldValidator> 
                                            </span>
                                        </div>

                                        <div class="col-sm-4 col-lg-3 pt-3">
                                            <div class="input-icon input-icon-sm right">
                                                <label>Password <span class="text-danger">*</span></label>
                                                <i class="bi bi-device-ssd b5-icon"></i>
                                                <asp:TextBox ID="txtPassword" class="form-control input-sm" MaxLength="50" autocomplete="off" placeholder="" runat="server"></asp:TextBox>
                                            </div>
                                            <span class="error">
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator11" Display="Dynamic" runat="server" ControlToValidate="txtPassword" ValidationGroup="RMVal" ErrorMessage="Enter password"></asp:RequiredFieldValidator>
                                                <asp:RegularExpressionValidator ID="RegularExpressionValidator11" runat="server" ControlToValidate="txtPassword" ValidationGroup="RMVal"
                                                    ValidationExpression="^[A-Za-z0-9 @#$]+(\.)?$" ErrorMessage="Enter vaid name" Display="Dynamic"></asp:RegularExpressionValidator>
                                            </span>
                                        </div> 
                                    </div>
                                </div>
                            </div> 
                        </div>
                         
                        <div class="card-footer">
                            <div class="d-flex justify-content-center">
                                <asp:Button
                                    ID="btnSave" ClientIDMode="Static"
                                    runat="server" OnClick="btnSave_Click1"
                                    Text="Submit" ValidationGroup="RMVal"
                                    class="btn btn-sm handle-btn-success me-1 swtAltSubmit btnSave"
                                    OnClientClick="if (validatePage()) { this.value='Please wait..'; this.style.display='none'; document.getElementById('bWait').style.display = ''; } else { return false; }" Style="min-width: 67px;" />
                                <button type="button" style="display: none" id="bWait" class="btn btn-secondary btn-sm me-1"><i class='fa fa-spinner fa-spin'></i>Please wait</button>
                                <div class="btn btn-sm handle-btn-danger swtAltCancel">Cancel</div>
                                <asp:Button ID="btnCancel" OnClick="btnCancel_Click" runat="server" Text="Cancel Project" Style="display: none;" />
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
      
    <script>
        function validatePage() {
            var flag = window.Page_ClientValidate('RMVal');
            return flag;  
        } 
        document.getElementById('<%= txtName.ClientID %>').addEventListener('keypress', function (e) {
            if (!/^[A-Za-z ]+(\.)?$/.test(e.key)) {
                e.preventDefault();
            }
        });   
        document.getElementById('<%= txtContactNumber.ClientID %>').addEventListener('keypress', function (e) {
            if (!/^\d+$/.test(e.key)) {
                e.preventDefault();
            }
        });  
        document.getElementById('<%= txtwhatsappnumber.ClientID %>').addEventListener('keypress', function (e) {
            if (!/^\d+$/.test(e.key)) {
                e.preventDefault();
            }
        });
    </script>
    <script type="text/javascript">
        document.addEventListener('DOMContentLoaded', function () {
            const cancelButton = document.querySelector('.swtAltCancel');

            cancelButton.addEventListener('click', function () {
                Swal.fire({
                    title: 'Are you sure you want to cancel?',
                    showCancelButton: true,
                    confirmButtonText: 'Yes',
                    cancelButtonText: 'No',
                    customClass: {
                        title: 'handle-info-pt',
                        confirmButton: 'handle-btn-danger',
                        cancelButton: 'handle-btn-success',
                    }
                }).then((result) => {
                    if (result.isConfirmed) {
                        // Trigger the ASP.NET Button click to handle postback
                        document.getElementById('<%= btnCancel.ClientID %>').click();
                    } else if (result.dismiss === Swal.DismissReason.cancel) { 
                        //    'You can continue with your relationship manager details submission.', 
                    }
                });
            });
        });
    </script>
</asp:Content>

