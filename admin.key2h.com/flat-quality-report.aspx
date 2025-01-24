<%@ Page Title="" Language="C#" MasterPageFile="AdminKey2h.master" AutoEventWireup="true" CodeFile="flat-quality-report.aspx.cs" Inherits="adminkey2hcom_FlatQualityReport" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
   
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
        <div class="content">
        <div class="panel-header bg-primary-gradient">
            <div class="page-inner py-5">
                <div class="d-flex pb-2 align-items-left align-items-sm-center flex-column flex-sm-row justify-content-between">
                    <div class="d-flex">
                        <h2 class="text-white mb-0 fw-bold text-uppercase">
                            <asp:Label ID="lblDisplaytext" runat="server" Text=""></asp:Label> 
                        </h2>
                        <ul class="breadcrumbs">
                            <li class="nav-home pt-1">
                                <a href="dashboard.html">
                                    <i class="fa fa-home"></i>
                                </a>
                            </li>
                        </ul>
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
                                        <h3>Add Details</h3>
                                    </div>
                                    <div class="row mx-0 margin-top20 mb-4">
                                        <div class="col-sm-4 col-xl-3 pt-3">
                                            <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
                                                <ContentTemplate>
                                                    <div class="input-icon input-icon-sm right">
                                                        <label>Project Name <span class="text-danger">*</span></label>
                                                        <i class="bi bi-journal-bookmark-fill b5-icon"></i>
                                                        <asp:DropDownList ID="ddlProName" AutoPostBack="true" OnSelectedIndexChanged="ddlProName_SelectedIndexChanged" class="bs-select form-control input-sm" runat="server">
                                                            <asp:ListItem Value="U49">U49</asp:ListItem>

                                                        </asp:DropDownList>
                                                    </div>
                                                    <span class="error">
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" Display="Dynamic" runat="server" ValidationGroup="projval"
                                                            ControlToValidate="ddlProName" InitialValue="" ErrorMessage="Select project name">
                                                        </asp:RequiredFieldValidator> 
                                                    </span>
                                                </ContentTemplate>
                                                <Triggers> 
                                                    <asp:AsyncPostBackTrigger ControlID="ddlProName" EventName="SelectedIndexChanged" />
                                                    <asp:AsyncPostBackTrigger ControlID="ddlBlockNumber" EventName="SelectedIndexChanged" />
                                                    <asp:AsyncPostBackTrigger ControlID="ddlFlatNumber" EventName="SelectedIndexChanged" />
                                                </Triggers>
                                            </asp:UpdatePanel>
                                        </div>

                                        <div class="col-sm-4 col-xl-3 pt-3">
                                            <div class="input-icon input-icon-sm right">
                                                <label>Block Name <span class="text-danger">*</span></label>
                                                <i class="bi bi-building b5-icon"></i>
                                                <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                                                    <ContentTemplate>
                                                        <asp:DropDownList ID="ddlBlockNumber" AutoPostBack="true" OnSelectedIndexChanged="ddlBlockNumber_SelectedIndexChanged" class="bs-select form-control input-sm" runat="server">
                                                        </asp:DropDownList>
                                                    </ContentTemplate>
                                                    <Triggers> 
                                                        <asp:AsyncPostBackTrigger ControlID="ddlProName" EventName="SelectedIndexChanged" />
                                                        <asp:AsyncPostBackTrigger ControlID="ddlBlockNumber" EventName="SelectedIndexChanged" />
                                                        <asp:AsyncPostBackTrigger ControlID="ddlFlatNumber" EventName="SelectedIndexChanged" />
                                                    </Triggers>
                                                </asp:UpdatePanel>
                                                <span class="error">
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ValidationGroup="projval"
                                                        ControlToValidate="ddlBlockNumber" InitialValue="" Display="Dynamic" ErrorMessage="Select block name">
                                                    </asp:RequiredFieldValidator> 
                                                </span>
                                            </div>
                                        </div>
                                        <div class="col-sm-4 col-xl-3 pt-3">
                                            <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                                                <ContentTemplate>
                                                    <div class="input-icon input-icon-sm right">
                                                        <label>Flat Number <span class="text-danger">*</span></label>
                                                        <i class="bi bi-file-binary b5-icon"></i>
                                                        <asp:DropDownList ID="ddlFlatNumber" AutoPostBack="true" ClientIDMode="Static" OnSelectedIndexChanged="ddlFlatNumber_SelectedIndexChanged" class="bs-select form-control input-sm" runat="server">
                                                        </asp:DropDownList>
                                                    </div>
                                                </ContentTemplate>
                                                <Triggers> 
                                                    <asp:AsyncPostBackTrigger ControlID="ddlProName" EventName="SelectedIndexChanged" />
                                                    <asp:AsyncPostBackTrigger ControlID="ddlBlockNumber" EventName="SelectedIndexChanged" />
                                                    <asp:AsyncPostBackTrigger ControlID="ddlFlatNumber" EventName="SelectedIndexChanged" />
                                                </Triggers>
                                            </asp:UpdatePanel>
                                            <span class="error">
                                                <asp:RequiredFieldValidator ClientIDMode="Static" Display="Dynamic" EnableClientScript="true" SetFocusOnError="true" ControlToValidate="ddlFlatNumber" ValidationGroup="projval" ID="RequiredFieldValidator10" runat="server" ErrorMessage="Select flat no. "></asp:RequiredFieldValidator>
                                               </span>
                                        </div>
                                        <div class="col-sm-4 col-xl-3 pt-3">
                                            <asp:UpdatePanel ID="UpdatePanel4" runat="server" UpdateMode="Conditional">
                                                <ContentTemplate>
                                                    <div class="input-icon input-icon-sm right">
                                                        <label>Customer Name </label>
                                                        <i class="bi bi-person-square b5-icon"></i>
                                                        <asp:TextBox runat="server" ID="txtCustomerName" class="form-control input-sm" disabled="true" autocomplete="off" placeholder=""></asp:TextBox>
                                                    </div>
                                                    <asp:Label ID="lblcustomernameerror" ClientIDMode="Static" class="align-items-center text-center error" runat="server" Text=""></asp:Label>

                                                </ContentTemplate>
                                                <Triggers> 
                                                    <asp:AsyncPostBackTrigger ControlID="ddlProName" EventName="SelectedIndexChanged" />
                                                    <asp:AsyncPostBackTrigger ControlID="ddlBlockNumber" EventName="SelectedIndexChanged" />
                                                    <asp:AsyncPostBackTrigger ControlID="ddlFlatNumber" EventName="SelectedIndexChanged" />
                                                    <asp:AsyncPostBackTrigger ControlID="btnCancel" EventName="click" />
                                                </Triggers>
                                            </asp:UpdatePanel>
                                        </div>
                                        <div class="col-sm-4 col-xl-3 pt-3">
                                            <asp:UpdatePanel ID="UpdatePanel5" runat="server" UpdateMode="Conditional">
                                                <ContentTemplate>
                                                    <div class="input-icon input-icon-sm right">
                                                        <label>Title <span class="text-danger">*</span></label>
                                                          <asp:TextBox runat="server" placeholder=""  ID="txtTitle" MaxLength="50" class="form-control input-sm input-value capitalize-input" autocomplete="off"></asp:TextBox>
                                                    </div>
                                                    </ContentTemplate>
                                                <Triggers> 
                                                    <asp:AsyncPostBackTrigger ControlID="ddlProName" EventName="SelectedIndexChanged" />
                                                    <asp:AsyncPostBackTrigger ControlID="ddlBlockNumber" EventName="SelectedIndexChanged" />
                                                    <asp:AsyncPostBackTrigger ControlID="ddlFlatNumber" EventName="SelectedIndexChanged" /> 
                                                    <asp:AsyncPostBackTrigger ControlID="btnCancel" EventName="click" />
                                                </Triggers>
                                            </asp:UpdatePanel>
                                            <span class="error">
                                                <asp:RequiredFieldValidator ClientIDMode="Static" Display="Dynamic" EnableClientScript="true" SetFocusOnError="true" ControlToValidate="txtTitle" ValidationGroup="projval" ID="RegularExpressionValidator11" runat="server" ErrorMessage="Enter title"></asp:RequiredFieldValidator>
                                            <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtTitle" ValidationGroup="projval" ValidationExpression="^[A-Za-z0-9 -]+$" ErrorMessage="Enter vaid title" Display="Dynamic"></asp:RegularExpressionValidator>
                                           
                                            </span>
                                        </div>
                                        <div class="col-sm-4 col-xl-3 pt-3">
                                            <asp:UpdatePanel ID="UpdatePanel8" runat="server" UpdateMode="Conditional">
                                                <ContentTemplate>
                                                    <div class="input-icon input-icon-sm right">
                                                        <label>Upload <span class="text-danger">*</span></label>
                                                        <asp:FileUpload ID="flUpload" ClientIDMode="Static" accept=".pdf" class="form-control input-sm file-upload" autocomplete="off" placeholder="" runat="server" />
                                                        <span class="handle-file-request">(PDF file only, max size of 800 KB)</span>
                                                    </div>
                                                     <asp:HiddenField ID="hdnUpload" runat="server" />
                                                    <span class="error"> 
                                                        <asp:RequiredFieldValidator ClientIDMode="Static" Display="Dynamic" EnableClientScript="true" SetFocusOnError="true" ControlToValidate="flUpload" ValidationGroup="projval" ID="RequiredFieldValidator9" runat="server" ErrorMessage="Upload PDF"></asp:RequiredFieldValidator>
                                                      <asp:Label ID="lblflUpload" CssClass="error-label" runat="server" ForeColor="#d41111" Text="" Display="Dynamic"></asp:Label>  
                                                    </span>
                                                    <div class="view-upload-pdf mt-3 btn-view-pop btn-view" runat="server" style="display: none">
                                                        <i class="bi bi-eye"></i>View PDF
                                                    </div>
                                                </ContentTemplate>
                                                <Triggers>
                                                    <asp:AsyncPostBackTrigger ControlID="btnCancel" EventName="click" />
                                                </Triggers>
                                            </asp:UpdatePanel>
                                        </div>

                                        
                                        <!-- Display Added Values -->
                                        <div class="added-values"></div>
                                    </div>

                                    <div class="card-footer mx-2 pb-4">
    <div class="d-flex justify-content-center"> 
        <asp:UpdatePanel ID="UpdatePanel6" runat="server" UpdateMode="Conditional">
    <ContentTemplate>
        <asp:LinkButton ID="btnAdd" OnClientClick="if (validatePage1()) { this.value='Please wait..'; this.style.display='none'; document.getElementById('bWait1').style.display = ''; } else { return false; }" OnClick="btnAdd_Click" runat="server" class="btn me-1 btn btn-sm handle-btn-success add-btn">
            Submit
        </asp:LinkButton>
        <button type="button" style="display: none" id="bWait1" class="btn btn-secondary btn-sm me-1">Please Wait</button>
        <div class="btn btn-sm handle-btn-danger swtAltCancel ">Cancel</div>
        <asp:Button ID="btnCancel" ClientIDMode="Static" runat="server" Text="Cancel Project" OnClick="btnCancel_Click" Style="display: none;" />
                                   
    </ContentTemplate>
    <Triggers>
        <asp:AsyncPostBackTrigger ControlID="btnAdd" EventName="click" />
        <asp:AsyncPostBackTrigger ControlID="ddlProName" EventName="SelectedIndexChanged" />
        <asp:AsyncPostBackTrigger ControlID="ddlBlockNumber" EventName="SelectedIndexChanged" />
        <asp:AsyncPostBackTrigger ControlID="ddlFlatNumber" EventName="SelectedIndexChanged" /> 
        <asp:AsyncPostBackTrigger ControlID="btnCancel" EventName="click" />
    </Triggers>
