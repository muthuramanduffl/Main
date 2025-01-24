<%@ Page Title="" Language="C#" MasterPageFile="AdminKey2h.master" AutoEventWireup="true" CodeFile="add-projectold.aspx.cs" Inherits="adminkey2hcom_Addproject" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="content">
        <div class="panel-header bg-primary-gradient">
            <div class="page-inner py-5">
                <div class="d-flex pb-2 align-items-left align-items-sm-center flex-column flex-sm-row justify-content-between">
                    <div class="d-flex">
                        <h2 class="text-white mb-0 fw-bold text-uppercase">
                            <asp:Label ID="lbldisplaystatus" runat="server" Text=""></asp:Label>
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
                                        <h3>Project Details</h3>
                                    </div>
                                    <asp:HiddenField ID="hdnID" ClientIDMode="Static" runat="server" /> 
                                    <div class="row mx-0 margin-top20 mb-2"> 
                                        <div class="col-sm-4 col-xl-3 pt-3">
                                            <div class="input-icon input-icon-sm right">
                                                <label>Project Name <span class="text-danger">*</span></label>
                                                <i class="bi bi-journal-bookmark-fill b5-icon"></i>
                                                <asp:TextBox ID="txtprojectname" ClientIDMode="Static" class="form-control input-sm capitalize-input" onkeyup="keyupFunction(this.id)" MaxLength="100" autocomplete="off" placeholder=""  runat="server"></asp:TextBox>
                                            </div>
                                            <span class="error">
                                                <asp:RequiredFieldValidator ClientIDMode="Static" Display="Dynamic" EnableClientScript="true" SetFocusOnError="true" ControlToValidate="txtprojectname" ValidationGroup="projval" ID="RequiredFieldValidator2" runat="server" ErrorMessage="Enter project name"></asp:RequiredFieldValidator>
                                                <asp:RegularExpressionValidator
                                                    ClientIDMode="Static"
                                                    ID="RegularExpressionValidator8"
                                                    Display="Dynamic"
                                                    runat="server"
                                                    ValidationGroup="projval"
                                                    ControlToValidate="txtprojectname"
                                                    ValidationExpression="^[A-Za-z0-9\s.,-]+$"
                                                    ErrorMessage="Enter valid project name">
                                                </asp:RegularExpressionValidator>
                                                <div id="projectValidationMessage"></div>
                                            </span>
                                        </div>
                                    </div>
                                    <div class="row mx-0 mb-4">
                                        <div class="col-sm-4 col-xl-2 pt-3"> 
                                            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                                <ContentTemplate>
                                                    <div class="input-icon input-icon-sm right">
                                                        <label>State <span class="text-danger">*</span></label>
                                                        <i class="bi bi-globe-americas b5-icon"></i>
                                                        <asp:DropDownList ID="ddlstate" ClientIDMode="Static" OnSelectedIndexChanged="ddlstate_SelectedIndexChanged" AutoPostBack="true" class="bs-select form-control input-sm" runat="server">
                                                            <asp:ListItem Selected="True"></asp:ListItem>
                                                        </asp:DropDownList>
                                                    </div>
                                                    <span class="error">
                                                        <asp:RequiredFieldValidator ClientIDMode="Static" EnableClientScript="true" SetFocusOnError="true" ControlToValidate="ddlstate" InitialValue="" ValidationGroup="projval" ID="RequiredFieldValidator5" runat="server" ErrorMessage="Select state"></asp:RequiredFieldValidator>
                                                    </span>
                                                </ContentTemplate>
                                                <Triggers>
                                                    <asp:AsyncPostBackTrigger ControlID="ddlstate" EventName="SelectedIndexChanged" />
                                                </Triggers>
                                            </asp:UpdatePanel>
                                        </div>
                                        <div class="col-sm-4 col-xl-2 pt-3">
                                            <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                                                <ContentTemplate>
                                                    <div class="input-icon input-icon-sm right">
                                                        <label>City <span class="text-danger">*</span></label>
                                                        <i class="bi bi-buildings b5-icon"></i>
                                                        <asp:DropDownList ID="ddlcity" ClientIDMode="Static" class="bs-select form-control input-sm" runat="server">
                                                            <asp:ListItem></asp:ListItem>
                                                            <asp:ListItem>Select state</asp:ListItem>
                                                        </asp:DropDownList>
                                                    </div>
                                                    <span class="error">
                                                        <asp:RequiredFieldValidator ClientIDMode="Static" EnableClientScript="true" SetFocusOnError="true" ControlToValidate="ddlcity" InitialValue="" ValidationGroup="projval" ID="RequiredFieldValidator6" runat="server" ErrorMessage="Select city"></asp:RequiredFieldValidator>
                                                    </span>
                                                </ContentTemplate>
                                                <Triggers>
                                                    <asp:AsyncPostBackTrigger ControlID="ddlstate" EventName="SelectedIndexChanged" />
                                                </Triggers>
                                            </asp:UpdatePanel>
                                        </div> 
                                        <div class="col-sm-4 col-xl-3 pt-3">
                                            <div class="input-icon input-icon-sm right">
                                                <label>Project Location <span class="text-danger">*</span></label>
                                                <i class="bi bi-geo-alt-fill b5-icon"></i>
                                                <asp:TextBox runat="server" ClientIDMode="Static" ID="txtlocation" MaxLength="300" class="form-control input-sm capitalize-input" autocomplete="off" placeholder=""></asp:TextBox>
                                            </div>
                                            <span class="error">
                                                <asp:RequiredFieldValidator Display="Dynamic" ClientIDMode="Static" EnableClientScript="true" SetFocusOnError="true" ControlToValidate="txtlocation" ValidationGroup="projval" ID="RequiredFieldValidator3" runat="server" ErrorMessage="Enter project location"></asp:RequiredFieldValidator>
                                                <asp:RegularExpressionValidator
                                                    ID="RegularExpressionValidator9"
                                                    runat="server" ClientIDMode="Static"
                                                    ValidationGroup="projval"
                                                    ControlToValidate="txtlocation"
                                                    ValidationExpression="^[A-Za-z\s.,-]+$"
                                                    ErrorMessage="Enter valid project location"
                                                    Display="Dynamic" />
                                            </span> 
                                        </div> 
                                        <div class="col-sm-4 col-xl-2 pt-3">
                                            <div class="input-icon input-icon-sm right">
                                                <label>Postal Code <span class="text-danger">*</span></label>
                                                <i class="bi bi-mailbox b5-icon"></i>
                                                <asp:TextBox runat="server" ClientIDMode="Static" ID="txtpostalcode" MaxLength="6" class="form-control input-sm" autocomplete="off" placeholder=""></asp:TextBox>
                                            </div>
                                            <span class="error">
                                                <asp:RequiredFieldValidator ClientIDMode="Static" EnableClientScript="true" SetFocusOnError="true" ControlToValidate="txtpostalcode" Display="Dynamic" ValidationGroup="projval" ID="RequiredFieldValidator7" runat="server" ErrorMessage="Enter postal code"></asp:RequiredFieldValidator>
                                                <asp:RegularExpressionValidator ClientIDMode="Static" ID="RegularExpressionValidator3" Display="Dynamic" runat="server" ValidationGroup="projval" ControlToValidate="txtpostalcode" ValidationExpression="^\d{0,6}$" ErrorMessage="Enter valid postal code"></asp:RegularExpressionValidator>
                                            </span>
                                        </div> 
                                        <div class="col-sm-4 col-xl-4 pt-3">
                                            <div class="input-icon input-icon-sm right">
                                                <label>Address <span class="text-danger">*</span></label>
                                                <i class="bi bi-geo-fill b5-icon"></i>
                                                <asp:TextBox ID="txtAddress" ClientIDMode="Static" TextMode="MultiLine" class="form-control capitalize-input" Rows="1" cols="50" placeholder="" runat="server"></asp:TextBox>
                                            </div>
                                            <span class="error">
                                                <asp:RequiredFieldValidator EnableClientScript="true" SetFocusOnError="true" ControlToValidate="txtAddress" ValidationGroup="projval" ID="RequiredFieldValidator4" runat="server" ErrorMessage=" Enter address "></asp:RequiredFieldValidator>
                                                <asp:RegularExpressionValidator
                                                    ID="RegularExpressionValidator11"
                                                    runat="server" ClientIDMode="Static"
                                                    ValidationGroup="projval"
                                                    ControlToValidate="txtAddress"
                                                    ValidationExpression="^[A-Za-z0-9\s.,-/()]+$"
                                                    ErrorMessage="Enter valid address"
                                                    Display="Dynamic" />
                                            </span>
                                        </div>
                                        <div class="col-sm-4 col-xl-3 pt-3">
                                            <div class="input-icon input-icon-sm right">
                                                <label>Google Map Link <span class="text-danger">*</span></label>
                                                <i class="bi bi-map b5-icon"></i>
                                                <asp:TextBox runat="server" ID="txtGooglemap" ClientIDMode="Static" MaxLength="300" class="form-control input-sm" autocomplete="off" placeholder=""></asp:TextBox>
                                            </div>
                                            <span class="error">
                                                <asp:RequiredFieldValidator ClientIDMode="Static" ControlToValidate="txtGooglemap" ValidationGroup="projval" Display="Dynamic" ID="RequiredFieldValidator22" runat="server" ErrorMessage="Enter google map link">
                                                </asp:RequiredFieldValidator>
                                                <asp:RegularExpressionValidator
                                                    ID="RegularExpressionValidator13"
                                                    runat="server"
                                                    Display="Dynamic"
                                                    ControlToValidate="txtGooglemap"
                                                    SetFocusOnError="true"
                                                    ForeColor="#d41111"
                                                    ValidationGroup="projval"
                                                    ValidationExpression="^(https?:\/\/)?(www\.)?(google\.com\/maps|maps\.google\.com|maps\.app\.goo\.gl|goo\.gl\/maps)(\/.*)?(\?.*)?$"
                                                    ErrorMessage="Enter valid google map link">
                                                </asp:RegularExpressionValidator> 
                                            </span>
                                        </div>
                                        <div class="col-sm-4 col-xl-3 pt-3">
                                            <div class="input-icon input-icon-sm right">
                                                <label>Location Map <span class="text-danger">*</span></label>
                                                <i class="bi bi-crosshair b5-icon"></i>
                                                <asp:FileUpload ID="Fileuploadlocationmap" ClientIDMode="Static" accept=".jpeg, .jpg, .png" onchange="showMyImage2(this)" class="form-control input-sm Fileuploadlocationmap" autocomplete="off" placeholder="" runat="server" />
                                                <span class="handle-file-request">(max file size 500 KB)</span>
                                                <asp:HiddenField ID="hdnuploadlocationmap" runat="server" />
                                            </div>
                                            <span class="error">
                                                <asp:Label ID="lblFileuploadlocationmap" CssClass="lblFileuploadlocationmap" runat="server" ForeColor="#d41111" Text=""></asp:Label>
                                            </span>
                                            <span class="error">
                                                <asp:RequiredFieldValidator ClientIDMode="Static" EnableClientScript="true" SetFocusOnError="true" ControlToValidate="Fileuploadlocationmap" ValidationGroup="projval" ID="RequiredFieldValidator15" runat="server" ErrorMessage=" Upload location map"></asp:RequiredFieldValidator>
                                            </span>
                                            <div class="view-loca-map-img btn-view-pop" runat="server" id="viewmapbtn" style="display: none">
                                                <i class="bi bi-eye"></i>View Image
                                            </div>
                                        </div>
                                        <div class="col-sm-4 col-xl-2 pt-3">
                                            <div class="input-icon input-icon-sm right">
                                                <label>Land Area <span class="text-danger">*</span></label>
                                                <i class="bi bi-globe2 b5-icon"></i>
                                                <asp:TextBox runat="server" ClientIDMode="Static" ID="txtlandarea" MaxLength="50" class="form-control input-sm" autocomplete="off" placeholder=""></asp:TextBox>
                                                <span class="handle-file-request">(in Sq.ft)</span>
                                            </div>
                                            <span class="error">
                                                <asp:RequiredFieldValidator ClientIDMode="Static" EnableClientScript="true" SetFocusOnError="true" Display="Dynamic" ControlToValidate="txtlandarea" ValidationGroup="projval" ID="RequiredFieldValidator11" runat="server" ErrorMessage="Enter land area"></asp:RequiredFieldValidator>
                                                <asp:RegularExpressionValidator ClientIDMode="Static" ID="RegularExpressionValidator12" Display="Dynamic" runat="server"  ValidationGroup="projval" ControlToValidate="txtlandarea" ValidationExpression="^[0-9\s]+$" ErrorMessage="Enter valid land area"></asp:RegularExpressionValidator> 
                                            </span>
                                        </div>
                                        <div class="col-sm-4 col-xl-2 pt-3">
                                            <div class="input-icon input-icon-sm right">
                                                <label>No. of Blocks <span class="text-danger">*</span></label>
                                                <i class="bi bi-border-style b5-icon"></i>
                                                <asp:TextBox runat="server" ID="txtnoofblocks" ClientIDMode="Static" MaxLength="5" class="form-control input-sm" autocomplete="off" placeholder=""></asp:TextBox>
                                            </div>
                                            <span class="error">
                                                <asp:RequiredFieldValidator ClientIDMode="Static" EnableClientScript="true" SetFocusOnError="true" ControlToValidate="txtnoofblocks" Display="Dynamic" ValidationGroup="projval" ID="RequiredFieldValidator9" runat="server" ErrorMessage="Enter no. of blocks"></asp:RequiredFieldValidator>
                                                <asp:RegularExpressionValidator ClientIDMode="Static" ID="RegularExpressionValidator4" Display="Dynamic" runat="server" ValidationGroup="projval" ControlToValidate="txtnoofblocks" ValidationExpression="^\d{1,5}$" ErrorMessage="Enter valid no. of blocks"></asp:RegularExpressionValidator>
                                            </span>
                                        </div>
                                        <div class="col-sm-4 col-xl-2 pt-3">
                                            <div class="input-icon input-icon-sm right">
                                                <label>No. of Flats <span class="text-danger">*</span></label>
                                                <i class="bi bi-building b5-icon"></i>
                                                <asp:TextBox runat="server" ID="txtflatsunits" ClientIDMode="Static" MaxLength="5" class="form-control input-sm" autocomplete="off" placeholder=""></asp:TextBox>
                                            </div>
                                            <span class="error">
                                                <asp:RequiredFieldValidator ClientIDMode="Static" EnableClientScript="true" SetFocusOnError="true" ControlToValidate="txtflatsunits" Display="Dynamic" ValidationGroup="projval" ID="RequiredFieldValidator10" runat="server" ErrorMessage="Enter no. of flats "></asp:RequiredFieldValidator>
                                                <asp:RegularExpressionValidator ClientIDMode="Static" ID="RegularExpressionValidator5" Display="Dynamic" runat="server" ValidationGroup="projval" ControlToValidate="txtflatsunits" ValidationExpression="^\d{1,5}$" ErrorMessage="Enter valid no. of flats"></asp:RegularExpressionValidator>
                                            </span>
                                        </div> 
                                        <div class="col-sm-4 col-xl-3 pt-3">
                                            <div class="input-icon input-icon-sm right">
                                                <label>RERA Number <span class="text-danger">*</span></label>
                                                <i class="bi bi-file-earmark-zip b5-icon"></i>
                                                <asp:TextBox runat="server" ID="txtreranumber" ClientIDMode="Static" MaxLength="100" class="form-control input-sm" autocomplete="off" placeholder=""></asp:TextBox>
                                            </div>
                                            <span class="error">
                                                <asp:RequiredFieldValidator ClientIDMode="Static" EnableClientScript="true" SetFocusOnError="true" ControlToValidate="txtreranumber" ValidationGroup="projval" ID="RequiredFieldValidator12" runat="server" ErrorMessage="Enter RERA no."></asp:RequiredFieldValidator>
                                                <asp:RegularExpressionValidator ClientIDMode="Static" ID="RegularExpressionValidator10" Display="Dynamic" runat="server" ValidationGroup="projval" ControlToValidate="txtreranumber" ValidationExpression="^[A-Za-z0-9\s/-]+$" ErrorMessage="Enter valid RERA no."></asp:RegularExpressionValidator>
                                            </span>
                                        </div> 
                                        <div class="col-sm-4 col-xl-2 pt-3">
                                            <div class="input-icon input-icon-sm right">
                                                <label>Project Status <span class="text-danger">*</span></label>
                                                <i class="bi bi-check2-square b5-icon"></i>
                                                <asp:DropDownList ID="ddlProjectstatus" ClientIDMode="Static" class="bs-select form-control input-sm" runat="server">
                                                    <asp:ListItem Selected="True"></asp:ListItem>
                                                    <asp:ListItem Value="0">Ongoing</asp:ListItem>
                                                    <asp:ListItem Value="1">Completed</asp:ListItem>
                                                </asp:DropDownList>
                                            </div>
                                            <span class="error">
                                                <asp:RequiredFieldValidator ClientIDMode="Static" EnableClientScript="true" SetFocusOnError="true" ControlToValidate="ddlProjectstatus" ValidationGroup="projval" ID="RequiredFieldValidator13" runat="server" ErrorMessage="Select project status"></asp:RequiredFieldValidator>
                                            </span>
                                        </div> 
                                        <div class="col-md-4 pt-3 d-none">
                                            <div class="input-icon input-icon-sm right">
                                                <label>Project Display Status <span class="text-danger">*</span></label>
                                                <div class="toggle-container">
                                                    <div class="toggle-switch">
                                                        <asp:CheckBox ID="toggleActiveInactive" Checked="true" runat="server" ClientIDMode="Static" />
                                                        <label for="toggleActiveInactive" class="toggle-label">
                                                            <span class="toggle-text-active">Active</span>
                                                            <span class="toggle-text-inactive">Inactive</span>
                                                        </label>
                                                    </div>
                                                </div> 
                                            </div>
                                        </div>
                                        <div class="col-md-4 pt-3 d-none">
                                            <div class="input-icon input-icon-sm right">
                                                <label>Project Screen <span class="text-danger">*</span></label>
                                                <i class="bi bi-images b5-icon"></i>
                                                <asp:FileUpload ID="FluploadProjectScreen" ClientIDMode="Static" accept=".jpeg, .jpg, .png" class="form-control input-sm FluploadProjectScreen" autocomplete="off" placeholder="" runat="server" />
                                                
                                                <span class="handle-file-request">(max file size of 800 KB)</span>
                                            </div>
                                            <asp:HiddenField ID="hdnprojectscreen" runat="server" />
                                            <span class="error">
                                                <asp:Label ID="lblFluploadProjectScreen" CssClass="lblFluploadProjectScreen" runat="server" ForeColor="#d41111" Text=""></asp:Label>
                                            </span>
                                            <span class="error"></span>
                                            <div class="view-pro-screen-img view-pro-screen  btn-view-pop" runat="server" id="viewproscreenbtn" style="display: none">
                                                <i class="bi bi-eye"></i>View Image
                                            </div>
                                        </div> 
                                        <div class="col-sm-4 col-xl-2 pt-3">
                                            <div class="input-icon input-icon-sm right">
                                                <label>Completion <span class="text-danger">*</span></label>
                                                <i class="bi bi-journal-check b5-icon"></i>
                                                <asp:TextBox runat="server" ID="txtProjectstatus" ClientIDMode="Static" MaxLength="50" class="form-control input-sm" autocomplete="off" placeholder=""></asp:TextBox>
                                                <div class="handle-file-request">(in percentage)</div>
                                            </div>
                                            <span class="error">
                                                <asp:RequiredFieldValidator ClientIDMode="Static" EnableClientScript="true" SetFocusOnError="true" ControlToValidate="txtProjectstatus" Display="Dynamic" ValidationGroup="projval" ID="RequiredFieldValidator16" runat="server" ErrorMessage="Enter completion"></asp:RequiredFieldValidator>
                                                <asp:CustomValidator ClientIDMode="Static" ID="CustomValidator1" runat="server" ValidationGroup="projval" ClientValidationFunction="validProjectstatus" Display="Dynamic" ErrorMessage="Max 3 digit"></asp:CustomValidator>
                                                <asp:RegularExpressionValidator ClientIDMode="Static" ID="RegularExpressionValidator2" Display="Dynamic" runat="server" ValidationGroup="projval" ControlToValidate="txtProjectstatus" ValidationExpression="^(100|[1-9][0-9]?)$" ErrorMessage="Enter valid number between 1 and 100"></asp:RegularExpressionValidator>
                                            </span>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div class="form-group">
                                <div class="form-border margin-top20">
                                    <div class="form-title"> 
                                        <h3>Project Bank Details </h3>
                                    </div>
                                    <div class="row mx-0 margin-top20 mb-4">
                                        <div class="col-sm-4 col-xl pt-3">
                                            <div class="input-icon input-icon-sm right">
                                                <label>Bank Name <span class="text-danger"></span></label>
                                                <i class="bi bi-bank b5-icon"></i>
                                                <asp:TextBox ID="txtBankname" ClientIDMode="Static" MaxLength="50" class="form-control input-sm capitalize-input" autocomplete="off" placeholder="" runat="server"></asp:TextBox>
                                            </div>
                                            <span class="error"></span>
                                        </div>
                                        <div class="col-sm-4 col-xl pt-3">
                                            <div class="input-icon input-icon-sm right">
                                                <label>Account Name <span class="text-danger"></span></label>
                                                <i class="bi bi-person-square b5-icon"></i>
                                                <asp:TextBox ID="txtaccountname" ClientIDMode="Static" MaxLength="50" class="form-control input-sm capitalize-input" autocomplete="off" placeholder="" runat="server"></asp:TextBox>
                                            </div>
                                            <span class="error">
                                                <asp:RegularExpressionValidator
                                                    ID="RegularExpressionValidatorAccountName"
                                                    runat="server" ClientIDMode="Static"
                                                    ValidationGroup="projval"
                                                    ControlToValidate="txtAccountName"
                                                    ValidationExpression="^[A-Za-z\s-]+$"
                                                    ErrorMessage="Enter valid account name"
                                                    Display="Dynamic" />
                                            </span>
                                        </div>
                                        <div class="col-sm-4 col-xl pt-3">
                                            <div class="input-icon input-icon-sm right">
                                                <label>Account Number <span class="text-danger"></span></label>
                                                <i class="bi bi-file-binary b5-icon"></i>
                                                <asp:TextBox ID="txtaccountnumber" class="form-control input-sm" MaxLength="16" autocomplete="off" placeholder="" runat="server"></asp:TextBox>
                                            </div>
                                            <span class="error">
                                                <asp:RegularExpressionValidator ClientIDMode="Static" ID="RegularExpressionValidator1" Display="Dynamic" runat="server" ValidationGroup="projval" ControlToValidate="txtaccountnumber" ValidationExpression="^[1-9]\d{7,16}$" ErrorMessage="Enter valid account number"></asp:RegularExpressionValidator>
                                            </span>
                                        </div>
                                        <div class="col-sm-4 col-xl pt-3">
                                            <div class="input-icon input-icon-sm right">
                                                <label>IFSC Number <span class="text-danger"></span></label>
                                                <i class="bi bi-safe b5-icon"></i>
                                                <asp:TextBox ID="txtifscnumber" MaxLength="11" class="form-control input-sm" autocomplete="off" ClientIDMode="Static" placeholder="" runat="server"></asp:TextBox>
                                            </div>
                                            <span class="error">
                                                <asp:RegularExpressionValidator ClientIDMode="Static" ID="RegularExpressionValidator6" Display="Dynamic" runat="server" ValidationGroup="projval" ControlToValidate="txtifscnumber" ValidationExpression="^[A-Z]{4}0[A-Z0-9]{6}$" ErrorMessage="Enter valid IFSC number"></asp:RegularExpressionValidator>
                                            </span>
                                        </div>
                                        <div class="col-sm-4 col-xl pt-3">
                                            <div class="input-icon input-icon-sm right">
                                                <label>Branch <span class="text-danger"></span></label>
                                                <i class="bi bi-safe2 b5-icon"></i>
                                                <asp:TextBox ID="txtBranch" MaxLength="50" class="form-control input-sm capitalize-input" autocomplete="off" placeholder="" runat="server"></asp:TextBox>
                                            </div>
                                            <span class="error">
                                                <asp:RegularExpressionValidator ClientIDMode="Static" ID="RegularExpressionValidator7" Display="Dynamic" runat="server" ValidationGroup="projval" ControlToValidate="txtBranch" ValidationExpression="^[A-Za-z\s-]+$" ErrorMessage="Enter valid branch"></asp:RegularExpressionValidator>
                                            </span>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>

                        <div class="card-footer">
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
                Powered by <a class="text-uppercase" href="https://duffldigital.com/" target="_blank">Duffl Digital</a>
            </div>
        </div>
    </footer>
     
    <!-- Date Picker -->
    <script src="assets/js/dtsel.js"></script> 
    <script type="text/javascript"> 
        document.getElementById('<%= txtaccountnumber.ClientID %>').addEventListener('keypress', function (e) {
            if (e.key < '0' || e.key > '9' || this.value.length >= 18) {
                e.preventDefault();
            }
        });
        document.getElementById('<%= txtflatsunits.ClientID %>').addEventListener('keypress', function (e) {
            if (e.key < '0' || e.key > '9' || this.value.length >= 18) {
                e.preventDefault();
            }
        });
        document.getElementById('<%= txtnoofblocks.ClientID %>').addEventListener('keypress', function (e) {
            if (e.key < '0' || e.key > '9' || this.value.length >= 18) {
                e.preventDefault();
            }
        }); 
        document.getElementById('<%= txtProjectstatus.ClientID %>').addEventListener('keypress', function (e) {
            if (e.key < '0' || e.key > '9' || this.value.length >= 3) {
                e.preventDefault();
            }
        });
        document.getElementById('<%= txtpostalcode.ClientID %>').addEventListener('keypress', function (e) {
            if (e.key < '0' || e.key > '9' || this.value.length >= 6) {
                e.preventDefault();
            }
        });
        document.getElementById('<%= txtreranumber.ClientID %>').addEventListener('keypress', function (e) {
            if (!/^[A-Za-z0-9\s/-]+$/.test(e.key)) {
                e.preventDefault();
            }
        }); 
        document.getElementById('<%= txtaccountname.ClientID %>').addEventListener('keypress', function (e) {
            if (!/^[A-Za-z\s-]+$/.test(e.key)) {
                e.preventDefault();
            }
        }); 
        document.getElementById('<%= txtaccountnumber.ClientID %>').addEventListener('keypress', function (e) {
            var validPattern = !/^[1-9]\d{8,17}$/;
            if (!validPattern.test(e.key)) {
                e.preventDefault();
            }
        }); 
        document.getElementById('<%= txtifscnumber.ClientID %>').addEventListener('keypress', function (e) {
            var validPattern = /^[A-Za-z0-9\s]+$/;
            if (!validPattern.test(e.key)) {
                e.preventDefault();
            }
        }); 
        document.getElementById('<%= txtBankname.ClientID %>').addEventListener('keypress', function (e) {
            var validPattern = /^[a-zA-Z\s-]+$/;
            if (!validPattern.test(e.key)) {
                e.preventDefault();
            }
        });
        document.getElementById('<%= txtprojectname.ClientID %>').addEventListener('keypress', function (e) {
            var validPattern = /^[A-Za-z0-9\s.,-]+$/;
            if (!validPattern.test(e.key)) {
                e.preventDefault();
            }
        });
        document.getElementById('<%= txtlocation.ClientID %>').addEventListener('keypress', function (e) {
            var validPattern = /^[A-Za-z\s.,-]+$/;
            if (!validPattern.test(e.key)) {
                e.preventDefault();
            }
        });
        document.getElementById('<%= txtAddress.ClientID %>').addEventListener('keypress', function (e) {
            var validPattern = /^[A-Za-z0-9\s.,-/()]+$/;
            if (!validPattern.test(e.key)) {
                e.preventDefault();
            }
        });
        document.getElementById('<%= txtlandarea.ClientID %>').addEventListener('keypress', function (e) {
            var validPattern = /^[0-9\s]+$/;
            if (!validPattern.test(e.key)) {
                e.preventDefault();
            }
        });
        document.getElementById('<%= txtBranch.ClientID %>').addEventListener('keypress', function (e) {
            var validPattern = /^[A-Za-z\s-]+$/;
            if (!validPattern.test(e.key)) {
                e.preventDefault();
            }
        });
    </script>
     
    <script type="text/javascript">
        function validatePage() { 
            var flag = Page_ClientValidate('projval') 
            return flag;
        }
    </script>
     
    <script type="text/javascript">
        function keyupFunction(inputId) {
            const getQueryStringValue = (param) => new URLSearchParams(window.location.search).get(param);
            var ProjectID=getQueryStringValue('ProjectID')  // Example usage with 'ProjectID'

            var projectName = $('#' + inputId).val();
            var messageDiv = $('#projectValidationMessage');
            if (projectName.trim() !== '') {
                $.ajax({
                    type: "POST",
                    url: "add-project.aspx/CheckProjectExistence",
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    data: JSON.stringify({
                        ProjectID: ProjectID,
                        projectName: projectName
                    }),
                    success: function (response) {
                        if (response.d === true) {
                            messageDiv.text("Project already exists").css("color", "#d41111");
                        } else {
                            messageDiv.text("");
                            // messageDiv.text("Project name is not exist to the client.").css("color", "green");
                        }
                    },
                    error: function (xhr) {
                        //console.error("An error occurred: " + xhr.responseText);
                        //messageDiv.text("Error occurred while checking project name.").css("color", "red");
                        messageDiv.text("");
                    }
                });
            } else {
                messageDiv.text("").css("color", "#d41111");
            }
        }
    </script>
     
    <script type="text/javascript">
        function validProjectstatus(sender, args) {
            //alert("hi");  // Check if the function is called
            var text = $('#<%= txtProjectstatus.ClientID %>').val(); 
            if (text != null) {
                //alert(text.length);
                if (text.length <= 3) {
                    args.IsValid = true;
                } else {
                    args.IsValid = false;
                }
            }
        }
    </script>
       
    <script type="text/javascript">
        //-- view loca-map img with popup
        document.addEventListener('DOMContentLoaded', function () { 
            var fileUploader = document.querySelector('.Fileuploadlocationmap');
            var viewLogoBtn = document.querySelector('.view-loca-map-img');
            var mapsrc = document.querySelector('.view-loca-map-img'); 
            if (!fileUploader || !viewLogoBtn) {
                console.error("Required elements not found in the DOM.");
                return;
            } 
            mapsrc = null; 
            fileUploader.addEventListener('change', function (event) {
                var file = event.target.files[0]; 
                if (file) {
                    var reader = new FileReader();
                    reader.onload = function (e) {
                        mapsrc = e.target.result;
                        viewLogoBtn.src = mapsrc;
                        viewLogoBtn.style.display = 'inline-block';
                    }; 
                    reader.onerror = function (err) {
                        console.error("Error reading file:", err);
                        mapsrc = null;
                    }; 
                    reader.readAsDataURL(file);
                } else { 
                    mapsrc = null;
                    viewLogoBtn.src = '';
                    viewLogoBtn.style.display = 'none';
                    // alert("No file selected.");
                }
            });

            viewLogoBtn.addEventListener('click', function () {
                if (!mapsrc) {
                    //alert("No image uploaded yet!");
                    return;
                }
                Swal.fire({
                    html: `
                         <div style="position: relative;">
                             <div class="btn-close-icon" style="cursor: pointer; position: absolute; top: -15px; right: -25px;">&times;</div>
                             <h2 class="fw-bold">Location Map</h2>
                             <img id="swalImage" src="" alt="Location Map" class="img-fluid mt-3">
                         </div>
                     `,
                    showConfirmButton: false,
                    didOpen: () => {
                        document.getElementById('swalImage').src = mapsrc;
                        document.querySelector('.btn-close-icon').addEventListener('click', () => Swal.close());
                    }
                });
            });
        });
        //--// view loca-map img with popup 
    </script>
      
    <script type="text/javascript">
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
                        // Trigger the ASP.NET Button click to handle postback
                        document.getElementById('<%= btnCancel.ClientID %>').click();
                    } else if (result.dismiss === Swal.DismissReason.cancel) {
                        // User clicked 'No' 
                    }
                });
            });
        });
    </script>
  
    <script type="text/javascript">
        //logo fileupload
        function showMyImage2(fileInput) {
            var lbl = document.querySelector('.lblFileuploadlocationmap');
            var files = fileInput.files;
            var allowedFiles = [".png", ".jpg", ".jpeg"];
            if (files.length === 0) {
                //resetImageDisplay();
                var viewLogoBtn = document.querySelector('.view-loca-map-img');
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
                        var viewLogoBtn = document.querySelector('.view-loca-map-img');
                        viewLogoBtn.style.display = 'none';
                        //resetImageDisplay();
                        return;
                    } else {
                        var lbl = document.querySelector('.lblFileuploadlocationmap');
                        lbl.textContent = "";
                        var viewLogoBtn = document.querySelector('.view-loca-map-img');
                        viewLogoBtn.style.display = 'inline-block';
                    }
                } else {
                    lbl.textContent="Select .png, .jpg, or .jpeg files only.";
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
        function bindImageToPreviewlocationmap(imagePath) {
            var viewLogoBtn = document.querySelector('.view-loca-map-img');
            var lbl = document.querySelector('.lblFileuploadlocationmap');
            if (imagePath) {
                viewLogoBtn.src = imagePath;
                viewLogoBtn.style.display = 'inline-block';
                lbl.textContent = "";
                viewLogoBtn.onclick = function () {
                    var imageSrc = imagePath || 'assets/img/logo.png';
                    Swal.fire({
                        html: `
                                <div style="position: relative;">
                                    <div class="btn-close-icon" 
                                         style="cursor: pointer; position: absolute; top: -15px; right: -25px;">
                                         &times;
                                    </div>
                                    <h2 class="fw-bold">Location Map</h2>
                                    <img src="${imageSrc}" alt="Location Map" class="img-fluid mt-3">
                                </div>
                            `,
                        showConfirmButton: false,
                        didOpen: () => {
                            document.querySelector('.btn-close-icon').addEventListener('click', () => Swal.close());
                        }
                    });
                };

            } else {
                viewLogoBtn.src = "";
                viewLogoBtn.style.display = 'none';
                lbl.textContent = "No image available.";
            }
        }
    </script>

</asp:Content>

