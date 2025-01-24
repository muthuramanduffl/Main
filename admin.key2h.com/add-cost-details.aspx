<%@ Page Title="" Language="C#" MasterPageFile="AdminKey2h.master" AutoEventWireup="true" CodeFile="add-cost-details.aspx.cs" Inherits="adminkey2hcom_AddCostDetails" %>

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
    <style>
        .btnnext {
            color: #493700;
            background: none;
            border: 1px solid #000;
            cursor: pointer;
            transition: all 0.3s ease;
            font-size: medium;
            position: relative;
            padding-top: 7px;
            padding-bottom: 8px;
        }



            .btnnext:hover {
                background: none;
                color: #493700;
                transform: translateY(-2px);
            }

            .btnnext span {
                transition: opacity 0.3s ease;
            }

            .btnnext:hover span {
                opacity: 0; /* Hide text on hover */
            }

            .btnnext i {
                font-size: 16px;
                color: inherit;
                top: 10px;
                position: absolute;
                right: -20px; /* Start off-screen */
                transition: all 0.3s ease;
                opacity: 0; /* Initially hidden */
            }

            .btnnext:hover i {
                opacity: 1;
                right: 18px;
            }

        .button-group {
            display: flex; /* Arrange buttons in a single row */
            gap: 10px; /* Space between buttons */
            justify-content: center; /* Center the buttons */
            align-items: center; /* Align vertically */
            margin-top: 10px; /* Adjust spacing if needed */
        }

        .btn-wait {
            display: none; /* Hidden initially */
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
                                        <h3>Cost Details</h3>
                                    </div>
                                    <div class="row mx-0 margin-top20 mb-4 pt-2">
                                        <div class="col-sm-4 col-xl-3 pt-3">
                                            <asp:HiddenField ID="hdnCostID" runat="server" />
                                            <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
                                                <ContentTemplate>
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

                                        <div class="col-sm-4 col-xl-3 pt-3">
                                            <asp:UpdatePanel ID="UpdatePanel2" runat="server" UpdateMode="Conditional">
                                                <ContentTemplate>
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
                                        <div class="col-sm-4 col-xl-3 pt-3">
                                            <asp:UpdatePanel ID="UpdatePanel3" runat="server" UpdateMode="Conditional">
                                                <ContentTemplate>
                                                    <div class="input-icon input-icon-sm right">
                                                        <label>Flat Number <span class="text-danger">*</span></label>
                                                        <i class="bi bi-file-binary b5-icon"></i>
                                                        <asp:DropDownList ID="ddlFlatNumber" AutoPostBack="true" ClientIDMode="Static" OnSelectedIndexChanged="ddlFlatNumber_SelectedIndexChanged" class="bs-select form-control input-sm" runat="server">
                                                        </asp:DropDownList>
                                                    </div>
                                                    <span class="error">
                                                        <asp:RequiredFieldValidator ClientIDMode="Static" Display="Dynamic" EnableClientScript="true" SetFocusOnError="true" ControlToValidate="ddlFlatNumber" ValidationGroup="val" ID="RequiredFieldValidator13" runat="server" ErrorMessage="Select flat no. "></asp:RequiredFieldValidator>
                                                    </span>
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
                                                    <asp:AsyncPostBackTrigger ControlID="btnAdd" EventName="click" />
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
                                                        <label>Cost Label <span class="text-danger">*</span></label>
                                                        <i class="bi bi-journal-text b5-icon"></i>
                                                        <asp:DropDownList ID="ddlCostLabel" AutoPostBack="true" OnSelectedIndexChanged="ddlCostLabel_SelectedIndexChanged" class="bs-select option-select form-control input-sm" runat="server">
                                                        </asp:DropDownList>
                                                    </div>
                                                    <span class="error">
                                                        <asp:RequiredFieldValidator ClientIDMode="Static" Display="Dynamic" EnableClientScript="true" SetFocusOnError="true" ControlToValidate="ddlCostLabel" ValidationGroup="val" ID="RegularExpressionValidator11" runat="server" ErrorMessage="Select cost label"></asp:RequiredFieldValidator>
                                                        <asp:Label ID="lblprojectValidationMessage" ClientIDMode="Static" runat="server" Text=""></asp:Label>
                                                    </span>
                                                </ContentTemplate>
                                                <Triggers>
                                                    <asp:AsyncPostBackTrigger ControlID="btnAdd" EventName="click" />
                                                    <asp:AsyncPostBackTrigger ControlID="ddlProName" EventName="SelectedIndexChanged" />
                                                    <asp:AsyncPostBackTrigger ControlID="ddlBlockNumber" EventName="SelectedIndexChanged" />
                                                    <asp:AsyncPostBackTrigger ControlID="ddlFlatNumber" EventName="SelectedIndexChanged" />
                                                    <asp:AsyncPostBackTrigger ControlID="ddlCostLabel" EventName="SelectedIndexChanged" />
                                                    <asp:AsyncPostBackTrigger ControlID="btnCancel" EventName="click" />
                                                </Triggers>
                                            </asp:UpdatePanel>

                                        </div>
                                        <div class="col-sm-4 col-xl-3 pt-3">
                                            <asp:UpdatePanel ID="UpdatePanel8" runat="server" UpdateMode="Conditional">
                                                <ContentTemplate>
                                                    <div class="input-icon input-icon-sm right">
                                                        <label>Cost <span class="text-danger">*</span></label>
                                                        <i class="bi bi-cash-stack b5-icon"></i>
                                                        <asp:TextBox runat="server" onfocus="addCurrencySymbol(this)" ID="txtCost" MaxLength="10" class="form-control input-sm input-value" autocomplete="off"></asp:TextBox>
                                                    </div>
                                                    <span class="error">

                                                        <asp:RequiredFieldValidator ClientIDMode="Static" Display="Dynamic" EnableClientScript="true" SetFocusOnError="true" ControlToValidate="txtCost" ValidationGroup="val" ID="RequiredFieldValidator9" runat="server" ErrorMessage="Enter cost"></asp:RequiredFieldValidator>
                                                        <asp:RegularExpressionValidator ClientIDMode="Static" ID="RegularExpressionValidator3" Display="Dynamic" runat="server" ValidationGroup="val" ControlToValidate="txtCost" ValidationExpression="^₹?[0-9]+$" ErrorMessage="Enter valid cost (only numbers)"></asp:RegularExpressionValidator>
                                                    </span>
                                                </ContentTemplate>
                                                <Triggers>
                                                    <asp:AsyncPostBackTrigger ControlID="ddlCostLabel" EventName="SelectedIndexChanged" />
                                                    <asp:AsyncPostBackTrigger ControlID="btnAdd" EventName="click" />
                                                    <asp:AsyncPostBackTrigger ControlID="btnCancel" EventName="click" />
                                                </Triggers>
                                            </asp:UpdatePanel>
                                        </div>
                                        <!-- Display Added Values -->
                                        <div class="added-values"></div>
                                    </div>
                                    <div class="card-footer mx-2 pb-4">
                                        <div class="d-flex justify-content-center">
                                            <asp:UpdatePanel ID="UpdatePanel9" runat="server" UpdateMode="Conditional">
                                                <ContentTemplate>
                                                    <asp:LinkButton ID="btnAdd" OnClientClick="if (validatePage1()) { this.value='Please wait..'; this.style.display='none'; document.getElementById('bWait1').style.display = ''; } else { return false; }" OnClick="btnAdd_Click" runat="server" class="btn btn-sm handle-btn-success add-btn">
                                                        Submit
                                                    </asp:LinkButton>
                                                    <button type="button" style="display: none" id="bWait1" class="btn btn-secondary btn-sm me-1"><i class='fa fa-spinner fa-spin'></i>Please wait</button>
                                                    <div class="btn btn-sm handle-btn-danger swtAltCancel ms-1">Cancel</div>
                                                    <asp:Button ID="btnCancel" ClientIDMode="Static" runat="server" Text="Cancel Project" OnClick="btnCancel_Click" Style="display: none;" />
                                                    <asp:LinkButton ID="divbtngonext"
                                                        CssClass="btnnext btn btn-sm  ms-1"
                                                        OnClick="LinkButton1_Click"
                                                        runat="server"
                                                        Style="display: none;">
                        <span>Next</span>
                        <i class="fas fa-arrow-right"></i>
                    </asp:LinkButton>
                                                </ContentTemplate>
                                                <Triggers>
                                                    <asp:AsyncPostBackTrigger ControlID="divbtngonext" EventName="click" />
                                                    <asp:AsyncPostBackTrigger ControlID="btnAdd" EventName="click" />
                                                    <asp:AsyncPostBackTrigger ControlID="ddlProName" EventName="SelectedIndexChanged" />
                                                    <asp:AsyncPostBackTrigger ControlID="ddlBlockNumber" EventName="SelectedIndexChanged" />
                                                    <asp:AsyncPostBackTrigger ControlID="ddlFlatNumber" EventName="SelectedIndexChanged" />
                                                    <asp:AsyncPostBackTrigger ControlID="ddlCostLabel" EventName="SelectedIndexChanged" />
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
                                        <h3>View Cost Details</h3>
                                    </div>
                                    <div class="table-responsive pt-4 mt-md-2 mt-0 px-4">
                                        <asp:UpdatePanel ID="UpdatePanel7" runat="server">
                                            <ContentTemplate>
                                                <asp:Repeater ID="rptCustomers" runat="server">
                                                    <HeaderTemplate>
                                                        <table class="table table-bordered" id="tblCustomers">
                                                            <thead>
                                                                <th># </th>
                                                                <th>Cost Label </th>
                                                                <th class="min-w-150">Cost</th>
                                                                <th>Action</th>
                                                            </thead>
                                                            <tbody>
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <tr>
                                                            <td><%# GetRowNo(Convert.ToString(Container.ItemIndex + 1))%> </td>
                                                            <td>
                                                                <asp:HiddenField ID="hdnCostLabelID" Value='<%# Eval("CostLabelID") %>' runat="server" />
                                                                <label class="lblCostLabel"><%# Eval("CostParameterName") %></label>
                                                                <input type="text" class="txtCostLabel" value='<%# Eval("CostParameterName") %>' style="display: none;" />
                                                            </td>
                                                            <td>
                                                                <div class="lblCost">
                                                                    <p><%#"₹" + Eval("Cost") %></p>
                                                                </div>
                                                                <input type="text" class="form-control input-sm input-value txtCost" value='<%# "₹" + Eval("Cost") %>' style="display: none;" />
                                                                <label class="lblerror" style="display: none; color: #D41111 !important;">Enter Cost</label>
                                                            </td>
                                                            <td>
                                                                <a href="javascript:void(0);" style="display: none" class="btnEdit" onclick="editRow(this)"><i class="bi bi-pencil-square b5-icon-et-dlt me-3" data-bs-toggle="tooltip" title="Edit"></i></a>
                                                                <a href="javascript:void(0);" class="btnUpdate" onclick="updateRow(this)" style="display: none;"><i class="bi bi-check2-square b5-icon-et-dlt me-3" data-bs-toggle="tooltip" title="Update"></i></a>
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
                                                <asp:AsyncPostBackTrigger ControlID="divbtngonext" EventName="click" />
                                                <asp:AsyncPostBackTrigger ControlID="btnAdd" EventName="click" />
                                                <asp:AsyncPostBackTrigger ControlID="ddlProName" EventName="SelectedIndexChanged" />
                                                <asp:AsyncPostBackTrigger ControlID="ddlBlockNumber" EventName="SelectedIndexChanged" />
                                                <asp:AsyncPostBackTrigger ControlID="ddlFlatNumber" EventName="SelectedIndexChanged" />
                                                <asp:AsyncPostBackTrigger ControlID="ddlCostLabel" EventName="SelectedIndexChanged" />
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
            var flag = Page_ClientValidate('val');
            return flag;
        }
    </script>

    <script type="text/javascript">
        function editRow(btn) {
            const row = btn.closest('tr');
            row.querySelector('.lblCost').style.display = 'none';
            row.querySelector('.txtCost').style.display = 'inline';
            row.querySelector('.btnEdit').style.display = 'none';
            row.querySelector('.btnUpdate').style.display = 'inline';
            row.querySelector('.btnCancel').style.display = 'inline';
        }
        function cancelEdit(btn) {
            const row = btn.closest('tr');
            row.querySelector('.lblCost').style.display = 'inline';
            row.querySelector('.txtCost').style.display = 'none';
            row.querySelector('.btnEdit').style.display = 'inline';
            row.querySelector('.btnUpdate').style.display = 'none';
            row.querySelector('.btnCancel').style.display = 'none';
        }
        function updateRow(btn) {
            const row = btn.closest('tr');
            const costLabelID = row.querySelector('input[type="hidden"]').value;
            const costParameterName = row.querySelector('.txtCostLabel').value;
            const cost = row.querySelector('.txtCost').value;
            const lblerror = row.querySelector('.lblerror');
            if (lblerror) {
                lblerror.style.display = 'none';
            }
            var trimcost = cost.replace(/^₹|₹$/g, '').trim();
            if (trimcost !== '' && trimcost !== '0') {
                var dropflatname = document.getElementById('<%= ddlFlatNumber.ClientID %>');
                if (!dropflatname) {
                    alert('Dropdown not found!');
                    return;
                }
                var selectedValue = dropflatname.value;

                $.ajax({
                    type: 'POST',
                    url: 'add-cost-details.aspx/UpdateCustomer',
                    data: JSON.stringify({ costLabelID, costParameterName, cost, selectedValue }),
                    contentType: 'application/json; charset=utf-8',
                    dataType: 'json',
                    success: function (response) {
                        row.querySelector('.lblCostLabel').innerText = costParameterName;
                        row.querySelector('.lblCost').innerText = "₹" + trimcost;

                        cancelEdit(btn);
                        Swal.fire({
                            icon: 'success',
                            title: 'Cost details updated successfully',
                            confirmButtonText: 'OK', customClass: { confirmButton: 'handle-btn-success', icon: 'handle-icon-clr' }
                        });

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
            } else {
                lblerror.style.fontSize = '12px !important';
                lblerror.style.color = '#D41111 !important';
                lblerror.style.display = 'inline';
            }
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
            const lblnocustomer = document.getElementById('<%= lblcustomernameerror.ClientID %>');
            var selectedValue = dropflatname.value;
            var Selectedddlproject = ddlproject.value;
            var selectedBlock = ddlblock.value;
            if (!selectedValue) {
                repeaterContainer.style.display = 'none';
                return;
            }
            $.ajax({
                type: 'POST',
                url: 'add-cost-details.aspx/GetRowCount',
                data: JSON.stringify({
                    selectedValue: selectedValue,
                    Selectedddlproject: Selectedddlproject,
                    selectedBlock: selectedBlock
                }),
                contentType: 'application/json; charset=utf-8',
                dataType: 'json',
                success: function (response) {
                    const rowCount = response.d;
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
                error: function (xhr, status, error) {
                    console.error("AJAX Error: ", status, error);
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

    </script>

    <script>
        // Function to delete cost details
        function deleteCostDetail(costLabelID, selectedValue) {
            $.ajax({
                type: 'POST',
                url: 'add-cost-details.aspx/DeleteCustomer',
                data: JSON.stringify({ costLabelID: costLabelID, selectedValue: selectedValue }),
                contentType: 'application/json; charset=utf-8',
                dataType: 'json',
                success: function (response) {
                    if (response.d != null && response.d != 0) {
                        // On success, remove the row and refresh the data
                        const row = document.querySelector(`tr[data-costlabelid="${costLabelID}"]`);
                        if (row) {
                            row.remove();
                        }

                        loadRepeaterData(selectedValue);

                        // Check if there are no rows left, hide the container
                        const table = document.getElementById('tblCustomers');
                        const rows = table.querySelectorAll('tbody tr');
                        if (rows.length === 0) {
                            const repeaterContainer = document.getElementById('<%= divrptCustomers.ClientID %>').closest('div');
                            if (repeaterContainer) {
                                repeaterContainer.style.display = 'none';
                            }
                        }

                        Swal.fire({
                            title: response.d,
                            confirmButtonText: 'Ok',
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
        }

        // Function to show the appropriate delete confirmation popup
        function showDeleteConfirmation(costLabelID, selectedValue) {
            $.ajax({
                type: 'POST',
                url: 'add-cost-details.aspx/CheckExistProjectCostLabelsParameter',
                data: JSON.stringify({ costLabelID: costLabelID }),
                contentType: 'application/json; charset=utf-8',
                dataType: 'json',
                success: function (response) {
                    if (response.d) {
                        // The condition is true, show detailed popup
                        Swal.fire({
                            title: 'Deleting this cost item will lead to deleting the payment schedule. Are you sure you want to proceed?',
                            showCancelButton: true,
                            confirmButtonText: 'Yes',
                            cancelButtonText: 'No',
                            customClass: {
                                confirmButton: 'handle-btn-danger',
                                cancelButton: 'handle-btn-success',
                            }
                        }).then((result) => {
                            if (result.isConfirmed) {
                                deleteCostDetail(costLabelID, selectedValue);
                            }
                        });
                    } else {
                        // The condition is false, show simpler popup
                        Swal.fire({
                            title: 'Are you sure you want to delete this cost item?',
                            showCancelButton: true,
                            confirmButtonText: 'Yes',
                            cancelButtonText: 'No',
                            customClass: {
                                confirmButton: 'handle-btn-danger',
                                cancelButton: 'handle-btn-success',
                            }
                        }).then((result) => {
                            if (result.isConfirmed) {
                                deleteCostDetail(costLabelID, selectedValue);
                            }
                        });
                    }
                },
                error: function () {
                    alert('Error checking condition!');
                }
            });
        }

        // Function to handle the delete button click
        function deleteRow(btn) {
            const row = btn.closest('tr');
            const hiddenField = row.querySelector('input[type="hidden"]');
            const costLabelID = hiddenField ? hiddenField.value : '';

            if (!costLabelID) {
                alert('CostLabelID is missing!');
                return;
            }
            var dropflatname = document.getElementById('<%= ddlFlatNumber.ClientID %>');
            var selectedValue = dropflatname ? dropflatname.value : '';
            // Call the function to show the delete confirmation based on the check
            showDeleteConfirmation(costLabelID, selectedValue);
        }
    </script>


    <script type="text/javascript">
        function loadRepeaterData(selectedValue) {
            $.ajax({
                type: 'POST',
                url: 'add-cost-details.aspx/GetCostDetails',
                data: JSON.stringify({ selectedValue: selectedValue }),
                contentType: 'application/json; charset=utf-8',
                dataType: 'json',
                success: function (response) {
                    if (response && response.d) {
                        const data = response.d;
                        const repeaterBody = document.querySelector('#tblCustomers tbody');
                        repeaterBody.innerHTML = '';
                        data.forEach(function (item, index) {
                            const row = document.createElement('tr');
                            row.innerHTML = `
                        <td>${index + 1}</td>
                        <td>${item.CostParameterName}</td>  
                        <td>₹${item.Cost} 
                        <asp:HiddenField ID="hdnCostLabelID" Value='${item.CostLabelID}' runat="server" />
                        <label class="lblerror" style="display:none;color:#D41111">Enter Cost</label> 
                        </td>     
                        <td> 
                                                                <a href="javascript:void(0);" style="display: none" class="btnEdit" onclick="editRow(this)"><i class="bi bi-pencil-square b5-icon-et-dlt me-3" data-bs-toggle="tooltip" title="Edit"></i></a>
                            <a href="javascript:void(0);" class="btnUpdate me-3" data-bs-toggle="tooltip" title="Update" onclick="updateRow(this)" style="display: none;"><i class="bi bi-save b5-icon-et-dlt"></i></a>
                            <a href="javascript:void(0);" class="btnCancel me-3" data-bs-toggle="tooltip" title="Cancel" onclick="cancelEdit(this)" style="display: none;"><i class="bi bi-x-square b5-icon-et-dlt"></i></a>
                            <a href="javascript:void(0);" class="btnDelete me-3" data-bs-toggle="tooltip" title="Delete" onclick="deleteRow(this)"><i class="bi bi-trash b5-icon-et-dlt"></i></a>
                        </td>
                    `;
                            repeaterBody.appendChild(row);
                        });
                        const tooltipTriggerList = [].slice.call(document.querySelectorAll('[data-bs-toggle="tooltip"]'));
                        tooltipTriggerList.forEach(function (tooltipTriggerEl) {
                            new bootstrap.Tooltip(tooltipTriggerEl);
                        });
                        const repeaterContainer = document.getElementById('<%= divrptCustomers.ClientID %>').closest('div');
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

    <script>
        function addCurrencySymbol(input) {
            if (!input.value.startsWith("₹")) {
                input.value = "₹" + input.value;
            }
        }

        document.addEventListener('input', function (e) {
            if (e.target.classList.contains('txtCost')) {
                const input = e.target;

                input.value = input.value.replace(/[^₹\d]/g, '');
                if (!input.value.startsWith('₹')) {
                    input.value = '₹' + input.value.replace('₹', '');
                }
                let numericValue = input.value.replace('₹', '');
                if (numericValue.startsWith('0') && numericValue.length > 1) {
                    numericValue = numericValue.replace(/^0+/, '');
                }
                if (numericValue.length > 10) {
                    numericValue = numericValue.slice(0, 10);
                }
                input.value = '₹' + numericValue;
            }
        });
    </script>

</asp:Content>

