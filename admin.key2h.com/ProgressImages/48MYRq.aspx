<%@ Page Title="" Language="C#" MasterPageFile="AdminKey2h.master" AutoEventWireup="true" CodeFile="add-floorplan.aspx.cs" Inherits="adminkey2hcom_AddFloorPlan" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <style>
        /* Popup styling */
        .sweet-popup-style {
            max-width: 90%;
            max-height: 80vh;
            height: auto;
            overflow: auto;
            border-radius: 15px;
            box-shadow: 0 4px 10px rgba(0, 0, 0, 0.2);
            position: relative;
        }

        /* Image container */
        .image-container {
            text-align: center;
            background-color: #ffffff;
            padding: 20px;
            border-radius: 10px;
            position: relative;
            overflow: hidden;
            height: 90vh;
            display: flex;
            justify-content: center; /* Center the image horizontally */
            align-items: center; /* Center the image vertically */
        }

        /* Image styling */
        .image-preview {
            max-width: 100%;
            max-height: 90vh; /* Restrict height to 70% of viewport */
            object-fit: contain;
            transition: transform 0.3s ease;
            position: absolute; /* Absolute position to allow dragging */
            cursor: grab; /* Cursor style when hovering over the image */
            top: 50%; /* Position image vertically at 50% */
            left: 50%; /* Position image horizontally at 50% */
            transform: translate(-50%, -50%); /* Center the image */
            transform-origin: center center; /* Ensure zoom happens from the center */
        }

        /* Zoom controls */
        .zoom-controls {
            margin-top: 10px;
            display: flex;
            justify-content: center;
            gap: 10px; /* Space between buttons */
            position: absolute;
            bottom: 10px;
            left: 50%;
            transform: translateX(-50%);
            z-index: 10; /* Ensure buttons are always on top */
        }

        /* Zoom buttons */
        .zoom-btn {
            padding: 10px 15px;
            font-size: 18px;
            border: none;
            border-radius: 5px;
            background-color: #d3d3d3; /* Light gray */
            color: #ffffff; /* White text */
            cursor: pointer;
            transition: background-color 0.3s ease;
        }

            .zoom-btn:hover {
                background-color: #808080; /* Darker gray */
            }

        /* Close button styling */
        .swal2-confirm {
            font-size: 16px;
            padding: 10px 20px;
            border-radius: 5px;
            background-color: #000000; /* Black */
            color: #ffffff; /* White text */
            transition: background-color 0.3s ease;
        }

            .swal2-confirm:hover {
                background-color: #333333; /* Slightly lighter black */
            }

        /* Styling for close button in popup */
        .swal2-close {
            background-color: transparent;
            color: #000000;
            font-size: 18px;
            position: absolute;
            top: 10px;
            right: 10px;
            border: none;
            cursor: pointer;
        }

            .swal2-close:hover {
                color: #ff0000; /* Red on hover */
            }

        /* Reset image drag position after zoom */
        .image-preview {
            transition: transform 0.3s ease, left 0.3s ease, top 0.3s ease;
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
                                        <h3>Add Floor Plan</h3>
                                    </div>
                                    <div class="row mx-0 margin-top20 mb-4">

                                        <div class="col-sm-4 col-xl-3 pt-3">
                                            <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
                                                <ContentTemplate>
                                                    <div class="input-icon input-icon-sm right">
                                                        <label>Project Name <span class="text-danger">*</span></label>
                                                        <i class="bi bi-journal-bookmark-fill b5-icon"></i>
                                                        <asp:DropDownList ID="ddlProName" AutoPostBack="true" OnSelectedIndexChanged="ddlProName_SelectedIndexChanged" class="bs-select form-control input-sm" runat="server">
                                                            <asp:ListItem Value=""> </asp:ListItem>
                                                        </asp:DropDownList>
                                                    </div>
                                                </ContentTemplate>
                                                <Triggers>
                                                    <asp:AsyncPostBackTrigger ControlID="ddlProName" EventName="SelectedIndexChanged" />
                                                    <asp:AsyncPostBackTrigger ControlID="btnCancel" EventName="Click" />

                                                </Triggers>
                                            </asp:UpdatePanel>
                                            <span class="error">
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ValidationGroup="projval"
                                                    ControlToValidate="ddlProName" InitialValue="" ErrorMessage="Select project name">
                                                </asp:RequiredFieldValidator>
                                            </span>

                                        </div>
                                        <div class="col-sm-4 col-xl-3 pt-3">
                                            <asp:UpdatePanel ID="UpdatePanel4" runat="server" UpdateMode="Conditional">
                                                <ContentTemplate>
                                                    <div class="input-icon input-icon-sm right">
                                                        <label>Title <span class="text-danger">*</span></label>
                                                        <i class="bi bi-journal-text b5-icon"></i>
                                                        <asp:TextBox runat="server" ID="txtTitle" MaxLength="50" class="form-control input-sm capitalize-input" autocomplete="off" placeholder=""></asp:TextBox>
                                                    </div>
                                                </ContentTemplate>
                                                <Triggers>
                                                    <asp:AsyncPostBackTrigger ControlID="ddlProName" EventName="SelectedIndexChanged" />
                                                    <asp:AsyncPostBackTrigger ControlID="btnCancel" EventName="Click" />

                                                </Triggers>
                                            </asp:UpdatePanel>
                                            <span class="error">
                                                <asp:RequiredFieldValidator ClientIDMode="Static" EnableClientScript="true" SetFocusOnError="true" ControlToValidate="txtTitle" Display="Dynamic" ValidationGroup="projval" ID="RequiredFieldValidator3" runat="server" ErrorMessage="Enter title"></asp:RequiredFieldValidator>
                                                <asp:RegularExpressionValidator ClientIDMode="Static" ID="RegularExpressionValidator1" Display="Dynamic" runat="server" ValidationGroup="projval" ControlToValidate="txtTitle" ValidationExpression="^[A-Za-z -]+$" ErrorMessage="Enter valid title"></asp:RegularExpressionValidator>
                                            </span>
                                        </div>

                                        <div class="col-sm-4 col-xl-3 pt-3 ">
                                            <div class="input-icon input-icon-sm right">
                                                <label>Image Upload <span class="text-danger">*</span></label>
                                                <i class="bi bi-images b5-icon"></i>
                                                <asp:FileUpload ID="FluploadImageUpload" ClientIDMode="Static" accept=".jpeg, .jpg, .png" onchange="showMyImage1(this)" class="form-control input-sm FluploadImageUpload" autocomplete="off" placeholder="" runat="server" />
                                                <span class="handle-file-request">(max file size of 500 KB)</span>
                                                <asp:HiddenField ID="hdnImageUpload" runat="server" />
                                            </div>

                                            <span class="error">
                                                <asp:Label ID="lblFluploadImageUpload" CssClass="lblFluploadImageUpload" runat="server" ForeColor="#d41111" Text=""></asp:Label>

                                            </span>
                                            <span class="error">
                                                <asp:RequiredFieldValidator EnableClientScript="true" SetFocusOnError="true" ControlToValidate="FluploadImageUpload" ValidationGroup="projval" ID="RequiredFieldValidator2" runat="server" ErrorMessage=" Upload image "></asp:RequiredFieldValidator>

                                            </span>
                                            <div class="view-pro-screen-img view-pro-screen btn-view-pop btn-view-Photo1" runat="server" id="viewpflphoto" style="display: none">
                                                <i class="bi bi-eye"></i>View Image
                                            </div>
                                        </div>
                                    </div>
                                    <asp:UpdatePanel ID="UpdatePanel3" runat="server" UpdateMode="Conditional">
                                        <ContentTemplate>
                                            <div class="card-footer mx-2 pb-4">
                                                <div class="d-flex justify-content-center">
                                                    <asp:Button
                                                        ID="btnSave" ClientIDMode="Static"
                                                        runat="server" OnClick="btnSave_Click"
                                                        Text="Add" ValidationGroup="projval"
                                                        class="btn btn-sm handle-btn-success me-1 swtAltSubmit btnSave"
                                                        OnClientClick="if (validatePage()) { this.value='Please wait..'; this.style.display='none'; document.getElementById('bWait').style.display = ''; } else { return false; }" Style="min-width: 67px;" />
                                                    <button type="button" style="display: none" id="bWait" class="btn btn-secondary btn-sm me-1"><i class='fa fa-spinner fa-spin'></i>Please wait</button>
                                                    <div class="btn btn-sm handle-btn-danger swtAltCancel-Refresh">Cancel</div>
                                                    <asp:Button ID="btnCancel" ClientIDMode="Static" runat="server" Text="Cancel Project" OnClick="btnCancel_Click" Style="display: none;" />
                                                </div>
                                            </div>

                                        </ContentTemplate>
                                        <Triggers>
                                            <asp:AsyncPostBackTrigger ControlID="ddlProName" EventName="SelectedIndexChanged" />
                                            <asp:AsyncPostBackTrigger ControlID="btnCancel" EventName="Click" />
                                            <asp:PostBackTrigger ControlID="btnSave" />
                                        </Triggers>
                                    </asp:UpdatePanel>
                                </div>


                                <!------------------ View Floor Plan List ------------------>
                                <asp:UpdatePanel ID="UpdatePanel2" runat="server" UpdateMode="Conditional">
                                    <ContentTemplate>
                                        <div class="form-group" id="divrptCustomers" style="display: none" clientidmode="Static" runat="server">
                                            <div class="form-border margin-top20">
                                                <div class="form-title">
                                                    <h3>View Details</h3>
                                                </div>
                                                <div class="table-responsive pt-4 mt-md-2 mt-0 px-4">

                                                    <asp:Repeater ID="rpruser" runat="server">
                                                        <HeaderTemplate>
                                                            <table class="table table-bordered" id="tblCustomers">
                                                                <thead>
                                                                    <th># </th>
                                                                    <th>Project Name </th>
                                                                    <th>Title </th>
                                                                    <th>View</th>
                                                                    <th>Action</th>
                                                                </thead>
                                                                <tbody>
                                                        </HeaderTemplate>
                                                        <ItemTemplate>
                                                            <tr>
                                                                <asp:HiddenField ID="HiddenField1" Value='<%# Eval("FloorPlanID") %>' runat="server" />
                                                                <td><%# GetRowNo(Convert.ToString(Container.ItemIndex + 1))%>  </td>
                                                                <td><%# Bindprojectname(Convert.ToInt32(Eval("ProjectID"))) %> </td>
                                                                <td><%# Eval("Title") %></td>
                                                                <td>
                                                                    <%-- <div class="view-popup-img" data-bs-toggle="tooltip" title="View">
                                                            <i class="bi bi-eye b5-icon-et-dlt"></i>
                                                        </div>--%>

                                                                    <a href="#" data-bs-toggle="tooltip" title="View" onclick="showImage('<%#"/FloorPlans/"+ Eval("ImagePath") %>'); return false;">
                                                                        <i class="bi bi-eye b5-icon-et-dlt"></i>
                                                                    </a>

                                                                </td>
                                                                <td>
                                                                    <a href="javascript:void(0);" class="btnDelete" onclick="deleteRow(this)"><i class="bi bi-trash b5-icon-et-dlt me-3" data-bs-toggle="tooltip" title="Delete"></i></a>

                                                                </td>
                                                            </tr>
                                                            </tbody>
                                                        </ItemTemplate>
                                                        <FooterTemplate>
                                                            </table>
                                                        </FooterTemplate>
                                                    </asp:Repeater>



                                                </div>
                                            </div>
                                        </div>
                                    </ContentTemplate>
                                    <Triggers>
                                        <asp:AsyncPostBackTrigger ControlID="ddlProName" EventName="SelectedIndexChanged" />
                                        <asp:PostBackTrigger ControlID="btnSave" />
                                        <asp:AsyncPostBackTrigger ControlID="btnCancel" EventName="Click" />
                                    </Triggers>
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
            Sys.WebForms.PageRequestManager.getInstance().add_endRequest(function () {
                attachSweetAlert();
            });

            document.addEventListener('DOMContentLoaded', function () {
                attachSweetAlert();
            });

            function attachSweetAlert() {
                const cancelButton = document.querySelector('.swtAltCancel-Refresh');

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


        <script>
            let scale = 1;
            let isDragging = false;
            let startX, startY;

            function showImage(imageUrl) {
                Swal.fire({
                    title: 'Image Preview',
                    html: `
            <div class="image-container">
                <img src="${imageUrl}" alt="Image Preview" class="image-preview" id="popupImage" onmousedown="startDrag(event)">
                <div class="zoom-controls">
                    <button class="zoom-btn" onclick="zoomImage(1.1)">+</button>
                    <button class="zoom-btn" onclick="zoomImage(0.9)">-</button>
                </div>
            </div>
        `,
                    showCloseButton: true,
                    showConfirmButton: true,
                    confirmButtonText: 'Close',
                    confirmButtonColor: '#000000', /* Black Close Button */
                    background: '#f9f9f9',
                    width: '90%', /* Increase popup width */
                    customClass: {
                        popup: 'sweet-popup-style',
                    },
                    onClose: () => {
                        // Reset zoom when the popup is closed
                        scale = 1;
                        const image = document.getElementById('popupImage');
                        image.style.transform = `scale(${scale})`;
                        image.style.left = '0px';
                        image.style.top = '0px'; // Reset image position when closed
                    }
                });
            }

            function zoomImage(factor) {
                const image = document.getElementById('popupImage');
                scale *= factor;
                image.style.transform = `scale(${scale})`;

                // Recenter the image after zoom to ensure it stays centered
                const container = document.querySelector('.image-container');
                const imageWidth = image.offsetWidth * scale;
                const imageHeight = image.offsetHeight * scale;

                const containerWidth = container.offsetWidth;
                const containerHeight = container.offsetHeight;

                const offsetX = (containerWidth - imageWidth) / 2;
                const offsetY = (containerHeight - imageHeight) / 2;

                image.style.left = `${offsetX}px`;
                image.style.top = `${offsetY}px`;
            }

            function startDrag(event) {
                isDragging = true;
                startX = event.clientX - parseInt(document.getElementById('popupImage').style.left || 0);
                startY = event.clientY - parseInt(document.getElementById('popupImage').style.top || 0);
                document.addEventListener('mousemove', dragImage);
                document.addEventListener('mouseup', stopDrag);
            }

            function dragImage(event) {
                if (isDragging) {
                    const image = document.getElementById('popupImage');
                    image.style.left = (event.clientX - startX) + 'px';
                    image.style.top = (event.clientY - startY) + 'px';
                }
            }

            function stopDrag() {
                isDragging = false;
                document.removeEventListener('mousemove', dragImage);
                document.removeEventListener('mouseup', stopDrag);
            }


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
                        const hiddenField = row.querySelector('input[type="hidden"]');
                        const FloorID = hiddenField ? hiddenField.value : '';

                        if (!FloorID) {
                            alert('CostLabelID is missing!');
                            return;
                        }

                        var dropflatname = document.getElementById('<%= ddlProName.ClientID %>');
                        var selectedValue = dropflatname ? dropflatname.value : '';

                        $.ajax({
                            type: 'POST',
                            url: 'add-floorplan.aspx/DeleteCustomer',
                            data: JSON.stringify({ FloorID: FloorID }),
                            contentType: 'application/json; charset=utf-8',
                            dataType: 'json',
                            success: function (response) {
                                row.remove();
                                loadRepeaterData(selectedValue);

                                const table = document.getElementById('tblCustomers');
                                const rows = table.querySelectorAll('tbody tr');
                                if (rows.length === 0) {
                                    const repeaterContainer = document.getElementById('<%= divrptCustomers.ClientID %>').closest('div');
                                    if (repeaterContainer) {
                                        repeaterContainer.style.display = 'none';
                                    }
                                }
                                Swal.fire({
                                    title: 'Cost details have been deleted as requested', confirmButtonText: 'Ok',
                                    customClass: {
                                        confirmButton: 'handle-btn-success'
                                    },
                                });

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
                $.ajax({
                    type: 'POST',
                    url: 'add-floorplan.aspx/GetCostDetails',
                    data: JSON.stringify({ selectedValue: selectedValue }),
                    contentType: 'application/json; charset=utf-8',
                    dataType: 'json',
                    success: function (response) {
                        if (response && response.d) {
                           // console.log(response.d);
                            const data = response.d;

                            // Ensure the repeater body is cleared before populating new data
                            const repeaterBody = document.querySelector('#tblCustomers tbody');
                            if (repeaterBody) {
                                // Clear existing rows before appending new ones
                                repeaterBody.innerHTML = ''; // Clear existing rows
                            }

                            // Populate the repeater with new data
                            data.forEach(function (item, index) {
                                const row = document.createElement('tr');
                                row.innerHTML = `
                        <td>${index + 1}</td>
                        <td>${item.ProjectID}</td>
                        <td>${item.Title}
                            <input type="hidden" id="HiddenField1" ClientIDMode="Static" value="${item.FloorPlanID}" />
                        </td>
                        <td>
                            <a href="#" data-bs-toggle="tooltip" title="View" onclick="showImage('/FloorPlans/${item.ImagePath}'); return false;">
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


        <script>
            function validatePage() {
                var flag = window.Page_ClientValidate('projval');
                return flag;
            }

            document.getElementById('<%= txtTitle.ClientID %>').addEventListener('keypress', function (e) {
                if (!/^[A-Za-z -]+$/.test(e.key)) {
                    e.preventDefault();
                }
            });
        </script>

        <script type="text/javascript">



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
            window.screensrc = { photo1: [], photo2: [] }; // Global screensrc for binding images

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

            // Initialize file uploaders with unique selectors
            document.addEventListener('DOMContentLoaded', function () {
                setupFileUploader('.FluploadImageUpload', '.btn-view-Photo1', '.lblFluploadImageUpload');
            });

            function initializeDeleteEvents() {
                const cancelButtons = document.querySelectorAll('.swtAltCancel');

                cancelButtons.forEach((cancelButton) => {
                    cancelButton.addEventListener('click', function () {
                        const linkButton = this.closest('tr')?.querySelector('.dlt-img.hidden'); // Adjust selector for the parent container if needed.

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
                            if (result.isConfirmed && linkButton) {
                                linkButton.click();

                                // Show confirmation message after deletion
                                Swal.fire({
                                    title: 'RM has been deleted as requested',
                                    confirmButtonText: 'Ok',
                                    customClass: {
                                        confirmButton: 'handle-btn-success'
                                    }
                                })
                            } else if (result.dismiss === Swal.DismissReason.cancel) {
                                // No action on cancel
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
</asp:Content>

