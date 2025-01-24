<%@ Page Title="" Language="C#" MasterPageFile="AdminKey2h.master" AutoEventWireup="true" CodeFile="view-flat-booking.aspx.cs" Inherits="adminkey2hcom_ViewFlatBooking" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="content">
        <div class="panel-header bg-primary-gradient">
            <div class="page-inner py-5">
                <div class="d-flex pb-2 align-items-left align-items-md-center flex-column flex-md-row justify-content-between">
                    <div class="d-flex">
                        <h2 class="text-white mb-0 fw-bold text-uppercase">View Flat Booking</h2>
                        <ul class="breadcrumbs">
                            <li class="nav-home pt-1">
                                <a href="dashboard.html">
                                    <i class="fa fa-home"></i>
                                </a>
                            </li>
                        </ul>
                    </div>
                    <div class="text-end">
                        <asp:LinkButton class="edit-img me-2 " data-bs-toggle="tooltip" title="Export to excel" CssClass="me-3 " OnClick="btnSubmitExport_Click" ID="lkedit" runat="server">
                            <i class="bi bi-filetype-xls add-view-img"></i>
                        </asp:LinkButton>
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
                                    <div class="col-sm-4 col-xl-4 pt-3"> 
                                        <asp:UpdatePanel ID="UpdatePanel434" runat="server">
                                            <ContentTemplate>
                                                <div class="input-icon input-icon-sm right">
                                                    <label>Search <span class="text-danger">*</span></label>
                                                    <asp:LinkButton ID="lnkbtngo" OnClientClick="if (validatePage()) { this.value='Please wait..'; this.style.display='none'; this.style.display = 'none'; } else { return false; }" Style="min-width: 67px;" OnClick="lnkbtngo_Click" runat="server">
                                                        <i class="bi bi-search bg-after-search text-dark b5-icon" data-bs-toggle="tooltip" title="Search"></i>
                                                    </asp:LinkButton>
                                                    <asp:TextBox ID="txtsearch" class="form-control input-sm" MaxLength="10" runat="server" placeholder="By flat/phone number"></asp:TextBox>
                                                </div>
                                                <span class="error">
                                                    <asp:RequiredFieldValidator ClientIDMode="Static" Display="Dynamic" EnableClientScript="true" SetFocusOnError="true" ControlToValidate="txtsearch" ValidationGroup="val" ID="RequiredFieldValidator2" runat="server" ErrorMessage=""></asp:RequiredFieldValidator>
                                                    <asp:RegularExpressionValidator ClientIDMode="Static" ID="RegularExpressionValidator16" Display="Dynamic" runat="server" ValidationGroup="val" ControlToValidate="txtsearch" ValidationExpression="^[a-zA-Z\d]{0,10}$" ErrorMessage="Enter valid flat/mobile number"></asp:RegularExpressionValidator>
                                                </span>
                                            </ContentTemplate>
                                            <Triggers>
                                                <asp:AsyncPostBackTrigger ControlID="lnkbtngo" EventName="Click" />
                                                <asp:AsyncPostBackTrigger ControlID="lnkcancel" EventName="Click" />
                                                <asp:AsyncPostBackTrigger ControlID="ddlprojectname" EventName="SelectedIndexChanged" />
                                                <asp:AsyncPostBackTrigger ControlID="ddlblocknumber" EventName="SelectedIndexChanged" />
                                                <asp:AsyncPostBackTrigger ControlID="ddlflatNumber" EventName="SelectedIndexChanged" />
                                            </Triggers>
                                        </asp:UpdatePanel> 
                                    </div>

                                    <div class="col-sm-4 col-xl-2 pt-3"> 
                                        <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                                            <ContentTemplate>
                                                <div class="input-icon input-icon-sm right">
                                                    <label>Project Name <span class="text-danger">*</span></label>
                                                    <i class="bi bi-journal-bookmark-fill b5-icon"></i>
                                                    <asp:DropDownList ID="ddlprojectname" ClientIDMode="Static" class="form-control input-sm" AutoPostBack="true" OnSelectedIndexChanged="ddlprojectname_SelectedIndexChanged" runat="server">
                                                        <asp:ListItem Value="" Text="All"></asp:ListItem> 
                                                    </asp:DropDownList>
                                                </div>
                                            </ContentTemplate>
                                            <Triggers>
                                                <asp:AsyncPostBackTrigger ControlID="lnkbtngo" EventName="Click" />
                                                <asp:AsyncPostBackTrigger ControlID="lnkcancel" EventName="Click" />
                                                <asp:AsyncPostBackTrigger ControlID="ddlprojectname" EventName="SelectedIndexChanged" />
                                                <asp:AsyncPostBackTrigger ControlID="ddlblocknumber" EventName="SelectedIndexChanged" />
                                                <asp:AsyncPostBackTrigger ControlID="ddlflatNumber" EventName="SelectedIndexChanged" />
                                            </Triggers>
                                        </asp:UpdatePanel> 
                                    </div>
                                     
                                    <div class="col-sm-4 col-xl-2 pt-3">
                                        <asp:UpdatePanel ID="UpdatePanel4" runat="server" RenderMode="Block" UpdateMode="Conditional" ChildrenAsTriggers="true">
                                            <ContentTemplate>
                                                <div class="input-icon input-icon-sm right">
                                                    <label>Block Name <span class="text-danger">*</span></label>
                                                    <i class="bi bi-building b5-icon"></i>
                                                    <asp:DropDownList ID="ddlblocknumber" ClientIDMode="Static" OnSelectedIndexChanged="ddlblocknumber_SelectedIndexChanged" AutoPostBack="true" class="form-control input-sm" runat="server">
                                                        <asp:ListItem Value="" Text="All"></asp:ListItem> 
                                                    </asp:DropDownList>
                                                </div>
                                            </ContentTemplate>
                                            <Triggers>
                                                <asp:AsyncPostBackTrigger ControlID="lnkbtngo" EventName="Click" />
                                                <asp:AsyncPostBackTrigger ControlID="lnkcancel" EventName="Click" />
                                                <asp:AsyncPostBackTrigger ControlID="ddlprojectname" EventName="SelectedIndexChanged" />
                                                <asp:AsyncPostBackTrigger ControlID="ddlblocknumber" EventName="SelectedIndexChanged" />
                                                <asp:AsyncPostBackTrigger ControlID="ddlflatNumber" EventName="SelectedIndexChanged" />
                                            </Triggers>
                                        </asp:UpdatePanel>
                                    </div>
                                    <div class="col-sm-4 col-xl-2 pt-3">
                                        <asp:UpdatePanel ID="UpdatePanel1" runat="server" RenderMode="Block" UpdateMode="Conditional" ChildrenAsTriggers="true">
                                            <ContentTemplate>
                                                <div class="input-icon input-icon-sm right">
                                                    <label>Flat Number <span class="text-danger">*</span></label>
                                                    <i class="bi bi-file-binary b5-icon"></i>
                                                    <asp:DropDownList ID="ddlflatNumber" ClientIDMode="Static" AutoPostBack="true" OnSelectedIndexChanged="ddflatNumber_SelectedIndexChanged" class="form-control input-sm" runat="server">
                                                        <asp:ListItem Value="" Text="All"></asp:ListItem> 
                                                    </asp:DropDownList>
                                                </div>
                                            </ContentTemplate>
                                            <Triggers>
                                                <asp:AsyncPostBackTrigger ControlID="lnkbtngo" EventName="Click" />
                                                <asp:AsyncPostBackTrigger ControlID="lnkcancel" EventName="Click" />
                                                <asp:AsyncPostBackTrigger ControlID="ddlprojectname" EventName="SelectedIndexChanged" />
                                                <asp:AsyncPostBackTrigger ControlID="ddlblocknumber" EventName="SelectedIndexChanged" />
                                                <asp:AsyncPostBackTrigger ControlID="ddlflatNumber" EventName="SelectedIndexChanged" />
                                            </Triggers>
                                        </asp:UpdatePanel>
                                    </div>
                                     
                                    <div class="col-sm-2 pt-3 d-flex add-bs-1"> 
                                        <asp:UpdatePanel ID="UpdatePanel7" runat="server">
                                            <ContentTemplate>
                                                <asp:LinkButton ID="lnkcancel" data-bs-toggle="tooltip" title="Reset" OnClick="lnkcancel_Click" class="b5-icon-reset" runat="server">
                                                    <i class="bi bi-repeat"></i>
                                                </asp:LinkButton> 
                                            </ContentTemplate>
                                            <Triggers> 
                                                <asp:AsyncPostBackTrigger ControlID="lnkbtngo" EventName="Click" />
                                                <asp:AsyncPostBackTrigger ControlID="lnkcancel" EventName="Click" />
                                                <asp:AsyncPostBackTrigger ControlID="ddlprojectname" EventName="SelectedIndexChanged" />
                                                <asp:AsyncPostBackTrigger ControlID="ddlblocknumber" EventName="SelectedIndexChanged" />
                                                <asp:AsyncPostBackTrigger ControlID="ddlflatNumber" EventName="SelectedIndexChanged" /> 
                                            </Triggers>
                                        </asp:UpdatePanel>
                                    </div> 
                                </div>

                                <asp:UpdatePanel ID="UpdatePanel6" runat="server">
                                    <ContentTemplate>
                                        <h5 id="h5TotalNoCount" runat="server"><span class="box-b-only p-1">Total no. of Count :
                                            <asp:Label ID="lblcount" runat="server" Text="Label"></asp:Label>
                                        </span></h5>

                                    </ContentTemplate>
                                    <Triggers>
                                        <asp:AsyncPostBackTrigger ControlID="lnkbtngo" EventName="Click" />
                                        <asp:AsyncPostBackTrigger ControlID="lnkcancel" EventName="Click" />
                                        <asp:AsyncPostBackTrigger ControlID="ddlprojectname" EventName="SelectedIndexChanged" />
                                        <asp:AsyncPostBackTrigger ControlID="ddlblocknumber" EventName="SelectedIndexChanged" />
                                        <asp:AsyncPostBackTrigger ControlID="ddlflatNumber" EventName="SelectedIndexChanged" />
                                    </Triggers>
                                </asp:UpdatePanel> 
                                <asp:UpdatePanel ID="UpdatePanel8" runat="server">
                                    <ContentTemplate>
                                        <div class="text-center no-data-found" clientidmode="Static" id="DivNoDataFound" runat="server" style="display: none;">
                                            <h4 class="mb-0 text-secondary pt-5 pb-4">
                                                <img src="assets/img/no-data.png" alt="img" class="img-fluid" />
                                                No Data Found</h4>
                                        </div>
                                    </ContentTemplate>
                                    <Triggers>
                                        <asp:AsyncPostBackTrigger ControlID="lnkbtngo" EventName="Click" />
                                        <asp:AsyncPostBackTrigger ControlID="lnkcancel" EventName="Click" />
                                        <asp:AsyncPostBackTrigger ControlID="ddlprojectname" EventName="SelectedIndexChanged" />
                                        <asp:AsyncPostBackTrigger ControlID="ddlblocknumber" EventName="SelectedIndexChanged" />
                                        <asp:AsyncPostBackTrigger ControlID="ddlflatNumber" EventName="SelectedIndexChanged" />
                                    </Triggers>
                                </asp:UpdatePanel>
                            </div>
                            <div class="table-responsive">
                                <asp:UpdatePanel ID="UpdatePanel5" runat="server">
                                    <ContentTemplate>
                                        <asp:Repeater ID="rpruser" OnItemCommand="Repeater1_ItemCommand" runat="server">
                                            <HeaderTemplate>
                                                <table class="table table-bordered" id="basic-datatables" role="grid" aria-describedby="basic-datatables_info">
                                                    <thead>
                                                        <tr>
                                                            <th class="w-sno">#</th>
                                                            <th class="min-w-120">Customer Name</th>
                                                            <th class="min-w-120 d-none">Customer ID </th>
                                                            <th class="min-w-120">Project Name </th>
                                                            <th class="min-w-120">Block Name</th>
                                                            <th class="min-w-120">Flat No. </th>
                                                            <th class="min-w-120">Flat Login ID </th>
                                                            <th class="min-w-120">Email ID </th>
                                                            <th class="min-w-120">Mobile No. </th>
                                                            <%--<th>Display Status</th>--%>
                                                            <th class="min-w-120">Action </th>
                                                        </tr>
                                                    </thead>
                                                    <tbody>
                                            </HeaderTemplate>
                                            <ItemTemplate>
                                                <tr>
                                                    <asp:HiddenField ID="HiddenField1" Value='<%# Eval("FlatCustomerID") %>' runat="server" />
                                                    <td>
                                                        <%# GetRowNo(Convert.ToString(Container.ItemIndex + 1))%> 
                                                    </td>
                                                    <td>
                                                        <%#Eval("ApplicantFirstName") %>
                                                    </td>
                                                    <td class="d-none">
                                                        <%# Eval("CustomerID") %> 
                                                    </td>
                                                    <td>
                                                        <%# Bindproject(Convert.ToInt32((Eval("ProjectID")))) %> 
                                                    </td>
                                                    <td><%# BindBlockname(Convert.ToInt32(Eval("BlockID")))%></td>
                                                    <td><%#ViewFlatNameByFlatID(Convert.ToInt32(Eval("FlatID"))) %></td>
                                                    <td> <%# Eval("FlatLoginID") %> </td>
                                                    <td> <%# Eval("EmailID") %> </td>
                                                    <td>  <%# Eval("Mobilenumber1") %> </td> 
                                                    <td>
                                                        <asp:LinkButton class="edit-img me-3" data-bs-toggle="tooltip" title="Edit" ID="lkedit" runat="server" CommandName="Edit"
                                                            CommandArgument='<%# DataBinder.Eval(Container.DataItem, "FlatCustomerID") %>'>
                                                            <i class="bi bi-pencil-square b5-icon-et-dlt"></i>
                                                        </asp:LinkButton>

                                                        <asp:LinkButton class="edit-img " data-bs-toggle="tooltip" title="Download Full Details" ID="btnexportindivitualrecords" runat="server" CommandName="btnexportindivitualrecords"
                                                            CommandArgument='<%# DataBinder.Eval(Container.DataItem, "FlatCustomerID") %>'>
                                                            <i class="bi bi-journal-arrow-down b5-icon-et-dlt"></i>
                                                        </asp:LinkButton>
                                                        <a class="swtAltCancel d-none">
                                                            <i class="dlt-img bi bi-trash b5-icon-et-dlt" data-bs-toggle="tooltip" title="Delete"></i>
                                                        </a>
                                                        <asp:LinkButton ID="LinkButton2" CausesValidation="false" runat="server" class="dlt-img hidden" Text="Delete" CommandName="Delete" CommandArgument='<%# Eval("FlatCustomerID") %>' Style="display: none">
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
                                        <asp:AsyncPostBackTrigger ControlID="lnkbtngo" EventName="Click" />
                                        <asp:AsyncPostBackTrigger ControlID="lnkcancel" EventName="Click" />
                                        <asp:AsyncPostBackTrigger ControlID="ddlprojectname" EventName="SelectedIndexChanged" />
                                        <asp:AsyncPostBackTrigger ControlID="ddlblocknumber" EventName="SelectedIndexChanged" />
                                        <asp:AsyncPostBackTrigger ControlID="ddlflatNumber" EventName="SelectedIndexChanged" /> 
                                    </Triggers>
                                </asp:UpdatePanel>
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
        function addSearchKeyPressListener() {
            // Prevent non-numeric characters during typing 
            document.getElementById('<%= txtsearch.ClientID %>').addEventListener('keypress', function (e) {
                if (!/^[a-zA-Z0-9]$/.test(e.key) && e.key !== 'Backspace' && e.key !== 'Delete') {
                    e.preventDefault();
                }
            });
             
            document.getElementById('<%= txtsearch.ClientID %>').addEventListener('input', function (e) {
                this.value = this.value.replace(/[^a-zA-Z0-9]/g, '');
            }); 
        }

        Sys.Application.add_load(function () {
            addSearchKeyPressListener();
        });
        Sys.WebForms.PageRequestManager.getInstance().add_endRequest(function () {
            addSearchKeyPressListener();
        });
    </script>
     
    <script> 
        function validatePage() {
            var flag = Page_ClientValidate('val')
            return flag;
        }
          
        function initializeDeleteEvents() {
            const cancelButtons = document.querySelectorAll('.swtAltCancel'); 
            cancelButtons.forEach((cancelButton) => {
                cancelButton.addEventListener('click', function () {
                    const linkButton = this.closest('tr')?.querySelector('.dlt-img.hidden');  
                    Swal.fire({
                        title: 'Are you sure you want to delete?',
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
                            //Your customer has not been deleted.
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

