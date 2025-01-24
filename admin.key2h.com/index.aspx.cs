using System;
using System.Activities.Statements;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class adminkey2hcomindex : System.Web.UI.Page
{
    ClientDashboardError CI=new ClientDashboardError();
    ClientUsers CU = new ClientUsers();
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void Loginbtn_Click(object sender, EventArgs e)
    {
        string labelerror = string.Empty;

        if (string.IsNullOrEmpty(txtusername.Text) && string.IsNullOrEmpty(txtpassword.Text))
        {
            labelerror = "Fill all the field";
        }
        else if (string.IsNullOrEmpty(txtusername.Text))
        {
            labelerror = "Enter name";
        }
        else if (string.IsNullOrEmpty(txtpassword.Text))
        {
            labelerror = "Enter password";
        }

        if (string.IsNullOrEmpty(labelerror))
        {
            try
            {
                CU.username = txtusername.Text.Trim();
                CU.password = Encrypt(txtpassword.Text.Trim());
                DataTable dt = CU.ViewValidClientUserLogin(CU);
                if (dt.Rows.Count > 0)
                {
                    if (Convert.ToBoolean(dt.Rows[0]["UserStatus"]) ==true)
                    {
                        string username = Convert.ToString(dt.Rows[0]["UserName"]);
                        string password = decrypt(Convert.ToString(dt.Rows[0]["Password"]));
                        int strclientID = Convert.ToInt32(dt.Rows[0]["ClientID"]);
                        string strEmailid = Convert.ToString(dt.Rows[0]["UserEmailID"]);
                        string strname=Convert.ToString(dt.Rows[0]["Name"]);
                        string strRole=Convert.ToString(dt.Rows[0]["Role"]);
                        StringComparer ordCmp = StringComparer.Ordinal;
                        if (string.Equals(password, txtpassword.Text.Trim(), StringComparison.Ordinal) && string.Equals(username.ToLower(), txtusername.Text.Trim().ToLower(), StringComparison.Ordinal))
                        {
                            CreateCookies(strname, strclientID,strEmailid, strRole);
                            FormsAuthentication.SetAuthCookie(txtusername.Text.Trim(), true);
                            Response.Redirect("add-project.aspx", false);
                            HttpContext.Current.ApplicationInstance.CompleteRequest();
                        }
                        else
                        {
                            txtusername.Text = "";
                            labelerror = "Check the username, password combination.";
                            ShowInvalidLoginAlert(labelerror);
                        }
                    }
                    else
                    {
                        labelerror = "Client is not active, pls contact your admin";
                        ShowInvalidLoginAlert(labelerror);
                    }
                }
                else
                {
                    txtusername.Text = "";
                    labelerror = "Check the username, password combination.";
                    ShowInvalidLoginAlert(labelerror);
                }
            }
            catch (Exception ex)
            {
                CI.StoreExceptionMessage("index.aspx", "AddData", ex.Message, "Not Fixed");
            }
        }
        else
        {
            ShowInvalidLoginAlert(labelerror);
        }      
    }





    public string Encrypt(string encrypt)
    {
        string finalencrypt = string.Empty;
        byte[] encode = new byte[encrypt.Length];
        encode = Encoding.UTF8.GetBytes(encrypt);
        finalencrypt = Convert.ToBase64String(encode);
        return finalencrypt;
    }




    public string decrypt(string encryptpswd)
    {
        string strDecrypt = string.Empty;
        UTF8Encoding Encode = new UTF8Encoding();
        Decoder Decod = Encode.GetDecoder();
        byte[] todecode = Convert.FromBase64String(encryptpswd);
        int charcount = Decod.GetCharCount(todecode, 0, todecode.Length);
        char[] chardecode = new char[charcount];
        Decod.GetChars(todecode, 0, todecode.Length, chardecode, 0);

        strDecrypt = new string(chardecode);
        return strDecrypt;
    }










    private void ShowInvalidLoginAlert(string LABELERROR)
    {

        // JavaScript for SweetAlert
        string script = @"
    <script src='https://cdn.jsdelivr.net/npm/sweetalert2@11'></script>
    <script>
        Swal.fire({
    title: 'Invalid Details',
    text: '" + LABELERROR + @"', 
    confirmButtonText: 'OK',
    customClass: {
        popup: 'swal-popup',
        title: 'swal-title',
        content: 'swal-content',
        confirmButton: 'handle-btn-success'  
    }
}).then(function() {  
});

    </script>";

        // CSS to change text color, popup width, and button style
        string css = @"
    <style>
        .swal-content { color: yellow !important; }   
        .swal-title { font-size: 22px !important; }    
    </style>";

        // Register JavaScript and CSS
        Page.ClientScript.RegisterStartupScript(this.GetType(), "SweetAlertCSS", css);
        Page.ClientScript.RegisterStartupScript(this.GetType(), "SweetAlert", script);


    }



    public void CreateCookies(string strUsername, int ClientID,string strEmailID,string Role)
    {
        if (Request.Browser.Cookies)
        {
            HttpCookie LoginCookie = Request.Cookies["CLIENTDASHBOARDLOGIN"];
            HttpCookie EmailidCookie = Request.Cookies["EmailID"];
            HttpCookie LoginIDCookie = Request.Cookies["clientid"];
            HttpCookie UsernameCookie = Request.Cookies["Username"];
            HttpCookie UsernameRole = Request.Cookies["Role"];

            if (LoginCookie == null)
            {
                LoginCookie = new HttpCookie("CLIENTDASHBOARDLOGIN");
            }
            if (EmailidCookie == null)
            {
                EmailidCookie = new HttpCookie("EmailID");
            }
            if (LoginIDCookie == null)
            {
                LoginIDCookie = new HttpCookie("clientid");
            } 
            
            if (UsernameCookie == null)
            {
                UsernameCookie = new HttpCookie("Username");
            }
               
            if (UsernameRole == null)
            {
                UsernameRole = new HttpCookie("Role");
            }

            LoginCookie["CLIENTDASHBOARDLOGIN"] = strUsername.Trim();
            LoginIDCookie["clientid"] = Convert.ToString(ClientID);
            EmailidCookie["EmailID"] = Convert.ToString(strEmailID);
            UsernameCookie["Username"] = Convert.ToString(strUsername);
            UsernameRole["Role"] = Convert.ToString(Role);

            Response.Cookies.Add(LoginCookie);
            Response.Cookies.Add(EmailidCookie);
            Response.Cookies.Add(LoginIDCookie);
            Response.Cookies.Add(UsernameCookie);
            Response.Cookies.Add(UsernameRole);
        }

        Session["CLIENTDASHBOARDLOGIN"] = strUsername.Trim();
        Session["clientid"] = ClientID;
    }


}