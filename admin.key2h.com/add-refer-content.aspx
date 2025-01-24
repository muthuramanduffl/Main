<%@ Page Title="" Language="C#" MasterPageFile="AdminKey2h.master" AutoEventWireup="true" CodeFile="add-refer-content.aspx.cs" Inherits="adminkey2hcom_AddReferContent" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
        <!-- jQuery UI library -->
        <link rel="stylesheet" href="https://code.jquery.com/ui/1.12.1/themes/base/jquery-ui.css">
        <link rel="stylesheet" href="assets/css/dtsel.css" />
        <style>
            .btn-view-pop {
                top: 5px;
            }
        </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="content">
        <div class="panel-header bg-primary-gradient">
            <div class="page-inner py-5">
                <div class="d-flex pb-2 align-items-left align-items-sm-center flex-column flex-sm-row justify-content-between">
                    <div class="d-flex">
                        <h2 class="text-white mb-0 fw-bold text-uppercase"> <asp:Label ID="lbldisplaymsg" runat="server" Text=""></asp:Label> 
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
                                        <h3>Refer Content Details</h3>
                                    </div>
                                    <div class="row mx-0 margin-top20 mb-4">
                                        <div class="col-sm-4 col-xl-3 pt-3">
                                            <asp:UpdatePanel ID="UpdatePanel1" runat="server" RenderMode="Block" UpdateMode="Conditional" ChildrenAsTriggers="true">
                                                <ContentTemplate>
                                                    <div class="input-icon input-icon-sm right">
                                                        <label>Project Name <span class="text-danger">*</span></label>
                                                        <i class="bi bi-journal-bookmark-fill b5-icon"></i>
                                                        <asp:DropDownList ID="ddlProName" AutoPostBack="true" class="bs-select form-control input-sm" runat="server"> 
                                                        </asp:DropDownList>
                                                    </div>
                                                    <span class="error">
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ValidationGroup="projval"
                                                            ControlToValidate="ddlProName" InitialValue="" ErrorMessage="Select project name">
                                                        </asp:RequiredFieldValidator>
                                                    </span>
                                                </ContentTemplate>
                                                <Triggers>
                                                    <asp:AsyncPostBackTrigger ControlID="ddlProName" EventName="SelectedIndexChanged" /> 
                                                </Triggers>
                                            </asp:UpdatePanel>
                                        </div>
                                         
                                        <div class="col-sm-4 col-xl-3 pt-3 ">
                                            <div class="input-icon input-icon-sm right">
                                                <label>Image Upload <span class="text-danger">*</span></label>
                                                <i class="bi bi-images b5-icon"></i>
                                                <asp:FileUpload ID="FluploadImageUpload" ClientIDMode="Static" accept=".jpeg, .jpg, .png" onchange="showMyImage1(this)" class="form-control input-sm FluploadImageUpload" autocomplete="off" placeholder="" runat="server" />
                                                <span class="handle-file-request">(max file size of 500 KB)</span>
                                                <asp:HiddenField ID="hdnImageUpload" runat="server" />
                                            </div> 
                                            <div class="view-pro-screen-img view-pro-screen btn-view-pop btn-view-Photo1" runat="server" id="viewpflphoto" style="display: none">
                                                <i class="bi bi-eye"></i>View Image
                                            </div>
                                            <span class="error">
                                                <asp:Label ID="lblFluploadImageUpload" CssClass="lblFluploadImageUpload" runat="server" ForeColor="#d41111" Text=""></asp:Label>
                                             </span>
                                            <span class="error">
                                                <asp:RequiredFieldValidator EnableClientScript="true" SetFocusOnError="true" ControlToValidate="FluploadImageUpload" ValidationGroup="projval" ID="RequiredFieldValidator5" runat="server" ErrorMessage=" Upload image "></asp:RequiredFieldValidator>
                                            </span>
                                        </div>
                                        <div class="col-sm-4 col-xl-4 pt-3">
                                            <div class="input-icon input-icon-sm right">
                                                <label>Question <span class="text-danger">*</span></label>
                                                <i class="bi bi-person-raised-hand b5-icon"></i>
                                                <asp:TextBox ID="txtQuestion" ClientIDMode="Static" TextMode="MultiLine" class="form-control capitalize-input" Rows="2" cols="50" placeholder="" runat="server"></asp:TextBox>
                                            <span class="handle-file-request">(maximum 200 characters)</span>
                                            </div>
                                            <span class="error">
                                                <asp:RequiredFieldValidator EnableClientScript="true" SetFocusOnError="true" ControlToValidate="txtQuestion" ValidationGroup="projval" ID="RequiredFieldValidator2" runat="server" ErrorMessage=" Enter question "></asp:RequiredFieldValidator>
                                             </span>
                                        </div>
                                        <div class="col-sm-4 col-xl-4 pt-3">
                                            <div class="input-icon input-icon-sm right">
                                                <label>Brief Content <span class="text-danger">*</span></label>
                                                <i class="bi bi-body-text b5-icon"></i>
                                                <asp:TextBox ID="txtBriefContent" ClientIDMode="Static" TextMode="MultiLine" class="form-control capitalize-input" Rows="2" cols="50" placeholder="" runat="server"></asp:TextBox>
                                            <span class="handle-file-request">(maximum 200 characters)</span>
                                            </div>
                                            <span class="error">
                                                <asp:RequiredFieldValidator EnableClientScript="true" SetFocusOnError="true" ControlToValidate="txtBriefContent" ValidationGroup="projval" ID="RequiredFieldValidator3" runat="server" ErrorMessage=" Enter brief content "></asp:RequiredFieldValidator> 
                                            </span>
                                        </div>
                                        <div class="col-sm-4 col-xl-4 pt-3">
                                            <div class="input-icon input-icon-sm right">
                                                <label>Message Content <span class="text-danger">*</span></label>
                                                <i class="bi bi-chat-square-text b5-icon"></i>
                                                <asp:TextBox ID="txtMessageContent" ClientIDMode="Static" TextMode="MultiLine" class="form-control capitalize-input" Rows="2" cols="50" placeholder="" runat="server"></asp:TextBox>
                                            <span class="handle-file-request">(maximum 200 characters)</span>
                                            </div>
                                            <span class="error">
                                                <asp:RequiredFieldValidator EnableClientScript="true" SetFocusOnError="true" ControlToValidate="txtMessageContent" ValidationGroup="projval" ID="RequiredFieldValidator4" runat="server" ErrorMessage=" Enter message content "></asp:RequiredFieldValidator>
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
                                    runat="server" OnClick="btnSave_Click"
                                    Text="Submit" ValidationGroup="projval"
                                    class="btn btn-sm handle-btn-success me-1 swtAltSubmit btnSave"
                                    OnClientClick="if (validatePage()) { this.value='Please wait..'; this.style.display='none'; document.getElementById('bWait').style.display = ''; } else { return false; }" Style="min-width: 67px;" />
                                <button type="button" style="display: none" id="bWait" class="btn btn-secondary btn-sm me-1"><i class='fa fa-spinner fa-spin'></i>Please wait</button>
                                <div class="btn btn-sm handle-btn-danger swtAltCancel">Cancel</div>
                                <asp:Button ID="btnCancel" runat="server" Text="Cancel Project" OnClick="btnCancel_Click" Style="display: none;" />
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

    <script src="https://cdnjs.cloudflare.com/ajax/libs/pdf.js/2.10.377/pdf.min.js"></script> 
    <!-- Date Picker -->
    <script src="assets/js/dtsel.js"></script>

    <script type="text/javascript">
        function validatePage() {
            var flag = Page_ClientValidate('projval')
            return flag;
        }
        document.getElementById('<%= txtQuestion.ClientID %>').addEventListener('input', function (e) {
            if (this.value.length > 200) {
                this.value = this.value.substring(0, 200);
            }
        });
        document.getElementById('<%= txtBriefContent.ClientID %>').addEventListener('input', function (e) {
            if (this.value.length > 200) {
                this.value = this.value.substring(0, 200);
            }
        });
        document.getElementById('<%= txtMessageContent.ClientID %>').addEventListener('input', function (e) {
            if (this.value.length > 200) {
                this.value = this.value.substring(0, 200);
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
                        confirmButton: 'handle-btn-danger',
                        cancelButton: 'handle-btn-success',
                    }
                }).then((result) => {
                    if (result.isConfirmed) { 
                        document.getElementById('<%= btnCancel.ClientID %>').click();
                 } else if (result.dismiss === Swal.DismissReason.cancel) {
                     // You can continue with your flat details submission 
                 }
             });
         });
     });
      
        //logo fileupload
        function showMyImage1(fileInput) {
            var lbl = document.querySelector('.lblFluploadImageUpload');
            var files = fileInput.files;
            var allowedFiles = [".png", ".jpg", ".jpeg"];

            if (files.length === 0) {
                //resetImageDisplay();
                var viewLogoBtn = document.querySelector('.view-pro-screen-img');
                viewLogoBtn.style.display = 'none';
                return;
            }

            for (var i = 0; i < files.length; i++) {
                var file = files[i];
                var ext = file.name.split('.').pop().toLowerCase(); 
                if (allowedFiles.includes("." + ext)) {
                    var size = parseFloat(file.size / 1024).toFixed(2); // Size in KB
                    if (size > 500) {
                        lbl.textContent = "Image size must be under 500 KB";
                        //alert();
                        resetFileInput(fileInput);
                        var viewLogoBtn = document.querySelector('.view-pro-screen-img');
                        viewLogoBtn.style.display = 'none';
                        //resetImageDisplay();
                        return;
                    } else {
                        var lbl = document.querySelector('.lblFluploadImageUpload');
                        lbl.textContent = "";
                        var viewLogoBtn = document.querySelector('.view-pro-screen-img');
                        viewLogoBtn.style.display = 'inline-block';
                    }
                } else {
                    alert("Select .png, .jpg, or .jpeg files only.");
                    resetFileInput(fileInput);
                    //resetImageDisplay();
                }
            }
        }

        function resetFileInput(fileInput) {
            fileInput.value = ''; 
        }

    </script>

    <script type="text/javascript">
        //-- view pro-screen img with popup  
        document.addEventListener('DOMContentLoaded', function () { 
            var fileUploader = document.querySelector('.FluploadImageUpload');
            var viewLogoBtn = document.querySelector('.view-pro-screen-img');
            var screensrc;
            if (!fileUploader || !viewLogoBtn) {
                console.error("Required elements not found in the DOM.");
                return;
            }
            screensrc = null;
            fileUploader.addEventListener('change', function (event) {
                var file = event.target.files[0]; 
                if (file) {
                    var reader = new FileReader(); 
                    reader.onload = function (e) { 
                        screensrc = e.target.result; 
                        viewLogoBtn.src = screensrc;
                        viewLogoBtn.style.display = 'inline-block';
                    }; 
                    reader.onerror = function (err) {
                        console.error("Error reading file:", err);
                        screensrc = null;
                    }; 
                    reader.readAsDataURL(file);
                } else { 
                    screensrc = null;
                    viewLogoBtn.src = '';
                    viewLogoBtn.style.display = 'none';
                    //alert("No file selected.");
                }
            });
            viewLogoBtn.addEventListener('click', function () {
                if (!screensrc) { 
                    // alert("No image uploaded yet!");
                    return;
                }
                Swal.fire({
                    html: `
             <div style="position: relative;">
                 <div class="btn-close-icon" style="cursor: pointer; position: absolute; top: -15px; right: -25px;">&times;</div>
                 <h2 class="fw-bold">Image</h2>
                 <img id="swalImage" src="" alt="Image" class="img-fluid mt-3">
             </div>
         `,
                    showConfirmButton: false,
                    didOpen: () => { 
                        document.getElementById('swalImage').src = screensrc;
                        document.querySelector('.btn-close-icon').addEventListener('click', () => Swal.close());
                    }
                });
            });
        }); 
        //--// view pro-screen img with popup 
    </script>

     <script>
        function setupFileUploader(fileUploaderSelector, viewButtonSelector, labelSelector) {
            const fileUploader = document.querySelector(fileUploaderSelector);
            const viewButton = document.querySelector(viewButtonSelector);
            const label = document.querySelector(labelSelector);
            let screensrc = null; 
            if (!fileUploader || !viewButton || !label) {
                console.error("Required elements not found for selectors:", { fileUploaderSelector, viewButtonSelector, labelSelector });
                return;
            } 
            function resetFileInput() {
                fileUploader.value = '';
                screensrc = null;
                viewButton.style.display = 'none';
            } 
            fileUploader.addEventListener('change', function () {
                const file = fileUploader.files[0];
                const allowedFiles = [".png", ".jpg", ".jpeg"]; 
                if (file) {
                    const ext = file.name.split('.').pop().toLowerCase(); 
                    if (!allowedFiles.includes("." + ext)) {
                        alert("Select .png, .jpg, or .jpeg files only.");
                        resetFileInput();
                        return;
                    } 
                    const size = parseFloat(file.size / 1024).toFixed(2); // Size in KB
                    if (size > 500) {
                        label.textContent = "Image size must be under 500 KB";
                        resetFileInput();
                        return;
                    } 
                    label.textContent = "";
                    const reader = new FileReader();
                    reader.onload = function (e) {
                        screensrc = e.target.result;
                        viewButton.style.display = 'inline-block';
                    }; 
                    reader.onerror = function () {
                        screensrc = null;
                        console.error("Error reading file.");
                    }; 
                    reader.readAsDataURL(file);
                } else {
                    resetFileInput();
                }
            });

            viewButton.addEventListener('click', function () {
                if (!screensrc) {
                    return;
                }
                Swal.fire({
                    html: `
            <div style="position: relative;">
                <div class="btn-close-icon" style="cursor: pointer; position: absolute; top: -15px; right: -25px;">&times;</div>
                <h2 class="fw-bold">Photo</h2>
                <img id="swalImage" src="" alt="Photo" class="img-fluid mt-3">
            </div>
        `,
                    showConfirmButton: false,
                    didOpen: () => {
                        document.getElementById('swalImage').src = screensrc;
                        document.querySelector('.btn-close-icon').addEventListener('click', () => Swal.close());
                    }
                });
            });
        }

        // Initialize file uploaders with unique selectors
        document.addEventListener('DOMContentLoaded', function () {
            setupFileUploader('.FluploadImageUpload', '.btn-view-Photo1', '.lblFluploadImageUpload');
        });

    </script>

<script type="text/javascript">
    window.screensrc = { photo1: [], photo2: [] };  
    function bindImageToPreviewphoto(srclogo, index, type) {
        //console.log("Binding image to preview: ", srclogo, index, type); // Debugging line
        var viewLogoBtns = type === 'photo1' ? document.querySelectorAll('.btn-view-Photo1') : document.querySelectorAll('.btn-view-Photo2');

        if (index !== -1 && viewLogoBtns[index]) {
            screensrc[type] = screensrc[type] || [];
            screensrc[type][index] = srclogo;
            viewLogoBtns[index].style.display = 'inline-block';
            viewLogoBtns[index].src = srclogo; // Show the image preview
        } else {
            console.error("View logo button not found or index is invalid.");
        }
    }
         // Ensure global function is set
         window.bindImageToPreviewphoto = bindImageToPreviewphoto; 
        document.addEventListener('DOMContentLoaded', function () {
            setupFileUploader('.FluploadImageUpload', '.btn-view-Photo1', '.lblFluploadImageUpload');
        }); 
    </script>


</asp:Content>

