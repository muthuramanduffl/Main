<%@ Page Title="" Language="C#" MasterPageFile="~/AdminKey2h.master" AutoEventWireup="true" CodeFile="add-kyc-docs.aspx.cs" Inherits="adminkey2hcom_AddKYCDocs" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
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
                            <asp:Label ID="lblDisplaytext" runat="server" Text=""></asp:Label>
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
                                        <h3>KYC Docs Upload</h3>
                                    </div>
                                    <div class="row mx-0 margin-top20 mb-4">
                                        <div class="col-sm-4 col-xl-3 pt-4">
                                            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                                <ContentTemplate>
                                                    <div class="input-icon input-icon-sm right">
                                                        <label>Project Name <span class="text-danger">*</span></label>
                                                        <i class="bi bi-journal-bookmark-fill b5-icon"></i>
                                                        <asp:DropDownList ID="ddlProName" AutoPostBack="true" OnSelectedIndexChanged="ddlProName_SelectedIndexChanged" class="bs-select form-control input-sm" runat="server">
                                                            <asp:ListItem Value=" "> </asp:ListItem>
                                                        </asp:DropDownList>
                                                    </div>
                                                    <span class="error">
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ValidationGroup="val"
                                                            ControlToValidate="ddlProName" InitialValue="" ErrorMessage="Select project name">
                                                        </asp:RequiredFieldValidator>
                                                    </span>
                                                </ContentTemplate>
                                                <Triggers>
                                                    <asp:AsyncPostBackTrigger ControlID="ddlProName" EventName="SelectedIndexChanged" />
                                                    <asp:AsyncPostBackTrigger ControlID="ddlBlockNumber" EventName="SelectedIndexChanged" />
                                                    <asp:AsyncPostBackTrigger ControlID="ddlFlatNumber" EventName="SelectedIndexChanged" />
                                                </Triggers>
                                            </asp:UpdatePanel>
                                        </div>

                                        <div class="col-sm-4 col-xl-3 pt-4">
                                            <div class="input-icon input-icon-sm right">
                                                <label>Block Name <span class="text-danger">*</span></label>
                                                <i class="bi bi-building b5-icon"></i>
                                                <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                                                    <ContentTemplate>
                                                        <asp:DropDownList ID="ddlBlockNumber" AutoPostBack="true" OnSelectedIndexChanged="ddlBlockNumber_SelectedIndexChanged" class="bs-select form-control input-sm" runat="server">
                                                        </asp:DropDownList>
                                                        <span class="error">
                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ValidationGroup="val"
                                                                ControlToValidate="ddlBlockNumber" InitialValue="" ErrorMessage="Select block name">
                                                            </asp:RequiredFieldValidator>
                                                        </span>
                                                    </ContentTemplate>
                                                    <Triggers>
                                                        <asp:AsyncPostBackTrigger ControlID="ddlProName" EventName="SelectedIndexChanged" />
                                                        <asp:AsyncPostBackTrigger ControlID="ddlBlockNumber" EventName="SelectedIndexChanged" />
                                                        <asp:AsyncPostBackTrigger ControlID="ddlFlatNumber" EventName="SelectedIndexChanged" />
                                                    </Triggers>
                                                </asp:UpdatePanel>
                                            </div>
                                        </div>
                                        <asp:HiddenField ID="hdnID" runat="server" />
                                        <div class="col-sm-4 col-xl-3 pt-4">
                                            <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                                                <ContentTemplate>
                                                    <div class="input-icon input-icon-sm right">
                                                        <label>Flat Number <span class="text-danger">*</span></label>
                                                        <i class="bi bi-file-binary b5-icon"></i>
                                                        <asp:DropDownList ID="ddlFlatNumber" AutoPostBack="true" ClientIDMode="Static" OnSelectedIndexChanged="ddlFlatNumber_SelectedIndexChanged" class="bs-select form-control input-sm" runat="server">
                                                        </asp:DropDownList>
                                                    </div>
                                                    <span class="error">
                                                        <asp:RequiredFieldValidator ClientIDMode="Static" Display="Dynamic" EnableClientScript="true" SetFocusOnError="true" ControlToValidate="ddlFlatNumber" ValidationGroup="val" ID="RequiredFieldValidator13" runat="server" ErrorMessage="Select flat no. "></asp:RequiredFieldValidator>
                                                    </span>
                                                </ContentTemplate>
                                                <Triggers>
                                                    <asp:AsyncPostBackTrigger ControlID="ddlProName" EventName="SelectedIndexChanged" />
                                                    <asp:AsyncPostBackTrigger ControlID="ddlBlockNumber" EventName="SelectedIndexChanged" />
                                                    <asp:AsyncPostBackTrigger ControlID="ddlFlatNumber" EventName="SelectedIndexChanged" />
                                                </Triggers>
                                            </asp:UpdatePanel>
                                        </div>
                                        <div class="col-sm-4 col-xl-3 pt-4">
                                            <asp:UpdatePanel ID="UpdatePanel4" runat="server" UpdateMode="Conditional">
                                                <ContentTemplate>
                                                    <div class="input-icon input-icon-sm right">
                                                        <label>Customer Name </label>
                                                        <i class="bi bi-person-square b5-icon"></i>
                                                        <asp:TextBox runat="server" ID="txtCustomerName" class="form-control input-sm" ReadOnly="true" autocomplete="off" placeholder=""></asp:TextBox>
                                                    </div>
                                                    <asp:Label ID="lblcustomernameerror" ClientIDMode="Static" class="align-items-center text-center error" runat="server" Text=""></asp:Label>
                                                </ContentTemplate>
                                                <Triggers>
                                                    <asp:AsyncPostBackTrigger ControlID="ddlProName" EventName="SelectedIndexChanged" />
                                                    <asp:AsyncPostBackTrigger ControlID="ddlBlockNumber" EventName="SelectedIndexChanged" />
                                                    <asp:AsyncPostBackTrigger ControlID="ddlFlatNumber" EventName="SelectedIndexChanged" />
                                                </Triggers>
                                            </asp:UpdatePanel>
                                        </div>

                                        <div class="col-sm-4 col-xl-3 pt-4">
                                            <div class="input-icon input-icon-sm right">
                                                <label>Sale Deed Draft</label>
                                                <i class="bi bi-images b5-icon"></i>
                                                <asp:FileUpload ID="FileUploadSaleDeedDraft" ClientIDMode="Static" runat="server" CssClass="form-control input-sm file-upload" accept=".pdf" />
                                                <span class="handle-file-request">(upload max file size,pdf-800 KB)</span>
                                                <asp:HiddenField ID="hdnFileUploadSaleDeedDraft" runat="server" />
                                            </div>
                                            <span class="error">
                                                <asp:Label ID="lblFileUploadSaleDeedDraft" CssClass="lblFileUpload" runat="server" ForeColor="#d41111" Text=""></asp:Label>
                                                <%--                                                <asp:RequiredFieldValidator ClientIDMode="Static" Display="Dynamic" EnableClientScript="true" SetFocusOnError="true" ControlToValidate="FileUploadSaleDeedDraft" ValidationGroup="val" ID="RequiredFieldValidator3" runat="server" ErrorMessage="Upload sale deed draft"></asp:RequiredFieldValidator>--%>
                                            </span>
                                            <div class="btn-view btn-view-pop" clientidmode="Static" id="DivSaleDeedDraft" style="display: none">
                                                <i class="bi bi-eye"></i>View 
                                            </div>
                                        </div>

                                        <div class="col-sm-4 col-xl-3 pt-4">
                                            <div class="input-icon input-icon-sm right">
                                                <label>Sale Deed Final</label>
                                                <i class="bi bi-images b5-icon"></i>
                                                <asp:FileUpload ID="FileUploadSaleDeedFinal" ClientIDMode="Static" runat="server" CssClass="form-control input-sm file-upload" accept=".pdf" />
                                                <span class="handle-file-request">(upload max file size,pdf-800 KB)</span>
                                                <asp:HiddenField ID="hdnFileUploadSaleDeedFinal" runat="server" />
                                            </div>
                                            <span class="error">
                                                <asp:Label ID="lblFileUploadSaleDeedFinal" CssClass="lblFileUpload" runat="server" ForeColor="#d41111" Text=""></asp:Label>
                                                <%--                                                <asp:RequiredFieldValidator ClientIDMode="Static" Display="Dynamic" EnableClientScript="true" SetFocusOnError="true" ControlToValidate="FileUploadSaleDeedFinal" ValidationGroup="val" ID="RequiredFieldValidator4" runat="server" ErrorMessage="Upload sale deed final"></asp:RequiredFieldValidator>--%>

                                            </span>
                                            <div class="btn-view btn-view-pop" clientidmode="Static" runat="server" id="DivSaleDeedFinal" style="display: none">
                                                <i class="bi bi-eye"></i>View 
                                            </div>
                                        </div>

                                        <div class="col-sm-4 col-xl-3 pt-4">
                                            <div class="input-icon input-icon-sm right">
                                                <label>Sale Agreement Draft</label>
                                                <i class="bi bi-images b5-icon"></i>
                                                <asp:FileUpload ID="FileUploadSaleAgreementDraft" ClientIDMode="Static" runat="server" CssClass="form-control input-sm file-upload" accept=".pdf" />
                                                <span class="handle-file-request">(upload max file size,pdf-800 KB)</span>
                                                <asp:HiddenField ID="hdnFileUploadSaleAgreementDraft" runat="server" />
                                            </div>
                                            <span class="error">
                                                <asp:Label ID="lblFileUploadSaleAgreementDraft" CssClass="lblFileUpload" runat="server" ForeColor="#d41111" Text=""></asp:Label>
                                                <%--                                                <asp:RequiredFieldValidator ClientIDMode="Static" Display="Dynamic" EnableClientScript="true" SetFocusOnError="true" ControlToValidate="FileUploadSaleAgreementDraft" ValidationGroup="val" ID="RequiredFieldValidator5" runat="server" ErrorMessage="Upload sale agreement draft"></asp:RequiredFieldValidator>--%>

                                            </span>
                                            <div class="btn-view btn-view-pop" clientidmode="Static" runat="server" id="DivSaleAgreementDraft" style="display: none">
                                                <i class="bi bi-eye"></i>View 
                                            </div>
                                        </div>

                                        <div class="col-sm-4 col-xl-3 pt-4">
                                            <div class="input-icon input-icon-sm right">
                                                <label>Sale Agreement Final</label>
                                                <i class="bi bi-images b5-icon"></i>
                                                <asp:FileUpload ID="FileUploadSaleAgreementFinal" ClientIDMode="Static" runat="server" CssClass="form-control input-sm file-upload" accept=".pdf" />
                                                <span class="handle-file-request">(upload max file size,pdf-800 KB)</span>
                                                <asp:HiddenField ID="hdnFileUploadSaleAgreementFinal" runat="server" />
                                            </div>
                                            <span class="error">
                                                <asp:Label ID="lblFileUploadSaleAgreementFinal" CssClass="lblFileUpload" runat="server" ForeColor="#d41111" Text=""></asp:Label>
                                                <%--                                                <asp:RequiredFieldValidator ClientIDMode="Static" Display="Dynamic" EnableClientScript="true" SetFocusOnError="true" ControlToValidate="FileUploadSaleAgreementFinal" ValidationGroup="val" ID="RequiredFieldValidator6" runat="server" ErrorMessage="Upload sale agreement final"></asp:RequiredFieldValidator>--%>

                                            </span>
                                            <div class="btn-view btn-view-pop" clientidmode="Static" runat="server" id="DivSaleAgreementFinal" style="display: none">
                                                <i class="bi bi-eye"></i>View 
                                            </div>
                                        </div>

                                        <div class="col-sm-4 col-xl-3 pt-4">
                                            <div class="input-icon input-icon-sm right">
                                                <label>Allotment Letter</label>
                                                <i class="bi bi-images b5-icon"></i>
                                                <asp:FileUpload ID="FileUploadAllotmentLetter" ClientIDMode="Static" runat="server" CssClass="form-control input-sm file-upload" accept=".pdf" />
                                                <span class="handle-file-request">(upload max file size,pdf-800 KB)</span>
                                                <asp:HiddenField ID="hdnFileUploadAllotmentLetter" runat="server" />
                                            </div>
                                            <span class="error">
                                                <asp:Label ID="lblFileUploadAllotmentLetter" CssClass="lblFileUpload" runat="server" ForeColor="#d41111" Text=""></asp:Label>
                                                <%--                                                <asp:RequiredFieldValidator ClientIDMode="Static" Display="Dynamic" EnableClientScript="true" SetFocusOnError="true" ControlToValidate="FileUploadAllotmentLetter" ValidationGroup="val" ID="RequiredFieldValidator7" runat="server" ErrorMessage="Upload allotment letter"></asp:RequiredFieldValidator>--%>

                                            </span>
                                            <div class="btn-view btn-view-pop" clientidmode="Static" runat="server" id="DivAllotmentLetter" style="display: none">
                                                <i class="bi bi-eye"></i>View 
                                            </div>
                                        </div>
                                        <div class="col-sm-4 col-xl-3 pt-4">
                                            <div class="input-icon input-icon-sm right">
                                                <label>Welcome Letter</label>
                                                <i class="bi bi-images b5-icon"></i>
                                                <asp:FileUpload ID="FileUploadWelcomeLetter" CssClass="form-control input-sm file-upload" accept=".pdf" runat="server" />
                                                <span class="handle-file-request">(upload max file size,pdf-800 KB)</span>
                                                <asp:HiddenField ID="hdnFileUploadWelcomeLetter" runat="server" />
                                            </div>
                                            <span class="error">
                                                <asp:Label ID="lblFileUploadWelcomeLetter" CssClass="lblFileUpload" runat="server" ForeColor="#d41111" Text=""></asp:Label>
                                                <%--                                                <asp:RequiredFieldValidator ClientIDMode="Static" Display="Dynamic" EnableClientScript="true" SetFocusOnError="true" ControlToValidate="FileUploadWelcomeLetter" ValidationGroup="val" ID="RequiredFieldValidator8" runat="server" ErrorMessage="Upload welcome letter"></asp:RequiredFieldValidator>--%>
                                            </span>
                                            <div class="btn-view btn-view-pop" clientidmode="Static" runat="server" id="DivWelcomeLetter" style="display: none">
                                                <i class="bi bi-eye"></i>View 
                                            </div>
                                        </div>
                                        <div class="col-sm-4 col-xl-3 pt-4">
                                            <div class="input-icon input-icon-sm right">
                                                <label>Demand Letter</label>
                                                <i class="bi bi-images b5-icon"></i>
                                                <asp:FileUpload ID="FileUploadDemandLetter" CssClass="form-control input-sm file-upload" accept=".pdf" runat="server" />
                                                <span class="handle-file-request">(upload max file size,pdf-800 KB)</span>
                                                <asp:HiddenField ID="hdnFileUploadDemandLetter" runat="server" />
                                            </div>
                                            <span class="error">
                                                <asp:Label ID="lblFileUploadDemandLetter" CssClass="lblFileUpload" runat="server" ForeColor="#d41111" Text=""></asp:Label>
                                                <%--  <asp:RequiredFieldValidator ClientIDMode="Static" Display="Dynamic" EnableClientScript="true" SetFocusOnError="true" ControlToValidate="FileUploadDemandLetter" ValidationGroup="val" ID="RequiredFieldValidator9" runat="server" ErrorMessage="Upload demand letter"></asp:RequiredFieldValidator>--%>
                                            </span>
                                            <div class="btn-view btn-view-pop" clientidmode="Static" runat="server" id="DivDemandLetter" style="display: none">
                                                <i class="bi bi-eye"></i>View 
                                            </div>
                                        </div>
                                        <div class="col-sm-4 col-xl-3 pt-4">
                                            <div class="input-icon input-icon-sm right">
                                                <label>Payment Receipt</label>
                                                <i class="bi bi-images b5-icon"></i>
                                                <asp:FileUpload ID="FileUploadPaymentReceipt" CssClass="form-control input-sm file-upload" accept=".pdf" runat="server" />
                                                <span class="handle-file-request">(upload max file size,pdf-800 KB)</span>
                                                <asp:HiddenField ID="hdnFileUploadPaymentReceipt" runat="server" />
                                            </div>
                                            <span class="error">
                                                <asp:Label ID="lblFileUploadPaymentReceipt" CssClass="lblFileUpload" runat="server" ForeColor="#d41111" Text=""></asp:Label>
                                                <%--                                                <asp:RequiredFieldValidator ClientIDMode="Static" Display="Dynamic" EnableClientScript="true" SetFocusOnError="true" ControlToValidate="FileUploadPaymentReceipt" ValidationGroup="val" ID="RequiredFieldValidator10" runat="server" ErrorMessage="Upload payment receipt"></asp:RequiredFieldValidator>--%>

                                            </span>
                                            <div class="btn-view btn-view-pop" clientidmode="Static" runat="server" id="DivPaymentReceipt" style="display: none">
                                                <i class="bi bi-eye"></i>View 
                                            </div>
                                        </div>
                                        <div class="col-sm-4 col-xl-3 pt-4">
                                            <div class="input-icon input-icon-sm right">
                                                <label>Bill</label>
                                                <i class="bi bi-images b5-icon"></i>
                                                <asp:FileUpload ID="FileUploadBill" CssClass="form-control input-sm file-upload" accept=".pdf" runat="server" />
                                                <span class="handle-file-request">(upload max file size,pdf-800 KB)</span>
                                                <asp:HiddenField ID="hdnFileUploadBill" runat="server" />
                                            </div>
                                            <span class="error">
                                                <asp:Label ID="lblFileUploadBill" CssClass="lblFileUpload" runat="server" ForeColor="#d41111" Text=""></asp:Label>
                                                <%--                                                <asp:RequiredFieldValidator ClientIDMode="Static" Display="Dynamic" EnableClientScript="true" SetFocusOnError="true" ControlToValidate="FileUploadBill" ValidationGroup="val" ID="RequiredFieldValidator11" runat="server" ErrorMessage="Upload payment receipt"></asp:RequiredFieldValidator>--%>
                                            </span>
                                            <div class="btn-view btn-view-pop" clientidmode="Static" runat="server" id="DivBill" style="display: none">
                                                <i class="bi bi-eye"></i>View 
                                            </div>
                                        </div>
                                        <div class="col-sm-4 col-xl-3 pt-4">
                                            <div class="input-icon input-icon-sm right">
                                                <label>Payment Schedule</label>
                                                <i class="bi bi-images b5-icon"></i>
                                                <asp:FileUpload ID="FileUploadPaymentSchedule" CssClass="form-control input-sm file-upload" accept=".pdf" runat="server" />
                                                <span class="handle-file-request">(upload max file size,pdf-800 KB)</span>
                                                <asp:HiddenField ID="hdnFileUploadPaymentSchedule" runat="server" />
                                            </div>
                                            <span class="error">
                                                <%--     <asp:RequiredFieldValidator ClientIDMode="Static" Display="Dynamic" EnableClientScript="true" SetFocusOnError="true" ControlToValidate="FileUploadPaymentSchedule" ValidationGroup="val" ID="RequiredFieldValidator12" runat="server" ErrorMessage="Upload payment schedule"></asp:RequiredFieldValidator>--%>
                                                <asp:Label ID="lblFileUploadPaymentSchedule" CssClass="lblFileUpload" runat="server" ForeColor="#d41111" Text=""></asp:Label>
                                            </span>
                                            <div class="btn-view btn-view-pop" clientidmode="Static" runat="server" id="DivPaymentSchedule" style="display: none">
                                                <i class="bi bi-eye"></i>View 
                                            </div>
                                        </div>
                                        <div class="col-sm-4 col-xl-3 pt-4">
                                            <div class="input-icon input-icon-sm right">
                                                <label>EB card</label>
                                                <i class="bi bi-images b5-icon"></i>
                                                <asp:FileUpload ID="FileUploadEBCard" CssClass="form-control input-sm file-upload" accept=".pdf" runat="server" />
                                                <span class="handle-file-request">(upload max file size,pdf-800 KB)</span>
                                                <asp:HiddenField ID="hdnFileUploadEBCard" runat="server" />
                                            </div>
                                            <span class="error">
                                                <%--                                                <asp:RequiredFieldValidator ClientIDMode="Static" Display="Dynamic" EnableClientScript="true" SetFocusOnError="true" ControlToValidate="FileUploadEBCard" ValidationGroup="val" ID="RequiredFieldValidator14" runat="server" ErrorMessage="Upload EB card"></asp:RequiredFieldValidator>--%>
                                                <asp:Label ID="lblFileUploadEBCard" CssClass="lblFileUpload" runat="server" ForeColor="#d41111" Text=""></asp:Label>

                                            </span>
                                            <div class="btn-view btn-view-pop" clientidmode="Static" runat="server" id="DivEBCard" style="display: none">
                                                <i class="bi bi-eye"></i>View 
                                            </div>
                                        </div>
                                        <div class="col-sm-4 col-xl-3 pt-4">
                                            <div class="input-icon input-icon-sm right">
                                                <label>NOC for Handing over</label>
                                                <i class="bi bi-images b5-icon"></i>
                                                <asp:FileUpload ID="FileUploadNOC" CssClass="form-control input-sm file-upload" accept=".pdf" runat="server" />
                                                <span class="handle-file-request">(upload max file size,pdf-800 KB)</span>
                                                <asp:HiddenField ID="hdnFileUploadNOC" runat="server" />
                                            </div>
                                            <span class="error">
                                                <%--                                                <asp:RequiredFieldValidator ClientIDMode="Static" Display="Dynamic" EnableClientScript="true" SetFocusOnError="true" ControlToValidate="FileUploadNOC" ValidationGroup="val" ID="RequiredFieldValidator15" runat="server" ErrorMessage="Upload NOC for handing over"></asp:RequiredFieldValidator>--%>
                                                <asp:Label ID="lblFileUploadNOC" CssClass="lblFileUpload" runat="server" ForeColor="#d41111" Text=""></asp:Label>

                                            </span>
                                            <div class="btn-view btn-view-pop" clientidmode="Static" runat="server" id="DivNOC" style="display: none">
                                                <i class="bi bi-eye"></i>View 
                                            </div>
                                        </div>
                                        <div class="col-sm-4 col-xl-3 pt-4">
                                            <div class="input-icon input-icon-sm right">
                                                <label>CC Updation</label>
                                                <i class="bi bi-images b5-icon"></i>
                                                <asp:FileUpload ID="FileUploadCCUpdation" CssClass="form-control input-sm file-upload" accept=".pdf" runat="server" />
                                                <span class="handle-file-request">(upload max file size,pdf-800 KB)</span>
                                                <asp:HiddenField ID="hdnFileUploadCCUpdation" runat="server" />
                                            </div>
                                            <span class="error">
                                                <asp:Label ID="lblFileUploadCCUpdation" CssClass="lblFileUpload" runat="server" ForeColor="#d41111" Text=""></asp:Label>
                                                <%--                                                <asp:RequiredFieldValidator ClientIDMode="Static" Display="Dynamic" EnableClientScript="true" SetFocusOnError="true" ControlToValidate="FileUploadCCUpdation" ValidationGroup="val" ID="RequiredFieldValidator16" runat="server" ErrorMessage="Upload CC updation"></asp:RequiredFieldValidator>--%>

                                            </span>
                                            <div class="btn-view btn-view-pop" clientidmode="Static" runat="server" id="DivCCUpdation" style="display: none">
                                                <i class="bi bi-eye"></i>View 
                                            </div>
                                        </div>
                                        <div class="col-sm-4 col-xl-3 pt-4">
                                            <div class="input-icon input-icon-sm right">
                                                <label>Bank Documents</label>
                                                <i class="bi bi-images b5-icon"></i>
                                                <asp:FileUpload ID="FileUploadBankDocuments" CssClass="form-control input-sm file-upload" accept=".pdf" runat="server" />
                                                <span class="handle-file-request">(upload max file size,pdf-800 KB)</span>
                                                <asp:HiddenField ID="hdnFileUploadBankDocuments" runat="server" />
                                            </div>
                                            <span class="error">
                                                <asp:Label ID="lblFileUploadBankDocuments" CssClass="lblFileUpload" runat="server" ForeColor="#d41111" Text=""></asp:Label>
                                                <%--                                                <asp:RequiredFieldValidator ClientIDMode="Static" Display="Dynamic" EnableClientScript="true" SetFocusOnError="true" ControlToValidate="FileUploadBankDocuments" ValidationGroup="val" ID="RequiredFieldValidator17" runat="server" ErrorMessage="Upload bank documents"></asp:RequiredFieldValidator>--%>

                                            </span>
                                            <div class="btn-view btn-view-pop" clientidmode="Static" runat="server" id="DivBankDocuments" style="display: none">
                                                <i class="bi bi-eye"></i>View 
                                            </div>
                                        </div>
                                        <div class="col-sm-4 col-xl-3 pt-4">
                                            <div class="input-icon input-icon-sm right">
                                                <label>Handing Over Documents</label>
                                                <i class="bi bi-images b5-icon"></i>
                                                <asp:FileUpload ID="FileUploadHandingOverDocuments" CssClass="form-control input-sm file-upload" accept=".pdf" runat="server" />
                                                <span class="handle-file-request">(upload max file size,pdf-800 KB)</span>
                                                <asp:HiddenField ID="hdnFileUploadHandingOverDocuments" runat="server" />
                                            </div>
                                            <span class="error">
                                                <asp:Label ID="lblFileUploadHandingOverDocuments" CssClass="lblFileUpload" runat="server" ForeColor="#d41111" Text=""></asp:Label>
                                                <%--                                                <asp:RequiredFieldValidator ClientIDMode="Static" Display="Dynamic" EnableClientScript="true" SetFocusOnError="true" ControlToValidate="FileUploadHandingOverDocuments" ValidationGroup="val" ID="RequiredFieldValidator18" runat="server" ErrorMessage="Upload handing over documents"></asp:RequiredFieldValidator>--%>
                                            </span>
                                            <div class="btn-view btn-view-pop" clientidmode="Static" runat="server" id="DivHandingOverDocuments" style="display: none">
                                                <i class="bi bi-eye"></i>View 
                                            </div>
                                        </div>
                                        <div class="col-sm-4 col-xl-3 pt-4">
                                            <div class="input-icon input-icon-sm right">
                                                <label>Other Documents</label>
                                                <i class="bi bi-images b5-icon"></i>
                                                <asp:FileUpload ID="FileUploadOtherDocuments" CssClass="form-control input-sm file-upload" accept=".pdf" runat="server" />
                                                <span class="handle-file-request">(upload max file size,pdf-800 KB)</span>
                                                <asp:HiddenField ID="hdnFileUploadOtherDocuments" runat="server" />
                                            </div>
                                            <span class="error">
                                                <asp:Label ID="lblFileUploadOtherDocuments" CssClass="lblFileUpload" runat="server" ForeColor="#d41111" Text=""></asp:Label>
                                                <%--                                                <asp:RequiredFieldValidator ClientIDMode="Static" Display="Dynamic" EnableClientScript="true" SetFocusOnError="true" ControlToValidate="FileUploadOtherDocuments" ValidationGroup="val" ID="RequiredFieldValidator19" runat="server" ErrorMessage="Upload other documents"></asp:RequiredFieldValidator>--%>

                                            </span>
                                            <div class="btn-view btn-view-pop" clientidmode="Static" runat="server" id="DivOtherDocuments" style="display: none">
                                                <i class="bi bi-eye"></i>View 
                                            </div>
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
                                    Text="Submit" ValidationGroup="val"
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
        function validatePage() {
            var flag = Page_ClientValidate('val')
            return flag;
        }
    </script>

    <script>
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
                        // You can continue with your customer details submission 
                    }
                });
            });
        });
    </script>

    <script type="text/javascript">
        document.addEventListener('DOMContentLoaded', function () {
            var fileUploaders = document.querySelectorAll('.file-upload');
            var viewLogoBtns = document.querySelectorAll('.btn-view');
            var errorLabels = document.querySelectorAll('.lblFileUpload');
            var screensrc = {};
            var fileType = {};
            var fileTitles = ['Sale Deed Draft', 'Sale Deed Final', 'Sale Agreement Draft', 'Sale Agreement Final', 'Allotment Letter', 'Welcome Letter', 'Demand Letter', 'Payment Receipt', 'Bill', 'Payment Schedule', 'EB card', 'NOC for Handing over', 'CC Updation', 'Bank Documents', 'Handing Over Documents', 'Other Documents'];

            if (!fileUploaders || !viewLogoBtns || !errorLabels) {
                console.error("Required elements not found in the DOM.");
                return;
            }

            fileUploaders.forEach(function (fileUploader, index) {
                // Show file when selected
                fileUploader.addEventListener('change', function (event) {
                    var input = event.target;
                    var file = input.files[0];
                    var validFileTypes = ['application/pdf']; // Only PDF files allowed
                    var isValidFileType = validFileTypes.includes(file.type);
                    var viewLogoBtn = viewLogoBtns[index];
                    var errorLabel = errorLabels[index];
                    fileType[index] = file.type;
                    errorLabel.textContent = ''; // Clear any previous error messages

                    if (!file) {
                        resetUploader(viewLogoBtn, errorLabel, index);
                        errorLabel.textContent = "No file selected.";
                        return;
                    }

                    if (!isValidFileType) {
                        resetUploader(viewLogoBtn, errorLabel, index);
                        errorLabel.textContent = "Invalid file type. Only PDF files are allowed.";
                        return;
                    }

                    if (file.type === 'application/pdf' && file.size > 800 * 1024) {
                        resetUploader(viewLogoBtn, errorLabel, index);
                        errorLabel.textContent = "PDF size must be under 800 KB";
                        return;
                    }

                    var reader = new FileReader();
                    reader.onload = function (e) {
                        screensrc[index] = e.target.result;
                        viewLogoBtn.style.display = 'inline-block'; // Show the view button
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
                    }
                });
            });

            // Reset the uploader
            function resetUploader(viewLogoBtn, errorLabel, index) {
                screensrc[index] = null;
                document.querySelectorAll('.file-upload')[index].value = '';
                viewLogoBtn.style.display = 'none';
                errorLabel.textContent = ''; // Clear error message
            }
        });
    </script>



