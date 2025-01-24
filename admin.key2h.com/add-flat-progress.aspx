<%@ Page Title="" Language="C#" MasterPageFile="AdminKey2h.master" AutoEventWireup="true" CodeFile="add-flat-progress.aspx.cs" Inherits="adminkey2hcomaddflatprogress" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <style>
        /* Flexbox container for rows */
        .file-upload-row {
            display: flex;
            align-items: flex-start;
            gap: 15px;
            margin-bottom: 15px;
        }

        /* Button alignment */
        .remove-progress {
            cursor: pointer;
            font-size: 14px;
            margin: 0;
        }
        /* Add button styling */
        .addprogressRows {
            cursor: pointer;
            display: inline-flex;
            align-items: center;
            gap: 5px;
            font-size: 16px;
        }

        .b5-icon-et-dlt {
            font-size: 20px;
        } 
        .image-container {
            text-align: center;
            background-color: #ffffff;
            padding: 20px;
            border-radius: 10px;
            position: relative;
            overflow: hidden;
            height: 50vh;
            display: flex;
            justify-content: center; /* Center the image horizontally */
            align-items: center; /* Center the image vertically */
        }
    </style>

    <!-- multiSelector -->
    <link rel="stylesheet" href="https://cdn.jsdelivr.net/npm/choices.js/public/assets/styles/choices.min.css">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" enctype="multipart/form-data" runat="Server">

    <div class="content">
        <div class="panel-header bg-primary-gradient">
            <div class="page-inner py-5">
                <div class="d-flex pb-2 align-items-left align-items-sm-center flex-column flex-sm-row justify-content-between">
                    <div class="d-flex">
                        <h2 class="text-white mb-0 fw-bold text-uppercase">
                            <asp:Label ID="lbldisplaymsg" runat="server" Text="Label"></asp:Label></h2>
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
                                        <h3>Flat Progress Details</h3>
                                    </div>

                                    <div class="row mx-0 margin-top20 mb-4">

                                        <div class="col-sm-4 col-xl-2 pt-3">
                                            <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
                                                <ContentTemplate>
                                                    <div class="input-icon input-icon-sm right">
                                                        <label>Project Name <span class="text-danger">*</span></label>
                                                        <i class="bi bi-journal-bookmark-fill b5-icon"></i>
                                                        <asp:DropDownList class="bs-select form-control input-sm" AutoPostBack="true" OnSelectedIndexChanged="ddlprojects_SelectedIndexChanged" ID="ddlprojects" runat="server">
                                                        </asp:DropDownList>
                                                    </div>
                                                    <span class="error">
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" InitialValue="" ValidationGroup="projval" ControlToValidate="ddlprojects" runat="server" ErrorMessage=" Select project name"></asp:RequiredFieldValidator>
                                                    </span>
                                                </ContentTemplate>
                                                <Triggers>
                                                    <asp:AsyncPostBackTrigger ControlID="ddlprojects" EventName="SelectedIndexChanged" />

                                                </Triggers>
                                            </asp:UpdatePanel>
                                        </div>
                                        <div class="col-sm-4 col-xl-2 pt-3">
                                            <asp:UpdatePanel ID="UpdatePanel3" runat="server" UpdateMode="Conditional">
                                                <ContentTemplate>
                                                    <div class="input-icon input-icon-sm right">
                                                        <label>Block Name <span class="text-danger">*</span></label>
                                                        <i class="bi bi-building  b5-icon"></i>
                                                        <asp:DropDownList class="bs-select form-control input-sm" ID="ddlBlockName" OnSelectedIndexChanged="ddlblocknumber_SelectedIndexChanged" AutoPostBack="true" runat="server">
                                                        </asp:DropDownList>
                                                    </div>
                                                    <span class="error">
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator7" InitialValue="" ValidationGroup="projval" ControlToValidate="ddlBlockName" runat="server" ErrorMessage=" Select block name"></asp:RequiredFieldValidator>
                                                    </span>
                                                </ContentTemplate>
                                                <Triggers>
                                                    <asp:AsyncPostBackTrigger ControlID="ddlprojects" EventName="SelectedIndexChanged" />
                                                    <asp:AsyncPostBackTrigger ControlID="ddlBlockName" EventName="SelectedIndexChanged" />
                                                    <asp:AsyncPostBackTrigger ControlID="ddlFlatNumbers" EventName="SelectedIndexChanged" />

                                                </Triggers>
                                            </asp:UpdatePanel>
                                        </div>
                                        <div class="col-sm-4 col-xl-2 pt-3">
                                            <asp:UpdatePanel ID="UpdatePanel4" runat="server" UpdateMode="Conditional">
                                                <ContentTemplate>
                                                    <div class="input-icon input-icon-sm right">
                                                        <label>Flat Numbers <span class="text-danger">*</span></label>
                                                        <i class="bi bi-journal-bookmark-fill b5-icon"></i>
                                                        <asp:DropDownList class="form-control input-sm " AutoPostBack="true" OnSelectedIndexChanged="ddlFlatNumbers_SelectedIndexChanged" ID="ddlFlatNumbers" runat="server">
                                                        </asp:DropDownList>
                                                    </div>
                                                    <input type="hidden" id="hiddenSelectedValues" runat="server" />
                                                    <span class="error">
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator8" InitialValue="" ValidationGroup="projval" ControlToValidate="ddlFlatNumbers" runat="server" ErrorMessage=" Select flat no."></asp:RequiredFieldValidator>
                                                    </span>
                                                </ContentTemplate>
                                                <Triggers>
                                                    <asp:AsyncPostBackTrigger ControlID="ddlprojects" EventName="SelectedIndexChanged" />
                                                    <asp:AsyncPostBackTrigger ControlID="ddlBlockName" EventName="SelectedIndexChanged" />
                                                    <asp:AsyncPostBackTrigger ControlID="ddlFlatNumbers" EventName="SelectedIndexChanged" />

                                                </Triggers>
                                            </asp:UpdatePanel>
                                        </div>
                                        <div class="col-sm-4 col-xl-2 pt-3">
                                            <asp:UpdatePanel ID="UpdatePanel5" runat="server" UpdateMode="Conditional">
                                                <ContentTemplate>
                                                    <div class="input-icon input-icon-sm right">
                                                        <label>Month <span class="text-danger">*</span></label>
                                                        <i class="bi bi-calendar-week b5-icon"></i>
                                                        <asp:DropDownList class="bs-select form-control input-sm" AutoPostBack="true" ID="ddlmonth" OnSelectedIndexChanged="ddlmonth_SelectedIndexChanged" runat="server">
                                                            <asp:ListItem Value=""></asp:ListItem>
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
                                                    </div>
                                                    <span class="error">
                                                        <asp:RequiredFieldValidator ClientIDMode="Static" SetFocusOnError="true" EnableClientScript="true" ID="RequiredFieldValidator2" InitialValue="" ValidationGroup="projval" ControlToValidate="ddlmonth" runat="server" ErrorMessage=" Select month"></asp:RequiredFieldValidator>
                                                    </span>
                                                </ContentTemplate>
                                                <Triggers>
                                                    <asp:AsyncPostBackTrigger ControlID="ddlprojects" EventName="SelectedIndexChanged" />
                                                    <asp:AsyncPostBackTrigger ControlID="ddlBlockName" EventName="SelectedIndexChanged" />
                                                    <asp:AsyncPostBackTrigger ControlID="ddlFlatNumbers" EventName="SelectedIndexChanged" />
                                                    <asp:AsyncPostBackTrigger ControlID="ddlmonth" EventName="SelectedIndexChanged" />

                                                </Triggers>
                                            </asp:UpdatePanel>
                                        </div>
                                        <div class="col-sm-4 col-xl-2 pt-3">
                                            <asp:UpdatePanel ID="UpdatePanel6" runat="server" UpdateMode="Conditional">
                                                <ContentTemplate>
                                                    <div class="input-icon input-icon-sm right">
                                                        <label>Year <span class="text-danger">*</span></label>
                                                        <i class="bi bi-calendar4 b5-icon"></i>
                                                        <asp:DropDownList class="bs-select form-control input-sm" AutoPostBack="true" ID="ddlyear" OnSelectedIndexChanged="ddlyear_SelectedIndexChanged" runat="server">
                                                            <asp:ListItem Value=""></asp:ListItem>
                                                            <asp:ListItem Value="2024">2024</asp:ListItem>
                                                            <asp:ListItem Value="2025">2025</asp:ListItem>
                                                            <asp:ListItem Value="2026">2026</asp:ListItem>
                                                            <asp:ListItem Value="2027">2027</asp:ListItem>
                                                            <asp:ListItem Value="2028">2028</asp:ListItem>
                                                            <asp:ListItem Value="2029">2029</asp:ListItem>
                                                            <asp:ListItem Value="2030">2030</asp:ListItem>
                                                        </asp:DropDownList>
                                                    </div>
                                                    <span class="error">
                                                        <asp:RequiredFieldValidator ClientIDMode="Static" SetFocusOnError="true" EnableClientScript="true" ID="RequiredFieldValidator3" InitialValue="" ValidationGroup="projval" ControlToValidate="ddlyear" runat="server" ErrorMessage=" Select year"></asp:RequiredFieldValidator>
                                                    </span>
                                                </ContentTemplate>
                                                <Triggers>
                                                    <asp:AsyncPostBackTrigger ControlID="ddlprojects" EventName="SelectedIndexChanged" />
                                                    <asp:AsyncPostBackTrigger ControlID="ddlBlockName" EventName="SelectedIndexChanged" />
                                                    <asp:AsyncPostBackTrigger ControlID="ddlFlatNumbers" EventName="SelectedIndexChanged" />
                                                    <asp:AsyncPostBackTrigger ControlID="ddlmonth" EventName="SelectedIndexChanged" />
                                                    <asp:AsyncPostBackTrigger ControlID="ddlyear" EventName="SelectedIndexChanged" />

                                                </Triggers>
                                            </asp:UpdatePanel>
                                        </div>

                                        <div class="align-items-center text-center" id="projectValidationMessage"></div>

                                        <asp:UpdatePanel ID="UpdatePanel2" runat="server" UpdateMode="Conditional">
                                            <ContentTemplate>
                                                <div class="col-sm-4 col-xl-4 pt-3">
                                                    <div class="input-icon input-icon-sm right">
                                                        <label>Thumbnail Image Upload <span class="text-danger">*</span></label>
                                                        <div id="divthumnailfield" runat="server">
                                                            <i class="bi bi-image b5-icon"></i>
                                                            <asp:FileUpload ID="uploadThumbnailImg" ClientIDMode="Static" accept=".jpeg, .jpg, .png" class="form-control input-sm UploadThumbnailImg Thumbnail" autocomplete="off" placeholder="" runat="server" />
                                                            <span class="handle-file-request">(max file size of 500 KB)</span>
                                                            <span class="error Thumbnailfile-size-error"></span>
                                                        </div>
                                                    </div>
                                                    <span class="error">
                                                        <asp:RequiredFieldValidator ClientIDMode="Static" SetFocusOnError="true" EnableClientScript="true" ControlToValidate="uploadThumbnailImg" ValidationGroup="projval" ID="RequiredFieldValidator4" runat="server" ErrorMessage="Upload thumbnail image"></asp:RequiredFieldValidator>
                                                    </span>
                                                    <div class="view-loca-map-img btn-view-pop Thumbnailbtn-view-pop" runat="server" id="divviewthumnail" style="display: none">
                                                        <i class="bi bi-eye"></i>View Image
                                                    </div>
                                                </div>
                                            </ContentTemplate>
                                            <Triggers>
                                                <asp:AsyncPostBackTrigger ControlID="ddlprojects" EventName="SelectedIndexChanged" />
                                                <asp:AsyncPostBackTrigger ControlID="ddlBlockName" EventName="SelectedIndexChanged" />
                                                <asp:AsyncPostBackTrigger ControlID="ddlFlatNumbers" EventName="SelectedIndexChanged" />
                                                <asp:AsyncPostBackTrigger ControlID="ddlmonth" EventName="SelectedIndexChanged" />
                                                <asp:AsyncPostBackTrigger ControlID="ddlyear" EventName="SelectedIndexChanged" />


                                                <asp:PostBackTrigger ControlID="btnadd" />
                                            </Triggers>

                                        </asp:UpdatePanel>



                                        <div id="fileUploadContainer">
                                            <div id="fileUploadRow1" class="file-upload-row d-flex align-items-start flex-wrap">
                                                <div class="col-sm-4 col-xl-4 pt-3">
                                                    <div class="input-icon input-icon-sm right">
                                                        <label>Image Upload <span class="text-danger">*</span></label>
                                                        <i class="bi bi-file-earmark-image-fill b5-icon"></i>
                                                        <asp:FileUpload ID="fileUpload" ClientIDMode="Static" accept=".jpeg, .jpg, .png" onchange="showMyImage(this)" class="form-control input-sm UploadMultipleImg progressImagesUpload flupload" autocomplete="off" placeholder="" runat="server" />
                                                        <span class="handle-file-request">(max file size of 500 KB)</span>
                                                        <span class="error file-size-error"></span>
                                                    </div>
                                                    <span class="error">
                                                        <asp:RequiredFieldValidator ClientIDMode="Static" SetFocusOnError="true" EnableClientScript="true" ControlToValidate="FileUpload" ValidationGroup="projval" ID="RequiredFieldValidator5" runat="server" ErrorMessage="Upload image"></asp:RequiredFieldValidator>
                                                    </span>
                                                    <div class="view-loca-map-img fluploadbtn-view-pop btn-view-pop" runat="server" id="viewmapbtn" style="display: none">
                                                        <i class="bi bi-eye"></i>View Image
                                                    </div>
                                                </div>
                                                <div class="col-sm-5 col-xl-4 pt-3">
                                                    <div class="input-icon input-icon-sm right">
                                                        <label>Content <span class="text-danger">*</span></label>
                                                        <i class="bi bi-list-check b5-icon"></i>
                                                        <asp:TextBox ID="txtContent" TextMode="MultiLine" MaxLength="100" class="form-control input-sm editor capitalize-input" Rows="2" runat="server"></asp:TextBox>
                                                        <span class="handle-file-request">(max 100 characters)</span>
                                                    </div>
                                                    <span class="error">
                                                        <asp:RequiredFieldValidator ClientIDMode="Static" SetFocusOnError="true" EnableClientScript="true" ControlToValidate="txtContent" ValidationGroup="projval" ID="RequiredFieldValidator6" runat="server" ErrorMessage="Enter content"></asp:RequiredFieldValidator>
                                                    </span>
                                                </div>

                                            </div>

                                            <div class="card-footer">
                                                    <asp:UpdatePanel ID="UpdatePanel8" runat="server" UpdateMode="Conditional">
                                                        <ContentTemplate> 
                                                        <div class="d-flex justify-content-center">
                                                            <div class="" id="addFileUploadBtn" data-bs-toggle="tooltip" title="Add Another Progress">
                                                                <asp:LinkButton ID="btnadd" runat="server" class="btn btn-sm handle-btn-success me-1" OnClick="btnSave_Click" OnClientClick="if (validatePage()) { this.value='Please wait..'; this.style.display='none'; document.getElementById('bWait').style.display = ''; } else { return false; }" Style="min-width: 67px;"><i class="bi bi-plus-circle b5-icon-et-dlt"></i>Add</asp:LinkButton>
                                                                <button type="button" style="display: none" id="bWait" class="btn btn-secondary btn-sm me-1"><i class='fa fa-spinner fa-spin'></i>Please wait</button>
                                                            </div>
                                                            <div class="btn btn-sm handle-btn-danger swtAltCancel">Cancel</div>
                                                            <asp:Button ID="Button1" runat="server" Text="Cancel Project" OnClick="btnCancel_Click" Style="display: none;" />
                                                       </div>
                                                            </ContentTemplate>
                                                        <Triggers>
                                                            <asp:AsyncPostBackTrigger ControlID="ddlprojects" EventName="SelectedIndexChanged" />
                                                            <asp:AsyncPostBackTrigger ControlID="ddlBlockName" EventName="SelectedIndexChanged" />
                                                            <asp:AsyncPostBackTrigger ControlID="ddlFlatNumbers" EventName="SelectedIndexChanged" />
                                                            <asp:AsyncPostBackTrigger ControlID="ddlmonth" EventName="SelectedIndexChanged" />
                                                            <asp:AsyncPostBackTrigger ControlID="ddlyear" EventName="SelectedIndexChanged" /> 
                                                            <asp:PostBackTrigger ControlID="btnadd" />
                                                        </Triggers> 
                                                    </asp:UpdatePanel>
                                                
                                            </div>
                                        </div>

                                    </div>
                                </div>
                            </div>
                        </div>

                        <div class="card-footer" style="display: none">
                            <div class="d-flex justify-content-center">
                                <asp:Button ID="btnSave" ClientIDMode="Static" runat="server" OnClick="btnSave_Click"
                                    Text="Submit" ValidationGroup="projval" class="btn btn-sm handle-btn-success me-1 btnSave"
                                    OnClientClick="if (validatePage()) { this.value='Please wait..'; this.style.display='none'; document.getElementById('bWait1').style.display = ''; } else { return false; }" Style="min-width: 67px;" />
                                <button type="button" style="display: none" id="bWait1" class="btn btn-secondary btn-sm me-1"><i class='fa fa-spinner fa-spin'></i>Please wait</button>
                                <div class="btn btn-sm handle-btn-danger swtAltCancel">Cancel</div>
                                <asp:Button ID="btnCancel" runat="server" Text="Cancel Project" OnClick="btnCancel_Click" Style="display: none;" />
                            </div>
                        </div>
                        <asp:UpdatePanel ID="UpdatePanel7" runat="server" UpdateMode="Conditional">
                            <ContentTemplate>
                                <div class="form-group" id="divflatprogressimages" style="display: none" clientidmode="Static" runat="server">
                                    <div class="form-border margin-top20">
                                        <div class="form-title">
                                            <h3>View Flat Progress List</h3>
                                        </div>
                                        <div class="table-responsive pt-4 mt-md-2 mt-0 px-4">
                                            <asp:Repeater ID="rpflatprogressimages" runat="server">
                                                <HeaderTemplate>
                                                    <table class="table table-bordered" id="tblFlatprogressList">
                                                        <thead>
                                                            <tr>
                                                                <th class="w-sno">#</th>
                                                                <th>Content</th>
                                                                <th>View Image</th>
                                                                <th>Action</th>
                                                            </tr>
                                                        </thead>
                                                        <tbody>
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <tr id="row<%# Container.ItemIndex %>">
                                                        <asp:HiddenField ID="HiddenField1" Value='<%# Eval("FlatProgressImageID") %>' ClientIDMode="Static" runat="server" />
                                                        <asp:HiddenField ID="HiddenField2" Value='<%# Eval("FlatProgressID") %>' ClientIDMode="Static" runat="server" />
                                                        <td><%# Container.ItemIndex + 1 %></td>
                                                        <td><%#Eval("Content") %></td>
                                                        <td>
                                                            <a href="#" data-bs-toggle="tooltip" title="View" onclick="showImage('<%#"/FlatProgressimage/"+Eval("ImageName") %>'); return false;">
                                                                <i class="bi bi-eye b5-icon-et-dlt"></i>
                                                            </a> 
                                                        </td>
                                                        <td> 
                                                            <a href="javascript:void(0);" class="btnDelete " onclick="deleteRow(this)"><i class="bi bi-trash b5-icon-et-dlt" data-bs-toggle="tooltip" title="Delete"></i></a>
                                                        </td>
                                                    </tr>
                                                </ItemTemplate>
                                                <FooterTemplate>
                                                    </tbody>
                                                 </table>           
                                                </FooterTemplate>
                                            </asp:Repeater>
                                        </div>
                                    </div>
                                </div>
                            </ContentTemplate>
                            <Triggers>
                                <asp:AsyncPostBackTrigger ControlID="ddlprojects" EventName="SelectedIndexChanged" />
                                <asp:AsyncPostBackTrigger ControlID="ddlBlockName" EventName="SelectedIndexChanged" />
                                <asp:AsyncPostBackTrigger ControlID="ddlFlatNumbers" EventName="SelectedIndexChanged" />
                                <asp:AsyncPostBackTrigger ControlID="ddlmonth" EventName="SelectedIndexChanged" />
                                <asp:AsyncPostBackTrigger ControlID="ddlyear" EventName="SelectedIndexChanged" />
                                <asp:PostBackTrigger ControlID="btnSave" />
                            </Triggers>
                        </asp:UpdatePanel>
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
                Powered by <a class="text-uppercase" href="https://duffldigital.com/" target="_blank">Duffl Digital</a>
            </div>
        </div>
    </footer>





    <!-- multiSelector -->
    <script src="https://cdn.jsdelivr.net/npm/choices.js/public/assets/scripts/choices.min.js"> </script>

    <script>
        function showImage(imageUrl) {
            Swal.fire({
                html: `
    <div style="position: relative;">
        <div class="btn-close-icon" onclick="Swal.close()" style="cursor: pointer; position: absolute; top: -15px; right: -25px;">&times;</div>
        <h2 class="fw-bold">Preview Image</h2>
        <img src="${imageUrl}" alt="Image Preview" class="image-preview img-fluid mt-3" id="popupImage" onmousedown="startDrag(event)">
    </div>
`,
                showConfirmButton: false,

            });

        }
    </script>








    <script>
        function validatePage() {
            var flag = window.Page_ClientValidate('projval');
            const fileSizeErrorLabel = document.querySelector('.Thumbnailfile-size-error');
            fileSizeErrorLabel.textContent = '';
            const imageerrorlabel = document.querySelector('.file-size-error');
            imageerrorlabel.textContent = '';
            return flag;
        }

        function validatePage1() {
            var flag = window.Page_ClientValidate('val');
            return flag;
        }

        document.getElementById('<%= txtContent.ClientID %>').addEventListener('input', function (e) {
            if (this.value.length > 100) {
                this.value = this.value.substring(0, 100);
            }
        });

        //-- Select the Cancel button with the class 'swtAltCancel'
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
                        //'You can continue with your project progress details submission.', 
                    }
                });
            });
        });
        //--// Select the Cancel button with the class 'swtAltCancel'


       <%-- // Get the current month name
        document.addEventListener('DOMContentLoaded', function () {
            const currentMonth = new Date().toLocaleString('default', { month: 'long' });
            const ddlMonth = document.getElementById('<%= ddlmonth.ClientID %>');
            for (let i = 0; i < ddlMonth.options.length; i++) {
                if (ddlMonth.options[i].value === currentMonth) {
                    ddlMonth.selectedIndex = i;
                    break;
                }
            }
            const currentYear = new Date().getFullYear();
            const ddlYear = document.getElementById('<%= ddlyear.ClientID %>');
            for (let i = 0; i < ddlYear.options.length; i++) {
                if (ddlYear.options[i].value === currentYear.toString()) {
                    ddlYear.selectedIndex = i;
                    break;
                }
            }
        });--%>
    </script>

    <script src="https://code.jquery.com/jquery-3.6.0.min.js"></script>

    <script>
        document.addEventListener("DOMContentLoaded", function () {
            let rowCounter = 0;
            const maxRows = 10;
            const maxFileSize = 500 * 1024;

            // Function to add a new file upload row
            function addNewFileUploadRow() {

                if (rowCounter < maxRows) {
                    rowCounter++;

                    const newRow = document.createElement("div");
                    newRow.className = "file-upload-row";
                    newRow.setAttribute("data-row-index", rowCounter);

                    const fileDiv = document.createElement("div");
                    fileDiv.className = "col-sm-4 col-xl-4 pt-3";
                    fileDiv.innerHTML = `
                    <div class="input-icon input-icon-sm right">
                    <label>Image Upload <span class="text-danger"></span></label>
                    <i class="bi bi-file-earmark-image-fill b5-icon"></i>
                    <input type="file" id="fileUpload${rowCounter}" name="fileUpload${rowCounter}"
                        accept=".jpeg, .jpg, .png" class="form-control file-input" />
                    <span class="handle-file-request d-block pt-1">(max file size of 500 KB)</span>
                    <small class="file-error text-danger d-none">Image size must be under 500 KB</small>
                    <div class="view-progress btn-view-pop" 
                        data-row-index="${rowCounter}" style="display: none; top: 5px;">
                        <i class="bi bi-eye view-spec b5-icon-et-view"></i> View Image
                    </div>
                    </div>
                `;

                    const contentDiv = document.createElement("div");
                    contentDiv.className = "col-sm-5 col-xl-4 pt-3";
                    contentDiv.innerHTML = `
                    <div class="input-icon input-icon-sm right">
                    <label>Content <span class="text-danger"></span></label>
                        <i class="bi bi-list-check b5-icon"></i>
                    <textarea id="txtContent${rowCounter}" name="txtContent${rowCounter}"
                        maxlength="100" rows="2" class="form-control input-sm editor capitalize-input"></textarea>
                    <span class="handle-file-request">(max 100 characters)</span>
                    <div>
                `;
                    const newTextbox = contentDiv.querySelector(".capitalize-input");
                    addCapitalizeEvent(newTextbox);

                    const buttonDiv = document.createElement("div");
                    buttonDiv.className = "col-sm-3 col-xl-2 pt-5";
                    buttonDiv.innerHTML = `
                    <div class="remove-progress btn" data-bs-toggle="tooltip" title="Remove Progress" data-row-index="${rowCounter}">
                        <i class="bi bi-dash-circle remove-spec b5-icon-et-dlt"></i> Remove
                    </div>
                `;

                    new bootstrap.Tooltip(buttonDiv.querySelector('[data-bs-toggle="tooltip"]'));

                    newRow.appendChild(fileDiv);
                    newRow.appendChild(contentDiv);
                    newRow.appendChild(buttonDiv);

                    document.querySelector("#fileUploadContainer").appendChild(newRow);

                    document.querySelector(`#fileUpload${rowCounter}`).addEventListener('change', function (event) {
                        const file = event.target.files[0];
                        const viewButton = document.querySelector(`.view-progress[data-row-index="${rowCounter}"]`);
                        const errorLabel = event.target.nextElementSibling.nextElementSibling;

                        if (file) {
                            if (file.size > maxFileSize) {
                                errorLabel.classList.remove("d-none");
                                event.target.value = ""; // Clear the file input
                                viewButton.style.display = "none"; // Hide view button
                            } else {
                                errorLabel.classList.add("d-none"); // Hide error
                                const reader = new FileReader();
                                reader.onload = function (e) {
                                    const imgsrc = e.target.result;
                                    viewButton.setAttribute('data-imgsrc', imgsrc);
                                    viewButton.style.display = 'inline-block';
                                };
                                reader.readAsDataURL(file);
                            }
                        } else {
                            errorLabel.classList.add("d-none"); // Hide error
                            viewButton.style.display = "none";
                        }
                    });
                } else {
                    Swal.fire({
                        title: `Maximum limit reached. Only ${maxRows} rows are allowed`,
                        confirmButtonText: 'OK',
                        customClass: {
                            confirmButton: 'handle-btn-success',
                        }
                    });
                }
            }

            // Function to remove a file upload row
            function removeFileUploadRow(rowIndex) {
                const row = document.querySelector(`.file-upload-row[data-row-index="${rowIndex}"]`);
                if (row) {
                    row.remove();
                    rowCounter--;
                }
            }
        });
    </script>


    <script type="text/javascript">
        document.addEventListener('DOMContentLoaded', function () {
            const fileUploader = document.querySelector('.flupload');
            const viewLogoBtn = document.querySelector('.fluploadbtn-view-pop');
            const fileSizeErrorLabel = document.querySelector('.file-size-error');
            const maxFileSize = 500 * 1024;
            const allowedExtensions = [".jpg", ".jpeg", ".png"];
            let screensrc = null;

            if (!fileUploader || !viewLogoBtn || !fileSizeErrorLabel) {
                console.error("Required elements not found in the DOM.");
                return;
            }

            fileUploader.addEventListener('change', function (event) {
                const file = event.target.files[0];
                fileSizeErrorLabel.textContent = '';
                screensrc = null;
                viewLogoBtn.src = '';
                viewLogoBtn.style.display = 'none';

                if (!file) {
                    fileSizeErrorLabel.textContent = '';
                    return;
                }

                const fileExtension = `.${file.name.split('.').pop().toLowerCase()}`;
                if (!allowedExtensions.includes(fileExtension)) {
                    fileSizeErrorLabel.textContent = "Only .jpg, .jpeg, and .png files are allowed.";
                    event.target.value = '';
                    return;
                }

                if (file.size > maxFileSize) {
                    fileSizeErrorLabel.textContent = `File size must be under 500 KB`;
                    event.target.value = '';
                    return;
                }

                const reader = new FileReader();
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
            });

            viewLogoBtn.addEventListener('click', function () {
                if (!screensrc) {
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
    </script>
    <script type="text/javascript">
        document.addEventListener('DOMContentLoaded', function () {
            const fileUploader = document.querySelector('.Thumbnail');
            const viewLogoBtn = document.querySelector('.Thumbnailbtn-view-pop');
            const fileSizeErrorLabel = document.querySelector('.Thumbnailfile-size-error'); // Label for file size errors
            const maxFileSize = 500 * 1024; // 500 KB in bytes
            let screensrc = null;

            if (!fileUploader || !viewLogoBtn || !fileSizeErrorLabel) {
                console.error("Required elements not found in the DOM.");
                return;
            }

            fileUploader.addEventListener('change', function (event) {
                const file = event.target.files[0];

                // Reset previous error and view button states
                fileSizeErrorLabel.textContent = '';
                screensrc = null;
                viewLogoBtn.src = '';
                viewLogoBtn.style.display = 'none';

                if (file) {
                    if (file.size > maxFileSize) {
                        fileSizeErrorLabel.textContent = `File size must be under 500 KB`;
                        event.target.value = ''; // Clear file input
                        return;
                    }

                    const reader = new FileReader();

                    reader.onload = function (e) {
                        screensrc = e.target.result;

                        // Set the view button's source and display it
                        viewLogoBtn.src = screensrc;
                        viewLogoBtn.style.display = 'inline-block';
                    };

                    reader.onerror = function (err) {
                        console.error("Error reading file:", err);
                        screensrc = null;
                    };

                    reader.readAsDataURL(file);
                } else {
                    // Handle case where no file is selected
                    fileSizeErrorLabel.textContent = '';
                }
            });

            viewLogoBtn.addEventListener('click', function () {
                if (!screensrc) {
                    return; // No image uploaded yet
                }

                Swal.fire({
                    html: `
                    <div style="position: relative;">
                        <div class="btn-close-icon" style="cursor: pointer; position: absolute; top: -15px; right: -25px;">&times;</div>
                        <h2 class="fw-bold">Thumbnail Image</h2>
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
    </script>


    <script type="text/javascript">
        window.screensrc = { photo1: [], photo2: [] }; // Global screensrc for binding images

        function bindImageToPreviewphoto(srclogo, index, type) {

            var viewLogoBtns = document.querySelectorAll('.Thumbnailbtn-view-pop');
            if (index !== -1 && viewLogoBtns[index]) {
                screensrc[type] = screensrc[type] || [];
                screensrc[type][index] = srclogo;
                viewLogoBtns[index].style.display = 'inline-block';
                viewLogoBtns[index].src = srclogo; // Show the image preview
            } else {
                console.error("View logo button not found or index is invalid.");
            }
        }

        function setupFileUploader(fileUploaderSelector, viewButtonSelector, labelSelector, type) {
            const fileUploaders = document.querySelectorAll(fileUploaderSelector);
            const viewLogoBtns = document.querySelectorAll(viewButtonSelector);
            const errorLabels = document.querySelectorAll(labelSelector);

            if (!fileUploaders.length || !viewLogoBtns.length || !errorLabels.length) {
                console.error("Required elements not found for selectors:", { fileUploaderSelector, viewButtonSelector, labelSelector });
                return;
            }

            fileUploaders.forEach((fileUploader, index) => {
                const viewButton = viewLogoBtns[index];
                const label = errorLabels[index];

                if (!fileUploader || !viewButton || !label) {
                    console.error("Element at index " + index + " not found.");
                    return;
                }

                function resetFileInput() {
                    fileUploader.value = '';
                    screensrc[type][index] = null;
                    viewButton.style.display = 'none';
                }

                fileUploader.addEventListener('change', function () {
                    const file = fileUploader.files[0];
                    const allowedFiles = [".png", ".jpg", ".jpeg"];

                    if (file) {
                        const ext = file.name.split('.').pop().toLowerCase();

                        if (!allowedFiles.includes("." + ext)) {
                            label.textContent="Select .png, .jpg, or .jpeg files only.";
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
                            screensrc[type][index] = e.target.result;
                            viewButton.style.display = 'inline-block';
                            viewButton.src = screensrc[type][index]; // Display image in button
                        };

                        reader.onerror = function () {
                            screensrc[type][index] = null;
                            console.error("Error reading file.");
                        };

                        reader.readAsDataURL(file);
                    } else {
                        resetFileInput();
                    }
                });

                viewButton.addEventListener('click', function () {
                    if (!screensrc[type][index]) {
                        return;
                    }
                    Swal.fire({
                        html: `
                    <div style="position: relative;">
                        <div class="btn-close-icon" style="cursor: pointer; position: absolute; top: -15px; right: -25px;">&times;</div>
                        <h2 class="fw-bold">Thumbnail Image</h2>
                        <img id="swalImage" src="${screensrc[type][index]}" alt="Photo" class="img-fluid mt-3">
                    </div>
                `,
                        showConfirmButton: false,
                        didOpen: () => {
                            document.querySelector('.btn-close-icon').addEventListener('click', () => Swal.close());
                        }
                    });
                });
            });
        }

        function initializeUploader() {
            setupFileUploader('.Thumbnail', '.Thumbnailbtn-view-pop', '.Thumbnailfile-size-error', 'photo1');
        }

        document.addEventListener('DOMContentLoaded', initializeUploader);

        Sys.WebForms.PageRequestManager.getInstance().add_endRequest(function () {
            initializeUploader(); // Rebind after partial postback
        });

        window.bindImageToPreviewphoto = bindImageToPreviewphoto;
    </script>



    <script>
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


                    const hiddenFields = row.querySelectorAll('input[type="hidden"]');


                    const FlatProgressImageID = hiddenFields[0] ? hiddenFields[0].value : '';

                    let commonVariable = null;
                    const hiddenField2 = hiddenFields[1];
                    if (hiddenField2) {
                        commonVariable = hiddenField2.value;
                        //console.log('Hidden Field 2 Value:', hiddenField2.value);
                    }

                    if (!FlatProgressImageID) {
                        alert('FlatProgressImageID is missing!');
                        return;
                    }

                    var dropflatname = document.getElementById('<%= ddlprojects.ClientID %>');
                    var selectedValue = dropflatname ? dropflatname.value : '';


                    $.ajax({
                        type: 'POST',
                        url: 'add-flat-progress.aspx/DeleteCustomer',
                        data: JSON.stringify({ FlatProgressImageID: FlatProgressImageID }),
                        contentType: 'application/json; charset=utf-8',
                        dataType: 'json',
                        success: function (response) {
                            row.remove();
                            loadRepeaterData(commonVariable,);

                            const table = document.getElementById('tblFlatprogressList');
                            const rows = table.querySelectorAll('tbody tr');
                            if (rows.length === 0) {
                                const repeaterContainer = document.getElementById('<%= divflatprogressimages.ClientID %>').closest('div');
                                if (repeaterContainer) {
                                    repeaterContainer.style.display = 'none';
                                }
                            }



                            if (response.d == "1") {
                                Swal.fire({
                                    title: 'Flat progress details have been deleted as requested', confirmButtonText: 'Ok',
                                    customClass: {
                                        confirmButton: 'handle-btn-success'
                                    },
                                });
                            }
                            else {
                                Swal.fire({
                                    title: 'Flat progress details have been not deleted as requested', confirmButtonText: 'Ok',
                                    customClass: {
                                        confirmButton: 'handle-btn-success'
                                    },
                                });
                            }
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
        function loadRepeaterData(selectedValue) {
            //alert("hi");
            $.ajax({
                type: 'POST',
                url: 'add-flat-progress.aspx/GetCostDetails',
                data: JSON.stringify({ selectedValue: selectedValue }),
                contentType: 'application/json; charset=utf-8',
                dataType: 'json',
                success: function (response) {
                    if (response && response.d) {
                        // console.log(response.d);
                        const data = response.d;
                        const repeaterBody = document.querySelector('#tblFlatprogressList tbody');
                        if (repeaterBody) {
                            repeaterBody.innerHTML = '';
                        }
                        data.forEach(function (item, index) {
                            const row = document.createElement('tr');
                            row.innerHTML = `
                <td>${index + 1}</td>
               
                <td>${item.Content}
                    <input type="hidden" id="HiddenField1" ClientIDMode="Static" value="${item.ProgressImageID}" />
                     <asp:HiddenField ID="HiddenField2" value="${item.ProgressID}" ClientIDMode="Static" runat="server" />
                </td>
                <td>
                    <a href="#" data-bs-toggle="tooltip" title="View" onclick="showImage('/ProgressImages/${item.ImageName}'); return false;">
                        <i class="bi bi-eye b5-icon-et-dlt"></i>
                    </a>
                </td>
                <td>
                    <a href="javascript:void(0);" class="btnDelete" onclick="deleteRow(this)">
                        <i class="bi bi-trash b5-icon-et-dlt" data-bs-toggle="tooltip" title="Delete"></i>
                    </a>
                </td>
            `;
                            repeaterBody.appendChild(row);
                        });

                        // Initialize tooltips
                        const tooltipTriggerList = [].slice.call(document.querySelectorAll('[data-bs-toggle="tooltip"]'));
                        tooltipTriggerList.forEach(function (tooltipTriggerEl) {
                            new bootstrap.Tooltip(tooltipTriggerEl);
                        });

                        // Toggle visibility of the repeater container
                        const repeaterContainer = document.getElementById('<%= divflatprogressimages.ClientID %>');
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

