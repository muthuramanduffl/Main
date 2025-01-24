<%@ Page Title="" Language="C#" MasterPageFile="AdminKey2h.master" AutoEventWireup="true" CodeFile="view-project.aspx.cs" Inherits="adminkey2hcom_ViewProjects" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server"> 
    <div class="content">
        <div class="panel-header bg-primary-gradient">
            <div class="page-inner py-5">
                <div class="d-flex pb-2 align-items-left align-items-sm-center flex-column flex-sm-row justify-content-between">
                    <div class="d-flex">
                        <h2 class="text-white mb-0 fw-bold text-uppercase">View Projects</h2>
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
                            <div class="form-group p-0"> 
                                <div class="row mb-4">
                                    <div class="col-sm-4 col-xl-2 pt-3">
                                        <div class="input-icon input-icon-sm right">
                                            <label>Project Name </label>
                                            <i class="bi bi-journal-bookmark-fill b5-icon"></i>
                                            <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                                                <ContentTemplate>
                                                    <asp:DropDownList ID="ddlprojects" OnSelectedIndexChanged="ddlprojects_SelectedIndexChanged" AutoPostBack="true" class="bs-select form-control input-sm" runat="server">
                                                        <asp:ListItem Value=""></asp:ListItem>
                                                    </asp:DropDownList>
                                                </ContentTemplate>
                                                <Triggers>
                                                    <asp:AsyncPostBackTrigger ControlID="ddlprojects" EventName="SelectedIndexChanged" />
                                                </Triggers>
                                            </asp:UpdatePanel> 
                                        </div>
                                    </div> 
                                    <div class="col-sm-4 col-xl-2 pt-3">
                                        <div class="input-icon input-icon-sm right">
                                            <label>Project Status </label>
                                            <i class="bi bi-check2-square b5-icon"></i>
                                            <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                                                <ContentTemplate>
                                                    <asp:DropDownList ID="ddlprojectstatus" OnSelectedIndexChanged="ddlprojectstatus_SelectedIndexChanged" AutoPostBack="true" class="bs-select form-control input-sm" runat="server">
                                                        <asp:ListItem Value="All"></asp:ListItem>
                                                        <asp:ListItem Value="0">Ongoing</asp:ListItem>
                                                        <asp:ListItem Value="1">Completed</asp:ListItem>

                                                    </asp:DropDownList>
                                                </ContentTemplate>
                                                <Triggers>
                                                    <asp:AsyncPostBackTrigger ControlID="ddlprojectstatus" EventName="SelectedIndexChanged" />
                                                </Triggers>
                                            </asp:UpdatePanel>
                                        </div>
                                    </div> 
                                    <div class="col-sm-4 col-xl-2 pt-0 pt-sm-3 d-flex add-bs-1"> 
                                        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                            <ContentTemplate>
                                                <asp:LinkButton ID="lnkbtngo" data-bs-toggle="tooltip" title="Search" OnClick="lnkbtngo_Click" class="b5-icon-search me-3 d-none" runat="server">
                                                    <i class="bi bi-binoculars"></i>
                                                </asp:LinkButton>
                                            </ContentTemplate>
                                            <Triggers>
                                                <asp:AsyncPostBackTrigger ControlID="lnkbtngo" EventName="Click" /> 
                                            </Triggers>
                                        </asp:UpdatePanel> 
                                        <asp:UpdatePanel ID="UpdatePanel7" runat="server">
                                            <ContentTemplate>
                                                <asp:LinkButton ID="lnkcancel" data-bs-toggle="tooltip" title="Reset" OnClick="lnkcancel_Click" class="b5-icon-reset" runat="server">
                                                    <i class="bi bi-repeat"></i>
                                                </asp:LinkButton> 
                                            </ContentTemplate>
                                            <Triggers> 
                                                <asp:AsyncPostBackTrigger ControlID="lnkcancel" EventName="Click" />
                                            </Triggers>
                                        </asp:UpdatePanel>
                                    </div> 
                                </div>
                                <asp:UpdatePanel ID="UpdatePanel6" runat="server">
                                    <ContentTemplate>
                                        <h5 id="h5TotalNoCount" runat="server"><span class="box-b-only p-1 d-none">Total no. of Count :
                                            <asp:Label ID="lblcount" runat="server" Text="Label"></asp:Label>
                                        </span></h5> 
                                    </ContentTemplate>
                                    <Triggers>
                                        <asp:AsyncPostBackTrigger ControlID="ddlprojectstatus" EventName="SelectedIndexChanged" />
                                        <asp:AsyncPostBackTrigger ControlID="lnkbtngo" EventName="Click" />
                                        <asp:AsyncPostBackTrigger ControlID="lnkcancel" EventName="Click" />
                                        <asp:AsyncPostBackTrigger ControlID="ddlprojects" EventName="SelectedIndexChanged" />
                                    </Triggers>
                                </asp:UpdatePanel>
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
                                    <asp:AsyncPostBackTrigger ControlID="ddlprojectstatus" EventName="SelectedIndexChanged" />
                                    <asp:AsyncPostBackTrigger ControlID="lnkbtngo" EventName="Click" />
                                    <asp:AsyncPostBackTrigger ControlID="lnkcancel" EventName="Click" />
                                    <asp:AsyncPostBackTrigger ControlID="ddlprojects" EventName="SelectedIndexChanged" />
                                </Triggers>
                            </asp:UpdatePanel>
                            <div class="table-responsive">
                                <asp:UpdatePanel ID="UpdatePanel5" runat="server">
                                    <ContentTemplate>
                                        <asp:Repeater ID="rpruser" OnItemCommand="Repeater1_ItemCommand" runat="server">
                                            <HeaderTemplate>
                                                <table class="table table-bordered" id="basic-datatables" role="grid" aria-describedby="basic-datatables_info">
                                                    <thead>
                                                        <tr>
                                                            <th class="w-sno">#</th>
                                                            <th class="min-w-120">Project Name</th>
                                                            <th class="min-w-120">Project Location</th>
                                                            <th class="min-w-120">No. of Blocks</th>
                                                            <th class="min-w-120">No. of Flats </th> 
                                                            <th class="min-w-120">Completion</th>
                                                            <th class="min-w-120">Status</th>
                                                            <th class="min-w-120">Edit </th>
                                                        </tr>
                                                    </thead>
                                                    <tbody>
                                            </HeaderTemplate>
                                            <ItemTemplate>
                                                <tr>
                                                    <asp:HiddenField ID="HiddenField1" Value='<%# Eval("ProjectID") %>' runat="server" />
                                                    <td>
                                                        <%# GetRowNo(Convert.ToString(Container.ItemIndex + 1))%> 
                                                    </td>
                                                    <td> <%# Eval("ProjectName") %>  </td>
                                                    <td> <%# Eval("Location")%> </td> 
                                                    <td> <%# Eval("BlockCount") %> </td>
                                                    <td> <%# Eval("FlatCount") %> </td>
                                                    <td> <%# Eval("ProjectStatusPercentage")+"%" %> </td>
                                                    <td> <%# Convert.ToInt32(Eval("ProjectStatus")) == 1 ? 
                                                            "<div class='btn-completed'>Completed</div>" :
                                                            "<div class='btn-ongoing'>Ongoing </div> " %>
                                                    </td>
                                                    <td class="d-none">
                                                        <%# Convert.ToInt32(Eval("ProjectDisplayStatus")) == 1 ? 
                                                            "<div class='btn-active'><i class='bi bi-shield-check'></i> Active</div>" : 
                                                            "<div class='btn-inactive'><i class='bi bi-shield-x'></i> Inactive</div> " %>
                                                    </td>
                                                    <td class="d-none">
                                                        <%# Eval("addeddate","{0:dd-MMM-yyyy}") %>
                                                    </td>
                                                    <td>
                                                        <asp:LinkButton class="me-3" ID="lkedit" runat="server" CommandName="Edit"
                                                            CommandArgument='<%# DataBinder.Eval(Container.DataItem, "ProjectID") %>'>
                                                            <i class="bi bi-pencil-square b5-icon-et-dlt" data-bs-toggle="tooltip" title="Edit"></i>
                                                        </asp:LinkButton> 
                                                        <a class="swtAltCancel" style="display: none">
                                                            <i class="bi bi-trash b5-icon-et-dlt" data-bs-toggle="tooltip" title="Delete"></i>
                                                        </a>
                                                        <asp:LinkButton ID="LinkButton2" CausesValidation="false" runat="server" class="dlt-img hidden" Text="Delete" CommandName="Delete" CommandArgument='<%# Eval("ProjectID") %>' Style="display: none">
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
                                        <asp:AsyncPostBackTrigger ControlID="ddlprojectstatus" EventName="SelectedIndexChanged" />
                                        <asp:AsyncPostBackTrigger ControlID="lnkbtngo" EventName="Click" />
                                        <asp:AsyncPostBackTrigger ControlID="lnkcancel" EventName="Click" />
                                        <asp:AsyncPostBackTrigger ControlID="ddlprojects" EventName="SelectedIndexChanged" />
                                    </Triggers>
                                </asp:UpdatePanel>
                            </div>
                            <div class="d-md-flex justify-content-end d-block mb-3">
                                <asp:UpdatePanel ID="UpdatePanel4" runat="server">
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
                                        <asp:AsyncPostBackTrigger ControlID="ddlprojectstatus" EventName="SelectedIndexChanged" />
                                        <asp:AsyncPostBackTrigger ControlID="lnkbtngo" EventName="Click" />
                                        <asp:AsyncPostBackTrigger ControlID="lnkcancel" EventName="Click" />
                                        <asp:AsyncPostBackTrigger ControlID="ddlprojects" EventName="SelectedIndexChanged" />
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
     
    <script>
        function initializeDeleteEvents() {
            const cancelButtons = document.querySelectorAll('.swtAltCancel');

            cancelButtons.forEach((cancelButton) => {
                cancelButton.addEventListener('click', function () {
                    const linkButton = this.closest('tr')?.querySelector('.dlt-img.hidden');  
                    Swal.fire({
                        title: 'Are you sure you want to cancel?',
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

</asp:Content>

