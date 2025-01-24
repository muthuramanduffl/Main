<%@ Page Title="" Language="C#" MasterPageFile="AdminKey2h.master" AutoEventWireup="true" CodeFile="add-customization-demend1.aspx.cs" Inherits="adminkey2hcom_AddCustomizationDemend1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <style>
        .custom-number-input::-webkit-inner-spin-button,
        .custom-number-input::-webkit-outer-spin-button {
            -webkit-appearance: none;
            margin: 0;
        }
        /* For Firefox */
        .custom-number-input[type="number"] {
            -moz-appearance: textfield;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

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
                                        <h3>Customization Demend Details</h3>
                                    </div>
                                    <div class="row mx-0 margin-top20 mb-4 pt-2">
                                        <div class="col-sm-4 col-xl-3 pt-3">
                                            <asp:HiddenField ID="hdnCostID" runat="server" />
                                            <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
                                                <contenttemplate>
                                                    <div class="input-icon input-icon-sm right">
                                                        <label>Project Name <span class="text-danger">*</span></label>
                                                        <i class="bi bi-journal-bookmark-fill b5-icon"></i>
                                                        <asp:DropDownList ID="ddlProName" AutoPostBack="true" OnSelectedIndexChanged="ddlProName_SelectedIndexChanged" class="bs-select form-control input-sm" runat="server">
                                                            <asp:ListItem Value=""></asp:ListItem>
                                                        </asp:DropDownList>
                                                    </div>
                                                    <span class="error">
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator18" Display="Dynamic" runat="server" ValidationGroup="val"
                                                            ControlToValidate="ddlProName" InitialValue="" ErrorMessage="Select project name">
                                                        </asp:RequiredFieldValidator>
                                                    </span>
                                                </contenttemplate>
                                                <triggers>
                                                    <asp:PostBackTrigger ControlID="btnAdd" />
                                                    <asp:AsyncPostBackTrigger ControlID="ddlProName" EventName="SelectedIndexChanged" />
                                                    <asp:AsyncPostBackTrigger ControlID="ddlBlockNumber" EventName="SelectedIndexChanged" />
                                                    <asp:AsyncPostBackTrigger ControlID="ddlFlatNumber" EventName="SelectedIndexChanged" />
                                                    <asp:AsyncPostBackTrigger ControlID="btnCancel" EventName="click" />
                                                </triggers>
                                            </asp:UpdatePanel>
                                        </div>

                                        <div class="col-sm-4 col-xl-3 pt-3">
                                            <asp:UpdatePanel ID="UpdatePanel2" runat="server" UpdateMode="Conditional">
                                                <contenttemplate>
                                                    <div class="input-icon input-icon-sm right">
                                                        <label>Block Name <span class="text-danger">*</span></label>
                                                        <i class="bi bi-building b5-icon"></i>
                                                        <asp:DropDownList ID="ddlBlockNumber" AutoPostBack="true" OnSelectedIndexChanged="ddlBlockNumber_SelectedIndexChanged" class="bs-select form-control input-sm" runat="server">
                                                        </asp:DropDownList>
                                                    </div>
                                                    <span class="error">
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator17" Display="Dynamic" runat="server" ValidationGroup="val"
                                                            ControlToValidate="ddlBlockNumber" InitialValue="" ErrorMessage="Select block name">
                                                        </asp:RequiredFieldValidator>
                                                    </span>
                                                </contenttemplate>
                                                <triggers>
                                                    <asp:PostBackTrigger ControlID="btnAdd" />
                                                    <asp:AsyncPostBackTrigger ControlID="ddlProName" EventName="SelectedIndexChanged" />
                                                    <asp:AsyncPostBackTrigger ControlID="ddlBlockNumber" EventName="SelectedIndexChanged" />
                                                    <asp:AsyncPostBackTrigger ControlID="ddlFlatNumber" EventName="SelectedIndexChanged" />
                                                    <asp:AsyncPostBackTrigger ControlID="btnCancel" EventName="click" />
                                                </triggers>
                                            </asp:UpdatePanel>
                                        </div>
                                        <div class="col-sm-4 col-xl-3 pt-3">
                                            <asp:UpdatePanel ID="UpdatePanel3" runat="server" UpdateMode="Conditional">
                                                <contenttemplate>
                                                    <div class="input-icon input-icon-sm right">
                                                        <label>Flat Number <span class="text-danger">*</span></label>
                                                        <i class="bi bi-file-binary b5-icon"></i>
                                                        <asp:DropDownList ID="ddlFlatNumber" AutoPostBack="true" ClientIDMode="Static" OnSelectedIndexChanged="ddlFlatNumber_SelectedIndexChanged" class="bs-select form-control input-sm" runat="server">
                                                        </asp:DropDownList>
                                                    </div>
                                                    <span class="error">
                                                        <asp:RequiredFieldValidator ClientIDMode="Static" Display="Dynamic" EnableClientScript="true" SetFocusOnError="true" ControlToValidate="ddlFlatNumber" ValidationGroup="val" ID="RequiredFieldValidator13" runat="server" ErrorMessage="Select flat no. "></asp:RequiredFieldValidator>
                                                    </span>
                                                </contenttemplate>
                                                <triggers>
                                                    <asp:PostBackTrigger ControlID="btnAdd" />
                                                    <asp:AsyncPostBackTrigger ControlID="ddlProName" EventName="SelectedIndexChanged" />
                                                    <asp:AsyncPostBackTrigger ControlID="ddlBlockNumber" EventName="SelectedIndexChanged" />
                                                    <asp:AsyncPostBackTrigger ControlID="ddlFlatNumber" EventName="SelectedIndexChanged" />
                                                    <asp:AsyncPostBackTrigger ControlID="btnCancel" EventName="click" />
                                                </triggers>
                                            </asp:UpdatePanel>

                                        </div>
                                        <div class="col-sm-4 col-xl-3 pt-3">
                                            <asp:UpdatePanel ID="UpdatePanel4" runat="server" UpdateMode="Conditional">
                                                <contenttemplate>
                                                    <div class="input-icon input-icon-sm right">
                                                        <label>Customer Name </label>
                                                        <i class="bi bi-person-square b5-icon"></i>
                                                        <asp:TextBox runat="server" ID="txtCustomerName" class="form-control input-sm" ReadOnly="true" EnableViewState="true" autocomplete="off" placeholder=""></asp:TextBox>
                                                    </div>
                                                    <asp:Label ID="lblcustomernameerror" ClientIDMode="Static" class="align-items-center text-center error" runat="server" Text=""></asp:Label>
                                                </contenttemplate>
                                                <triggers>
                                                    <asp:PostBackTrigger ControlID="btnAdd" />
                                                    <asp:AsyncPostBackTrigger ControlID="ddlProName" EventName="SelectedIndexChanged" />
                                                    <asp:AsyncPostBackTrigger ControlID="ddlBlockNumber" EventName="SelectedIndexChanged" />
                                                    <asp:AsyncPostBackTrigger ControlID="ddlFlatNumber" EventName="SelectedIndexChanged" />
                                                    <asp:AsyncPostBackTrigger ControlID="btnCancel" EventName="click" />
                                                </triggers>
                                            </asp:UpdatePanel>
                                        </div>

                                        <div class="col-sm-4 col-xl-3 pt-3">
                                            <asp:UpdatePanel ID="UpdatePanel5" runat="server" UpdateMode="Conditional">
                                                <contenttemplate>
                                                    <div class="input-icon input-icon-sm right">
                                                        <label>Work List <span class="text-danger">*</span></label>
                                                        <i class="bi bi-journal-text b5-icon"></i>
                                                        <asp:DropDownList ID="ddlWorkList" AutoPostBack="true" OnSelectedIndexChanged="ddlWorkList_SelectedIndexChanged" class="bs-select form-control input-sm" runat="server">
                                                            <asp:ListItem Value=""></asp:ListItem>
                                                        </asp:DropDownList>
                                                    </div>
                                                    <span class="error">
                                                        <asp:RequiredFieldValidator ClientIDMode="Static" Display="Dynamic" ControlToValidate="ddlWorkList" ValidationGroup="val" ID="RegularExpressionValidator11" runat="server" ErrorMessage="Select work list"></asp:RequiredFieldValidator>
                                                    </span>
                                                </contenttemplate>
                                                <triggers>
                                                    <asp:PostBackTrigger ControlID="btnAdd" />
                                                    <asp:AsyncPostBackTrigger ControlID="ddlProName" EventName="SelectedIndexChanged" />
                                                    <asp:AsyncPostBackTrigger ControlID="ddlBlockNumber" EventName="SelectedIndexChanged" />
                                                    <asp:AsyncPostBackTrigger ControlID="ddlFlatNumber" EventName="SelectedIndexChanged" />
                                                    <asp:AsyncPostBackTrigger ControlID="ddlWorkList" EventName="SelectedIndexChanged" />
                                                    <asp:AsyncPostBackTrigger ControlID="btnCancel" EventName="click" />
                                                </triggers>
                                            </asp:UpdatePanel>
                                        </div>

                                        <div class="col-sm-4 col-xl-3 pt-3">
                                            <asp:UpdatePanel ID="UpdatePanel8" runat="server" UpdateMode="Conditional">
                                                <contenttemplate>
                                                    <div class="input-icon input-icon-sm right">
                                                        <label>Amount <span class="text-danger">*</span></label>
                                                        <i class="bi bi-cash-stack b5-icon"></i>
                                                        <asp:TextBox runat="server" ID="txtAmount" EnableViewState="true" ReadOnly="true" MaxLength="10" class="form-control input-sm input-value" autocomplete="off"></asp:TextBox>
                                                    </div>
                                                </contenttemplate>
                                                <triggers>
                                                    <asp:PostBackTrigger ControlID="btnAdd" />
                                                    <asp:AsyncPostBackTrigger ControlID="ddlProName" EventName="SelectedIndexChanged" />
                                                    <asp:AsyncPostBackTrigger ControlID="ddlBlockNumber" EventName="SelectedIndexChanged" />
                                                    <asp:AsyncPostBackTrigger ControlID="ddlFlatNumber" EventName="SelectedIndexChanged" />
                                                    <asp:AsyncPostBackTrigger ControlID="ddlWorkList" EventName="SelectedIndexChanged" />
                                                    <asp:AsyncPostBackTrigger ControlID="btnCancel" EventName="click" />
                                                </triggers>
                                            </asp:UpdatePanel>
                                        </div>
                                        <div class="col-sm-4 col-xl-3 pt-3">
                                            <div class="input-icon input-icon-sm right">
                                                <label>Upload <span class="text-danger">*</span></label>
                                                <i class="bi bi-file-earmark-zip b5-icon"></i>
                                                <asp:FileUpload ID="flDemandUpload" ClientIDMode="Static" accept=".pdf" class="form-control input-sm FluploadPDF" autocomplete="off" placeholder="" runat="server" />
                                                <span class="handle-file-request">(PDF file only, max size of 800 KB)</span>
                                            </div>
                                            <asp:HiddenField ID="hdndemandUpload" runat="server" />
                                            <span class="error">
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ValidationGroup="val" Display="Dynamic"
                                                    ControlToValidate="flDemandUpload" InitialValue="" ErrorMessage="Upload PDF">
                                                </asp:RequiredFieldValidator>
                                                <asp:Label ID="lblflDemandUpload" CssClass="lblflDemandUpload " runat="server" ForeColor="#d41111" Text="" Display="Dynamic"></asp:Label>
                                            </span>
                                            <span class="error"></span>
                                            <div class="mt-3 ViewFluploadPDF btn-view-pop" runat="server" id="viewproscreenbtn" style="display: none">
                                                <i class="bi bi-eye"></i>View PDF
                                            </div>
                                        </div>


                                        <!-- Display Added Values -->
                                        <div class="added-values"></div>
                                    </div>
                                    <div class="card-footer mx-2 pb-4">
                                        <div class="d-flex justify-content-center">
                                            <asp:UpdatePanel ID="UpdatePanel9" runat="server" UpdateMode="Conditional">
                                                <contenttemplate>
                                                    <asp:LinkButton ID="btnAdd" OnClientClick="if (validatePage1()) { this.value='Please wait..'; this.style.display='none'; document.getElementById('bWait1').style.display = ''; } else { return false; }" OnClick="btnAdd_Click" runat="server" class="btn btn-sm handle-btn-success add-btn">
                                                        Submit
                                                    </asp:LinkButton>
                                                    <button type="button" style="display: none" id="bWait1" class="btn btn-secondary btn-sm me-1"><i class='fa fa-spinner fa-spin'></i>Please wait</button>
                                                    <div class="btn btn-sm handle-btn-danger swtAltCancel ms-1">Cancel</div>
                                                    <asp:Button ID="btnCancel" ClientIDMode="Static" runat="server" Text="Cancel Project" OnClick="btnCancel_Click" Style="display: none;" />

                                                </contenttemplate>
                                                <triggers>
                                                    <asp:PostBackTrigger ControlID="btnAdd" />
                                                    <asp:AsyncPostBackTrigger ControlID="ddlProName" EventName="SelectedIndexChanged" />
                                                    <asp:AsyncPostBackTrigger ControlID="ddlBlockNumber" EventName="SelectedIndexChanged" />
                                                    <asp:AsyncPostBackTrigger ControlID="ddlFlatNumber" EventName="SelectedIndexChanged" />
                                                    <asp:AsyncPostBackTrigger ControlID="ddlWorkList" EventName="SelectedIndexChanged" />
                                                    <asp:AsyncPostBackTrigger ControlID="btnCancel" EventName="click" />
                                                </triggers>
                                            </asp:UpdatePanel>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <asp:UpdatePanel ID="UpdatePanel7" runat="server">
                                <contenttemplate>
                                    <div class="form-group" id="divrptCustomers" clientidmode="Static" runat="server">
                                        <div class="form-border margin-top20">
                                            <div class="form-title">
                                                <h3>View Customization Details</h3>
                                            </div>
                                            <div class="table-responsive pt-4 mt-md-2 mt-0 px-4">

                                                <asp:Repeater ID="rptCustomizationdemand" runat="server">
                                                    <headertemplate>
                                                        <table class="table table-bordered" id="Customizationdemand">
                                                            <thead>
                                                                <th># </th>
                                                                <th>Work Title </th>
                                                                <th>Amount</th>
                                                                <th>View PDF</th>
                                                                <th>Action</th>
                                                            </thead>
                                                            <tbody>
                                                    </headertemplate>
                                                    <itemtemplate>
                                                        <tr>
                                                            <td><%# GetRowNo(Convert.ToString(Container.ItemIndex + 1))%> </td>
                                                            <td>
                                                                <asp:HiddenField ID="hdnCDemandID" Value='<%# Eval("CDemandID") %>' runat="server" />
                                                                <label class="lblWorkTitle"><%# Eval("WorkTitle") %></label>

                                                            </td>


                                                            <td>
                                                                <div class="lblAmount">
                                                                    <p><%#"₹" + Eval("Amount") %></p>
                                                                </div>
                                                            </td>
                                                            <td>
                                                            <div class="view-pdf btn-view" id="viewPdf<%# Container.ItemIndex %>">
                                                                <a target="_blank" href='<%# "/CustomizationDemandDoc/"+Eval("PDFName") %>' class="btn-view btnview-pdf" data-bs-toggle="tooltip" title="View">
                                                                    <i class="bi bi-eye b5-icon-et-dlt"></i>
                                                                </a>
                                                            </div>
                                                            </td>
                                                            <td>
                                                                <a href="javascript:void(0);" class="btnDelete" onclick="deleteRow(this)"><i class="bi bi-trash b5-icon-et-dlt me-3" data-bs-toggle="tooltip" title="Delete"></i></a>
                                                            </td>
                                                        </tr>
                                                    </itemtemplate>
                                                    <footertemplate>
                                                        </tbody>
                                                        </table>
                                                    </footertemplate>
                                                </asp:Repeater>

                                            </div>
                                        </div>
                                    </div>
                                </contenttemplate>
                                <triggers>
                                    <asp:PostBackTrigger ControlID="btnAdd" />
                                    <asp:AsyncPostBackTrigger ControlID="ddlProName" EventName="SelectedIndexChanged" />
                                    <asp:AsyncPostBackTrigger ControlID="ddlBlockNumber" EventName="SelectedIndexChanged" />
                                    <asp:AsyncPostBackTrigger ControlID="ddlFlatNumber" EventName="SelectedIndexChanged" />

                                    <asp:AsyncPostBackTrigger ControlID="btnCancel" EventName="click" />
                                </triggers>
                            </asp:UpdatePanel>
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
            var flag = Page_ClientValidate('val');
            return flag;
        }
    </script>

    <script type="text/javascript"> 
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
                    const hiddenField = row.querySelector('input[type="hidden"]');
                    const CDemandID = hiddenField ? hiddenField.value : '';

                    if (!CDemandID) {
                        alert('CustomDemandID is missing!');
                        return;
                    }
                    var dropflatname = document.getElementById('<%= ddlFlatNumber.ClientID %>');
                    var selectedValue = dropflatname ? dropflatname.value : '';
                    $.ajax({
                        type: 'POST',
                        url: 'add-customization-demend.aspx/DeleteCustomisationDemands',
                        data: JSON.stringify({ CDemandID: CDemandID, selectedValue: selectedValue }),
                        contentType: 'application/json; charset=utf-8',
                        dataType: 'json',
                        success: function (response) {
                            row.remove();

                            const table = document.getElementById('Customizationdemand');
                            const rows = table.querySelectorAll('tbody tr');
                            if (rows.length === 0) {
                                const repeaterContainer = document.getElementById('<%= divrptCustomers.ClientID %>').closest('div');
                                if (repeaterContainer) {
                                    repeaterContainer.style.display = 'none';
                                }
                            }

                            if (response.d == "1") {
                                Swal.fire({
                                    title: 'Customization demand details have been deleted as requested', confirmButtonText: 'Ok',
                                    customClass: {
                                        confirmButton: 'handle-btn-success'
                                    },
                                });
                            }
                            else {
                                Swal.fire({
                                    title: 'Customization demand details have been not deleted as requested', confirmButtonText: 'Ok',
                                    customClass: {
                                        confirmButton: 'handle-btn-success'
                                    },
                                });
                            }


                            loadRepeaterData(selectedValue);
                        },
                        error: function () {
                            alert('Error deleting row!');
                        }
                    });
                } else {
                    return;
                }
            });
        }




    </script>

    <script type="text/javascript">
        document.addEventListener('DOMContentLoaded', function () {
            function initializeFileUpload() {
                var fileUploader = document.querySelector('.FluploadPDF');
                var viewLogoBtn = document.querySelector('.ViewFluploadPDF');
                var errorLabel = document.querySelector('.lblflDemandUpload');
                var screensrc = null;
                var fileType = null;
                if (!fileUploader || !viewLogoBtn || !errorLabel) {
                    console.error("Required elements not found in the DOM.");
                    return;
                }

                function resetUploader() {
                    screensrc = null;
                    fileType = null;
                    viewLogoBtn.style.display = 'none';
                    errorLabel.textContent = '';
                }

                fileUploader.addEventListener('change', function (event) {
                    var input = event.target;
                    var file = input.files[0];
                    var validFileType = 'application/pdf';
                    errorLabel.textContent = '';

                    if (!file) {
                        resetUploader();
                        errorLabel.textContent = "No file selected.";
                        return;
                    }
                    if (file.type !== validFileType) {
                        resetUploader();
                        errorLabel.textContent = "Invalid file type. Only PDF files are allowed.";
                        return;
                    }
                    if (file.size > 800 * 1024) { // 800 KB
                        resetUploader();
                        errorLabel.textContent = "FIle size must be less than 800 KB";
                        return;
                    }
                    var reader = new FileReader();
                    reader.onload = function (e) {
                        screensrc = e.target.result;
                        fileType = file.type;
                        viewLogoBtn.style.display = 'inline-block';
                        viewLogoBtn.src = 'path/to/pdf-icon.png'; // Adjust this to the actual icon path
                    };
                    reader.onerror = function (err) {
                        console.error("Error reading file:", err);
                        resetUploader();
                    };
                    reader.readAsDataURL(file);
                });

                fileUploader.addEventListener('click', function () {
                    resetUploader();
                });

                viewLogoBtn.addEventListener('click', function () {
                    if (!screensrc) {
                        errorLabel.textContent = "No file uploaded yet!";
                        resetUploader();
                        return;
                    }
                    if (fileType === 'application/pdf') {
                        var newWindow = window.open('', '_blank');
                        if (newWindow) {
                            newWindow.document.write(`
                        <html>
                            <head><title>PDF Preview</title></head>
                            <body style="margin: 0;">
                                <embed src="${screensrc}" width="100%" height="100%">
                            </body>
                        </html>
                    `);
                            newWindow.document.close();
                        } else {
                            alert('Popup blocked! Please allow popups for this website.');
                        }
                    }
                });
            }
            initializeFileUpload();
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
            const cancelButton = document.querySelector('.swtAltCancel');
            if (cancelButton) {
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
            }
        }
    </script>



    <script type="text/javascript">
        function loadRepeaterData(selectedValue) {
            $.ajax({
                type: 'POST',
                url: 'add-customization-demend.aspx/GetCostDetails',
                data: JSON.stringify({ selectedValue: selectedValue }),
                contentType: 'application/json; charset=utf-8',
                dataType: 'json',
                success: function (response) {
                    if (response && response.d) {
                        // console.log(response.d);
                        const data = response.d;
                        const repeaterBody = document.querySelector('#Customizationdemand tbody');
                        if (repeaterBody) {
                            repeaterBody.innerHTML = '';
                        }
                        data.forEach(function (item, index) {
                            const row = document.createElement('tr');
                            row.innerHTML = `
                  <td>${index + 1}</td>
                 
                

                  <td> <input type="hidden" id="hdnCDemandID" ClientIDMode="Static" value="${item.CDemandID}" />
                  <label class="lblWorkTitle">${item.WorkTitle}</label>
                  </td>
                    
                
                   <td><div class="lblAmount"> <p>₹${item.Amount}</p></div></td>
               
                   <td>
                    <div class="view-pdf btn-view" id="viewPdf${index}">
                     <a target="_blank" href="/CustomizationDemandDoc/${item.PDFName}" class="btn btn-view btnview-pdf" data-bs-toggle="tooltip" title="View">
                      <i class="bi bi-eye b5-icon-et-dlt"></i>
                     </a>
                    </div>
                    </td> 
                  <td>
                      <a href="javascript:void(0);" class="btnDelete" onclick="deleteRow(this)">
                          <i class="bi bi-trash b5-icon-et-dlt" data-bs-toggle="tooltip" title="Delete"></i>
                      </a>
                  </td> `;
                            repeaterBody.appendChild(row);
                        });

                        // Initialize tooltips
                        const tooltipTriggerList = [].slice.call(document.querySelectorAll('[data-bs-toggle="tooltip"]'));
                        tooltipTriggerList.forEach(function (tooltipTriggerEl) {
                            new bootstrap.Tooltip(tooltipTriggerEl);
                        });

                        // Toggle visibility of the repeater container
                        const repeaterContainer = document.getElementById('<%= divrptCustomers.ClientID %>');
                        if (repeaterContainer) {
                            repeaterContainer.style.display = data.length ? 'block' : 'none';
                        }
                    }
                },
                error: function () {
                    alert('Error loading repeater data!');
                }
            });
        }
    </script>


</asp:Content>



