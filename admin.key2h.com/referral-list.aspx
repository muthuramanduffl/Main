<%@ Page Title="" Language="C#" MasterPageFile="AdminKey2h.master" AutoEventWireup="true" CodeFile="referral-list.aspx.cs" Inherits="adminkey2hcom_ReferralList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
     <div class="content">
     <div class="panel-header bg-primary-gradient">
         <div class="page-inner py-5">
             <div class="d-flex pb-2 align-items-left align-items-md-center flex-column flex-md-row justify-content-between">
                 <div class="d-flex">
                     <h2 class="text-white mb-0 fw-bold text-uppercase">Referral List</h2>
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
                                 <div class="col-sm-4 col-xl-4 pt-3"> 
                                     <asp:UpdatePanel ID="UpdatePanel434" runat="server">
                                         <ContentTemplate>
                                             <div class="input-icon input-icon-sm right">
                                                 <label>Search <span class="text-danger">*</span></label>
                                                 <asp:LinkButton ID="lnkbtngo" OnClientClick="if (validatePage()) { this.value='Please wait..'; this.style.display='none'; this.style.display = 'none'; } else { return false; }" Style="min-width: 67px;" OnClick="lnkbtngo_Click" runat="server">
                                                     <i class="bi bi-search bg-after-search text-dark b5-icon" data-bs-toggle="tooltip" title="Search"></i>
                                                 </asp:LinkButton>
                                                 <asp:TextBox ID="txtsearch" class="form-control input-sm" MaxLength="10" runat="server" placeholder="By flat/whatsapp number"></asp:TextBox>
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
                                                     <asp:ListItem Selected="True"></asp:ListItem>
                                                     <asp:ListItem Value="" Text="Select"></asp:ListItem>
                                                 </asp:DropDownList>
                                             </div>
                                         </ContentTemplate>
                                         <Triggers>
                                             <asp:AsyncPostBackTrigger ControlID="lnkbtngo" EventName="Click" />
                                             <asp:AsyncPostBackTrigger ControlID="lnkcancel" EventName="Click" />
                                             <asp:AsyncPostBackTrigger ControlID="ddlprojectname" EventName="SelectedIndexChanged" /> 
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
                                         </Triggers>
                                     </asp:UpdatePanel>
                                 </div> 
                             </div>

                             <asp:UpdatePanel ID="UpdatePanel6" runat="server">
                                 <ContentTemplate>
                                     <h5 id="h5TotalNoCount" runat="server"><span class="box-b-only p-1">Total no. of Referral List:
                                         <asp:Label ID="lblcount" runat="server" Text="Label"></asp:Label>
                                     </span></h5> 
                                 </ContentTemplate>
                                 <Triggers>
                                     <asp:AsyncPostBackTrigger ControlID="lnkbtngo" EventName="Click" />
                                     <asp:AsyncPostBackTrigger ControlID="lnkcancel" EventName="Click" />
                                     <asp:AsyncPostBackTrigger ControlID="ddlprojectname" EventName="SelectedIndexChanged" /> 
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
                                 </Triggers>
                             </asp:UpdatePanel>
                         </div>
                         <div class="table-responsive">
                             <asp:UpdatePanel ID="UpdatePanel5" runat="server">
                                 <ContentTemplate>
                                     <asp:Repeater ID="rpruser" runat="server">
                                         <HeaderTemplate>
                                             <table class="table table-bordered" id="basic-datatables" role="grid" aria-describedby="basic-datatables_info">
                                                 <thead>
                                                     <tr>
                                                         <th class="w-sno" rowspan="2">#</th>
                                                         <th class="min-w-120" rowspan="2">Customer Name</th> 
                                                         <th class="min-w-120" rowspan="2">Project Name </th> 
                                                         <th class="min-w-120" rowspan="2">Flat No. </th>
                                                         <th class="min-w-120" colspan="5">Referral Details </th> 
                                                     </tr>
                                                     <tr> 
                                                         <th class="min-w-120">Date </th>
                                                         <th class="min-w-120">Name </th>
                                                         <th class="min-w-120">Whatsapp No. </th> 
                                                         <th class="max-w-400">Content</th> 
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
                                                 <td>
                                                     <%# Bindproject(Convert.ToInt32((Eval("ProjectID")))) %> 
                                                 </td> 
                                                 <td><%#ViewFlatNameByFlatID(Convert.ToInt32(Eval("FlatID"))) %></td> 
                                                 <td> <%# Eval("ReferredDate") %> </td> 
                                                 <td> <%# Eval("ReferralName") %> </td> 
                                                 <td> <%# Eval("ReferralMobile") %> </td> 
                                                 <td>
                                                     <div class="view-paragraphs truncate-text"> <%# Eval("ReferralContent") %>
                                                     </div> 
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
                 const linkButton = this.closest('tr')?.querySelector('.dlt-img.hidden'); // Adjust selector for the parent container if needed.

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
      
     //-- view para with popup
     document.querySelectorAll('.view-paragraphs').forEach(function (element) {
         element.addEventListener('click', function () {
             //alert("as");
             const fullContent = element.innerHTML; 
             Swal.fire({
                 title: 'Full Content',
                 html: fullContent,   
                 confirmButtonText: 'Close',
                 customClass: { 
                     confirmButton: 'handle-btn-success',
                 }
             });
         });
     });
     //--// view para with popup
 </script>

     
</asp:Content>

