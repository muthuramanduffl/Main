using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class adminkey2com_AdminKey2hold : System.Web.UI.MasterPage
{
    ClientUsers CU = new ClientUsers();
    protected void Page_Load(object sender, EventArgs e)
    {


        string stClientID = CU.GetClientLoginID();
        string Stemailid = CU.GetClientLoginEmailID();
        lblrole.Text = CU.GetClientRole().Replace("Role=", "");
        lblloginusername.Text = CU.GetClientLoginUsername().Replace("Username=", "");
        lblloginusermailid.Text = Stemailid.Replace("EmailID=", "");
        if (string.IsNullOrEmpty(stClientID))
            Response.Redirect("Index.aspx");


    }


    protected void lnklogout_Click(object sender, EventArgs e)
    {

        Session.Abandon();


        if (Request.Browser.Cookies)
        {
            if (Request.Cookies["CLIENTDASHBOARDLOGIN"] != null)
            {
                HttpCookie LoginCookie = new HttpCookie("CLIENTDASHBOARDLOGIN");
                LoginCookie.Expires = DateTime.Now.AddDays(-1);
                Response.Cookies.Add(LoginCookie);
            }

            if (Request.Cookies["EmailID"] != null)
            {
                HttpCookie EmailidCookie = new HttpCookie("EmailID");
                EmailidCookie.Expires = DateTime.Now.AddDays(-1);
                Response.Cookies.Add(EmailidCookie);
            }

            if (Request.Cookies["clientid"] != null)
            {
                HttpCookie LoginIDCookie = new HttpCookie("clientid");
                LoginIDCookie.Expires = DateTime.Now.AddDays(-1);
                Response.Cookies.Add(LoginIDCookie);
            } 
            
            if (Request.Cookies["Role"] != null)
            {
                HttpCookie LoginIDCookie = new HttpCookie("Role");
                LoginIDCookie.Expires = DateTime.Now.AddDays(-1);
                Response.Cookies.Add(LoginIDCookie);
            }
            if (Request.Cookies["Username"] != null)
            {
                HttpCookie LoginIDCookie = new HttpCookie("Username");
                LoginIDCookie.Expires = DateTime.Now.AddDays(-1);
                Response.Cookies.Add(LoginIDCookie);
            }
        }

        Response.Redirect("index.aspx", true);
    }
}