<script type="text/javascript">
    function bindImageToPreview(srclogo, index, fileType) {
        var viewLogoBtns = document.querySelectorAll('.btn-view');

        if (index !== -1 && viewLogoBtns[index]) {
            var viewLogoBtn = viewLogoBtns[index];

            // Ensure button visibility is set correctly
            viewLogoBtn.style.display = 'inline-block';

            // Attach event listener only once
            viewLogoBtn.removeEventListener('click', handleClick); // Remove any existing listeners
            viewLogoBtn.addEventListener('click', handleClick);

            function handleClick() {
                if (fileType === 'application/pdf') {
                    setButtonStyle(viewLogoBtn); // Pass the actual button element
                    window.open(srclogo, '_blank'); // Open the PDF in a new tab

                    // Reload the page with query string
                    var currentUrl = window.location.href;
                    var newUrl = addQueryStringToUrl(currentUrl);
                    window.location.href = newUrl; // Reload the page with updated URL
                }
            }
        }
    }

    function setButtonStyle(viewLogoBtn) {
        // Apply the style to the passed button element
        viewLogoBtn.style.display = 'inline-block';
    }

    function addQueryStringToUrl(url, queryString) {
        var separator = url.indexOf('?') !== -1 ? '&' : '?';
        return url + separator + queryString;
    }
</script>












</asp:Content>



