<%@ Page Title="" Language="C#" MasterPageFile="AdminKey2h.master" AutoEventWireup="true" CodeFile="view-broadcast.aspx.cs" Inherits="adminkey2hcom_ViewBroadcast" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="content">
        <div class="panel-header bg-primary-gradient">
            <div class="page-inner py-5">
                <div class="d-flex pb-2 align-items-left align-items-sm-center flex-column flex-sm-row justify-content-between">
                    <div class="d-flex">
                        <h2 class="text-white mb-0 fw-bold text-uppercase">View Broadcasts</h2>
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
                                                    <asp:AsyncPostBackTrigger ControlID="lnkcancel" EventName="Click" />
                                                    <asp:AsyncPostBackTrigger ControlID="ddlprojects" EventName="SelectedIndexChanged" />
                                                </Triggers>
                                            </asp:UpdatePanel> 
                                        </div>
                                    </div>  
                                    <div class="col-sm-4 col-xl-2 pt-0 pt-sm-3 d-flex add-bs-1"> 
                                        <asp:UpdatePanel ID="UpdatePanel7" runat="server">
                                            <ContentTemplate>
                                                <asp:LinkButton ID="lnkcancel" data-bs-toggle="tooltip" title="Reset" OnClick="lnkcancel_Click" class="b5-icon-reset" runat="server">
                                                    <i class="bi bi-repeat"></i>
                                                </asp:LinkButton> 
                                            </ContentTemplate>
                                            <Triggers> 
                                                <asp:AsyncPostBackTrigger ControlID="lnkcancel" EventName="Click" />
                                                <asp:AsyncPostBackTrigger ControlID="ddlprojects" EventName="SelectedIndexChanged" />
                                            </Triggers>
                                        </asp:UpdatePanel>
                                    </div> 
                                </div>
                                <asp:UpdatePanel ID="UpdatePanel6" runat="server">
                                    <ContentTemplate>
                                        <h5 id="h5TotalNoCount" runat="server"><span class="box-b-only p-1 ">Total no. of Count :
                                            <asp:Label ID="lblcount" runat="server" Text="Label"></asp:Label>
                                        </span></h5> 
                                    </ContentTemplate>
                                    <Triggers>  
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
                                        <asp:AsyncPostBackTrigger ControlID="lnkcancel" EventName="Click" />
                                        <asp:AsyncPostBackTrigger ControlID="ddlprojects" EventName="SelectedIndexChanged" />
                                    </Triggers>
                                </asp:UpdatePanel>
                                    <div class="table-responsive"> 
                                         <asp:UpdatePanel ID="UpdatePanel5" runat="server">
                                        <ContentTemplate> 
                                        <asp:Repeater ID="rpruser" runat="server">
                                            <headertemplate>
                                                <table class="table table-bordered">
                                                    <thead>
                                                        <tr>
                                                            <th class="w-sno">#</th>
                                                            <th class="min-w-150">Project Name</thclass="min-w-120>
                                                            <th>Title</th>
                                                            <th>Content</th>
                                                            <th class="min-w-150">Sent Date</th>
                                                            <th class="min-w-120 d-none">Action </th>
                                                        </tr>
                                                    </thead>
                                                    <tbody>
                                            </headertemplate>
                                            <itemtemplate>
                                                <tr>
                                                    <td><%# GetRowNo(Convert.ToString(Container.ItemIndex + 1))%></td>
                                                    <td><%# Bindprojectname(Convert.ToInt32(Eval("ProjectID"))) %>  </td>
                                                    <td><%# Eval("Title") %> </td>
                                                    <td><div class="view-paragraphs truncate-text"> <%# Eval("Message") %> </div> </td>
                                                    <td><%# Eval("CreatedDate") %> </td> 
                                                </tr>
                                                </tbody>
                                            </itemtemplate>
                                            <footertemplate>
                                                </table>
                                            </footertemplate>
                                        </asp:Repeater> 
                                        </ContentTemplate>
                                            <Triggers>   
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
        function validatePage() {
            var flag = window.Page_ClientValidate('projval');
            return flag; 
        }
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

