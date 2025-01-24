<%@ Page Title="" Language="C#" MasterPageFile="AdminKey2h.master" AutoEventWireup="true" CodeFile="add-flat-booking.aspx.cs" Inherits="adminkey2hcom_AddFlatBooking" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <!-- jQuery UI library -->
    <link rel="stylesheet" href="https://code.jquery.com/ui/1.12.1/themes/base/jquery-ui.css">
    <link rel="stylesheet" href="assets/css/dtsel.css" />
    <style>
        .btn-view-pop {
            top: 5px;
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
                            <asp:Label ID="lblDisplay" runat="server" Text=""></asp:Label></h2>
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
                                        <h3>Applicant Details</h3>
                                    </div>
                                    <div class="row mx-0 margin-top20 mb-4">
                                        <div class="col-sm-4 col-xl-3 pt-3">
                                            <div class="input-icon input-icon-sm right">
                                                <label>First Name <span class="text-danger">*</span></label>
                                                <i class="bi bi-person-square b5-icon"></i>
                                                <asp:TextBox ID="txtapplicationname" class="form-control input-sm capitalize-input" MaxLength="50" autocomplete="off" placeholder="" runat="server"></asp:TextBox>
                                            </div>
                                            <span class="error">
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" Display="Dynamic" runat="server" ControlToValidate="txtapplicationname" ValidationGroup="CusVal" ErrorMessage="Enter first name"></asp:RequiredFieldValidator>
                                                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtapplicationname" ValidationGroup="CusVal"
                                                    ValidationExpression="^[A-Za-z ]+(\.)?$" ErrorMessage="Enter vaid first name" Display="Dynamic"></asp:RegularExpressionValidator>
                                            </span>
                                        </div>
                                        <div class="col-sm-4 col-xl-3 pt-3">
                                            <div class="input-icon input-icon-sm right">
                                                <label>Last Name </label>
                                                <i class="bi bi-person-lines-fill b5-icon"></i>
                                                <asp:TextBox ID="txtapplicationlastname" class="form-control input-sm capitalize-input" MaxLength="50" autocomplete="off" placeholder="" runat="server"></asp:TextBox>

                                            </div>
                                            <span class="error">
                                                <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="txtapplicationlastname" ValidationGroup="CusVal"
                                                    ValidationExpression="^[A-Za-z ]+(\.)?$" ErrorMessage="Enter valid last name" Display="Dynamic"></asp:RegularExpressionValidator>
                                            </span>
                                        </div>


                                        <div class="col-sm-4 col-xl-3 pt-3">
                                            <div class="input-icon input-icon-sm right">
                                                <label>Father / Spouse Name <span class="text-danger">*</span></label>
                                                <i class="bi bi-people-fill b5-icon"></i>
                                                <asp:TextBox ID="txtFatherORSpouseName" class="form-control input-sm capitalize-input" MaxLength="50" runat="server"></asp:TextBox>
                                            </div>
                                            <span class="error">
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" Display="Dynamic" runat="server" ControlToValidate="txtFatherORSpouseName" ValidationGroup="CusVal" ErrorMessage="Enter father / spouse name"></asp:RequiredFieldValidator>
                                                <asp:RegularExpressionValidator ID="RegularExpressionValidator5" runat="server" ControlToValidate="txtFatherORSpouseName" ValidationGroup="CusVal"
                                                    ValidationExpression="^[A-Za-z ]+(\.)?$" ErrorMessage="Enter valid father / spouse name" Display="Dynamic"></asp:RegularExpressionValidator>

                                            </span>
                                        </div>
                                        <div class="col-sm-4 col-xl-2 pt-3">
                                            <div class="input-icon input-icon-sm right">
                                                <label>Gender <span class="text-danger">*</span></label>
                                                <i class="bi bi-gender-female b5-icon"></i>

                                                <asp:DropDownList ID="ddlgender" CssClass="bs-select form-control input-sm" runat="server">
                                                    <asp:ListItem Value=""> </asp:ListItem>
                                                    <asp:ListItem Value="Male">Male</asp:ListItem>
                                                    <asp:ListItem Value="Female">Female</asp:ListItem>
                                                    <asp:ListItem Value="Other">Other</asp:ListItem>
                                                </asp:DropDownList>

                                            </div>
                                            <span class="error">
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" Display="Dynamic" runat="server" InitialValue="" ControlToValidate="ddlgender" ValidationGroup="CusVal" ErrorMessage="Select gender"></asp:RequiredFieldValidator>

                                            </span>
                                        </div>

                                        <div class="col-sm-4 col-xl-2 pt-3">
                                            <div class="input-icon input-icon-sm right">
                                                <label>Date of Birth <span class="text-danger">*</span></label>
                                                <i class="bi bi-calendar-week b5-icon"></i>
                                                <asp:TextBox ID="txtdateofbirth" ClientIDMode="Static" class="form-control input-sm" runat="server"></asp:TextBox>
                                            </div>
                                            <span class="error">
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator8" Display="Dynamic" runat="server" ControlToValidate="txtdateofbirth" ValidationGroup="CusVal" ErrorMessage="Select date of birth"></asp:RequiredFieldValidator>
                                            </span>
                                        </div>
                                        <div class="col-sm-4 col-xl-3 pt-3">
                                            <div class="input-icon input-icon-sm right">
                                                <label>Email ID <span class="text-danger">*</span></label>
                                                <i class="bi bi-envelope b5-icon"></i>
                                                <asp:TextBox ID="txtEmailid" class="form-control input-sm" MaxLength="50" runat="server"></asp:TextBox>

                                            </div>
                                            <span class="error">
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator5" Display="Dynamic" runat="server" ControlToValidate="txtEmailid" ValidationGroup="CusVal" ErrorMessage="Enter email id"></asp:RequiredFieldValidator>
                                                <asp:RegularExpressionValidator ID="RegularExpressionValidator6" runat="server" ControlToValidate="txtEmailid" ValidationGroup="CusVal"
                                                    ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" ErrorMessage="Enter valid emailid" Display="Dynamic"></asp:RegularExpressionValidator>

                                            </span>
                                        </div>


                                        <div class="col-sm-4 col-xl-2 pt-3">
                                            <div class="input-icon input-icon-sm right">
                                                <label>Mobile Number 1 <span class="text-danger">*</span></label>
                                                <i class="bi bi-telephone-fill b5-icon"></i>
                                                <asp:TextBox ID="txtmobilenumber1" MaxLength="10" ClientIDMode="Static" class="form-control input-sm" runat="server"></asp:TextBox>
                                            </div>
                                            <span class="error">
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator6" Display="Dynamic" runat="server" ControlToValidate="txtmobilenumber1" ValidationGroup="CusVal" ErrorMessage="Enter mobile no."></asp:RequiredFieldValidator>
                                                <asp:RegularExpressionValidator ID="RegularExpressionValidator7" runat="server" ControlToValidate="txtmobilenumber1" ValidationGroup="CusVal"
                                                    ValidationExpression="^(?![0-5])\d{10}$" ErrorMessage="Enter valid mobile no." Display="Dynamic"></asp:RegularExpressionValidator>
                                            </span>
                                            <span class="handle-file-request">
                                                <asp:CheckBox ID="chkSameaswhatsapp" runat="server" ClientIDMode="Static" onclick="callFunction();" />
                                                The mobile number is the same as the WhatsApp number  </span>
                                        </div>
                                        <div class="col-sm-4 col-xl-2 pt-3">
                                            <div class="input-icon input-icon-sm right">
                                                <label>Mobile Number 2</label>
                                                <i class="bi bi-telephone b5-icon"></i>
                                                <asp:TextBox ID="txtmobilenumber2" MaxLength="10" class="form-control input-sm" runat="server"></asp:TextBox>
                                            </div>
                                            <span class="error">
                                                <asp:RegularExpressionValidator ID="RegularExpressionValidator8" runat="server" ControlToValidate="txtmobilenumber2" ValidationGroup="CusVal"
                                                    ValidationExpression="^(?![0-5])\d{10}$" ErrorMessage="Enter valid mobile no. 2" Display="Dynamic"></asp:RegularExpressionValidator>
                                            </span>
                                        </div>

                                        <div class="col-sm-4 col-xl-2 pt-3">
                                            <div class="input-icon input-icon-sm right">
                                                <label>WhatsApp Number <span class="text-danger">*</span></label>
                                                <i class="bi bi-whatsapp b5-icon"></i>
                                                <asp:TextBox ID="txtwhatsappnumber" MaxLength="10" ClientIDMode="Static" class="form-control input-sm" runat="server"></asp:TextBox>

                                            </div>
                                            <span class="error">
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator9" Display="Dynamic" runat="server" ControlToValidate="txtwhatsappnumber" ValidationGroup="CusVal" ErrorMessage="Enter whatsapp no."></asp:RequiredFieldValidator>
                                                <asp:RegularExpressionValidator ID="RegularExpressionValidator9" runat="server" ControlToValidate="txtwhatsappnumber" ValidationGroup="CusVal"
                                                    ValidationExpression="^(?![0-5])\d{10}$" ErrorMessage="Enter valid whatsapp no." Display="Dynamic"></asp:RegularExpressionValidator>
                                            </span>
                                        </div>


                                        <div class="col-sm-4 col-xl-3 pt-3">
                                            <div class="input-icon input-icon-sm right">
                                                <label>Profession <span class="text-danger">*</span></label>
                                                <i class="bi bi-briefcase b5-icon"></i>
                                                <asp:TextBox ID="txtprofession" class="form-control input-sm capitalize-input" MaxLength="50" runat="server"></asp:TextBox>
                                            </div>
                                            <span class="error">
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator10" Display="Dynamic" runat="server" ControlToValidate="txtprofession" ValidationGroup="CusVal" ErrorMessage="Enter profession"></asp:RequiredFieldValidator>
                                                <asp:RegularExpressionValidator ID="RegularExpressionValidator10" runat="server" ControlToValidate="txtprofession" ValidationGroup="CusVal"
                                                    ValidationExpression="^[A-Za-z ]+(\.)?$" ErrorMessage="Enter valid profession." Display="Dynamic"></asp:RegularExpressionValidator>
                                            </span>
                                        </div>
                                        <div class="col-sm-4 col-xl-3 pt-3">
                                            <div class="input-icon input-icon-sm right">
                                                <label>Company Name </label>
                                                <i class="bi bi-bank2 b5-icon"></i>
                                                <asp:TextBox ID="txtcompanyname" class="form-control input-sm capitalize-input" MaxLength="50" runat="server"></asp:TextBox>
                                            </div>
                                            <span class="error">
                                                <asp:RegularExpressionValidator ID="RegularExpressionValidator11" runat="server" ControlToValidate="txtcompanyname" ValidationGroup="CusVal"
                                                    ValidationExpression="^[A-Za-z0-9 &\-,.'/()#]+$" ErrorMessage="Enter valid company name" Display="Dynamic"></asp:RegularExpressionValidator>
                                            </span>
                                        </div>

                                        <div class="col-sm-4 col-xl-2 pt-3">
                                            <div class="input-icon input-icon-sm right">
                                                <label>Designation </label>
                                                <i class="bi bi-person-workspace b5-icon"></i>
                                                <asp:TextBox ID="txtDesignation" class="form-control input-sm capitalize-input" MaxLength="50" runat="server"></asp:TextBox>

                                            </div>
                                            <span class="error">
                                                <asp:RegularExpressionValidator ID="RegularExpressionValidator12" runat="server" ControlToValidate="txtDesignation" ValidationGroup="CusVal"
                                                    ValidationExpression="^[A-Za-z\s&\-.',/]+$" ErrorMessage="Enter valid designation" Display="Dynamic"></asp:RegularExpressionValidator>
                                            </span>
                                        </div>

                                        <div class="col-sm-4 col-xl-3 pt-3">
                                            <div class="input-icon input-icon-sm right">
                                                <label>Relationship with Co-Applicant <span class="text-danger">*</span> </label>
                                                <i class="bi bi-person-plus"></i>



                                                <asp:DropDownList ID="ddlRelationshipwithCoApplicant" class="bs-select form-control input-sm" runat="server">
                                                    <asp:ListItem Value="" Text="" />
                                                    <asp:ListItem Value="1" Text="Spouse" />
                                                    <asp:ListItem Value="2" Text="Parent" />
                                                    <asp:ListItem Value="3" Text="Sibling" />
                                                    <asp:ListItem Value="4" Text="Child" />
                                                    <asp:ListItem Value="5" Text="Relative" />
                                                    <asp:ListItem Value="6" Text="Friend" />
                                                    <asp:ListItem Value="7" Text="BusinessPartner" />
                                                    <asp:ListItem Value="8" Text="Colleague" />
                                                    <asp:ListItem Value="9" Text="Guardian" />
                                                    <asp:ListItem Value="10" Text="Other" />
                                                </asp:DropDownList>
                                                <%-- <asp:TextBox ID="txtRelationshipwithcoapplicant" MaxLength="50" class="form-control input-sm capitalize-input" runat="server"></asp:TextBox>--%>
                                            </div>
                                            <span class="error">
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator17" Display="Dynamic" runat="server" ControlToValidate="ddlRelationshipwithCoApplicant" InitialValue="" ValidationGroup="CusVal" ErrorMessage="Select relationship with co-applicant"></asp:RequiredFieldValidator>
                                                <%--   <asp:RegularExpressionValidator ID="RegularExpressionValidator13" runat="server" ControlToValidate="txtRelationshipwithcoapplicant" ValidationGroup="CusVal"
                                                    ValidationExpression="^[A-Za-z\s\-'&]+(?<!\.)$" ErrorMessage="Enter valid relationship with co-applicant" Display="Dynamic"></asp:RegularExpressionValidator>
                                                --%></span>
                                        </div>

                                        <div class="col-sm-4 col-xl-4 pt-3">
                                            <div class="input-icon input-icon-sm right">
                                                <label>Current Residing Address <span class="text-danger">*</span></label>
                                                <i class="bi bi-geo-fill b5-icon"></i>
                                                <asp:TextBox ID="txtCurrentResidingAddress" MaxLength="95" class="form-control capitalize-input" TextMode="MultiLine" Rows="1" cols="50" runat="server"></asp:TextBox>
                                            </div>
                                            <span class="error">
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator7" Display="Dynamic" runat="server" ControlToValidate="txtCurrentResidingAddress" ValidationGroup="CusVal" ErrorMessage="Enter current residing address"></asp:RequiredFieldValidator>
                                                <asp:RegularExpressionValidator ID="RegularExpressionValidator14" runat="server" ControlToValidate="txtCurrentResidingAddress" ValidationGroup="CusVal"
                                                    ValidationExpression="^[A-Za-z0-9\s,.\-#/']+$" ErrorMessage="Enter valid current residing address" Display="Dynamic"></asp:RegularExpressionValidator>
                                            </span>
                                        </div>

                                        <div class="col-sm-4 col-xl-4 pt-3">
                                            <div class="input-icon input-icon-sm right">
                                                <label>Permanent Address <span class="text-danger">*</span></label>
                                                <i class="bi bi-crosshair b5-icon"></i>
                                                <asp:TextBox ID="txtPermanentAddress" MaxLength="95" class="form-control capitalize-input" TextMode="MultiLine" Rows="1" cols="50" runat="server"></asp:TextBox>
                                            </div>
                                            <span class="error">
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator11" Display="Dynamic" runat="server" ControlToValidate="txtPermanentAddress" ValidationGroup="CusVal" ErrorMessage="Enter permanent address"></asp:RequiredFieldValidator>
                                                <asp:RegularExpressionValidator ID="RegularExpressionValidator15" runat="server" ControlToValidate="txtPermanentAddress" ValidationGroup="CusVal"
                                                    ValidationExpression="^[A-Za-z0-9\s,.\-#/']+$" ErrorMessage="Enter valid permanent address" Display="Dynamic"></asp:RegularExpressionValidator>
                                            </span>
                                        </div>

                                        <div class="col-sm-4 col-xl-3 pt-3">
                                            <div class="input-icon input-icon-sm right">
                                                <label>Residential Status <span class="text-danger">*</span></label>
                                                <i class="bi bi-house-door b5-icon"></i>
                                                <asp:DropDownList ID="ddlResidentialStatus" class="bs-select form-control input-sm" runat="server">
                                                    <asp:ListItem Selected="True" Value=""></asp:ListItem>
                                                    <asp:ListItem Value="Owned">Owned</asp:ListItem>
                                                    <asp:ListItem Value="Rented">Rented</asp:ListItem>
                                                    <asp:ListItem Value="Living with family">Living with family</asp:ListItem>
                                                </asp:DropDownList>
                                            </div>
                                            <span class="error">
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator12" Display="Dynamic" runat="server" InitialValue="" ControlToValidate="ddlResidentialStatus" ValidationGroup="CusVal" ErrorMessage="Select residential status"></asp:RequiredFieldValidator>
                                            </span>
                                        </div>
                                        <div class="col-sm-4 col-xl-2 pt-3">
                                            <asp:UpdatePanel ID="UpdatePanel1" runat="server" RenderMode="Block" UpdateMode="Conditional" ChildrenAsTriggers="true">
                                                <ContentTemplate>
                                                    <div class="input-icon input-icon-sm right">
                                                        <label>State <span class="text-danger">*</span></label>
                                                        <i class="bi bi-globe-americas b5-icon"></i>
                                                        <asp:DropDownList ID="ddlstate" AutoPostBack="true" OnSelectedIndexChanged="ddlstate_SelectedIndexChanged" class="bs-select form-control input-sm" runat="server">
                                                            <asp:ListItem Selected="True"></asp:ListItem>
                                                        </asp:DropDownList>
                                                    </div>
                                                    <span class="error">
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator13" Display="Dynamic" runat="server" InitialValue="" ControlToValidate="ddlstate" ValidationGroup="CusVal" ErrorMessage="Select state"></asp:RequiredFieldValidator>
                                                    </span>
                                                </ContentTemplate>
                                                <Triggers>
                                                    <asp:AsyncPostBackTrigger ControlID="ddlstate" EventName="SelectedIndexChanged" />
                                                </Triggers>
                                            </asp:UpdatePanel>
                                        </div>
                                        <div class="col-sm-4 col-xl-2 pt-3">
                                            <asp:UpdatePanel ID="UpdatePanel2" runat="server" RenderMode="Block" UpdateMode="Conditional" ChildrenAsTriggers="true">
                                                <ContentTemplate>
                                                    <div class="input-icon input-icon-sm right">
                                                        <label>City <span class="text-danger">*</span></label>
                                                        <i class="bi bi-buildings b5-icon"></i>
                                                        <asp:DropDownList ID="ddlcity" class="bs-select form-control input-sm" runat="server">
                                                            <asp:ListItem Selected="True"></asp:ListItem>
                                                        </asp:DropDownList>
                                                    </div>
                                                    <span class="error">
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator14" Display="Dynamic" runat="server" InitialValue="" ControlToValidate="ddlcity" ValidationGroup="CusVal" ErrorMessage="Select city"></asp:RequiredFieldValidator>
                                                    </span>
                                                </ContentTemplate>
                                                <Triggers>
                                                    <asp:AsyncPostBackTrigger ControlID="ddlstate" EventName="SelectedIndexChanged" />
                                                </Triggers>
                                            </asp:UpdatePanel>
                                        </div>
                                        <div class="col-sm-4 col-xl-2 pt-3">
                                            <div class="input-icon input-icon-sm right">
                                                <label>Postal Code <span class="text-danger">*</span></label>
                                                <i class="bi bi-mailbox b5-icon"></i>
                                                <asp:TextBox ID="txtpostalcode" MaxLength="6" class="form-control input-sm" runat="server"></asp:TextBox>
                                            </div>
                                            <span class="error">
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator15" Display="Dynamic" runat="server" ControlToValidate="txtpostalcode" ValidationGroup="CusVal" ErrorMessage="Enter postal code"></asp:RequiredFieldValidator>
                                                <asp:RegularExpressionValidator ClientIDMode="Static" ID="RegularExpressionValidator16" Display="Dynamic" runat="server" ValidationGroup="CusVal" ControlToValidate="txtpostalcode" ValidationExpression="^\d{0,6}$" ErrorMessage="Enter valid postal code"></asp:RegularExpressionValidator>
                                            </span>
                                        </div>
                                        <div class="col-sm-4 col-xl-2 pt-3">
                                            <div class="input-icon input-icon-sm right">
                                                <label>Loan Taken <span class="text-danger">*</span></label>
                                                <i class="bi bi-check-circle b5-icon"></i>
                                                <asp:DropDownList ID="ddloantaken" class="bs-select form-control input-sm" runat="server">
                                                    <asp:ListItem Value=""></asp:ListItem>
                                                    <asp:ListItem Value="1">Yes</asp:ListItem>
                                                    <asp:ListItem Value="0">No</asp:ListItem>
                                                </asp:DropDownList>
                                            </div>
                                        </div>

                                        <div class="col-sm-4 col-xl-3 pt-3 " style="display: none" runat="server" id="Divbankname">
                                            <div class="input-icon input-icon-sm right">
                                                <label>Bank Name <span class="text-danger">*</span></label>
                                                <i class="bi bi-bank b5-icon"></i>
                                                <asp:DropDownList ID="ddlbankname" ClientIDMode="Static" class="form-control input-sm capitalize-input" runat="server">
                                                    <asp:ListItem Selected="True"></asp:ListItem>

                                                </asp:DropDownList>
                                            </div>
                                            <span class="error">
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator20" Display="Dynamic" runat="server" InitialValue="" ControlToValidate="ddlbankname" ValidationGroup="CusVal" ErrorMessage="Select bank name"></asp:RequiredFieldValidator>
                                            </span>
                                        </div>
                                        <div class="col-sm-4 col-xl-2 pt-3">
                                            <div class="input-icon input-icon-sm right">
                                                <label>Lead Source <span class="text-danger">*</span></label>
                                                <i class="bi bi-diagram-2 b5-icon"></i>
                                                <asp:DropDownList ID="ddlLeadSource" ClientIDMode="Static" class="bs-select form-control input-sm" runat="server">
                                                    <asp:ListItem Value=""></asp:ListItem>
                                                </asp:DropDownList>
                                            </div>
                                            <span class="error">
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator18" Display="Dynamic" runat="server" ControlToValidate="ddlLeadSource" InitialValue="" ValidationGroup="CusVal" ErrorMessage="Select lead source"></asp:RequiredFieldValidator>
                                            </span>
                                        </div>
                                        <div class="col-sm-4 col-xl-2 pt-3" id="divreferenceby" clientidmode="Static" runat="server" style="display: none">
                                            <div class="input-icon input-icon-sm right">
                                                <label>Refered By <span class="text-danger">*</span></label>
                                                <i class="bi bi-diagram-2 b5-icon"></i>
                                                <asp:DropDownList ID="ddlReference" ClientIDMode="Static" class="bs-select form-control input-sm" runat="server">
                                                    <asp:ListItem Value=""></asp:ListItem>
                                                </asp:DropDownList>
                                            </div>
                                            <span class="error">
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator19" Display="Dynamic" runat="server" ControlToValidate="ddlReference" InitialValue="" ValidationGroup="CusVal" ErrorMessage="Select reference"></asp:RequiredFieldValidator>
                                            </span>
                                        </div>

                                        <div class="col-sm-4 col-xl-3 pt-3" id="DivRef1" runat="server" clientidmode="Static" style="display: none">
                                            <div class="input-icon input-icon-sm right">
                                                <label>Reference<span class="text-danger">*</span></label>
                                                <i class="bi bi-person-badge b5-icon"></i>
                                                <asp:TextBox ID="txtreference1" class="form-control input-sm capitalize-input" runat="server"></asp:TextBox>
                                                <span class="handle-file-request">(name / phone / code)</span>
                                            </div>
                                            <span class="error">
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator16" Display="Dynamic" runat="server" ControlToValidate="txtreference1" ValidationGroup="CusVal" ErrorMessage="Enter reference"></asp:RequiredFieldValidator>
                                                <asp:RegularExpressionValidator ID="RegularExpressionValidator17" runat="server" ControlToValidate="txtreference1" ValidationGroup="CusVal"
                                                    ValidationExpression="^[A-Za-z0-9 ]+(\.)?$" ErrorMessage="Enter valid reference 1" Display="Dynamic"></asp:RegularExpressionValidator>
                                            </span>
                                        </div>
                                        <div class="col-sm-4 col-xl-3 pt-3 d-none" style="display: none !important">
                                            <div class="input-icon input-icon-sm right">
                                                <label>Reference 2 </label>
                                                <i class="bi bi-person-plus-fill b5-icon"></i>
                                                <asp:TextBox ID="txtreference2" class="form-control input-sm capitalize-input" runat="server"></asp:TextBox>
                                            </div>
                                            <span class="error">
                                                <asp:RegularExpressionValidator ID="RegularExpressionValidator18" runat="server" ControlToValidate="txtreference2" ValidationGroup="CusVal"
                                                    ValidationExpression="^[A-Za-z ]+(\.)?$" ErrorMessage="Enter valid reference 2" Display="Dynamic"></asp:RegularExpressionValidator>
                                            </span>
                                        </div>
                                        <div class="col-sm-4 col-xl-3 pt-3">
                                            <div class="input-icon input-icon-sm right">
                                                <label>Photo <span class="text-danger">*</span></label>
                                                <i class="bi bi-images b5-icon"></i>
                                                <asp:FileUpload ID="flPhoto" accept=".jpeg, .jpg, .png" class="form-control input-sm flPhoto" runat="server" />
                                                <span class="handle-file-request">(upload max file size 500 KB)</span>
                                                <asp:HiddenField ID="hdnApplicantPhoto" runat="server" />
                                            </div>

                                            <span class="error">
                                                <asp:Label ID="lblflPhoto" CssClass="lblflPhoto" runat="server" Text=""></asp:Label>
                                            </span>
                                            <span class="error">
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator21" Display="Dynamic" runat="server" ControlToValidate="flPhoto" ValidationGroup="CusVal" ErrorMessage="Upload photo"></asp:RequiredFieldValidator>
                                            </span>
                                            <div class="view-pro-screen-img view-pro-screen btn-view-pop btn-view-Photo1" runat="server" id="viewpflphoto" style="display: none">
                                                <i class="bi bi-eye"></i>View Image
                                            </div>
                                        </div>
                                        <div class="col-sm-4 col-xl-3 pt-3">
                                            <div class="input-icon input-icon-sm right">
                                                <label>Aadhar Card Copy <span class="text-danger">*</span></label>
                                                <i class="bi bi-file-earmark-image b5-icon"></i>
                                                <asp:FileUpload ID="FluploadAadhar" ClientIDMode="Static" class="form-control input-sm file-upload" autocomplete="off" runat="server" accept=".pdf, .jpeg, .jpg, .png" />
                                                <span class="handle-file-request">(upload max file size,doc-800 KB/image-500 KB)</span>
                                                <asp:HiddenField ID="hdnApplicantAadhar" runat="server" />
                                            </div>
                                            <span class="error">
                                                <asp:Label ID="lblFluploadAadhar" ClientIDMode="Static" CssClass="lblFluploadAadhar error-label" runat="server" Text=""></asp:Label>
                                            </span>
                                            <span class="error">
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator23" Display="Dynamic" runat="server" ControlToValidate="FluploadAadhar" ValidationGroup="CusVal" ErrorMessage="Upload aadhar card copy"></asp:RequiredFieldValidator>
                                            </span>
                                            <div class="view-aadhar btn-view btn-view-pop" clientidmode="Static" runat="server" id="DivAadhar" style="display: none">
                                                <i class="bi bi-eye"></i>View Aadhar Card 
                                            </div>
                                        </div>
                                        <div class="col-sm-4 col-xl-3 pt-3">
                                            <div class="input-icon input-icon-sm right">
                                                <label>PAN Card Copy <span class="text-danger">*</span></label>
                                                <i class="bi bi-card-image b5-icon"></i>
                                                <asp:FileUpload ID="FluploadPan" ClientIDMode="Static" class="form-control input-sm file-upload" autocomplete="off" runat="server" accept=".pdf, .jpeg, .jpg, .png" />
                                                <span class="handle-file-request">(upload max file size,doc-800 KB/image-500 KB)</span>
                                                <asp:HiddenField ID="hdnApplicantPAN" runat="server" />
                                            </div>
                                            <span class="error">
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator22" Display="Dynamic" runat="server" ControlToValidate="FluploadPan" ValidationGroup="CusVal" ErrorMessage="Upload PAN card copy"></asp:RequiredFieldValidator>
                                            </span>
                                            <span class="error">
                                                <asp:Label ID="lblFluploadPan" ClientIDMode="Static" CssClass="lblFluploadPan error-label" runat="server" Text="">
                                                </asp:Label>
                                            </span>
                                            <div class="view-pan btn-view btn-view-pop" runat="server" clientidmode="Static" id="DivPan" style="display: none">
                                                <i class="bi bi-eye"></i>View PAN Card 
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div class="form-group">
                                <div class="form-border margin-top20">
                                    <div class="form-title">
                                        <h3>Co-Applicant Details </h3>
                                    </div>
                                    <div class="row mx-0 margin-top20 mb-4">
                                        <div class="col-sm-4 col-xl-3 pt-3">
                                            <div class="input-icon input-icon-sm right">
                                                <label>First Name <span class="text-danger">*</span></label>
                                                <i class="bi bi-person-fill b5-icon"></i>
                                                <asp:TextBox ID="txtCoapplicantFirstName" class="form-control input-sm capitalize-input" MaxLength="50" runat="server"></asp:TextBox>
                                            </div>
                                            <span class="error">
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" Display="Dynamic" runat="server" ControlToValidate="txtCoapplicantFirstName" ValidationGroup="CusVal" ErrorMessage="Enter first name"></asp:RequiredFieldValidator>
                                                <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ControlToValidate="txtCoapplicantFirstName" ValidationGroup="CusVal"
                                                    ValidationExpression="^[A-Za-z ]+(\.)?$" ErrorMessage="Enter valid first name" Display="Dynamic"></asp:RegularExpressionValidator>
                                            </span>

                                        </div>

                                        <div class="col-sm-4 col-xl-3 pt-3">
                                            <div class="input-icon input-icon-sm right">
                                                <label>Last Name </label>
                                                <i class="bi bi-person-video2 b5-icon"></i>
                                                <asp:TextBox ID="txtCoapplicantLastName" class="form-control input-sm capitalize-input" MaxLength="50" runat="server"></asp:TextBox>

                                            </div>
                                            <span class="error">
                                                <asp:RegularExpressionValidator ID="RegularExpressionValidator4" runat="server" ControlToValidate="txtCoapplicantLastName" ValidationGroup="CusVal"
                                                    ValidationExpression="^[A-Za-z ]+(\.)?$" ErrorMessage="Enter valid last name" Display="Dynamic"></asp:RegularExpressionValidator>
                                            </span>
                                        </div>
                                        <div class="col-sm-4 col-xl-2 pt-3">
                                            <div class="input-icon input-icon-sm right">
                                                <label>Gender <span class="text-danger">*</span></label>
                                                <i class="bi bi-gender-female b5-icon"></i>

                                                <asp:DropDownList ID="ddlCoGender" CssClass="bs-select form-control input-sm" runat="server">
                                                    <asp:ListItem Value=""> </asp:ListItem>
                                                    <asp:ListItem Value="Male">Male</asp:ListItem>
                                                    <asp:ListItem Value="Female">Female</asp:ListItem>
                                                    <asp:ListItem Value="Other">Other</asp:ListItem>
                                                </asp:DropDownList>

                                            </div>
                                            <span class="error">
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator30" Display="Dynamic" runat="server" InitialValue="" ControlToValidate="ddlCoGender" ValidationGroup="CusVal" ErrorMessage="Select gender"></asp:RequiredFieldValidator>

                                            </span>
                                        </div>
                                        <div class="col-sm-4 col-xl-2 pt-3">
                                            <div class="input-icon input-icon-sm right">
                                                <label>Date of Birth <span class="text-danger">*</span></label>
                                                <i class="bi bi-calendar-week b5-icon"></i>
                                                <asp:TextBox ID="txtCoDOB" ClientIDMode="Static" class="form-control input-sm" runat="server"></asp:TextBox>
                                            </div>
                                            <span class="error">
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator32" Display="Dynamic" runat="server" ControlToValidate="txtCoDOB" ValidationGroup="CusVal" ErrorMessage="Select date of birth"></asp:RequiredFieldValidator>
                                            </span>
                                        </div>

                                        <div class="col-sm-4 col-xl-3 pt-3">
                                            <div class="input-icon input-icon-sm right">
                                                <label>Email ID <span class="text-danger">*</span></label>
                                                <i class="bi bi-envelope b5-icon"></i>
                                                <asp:TextBox ID="txtCoaEmailID" class="form-control input-sm" MaxLength="50" runat="server"></asp:TextBox>

                                            </div>
                                            <span class="error">
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator33" Display="Dynamic" runat="server" ControlToValidate="txtCoaEmailID" ValidationGroup="CusVal" ErrorMessage="Enter email id"></asp:RequiredFieldValidator>
                                                <asp:RegularExpressionValidator ID="RegularExpressionValidator19" runat="server" ControlToValidate="txtCoaEmailID" ValidationGroup="CusVal"
                                                    ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" ErrorMessage="Enter valid emailid" Display="Dynamic"></asp:RegularExpressionValidator>

                                            </span>
                                        </div>

                                        <div class="col-sm-4 col-xl-2 pt-3">
                                            <div class="input-icon input-icon-sm right">
                                                <label>Mobile Number 1 <span class="text-danger">*</span></label>
                                                <i class="bi bi-telephone-fill b5-icon"></i>
                                                <asp:TextBox ID="txtcoatxtmobilenumber1" MaxLength="10" ClientIDMode="Static" class="form-control input-sm" runat="server"></asp:TextBox>
                                            </div>
                                            <span class="error">
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator34" Display="Dynamic" runat="server" ControlToValidate="txtcoatxtmobilenumber1" ValidationGroup="CusVal" ErrorMessage="Enter mobile no."></asp:RequiredFieldValidator>
                                                <asp:RegularExpressionValidator ID="RegularExpressionValidator21" runat="server" ControlToValidate="txtcoatxtmobilenumber1" ValidationGroup="CusVal"
                                                    ValidationExpression="^(?![0-5])\d{10}$" ErrorMessage="Enter valid mobile no." Display="Dynamic"></asp:RegularExpressionValidator>
                                            </span>
                                            <span class="handle-file-request">
                                                <asp:CheckBox ID="chkSameasWhatsapp1" runat="server" ClientIDMode="Static" onclick="callcoFunction();" />
                                                The mobile number is the same as the WhatsApp number  </span>
                                        </div>
                                        <div class="col-sm-4 col-xl-2 pt-3">
                                            <div class="input-icon input-icon-sm right">
                                                <label>Mobile Number 2 <span class="text-danger">*</span></label>
                                                <i class="bi bi-telephone-fill b5-icon"></i>
                                                <asp:TextBox ID="txtcoatxtmobilenumber2" MaxLength="10" ClientIDMode="Static" class="form-control input-sm" runat="server"></asp:TextBox>
                                            </div>
                                            <span class="error">
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator346" Display="Dynamic" runat="server" ControlToValidate="txtcoatxtmobilenumber2" ValidationGroup="CusVal" ErrorMessage="Enter mobile no."></asp:RequiredFieldValidator>
                                                <asp:RegularExpressionValidator ID="RegularExpressionValidator211" runat="server" ControlToValidate="txtcoatxtmobilenumber2" ValidationGroup="CusVal"
                                                    ValidationExpression="^(?![0-5])\d{10}$" ErrorMessage="Enter valid mobile no." Display="Dynamic"></asp:RegularExpressionValidator>
                                            </span>

                                        </div>


                                        <div class="col-sm-4 col-xl-2 pt-3">
                                            <div class="input-icon input-icon-sm right">
                                                <label>WhatsApp Number <span class="text-danger">*</span></label>
                                                <i class="bi bi-whatsapp b5-icon"></i>
                                                <asp:TextBox ID="txtCoaWhatsappNo" MaxLength="10" ClientIDMode="Static" class="form-control input-sm" runat="server"></asp:TextBox>

                                            </div>
                                            <span class="error">
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator35" Display="Dynamic" runat="server" ControlToValidate="txtCoaWhatsappNo" ValidationGroup="CusVal" ErrorMessage="Enter whatsapp no."></asp:RequiredFieldValidator>
                                                <asp:RegularExpressionValidator ID="RegularExpressionValidator22" runat="server" ControlToValidate="txtCoaWhatsappNo" ValidationGroup="CusVal"
                                                    ValidationExpression="^(?![0-5])\d{10}$" ErrorMessage="Enter valid whatsapp no." Display="Dynamic"></asp:RegularExpressionValidator>
                                            </span>
                                        </div>

                                        <div class="col-sm-4 col-xl-4 pt-3">
                                            <div class="input-icon input-icon-sm right">
                                                <label>Address <span class="text-danger">*</span></label>
                                                <i class="bi bi-geo-fill b5-icon"></i>
                                                <asp:TextBox ID="txtcoaAddress" MaxLength="95" class="form-control capitalize-input" TextMode="MultiLine" Rows="1" cols="50" runat="server"></asp:TextBox>
                                            </div>
                                            <span class="error">
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator36" Display="Dynamic" runat="server" ControlToValidate="txtcoaAddress" ValidationGroup="CusVal" ErrorMessage="Enter address"></asp:RequiredFieldValidator>
                                                <asp:RegularExpressionValidator ID="RegularExpressionValidator23" runat="server" ControlToValidate="txtcoaAddress" ValidationGroup="CusVal"
                                                    ValidationExpression="^[A-Za-z0-9\s,.\-#/']+$" ErrorMessage="Enter valid address" Display="Dynamic"></asp:RegularExpressionValidator>
                                            </span>
                                        </div>
                                        <div class="col-sm-4 col-xl-3 pt-3">
                                            <div class="input-icon input-icon-sm right">
                                                <label>Residential Status <span class="text-danger">*</span></label>
                                                <i class="bi bi-house-door b5-icon"></i>
                                                <asp:DropDownList ID="ddlCoaResidentialStatus" class="bs-select form-control input-sm" runat="server">
                                                    <asp:ListItem Selected="True" Value=""></asp:ListItem>
                                                    <asp:ListItem Value="Owned">Owned</asp:ListItem>
                                                    <asp:ListItem Value="Rented">Rented</asp:ListItem>
                                                    <asp:ListItem Value="Living with family">Living with family</asp:ListItem>
                                                </asp:DropDownList>
                                            </div>
                                            <span class="error">
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator37" Display="Dynamic" runat="server" InitialValue="" ControlToValidate="ddlCoaResidentialStatus" ValidationGroup="CusVal" ErrorMessage="Select residential status"></asp:RequiredFieldValidator>
                                            </span>
                                        </div>


                                        <div class="col-sm-4 col-xl-2 pt-3">
                                            <asp:UpdatePanel ID="UpdatePanel7" runat="server" RenderMode="Block" UpdateMode="Conditional" ChildrenAsTriggers="true">
                                                <ContentTemplate>
                                                    <div class="input-icon input-icon-sm right">
                                                        <label>State <span class="text-danger">*</span></label>
                                                        <i class="bi bi-globe-americas b5-icon"></i>
                                                        <asp:DropDownList ID="ddlCoState" AutoPostBack="true" OnSelectedIndexChanged="ddlCoState_SelectedIndexChanged" class="bs-select form-control input-sm" runat="server">
                                                            <asp:ListItem Selected="True"></asp:ListItem>
                                                        </asp:DropDownList>
                                                    </div>
                                                    <span class="error">
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator38" Display="Dynamic" runat="server" InitialValue="" ControlToValidate="ddlCoState" ValidationGroup="CusVal" ErrorMessage="Select state"></asp:RequiredFieldValidator>
                                                    </span>
                                                </ContentTemplate>
                                                <Triggers>
                                                    <asp:AsyncPostBackTrigger ControlID="ddlCoState" EventName="SelectedIndexChanged" />
                                                    <asp:AsyncPostBackTrigger ControlID="ddlCoaCity" EventName="SelectedIndexChanged" />
                                                </Triggers>
                                            </asp:UpdatePanel>
                                        </div>

                                        <div class="col-sm-4 col-xl-2 pt-3">
                                            <asp:UpdatePanel ID="UpdatePanel8" runat="server" RenderMode="Block" UpdateMode="Conditional" ChildrenAsTriggers="true">
                                                <ContentTemplate>
                                                    <div class="input-icon input-icon-sm right">
                                                        <label>City <span class="text-danger">*</span></label>
                                                        <i class="bi bi-buildings b5-icon"></i>
                                                        <asp:DropDownList ID="ddlCoaCity" class="bs-select form-control input-sm" runat="server">
                                                            <asp:ListItem Selected="True"></asp:ListItem>
                                                        </asp:DropDownList>
                                                    </div>
                                                    <span class="error">
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator39" Display="Dynamic" runat="server" InitialValue="" ControlToValidate="ddlCoaCity" ValidationGroup="CusVal" ErrorMessage="Select city"></asp:RequiredFieldValidator>
                                                    </span>
                                                </ContentTemplate>
                                                <Triggers>
                                                    <asp:AsyncPostBackTrigger ControlID="ddlCoState" EventName="SelectedIndexChanged" />
                                                    <asp:AsyncPostBackTrigger ControlID="ddlCoaCity" EventName="SelectedIndexChanged" />
                                                </Triggers>
                                            </asp:UpdatePanel>
                                        </div>
                                        <div class="col-sm-4 col-xl-2 pt-3">
                                            <div class="input-icon input-icon-sm right">
                                                <label>Postal Code <span class="text-danger">*</span></label>
                                                <i class="bi bi-mailbox b5-icon"></i>
                                                <asp:TextBox ID="txtCoaPincode" MaxLength="6" class="form-control input-sm" runat="server"></asp:TextBox>
                                            </div>
                                            <span class="error">
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator40" Display="Dynamic" runat="server" ControlToValidate="txtCoaPincode" ValidationGroup="CusVal" ErrorMessage="Enter postal code"></asp:RequiredFieldValidator>
                                                <asp:RegularExpressionValidator ClientIDMode="Static" ID="RegularExpressionValidator26" Display="Dynamic" runat="server" ValidationGroup="CusVal" ControlToValidate="txtCoaPincode" ValidationExpression="^\d{0,6}$" ErrorMessage="Enter valid postal code"></asp:RegularExpressionValidator>
                                            </span>
                                        </div>







                                        <div class="col-sm-4 col-xl-3 pt-3">
                                            <div class="input-icon input-icon-sm right">
                                                <label>Photo <span class="text-danger">*</span></label>
                                                <i class="bi bi-images b5-icon"></i>
                                                <asp:FileUpload ID="flPhoto2" ClientIDMode="Static" accept=".jpeg, .jpg, .png" class="form-control input-sm flPhoto2" runat="server" />
                                                <span class="handle-file-request">(upload max file size,doc-800 KB/image-500 KB)</span>
                                                <asp:HiddenField ID="hdnCoApplicantPhoto" runat="server" />
                                            </div>

                                            <span class="error">
                                                <asp:Label ID="lblflPhoto2" ClientIDMode="Static" CssClass="lblflPhoto2" runat="server" Text=""></asp:Label>
                                            </span>
                                            <span class="error">
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator24" Display="Dynamic" runat="server" ControlToValidate="flPhoto2" ValidationGroup="CusVal" ErrorMessage="Upload photo "></asp:RequiredFieldValidator>
                                            </span>
                                            <div class="view-pro-screen-img view-pro-screen btn-view-pop btn-view-Photo2" clientidmode="Static" runat="server" id="viewpflphoto2" style="display: none">
                                                <i class="bi bi-eye"></i>View Image
                                            </div>
                                        </div>


                                        <div class="col-sm-4 col-xl-3 pt-3">
                                            <div class="input-icon input-icon-sm right">
                                                <label>Aadhar Card Copy <span class="text-danger">*</span></label>
                                                <i class="bi bi-file-earmark-image b5-icon"></i>
                                                <asp:FileUpload ID="FluploadAadhar2" ClientIDMode="Static" class="form-control input-sm file-upload" autocomplete="off" runat="server" accept=".pdf, .jpeg, .jpg, .png" />
                                                <span class="handle-file-request">(upload max file size,doc-800 KB/image-500 KB)</span>
                                                <asp:HiddenField ID="hdnCoApplicantAadhar" runat="server" />
                                            </div>
                                            <span class="error">
                                                <asp:Label ID="lblFluploadAadhar2" ClientIDMode="Static" CssClass="lblFluploadAadhar2 error-label" runat="server" Text=""></asp:Label>
                                            </span>
                                            <span class="error">
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator25" Display="Dynamic" runat="server" ControlToValidate="FluploadAadhar2" ValidationGroup="CusVal" ErrorMessage="Upload aadhar card copy"></asp:RequiredFieldValidator>
                                            </span>
                                            <div class="view-aadhar btn-view btn-view-pop" clientidmode="Static" runat="server" id="divaadhar2" style="display: none">
                                                <i class="bi bi-eye"></i>View Aadhar Card
                                            </div>
                                        </div>


                                        <div class="col-sm-4 col-xl-3 pt-3">
                                            <div class="input-icon input-icon-sm right">
                                                <label>PAN Card Copy <span class="text-danger">*</span></label>
                                                <i class="bi bi-card-image b5-icon"></i>
                                                <asp:FileUpload ID="FluploadPan2" ClientIDMode="Static" class="form-control input-sm file-upload" autocomplete="off" runat="server" accept=".pdf, .jpeg, .jpg, .png" />
                                                <span class="handle-file-request">(upload max file size,doc-800 KB/image-500 KB)</span>
                                                <asp:HiddenField ID="hdnCoApplicantPAN" runat="server" />
                                            </div>
                                            <span class="error">
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator26" Display="Dynamic" runat="server" ControlToValidate="FluploadPan2" ValidationGroup="CusVal" ErrorMessage="Upload PAN card copy"></asp:RequiredFieldValidator>
                                            </span>
                                            <span class="error">
                                                <asp:Label ID="lblFluploadPan2" ClientIDMode="Static" CssClass="lblFluploadPan2 error-label" runat="server" Text="">
                                                </asp:Label>
                                            </span>
                                            <div class="view-pan btn-view btn-view-pop" runat="server" clientidmode="Static" id="divcoappliantpan" style="display: none">
                                                <i class="bi bi-eye"></i>View PAN Card
                                            </div>
                                        </div>

                                    </div>
                                </div>
                            </div>
                            <div class="form-group">
                                <div class="form-border margin-top20">
                                    <div class="form-title">
                                        <h3>Power of Attorney (Agent) </h3>
                                    </div>
                                    <div class="row mx-0 margin-top20 mb-4 px-0">
                                        <div class="col-sm-4 col-xl-3 pt-3">
                                            <div class="input-icon input-icon-sm right">
                                                <label>Agent Name </label>
                                                <i class="bi bi-person-check b5-icon"></i>
                                                <asp:TextBox ID="txtNamePowerofattorney" class="form-control input-sm capitalize-input" autocomplete="off" placeholder="" runat="server"></asp:TextBox>
                                            </div>
                                            <span class="error">
                                                <asp:RegularExpressionValidator ID="RegularExpressionValidator20" runat="server" ControlToValidate="txtNamePowerofattorney" ValidationGroup="CusVal"
                                                    ValidationExpression="^[A-Za-z ]+(\.)?$" ErrorMessage="Enter name" Display="Dynamic"></asp:RegularExpressionValidator>
                                            </span>
                                        </div>
                                        <div class="col-sm-4 col-xl-2 pt-3">
                                            <div class="input-icon input-icon-sm right">
                                                <label>Date of Birth </label>
                                                <i class="bi bi-calendar-week b5-icon"></i>
                                                <asp:TextBox ID="txtPAdate" ClientIDMode="Static" class="form-control input-sm " autocomplete="off" placeholder="" runat="server"></asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="col-sm-4 col-xl-3 pt-3">
                                            <div class="input-icon input-icon-sm right">
                                                <label>Aadhar Card Copy</label>
                                                <i class="bi bi-file-earmark-image b5-icon"></i>
                                                <asp:FileUpload ID="flPAAadhar" ClientIDMode="Static" class="form-control input-sm file-upload" autocomplete="off" runat="server" accept=".pdf, .jpeg, .jpg, .png" />
                                                <span class="handle-file-request">(upload max file size,doc-800 KB/image-500 KB)</span>
                                                <asp:HiddenField ID="hdnPAAadhar" runat="server" />
                                            </div>

                                            <span class="error">
                                                <asp:Label ID="lblflPAAadhar" ClientIDMode="Static" CssClass="lblflPAAadhar error-label" runat="server" Text=""></asp:Label>
                                            </span>
                                            <div class="view-aadhar btn-view btn-view-pop" clientidmode="Static" runat="server" id="divpaaadhar" style="display: none">
                                                <i class="bi bi-eye"></i>View Aadhar Card
                                            </div>
                                        </div>

                                        <div class="col-sm-4 col-xl-3 pt-3">
                                            <div class="input-icon input-icon-sm right">
                                                <label>PAN Card Copy</label>
                                                <i class="bi bi-card-image b5-icon"></i>
                                                <asp:FileUpload ID="fluPAPAN" ClientIDMode="Static" class="form-control input-sm file-upload" autocomplete="off" runat="server" accept=".pdf, .jpeg, .jpg, .png" />
                                                <span class="handle-file-request">(upload max file size,doc-800 KB/image-500 KB)</span>
                                                <asp:HiddenField ID="hdnPAPAN" runat="server" />
                                            </div>

                                            <span class="error">
                                                <asp:Label ID="lblfluPAPAN" ClientIDMode="Static" CssClass="lblfluPAPAN error-label" runat="server" Text="">
                                                </asp:Label>
                                            </span>
                                            <div class="view-pan btn-view btn-view-pop" clientidmode="Static" runat="server" id="divpapan" style="display: none">
                                                <i class="bi bi-eye"></i>View PAN Card
                                            </div>
                                        </div>

                                        <div class="col-sm-4 col-xl-4 pt-3">
                                            <div class="input-icon input-icon-sm right">
                                                <label>Address </label>
                                                <i class="bi bi-pin-map-fill b5-icon"></i>
                                                <asp:TextBox ID="txtaddresspowerofattorney" class="form-control input-sm capitalize-input" TextMode="MultiLine" Rows="1" cols="50" autocomplete="off" placeholder="" runat="server"></asp:TextBox>
                                            </div>
                                            <span class="error">
                                                <asp:RegularExpressionValidator ID="RegularExpressionValidator28" runat="server" ControlToValidate="txtaddresspowerofattorney" ValidationGroup="CusVal"
                                                    ValidationExpression="^[A-Za-z0-9\s,.\-#/']+$" ErrorMessage="Enter valid address" Display="Dynamic"></asp:RegularExpressionValidator>
                                            </span>
                                        </div>

                                    </div>
                                </div>
                            </div>
                            <div class="form-group">
                                <div class="form-border margin-top20">
                                    <div class="form-title">

                                        <h3>Flat Details </h3>
                                    </div>
                                    <div class="row mx-0 margin-top20 mb-4 px-0">

                                        <div class="col-sm-4 col-xl-3 pt-3">
                                            <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                                                <ContentTemplate>
                                                    <div class="input-icon input-icon-sm right">
                                                        <label>Project Name <span class="text-danger">*</span></label>
                                                        <i class="bi bi-journal-bookmark-fill b5-icon"></i>
                                                        <asp:DropDownList ID="ddlprojectname" ClientIDMode="Static" class="form-control input-sm capitalize-input" AutoPostBack="true" OnSelectedIndexChanged="ddlprojectname_SelectedIndexChanged" runat="server">
                                                            <asp:ListItem Selected="True"></asp:ListItem>
                                                            <asp:ListItem Value="" Text="Select"></asp:ListItem>
                                                        </asp:DropDownList>
                                                </ContentTemplate>
                                                <Triggers>
                                                    <asp:AsyncPostBackTrigger ControlID="ddlprojectname" EventName="SelectedIndexChanged" />
                                                </Triggers>
                                            </asp:UpdatePanel>
                                        </div>
                                        <span class="error">
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator28" Display="Dynamic" runat="server" InitialValue="" ControlToValidate="ddlprojectname" ValidationGroup="CusVal" ErrorMessage="Select project name"></asp:RequiredFieldValidator>
                                        </span>

                                    </div>


                                    <div class="col-sm-4 col-xl-3 pt-3">
                                        <asp:UpdatePanel ID="UpdatePanel4" runat="server" RenderMode="Block" UpdateMode="Conditional" ChildrenAsTriggers="true">
                                            <ContentTemplate>
                                                <div class="input-icon input-icon-sm right">
                                                    <label>Block Name <span class="text-danger">*</span></label>
                                                    <i class="bi bi-file-binary b5-icon"></i>

                                                    <asp:DropDownList ID="ddlblocknumber" ClientIDMode="Static" OnSelectedIndexChanged="ddlblocknumber_SelectedIndexChanged" AutoPostBack="true" class="form-control input-sm" runat="server">
                                                        <asp:ListItem Selected="True"></asp:ListItem>

                                                    </asp:DropDownList>

                                                </div>
                                                <span class="error">
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator29" Display="Dynamic" runat="server" InitialValue="" ControlToValidate="ddlblocknumber" ValidationGroup="CusVal" ErrorMessage="Select block name"></asp:RequiredFieldValidator>
                                                </span>
                                            </ContentTemplate>
                                            <Triggers>
                                                <asp:AsyncPostBackTrigger ControlID="ddlprojectname" EventName="SelectedIndexChanged" />
                                                <asp:AsyncPostBackTrigger ControlID="ddlblocknumber" EventName="SelectedIndexChanged" />
                                            </Triggers>
                                        </asp:UpdatePanel>
                                    </div>
                                    <div class="col-sm-4 col-xl-3 pt-3">
                                        <asp:UpdatePanel ID="UpdatePanel5" runat="server" UpdateMode="Conditional">
                                            <ContentTemplate>
                                                <div class="input-icon input-icon-sm right">
                                                    <label>Flat Number <span class="text-danger">*</span></label>
                                                    <i class="bi bi-building b5-icon"></i>
                                                    <asp:DropDownList ID="ddlflatNumber" ClientIDMode="Static" class="form-control input-sm" runat="server">
                                                        <asp:ListItem Selected="True"></asp:ListItem>
                                                    </asp:DropDownList>
                                                </div>
                                                <span class="error">
                                                    <asp:RequiredFieldValidator
                                                        ID="RequiredFieldValidator31"
                                                        Display="Dynamic"
                                                        runat="server"
                                                        InitialValue=""
                                                        ControlToValidate="ddlflatNumber"
                                                        ValidationGroup="CusVal"
                                                        ErrorMessage="Select flat no.">
                                                    </asp:RequiredFieldValidator>
                                                </span>
                                            </ContentTemplate>
                                            <Triggers>
                                                <asp:AsyncPostBackTrigger ControlID="ddlprojectname" EventName="SelectedIndexChanged" />
                                                <asp:AsyncPostBackTrigger ControlID="ddlblocknumber" EventName="SelectedIndexChanged" />
                                                <asp:AsyncPostBackTrigger ControlID="ddlflatNumber" EventName="SelectedIndexChanged" />

                                            </Triggers>
                                        </asp:UpdatePanel>
                                    </div>
                                    <div class="col-sm-4 col-xl-3 pt-3 " style="display: none">
                                        <div class="input-icon input-icon-sm right">
                                            <label>Customised Floor Plan </label>
                                            <i class="bi bi-card-heading b5-icon"></i>
                                            <asp:TextBox ID="txtcustomisedfloorplan" class="form-control input-sm" runat="server"></asp:TextBox>

                                        </div>
                                        <span class="error"></span>
                                    </div>
                                </div>
                                <asp:UpdatePanel ID="UpdatePanel6" runat="server" RenderMode="Block" UpdateMode="Conditional" ChildrenAsTriggers="true">
                                    <ContentTemplate>
                                        <div class="align-items-center text-center" id="projectValidationMessage"></div>
                                    </ContentTemplate>
                                    <Triggers>
                                        <asp:AsyncPostBackTrigger ControlID="ddlprojectname" EventName="SelectedIndexChanged" />
                                        <asp:AsyncPostBackTrigger ControlID="ddlblocknumber" EventName="SelectedIndexChanged" />
                                    </Triggers>
                                </asp:UpdatePanel>
                            </div>
                            <div class="form-group">
                                <div class="form-border margin-top20">
                                    <div class="form-title">
                                        <h3>Relationship Manager Details </h3>
                                    </div>
                                    <div class="row mx-0 margin-top20 mb-4">
                                        <div class="col-sm-4 col-xl-3 pt-3">
                                            <div class="input-icon input-icon-sm right">
                                                <label>Name  <span class="text-danger">*</span></label>
                                                <i class="bi bi-clipboard2-data b5-icon"></i>
                                                <asp:DropDownList ID="ddlcrmname" class="form-control input-sm" runat="server">
                                                    <asp:ListItem Value=""></asp:ListItem>
                                                </asp:DropDownList>
                                            </div>
                                            <span class="error">
                                                <asp:RequiredFieldValidator
                                                    ID="RequiredFieldValidator27"
                                                    Display="Dynamic"
                                                    runat="server"
                                                    InitialValue=""
                                                    ControlToValidate="ddlcrmname"
                                                    ValidationGroup="CusVal"
                                                    ErrorMessage="Select CRM name no.">
                                                </asp:RequiredFieldValidator>
                                            </span>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="form-group">
                            <div class="form-border margin-top20">
                                <div class="form-title">
                                    <h3>Booking Details </h3>
                                </div>
                                <div class="row mx-0 margin-top20 mb-4 px-0">
                                    <div class="col-sm-4 col-xl-2 pt-3">
                                        <div class="input-icon input-icon-sm right">
                                            <label>Booking Date </label>
                                            <i class="bi bi-calendar-check b5-icon"></i>
                                            <asp:TextBox ID="txtBookingdate" ClientIDMode="Static" class="form-control input-sm" runat="server"></asp:TextBox>

                                        </div>
                                    </div>

                                    <div class="col-sm-4 col-xl-3 pt-3">
                                        <div class="input-icon input-icon-sm right">
                                            <label>Amount Paid </label>
                                            <i class="bi bi-cash-stack b5-icon"></i>
                                            <asp:TextBox ID="txtamountpaid" MaxLength="10" Text="₹" onfocus="addCurrencySymbol(this)" onkeyup="keyup(this.id,'lblamount')" class="form-control input-sm" runat="server"></asp:TextBox>
                                            <span class="handle-file-request">
                                                <asp:Label ID="lblamount" ClientIDMode="static" runat="server"></asp:Label>
                                            </span>
                                        </div>
                                        <span class="error">
                                            <%--                                            <asp:RegularExpressionValidator ID="RegularFieldValidator1" runat="server" ControlToValidate="txtamountpaid" ValidationGroup="CusVal" ValidationExpression="^(\u20B9|\₹)\d{5,}$" ErrorMessage="Enter a minimum amount of ₹10000" Display="Dynamic"></asp:RegularExpressionValidator>--%>
                                        </span>
                                    </div>
                                    <div class="col-sm-4 col-xl-2 pt-3">
                                        <div class="input-icon input-icon-sm right">
                                            <label>Payment Mode </label>
                                            <i class="bi bi-wallet b5-icon"></i>

                                            <asp:DropDownList ID="ddlpaymentmode" class="form-control input-sm" runat="server">
                                                <asp:ListItem Text="" Value="" />
                                                <asp:ListItem Text="Credit Card" Value="1" />
                                                <asp:ListItem Text="Debit Card" Value="2" />
                                                <asp:ListItem Text="Net Banking" Value="3" />
                                                <asp:ListItem Text="UPI" Value="4" />
                                                <asp:ListItem Text="Wallets" Value="5" />
                                                <asp:ListItem Text="Cash" Value="6" />
                                                <asp:ListItem Text="Cheque" Value="7" />
                                                <asp:ListItem Text="Demand Draft" Value="8" />
                                                <asp:ListItem Text="NEFT" Value="9" />
                                                <asp:ListItem Text="RTGS" Value="10" />
                                                <asp:ListItem Text="IMPS" Value="11" />

                                            </asp:DropDownList>
                                        </div>

                                    </div>

                                    <div class="col-sm-4 col-xl-3 pt-3">
                                        <div class="input-icon input-icon-sm right">
                                            <label>Booking Acknowledgement </label>
                                            <i class="bi bi-calendar2-check b5-icon"></i>
                                            <asp:FileUpload ID="fluBookingAcknowledgement" ClientIDMode="Static" class="form-control input-sm file-upload" autocomplete="off" runat="server" accept=".pdf, .jpeg, .jpg, .png" />
                                            <span class="handle-file-request">(upload max file size,doc-800 KB/image-500 KB)</span>
                                            <asp:HiddenField ID="hdnBookingknowledgement" runat="server" />
                                        </div>

                                        <span class="error">
                                            <asp:Label ID="lblfluBookingAcknowledgement" ClientIDMode="Static" CssClass="lblfluBookingAcknowledgement error-label" runat="server" Text=""></asp:Label>
                                        </span>

                                        <div class="view-aadhar btn-view btn-view-pop" clientidmode="Static" runat="server" id="div1" style="display: none">
                                            <i class="bi bi-eye"></i>View 
                                        </div>
                                    </div>

                                </div>
                            </div>
                        </div>
                        <asp:HiddenField ID="hdncustomerID" runat="server" />
                        <div class="form-group">
                            <div class="form-border margin-top20">
                                <div class="form-title">

                                    <h3>Car Park Details </h3>
                                </div>
                                <div class="row mx-0 margin-top20 mb-4 px-0">
                                    <div class="ccol-sm-4 col-xl-3 pt-3">
                                        <div class="input-icon input-icon-sm right">
                                            <label>Car Park Allotted </label>
                                            <i class="bi bi-check2-square b5-icon"></i>
                                            <asp:DropDownList ID="ddlcarparkallotted" ClientIDMode="Static" class="form-control input-sm" runat="server" onchange="toggleSlotsVisibility(this)">
                                                <asp:ListItem Value=""></asp:ListItem>
                                                <asp:ListItem Value="1">Yes</asp:ListItem>
                                                <asp:ListItem Value="0">No</asp:ListItem>
                                            </asp:DropDownList>
                                        </div>
                                    </div>

                                    <div class="col-sm-4 col-xl-2 pt-3 handle-click-yes" style="display: none;">
                                        <div class="input-icon input-icon-sm right">
                                            <label>No. of Slots </label>
                                            <i class="bi bi-list-ol b5-icon"></i>
                                            <asp:TextBox ID="txtnoofslots" MaxLength="2" onkeyup="toggleSlotsVisibility(this)" ClientIDMode="Static" class="form-control input-sm" runat="server"></asp:TextBox>
                                            <asp:Label ID="lblerror" runat="server" class="errorLabel" ForeColor="#D41111" Text=""></asp:Label>
                                        </div>
                                        <span class="error">
                                            <asp:RegularExpressionValidator ID="RegularExpressionValidator24" runat="server" ControlToValidate="txtnoofslots" ValidationGroup="CusVal" ValidationExpression="^\d+$" ErrorMessage="Enter valid no.of slots" Display="Dynamic"></asp:RegularExpressionValidator>
                                        </span>
                                    </div>
                                    <div class="col-sm-4 col-xl-2 pt-3 handle-click-yes" style="display: none;">
                                        <div class="input-icon input-icon-sm right">
                                            <label>Car Parking Slot 1 </label>
                                            <i class="bi bi-car-front b5-icon"></i>

                                            <asp:TextBox ID="txtallottedcarparkslotnumber1" MaxLength="12" ClientIDMode="Static" class="form-control input-sm" runat="server"></asp:TextBox>
                                        </div>
                                        <span class="error">
                                            <asp:RegularExpressionValidator ID="RegularExpressionValidator296" runat="server" ControlToValidate="txtallottedcarparkslotnumber1" ValidationGroup="CusVal" ValidationExpression="^[A-Za-z0-9\-,]+$" ErrorMessage="Enter valid allotted car park slot no." Display="Dynamic"></asp:RegularExpressionValidator>
                                        </span>
                                    </div>
                                    <div class="col-sm-4 col-xl-2 pt-3 handle-click-yes" style="display: none;">
                                        <div class="input-icon input-icon-sm right">
                                            <label>Car Parking Slot 1 </label>
                                            <i class="bi bi-car-front b5-icon"></i>

                                            <asp:TextBox ID="txtallottedcarparkslotnumber2" MaxLength="12" ClientIDMode="Static" class="form-control input-sm" runat="server"></asp:TextBox>
                                        </div>
                                        <span class="error">
                                            <asp:RegularExpressionValidator ID="RegularExpressionValidator291" runat="server" ControlToValidate="txtallottedcarparkslotnumber2" ValidationGroup="CusVal" ValidationExpression="^[A-Za-z0-9\-,]+$" ErrorMessage="Enter valid allotted car park slot no." Display="Dynamic"></asp:RegularExpressionValidator>
                                        </span>
                                    </div>
                                    <div class="col-sm-4 col-xl-2 pt-3 handle-click-yes" style="display: none;">
                                        <div class="input-icon input-icon-sm right">
                                            <label>Car Parking Slot 1 </label>
                                            <i class="bi bi-car-front b5-icon"></i>
                                            <asp:TextBox ID="txtallottedcarparkslotnumber3" MaxLength="12" ClientIDMode="Static" class="form-control input-sm" runat="server"></asp:TextBox>
                                        </div>
                                        <span class="error">
                                            <asp:RegularExpressionValidator ID="RegularExpressionValidator25" runat="server" ControlToValidate="txtallottedcarparkslotnumber3" ValidationGroup="CusVal" ValidationExpression="^[A-Za-z0-9\-,]+$" ErrorMessage="Enter valid allotted car park slot no." Display="Dynamic"></asp:RegularExpressionValidator>
                                        </span>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="form-group">
                            <div class="form-border margin-top20">
                                <div class="form-title">
                                    <h3>Flat Registration Details </h3>
                                </div>
                                <div class="row mx-0 margin-top20 mb-4 px-0">
                                    <div class="col-sm-4 col-xl-3 pt-3">
                                        <div class="input-icon input-icon-sm right">
                                            <label>Registration Charges</label>
                                            <i class="bi bi-cash b5-icon"></i>
                                            <asp:TextBox ID="txtregistrationcharges" Text="₹" MaxLength="10" onfocus="addedCurrencySymbol(this)" onkeyup="keyup(this.id,'lblregistrationcharges')" class="form-control input-sm" runat="server"></asp:TextBox>
                                            <span class="handle-file-request">
                                                <asp:Label ID="lblregistrationcharges" ClientIDMode="static" runat="server"></asp:Label>
                                            </span>
                                        </div>
                                        <span class="error">
                                            <%--                                            <asp:RegularExpressionValidator ID="RegularExpressionValidator26" runat="server" ControlToValidate="txtregistrationcharges" ValidationGroup="CusVal" ValidationExpression="^(\u20B9|\₹)\d{5,}$" ErrorMessage="Enter a minimum amount of ₹10000" Display="Dynamic"></asp:RegularExpressionValidator>--%>
                                        </span>
                                    </div>

                                    <div class="col-sm-4 col-xl-3 pt-3">
                                        <div class="input-icon input-icon-sm right">
                                            <label>Registration Date </label>
                                            <i class="bi bi-calendar2-plus b5-icon"></i>
                                            <asp:TextBox ID="txtRegistrationdate" ClientIDMode="Static" class="form-control input-sm" runat="server"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="col-sm-4 col-xl-3 pt-3">
                                        <div class="input-icon input-icon-sm right">
                                            <label>Registration Office</label>
                                            <i class="bi bi-hospital b5-icon"></i>
                                            <asp:TextBox ID="txtregistrationoffice" class="form-control input-sm capitalize-input" runat="server"></asp:TextBox>
                                        </div>
                                        <span class="error">
                                            <asp:RegularExpressionValidator ID="RegularExpressionValidator27" runat="server" ControlToValidate="txtregistrationoffice" ValidationGroup="CusVal" ValidationExpression="^[A-Za-z0-9\s,.\-/'&]+$" ErrorMessage="Enter valid registration office" Display="Dynamic"></asp:RegularExpressionValidator>
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
                                runat="server" OnClick="btnSave_Click1"
                                Text="Submit" ValidationGroup="CusVal"
                                class="btn btn-sm handle-btn-success me-1 swtAltSubmit btnSave"
                                OnClientClick="if (validatePage()) { this.value='Please wait..'; this.style.display='none'; document.getElementById('bWait').style.display = ''; } else { return false; }" Style="min-width: 67px;" />
                            <button type="button" style="display: none" id="bWait" class="btn btn-secondary btn-sm me-1"><i class='fa fa-spinner fa-spin'></i>Please wait</button>
                            <div class="btn btn-sm handle-btn-danger swtAltCancel">Cancel</div>
                            <asp:Button ID="btnCancel" OnClick="btnCancel_Click" runat="server" Text="Cancel Project" Style="display: none;" />
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

    <script src="https://cdnjs.cloudflare.com/ajax/libs/pdf.js/2.10.377/pdf.min.js"></script>
    <script src="https://cdn.jsdelivr.net/npm/sweetalert2@11"></script>
    <!-- jQuery library -->
    <script src="assets/js/core/jquery.3.2.1.min.js"></script>
    <!-- Date Picker -->
    <script src="assets/js/dtsel.js"></script>

    <script>
        var inputField1 = document.getElementById("txtBookingdate");
        inputField1.addEventListener("keydown", function (event) {
            event.preventDefault();
        });
        var inputField1 = document.getElementById("txtPAdate");
        inputField1.addEventListener("keydown", function (event) {
            event.preventDefault();
        });
        var inputField1 = document.getElementById("txtdateofbirth");
        inputField1.addEventListener("keydown", function (event) {
            event.preventDefault();
        });
        var inputField1 = document.getElementById("txtRegistrationdate");
        inputField1.addEventListener("keydown", function (event) {
            event.preventDefault();
        });
        var inputField1 = document.getElementById("txtCoDOB");
        inputField1.addEventListener("keydown", function (event) {
            event.preventDefault();
        });
    </script>
    <script>
        function callFunction() {
            // JavaScript logic for checkbox click
            const checkbox = document.getElementById('chkSameaswhatsapp');
            const chkSameasWhatsapp1 = document.getElementById('chkSameasWhatsapp1');
            const txtmobilenumber1 = document.getElementById('txtmobilenumber1').value;
            const txtcoatxtmobilenumber1 = document.getElementById('txtcoatxtmobilenumber1').value;
            // alert(txtmobilenumber1);
            const txtwhatsappnumber = document.getElementById('txtwhatsappnumber');
            const txtCoaWhatsappNo = document.getElementById('txtCoaWhatsappNo');
            if (checkbox.checked) {
                if (txtmobilenumber1.trim() !== '') {
                    // alert("it not empty");
                    txtwhatsappnumber.value = txtmobilenumber1;
                }
                else {
                    txtwhatsappnumber.value = '';
                }
            }
            else {
                txtwhatsappnumber.value = '';
            }
        }
    </script>
    <script>
        function callcoFunction() {
            const chkSameasWhatsapp1 = document.getElementById('chkSameasWhatsapp1');
            const txtcoatxtmobilenumber1 = document.getElementById('txtcoatxtmobilenumber1').value;
            const txtCoaWhatsappNo = document.getElementById('txtCoaWhatsappNo');


            if (chkSameasWhatsapp1.checked) {
                if (txtcoatxtmobilenumber1.trim() !== '') {
                    // alert("it not empty");
                    txtCoaWhatsappNo.value = txtcoatxtmobilenumber1;
                }
                else {
                    txtCoaWhatsappNo.value = '';
                }
            }
            else {
                txtCoaWhatsappNo.value = '';
            }


        }

    </script>

    <script>
        document.addEventListener('DOMContentLoaded', function () {
            //-- date picker
            const datePickerOptions = {
                showTime: false,
                showDate: true,
                dateFormat: "dd-mm-yyyy"
            };

            new dtsel.DTS('input[id="txtBookingdate"]', datePickerOptions);
            new dtsel.DTS('input[id="txtCoDOB"]', datePickerOptions);
            new dtsel.DTS('input[id="txtPAdate"]', datePickerOptions);
            new dtsel.DTS('input[id="txtdateofbirth"]', datePickerOptions);
            new dtsel.DTS('input[id="txtRegistrationdate"]', datePickerOptions);
        });
    </script>
    <script type="text/javascript">
        Sys.Application.add_load(function () {
            // Get the dropdown and label elements
            var ddlLeadSource = document.getElementById('<%= ddlLeadSource.ClientID %>');
            var divreferenceby = document.getElementById('<%= divreferenceby.ClientID %>');

            // Attach onchange event for flat number dropdown
            ddlLeadSource.onchange = function () {
                // alert(ddlLeadSource.value);
                if (ddlLeadSource.value == '10') {
                    divreferenceby.style.display = 'Block';
                }
                else {
                    divreferenceby.style.display = 'none';
                    document.getElementById('ddlReference').selectedIndex = 0;
                    document.getElementById('DivRef1').style.display = 'none';

                }
            }
        });
    </script>
    <script type="text/javascript">
        Sys.Application.add_load(function () {
            // Get the dropdown and label elements
            var ddlReference = document.getElementById('<%= ddlReference.ClientID %>');
            var DivRef1 = document.getElementById('<%= DivRef1.ClientID %>');

            // Attach onchange event for ddlReference dropdown
            ddlReference.onchange = function () {
                // Check if value is not empty
                if (ddlReference.value != '') {
                    DivRef1.style.display = 'Block';
                }
                else {
                    DivRef1.style.display = 'none';
                    // Reset the selected index to 0 (no selection)
                    ddlReference.selectedIndex = 0;
                }
            }

            ddlReference.onchange();
        });
    </script>
    <script> 
        document.getElementById('<%= txtapplicationname.ClientID %>').addEventListener('keypress', function (e) {
            if (!/^[A-Za-z ]+(\.)?$/.test(e.key)) {
                e.preventDefault();
            }
        });
        document.getElementById('<%= txtapplicationlastname.ClientID %>').addEventListener('keypress', function (e) {
            if (!/^[A-Za-z ]+(\.)?$/.test(e.key)) {
                e.preventDefault();
            }
        });
        document.getElementById('<%= txtCoapplicantFirstName.ClientID %>').addEventListener('keypress', function (e) {
            if (!/^[A-Za-z ]+(\.)?$/.test(e.key)) {
                e.preventDefault();
            }
        });
        document.getElementById('<%= txtCoapplicantLastName.ClientID %>').addEventListener('keypress', function (e) {
            if (!/^[A-Za-z ]+(\.)?$/.test(e.key)) {
                e.preventDefault();
            }
        });
        document.getElementById('<%= txtCoapplicantLastName.ClientID %>').addEventListener('keypress', function (e) {
            if (!/^[A-Za-z ]+(\.)?$/.test(e.key)) {
                e.preventDefault();
            }
        });
        document.getElementById('<%= txtFatherORSpouseName.ClientID %>').addEventListener('keypress', function (e) {
            if (!/^[A-Za-z ]+(\.)?$/.test(e.key)) {
                e.preventDefault();
            }
        });
        document.getElementById('<%= txtmobilenumber1.ClientID %>').addEventListener('keypress', function (e) {
            if (!/^\d+$/.test(e.key)) {
                e.preventDefault();
            }
        });
        document.getElementById('<%= txtmobilenumber2.ClientID %>').addEventListener('keypress', function (e) {
            if (!/^\d+$/.test(e.key)) {
                e.preventDefault();
            }
        });
        document.getElementById('<%= txtwhatsappnumber.ClientID %>').addEventListener('keypress', function (e) {
            if (!/^\d+$/.test(e.key)) {
                e.preventDefault();
            }
        });
        document.getElementById('<%= txtcoatxtmobilenumber1.ClientID %>').addEventListener('keypress', function (e) {
            if (!/^\d+$/.test(e.key)) {
                e.preventDefault();
            }
        });
        document.getElementById('<%= txtcoatxtmobilenumber2.ClientID %>').addEventListener('keypress', function (e) {
            if (!/^\d+$/.test(e.key)) {
                e.preventDefault();
            }
        });
        document.getElementById('<%= txtCoaWhatsappNo.ClientID %>').addEventListener('keypress', function (e) {
            if (!/^\d+$/.test(e.key)) {
                e.preventDefault();
            }
        });
        document.getElementById('<%= txtprofession.ClientID %>').addEventListener('keypress', function (e) {
            if (!/^[A-Za-z ]+(\.)?$/.test(e.key)) {
                e.preventDefault();
            }
        });
        document.getElementById('<%= txtcompanyname.ClientID %>').addEventListener('keypress', function (e) {
            if (!/^[A-Za-z0-9 &\-,.'/()#]+$/.test(e.key)) {
                e.preventDefault();
            }
        });
        document.getElementById('<%= txtDesignation.ClientID %>').addEventListener('keypress', function (e) {
            if (!/^[A-Za-z\s&\-.',/]+$/.test(e.key)) {
                e.preventDefault();
            }
        });
      <%--  document.getElementById('<%= txtRelationshipwithcoapplicant.ClientID %>').addEventListener('keypress', function (e) {
            if (!/^[A-Za-z\s\-'&]+(?<!\.)$/.test(e.key)) {
                e.preventDefault();
            }
        });--%>
        document.getElementById('<%= txtCurrentResidingAddress.ClientID %>').addEventListener('keypress', function (e) {
            if (!/^[A-Za-z0-9\s,.\-#/']+$/.test(e.key)) {
                e.preventDefault();
            }
        });
        document.getElementById('<%= txtPermanentAddress.ClientID %>').addEventListener('keypress', function (e) {
            if (!/^[A-Za-z0-9\s,.\-#/']+$/.test(e.key)) {
                e.preventDefault();
            }
        });
        document.getElementById('<%= txtcoaAddress.ClientID %>').addEventListener('keypress', function (e) {
            if (!/^[A-Za-z0-9\s,.\-#/']+$/.test(e.key)) {
                e.preventDefault();
            }
        });
        document.getElementById('<%= txtpostalcode.ClientID %>').addEventListener('keypress', function (e) {
            if (!/^\d$/.test(e.key) || this.value.length >= 6) {
                e.preventDefault();
            }
        });
        document.getElementById('<%= txtCoaPincode.ClientID %>').addEventListener('keypress', function (e) {
            if (!/^\d$/.test(e.key) || this.value.length >= 6) {
                e.preventDefault();
            }
        });
        document.getElementById('<%= txtreference1.ClientID %>').addEventListener('keypress', function (e) {
            if (!/^[A-Za-z0-9 ]+(\.)?$/.test(e.key)) {
                e.preventDefault();
            }
        });
        document.getElementById('<%= txtreference2.ClientID %>').addEventListener('keypress', function (e) {
            if (!/^[A-Za-z ]+(\.)?$/.test(e.key)) {
                e.preventDefault();
            }
        });
        document.getElementById('<%= txtNamePowerofattorney.ClientID %>').addEventListener('keypress', function (e) {
            if (!/^[A-Za-z ]+(\.)?$/.test(e.key)) {
                e.preventDefault();
            }
        });
        document.getElementById('<%= txtaddresspowerofattorney.ClientID %>').addEventListener('keypress', function (e) {
            if (!/^[A-Za-z0-9\s,.\-#/']+$/.test(e.key)) {
                e.preventDefault();
            }
        });
        document.getElementById('<%= txtcustomisedfloorplan.ClientID %>').addEventListener('keypress', function (e) {
            if (!/^[A-Za-z0-9\s,.\-/'&]+$/.test(e.key)) {
                e.preventDefault();
            }
        });
        document.getElementById('<%= txtcustomisedfloorplan.ClientID %>').addEventListener('keypress', function (e) {
            if (!/^[A-Za-z0-9\s,.\-/'&]+$/.test(e.key)) {
                e.preventDefault();
            }
        });
        document.getElementById('<%= txtamountpaid.ClientID %>').addEventListener('keypress', function (e) {
            if (e.key !== '₹' && !/^[0-9]$/.test(e.key)) {
                e.preventDefault();
            }
        });
        document.getElementById('<%= txtnoofslots.ClientID %>').addEventListener('keypress', function (e) {
            if (!/^\d+$/.test(e.key)) {
                e.preventDefault();
            }
        });
        document.getElementById('<%= txtallottedcarparkslotnumber1.ClientID %>').addEventListener('keypress', function (e) {
            if (!/^[A-Za-z0-9\-,]+$/.test(e.key)) {
                e.preventDefault();
            }
        });
        document.getElementById('<%= txtregistrationcharges.ClientID %>').addEventListener('keypress', function (e) {
            if (e.key !== '₹' && !/^[0-9]$/.test(e.key)) {
                e.preventDefault();
            }
        });
        document.getElementById('<%= txtregistrationoffice.ClientID %>').addEventListener('keypress', function (e) {
            if (!/^[A-Za-z0-9\s,.\-/'&]+$/.test(e.key)) {
                e.preventDefault();
            }
        });
    <%--    document.getElementById('<%= txtBankname.ClientID %>').addEventListener('keypress', function (e) {
            var validPattern = /^[a-zA-Z\s]+$/;
            if (!validPattern.test(e.key)) {
                e.preventDefault();
            }
        });--%>
    </script>
    <script>
        function toggleSlotsVisibility(element) {
            var numSlots = 0;
            var maxSlots = 3;
            var errorLabel = document.getElementById("errorLabel");

            var parentRow = element.closest(".row");
            if (!parentRow) {
                console.error("Parent row not found");
                return;
            }
            if (element.tagName === "SELECT") {
                numSlots = parseInt(element.value, 10) || 0;

                var targetSections = parentRow.querySelectorAll(".handle-click-yes");
                targetSections.forEach(function (section, index) {
                    if (index < numSlots) {
                        section.style.display = "block";
                    } else {
                        section.style.display = "none";
                    }
                });

                if (numSlots <= maxSlots && errorLabel) {
                    errorLabel.style.display = "none";
                }
            }

            else if (element.tagName === "INPUT") {
                numSlots = parseInt(element.value, 10) || 0;

                if (numSlots > maxSlots) {
                    if (errorLabel) {
                        errorLabel.style.display = "block";
                        errorLabel.textContent = "The maximum number of slots is " + maxSlots + ". Please enter a number between 0 and " + maxSlots + ".";
                    }
                    element.value = maxSlots;
                    numSlots = maxSlots;
                } else {
                    if (errorLabel) {
                        errorLabel.style.display = "none";
                    }
                }
                var targetSections = parentRow.querySelectorAll(".handle-click-yes");
                targetSections.forEach(function (section, index) {
                    if (index <= numSlots) {
                        section.style.display = "block";
                    } else {
                        section.style.display = "none";
                    }
                });
            }
        }




        Sys.Application.add_load(function () {

            var dropdown = document.getElementById('<%= ddloantaken.ClientID %>');
            var req1 = document.getElementById('<%= RequiredFieldValidator20.ClientID %>');
            var divcarp1 = document.getElementById('<%= Divbankname.ClientID %>');
            dropdown.addEventListener('change', function () {
                var selectedValue = dropdown.value;

                if (selectedValue === "1") {
                    divcarp1.style.display = 'block';


                    ValidatorEnable(req1, true);
                }
                else {
                    divcarp1.style.display = 'none';

                    ValidatorEnable(req1, false);
                }

            });
        });
    </script>
    <script type="text/javascript">
        Sys.Application.add_load(function () {
            // Get the dropdown and label elements
            var dropdownprojectname = document.getElementById('<%= ddlprojectname.ClientID %>');
            var dropdownblocknumber = document.getElementById('<%= ddlblocknumber.ClientID %>');
            var dropdownflatNumber = document.getElementById('<%= ddlflatNumber.ClientID %>');
            var messageDiv = $('#projectValidationMessage');
            var txtallottedcarparkslotnumber = document.getElementById('<%= txtallottedcarparkslotnumber1.ClientID %>');
            var txtallottedcarparkslotnumber2 = document.getElementById('<%= txtallottedcarparkslotnumber2.ClientID %>');
            var txtallottedcarparkslotnumber3 = document.getElementById('<%= txtallottedcarparkslotnumber3.ClientID %>');
            var txtnoofslots = document.getElementById('<%= txtnoofslots.ClientID %>');

            // Attach onchange event for flat number dropdown
            dropdownflatNumber.onchange = function () {
                // Reset the message initially
                messageDiv.text("").css("color", "");

                var projectName = parseInt(dropdownprojectname.value, 10);
                var blockNumber = parseInt(dropdownblocknumber.value, 10);
                var flatNumber = parseInt(dropdownflatNumber.value, 10);

                // Validate if all dropdown values are valid numbers
                if (!isNaN(projectName) && !isNaN(blockNumber) && !isNaN(flatNumber)) {
                    $.ajax({
                        type: "POST",
                        url: "add-flat-booking.aspx/CheckProjectExistence",
                        contentType: "application/json; charset=utf-8",
                        dataType: "json",
                        data: JSON.stringify({
                            project: projectName,
                            BlockID: blockNumber,
                            FlatID: flatNumber
                        }),
                        success: function (response) {
                            if (response.d.exists) {
                                messageDiv.text("Flat details already exist.").css("color", "#d41111");
                                txtallottedcarparkslotnumber.value = "";
                                txtnoofslots.value = "";
                                txtallottedcarparkslotnumber2.value = "";
                                txtallottedcarparkslotnumber3.value = "";
                            } else {
                                messageDiv.text("");
                                txtallottedcarparkslotnumber.value = response.d.slotName || "";
                                txtnoofslots.value = response.d.Slotcount || "";
                                txtallottedcarparkslotnumber2.value = response.d.slotName2 || "";
                                txtallottedcarparkslotnumber3.value = response.d.slotName3 || "";
                            }
                        },
                        error: function (xhr, status, error) {
                            messageDiv.text("Error occurred while fetching flat details.").css("color", "#d41111");
                        }
                    });
                } else {
                    messageDiv.text("").css("color", "");
                }
            };
        });
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
                        document.getElementById('<%= btnCancel.ClientID %>').click();
                    } else if (result.dismiss === Swal.DismissReason.cancel) {
                    }
                });
            });
        });
    </script>
    <script type="text/javascript">
        function validatePage() {
            var flag = Page_ClientValidate('CusVal');

            var dropdown = document.getElementById('<%= ddloantaken.ClientID %>');
            var txtreference1 = document.getElementById('<%= txtreference1.ClientID %>');
            var req1 = document.getElementById('<%= RequiredFieldValidator20.ClientID %>');
            var ddlReference = document.getElementById('<%= ddlReference.ClientID %>');
            var req1ReferedBy = document.getElementById('<%= RequiredFieldValidator19.ClientID %>');
            var reqReference = document.getElementById('<%= RequiredFieldValidator16.ClientID %>');
            var ddlLeadSource = document.getElementById('<%= ddlLeadSource.ClientID %>');

            var selectedValue = dropdown.value;

            if (selectedValue === "1") {
                req1.style.display = 'block';
                ValidatorEnable(req1, true);
            } else {
                req1.style.display = 'none';
                ValidatorEnable(req1, false);
            }


            if (ddlLeadSource.value == '10') {
                req1ReferedBy.style.display = 'block';
                ValidatorEnable(req1ReferedBy, true);
                if (ddlReference.value !== '') {
                    if (txtreference1.value === '') {
                        reqReference.style.display = 'block';
                        ValidatorEnable(reqReference, true);
                    } else {
                        reqReference.style.display = 'none';
                        ValidatorEnable(reqReference, false);
                    }
                }
                else {

                    //req1ReferedBy.style.display = 'none';
                    //ValidatorEnable(reqReference, false);
                }
            }
            else {
                //alert("alert !=10");
                req1ReferedBy.style.display = 'none';
                ValidatorEnable(req1ReferedBy, false);

                reqReference.style.display = 'none';
                ValidatorEnable(reqReference, false);

            }

            // Return the validation result
            return flag;
        }
    </script>
    <script>
        function setupFileUploader(fileUploaderSelector, viewButtonSelector, labelSelector) {
            const fileUploader = document.querySelector(fileUploaderSelector);
            const viewButton = document.querySelector(viewButtonSelector);
            const label = document.querySelector(labelSelector);
            let screensrc = null;

            if (!fileUploader || !viewButton || !label) {
                console.error("Required elements not found for selectors:", { fileUploaderSelector, viewButtonSelector, labelSelector });
                return;
            }

            function resetFileInput() {
                fileUploader.value = '';
                screensrc = null;
                viewButton.style.display = 'none';
            }

            fileUploader.addEventListener('change', function () {
                const file = fileUploader.files[0];
                const allowedFiles = [".png", ".jpg", ".jpeg"];

                if (file) {
                    const ext = file.name.split('.').pop().toLowerCase();

                    if (!allowedFiles.includes("." + ext)) {
                        label.textContent = "Select .png, .jpg, or .jpeg files only.";
                        resetFileInput();
                        return;
                    }

                    const size = parseFloat(file.size / 1024).toFixed(2); // Size in KB
                    if (size > 500) {
                        label.textContent = "Image size must be under 500 KB";
                        resetFileInput();
                        return;
                    }

                    label.textContent = "";
                    const reader = new FileReader();
                    reader.onload = function (e) {
                        screensrc = e.target.result;
                        viewButton.style.display = 'inline-block';
                    };

                    reader.onerror = function () {
                        screensrc = null;
                        console.error("Error reading file.");
                    };

                    reader.readAsDataURL(file);
                } else {
                    resetFileInput();
                }
            });

            viewButton.addEventListener('click', function () {
                if (!screensrc) {
                    return;
                }
                Swal.fire({
                    html: `
            <div style="position: relative;">
                <div class="btn-close-icon" style="cursor: pointer; position: absolute; top: -15px; right: -25px;">&times;</div>
                <h2 class="fw-bold">Photo</h2>
                <img id="swalImage" src="" alt="Photo" class="img-fluid mt-3">
            </div>
        `,
                    showConfirmButton: false,
                    didOpen: () => {
                        document.getElementById('swalImage').src = screensrc;
                        document.querySelector('.btn-close-icon').addEventListener('click', () => Swal.close());
                    }
                });
            });
        }

        // Initialize file uploaders with unique selectors
        document.addEventListener('DOMContentLoaded', function () {
            setupFileUploader('.flPhoto', '.btn-view-Photo1', '.lblflPhoto');
            setupFileUploader('.flPhoto2', '.btn-view-Photo2', '.lblflPhoto2'); // Example for another uploader
        });

    </script>
    <script type="text/javascript">
        document.addEventListener('DOMContentLoaded', function () {
            var fileUploaders = document.querySelectorAll('.file-upload');
            var viewLogoBtns = document.querySelectorAll('.btn-view');
            var errorLabels = document.querySelectorAll('.error-label');
            var screensrc = {};
            var fileType = {};
            var fileTitles = ['Aadhaar', 'PAN', 'Co-Applicant Aadhaar', 'Co-Applicant PAN', 'Power of Attorney PAN', 'Power of Attorney Aadhar', 'Booking Acknowledgement'];

            if (!fileUploaders || !viewLogoBtns || !errorLabels) {
                console.error("Required elements not found in the DOM.");
                return;
            }

            fileUploaders.forEach(function (fileUploader, index) {
                // Show file when selected
                fileUploader.addEventListener('change', function (event) {
                    var input = event.target;
                    var file = input.files[0];
                    var validImageTypes = ['image/jpeg', 'image/png', 'image/jpg'];
                    var validFileTypes = validImageTypes.concat(['application/pdf']);
                    var isValidFileType = validFileTypes.includes(file.type);
                    var viewLogoBtn = viewLogoBtns[index];
                    var errorLabel = errorLabels[index];
                    fileType[index] = file.type;

                    errorLabel.textContent = ''; // Clear previous error messages

                    if (!file) {
                        resetUploader(viewLogoBtn, errorLabel, index);
                        errorLabel.textContent = "No file selected.";
                        return;
                    }
                    if (!isValidFileType) {
                        resetUploader(viewLogoBtn, errorLabel, index);
                        errorLabel.textContent = "Invalid file type. Only PDF, PNG, JPEG, and JPG files are allowed.";
                        return;
                    }
                    if (file.type === 'application/pdf' && file.size > 800 * 1024) {
                        resetUploader(viewLogoBtn, errorLabel, index);
                        errorLabel.textContent = "PDF size must be under 800 KB";
                        return;
                    }
                    if (validImageTypes.includes(file.type) && file.size > 500 * 1024) {
                        resetUploader(viewLogoBtn, errorLabel, index);
                        errorLabel.textContent = "Image size must be under 500 KB";
                        return;
                    }
                    var reader = new FileReader();
                    reader.onload = function (e) {
                        screensrc[index] = e.target.result;
                        viewLogoBtn.style.display = 'inline-block';
                        viewLogoBtn.src = validImageTypes.includes(file.type) ? screensrc[index] : ''; // Show image preview for images
                    };

                    reader.onerror = function (err) {
                        console.error("Error reading file:", err);
                        screensrc[index] = null;
                    };

                    reader.readAsDataURL(file);
                });

                // Reset the uploader when no file is chosen on click
                fileUploader.addEventListener('click', function () {
                    var errorLabel = errorLabels[index];
                    resetUploader(viewLogoBtns[index], errorLabel, index);
                });

                // Open file in new tab or SweetAlert modal
                viewLogoBtns[index].addEventListener('click', function () {
                    if (!screensrc[index]) {
                        var errorLabel = errorLabels[index];
                        errorLabel.textContent = "No file uploaded yet!";
                        resetUploader(viewLogoBtns[index], errorLabel, index); // Reset the file uploader if no file is uploaded
                        return;
                    }
                    //alert(fileTitles[index]);
                    var fileTitle = fileTitles[index];

                    if (fileType[index] === 'application/pdf') {
                        var newWindow = window.open();
                        newWindow.document.write(`<embed src="${screensrc[index]}" width="100%" height="100%">`);
                    } else {
                        Swal.fire({
                            html: `
                        <div style="position: relative;">
                            <div class="btn-close-icon" style="cursor: pointer; position: absolute; top: -15px; right: -25px;">&times;</div>
                            <h2 class="fw-bold">${fileTitle}</h2>
                            <img id="swalImage" src="" alt="${fileTitle}" class="img-fluid mt-3">
                        </div>
                    `,
                            showConfirmButton: false,
                            didOpen: () => {
                                document.getElementById('swalImage').src = screensrc[index];
                                document.querySelector('.btn-close-icon').addEventListener('click', () => Swal.close());
                            }
                        });
                    }
                });
            });

            // Reset the uploader
            function resetUploader(viewLogoBtn, errorLabel, index) {
                screensrc[index] = null;
                document.querySelectorAll('.file-upload')[index].value = '';
                viewLogoBtn.src = '';
                viewLogoBtn.style.display = 'none';
                errorLabel.textContent = ''; // Clear error message
            }
        });
    </script>
    <script>
        function addCurrencySymbol(input) {
            if (input && !input.value.startsWith("₹")) {
                input.value = "₹" + input.value;
            }
        }

        document.addEventListener("DOMContentLoaded", function () {
            var input = document.getElementById("txtamountpaid");
            var inputreg = document.getElementById("txtregistrationcharges");
            if (input) {
                if (input.value && !input.value.startsWith("₹")) {
                    input.value = "₹" + input.value;
                } else {
                }
            } else {
            }
            if (inputreg) {
                if (inputreg.value && !inputreg.value.startsWith("₹")) {
                    inputreg.value = "₹" + inputreg.value;
                } else {
                }
            } else {
            }
        });
    </script>
    <script> 

        function addCurrencySymbol(input) {
            if (!input.value.startsWith("₹")) {
                input.value = "₹" + input.value;
            }
        }


        function keyup(txtID, lblID) {
            if (lblID == "lblamount") {
                $("#lblamount").text("");
            }
            var txtamt = $("#" + txtID).val().replace(/₹/, "");
            if (txtamt !== '') {
                $.ajax({
                    type: "POST",
                    url: "add-flat-booking.aspx/AmttowordConversion",
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    data: '{stAmt: "' + txtamt + '" }',
                    success: function (data) {
                        $("#" + lblID).text(data.d);
                    },
                    error: (xhr) => {
                        var responseText = jQuery.parseJSON(xhr.responseText);
                        alert(responseText.Message);
                    }
                });
            } else {
                $("#" + lblID).text("");
            }
        }




        // Existing keyup function (no changes needed)
        function keyup(txtID, lblID) {
            if (lblID == "txtregistrationcharges") {
                $("#txtregistrationcharges").text("");
            }
            var txtamt = $("#" + txtID).val().replace(/₹/, ""); // Remove ₹ for processing
            if (txtamt !== '') {
                $.ajax({
                    type: "POST",
                    url: "add-flat-booking.aspx/AmttowordConversion",
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    data: '{stAmt: "' + txtamt + '" }',
                    success: function (data) {
                        $("#" + lblID).text(data.d);
                    },
                    error: (xhr) => {
                        var responseText = jQuery.parseJSON(xhr.responseText);
                        alert(responseText.Message);
                    }
                });
            } else {
                $("#" + lblID).text("");
            }
        }

    </script>
    <!-- Define global function -->
    <script type="text/javascript">

        window.screensrc = {};

        function bindImageToPreview(srclogo, index) {
            // console.log("Binding image to preview: ", srclogo, index); 
            var viewLogoBtns = document.querySelectorAll('.btn-view');

            if (index !== -1 && viewLogoBtns[index]) {
                screensrc[index] = srclogo;
                viewLogoBtns[index].style.display = 'inline-block';
                viewLogoBtns[index].src = srclogo;
            } else {
                console.error("View logo button not found or index is invalid.");
            }
        }

        document.addEventListener('DOMContentLoaded', function () {
            var fileUploaders = document.querySelectorAll('.file-upload');
            var viewLogoBtns = document.querySelectorAll('.btn-view');
            var errorLabels = document.querySelectorAll('.error-label');
            var fileType = {};
            var fileTitles = ['Aadhaar', 'PAN', 'Co-Applicant Aadhaar', 'Co-Applicant PAN', 'Power of Attorney PAN', 'Power of Attorney Aadhar', 'Booking Acknowledgement'];

            if (!fileUploaders.length || !viewLogoBtns.length || !errorLabels.length) {
                console.error("Required elements not found in the DOM.");
                return;
            }

            // Verify element selection
            fileUploaders.forEach((fileUploader, index) => {
                if (!fileUploader || !viewLogoBtns[index] || !errorLabels[index]) {
                    console.error("Element at index " + index + " not found.");
                    return;
                }

                fileUploader.addEventListener('change', function (event) {
                    var input = event.target;
                    var file = input.files[0];
                    var validImageTypes = ['image/jpeg', 'image/png', 'image/jpg'];
                    var validFileTypes = validImageTypes.concat(['application/pdf']);
                    var isValidFileType = validFileTypes.includes(file.type);
                    var viewLogoBtn = viewLogoBtns[index];
                    var errorLabel = errorLabels[index];
                    fileType[index] = file.type;

                    errorLabel.textContent = ''; // Clear previous error messages

                    if (!file) {
                        resetUploader(viewLogoBtn, errorLabel, index);
                        errorLabel.textContent = "No file selected.";
                        return;
                    }

                    if (!isValidFileType) {
                        resetUploader(viewLogoBtn, errorLabel, index);
                        errorLabel.textContent = "Invalid file type. Only PDF, PNG, JPEG, and JPG files are allowed.";
                        return;
                    }

                    if (file.type === 'application/pdf' && file.size > 800 * 1024) {
                        resetUploader(viewLogoBtn, errorLabel, index);
                        errorLabel.textContent = "PDF size must be under 500 KB";
                        return;
                    }

                    if (validImageTypes.includes(file.type) && file.size > 500 * 1024) {
                        resetUploader(viewLogoBtn, errorLabel, index);
                        errorLabel.textContent = "Image size must be under 500 KB";
                        return;
                    }

                    var reader = new FileReader();
                    reader.onload = function (e) {
                        screensrc[index] = e.target.result;
                        viewLogoBtn.style.display = 'inline-block';
                        viewLogoBtn.src = validImageTypes.includes(file.type) ? screensrc[index] : ''; // Show image preview for images
                    };

                    reader.onerror = function (err) {
                        console.error("Error reading file:", err);
                        screensrc[index] = null;
                    };

                    reader.readAsDataURL(file);
                });

                // Reset the uploader when no file is chosen on click
                fileUploader.addEventListener('click', function () {
                    var errorLabel = errorLabels[index];
                    resetUploader(viewLogoBtns[index], errorLabel, index);
                });

                // Open file in new tab or SweetAlert modal
                viewLogoBtns[index].addEventListener('click', function () {
                    if (!screensrc[index]) {
                        var errorLabel = errorLabels[index];
                        errorLabel.textContent = "No file uploaded yet!";
                        resetUploader(viewLogoBtns[index], errorLabel, index); // Reset the file uploader if no file is uploaded
                        return;
                    }
                    var fileTitle = fileTitles[index];

                    if (fileType[index] === 'application/pdf') {
                        var newWindow = window.open();
                        newWindow.document.write(`<embed src="${screensrc[index]}" width="100%" height="100%">`);
                    } else {
                        Swal.fire({
                            html: `
                                <div style="position: relative;">
                                    <div class="btn-close-icon" style="cursor: pointer; position: absolute; top: -15px; right: -25px;">&times;</div>
                                    <h2 class="fw-bold">${fileTitle}</h2>
                                    <img id="swalImage" src="${screensrc[index]}" alt="${fileTitle}" class="img-fluid mt-3">
                                </div>
                            `,
                            showConfirmButton: false,
                            didOpen: () => {
                                document.querySelector('.btn-close-icon').addEventListener('click', () => Swal.close());
                            }
                        }).then(() => {
                            // Ensure the button remains visible after closing the modal
                            viewLogoBtns[index].style.display = 'inline-block';
                        });
                    }
                });
            });

            // Reset the uploader
            function resetUploader(viewLogoBtn, errorLabel, index) {
                screensrc[index] = null;
                document.querySelectorAll('.file-upload')[index].value = '';
                viewLogoBtn.src = '';
                viewLogoBtn.style.display = 'none';
                errorLabel.textContent = ''; // Clear error message
            }
        });

        // Ensure global function is set
        window.bindImageToPreview = bindImageToPreview;
    </script>
    <script type="text/javascript">
        window.screensrc = { photo1: [], photo2: [] }; // Global screensrc for binding images

        function bindImageToPreviewphoto(srclogo, index, type) {
            //console.log("Binding image to preview: ", srclogo, index, type); // Debugging line
            var viewLogoBtns = type === 'photo1' ? document.querySelectorAll('.btn-view-Photo1') : document.querySelectorAll('.btn-view-Photo2');

            if (index !== -1 && viewLogoBtns[index]) {
                screensrc[type] = screensrc[type] || [];
                screensrc[type][index] = srclogo;
                viewLogoBtns[index].style.display = 'inline-block';
                viewLogoBtns[index].src = srclogo; // Show the image preview
            } else {
                console.error("View logo button not found or index is invalid.");
            }
        }

        function setupFileUploader(fileUploaderSelector, viewButtonSelector, labelSelector, type) {
            const fileUploaders = document.querySelectorAll(fileUploaderSelector);
            const viewLogoBtns = document.querySelectorAll(viewButtonSelector);
            const errorLabels = document.querySelectorAll(labelSelector);

            if (!fileUploaders.length || !viewLogoBtns.length || !errorLabels.length) {
                console.error("Required elements not found for selectors:", { fileUploaderSelector, viewButtonSelector, labelSelector });
                return;
            }

            fileUploaders.forEach((fileUploader, index) => {
                const viewButton = viewLogoBtns[index];
                const label = errorLabels[index];

                if (!fileUploader || !viewButton || !label) {
                    console.error("Element at index " + index + " not found.");
                    return;
                }

                // Function to reset file input
                function resetFileInput() {
                    fileUploader.value = '';
                    screensrc[type][index] = null;
                    viewButton.style.display = 'none';
                }

                fileUploader.addEventListener('change', function () {
                    const file = fileUploader.files[0];
                    const allowedFiles = [".png", ".jpg", ".jpeg"];

                    if (file) {
                        const ext = file.name.split('.').pop().toLowerCase();

                        if (!allowedFiles.includes("." + ext)) {
                            alert("Select .png, .jpg, or .jpeg files only.");
                            resetFileInput();
                            return;
                        }

                        const size = parseFloat(file.size / 1024).toFixed(2); // Size in KB
                        if (size > 500) {
                            label.textContent = "Image size must be under 500 KB";
                            resetFileInput();
                            return;
                        }

                        label.textContent = "";
                        const reader = new FileReader();
                        reader.onload = function (e) {
                            screensrc[type][index] = e.target.result;
                            viewButton.style.display = 'inline-block';
                            viewButton.src = screensrc[type][index]; // Display image in button
                        };

                        reader.onerror = function () {
                            screensrc[type][index] = null;
                            console.error("Error reading file.");
                        };

                        reader.readAsDataURL(file);
                    } else {
                        resetFileInput();
                    }
                });

                viewButton.addEventListener('click', function () {
                    if (!screensrc[type][index]) {
                        return;
                    }
                    Swal.fire({
                        html: `
                    <div style="position: relative;">
                        <div class="btn-close-icon" style="cursor: pointer; position: absolute; top: -15px; right: -25px;">&times;</div>
                        <h2 class="fw-bold">Photo</h2>
                        <img id="swalImage" src="${screensrc[type][index]}" alt="Photo" class="img-fluid mt-3">
                    </div>
            `,
                        showConfirmButton: false,
                        didOpen: () => {
                            document.querySelector('.btn-close-icon').addEventListener('click', () => Swal.close());
                        }
                    });
                });
            });
        }

        // Initialize file uploaders with unique selectors
        document.addEventListener('DOMContentLoaded', function () {
            setupFileUploader('.flPhoto', '.btn-view-Photo1', '.lblflPhoto', 'photo1');
            setupFileUploader('.flPhoto2', '.btn-view-Photo2', '.lblflPhoto2', 'photo2'); // Example for another uploader
        });

        // Ensure global function is set
        window.bindImageToPreviewphoto = bindImageToPreviewphoto;
    </script>
</asp:Content>