</asp:UpdatePanel>
        
    </div>
</div>



                                </div>
                            </div>

                            <div class="form-group" id="divrptCustomers" clientidmode="Static" runat="server">
                                <div class="form-border margin-top20">
                                    <div class="form-title">
                                        <h3>View Details</h3>
                                    </div>
                                    <div class="table-responsive pt-4 mt-md-2 mt-0 px-4">
                                        <asp:UpdatePanel ID="UpdatePanel7" runat="server">
                                            <ContentTemplate>
                                                <asp:Repeater ID="rptCustomers" runat="server">
                                                    <HeaderTemplate>
                                                        <table class="table table-bordered" id="tblCustomers">
                                                            <thead>
                                                                <th># </th>
                                                                <th>Title </th>
                                                                <th>PDF</th>
                                                                <th>Action</th>
                                                            </thead>
                                                            <tbody>
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <tr>
                                                            <td><%# GetRowNo(Convert.ToString(Container.ItemIndex + 1))%> </td>
                                                            <td>
                                                                <asp:HiddenField ID="hdnCostLabelID" Value='<%# Eval("CostLabelID") %>' runat="server" />
                                                                <div class="lblCostLabel txtTitleView"><%# Eval("CostParameterName") %></div>
                                                                <input type="text" class="txtTitle" value='<%# Eval("CostParameterName") %>' style="display: none;" />
                                                                <input type="text" maxlength="50" class="form-control input-sm input-value capitalize-input txtTitleEdit " value='<%# Eval("CostParameterName") %>' onkeypress="return /^[A-Za-z0-9 -]+$/.test(event.key);" style="display: none;" />
                                                            </td>
                                                            <td>
                                                                <div class="lblCost d-none">₹<%# Eval("Cost") %></div>
                                                                <a target="_blank" href="" class="lblCost view-show-hid" data-bs-toggle="tooltip" data-bs-original-title="View">
                                                            <i class="bi bi-eye b5-icon-et-dlt"></i>  
                                                        </a>
                                                                <div class="txtCost" style="display: none;">
                                                                <input type="file"  accept=".pdf" class="form-control input-sm input-value file-upload " id="fileUploader" value='<%# "₹" + Eval("Cost") %>' />
                                                                    </div>
                                                             <asp:Label ID="lblflUpload1" CssClass="error-label" runat="server" ForeColor="#d41111" Text="" Display="Dynamic"></asp:Label>  
                                                   
                                                                </td>
                                                            <td>
                                                                <a href="javascript:void(0);" class="btnEdit" onclick="editRow(this)"><i class="bi bi-pencil-square b5-icon-et-dlt me-3" data-bs-toggle="tooltip" title="Edit"></i></a>
                                                                <a href="javascript:void(0);" class="btnUpdate" onclick="updateRow(this)" style="display: none;"><i class="bi bi-save b5-icon-et-dlt me-3" data-bs-toggle="tooltip" title="Update"></i></a>
                                                                <a href="javascript:void(0);" class="btnCancel" onclick="cancelEdit(this)" style="display: none;"><i class="bi bi-x-circle b5-icon-et-dlt me-3" data-bs-toggle="tooltip" title="Cancel"></i></a>
                                                                <a href="javascript:void(0);" class="btnDelete" onclick="deleteRow(this)"><i class="bi bi-trash b5-icon-et-dlt me-3" data-bs-toggle="tooltip" title="Delete"></i></a>
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
                                                <asp:AsyncPostBackTrigger ControlID="btnAdd" EventName="click" /> 
                                                <asp:AsyncPostBackTrigger ControlID="ddlProName" EventName="SelectedIndexChanged" />
                                                <asp:AsyncPostBackTrigger ControlID="ddlBlockNumber" EventName="SelectedIndexChanged" />
                                                <asp:AsyncPostBackTrigger ControlID="ddlFlatNumber" EventName="SelectedIndexChanged" /> 
                                                <asp:AsyncPostBackTrigger ControlID="btnCancel" EventName="click" />
                                            </Triggers>
                                        </asp:UpdatePanel>
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
    
