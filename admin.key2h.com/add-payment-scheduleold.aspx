<%@ Page Title="" Language="C#" MasterPageFile="AdminKey2h.master" AutoEventWireup="true" CodeFile="add-payment-scheduleold.aspx.cs" Inherits="adminkey2hcom_AddPaymentSchedule" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <div class="content">
        <div class="panel-header bg-primary-gradient">
            <div class="page-inner py-5">
                <div class="d-flex pb-2 align-items-left align-items-sm-center flex-column flex-sm-row justify-content-between">
                    <div class="d-flex">
                        <h2 class="text-white mb-0 fw-bold text-uppercase">Add Payment Schedule
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
                                        <h3>Payment Schedule Details</h3>
                                    </div>
                                    <div class="row mx-0 margin-top20 mb-4">
                                        <div class="col-sm-4 col-xl-3 pt-3">
                                            <asp:UpdatePanel ID="UpdatePanel1" runat="server" RenderMode="block" UpdateMode="Conditional" ChildrenAsTriggers="true">
                                                <ContentTemplate>
                                                    <div class="input-icon input-icon-sm right">
                                                        <label>Project Name <span class="text-danger">*</span></label>
                                                        <i class="bi bi-journal-bookmark-fill b5-icon"></i>
                                                        <asp:DropDownList ID="ddlProName" AutoPostBack="true" OnSelectedIndexChanged="ddlProName_SelectedIndexChanged" class="bs-select form-control input-sm" runat="server">
                                                            <asp:ListItem Value=""></asp:ListItem>
                                                        </asp:DropDownList>
                                                    </div>
                                                    <span class="error">
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" Display="Dynamic" runat="server" ValidationGroup="projval"
                                                            ControlToValidate="ddlProName" InitialValue="" ErrorMessage="Select project name">
                                                        </asp:RequiredFieldValidator>
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator18" Display="Dynamic" runat="server" ValidationGroup="val"
                                                            ControlToValidate="ddlProName" InitialValue="" ErrorMessage="Select project name">
                                                        </asp:RequiredFieldValidator>
                                                    </span>
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
                                            <div class="input-icon input-icon-sm right">
                                                <label>Block Name <span class="text-danger">*</span></label>
                                                <i class="bi bi-building b5-icon"></i>
                                                <asp:UpdatePanel ID="UpdatePanel2" Value="3" runat="server" RenderMode="Block" UpdateMode="Conditional" ChildrenAsTriggers="true">
                                                    <ContentTemplate>
                                                        <asp:DropDownList ID="ddlBlockNumber" AutoPostBack="true" OnSelectedIndexChanged="ddlBlockNumber_SelectedIndexChanged" class="bs-select form-control input-sm" runat="server">
                                                        </asp:DropDownList>
                                                    </ContentTemplate>
                                                    <Triggers>
                                                        <asp:AsyncPostBackTrigger ControlID="ddlProName" EventName="SelectedIndexChanged" />
                                                        <asp:AsyncPostBackTrigger ControlID="ddlBlockNumber" EventName="SelectedIndexChanged" />
                                                        <asp:AsyncPostBackTrigger ControlID="ddlFlatNumber" EventName="SelectedIndexChanged" />
                                                        <asp:AsyncPostBackTrigger ControlID="btnCancel" EventName="click" />
                                                    </Triggers>
                                                </asp:UpdatePanel>
                                                <span class="error">
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ValidationGroup="projval"
                                                        ControlToValidate="ddlBlockNumber" InitialValue="" Display="Dynamic" ErrorMessage="Select block name">
                                                    </asp:RequiredFieldValidator>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator17" Display="Dynamic" runat="server" ValidationGroup="val"
                                                        ControlToValidate="ddlBlockNumber" InitialValue="" ErrorMessage="Select block name">
                                                    </asp:RequiredFieldValidator>
                                                </span>
                                            </div>
                                        </div>
                                        <div class="col-sm-4 col-xl-3 pt-3">
                                            <asp:UpdatePanel ID="UpdatePanel3" Value="3" runat="server" RenderMode="block" UpdateMode="Conditional" ChildrenAsTriggers="true">
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
                                                    <asp:AsyncPostBackTrigger ControlID="btnCancel" EventName="click" />
                                                </Triggers>
                                            </asp:UpdatePanel>
                                            <span class="error">
                                                <asp:RequiredFieldValidator ClientIDMode="Static" Display="Dynamic" EnableClientScript="true" SetFocusOnError="true" ControlToValidate="ddlFlatNumber" ValidationGroup="projval" ID="RequiredFieldValidator10" runat="server" ErrorMessage="Select flat no. "></asp:RequiredFieldValidator>
                                                <asp:RequiredFieldValidator ClientIDMode="Static" Display="Dynamic" EnableClientScript="true" SetFocusOnError="true" ControlToValidate="ddlFlatNumber" ValidationGroup="val" ID="RequiredFieldValidator13" runat="server" ErrorMessage="Select flat no. "></asp:RequiredFieldValidator>
                                            </span>
                                        </div>
                                        <div class="col-sm-4 col-xl-3 pt-3">
                                            <asp:UpdatePanel ID="UpdatePanel4" Value="3" runat="server" RenderMode="block" UpdateMode="Conditional" ChildrenAsTriggers="true">
                                                <ContentTemplate>
                                                    <div class="input-icon input-icon-sm right">
                                                        <label>Customer Name </label>
                                                        <i class="bi bi-person-square b5-icon"></i>
                                                        <asp:TextBox runat="server" ID="txtCustomerName" class="form-control input-sm" disabled="true" autocomplete="off" placeholder=""></asp:TextBox>

                                                    </div>
                                                </ContentTemplate>
                                                <Triggers>
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
                            <asp:UpdatePanel ID="UpdatePanel12" Value="3" runat="server" UpdateMode="Conditional">
                                <ContentTemplate>
                                    <div class="form-group" id="divDemandStages" clientidmode="Static" runat="server" style="display: none">
                                        <div class="form-border margin-top20">
                                            <div class="form-title">
                                                <h3>Payment Stages</h3>
                                            </div> 
                                            <div class="row mx-0 margin-top20 mb-4">
                                                <div class="col-sm-4 col-xl-3 pt-3">
                                                    <asp:UpdatePanel ID="UpdatePanel5" Value="3" runat="server" RenderMode="block" UpdateMode="Conditional" ChildrenAsTriggers="true">
                                                        <ContentTemplate>
                                                            <div class="input-icon input-icon-sm right">
                                                                <label>Payment Stage <span class="text-danger">*</span></label>
                                                                <i class="bi bi-journal-text b5-icon"></i>
                                                                <asp:DropDownList ID="ddlPaymentStages" ClientIDMode="Static" OnSelectedIndexChanged="ddlPaymentStages_SelectedIndexChanged" AutoPostBack="true" class="bs-select option-select form-control input-sm" runat="server">
                                                                </asp:DropDownList>
                                                            </div>
                                                            <span class="error">
                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" Display="Dynamic" ClientIDMode="Static" runat="server" ValidationGroup="projval"
                                                                    ControlToValidate="ddlPaymentStages" InitialValue="" ErrorMessage="Select payment stages">
                                                                </asp:RequiredFieldValidator>
                                                                <asp:Label ID="lblpaymentstagesMessage" Display="Dynamic" ClientIDMode="Static" class="" runat="server" Text=""></asp:Label>

                                                            </span>
                                                        </ContentTemplate>
                                                        <Triggers>
                                                            <asp:AsyncPostBackTrigger ControlID="ddlProName" EventName="SelectedIndexChanged" />
                                                            <asp:AsyncPostBackTrigger ControlID="ddlBlockNumber" EventName="SelectedIndexChanged" />
                                                            <asp:AsyncPostBackTrigger ControlID="ddlFlatNumber" EventName="SelectedIndexChanged" />
                                                            <asp:AsyncPostBackTrigger ControlID="ddlPaymentStages" EventName="SelectedIndexChanged" />
                                                            <asp:AsyncPostBackTrigger ControlID="calculateIcon" EventName="Click" />
                                                            <asp:AsyncPostBackTrigger ControlID="txtPercentage" EventName="TextChanged" />
                                                        </Triggers>
                                                    </asp:UpdatePanel>
                                                </div>
                                                <div class="col-sm-4 col-xl-3 pt-3">
                                                    <asp:UpdatePanel ID="UpdatePanel6" Value="3" runat="server" RenderMode="block" UpdateMode="Conditional" ChildrenAsTriggers="true">
                                                        <ContentTemplate>
                                                            <div class="input-icon input-icon-sm right">
                                                                <label>% <span class="text-danger">*</span></label>
                                                                <i class="bi bi-percent b5-icon"></i>
                                                                <asp:TextBox runat="server" ID="txtPercentage" AutoPostBack="true" EnableViewState="true" ClientIDMode="Static" MaxLength="5" OnTextChanged="txtPercentage_TextChanged"
                                                                    class="form-control input-sm" autocomplete="off" placeholder=""></asp:TextBox>
                                                                <asp:HiddenField ID="hfCalculateIconVisible" runat="server" />
                                                                <div class="handle-file-request">(in percentage)</div>
                                                            </div>
                                                            <span class="error">
                                                                <asp:RequiredFieldValidator ClientIDMode="Static" EnableClientScript="true" SetFocusOnError="true" ControlToValidate="txtPercentage" Display="Dynamic" ValidationGroup="projval" ID="RequiredFieldValidator16" runat="server" ErrorMessage="Enter percentage"></asp:RequiredFieldValidator>
                                                                <asp:RegularExpressionValidator ID="RegularExpressionValidator7" runat="server" ControlToValidate="txtPercentage" ValidationGroup="projval"
                                                                    ValidationExpression="^[0-9]+$" ErrorMessage="Enter valid percentage" Display="Dynamic"></asp:RegularExpressionValidator>
                                                                <asp:Label ID="lblenterpercentageMessage" Display="Dynamic" ClientIDMode="Static" class="" runat="server" Text=""></asp:Label>
                                                            </span>
                                                        </ContentTemplate>
                                                        <Triggers>
                                                            <asp:AsyncPostBackTrigger ControlID="ddlProName" EventName="SelectedIndexChanged" />
                                                            <asp:AsyncPostBackTrigger ControlID="ddlBlockNumber" EventName="SelectedIndexChanged" />
                                                            <asp:AsyncPostBackTrigger ControlID="ddlFlatNumber" EventName="SelectedIndexChanged" />
                                                            <asp:AsyncPostBackTrigger ControlID="ddlPaymentStages" EventName="SelectedIndexChanged" />
                                                            <asp:AsyncPostBackTrigger ControlID="calculateIcon" EventName="Click" />
                                                            <asp:AsyncPostBackTrigger ControlID="txtPercentage" EventName="TextChanged" />
                                                        </Triggers>
                                                    </asp:UpdatePanel>
                                                </div>
                                                <div class="col-sm-4 col-xl-4 pt-5">
                                                    <asp:UpdatePanel ID="UpdatePanel13" Value="3" runat="server" RenderMode="block" UpdateMode="Conditional" ChildrenAsTriggers="true">
                                                        <ContentTemplate>
                                                            <div id="addFileUploadBtn">
                                                                <asp:LinkButton ID="calculateIcon" class="btn addprogressRows" ClientIDMode="Static" OnClick="calculateIcon_Click" runat="server">
                                                            <i class="bi bi-calculator b5-icon-et-dlt"></i> Calculate
                                                                </asp:LinkButton>
                                                            </div>
                                                        </ContentTemplate>
                                                        <Triggers>
                                                            <asp:AsyncPostBackTrigger ControlID="ddlProName" EventName="SelectedIndexChanged" />
                                                            <asp:AsyncPostBackTrigger ControlID="ddlBlockNumber" EventName="SelectedIndexChanged" />
                                                            <asp:AsyncPostBackTrigger ControlID="ddlFlatNumber" EventName="SelectedIndexChanged" />
                                                            <asp:AsyncPostBackTrigger ControlID="ddlPaymentStages" EventName="SelectedIndexChanged" />
                                                            <asp:AsyncPostBackTrigger ControlID="calculateIcon" EventName="Click" />
                                                            <asp:AsyncPostBackTrigger ControlID="linkbtnclickhere" EventName="click" />
                                                        </Triggers>
                                                    </asp:UpdatePanel>
                                                </div>
                                                <div class="col-sm-4 col-xl-3 pt-3">
                                                    <asp:UpdatePanel ID="UpdatePanel7" Value="3" runat="server" RenderMode="block" UpdateMode="Conditional" ChildrenAsTriggers="true">
                                                        <ContentTemplate>
                                                            <div class="input-icon input-icon-sm right">
                                                                <label>Sub Amount</label>
                                                                <i class="bi bi-cash-stack b5-icon"></i>
                                                                <asp:TextBox runat="server" ID="txtsubAmount" ClientIDMode="Static" EnableViewState="true" class="form-control input-sm" disabled="true" placeholder="₹"></asp:TextBox>
                                                            </div>
                                                        </ContentTemplate>
                                                        <Triggers>
                                                            <asp:AsyncPostBackTrigger ControlID="ddlProName" EventName="SelectedIndexChanged" />
                                                            <asp:AsyncPostBackTrigger ControlID="ddlBlockNumber" EventName="SelectedIndexChanged" />
                                                            <asp:AsyncPostBackTrigger ControlID="ddlFlatNumber" EventName="SelectedIndexChanged" />
                                                            <asp:AsyncPostBackTrigger ControlID="ddlPaymentStages" EventName="SelectedIndexChanged" />
                                                            <asp:AsyncPostBackTrigger ControlID="calculateIcon" EventName="Click" />
                                                            <asp:AsyncPostBackTrigger ControlID="txtPercentage" EventName="TextChanged" />
                                                        </Triggers>
                                                    </asp:UpdatePanel>
                                                </div>

                                                <div class="col-sm-4 col-xl-3 pt-3">
                                                    <asp:UpdatePanel ID="UpdatePanel8" Value="3" runat="server" UpdateMode="Conditional">
                                                        <ContentTemplate>
                                                            <div class="input-icon input-icon-sm right">
                                                                <label>GST</label>
                                                                <i class="bi bi-device-hdd b5-icon"></i>
                                                                <asp:TextBox runat="server" ID="txtGST" ClientIDMode="Static" EnableViewState="true" class="form-control input-sm" disabled="true" placeholder="₹"></asp:TextBox>
                                                            </div>
                                                        </ContentTemplate>
                                                        <Triggers>
                                                            <asp:AsyncPostBackTrigger ControlID="ddlProName" EventName="SelectedIndexChanged" />
                                                            <asp:AsyncPostBackTrigger ControlID="ddlBlockNumber" EventName="SelectedIndexChanged" />
                                                            <asp:AsyncPostBackTrigger ControlID="ddlFlatNumber" EventName="SelectedIndexChanged" />
                                                            <asp:AsyncPostBackTrigger ControlID="ddlPaymentStages" EventName="SelectedIndexChanged" />
                                                            <asp:AsyncPostBackTrigger ControlID="calculateIcon" EventName="Click" />
                                                            <asp:AsyncPostBackTrigger ControlID="txtPercentage" EventName="TextChanged" />
                                                        </Triggers>
                                                    </asp:UpdatePanel>
                                                </div>
                                                <div class="col-sm-4 col-xl-3 pt-3">
                                                    <asp:UpdatePanel ID="UpdatePanel9" Value="3" runat="server" RenderMode="block" UpdateMode="Conditional" ChildrenAsTriggers="true">
                                                        <ContentTemplate>
                                                            <div class="input-icon input-icon-sm right">
                                                                <label>NET</label>
                                                                <i class="bi bi-device-ssd b5-icon"></i>
                                                                <asp:TextBox runat="server" ID="txtNET" ClientIDMode="Static" EnableViewState="true" class="form-control input-sm" disabled="true" placeholder="₹"></asp:TextBox>
                                                            </div>
                                                        </ContentTemplate>
                                                        <Triggers>
                                                            <asp:AsyncPostBackTrigger ControlID="ddlProName" EventName="SelectedIndexChanged" />
                                                            <asp:AsyncPostBackTrigger ControlID="ddlBlockNumber" EventName="SelectedIndexChanged" />
                                                            <asp:AsyncPostBackTrigger ControlID="ddlFlatNumber" EventName="SelectedIndexChanged" />
                                                            <asp:AsyncPostBackTrigger ControlID="ddlPaymentStages" EventName="SelectedIndexChanged" />
                                                            <asp:AsyncPostBackTrigger ControlID="calculateIcon" EventName="Click" />
                                                            <asp:AsyncPostBackTrigger ControlID="txtPercentage" EventName="TextChanged" />
                                                        </Triggers>
                                                    </asp:UpdatePanel>
                                                </div>
                                            </div>
                                            <div class="d-flex align-items-center justify-content-center">
                                                <asp:Label ID="lblcostlabelcounterrormsg" CssClass="error-label" ForeColor="#D41111" runat="server" Text=""></asp:Label>
                                                <asp:LinkButton ID="linkbtnclickhere" CssClass="ml-2" ForeColor="InfoText" OnClick="linkbtnclickhere_Click" Style="display: none;" runat="server">Click here</asp:LinkButton>
                                            </div>
                                            <div class="card-footer  mx-2 pb-4">
                                                <asp:UpdatePanel ID="UpdatePanel10" runat="server" UpdateMode="Conditional">
                                                    <ContentTemplate>
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
                                                    </ContentTemplate>
                                                    <Triggers>
                                                        <asp:AsyncPostBackTrigger ControlID="ddlProName" EventName="SelectedIndexChanged" />
                                                        <asp:AsyncPostBackTrigger ControlID="ddlBlockNumber" EventName="SelectedIndexChanged" />
                                                        <asp:AsyncPostBackTrigger ControlID="ddlFlatNumber" EventName="SelectedIndexChanged" />
                                                        <asp:AsyncPostBackTrigger ControlID="ddlPaymentStages" EventName="SelectedIndexChanged" />
                                                        <asp:AsyncPostBackTrigger ControlID="btnCancel" EventName="click" />
                                                        <asp:AsyncPostBackTrigger ControlID="calculateIcon" EventName="Click" />
                                                        <asp:AsyncPostBackTrigger ControlID="txtPercentage" EventName="TextChanged" />
                                                    </Triggers>
                                                </asp:UpdatePanel>
                                            </div>
                                        </div> 
                                    </div>
                                </ContentTemplate>
                                <Triggers>
                                    <asp:AsyncPostBackTrigger ControlID="ddlProName" EventName="SelectedIndexChanged" />
                                    <asp:AsyncPostBackTrigger ControlID="ddlBlockNumber" EventName="SelectedIndexChanged" />
                                    <asp:AsyncPostBackTrigger ControlID="ddlFlatNumber" EventName="SelectedIndexChanged" />
                                    <asp:AsyncPostBackTrigger ControlID="ddlPaymentStages" EventName="SelectedIndexChanged" />
                                    <asp:AsyncPostBackTrigger ControlID="txtPercentage" EventName="TextChanged" />
                                    <asp:AsyncPostBackTrigger ControlID="btnCancel" EventName="click" />
                                    <asp:AsyncPostBackTrigger ControlID="calculateIcon" EventName="Click" />
                                    <asp:AsyncPostBackTrigger ControlID="btnSave" EventName="click" />
                                    <asp:AsyncPostBackTrigger ControlID="linkbtnclickhere" EventName="click" />
                                </Triggers>
                            </asp:UpdatePanel>

                            <div class="form-group">
                            </div>
                            <asp:UpdatePanel ID="UpdatePanel11" runat="server">
                                <ContentTemplate>
                                    <div class="form-group" id="divrptCustomers" clientidmode="Static" runat="server">
                                        <div class="form-border margin-top20">
                                            <div class="form-title">
                                                <h3>View Cost Details</h3>
                                            </div>
                                            <div class="table-responsive pt-4 mt-md-2 mt-0 px-4">
                                                <asp:Repeater ID="rptsheduler" runat="server">
                                                    <HeaderTemplate>
                                                        <table class="table table-bordered" id="tblCustomers">
                                                            <thead>
                                                                <th># </th>
                                                                <th>Payment Stages</th>
                                                                <th>%</th>
                                                                <th>Sub Amount</th>
                                                                <th>GST</th>
                                                                <th>NET</th>
                                                                <th>Delete</th>
                                                            </thead>
                                                            <tbody>
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <tr>
                                                            <td><%# GetRowNo(Convert.ToString(Container.ItemIndex + 1))%> </td>
                                                            <td>
                                                                <asp:HiddenField ID="hdnPSID" Value='<%# Eval("PSID") %>' runat="server" />
                                                                <label class="lblCostLabel"><%# Eval("PaymentLabel") %></label>
                                                            </td>
                                                            <td class="lblCost"><%# Eval("PaymentPercentage") != null && !string.IsNullOrEmpty(Eval("PaymentPercentage").ToString())? Convert.ToInt32(Eval("PaymentPercentage")): 0 %> %</td>
                                                            <td class="lblCost">₹<%# Eval("SubAmount") %> </td>
                                                            <td class="lblCost">₹<%# Eval("GST") %> </td>
                                                            <td>₹<%# Convert.ToDecimal(Eval("SubAmount")) + Convert.ToDecimal(Eval("GST")) %>  </td>
                                                            <td >
                                                                <a href="javascript:void(0);" class="btnDelete" onclick="deleteRow(this)"><i class="bi bi-trash b5-icon-et-dlt" data-bs-toggle="tooltip" title="Delete"></i></a>
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
                                    <asp:AsyncPostBackTrigger ControlID="ddlProName" EventName="SelectedIndexChanged" />
                                    <asp:AsyncPostBackTrigger ControlID="ddlBlockNumber" EventName="SelectedIndexChanged" />
                                    <asp:AsyncPostBackTrigger ControlID="ddlFlatNumber" EventName="SelectedIndexChanged" />
                                    <asp:AsyncPostBackTrigger ControlID="btnCancel" EventName="click" />
                                    <asp:AsyncPostBackTrigger ControlID="btnSave" EventName="click" />
                                    <asp:AsyncPostBackTrigger ControlID="txtPercentage" EventName="TextChanged" />
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
        function validatePage() {
            var flag = Page_ClientValidate('projval');
            const requiredFieldValidator = document.getElementById("<%= lblpaymentstagesMessage.ClientID %>").textContent = '';
            const lblenterpercentageMessage = document.getElementById("<%= lblenterpercentageMessage.ClientID %>").textContent = ''; 
            return flag;
        }
        document.addEventListener("DOMContentLoaded", function () {
            // Attach keypress validation on initial page load
            initializePercentageValidationNumber();

            if (typeof Sys !== "undefined" && Sys.WebForms && Sys.WebForms.PageRequestManager) {
                const prm = Sys.WebForms.PageRequestManager.getInstance();
                prm.add_endRequest(function () {
                    initializePercentageValidationNumber();
                });
            }
        });

        function initializePercentageValidationNumber() {
            const txtPercentage = document.getElementById('<%= txtPercentage.ClientID %>');
            if (txtPercentage) {
                txtPercentage.addEventListener('keypress', function (e) {
                    if (!/^[0-9]$/.test(e.key)) {
                        e.preventDefault();
                    }
                });
            }
        } 
    </script>

    <script>
        document.addEventListener("DOMContentLoaded", function () {
            initializePercentageValidation();
            attachSweetAlert();
            initializePercentageValidationNumber(); 
        });

        function initializePercentageValidation() {
            const textBox = document.getElementById("<%= txtPercentage.ClientID %>");
            const txtsubAmount = document.getElementById("<%= txtsubAmount.ClientID %>");
            const txtNET = document.getElementById("<%= txtNET.ClientID %>");
            const txtGST = document.getElementById("<%= txtGST.ClientID %>");
            const calculateIcon = document.getElementById("calculateIcon");
            const dropStages = document.getElementById("<%= ddlPaymentStages.ClientID %>");
            const requiredFieldValidator = document.getElementById("<%= lblpaymentstagesMessage.ClientID %>");
            const lblenterpercentageMessage = document.getElementById("<%= lblenterpercentageMessage.ClientID %>");
            const requiredFieldValidator3 = document.getElementById("RequiredFieldValidator3");
            const hiddenField = document.getElementById("<%= hfCalculateIconVisible.ClientID %>"); 
            if (!textBox || !calculateIcon || !dropStages || !requiredFieldValidator || !hiddenField) {
                console.warn("One or more required elements are missing.");
                return;
            } 
            // Restore visibility of calculateIcon
            //calculateIcon.style.display = hiddenField.value === "true" ? "inline" : "none"; 
            textBox.addEventListener("input", function () {
                const value = textBox.value.trim();
                if (/^\d{1,}$/.test(value)) {
                    //calculateIcon.style.display = "block";
                    hiddenField.value = "true";
                    if (dropStages.value.trim() === '') {
                        requiredFieldValidator.textContent = "Select payment stages";
                        requiredFieldValidator.style.display = "block"; 
                    }
                    else {
                        requiredFieldValidator.textContent = '';
                        requiredFieldValidator.style.display = "none";
                        lblenterpercentageMessage.textContent = '';
                        lblenterpercentageMessage.style.display = "none";
                    }
                }
                else {
                    //calculateIcon.style.display = "block";
                    hiddenField.value = "false";
                    requiredFieldValidator.textContent = '';
                    requiredFieldValidator.style.display = "none";
                    lblenterpercentageMessage.textContent = '';
                    lblenterpercentageMessage.style.display = "none";

                    // Clear sub amount, net amount, and GST
                    txtsubAmount.value = '';
                    txtNET.value = '';
                    txtGST.value = '';
                }
            });
             
            dropStages.addEventListener("change", function () {
                if (dropStages.value.trim() === '') {
                    /* if (requiredFieldValidator3.style.display === 'inline') {*/
                    requiredFieldValidator.textContent = '';
                    requiredFieldValidator.style.display = "none";
                    lblenterpercentageMessage.textContent = '';
                    lblenterpercentageMessage.style.display = "none";
                } else {
                    requiredFieldValidator.textContent = '';
                    requiredFieldValidator.style.display = "none";
                    lblenterpercentageMessage.textContent = '';
                    lblenterpercentageMessage.style.display = "none";
                }
            });
             
            document.getElementById("calculateIcon").addEventListener("click", function (event) {
                if (textBox.value.trim() !== '') {
                    lblenterpercentageMessage.textContent = '';
                    lblenterpercentageMessage.style.display = "none";
                } else {
                    // Show the error message
                    lblenterpercentageMessage.textContent = "Enter percentage";
                    lblenterpercentageMessage.style.display = "block";
                }
            }); 
        }
         
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
                            cancelButton: 'handle-btn-success'
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

        function deleteRow(btn) {
            Swal.fire({
                title: 'Are you sure you want to delete?',
                showCancelButton: true,
                confirmButtonText: 'Yes',
                cancelButtonText: 'No',
                customClass: {
                    confirmButton: 'handle-btn-danger',
                    cancelButton: 'handle-btn-success'
                }
            }).then((result) => {
                if (result.isConfirmed) {
                    const row = btn.closest('tr');
                    const hiddenField = row.querySelector('input[type="hidden"]');
                    const hdnPSID = hiddenField ? hiddenField.value : ''; 
                    if (!hdnPSID) {
                        alert('Schedule is missing!');
                        return;
                    } 
                    const dropFlatName = document.getElementById('<%= ddlFlatNumber.ClientID %>');
                    const selectedValue = dropFlatName ? dropFlatName.value : '';

                    $.ajax({
                        type: 'POST',
                        url: 'add-payment-schedule.aspx/DeleteShedulestages',
                        data: JSON.stringify({ hdnPSID: hdnPSID }),
                        contentType: 'application/json; charset=utf-8',
                        dataType: 'json',
                        success: function (response) {
                            if (response.d == 1 || response.d === "1") {
                                loadRepeaterData(selectedValue);
                                row.remove();
                                const table = document.getElementById('tblCustomers');
                                const rows = Array.from(table.querySelectorAll('tbody tr'));
                                if (rows.length === 0) {
                                    const repeaterContainer = document.getElementById('<%= divrptCustomers.ClientID %>').closest('div');
                                    if (repeaterContainer) {
                                        repeaterContainer.style.display = 'none';
                                    }
                                }
                                Swal.fire({
                                    title: 'Payment schedule details has been deleted',
                                    confirmButtonText: 'Ok',
                                    customClass: {
                                        confirmButton: 'handle-btn-success'
                                    }
                                });
                            }
                        },
                        error: function () {
                            alert('Error deleting row!');
                        }
                    });
                }
            });
        }

        function loadRepeaterData(selectedValue) {
            $.ajax({
                type: 'POST',
                url: 'add-payment-schedule.aspx/GetCostDetails',
                data: JSON.stringify({ selectedValue: selectedValue }),
                contentType: 'application/json; charset=utf-8',
                dataType: 'json',
                success: function (response) {
                    if (response && response.d) {
                        const data = response.d;
                        const repeaterBody = document.querySelector('#tblCustomers tbody');
                        if (!repeaterBody) {
                            return;
                        }
                        repeaterBody.innerHTML = '';
                        const fragment = document.createDocumentFragment();
                        data.forEach((item, index) => {
                            const row = document.createElement('tr');
                            row.innerHTML = `
                            <td>${index + 1}</td>
                            <td>
                                <input type="hidden" class="hdnid" value="${item.PSID}" />
                                <label>${item.PaymentStages}</label>
                            </td>
                            <td>${item.Percentage}</td>
                            <td>${item.Amount}</td>
                            <td>${item.GST}</td>
                            <td>${item.NET}</td>
                            <td>
                                <a href="javascript:void(0);" class="btnDelete" onclick="deleteRow(this)">
                                    <i class="bi bi-trash b5-icon-et-dlt" data-bs-toggle="tooltip" title="Delete"></i>
                                </a>
                            </td>`;
                            fragment.appendChild(row);
                        });
                        repeaterBody.appendChild(fragment);
                        const tableContainer = document.querySelector('#tblCustomers').closest('div');
                        if (tableContainer) {
                            tableContainer.style.display = data.length > 0 ? 'inline-block' : 'none';
                        }
                    } else {
                        alert('No data found.');
                    }
                },
                error: function () {
                    alert('Error loading data!');
                }
            });
        }

        // Handle partial postbacks
        if (typeof Sys !== "undefined" && Sys.WebForms && Sys.WebForms.PageRequestManager) {
            const prm = Sys.WebForms.PageRequestManager.getInstance();
            prm.add_endRequest(function () {
                initializePercentageValidation();
                attachSweetAlert();
                //initializePercentageValidationNumber();
            });
        }
    </script>

</asp:Content>

