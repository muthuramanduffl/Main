<%@ Page Title="" Language="C#" MasterPageFile="AdminKey2h.master" AutoEventWireup="true" CodeFile="add-flat.aspx.cs" Inherits="adminkey2hcomaddflat" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="content">
        <div class="panel-header bg-primary-gradient">
            <div class="page-inner py-5">
                <div class="d-flex pb-2 align-items-left align-items-sm-center flex-column flex-sm-row justify-content-between">
                    <div class="d-flex">
                        <h2 class="text-white mb-0 fw-bold text-uppercase">
                            <asp:Label ID="lbldisplaymsg" runat="server" Text=""></asp:Label>
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
                                        <h3>Flat Details</h3>
                                    </div>
                                    <div class="row mx-0 margin-top20 mb-4">
                                        <div class="col-sm-4 col-xl-2 pt-3">
                                            <asp:UpdatePanel ID="UpdatePanel1" runat="server" RenderMode="Block" UpdateMode="Conditional" ChildrenAsTriggers="true">
                                                <ContentTemplate>
                                                    <div class="input-icon input-icon-sm right">
                                                        <label>Project Name <span class="text-danger">*</span></label>
                                                        <i class="bi bi-journal-bookmark-fill b5-icon"></i>
                                                        <asp:DropDownList ID="ddlProName" AutoPostBack="true" OnSelectedIndexChanged="ddlProName_SelectedIndexChanged" class="bs-select form-control input-sm" runat="server">
                                                            <asp:ListItem Value="U49">U49</asp:ListItem>
                                                        </asp:DropDownList>
                                                    </div>
                                                    <span class="error">
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ValidationGroup="projval"
                                                            ControlToValidate="ddlProName" InitialValue="" ErrorMessage="Select project name">
                                                        </asp:RequiredFieldValidator>
                                                    </span>
                                                </ContentTemplate>
                                                <Triggers>
                                                    <asp:AsyncPostBackTrigger ControlID="ddlProName" EventName="SelectedIndexChanged" />
                                                    <asp:AsyncPostBackTrigger ControlID="ddlBlockNumber" EventName="SelectedIndexChanged" />
                                                </Triggers>
                                            </asp:UpdatePanel>
                                        </div>

                                        <div class="col-sm-4 col-xl-2 pt-3">
                                            <div class="input-icon input-icon-sm right">
                                                <label>Block Name <span class="text-danger">*</span></label>
                                                <i class="bi bi-building b5-icon"></i>
                                                <asp:UpdatePanel ID="UpdatePanel2" Value="3" runat="server" RenderMode="Block" UpdateMode="Conditional" ChildrenAsTriggers="true">
                                                    <ContentTemplate>
                                                        <asp:DropDownList ID="ddlBlockNumber" AutoPostBack="true" OnSelectedIndexChanged="ddlBlockNumber_SelectedIndexChanged" class="bs-select form-control input-sm" runat="server">
                                                        </asp:DropDownList>
                                                        <span class="error">
                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ValidationGroup="projval"
                                                                ControlToValidate="ddlBlockNumber" InitialValue="" ErrorMessage="Select block name">
                                                            </asp:RequiredFieldValidator>
                                                        </span>
                                                    </ContentTemplate>
                                                    <Triggers>
                                                        <asp:AsyncPostBackTrigger ControlID="ddlProName" EventName="SelectedIndexChanged" />
                                                        <asp:AsyncPostBackTrigger ControlID="ddlBlockNumber" EventName="SelectedIndexChanged" />
                                                    </Triggers>
                                                </asp:UpdatePanel>
                                            </div>
                                        </div>
                                        <div class="col-sm-4 col-xl-2 pt-3">
                                            <asp:UpdatePanel ID="UpdatePanel3" Value="3" runat="server" RenderMode="Block" UpdateMode="Conditional" ChildrenAsTriggers="true">
                                                <ContentTemplate>
                                                    <div class="input-icon input-icon-sm right">
                                                        <label>Flat Number <span class="text-danger">*</span></label>
                                                        <i class="bi bi-file-binary b5-icon"></i>
                                                        <asp:TextBox runat="server" ID="txtUnitNoFlatNo" onkeyup="keyupFunction(this.id)" MaxLength="5" class="form-control input-sm" autocomplete="off" placeholder=""></asp:TextBox>
                                                    </div>
                                                    <span class="error">
                                                        <asp:RequiredFieldValidator ClientIDMode="Static" EnableClientScript="true" SetFocusOnError="true" ControlToValidate="txtUnitNoFlatNo" Display="Dynamic" ValidationGroup="projval" ID="RequiredFieldValidator10" runat="server" ErrorMessage="Enter flat no. "></asp:RequiredFieldValidator>
                                                        <asp:RegularExpressionValidator ClientIDMode="Static" ID="RegularExpressionValidator5" Display="Dynamic" runat="server" ValidationGroup="projval" ControlToValidate="txtUnitNoFlatNo" ValidationExpression="^[A-Za-z0-9\s\-\/]+$" ErrorMessage="Enter valid flat no. "></asp:RegularExpressionValidator>
                                                    </span>
                                                    <span class="handle-file-request">
                                                        <div id="projectValidationMessage"></div>
                                                    </span>
                                                    <!-- <span class="error"> Entered flat no. already exists for this project </span> -->
                                                </ContentTemplate>
                                                <Triggers>
                                                    <asp:AsyncPostBackTrigger ControlID="ddlProName" EventName="SelectedIndexChanged" />
                                                    <asp:AsyncPostBackTrigger ControlID="ddlBlockNumber" EventName="SelectedIndexChanged" />
                                                </Triggers>
                                            </asp:UpdatePanel>
                                        </div>
                                        <div class="col-sm-4 col-xl-2 pt-3">
                                            <div class="input-icon input-icon-sm right">
                                                <label>Floor <span class="text-danger">*</span></label>
                                                <i class="bi bi-bar-chart-steps b5-icon"></i>
                                                <asp:DropDownList ID="ddlFloor" class="bs-select form-control input-sm" runat="server">
                                                    <asp:ListItem Value=""></asp:ListItem>
                                                    <asp:ListItem Value="1">1st Floor</asp:ListItem>
                                                    <asp:ListItem Value="2">2nd Floor</asp:ListItem>
                                                    <asp:ListItem Value="3">3rd Floor</asp:ListItem>
                                                    <asp:ListItem Value="4">4th Floor</asp:ListItem>
                                                    <asp:ListItem Value="5">5th Floor</asp:ListItem>
                                                    <asp:ListItem Value="6">6th Floor</asp:ListItem>
                                                    <asp:ListItem Value="7">7th Floor</asp:ListItem>
                                                    <asp:ListItem Value="8">8th Floor</asp:ListItem>
                                                    <asp:ListItem Value="9">9th Floor</asp:ListItem>
                                                    <asp:ListItem Value="10">10th Floor</asp:ListItem>
                                                </asp:DropDownList>
                                            </div>
                                            <span class="error">
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator11" runat="server" ValidationGroup="projval"
                                                    ControlToValidate="ddlFloor" InitialValue="" ErrorMessage="Select floor">
                                                </asp:RequiredFieldValidator>
                                            </span>
                                        </div>
                                        <div class="col-sm-4 col-xl-2 pt-3">
                                            <div class="input-icon input-icon-sm right">
                                                <label>Facing <span class="text-danger">*</span></label>
                                                <i class="bi bi-arrows-move b5-icon"></i>

                                                <asp:DropDownList ID="ddlfacing" class="bs-select form-control input-sm" runat="server">
                                                    <asp:ListItem Text="" Value="" />
                                                   
                                                </asp:DropDownList>
                                                <%-- <asp:TextBox runat="server" ID="txtFacing" MaxLength="50" class="form-control input-sm capitalize-input" autocomplete="off" placeholder=""></asp:TextBox>--%>
                                            </div>
                                            <span class="error">
                                                <asp:RequiredFieldValidator ClientIDMode="Static" EnableClientScript="true" SetFocusOnError="true" InitialValue="" ControlToValidate="ddlfacing" Display="Dynamic" ValidationGroup="projval" ID="RequiredFieldValidator3" runat="server" ErrorMessage="select facing"></asp:RequiredFieldValidator>
                                                <%--<asp:RegularExpressionValidator ClientIDMode="Static" ID="RegularExpressionValidator1" Display="Dynamic" runat="server" ValidationGroup="projval" ControlToValidate="txtFacing" ValidationExpression="^[A-Za-z\s\-_\/]+$" ErrorMessage="Enter valid facing"></asp:RegularExpressionValidator>--%>
                                            </span>
                                        </div>
                                        <div class="col-sm-4 col-xl-2 pt-3">
                                            <div class="input-icon input-icon-sm right">
                                                <label>UDS <span class="text-danger">*</span></label>
                                                <i class="bi bi-intersect b5-icon"></i>
                                                <asp:TextBox runat="server" ID="txtUDS" MaxLength="10" class="form-control input-sm" autocomplete="off" placeholder=""></asp:TextBox>
                                            </div>
                                            <span class="error">
                                                <asp:RequiredFieldValidator ClientIDMode="Static" EnableClientScript="true" SetFocusOnError="true" ControlToValidate="txtUDS" Display="Dynamic" ValidationGroup="projval" ID="RequiredFieldValidator4" runat="server" ErrorMessage="Enter UDS"></asp:RequiredFieldValidator>
                                                <asp:RegularExpressionValidator ClientIDMode="Static" ID="RegularExpressionValidator3" Display="Dynamic" runat="server" ValidationGroup="projval" ControlToValidate="txtUDS" ValidationExpression="^[0-9.]+$" ErrorMessage="Enter valid UDS"></asp:RegularExpressionValidator>
                                            </span>
                                        </div>
                                        <div class="col-sm-4 col-xl-2 pt-3">
                                            <div class="input-icon input-icon-sm right">
                                                <label>Unit Type <span class="text-danger">*</span></label>
                                                <i class="bi bi-layers-half b5-icon"></i>