<script type="text/javascript">
    function validatePage1() {
        var flag = Page_ClientValidate('projval');
        return flag;
    }
    document.getElementById('<%= txtTitle.ClientID %>').addEventListener('keypress', function (e) {
        if (!/^[A-Za-z0-9 -]+$/.test(e.key)) {
            e.preventDefault();
        }
    });
     
</script>
 
    <script type="text/javascript">
        function editRow(btn) {
            const row = btn.closest('tr');
            //row.querySelector('.lblCostLabel').style.display = 'none';
            //row.querySelector('.txtTitle').style.display = 'inline';

            row.querySelector('.lblCost').style.display = 'none';
            row.querySelector('.view-show-hid').style.display = 'none'; 
            row.querySelector('.txtCost').style.display = 'inline';
            row.querySelector('.txtTitleEdit').style.display = 'inline'; 
            row.querySelector('.txtTitleView').style.display = 'none'; 
            row.querySelector('.btnEdit').style.display = 'none';
            row.querySelector('.btnUpdate').style.display = 'inline';
            row.querySelector('.btnCancel').style.display = 'inline';
        }

        function cancelEdit(btn) {
            const row = btn.closest('tr');
            // row.querySelector('.lblCostLabel').style.display = 'inline';
            // row.querySelector('.txtTitle').style.display = 'none';

            row.querySelector('.lblCost').style.display = 'inline';
            row.querySelector('.txtCost').style.display = 'none';
            row.querySelector('.txtTitleEdit').style.display = 'none';
            row.querySelector('.btnEdit').style.display = 'inline';
            row.querySelector('.txtTitleView').style.display = 'inline';
            row.querySelector('.btnUpdate').style.display = 'none';
            row.querySelector('.btnCancel').style.display = 'none';
        }

        function updateRow(btn) {
            const row = btn.closest('tr');
            const costLabelID = row.querySelector('input[type="hidden"]').value;
            const costParameterName = row.querySelector('.txtTitle').value;
            const cost = row.querySelector('.txtCost').value;

            var dropflatname = document.getElementById('<%= ddlFlatNumber.ClientID %>');
            if (!dropflatname) {
                alert('Dropdown not found!');
                return;
            }
            var selectedValue = dropflatname.value;

            $.ajax({
                type: 'POST',
                url: 'flat-quality-report.aspx/UpdateCustomer',
                data: JSON.stringify({ costLabelID, costParameterName, cost, selectedValue }),
                contentType: 'application/json; charset=utf-8',
                dataType: 'json',
                success: function (response) {
                    row.querySelector('.lblCostLabel').innerText = costParameterName;
                    row.querySelector('.lblCost').innerText = cost;

                    cancelEdit(btn);

                    const table = document.getElementById('tblCustomers');
                    const rows = table.querySelectorAll('tbody tr');
                    if (rows.length === 0) {
                        const repeaterContainer = document.getElementById('<%= divrptCustomers.ClientID %>').closest('div');
                        if (repeaterContainer) {
                            repeaterContainer.style.display = 'none';
                        }
                    }
                },
                error: function () {
                    alert('Error updating row!');
                }
            });
        }
        function deleteRow(btn) {
            Swal.fire({
                title: 'Are you sure you want to delete?',
                showCancelButton: true,
                confirmButtonText: 'Yes',
                cancelButtonText: 'No',
                customClass: {
                    confirmButton: 'handle-btn-danger',
                    cancelButton: 'handle-btn-success',
                }
            }).then((result) => {
                if (result.isConfirmed) {
                    const row = btn.closest('tr');
                    const hiddenField = row.querySelector('input[type="hidden"]'); // Get the HiddenField
                    const costLabelID = hiddenField ? hiddenField.value : '';

                    if (!costLabelID) {
                        alert('CostLabelID is missing!');
                        return;
                    }

                    var dropflatname = document.getElementById('<%= ddlFlatNumber.ClientID %>');
                    var selectedValue = dropflatname ? dropflatname.value : '';

                    $.ajax({
                        type: 'POST',
                        url: 'flat-quality-report.aspx/DeleteCustomer',
                        data: JSON.stringify({ costLabelID: costLabelID, selectedValue: selectedValue }),
                        contentType: 'application/json; charset=utf-8',
                        dataType: 'json',
                        success: function (response) {
                            row.remove();
                            loadRepeaterData(selectedValue); // Rebind data to the repeater

                            const table = document.getElementById('tblCustomers');
                            const rows = table.querySelectorAll('tbody tr');
                            if (rows.length === 0) {
                                const repeaterContainer = document.getElementById('<%= divrptCustomers.ClientID %>').closest('div');
                        if (repeaterContainer) {
                            repeaterContainer.style.display = 'none';
                        }
                    }

                    // Show SweetAlert success message with a tick icon only
                    //Swal.fire({
                    //    title: 'Report have been deleted as requested', confirmButtonText: 'Ok',
                    //    customClass: {
                    //        confirmButton: 'handle-btn-success'
                    //    },
                    //});

                },
                error: function () {
                    alert('Error deleting row!');
                }
            });
                } else {
                    // If canceled, do nothing
                    return;
                }
            });
        }


        function checkRowCountAndToggleDisplay() {
            var dropflatname = document.getElementById('<%= ddlFlatNumber.ClientID %>');
            if (!dropflatname) {
                alert('Dropdown not found!');
                return;
            }

            const ddlblock = document.getElementById('<%= ddlBlockNumber.ClientID %>');
            const ddlproject = document.getElementById('<%= ddlProName.ClientID %>');
            const repeaterContainer = document.getElementById('<%= divrptCustomers.ClientID %>').closest('div');

            var selectedValue = dropflatname.value;

            if (!selectedValue) {
                repeaterContainer.style.display = 'none';
                return;
            }

            $.ajax({
                type: 'POST',
                url: 'flat-quality-report.aspx/GetRowCount',
                data: JSON.stringify({ selectedValue: selectedValue }),
                contentType: 'application/json; charset=utf-8',
                dataType: 'json',
                success: function (response) {
                    const rowCount = response;

                    const repeaterContainer = document.getElementById('<%= divrptCustomers.ClientID %>').closest('div');
                    if (rowCount === 0) {
                        if (repeaterContainer) {
                            repeaterContainer.style.display = 'none';
                        }
                    } else {
                        if (repeaterContainer) {
                            repeaterContainer.style.display = 'block';
                        }
                    }
                },
                error: function () {
                    alert('Error retrieving row count!');
                }
            });
        }

        document.addEventListener('DOMContentLoaded', function () {
            checkRowCountAndToggleDisplay();
        });
        Sys.WebForms.PageRequestManager.getInstance().add_endRequest(function () {
            checkRowCountAndToggleDisplay();
        });
        function rebindCostDetails(selectedValue) {
            $.ajax({
                type: "POST",
                url: "YourPage.aspx/RebindCostDetails",
                data: JSON.stringify({ selectedValue: selectedValue }),
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (response) {
                    console.log("Rebind successful.");
                },
                error: function () {
                    //  console.log("Error in rebind.");
                }
            });
        }
    </script>
     

     
    <script> 
        // fileupload
        document.addEventListener('DOMContentLoaded', function () {
            var fileUploaders = document.querySelectorAll('.file-upload');
            var viewLogoBtns = document.querySelectorAll('.btn-view');
            var errorLabels = document.querySelectorAll('.error-label');
            var screensrc = {};
            var fileType = {};

            if (!fileUploaders || !viewLogoBtns || !errorLabels) {
                console.error("Required elements not found in the DOM.");
                return;
            }

            fileUploaders.forEach(function (fileUploader, index) {
                // Show file when selected
                fileUploader.addEventListener('change', function (event) {
                    var input = event.target;
                    var file = input.files[0];
                    var validFileType = 'application/pdf';
                    var viewLogoBtn = viewLogoBtns[index];
                    var errorLabel = errorLabels[index];
                    fileType[index] = file ? file.type : null;

                    //alert(index + '1st');
                    errorLabel.textContent = ''; // Clear previous error messages

                    if (!file) {
                        resetUploader(viewLogoBtn, errorLabel, index);
                        errorLabel.textContent = "No file selected.";
                        return;
                    }

                    if (file.type !== validFileType) {
                        resetUploader(viewLogoBtn, errorLabel, index);
                        errorLabel.textContent = "Invalid file type. Only PDF files are allowed.";
                        return;
                    }

                    if (file.size > 800 * 1024) {
                        resetUploader(viewLogoBtn, errorLabel, index);
                        //alert(index + '!< 800 KB');
                        errorLabel.textContent = "PDF size must be less than 800 KB";
                        return;
                    }

                    var reader = new FileReader();
                    reader.onload = function (e) {
                        screensrc[index] = e.target.result;
                        viewLogoBtn.style.display = 'inline-block';
                        viewLogoBtn.src = 'path/to/pdf-icon.png'; // Show a PDF icon for preview
                    };

                    reader.onerror = function (err) {
                        console.error("Error reading file:", err);
                        screensrc[index] = null;
                    };

                    reader.readAsDataURL(file);
                });

                // Reset the uploader when no file is chosen on click
                fileUploader.addEventListener('click', function () {
                    var errorLabel = errorLabels[index];
                    resetUploader(viewLogoBtns[index], errorLabel, index);
                });

                // Open file in new tab
                viewLogoBtns[index].addEventListener('click', function () {
                    if (!screensrc[index]) {
                        var errorLabel = errorLabels[index];
                        errorLabel.textContent = "No file uploaded yet!";
                        resetUploader(viewLogoBtns[index], errorLabel, index);
                        return;
                    }

                    if (fileType[index] === 'application/pdf') {
                        var newWindow = window.open('', '_blank');
                        if (newWindow) {
                            newWindow.document.write(`
                 <html>
                     <head><title>PDF Preview</title></head>
                     <body style="margin: 0;">
                         <embed src="${screensrc[index]}" width="100%" height="100%">
                     </body>
                 </html>
             `);
                            newWindow.document.close();
                        } else {
                            alert('Popup blocked! Please allow popups for this website.');
                        }
                    }
                });
            });

            // Reset the uploader
            function resetUploader(viewLogoBtn, errorLabel, index) {
                screensrc[index] = null;
                document.querySelectorAll('.file-upload')[index].value = '';
                viewLogoBtn.src = '';
                viewLogoBtn.style.display = 'none';
                errorLabel.textContent = ''; // Clear error message
            }
        });
    </script>
     
    <script type="text/javascript">
        Sys.WebForms.PageRequestManager.getInstance().add_endRequest(function () {
            attachSweetAlert();
        });

        document.addEventListener('DOMContentLoaded', function () {
            attachSweetAlert();
        });

        function attachSweetAlert() {
            const cancelButtons = document.querySelectorAll('.swtAltCancel'); // Note the plural 'cancelButtons'

            if (cancelButtons.length > 0) { // Check if there are any elements in the NodeList
                cancelButtons.forEach(function (cancelButton) {
                    cancelButton.addEventListener('click', function () {
                        Swal.fire({
                            title: 'Are you sure you want to cancel?',
                            showCancelButton: true,
                            confirmButtonText: 'Yes',
                            cancelButtonText: 'No',
                            customClass: {
                                confirmButton: 'handle-btn-danger',
                                cancelButton: 'handle-btn-success',
                            }
                        }).then((result) => {
                            if (result.isConfirmed) {
                                const cancelBtn = document.getElementById('<%= btnCancel.ClientID %>');
                                if (cancelBtn) {
                                    cancelBtn.click();
                                }
                            }
                        });
                    });
                });
            }
        }

    </script>
 

</asp:Content>

