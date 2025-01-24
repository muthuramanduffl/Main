<%@ Page Title="" Language="C#" MasterPageFile="/AdminKey2h.master" AutoEventWireup="true" CodeFile="bulkuploadblock.aspx.cs" Inherits="Adminkeyhcombulkuploadblock" %>
 
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <div class="content">
        <div class="panel-header bg-primary-gradient">
            <div class="page-inner py-5">
                <div class="d-flex pb-2 align-items-left align-items-md-center flex-column flex-md-row justify-content-between">
                    <div class="d-flex">
                        <h2 class="text-white mb-0 fw-bold text-uppercase">
                            <asp:Label ID="lbldisplaytext" runat="server" Text=""></asp:Label>
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
                                        <h3>Bulk Block Upload</h3>
                                    </div>
                                    <div class="row mx-0 margin-top20 mb-4">
                                        <div class="col-md-4 pt-3">
                                            <div class="input-icon input-icon-sm right">
                                                <label>Project Name <span class="text-danger">*</span></label>
                                                <i class="bi bi-journal-bookmark-fill b5-icon"></i>
                                                <asp:DropDownList class="bs-select form-control input-sm" ID="ddlprojects" runat="server">
                                                </asp:DropDownList> 
                                            </div>
                                            <span class="error">
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" InitialValue="" ValidationGroup="blockval" ControlToValidate="ddlprojects" runat="server" ErrorMessage=" Select project name"></asp:RequiredFieldValidator>
                                            </span>
                                        </div>

                                        <div class="col-md-4 pt-3">
                                            <div class="input-icon input-icon-sm right">
                                                <label>Bulk Block Upload <span class="text-danger">*</span></label>
                                                <i class="bi bi-images b5-icon"></i>
                                                <asp:FileUpload ID="FluploadProjectScreen" accept=".xls, .xlsx" onchange="validateExcelUpload(this)" class="form-control input-sm FluploadProjectScreen" autocomplete="off" placeholder="" runat="server" />
                                                <span class="handle-file-request">(maximum file size of 5mb)</span> 
                                            </div>
                                            <span class="error">
                                                <asp:Label ID="lblFluploadProjectScreen" CssClass="lblFluploadProjectScreen" runat="server" ForeColor="Red" Text=""></asp:Label>
                                            </span>
                                            <span class="error">
                                                <asp:RequiredFieldValidator ClientIDMode="Static" EnableClientScript="true" SetFocusOnError="true" ControlToValidate="FluploadProjectScreen" ValidationGroup="blockval" ID="RequiredFieldValidator14" runat="server" ErrorMessage="Upload file "></asp:RequiredFieldValidator>
                                            </span>
                                            <div class="text-start">
                                                <p id="viewPdfButton" class="btn-view-pop mb-0" style="display: none"><i class="bi bi-eye"></i>View File</p>
                                                <p id="spRemovepdf" class="btn btn-outline-danger" style="display: none; cursor: pointer; height: 30px; padding: 4px 10px 5px;">Remove File</p>
                                            </div>
                                            <asp:HiddenField ID="hdnpdffile" runat="server" />
                                            <asp:HiddenField ID="hdnpdffileview" runat="server" />
                                        </div>
                                        <asp:Label ID="lblMesg" ForeColor="Green" runat="server"></asp:Label>
                                    </div> 
                                </div>
                            </div> 
                        </div>
                        <div class="card-footer">
                            <div class="d-flex justify-content-center"> 
                                <asp:Button
                                    ID="btnSave" ClientIDMode="Static"
                                    runat="server" OnClick="btnSave_Click"
                                    Text="Submit" ValidationGroup="blockval"
                                    class="btn btn-sm btn-success me-1 swtAltSubmit btnSave"
                                    OnClientClick="if (validatePage()) { this.value='Please wait..'; this.style.display='none'; document.getElementById('bWait').style.display = ''; } else { return false; }" Style="min-width: 67px;" />
                                <button type="button" style="display: none" id="bWait" class="btn btn-secondary btn-sm me-1"><i class='fa fa-spinner fa-spin'></i>Please wait</button>
                                <div class="btn btn-sm btn-danger swtAltCancel">Cancel</div>
                                <asp:Button ID="btnCancel" runat="server" Text="Cancel Project" OnClick="btnCancel_Click" Style="display: none;" /> 
                            </div>
                        </div> 
                    </div>
                </div>
            </div>
        </div> 
    </div>
     
    <script type="text/javascript">
        document.getElementById("toggleActiveInactive").addEventListener("change", function () {
            const isChecked = this.checked;
            const label = document.querySelector("label[for='toggleActiveInactive']");
            if (isChecked) {
                label.classList.add("active");
            } else {
                label.classList.remove("active");
            }
        });
    </script>
     
    <script type="text/javascript">
        function validatePage() { 
            var flag = Page_ClientValidate('blockval') 
            return flag;
        } 
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
                        confirmButton: 'handle-btn-danger',
                        cancelButton: 'handle-btn-success',
                    }
                }).then((result) => {
                    if (result.isConfirmed) { 
                        document.getElementById('<%= btnCancel.ClientID %>').click();
                    } else if (result.dismiss === Swal.DismissReason.cancel) {
                        // User clicked 'No' 
                    }
                });
            });
        });
    </script>











    <script>
        // Function to validate Excel file upload and show "View File" button
        function validateExcelUpload(fileInput) {
            var files = fileInput.files;
            var allowedFiles = [".xls", ".xlsx"]; // Allowed file extensions

            if (files.length > 0) {
                var file = files[0]; // We only consider the first file
                var ext = file.name.split('.').pop().toLowerCase(); // Get file extension

                if (allowedFiles.includes("." + ext)) {
                    var maxSize = 5 * 1024 * 1024; // Max size = 5MB (in bytes)

                    // Check if the file size exceeds 5MB
                    if (file.size > maxSize) {
                        alert("File size is too high, please select a file smaller than 5mb.");
                        resetExcelUpload(); // Reset the form if the file is too large
                    } else {
                        // Show the "Remove File" button
                        document.getElementById("spRemovepdf").style.display = "none";

                        // Create a temporary URL for the uploaded file (use only for visual purposes, don't upload to server yet)
                        var fileURL = URL.createObjectURL(file);
                        setViewFileButton(fileURL);
                    }
                } else {
                    alert("Please select a valid Excel file (.xls or .xlsx).");
                    resetExcelUpload(); // Reset the form if the file type is invalid
                }
            } else {
                resetExcelUpload(); // If no file is selected, reset the form
            }
        }

        // Function to set up the "View File" button
        function setViewFileButton(fileURL) {
            var viewFileButton = document.getElementById("viewPdfButton");

            // Show the "View File" button and set its click event
            viewFileButton.style.display = "inline-block"; 
            viewFileButton.onclick = function () {
                window.open(fileURL, '_blank');
            };
        }

        // Function to reset the UI elements and file input
        function resetExcelUpload() {
            // Hide the "View File" and "Remove File" buttons
            document.getElementById("spRemovepdf").style.display = "none";
            document.getElementById("viewPdfButton").style.display = "none";

            // Reset the file input
            var fileInput = document.getElementById("FluploadProjectScreen");
            fileInput.value = ""; // Reset the file input value


        }

        // Function to handle the "Remove File" button
        function handleRemoveFile() {
            // Reset the file upload input
            resetExcelUpload();


        }

        // Attach event to the "Remove File" button
        document.getElementById("spRemovepdf").addEventListener('click', handleRemoveFile);

        window.onload = function () {
            // Check for any existing file URL
            var hiddenField = document.getElementById("hdnpdffileview");
            var fileURL = hiddenField.value;

            // If there is a file URL, show the "View File" button and "Remove File" button
            if (fileURL) {
                setViewFileButton(fileURL);
                document.getElementById("spRemovepdf").style.display = "none";
            } else {
                resetExcelUpload();
            }
        };
</script>





</asp:Content>

