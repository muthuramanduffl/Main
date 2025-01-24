<%@ Page Title="" Language="C#" MasterPageFile="AdminKey2h.master" AutoEventWireup="true" CodeFile="view-refer-content.aspx.cs" Inherits="adminkey2hcom_ViewReferContent" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server"> 
    <div class="content">
        <div class="panel-header bg-primary-gradient">
            <div class="page-inner py-5">
                <div class="d-flex pb-2 align-items-left align-items-sm-center flex-column flex-sm-row justify-content-between">
                    <div class="d-flex">
                        <h2 class="text-white mb-0 fw-bold text-uppercase">View Refer Content</h2>
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
                                                <asp:AsyncPostBackTrigger ControlID="ddlprojects" EventName="SelectedIndexChanged" />
                                                <asp:AsyncPostBackTrigger ControlID="lnkcancel" EventName="Click" />
                                            </Triggers>
                                        </asp:UpdatePanel>
                                    </div> 
                                </div> 
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
                                                            <th class="min-w-220">Project Name</th>
                                                            <th class="max-w-400">Question</th>
                                                            <th class="max-w-400">Brief Content</th>
                                                            <th class="max-w-400">Message Content</th>
                                                            <th class="min-w-120">Action </th>
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
                                                    <td>
                                                        <%# Bindproject(Convert.ToInt32((Eval("ProjectID")))) %> 
                                                    </td>
                                                    <%--<div class="view-paragraphs truncate-text"></div>--%>
                                                    <td><div class="view-paragraphs truncate-text"> <%# Eval("Question") %> </div> </td>
                                                    <td><div class="view-paragraphs truncate-text"> <%# Eval("Content") %> </div> </td>
                                                    <td><div class="view-paragraphs truncate-text"> <%# Eval("MessageContent") %> </div> </td>
                                                    <td>
                                                        <asp:LinkButton class="me-3" ID="lkedit" runat="server" CommandName="Edit"
                                                            CommandArgument='<%# DataBinder.Eval(Container.DataItem, "ReferScreenID") %>'>
                                                            <i class="bi bi-pencil-square b5-icon-et-dlt" data-bs-toggle="tooltip" title="Edit"></i>
                                                        </asp:LinkButton> 
                                                        <a class="swtAltCancel">
                                                            <i class="bi bi-trash b5-icon-et-dlt" data-bs-toggle="tooltip" title="Delete"></i>
                                                        </a>
                                                        <asp:LinkButton ID="LinkButton2" CausesValidation="false" runat="server" class="dlt-img hidden" Text="Delete" CommandName="Delete" CommandArgument='<%# Eval("ReferScreenID") %>' Style="display: none">
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
                        title: 'Are you sure you want to Delete?',
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
                            Swal.fire({
                                title: 'Refer content has been deleted as requested',
                                confirmButtonText: 'Ok',
                                customClass: {
                                    confirmButton: 'handle-btn-success'
                                }
                            }); // Fixed closing parentheses
                        } else if (result.dismiss === Swal.DismissReason.cancel) {
                            // Add any desired behavior for cancellation here, if needed.
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

    <script> 
        //-- view para with popup
        document.querySelectorAll('.view-paragraphs').forEach(function (element) {
            element.addEventListener('click', function () {
                const fullText = element.innerText;
                Swal.fire({
                    title: '<h2 class="fw-bold mb-0">Full Content</h2>',
                    text: fullText,
                    confirmButtonText: 'Ok',
                    customClass: {
                        confirmButton: 'handle-btn-success',
                    }
                });
            });
        });
        //--// view para with popup 
    </script>
</asp:Content>