<%--                                                <asp:TextBox runat="server" ID="txtUnitType" MaxLength="30" class="bs-select form-control input-sm" autocomplete="off" placeholder=""></asp:TextBox>--%>
                                                <asp:DropDownList ID="ddlUnitType" runat="server" CssClass="form-control">
                                                    <asp:ListItem Text="" Value="" />                                                 
                                                </asp:DropDownList>
                                            </div>
                                            <span class="error">
                                                <asp:RequiredFieldValidator ClientIDMode="Static" EnableClientScript="true" SetFocusOnError="true" ControlToValidate="ddlUnitType" InitialValue="" Display="Dynamic" ValidationGroup="projval" ID="RequiredFieldValidator5" runat="server" ErrorMessage="Select unit type"></asp:RequiredFieldValidator>
<%--                                                <asp:RegularExpressionValidator ClientIDMode="Static" ID="RegularExpressionValidator4" Display="Dynamic" runat="server" ValidationGroup="projval" ControlToValidate="txtUnitType" ValidationExpression="^[A-Za-z0-9\s\-\/]+$" ErrorMessage="Enter valid unit type"></asp:RegularExpressionValidator>--%>
                                            </span>
                                        </div>
                                        <div class="col-sm-4 col-xl-2 pt-3">
                                            <div class="input-icon input-icon-sm right">
                                                <label>Saleable Area <span class="text-danger">*</span></label>
                                                <i class="bi bi-pip b5-icon"></i>
                                                <asp:TextBox runat="server" ID="txtSaleableArea" MaxLength="10" class="form-control input-sm" autocomplete="off" placeholder=""></asp:TextBox>
                                                <span class="handle-file-request">(in sq.ft)</span>
                                            </div>
                                            <span class="error">
                                                <asp:RequiredFieldValidator ClientIDMode="Static" EnableClientScript="true" SetFocusOnError="true" ControlToValidate="txtSaleableArea" Display="Dynamic" ValidationGroup="projval" ID="RequiredFieldValidator6" runat="server" ErrorMessage="Enter saleable area"></asp:RequiredFieldValidator>
                                                <asp:RegularExpressionValidator ClientIDMode="Static" ID="RegularExpressionValidator6" Display="Dynamic" runat="server" ValidationGroup="projval" ControlToValidate="txtSaleableArea" ValidationExpression="^[0-9.]+$" ErrorMessage="Enter valid saleable area"></asp:RegularExpressionValidator>
                                            </span>
                                        </div>
                                        <div class="col-sm-4 col-xl-2 pt-3">
                                            <div class="input-icon input-icon-sm right">
                                                <label>Carpet Area <span class="text-danger">*</span></label>
                                                <i class="bi bi-columns b5-icon"></i>
                                                <asp:TextBox runat="server" ID="txtCarpetArea" MaxLength="10" class="form-control input-sm" autocomplete="off" placeholder=""></asp:TextBox>
                                                <span class="handle-file-request">(in sq.ft)</span>
                                            </div>
                                            <span class="error">
                                                <asp:RequiredFieldValidator ClientIDMode="Static" EnableClientScript="true" SetFocusOnError="true" ControlToValidate="txtCarpetArea" Display="Dynamic" ValidationGroup="projval" ID="RequiredFieldValidator7" runat="server" ErrorMessage="Enter carpet area"></asp:RequiredFieldValidator>
                                                <asp:RegularExpressionValidator ClientIDMode="Static" ID="RegularExpressionValidator7" Display="Dynamic" runat="server" ValidationGroup="projval" ControlToValidate="txtCarpetArea" ValidationExpression="^[0-9.]+$" ErrorMessage="Enter valid carpet area"></asp:RegularExpressionValidator>
                                            </span>
                                        </div>
                                        <div class="col-sm-4 col-xl-2 pt-3">
                                            <div class="input-icon input-icon-sm right">
                                                <label>Balcony <span class="text-danger">*</span></label>
                                                <i class="bi bi-border-all b5-icon"></i>
                                                <asp:TextBox runat="server" ID="txtBalcony" MaxLength="10" class="form-control input-sm" autocomplete="off" placeholder=""></asp:TextBox>
                                                <span class="handle-file-request">(in sq.ft)</span>
                                            </div>
                                            <span class="error">
                                                <asp:RequiredFieldValidator ClientIDMode="Static" EnableClientScript="true" SetFocusOnError="true" ControlToValidate="txtBalcony" Display="Dynamic" ValidationGroup="projval" ID="RequiredFieldValidator8" runat="server" ErrorMessage="Enter balcony"></asp:RequiredFieldValidator>
                                                <asp:RegularExpressionValidator ClientIDMode="Static" ID="RegularExpressionValidator8" Display="Dynamic" runat="server" ValidationGroup="projval" ControlToValidate="txtBalcony" ValidationExpression="^[0-9.]+$" ErrorMessage="Enter valid balcony"></asp:RegularExpressionValidator>
                                            </span>
                                        </div>
                                        <div class="col-sm-4 col-xl-2 pt-3">
                                            <div class="input-icon input-icon-sm right">
                                                <label>Wall Area <span class="text-danger">*</span></label>
                                                <i class="bi bi-bricks b5-icon"></i>
                                                <asp:TextBox runat="server" ID="txtWallArea" MaxLength="10" class="form-control input-sm" autocomplete="off" placeholder=""></asp:TextBox>
                                                <span class="handle-file-request">(in sq.ft)</span>
                                            </div>
                                            <span class="error">
                                                <asp:RequiredFieldValidator ClientIDMode="Static" EnableClientScript="true" SetFocusOnError="true" ControlToValidate="txtWallArea" Display="Dynamic" ValidationGroup="projval" ID="RequiredFieldValidator9" runat="server" ErrorMessage="Enter wall area"></asp:RequiredFieldValidator>
                                                <asp:RegularExpressionValidator ClientIDMode="Static" ID="RegularExpressionValidator9" Display="Dynamic" runat="server" ValidationGroup="projval" ControlToValidate="txtWallArea" ValidationExpression="^[0-9.]+$" ErrorMessage="Enter valid wall area"></asp:RegularExpressionValidator>
                                            </span>
                                        </div>

                                        <div class="col-sm-4 col-xl-3 pt-3">
                                            <div class="input-icon input-icon-sm right">
                                                <label>No. of Car Parking Slots <span class="text-danger">*</span></label>
                                                <i class="bi bi-car-front b5-icon"></i>
                                                <asp:DropDownList ID="ddlNoOfCarParking" class="bs-select form-control input-sm" runat="server">
                                                    <asp:ListItem Value=""></asp:ListItem>
                                                    <asp:ListItem Value="1">1</asp:ListItem>
                                                    <asp:ListItem Value="2">2</asp:ListItem>
                                                    <asp:ListItem Value="3">3</asp:ListItem>
                                                </asp:DropDownList>
                                            </div>
                                            <span class="error">
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator12" runat="server" ValidationGroup="projval"
                                                    ControlToValidate="ddlNoOfCarParking" InitialValue="" ErrorMessage="Select no. of car parking">
                                                </asp:RequiredFieldValidator>
                                            </span>
                                        </div>
                                        <div class="col-sm-4 col-xl-2 pt-3" runat="server" clientidmode="Static" id="divcarp1" style="display: none">
                                            <div class="input-icon input-icon-sm right">
                                                <label>Car Parking Slot 1<span class="text-danger"></span></label>
                                                <i class="bi bi-car-front b5-icon"></i>
                                                <asp:TextBox runat="server" ID="txtcarparking1" MaxLength="4" class="form-control input-sm" autocomplete="off" placeholder=""></asp:TextBox>

                                            </div>
                                            <span class="error">
                                                <asp:RequiredFieldValidator ClientIDMode="Static" EnableClientScript="true" SetFocusOnError="true" ControlToValidate="txtcarparking1" ValidationExpression="^[A-Za-z0-9\-]+$" Display="Dynamic" ValidationGroup="projval" ID="RequiredFieldValidator13" runat="server" ErrorMessage="Enter car parking slot 1"></asp:RequiredFieldValidator>

                                            </span>
                                        </div>
                                        <div class="col-sm-4 col-xl-2 pt-3" runat="server" clientidmode="Static" id="divcarp2" style="display: none">
                                            <div class="input-icon input-icon-sm right">
                                                <label>Car Parking Slot 2<span class="text-danger"></span></label>
                                                <i class="bi bi-car-front b5-icon"></i>
                                                <asp:TextBox runat="server" ID="txtcarparking2" MaxLength="4" class="form-control input-sm" autocomplete="off" placeholder=""></asp:TextBox>

                                            </div>
                                            <span class="error">
                                                <asp:RequiredFieldValidator ClientIDMode="Static" EnableClientScript="true" SetFocusOnError="true" ControlToValidate="txtcarparking2" ValidationExpression="^[A-Za-z0-9\-]+$" Display="Dynamic" ValidationGroup="projval" ID="RequiredFieldValidator14" runat="server" ErrorMessage="Enter car parking slot 2"></asp:RequiredFieldValidator>
                                            </span>
                                        </div>
                                        <div class="col-sm-4 col-xl-2 pt-3" runat="server" clientidmode="Static" id="divcarp3" style="display: none">
                                            <div class="input-icon input-icon-sm right">
                                                <label>Car Parking Slot 3<span class="text-danger"></span></label>
                                                <i class="bi bi-car-front b5-icon"></i>
                                                <asp:TextBox runat="server" ID="txtcarparking3" MaxLength="4" class="form-control input-sm" autocomplete="off" placeholder=""></asp:TextBox>
                                            </div>
                                            <span class="error">
                                                <asp:RequiredFieldValidator ClientIDMode="Static" EnableClientScript="true" SetFocusOnError="true" ControlToValidate="txtcarparking3" ValidationExpression="^[A-Za-z0-9\-]+$" Display="Dynamic" ValidationGroup="projval" ID="RequiredFieldValidator15" runat="server" ErrorMessage="Enter car parking slot 3"></asp:RequiredFieldValidator>
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
                Powered by <a class="text-uppercase" href="https://duffldigital.com/" target="_blank">Duffl
          Digital</a>
            </div>
        </div>
    </footer>

    <script>
        Sys.Application.add_load(function () {
            var dropdown = document.getElementById('<%= ddlNoOfCarParking.ClientID %>');
            var req1 = document.getElementById('<%= RequiredFieldValidator13.ClientID %>');
            var req2 = document.getElementById('<%= RequiredFieldValidator14.ClientID %>');
            var req3 = document.getElementById('<%= RequiredFieldValidator15.ClientID %>');
            var divcarp1 = document.getElementById('<%= divcarp1.ClientID %>');
            var divcarp2 = document.getElementById('<%= divcarp2.ClientID %>');
            var divcarp3 = document.getElementById('<%= divcarp3.ClientID %>');

            // Add an onchange event listener
            dropdown.addEventListener('change', function () {
                var selectedValue = dropdown.value; // Get the selected value 
                if (selectedValue === "1") {
                    divcarp1.style.display = 'block';
                    divcarp2.style.display = 'none';
                    divcarp3.style.display = 'none';
                    ValidatorEnable(req1, true);
                    ValidatorEnable(req2, false);
                    ValidatorEnable(req3, false);
                } else if (selectedValue === "2") {
                    divcarp1.style.display = 'block';
                    divcarp2.style.display = 'block';
                    divcarp3.style.display = 'none';
                    ValidatorEnable(req1, true);
                    ValidatorEnable(req2, true);
                    ValidatorEnable(req3, false);
                } else if (selectedValue === "3") {
                    divcarp1.style.display = 'block';
                    divcarp2.style.display = 'block';
                    divcarp3.style.display = 'block';
                    ValidatorEnable(req1, true);
                    ValidatorEnable(req2, true);
                    ValidatorEnable(req3, true);
                } else {
                    // Hide all divs if no valid selection
                    divcarp1.style.display = 'none';
                    divcarp2.style.display = 'none';
                    divcarp3.style.display = 'none';
                    ValidatorEnable(req1, false);
                    ValidatorEnable(req2, false);
                    ValidatorEnable(req3, false);
                }
            });
        });
    </script>

    <script>
        function validatePage() {
            var flag = window.Page_ClientValidate('projval');
            var dropdown = document.getElementById('<%= ddlNoOfCarParking.ClientID %>');
            var req1 = document.getElementById('<%= RequiredFieldValidator13.ClientID %>');
            var req2 = document.getElementById('<%= RequiredFieldValidator14.ClientID %>');
            var req3 = document.getElementById('<%= RequiredFieldValidator15.ClientID %>');
            var selectedValue = dropdown.value;
            if (selectedValue === "1") {
                //alert("hi");
                document.getElementById('divcarp1').style.display = 'block';
                document.getElementById('divcarp2').style.display = 'none';
                document.getElementById('divcarp3').style.display = 'none';

                req1.style.display = 'block';
                ValidatorEnable(req1, true);

                req2.style.display = 'none';
                ValidatorEnable(req2, false);

                req3.style.display = 'none';
                ValidatorEnable(req3, false);

            } else if (selectedValue === "2") {
                document.getElementById('divcarp2').style.display = 'block';
                document.getElementById('divcarp1').style.display = 'block';
                document.getElementById('divcarp3').style.display = 'none';

                req1.style.display = 'block';
                ValidatorEnable(req1, true);

                req2.style.display = 'block';
                ValidatorEnable(req2, true);

                req3.style.display = 'none';
                ValidatorEnable(req3, false);

            } else if (selectedValue === "3") {
                document.getElementById('divcarp3').style.display = 'block';
                document.getElementById('divcarp1').style.display = 'block';
                document.getElementById('divcarp2').style.display = 'block';

                req1.style.display = 'block';
                ValidatorEnable(req1, true);

                req2.style.display = 'block';
                ValidatorEnable(req2, true);

                req3.style.display = 'block';
                ValidatorEnable(req3, true);
            } else {

                document.getElementById('divcarp1').style.display = 'none';
                document.getElementById('divcarp2').style.display = 'none';
                document.getElementById('divcarp3').style.display = 'none';

                req1.style.display = 'none';
                ValidatorEnable(req1, false);

                req2.style.display = 'none';
                ValidatorEnable(req2, false);

                req3.style.display = 'none';
                ValidatorEnable(req3, false);
            }
            return flag;
        }

        document.getElementById('<%= txtUnitNoFlatNo.ClientID %>').addEventListener('keypress', function (e) {
            if (!/^[A-Za-z0-9\s\-\/]+$/.test(e.key)) {
                e.preventDefault();
            }
        });
        document.getElementById('<%= txtUDS.ClientID %>').addEventListener('keypress', function (e) {
            if (!/^[0-9.]+$/.test(e.key)) {
                e.preventDefault();
            }
        });
        <%--document.getElementById('<%= txtFacing.ClientID %>').addEventListener('keypress', function (e) {
            if (!/^[A-Za-z\s\-_\/]+$/.test(e.key)) {
                e.preventDefault();
            }
        });
        document.getElementById('<%= txtUnitType.ClientID %>').addEventListener('keypress', function (e) {
            if (!/^[A-Za-z0-9\s./]+$/.test(e.key)) {
                e.preventDefault();
            }
        });--%>
        document.getElementById('<%= txtSaleableArea.ClientID %>').addEventListener('keypress', function (e) {
            if (!/^[0-9.]+$/.test(e.key)) {
                e.preventDefault();
            }
        });
        document.getElementById('<%= txtCarpetArea.ClientID %>').addEventListener('keypress', function (e) {
            if (!/^[0-9.]+$/.test(e.key)) {
                e.preventDefault();
            }
        });
        document.getElementById('<%= txtBalcony.ClientID %>').addEventListener('keypress', function (e) {
            if (!/^[0-9.]+$/.test(e.key)) {
                e.preventDefault();
            }
        });
        document.getElementById('<%= txtWallArea.ClientID %>').addEventListener('keypress', function (e) {
            if (!/^[0-9.]+$/.test(e.key)) {
                e.preventDefault();
            }
        });
        document.getElementById('<%= txtcarparking1.ClientID %>').addEventListener('keypress', function (e) {
            if (!/^[A-Za-z0-9\-]+$/.test(e.key)) {
                e.preventDefault();
            }
        });
        document.getElementById('<%= txtcarparking2.ClientID %>').addEventListener('keypress', function (e) {
            if (!/^[A-Za-z0-9\-]+$/.test(e.key)) {
                e.preventDefault();
            }
        });
        document.getElementById('<%= txtcarparking3.ClientID %>').addEventListener('keypress', function (e) {
            if (!/^[A-Za-z0-9\-]+$/.test(e.key)) {
                e.preventDefault();
            }
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
                        // You can continue with your flat details submission 
                    }
                });
            });
        });
    </script>

    <script type="text/javascript">
        function keyupFunction(inputId) {
            var projectName = $('#' + inputId).val();
            var messageDiv = $('#projectValidationMessage');
            var dropdownprojectname = document.getElementById('<%= ddlProName.ClientID %>');
            var dropdownblocknumber = document.getElementById('<%= ddlBlockNumber.ClientID %>');
            var txtflatno = document.getElementById('<%= txtUnitNoFlatNo.ClientID %>').value;
            var projectName = parseInt(dropdownprojectname.value, 10);
            var blockNumber = parseInt(dropdownblocknumber.value, 10);

            $.ajax({
                type: "POST",
                url: "add-flat.aspx/CheckProjectExistence",
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                data: JSON.stringify({

                    projectName: projectName,
                    blockNumber: blockNumber,
                    txtflatno: txtflatno
                }),
                success: function (response) {
                    if (response.d === true) {
                        messageDiv.text("Flat number already exists").css("color", "#d41111");
                    } else {
                        messageDiv.text("");
                        //messageDiv.text("Project name is not exist to the client.").css("color", "green");
                    }
                },
                error: function (xhr) {
                    //console.error("An error occurred: " + xhr.responseText);
                    //messageDiv.text("Error occurred while checking project name.").css("color", "red");

                }
            });
            //} else {
            //    messageDiv.text("Invalid ClientID.").css("color", "red");
            //}
        }
    </script>
</asp:Content>

