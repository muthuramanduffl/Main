<%@ Page Title="" Language="C#" MasterPageFile="AdminKey2h.master" AutoEventWireup="true" CodeFile="view-project-progress.aspx.cs" Inherits="adminkey2hcom_ViewProjectProgress" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server"> 
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="content">
        <div class="panel-header bg-primary-gradient">
            <div class="page-inner py-5">
                <div class="d-flex pb-2 align-items-left align-items-sm-center flex-column flex-sm-row justify-content-between">
                    <div class="d-flex">
                        <h2 class="text-white mb-0 fw-bold text-uppercase">View Project Progress</h2>
                        <ul class="breadcrumbs">
                            <li class="nav-home pt-1">
                                <a href="dashboard.html">
                                    <i class="fa fa-home"></i>
                                </a>
                            </li>
                        </ul>
                    </div>
                    <div class="text-end d-none">
                        <a href="add-project-progress.html" data-bs-toggle="tooltip" title="Add page">
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
                            <div class="form-group p-0"> 
                                <div class="row mb-4">
                                    <div class="col-sm-4 col-lg-2 pt-3">
                                        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                            <ContentTemplate>
                                                <div class="input-icon input-icon-sm right">
                                                    <label>Project Name </label>
                                                    <i class="bi bi-journal-bookmark-fill b5-icon"></i>
                                                    <asp:DropDownList class="bs-select form-control input-sm" OnSelectedIndexChanged="ddlprojects_SelectedIndexChanged" AutoPostBack="true" ID="ddlprojects" runat="server">
                                                    </asp:DropDownList>
                                                </div>
                                            </ContentTemplate>
                                            <Triggers>
                                                <asp:AsyncPostBackTrigger ControlID="ddlprojects" EventName="SelectedIndexChanged" />
                                            </Triggers>
                                        </asp:UpdatePanel>
                                    </div>

                                    <div class="col-sm-4 col-lg-2 pt-3">
                                        <div class="input-icon input-icon-sm right">
                                            <label>Month </label>
                                            <i class="bi bi-calendar-week b5-icon"></i>
                                            <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                                                <ContentTemplate>
                                                    <asp:DropDownList class="bs-select form-control input-sm" OnSelectedIndexChanged="ddlmonth_SelectedIndexChanged" AutoPostBack="true" ID="ddlmonth" runat="server">
                                                        <asp:ListItem Value="All">All</asp:ListItem>
                                                        <asp:ListItem Value="January">January</asp:ListItem>
                                                        <asp:ListItem Value="February">February</asp:ListItem>
                                                        <asp:ListItem Value="March">March</asp:ListItem>
                                                        <asp:ListItem Value="April">April</asp:ListItem>
                                                        <asp:ListItem Value="May">May</asp:ListItem>
                                                        <asp:ListItem Value="June">June</asp:ListItem>
                                                        <asp:ListItem Value="July">July</asp:ListItem>
                                                        <asp:ListItem Value="August">August</asp:ListItem>
                                                        <asp:ListItem Value="September">September</asp:ListItem>
                                                        <asp:ListItem Value="October">October</asp:ListItem>
                                                        <asp:ListItem Value="November">November</asp:ListItem>
                                                        <asp:ListItem Value="December">December</asp:ListItem>
                                                    </asp:DropDownList>
                                                </ContentTemplate>
                                                <Triggers>
                                                    <asp:AsyncPostBackTrigger ControlID="ddlprojects" EventName="SelectedIndexChanged" />
                                                    <asp:AsyncPostBackTrigger ControlID="ddlmonth" EventName="SelectedIndexChanged" />
                                                </Triggers>
                                            </asp:UpdatePanel>
                                        </div>
                                    </div>
                                    <div class="col-sm-4 col-lg-2 pt-3">
                                        <div class="input-icon input-icon-sm right">
                                            <label>Year  </label>
                                            <i class="bi bi-calendar-week b5-icon"></i>
                                            <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                                                <ContentTemplate>
                                                    <asp:DropDownList class="bs-select form-control input-sm" OnSelectedIndexChanged="ddlyear_SelectedIndexChanged" AutoPostBack="true" ID="ddlyear" runat="server">
                                                        <asp:ListItem Value="All">All</asp:ListItem>
                                                        <asp:ListItem Value="2024">2024</asp:ListItem>
                                                        <asp:ListItem Value="2025">2025</asp:ListItem>
                                                        <asp:ListItem Value="2026">2026</asp:ListItem>
                                                        <asp:ListItem Value="2027">2027</asp:ListItem>
                                                        <asp:ListItem Value="2028">2028</asp:ListItem>
                                                        <asp:ListItem Value="2029">2029</asp:ListItem>
                                                        <asp:ListItem Value="2030">2030</asp:ListItem>
                                                    </asp:DropDownList>
                                                </ContentTemplate>
                                                <Triggers>
                                                    <asp:AsyncPostBackTrigger ControlID="ddlprojects" EventName="SelectedIndexChanged" />
                                                    <asp:AsyncPostBackTrigger ControlID="ddlmonth" EventName="SelectedIndexChanged" />
                                                    <asp:AsyncPostBackTrigger ControlID="ddlyear" EventName="SelectedIndexChanged" />
                                                </Triggers>
                                            </asp:UpdatePanel>
                                        </div>
                                    </div>

                                    <div class="col-sm-2 pt-3 d-flex add-bs-1"> 
                                        <asp:UpdatePanel ID="UpdatePanel7" runat="server">
                                            <ContentTemplate>
                                                <asp:LinkButton ID="lnkbtngo" data-bs-toggle="tooltip" title="Reset" OnClick="lnkbtngo_Click" class="b5-icon-search me-3" runat="server">
                                                <i class="bi bi-repeat"></i>
                                                </asp:LinkButton>
                                            </ContentTemplate>
                                            <Triggers>
                                                <asp:AsyncPostBackTrigger ControlID="ddlprojects" EventName="SelectedIndexChanged" />
                                                <asp:AsyncPostBackTrigger ControlID="ddlmonth" EventName="SelectedIndexChanged" />
                                                <asp:AsyncPostBackTrigger ControlID="ddlyear" EventName="SelectedIndexChanged" /> 
                                            </Triggers>
                                        </asp:UpdatePanel>
                                    </div>
                                </div>
                                <asp:UpdatePanel ID="UpdatePanel8" runat="server">
                                    <ContentTemplate>
                                        <div class="text-center no-data-found" clientidmode="Static" id="DivNoDataFound" runat="server" style="display: none;">
                                            <h4 class="mb-0 text-secondary pt-5 pb-4">
                                                <img src="assets/img/no-data.png" alt="img" class="img-fluid" />
                                                No Data Found</h4>
                                        </div>
                                    </ContentTemplate>
                                    <Triggers>
                                        <asp:AsyncPostBackTrigger ControlID="ddlprojects" EventName="SelectedIndexChanged" />
                                        <asp:AsyncPostBackTrigger ControlID="ddlmonth" EventName="SelectedIndexChanged" />
                                        <asp:AsyncPostBackTrigger ControlID="ddlyear" EventName="SelectedIndexChanged" />
                                    </Triggers>
                                </asp:UpdatePanel>
                                <asp:UpdatePanel ID="UpdatePanel6" runat="server">
                                    <ContentTemplate>
                                        <h5><span class="box-b-only p-1">
                                            <asp:Label ID="lblcount" runat="server" Text=""></asp:Label>
                                        </span></h5>
                                    </ContentTemplate>
                                    <Triggers>
                                        <asp:AsyncPostBackTrigger ControlID="ddlprojects" EventName="SelectedIndexChanged" />
                                        <asp:AsyncPostBackTrigger ControlID="ddlmonth" EventName="SelectedIndexChanged" />
                                        <asp:AsyncPostBackTrigger ControlID="ddlyear" EventName="SelectedIndexChanged" />
                                    </Triggers>
                                </asp:UpdatePanel>
                            </div>
                             
                            <div class="table-responsive">
                                <asp:UpdatePanel ID="UpdatePanel5" runat="server" UpdateMode="Conditional">
                                    <ContentTemplate>
                                        <asp:Repeater ID="rpruser" OnItemCommand="Repeater1_ItemCommand" runat="server">
                                            <HeaderTemplate>
                                                <table class="table table-bordered" id="basic-datatables" role="grid" aria-describedby="basic-datatables_info">
                                                    <thead>
                                                        <tr>
                                                            <th class="w-sno">#</th>
                                                            <th>Project Name </th>
                                                            <th>Thumbnail Image</th>
                                                            <th>Month / Year</th>
                                                            <th class="min-w-120">Action </th>
                                                        </tr>
                                                    </thead>
                                                    <tbody>
                                            </HeaderTemplate>
                                            <ItemTemplate>
                                                <tr>
                                                    <asp:HiddenField ID="HiddenField1" ClientIDMode="Static" Value='<%# Eval("ProgressID") %>' runat="server" />
                                                    <td>
                                                        <%# GetRowNo(Convert.ToString(Container.ItemIndex + 1))%> 
                                                    </td>
                                                    <td>
                                                        <%#Bindproject(Convert.ToInt32(Eval("ProjectID"))) %>                                            
                                                    </td>
                                                    <td>
                                                        <asp:HiddenField ID="HiddenField2" Value='<%# Eval("ProgressID") %>' runat="server" /> 
                                                        <a href="#" class="me-3" data-bs-toggle="tooltip" title="View" onclick="showImage('<%#"/ProjectProgressThumbnailimage/"+ Eval("ThumbnailImage") %>'); return false;">
                                                            <i class="bi bi-eye b5-icon-et-dlt "></i>
                                                        </a> 
                                                        <asp:HiddenField ID="hdnfile" Value='<%# Eval("ThumbnailImage")%>' runat="server" />
                                                        <asp:LinkButton CssClass=" " ID="Editbtn" runat="server" CommandName="EditThumbnail" Visible="true"
                                                            CommandArgument='<%# DataBinder.Eval(Container.DataItem, "ProgressID") %>'><i class="bi bi-pencil-square b5-icon-et-dlt" data-bs-toggle="tooltip" title="Edit"></i></asp:LinkButton> 
                                                    </td>
                                                    <td>
                                                        <%# Eval("Month")+" / "+ Eval("Year") %>                                               
                                                    </td>
                                                    <td>
                                                        <asp:LinkButton class="me-3" ID="lkedit" runat="server" CommandName="Edit"
                                                            CommandArgument='<%# DataBinder.Eval(Container.DataItem, "ProgressID") %>'>
                                                            <i class="bi bi-pencil-square b5-icon-et-dlt" data-bs-toggle="tooltip" title="Edit"></i>
                                                        </asp:LinkButton> 
                                                        <a class="swtAltCancel">
                                                            <i class="bi bi-trash b5-icon-et-dlt" data-bs-toggle="tooltip" title="Delete"></i>
                                                        </a>
                                                        <asp:LinkButton ID="LinkButton2" CausesValidation="false" runat="server" class="dlt-img hidden" Text="Delete" CommandName="Delete" CommandArgument='<%# Eval("ProgressID") %>' Style="display: none">
                                                        </asp:LinkButton>
                                                    </td>
                                                </tr>
                                            </ItemTemplate>
                                            <FooterTemplate>
                                                </tbody>
                                        </table>               
                                            </FooterTemplate>
                                        </asp:Repeater>
                                    </ContentTemplate>
                                    <Triggers> 
                                        <asp:AsyncPostBackTrigger ControlID="ddlprojects" EventName="SelectedIndexChanged" />
                                        <asp:AsyncPostBackTrigger ControlID="ddlmonth" EventName="SelectedIndexChanged" />
                                        <asp:AsyncPostBackTrigger ControlID="ddlyear" EventName="SelectedIndexChanged" />
                                    </Triggers>
                                </asp:UpdatePanel>  
                            </div>
                            <div class="d-md-flex justify-content-end d-block mb-3">
                                <asp:UpdatePanel ID="UpdatePanel4" UpdateMode="Conditional" runat="server">
                                    <ContentTemplate>
                                        <asp:Repeater ID="rptPager" runat="server">
                                            <ItemTemplate>
                                                <asp:LinkButton ID="lnkPage" runat="server" Text='<%#Eval("Text") %>' CommandArgument='<%# Eval("Value") %>'
                                                    CssClass='page-list'
                                                    Enabled='<%# Convert.ToBoolean(Eval("Enabled")) ? true : false %>'
                                                    OnClick="Page_Changed" OnClientClick='<%# !Convert.ToBoolean(Eval("Enabled")) ? "return false;" : "" %>'></asp:LinkButton> 
                                            </ItemTemplate>
                                        </asp:Repeater>
                                    </ContentTemplate>
                                    <Triggers>
                                        <asp:AsyncPostBackTrigger ControlID="ddlprojects" EventName="SelectedIndexChanged" />
                                        <asp:AsyncPostBackTrigger ControlID="ddlmonth" EventName="SelectedIndexChanged" />
                                        <asp:AsyncPostBackTrigger ControlID="ddlyear" EventName="SelectedIndexChanged" /> 
                                    </Triggers>
                                </asp:UpdatePanel>
                            </div> 
                        </div> 
                    </div>
                </div>
            </div>
        </div> 
    </div>

    <div id="fileUploaderModal" class="modal" style="display: none;">
        <div class="modal-dialog modal-dialog-centered">
            <div class="modal-content ">
                <div class="modal-header border-0 justify-content-center">
                    <h3 class="fw-bold m-0 p-0 text-black" id="modalLabel">Upload File</h3>
                    <div class="btn-close-icon" onclick="closeModal()" aria-label="Close" style="cursor: pointer; position: absolute; top: 16px; right: 14px;">
                        <p style="margin-left: 10px; margin-top: 1px">X</p>
                    </div>
                </div>
                <div class="modal-body border-0 px-3 py-0">
                    <asp:HiddenField ID="hdnProgressID" runat="server" />
                    <asp:FileUpload ID="FileUpload1" accept=".jpeg, .jpg, .png" runat="server" class="form-control input-sm file-upload" />
                    <span class="handle-file-request">(max file size of 500 KB)</span>
                    <span class="error-label" style="color: #D41111"></span>
                    <span class="error">
                        <asp:RequiredFieldValidator ClientIDMode="Static" SetFocusOnError="true" EnableClientScript="true" ControlToValidate="FileUpload1" ValidationGroup="val" ID="RequiredFieldValidator5" runat="server" ErrorMessage="Upload image"></asp:RequiredFieldValidator>
                    </span>
                </div>
                <div class="modal-footer m-0 p-0 justify-content-center border-0">
                    <asp:UpdatePanel ID="UpdatePanel9" UpdateMode="Conditional" runat="server">
                        <ContentTemplate>
                            <asp:LinkButton ID="btnAdd" ValidationGroup="val" OnClientClick="if (validatePage1()) { this.value='Please wait..'; this.style.display='none'; document.getElementById('bWait1').style.display = ''; } else { return false; }" OnClick="btnUpload_Click" runat="server" class="btn btn-sm me-1 handle-btn-success add-btn">
                     Submit
                            </asp:LinkButton>
                            <button type="button" style="display: none" id="bWait1" class="btn btn-secondary btn-sm me-1"><i class='fa fa-spinner fa-spin'></i>Please Wait</button>
                        </ContentTemplate>
                        <Triggers>
                            <asp:AsyncPostBackTrigger ControlID="ddlprojects" EventName="SelectedIndexChanged" />
                            <asp:AsyncPostBackTrigger ControlID="ddlmonth" EventName="SelectedIndexChanged" />
                            <asp:AsyncPostBackTrigger ControlID="ddlyear" EventName="SelectedIndexChanged" />
                            <asp:PostBackTrigger ControlID="btnAdd"/>
                        </Triggers>
                    </asp:UpdatePanel>
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
        function validatePage1() {
            var flag = window.Page_ClientValidate('val');
            return flag;
        } 
    </script>

    <script>
        function showImage(imageUrl) {
            Swal.fire({
                html: `
                    <div style="position: relative;">
                        <div class="btn-close-icon" onclick="Swal.close()" style="cursor: pointer; position: absolute; top: -15px; right: -25px;">&times;</div>
                        <h2 class="fw-bold">Thumbnail Image</h2>
                        <img src="${imageUrl}" alt="Image Preview" class="image-preview img-fluid mt-3" id="popupImage">
                    </div> 
            `,
                showConfirmButton: false, /* Removes the OK button */
                //background: '#f9f9f9',
                //width: '50%', /* Adjust popup width as needed */
                //customClass: {
                //    popup: 'sweet-popup-style',
                //},
            });
        }
    </script>


    <script>
        // Function to open the modal
        function openModal() {
            document.getElementById('fileUploaderModal').style.display = 'block';
        }

        // Function to close the modal
        function closeModal() {
            document.getElementById('fileUploaderModal').style.display = 'none';
        } 
    </script>
    <script> 
        function initializeDeleteEvents() {
            const cancelButtons = document.querySelectorAll('.swtAltCancel'); 
            cancelButtons.forEach((cancelButton) => {
                cancelButton.addEventListener('click', function () {
                    const linkButton = this.closest('tr')?.querySelector('.dlt-img.hidden'); 
                    Swal.fire({
                        title: 'Are you sure you want to delete all images & details?',
                        showCancelButton: true,
                        confirmButtonText: 'Yes',
                        cancelButtonText: 'No',
                        customClass: {
                            title: 'handle-info-pt',
                            confirmButton: 'handle-btn-danger',
                            cancelButton: 'handle-btn-success',
                        }
                    }).then((result) => {
                        if (result.isConfirmed && linkButton) {
                            linkButton.click();
                        } else if (result.dismiss === Swal.DismissReason.cancel) {
                            //Your project has not been deleted.
                        }
                    });
                });
            });
        }
        // Attach events on page load
        document.addEventListener('DOMContentLoaded', function () {
            initializeDeleteEvents();
        });

        // Attach events after UpdatePanel updates
        Sys.WebForms.PageRequestManager.getInstance().add_endRequest(function () {
            initializeDeleteEvents();
        });
    </script>

    <script type="text/javascript">
        document.addEventListener('DOMContentLoaded', function () {
            var fileUploader = document.querySelector('.file-upload');  
            var errorLabel = document.querySelector('.error-label');    
            var screensrc = {};  
            var fileType = {};  
            if (!fileUploader || !errorLabel) {
                console.error("Required elements not found in the DOM.");
                return;
            } 
            fileUploader.addEventListener('change', function (event) {
                var input = event.target;
                var file = input.files[0];
                var allowedFiles = [".png", ".jpg", ".jpeg"]; 
                errorLabel.innerHTML = ''; 
                if (!file) {
                    updateError(errorLabel, "No file selected.");
                    resetUploader();
                    return;
                }

                var ext = file.name.split('.').pop().toLowerCase();
                if (allowedFiles.includes("." + ext)) {
                    var size = parseFloat(file.size / 1024).toFixed(2); // Size in KB
                    if (size > 500) {
                        updateError(errorLabel, "Image size must be under 500 KB");
                        resetUploader();
                        return;
                    } else {
                        var lbl = document.querySelector('.lbluploderlogomsg');
                        lbl.textContent = "";

                        var viewLogoBtn = document.querySelector('.view-pro-logo-img');
                        viewLogoBtn.style.display = 'inline-block';  // Show the image view button
                    }
                } else {
                    updateError(errorLabel, "Select .png, .jpg, or .jpeg files only.");
                    resetUploader();
                }

                // If valid, store the file type
                fileType = file.type;
                screensrc = URL.createObjectURL(file);  // Store the file for further use
            });

            fileUploader.addEventListener('click', function () {
                resetUploader();
                errorLabel.innerHTML = '';  // Clear any existing error message
            });

            function resetUploader() {
                screensrc = null;
                fileUploader.value = ''; // Reset the file input
                var viewLogoBtn = document.querySelector('.view-pro-logo-img');
                viewLogoBtn.style.display = 'none'; // Hide the image view button
            }

            function updateError(errorLabel, message) {
                if (errorLabel) {
                    errorLabel.innerHTML = message;
                } else {
                    console.error("Error label not found.");
                }
            }
        });
    </script>
     
</asp:Content>

