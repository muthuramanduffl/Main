<%@ Page Language="C#" AutoEventWireup="true" CodeFile="index.aspx.cs" Inherits="adminkey2hcomindex" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <title>Admin Dashboard | KEY2H</title>
    <meta content='width=device-width, initial-scale=1.0, shrink-to-fit=no' name='viewport' />
    <link rel="icon" href="assets/img/fav-icon.png" type="image/x-icon" />

    <!-- Fonts and icons -->
    <script src="assets/js/plugin/webfont/webfont.min.js"></script>
    <script>
        WebFont.load({
            google: { "families": ["Lato:300,400,700,900"] },
            custom: { "families": ["Flaticon", "Font Awesome 5 Solid", "Font Awesome 5 Regular", "Font Awesome 5 Brands", "simple-line-icons"], urls: ['assets/css/fonts.min.css'] },
            active: function () {
                sessionStorage.fonts = true;
            }
        });
	</script>

    <!-- CSS Files -->
    <link rel="stylesheet" href="assets/css/bootstrap.min.css">
    <link rel="stylesheet" href="assets/css/login-page.css">
    <link rel="stylesheet" href="assets/bootstrap-icons/bootstrap-icons.css">
</head>

<body>
    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" EnableCdn="true" EnablePartialRendering="true" runat="server"></asp:ScriptManager>

        <div class="container">
            <div class="formBox level-login">
                <div class="box boxShaddow"></div>
                <div class="box loginBox">
                    <div class="text-center mb-3">
                        <img src="assets/img/logo.png" alt="img" class="img-fluid" width="200">
                    </div>
                    <h2>LOGIN</h2>
                    <div class="form">
                        <div class="f_row">
                            <label>Username</label>
                            <asp:TextBox ID="txtusername" CssClass="input-field" runat="server"></asp:TextBox>

                            <%-- <input type="text" class="input-field" required>--%>
                            <u></u>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ForeColor="#d41111" ControlToValidate="txtusername" EnableClientScript="true" SetFocusOnError="true" ValidationGroup="Val" runat="server" ErrorMessage="Enter username"></asp:RequiredFieldValidator>
                        </div>
                        <div class="f_row last">
                            <label>Password</label> 
                                <asp:TextBox ID="txtpassword" TextMode="Password" CssClass="input-field" runat="server"></asp:TextBox>
                                <!-- Eye Icon -->
                                <i class="bi bi-eye eye-icon" id="togglePassword"></i>
                            
                            <u></u>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" ForeColor="#d41111" ControlToValidate="txtpassword" EnableClientScript="true" SetFocusOnError="true" ValidationGroup="Val" runat="server" ErrorMessage="Enter password"></asp:RequiredFieldValidator>

                        </div>

                        <asp:LinkButton ID="Loginbtn" OnClick="Loginbtn_Click" ValidationGroup="Val" OnClientClick="if (validatePage()) { this.value='Please wait..'; this.style.display='none'; document.getElementById('bWait').style.display = '';return true; } else { return false; }" CssClass="btn" runat="server">
                            <span>GO</span><u></u>
                            <svg version="1.1" xmlns="http://www.w3.org/2000/svg" xmlns:xlink="http://www.w3.org/1999/xlink" x="0px" y="0px" viewBox="0 0 415.582 415.582" xml:space="preserve">
                                <path d="M411.47,96.426l-46.319-46.32c-5.482-5.482-14.371-5.482-19.853,0L152.348,243.058l-82.066-82.064
