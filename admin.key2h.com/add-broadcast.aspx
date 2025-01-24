<%@ Page Title="" Language="C#" MasterPageFile="AdminKey2h.master" AutoEventWireup="true" CodeFile="add-broadcast.aspx.cs" Inherits="adminkey2hcom_AddBroadcast" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="content">
        <div class="panel-header bg-primary-gradient">
            <div class="page-inner py-5">
                <div class="d-flex pb-2 align-items-left align-items-md-center flex-column flex-md-row justify-content-between">
                    <div class="d-flex">
                        <h2 class="text-white mb-0 fw-bold text-uppercase">
                            <asp:Label ID="lbldisplaytext" runat="server" Text=""></asp:Label>
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
                                        <h3>Broadcast Details</h3>
                                        <asp:Label ID="lblError" runat="server" Text=""></asp:Label>
                                        <asp:Label ID="lblerrormsg" runat="server" Text=""></asp:Label>
                                    </div>
                                    <div class="row mx-0 margin-top20 mb-4">
                                        <div class="col-sm-4 col-xl-3 pt-3">
                                            <asp:UpdatePanel ID="UpdatePanel2" runat="server" UpdateMode="Conditional">
                                                <ContentTemplate>
                                                    <div class="input-icon input-icon-sm right">
                                                        <label>Project Name <span class="text-danger">*</span></label>
                                                        <i class="bi bi-journal-bookmark-fill b5-icon"></i>
                                                        <asp:DropDownList class="bs-select form-control input-sm" ID="ddlprojects" runat="server">
                                                        </asp:DropDownList> 
                                                    </div>
                                                    <span class="error">
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" InitialValue="" ValidationGroup="proval" ControlToValidate="ddlprojects" runat="server" ErrorMessage=" Select project name"></asp:RequiredFieldValidator>
                                                    </span>
                                                </ContentTemplate>
                                                <Triggers>
                                                    <asp:AsyncPostBackTrigger ControlID="btnSave" EventName="click" />
                                                    <asp:AsyncPostBackTrigger ControlID="btnCancel" EventName="click" />
                                                </Triggers>
                                            </asp:UpdatePanel>
                                        </div>
                                        <div class="col-sm-4 col-xl-3 pt-3">
                                            <asp:UpdatePanel ID="UpdatePanel31" runat="server" UpdateMode="Conditional">
                                                <ContentTemplate> 
                                                    <div class="input-icon input-icon-sm right">
                                                        <label>Title <span class="text-danger">*</span></label>
                                                        <i class="bi bi-journal-text b5-icon"></i>
                                                        <asp:TextBox ID="txtTitle" ClientIDMode="Static" MaxLength="50" class="form-control capitalize-input"  placeholder="" runat="server"></asp:TextBox>
                                                    <span class="handle-file-request">(maximum 50 characters)</span>
                                                    </div>
                                                    <span class="error">
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator21" runat="server" Display="Dynamic" ValidationGroup="proval"
                                                            ControlToValidate="txtTitle" ErrorMessage="Enter title">
                                                        </asp:RequiredFieldValidator> 
                                                    </span>
                                                </ContentTemplate>
                                                <Triggers>
                                                    <asp:AsyncPostBackTrigger ControlID="btnSave" EventName="click" />
                                                    <asp:AsyncPostBackTrigger ControlID="btnCancel" EventName="click" />
                                                </Triggers>
                                            </asp:UpdatePanel>
                                        </div>
                                        <div class="col-sm-4 col-xl-4 pt-3">
                                            <asp:UpdatePanel ID="UpdatePanel3" runat="server" UpdateMode="Conditional">
                                                <ContentTemplate> 
                                                    <div class="input-icon input-icon-sm right">
                                                        <label>Message <span class="text-danger">*</span></label>
                                                        <i class="bi bi-chat-square-text b5-icon"></i>
                                                        <asp:TextBox ID="txtMessage" ClientIDMode="Static" MaxLength="200" TextMode="MultiLine" class="form-control capitalize-input" Rows="2" cols="50" placeholder="" runat="server"></asp:TextBox>
                                                    <span class="handle-file-request">(maximum 200 characters)</span>
                                                    </div>
                                                    <span class="error">
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" Display="Dynamic" ValidationGroup="proval"
                                                            ControlToValidate="txtMessage" ErrorMessage="Enter message">
                                                        </asp:RequiredFieldValidator> 
                                                    </span>
                                                </ContentTemplate>
                                                <Triggers>
                                                    <asp:AsyncPostBackTrigger ControlID="btnSave" EventName="click" />
                                                    <asp:AsyncPostBackTrigger ControlID="btnCancel" EventName="click" />
                                                </Triggers>
                                            </asp:UpdatePanel>
                                        </div> 
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="card-footer">
                            <div class="d-flex justify-content-center">
                                <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
                                    <ContentTemplate>
                                        <asp:Button
                                            ID="btnSave" ClientIDMode="Static"
                                            runat="server" OnClick="btnSave_Click"
                                            Text="Submit" ValidationGroup="proval"
                                            class="btn btn-sm handle-btn-success me-1 swtAltSubmit btnSave"
                                            OnClientClick="if (validatePage()) { this.value='Please wait..'; this.style.display='none'; document.getElementById('bWait').style.display = ''; } else { return false; }" Style="min-width: 67px;" />
                                        <button type="button" style="display: none" id="bWait" class="btn btn-secondary btn-sm me-1"><i class='fa fa-spinner fa-spin'></i>Please wait</button>
                                        <div class="btn btn-sm handle-btn-danger swtAltCancel">Cancel</div>
                                        <asp:Button ID="btnCancel" runat="server" Text="Cancel Project" OnClick="btnCancel_Click" Style="display: none;" />
                                    </ContentTemplate>
                                    <Triggers>
                                        <asp:AsyncPostBackTrigger ControlID="btnSave" EventName="click" />
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

     
    <script type="text/javascript">
        function validatePage() { 
            var flag = Page_ClientValidate('proval') 
            return flag;
        } 
        document.getElementById('<%= txtMessage.ClientID %>').addEventListener('input', function (e) {
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
                        // Trigger the ASP.NET Button click to handle postback
                        document.getElementById('<%= btnCancel.ClientID %>').click();
                    } else if (result.dismiss === Swal.DismissReason.cancel) {
                        // User clicked 'No' 
                    }
                });
            });
        });
    </script> 
     
</asp:Content>


