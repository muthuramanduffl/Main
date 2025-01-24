<%@ Page Title="" Language="C#" MasterPageFile="AdminKey2h.master" AutoEventWireup="true"
    CodeFile="lead-source.aspx.cs" Inherits="adminkey2hcomleadsource" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <style>
        .form-control:disabled, .form-control[readonly] {
            background: #f8f8f800 !important;
            border-color: #e8e8e800 !important;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="content">
        <div class="panel-header bg-primary-gradient">
            <div class="page-inner py-5">
                <div
                    class="d-flex pb-2 align-items-left align-items-sm-center flex-column flex-sm-row justify-content-between">
                    <div class="d-flex">
                        <h2 class="text-white mb-0 fw-bold text-uppercase">Lead Source</h2>
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
                                        <h3>Add Lead Source</h3>
                                    </div>
                                    <div class="row mx-0 margin-top20 mb-4">
                                        <div class="col-sm-4 col-lg-3 pt-3">
                                            <div class="input-icon input-icon-sm right">
                                                <label>Lead Source <span class="text-danger">*</span></label>
                                                <i class="bi bi-diagram-2 b5-icon"></i>
                                                <asp:TextBox runat="server" ID="txtLeadSource" MaxLength="100"
                                                    class="form-control input-sm" autocomplete="off"></asp:TextBox>
                                            </div>
                                            <span class="error">
                                                <asp:RequiredFieldValidator ClientIDMode="Static"
                                                    ValidationGroup="projval" EnableClientScript="true"
                                                    SetFocusOnError="true" ControlToValidate="txtLeadSource"
                                                    Display="Dynamic" ID="RequiredFieldValidatorLeadSource"
                                                    runat="server" ErrorMessage="Enter lead source">
                                                </asp:RequiredFieldValidator> 
                                                <asp:RegularExpressionValidator ClientIDMode="Static"
                                                    ValidationGroup="projval"
                                                    ID="RegularExpressionValidatorLeadSource" Display="Dynamic"
                                                    runat="server" ControlToValidate="txtLeadSource"
                                                    ValidationExpression="^[A-Za-z0-9\s-]+$"
                                                    ErrorMessage="Enter valid lead source">
                                                </asp:RegularExpressionValidator>
                                            </span>
                                        </div>

                                        <div class="col-sm col-lg d-flex pt-sm-3 pt-0">
                                            <div class="pt-sm-4 pt-2 mt-2">
                                                <asp:Button ID="btnSave" ClientIDMode="Static" runat="server" data-bs-toggle="tooltip" title="Add"
                                                    OnClick="btnSave_Click" Text="Add" ValidationGroup="projval"
                                                    class="btn btn-sm handle-btn-success me-1 swtAltSubmit btnSave"
                                                    OnClientClick="if (validatePage()) { this.value='Please wait..'; this.style.display='none'; document.getElementById('bWait').style.display = ''; } else { return false; }"
                                                    Style="min-width: 67px;" />
                                                <button type="button" style="display: none" id="bWait"
                                                    class="btn btn-secondary btn-sm me-1">
                                                    <i class='fa fa-spinner fa-spin'></i>Please wait</button>
                                                <div class="btn btn-sm handle-btn-danger swtAltCancel" data-bs-toggle="tooltip" title="Cancel">Cancel</div>
                                                <asp:Button ID="btnCancel" runat="server" Text="Cancel Project"
                                                    OnClick="btnCancel_Click" Style="display: none;" />
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                             
                            <!------------------ View Lead Source List ------------------>
                            <div class="form-group">
                                <div class="form-border margin-top20">
                                    <div class="form-title">
                                        <h3>View Details</h3>
                                    </div>
                                    <div class="row mx-0 margin-top20 pt-3 mb-2"> 
                                        <div class="table-responsive"> 
                                            <asp:Repeater ID="rpruser" OnItemCommand="Repeater1_ItemCommand" runat="server">
                                                <HeaderTemplate>
                                                    <table class="table table-bordered">
                                                        <thead>
                                                            <tr>
                                                                <th class="w-sno">#</th>
                                                                <th>Lead Source</th>
                                                                <th class="min-w-120">Action </th>
                                                            </tr>
                                                        </thead>
                                                        <tbody>
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <tr>
                                                        <asp:HiddenField ID="HiddenField1" Value='<%# Eval("LeadID") %>' runat="server" /> 
                                                        <td><%# GetRowNo(Convert.ToString(Container.ItemIndex + 1))%> </td>
                                                        <td>
                                                            <asp:TextBox ID="txtLeadSourceName" TextMod="MultiLine" CssClass="w-100 form-control input-sm input-cus dynamic-textbox" Wrap="true" runat="server" Text='<%# string.IsNullOrEmpty(Eval("LeadSourceName").ToString()) ? "-" : Eval("LeadSourceName")%>' ReadOnly="true" Style="background: #fcfcfc; border-color: #cccdce;text-align: center;" /></td>
                                                        <td>
                                                            <asp:HiddenField ID="HiddenField2" Value='<%# Eval("LeadID") %>' runat="server" />
                                                            <%--<asp:LinkButton CssClass=" " ID="Editbtn" runat="server" CommandName="Edit" Visible="true" data-bs-toggle="tooltip" title="Edit"
                                                                CommandArgument='<%# DataBinder.Eval(Container.DataItem, "LeadID") %>'><i class="bi bi-pencil-square b5-icon-et-dlt"></i></asp:LinkButton>--%>
                                                            <a href="javascript:void(0);" class="btnDelete" onclick="deleteRow(this)">
                                                                <i class="bi bi-trash b5-icon-et-dlt me-3" data-bs-toggle="tooltip" aria-label="Delete" data-bs-original-title="Delete"></i>
                                                            </a> 
                                                           <%--<asp:LinkButton CssClass="md-btn md-btn-small md-btn-flat md-btn-danger" ID="Delete" runat="server" OnClientClick='javascript:return confirm("Are you sure you want to delete?")' CommandName="Delete" Visible="true"
                                                                CommandArgument='<%# DataBinder.Eval(Container.DataItem, "LeadID") %>'>Delete</asp:LinkButton> --%>
                                                            <asp:LinkButton class=" " ID="btnSave" runat="server" CommandName="Save" Visible="false" data-bs-toggle="tooltip" title="Save"
                                                                CommandArgument='<%# DataBinder.Eval(Container.DataItem, "LeadID") %>'><i class="bi bi-check-square b5-icon-et-dlt"></i></asp:LinkButton> 
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
        document.getElementById('<%= txtLeadSource.ClientID %>').addEventListener('keypress', function (e) {
            if (!/^[A-Za-z0-9\s-]+$/.test(e.key)) {
                e.preventDefault();
            }
        }); 
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
                            //  You can continue with your lead source details submission. 
                        }
                    });
                });
            });

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
            });
        }   
    </script>

</asp:Content>