c-5.48-5.482-14.37-5.482-19.851,0l-46.319,46.32c-5.482,5.481-5.482,14.37,0,19.852l138.311,138.31
c2.741,2.742,6.334,4.112,9.926,4.112c3.593,0,7.186-1.37,9.926-4.112L411.47,116.277c2.633-2.632,4.111-6.203,4.111-9.925
C415.582,102.628,414.103,99.059,411.47,96.426z" />
                            </svg>

                        </asp:LinkButton>
                       <button type="button" style="display: none" id="bWait" class="btn"><i class='fa fa-spinner fa-spin'></i></button>



                        <div class="f_link">
                            <a href="" class="resetTag">Forgot password?</a>
                        </div>
                    </div>
                </div>
                <div class="box forgetbox">
                    <a href="#" class="back icon-back">
                        <svg version="1.1" id="Capa_1" xmlns="http://www.w3.org/2000/svg" xmlns:xlink="http://www.w3.org/1999/xlink" x="0px" y="0px" viewBox="0 0 199.404 199.404" style="enable-background: new 0 0 199.404 199.404;" xml:space="preserve">
                            <polygon points="199.404,81.529 74.742,81.529 127.987,28.285 99.701,0 0,99.702 99.701,199.404 127.987,171.119 74.742,117.876 
          199.404,117.876 " />
                        </svg>
                    </a>
                    <h2>Reset Password</h2>
                    <form class="form">
                        <p>Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, </p>
                        <div class="f_row last">
                            <label>Email Id</label>
                            <input type="text" class="input-field" required>
                            <u></u>
                        </div>
                        <button class="btn">
                            <span>Reset</span><u></u>
                            <svg version="1.1" xmlns="http://www.w3.org/2000/svg" xmlns:xlink="http://www.w3.org/1999/xlink" x="0px" y="0px" viewBox="0 0 415.582 415.582" xml:space="preserve">
                                <path d="M411.47,96.426l-46.319-46.32c-5.482-5.482-14.371-5.482-19.853,0L152.348,243.058l-82.066-82.064
            c-5.48-5.482-14.37-5.482-19.851,0l-46.319,46.32c-5.482,5.481-5.482,14.37,0,19.852l138.311,138.31
            c2.741,2.742,6.334,4.112,9.926,4.112c3.593,0,7.186-1.37,9.926-4.112L411.47,116.277c2.633-2.632,4.111-6.203,4.111-9.925
            C415.582,102.628,414.103,99.059,411.47,96.426z" />
                            </svg>
                        </button>
                    </form>
                </div>

            </div>
        </div>


        <!--   Core JS Files   -->
        <script src="assets/js/core/jquery.3.2.1.min.js"></script>
        <script src="assets/js/core/bootstrap.min.js"></script>



        <script type="text/javascript">
            function validatePage() {
                // alert("hi");
                var flag = Page_ClientValidate('Val')// window.Page_ClientValidate('projval');
                //alert(flag);
                return flag;
            }
            const passwordInput = document.querySelector("[id$='txtpassword']");
            const togglePassword = document.getElementById("togglePassword");

            togglePassword.addEventListener("click", function () {
                // Toggle the password visibility
                const isPassword = passwordInput.type === "password";
                passwordInput.type = isPassword ? "text" : "password";

                // Toggle the eye icon class
                this.classList.toggle("bi-eye");
                this.classList.toggle("bi-eye-slash");
            });
        </script>

        <script type="text/javascript">
            var inP = $(".input-field");

            // Handle blur and focus events to add/remove focus class
            inP
                .on("blur", function () {
                    if (!this.value) {
                        $(this).parent(".f_row").removeClass("focus");
                    } else {
                        $(this).parent(".f_row").addClass("focus");
                    }
                })
                .on("focus", function () {
                    $(this).parent(".f_row").addClass("focus");
                });

            // Validate text inputs and apply shake effect
            $(".btn").on("click", function () {
                var form = $(this).closest("form"); // Get the closest form element
                var textInputs = form.find("input[type='text']"); // Find only text input fields

                // Validate text input fields
                textInputs.each(function () {
                    if (!$(this).val()) {
                        $(this).parent(".f_row").addClass("shake"); // Add shake class to invalid fields
                    } else {
                        $(this).parent(".f_row").removeClass("shake"); // Remove shake class for valid fields
                    }
                });
            });
        </script>
    </form>
</body>
</html>
