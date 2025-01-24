using System; 
using System.Data; 
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web.Script.Serialization;
using System.Collections.Generic;
using System.Configuration;
using System.Text;

public partial class adminkey2hcom_AddBroadcast : System.Web.UI.Page
{
    Key2hProject k2 = new Key2hProject();
    Key2hProjectbroadcast K2b = new Key2hProjectbroadcast();
    ClientUsers CU = new ClientUsers();
    ClientdashboardIssue CI = new ClientdashboardIssue();

    public static string Userid;
     
    protected void Page_Load(object sender, EventArgs e)
    {
        string clientLoginId = CU.GetClientLoginID();
        if (!string.IsNullOrEmpty(clientLoginId) && clientLoginId.Contains("clientid="))
        {
            Userid = clientLoginId.Replace("clientid=", "");
        }
        else
        { 
            Userid = clientLoginId;
        }
        if (!IsPostBack)
        {
            Bindprojects();
            btnSave.Text = "Send Now";
            lbldisplaytext.Text = "Add Broadcast";
            ddlprojects.Enabled = true; 
        }

    }

    public void Bindprojects()
    {
        DataTable dt = k2.ViewActiveprojects();
        if (dt.Rows.Count > 0)
        {
            ddlprojects.DataSource = dt;
            ddlprojects.DataTextField = "ProjectName";
            ddlprojects.DataValueField = "ProjectID";
            ddlprojects.DataBind();
            ddlprojects.Items.Insert(0, new ListItem("", ""));
            //ddlprojects.SelectedValue = "18";
        }
    }



    protected void btnSave_Click(object sender, EventArgs e)
    {
        string Labelerror = string.Empty;

        if (string.IsNullOrEmpty(ddlprojects.SelectedValue) && string.IsNullOrEmpty(txtMessage.Text))
        {
            Labelerror = "Fill all the field";
        }
        else if (string.IsNullOrEmpty(ddlprojects.SelectedValue))
        {
            Labelerror = "Select project";
        }
        else if (string.IsNullOrEmpty(txtTitle.Text))
        {
            Labelerror = "Enter title";
        }
        else if (string.IsNullOrEmpty(txtMessage.Text))
        {
            Labelerror = "Enter message";
        }
        if (string.IsNullOrEmpty(Labelerror))
        {
            if (AddBroadcast() == 1)
            {
                string apiResponse = NotifyBroadcastAPI();
                lblerrormsg.Text = apiResponse;
                if(!string.IsNullOrEmpty(apiResponse) && apiResponse.Contains("\"success\":true"))
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alert",
                    "Swal.fire({ " + "  title: 'Broadcast details added &<br> Notification sent successfully!', " +
                     "  icon: 'success', " +
                        "  allowOutsideClick: 'true', " +
                        "  customClass: { " +
                        "    icon: 'handle-icon-clr', " +
                        "    confirmButton: 'handle-btn-success' " +
                        "  } " +
                        "}).then((result) => { " +
                        "  window.location.href = '" + Request.Url.AbsolutePath + "'; " +
                        "});", true);
                }
                else
                {
                    // Extract the error message from the API response
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alert",
                    "Swal.fire({ " +"  title: 'Broadcast added, but notification failed to send.', " +  
                    "  customClass: { " + 
                    "    confirmButton: 'handle-btn-error' " +"  } " +"});", true);}
                        // Clear(); 
                    }
                    else
                    { 
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert",
                            "Swal.fire({ " +
                            "  title: 'Broadcast details not added due to a server or network issue', " +
                            "  confirmButtonText: 'OK', " +
                           "  customClass: { " +
                            "      confirmButton: 'handle-btn-success', " +
                            "  }" +
                            "});", true);
                    } 
        }
        else
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "alert",
                "Swal.fire({ " +
                            "  title: '" + Labelerror + "', " +
                           "  confirmButtonText: 'OK', " +
                           "  customClass: { " +
                            "      confirmButton: 'handle-btn-success', " +
                            "  }" +
                            "});", true);
        } 
    }

    protected void btnCancel_Click(object sender, EventArgs e)
    {
        Clear(); 
        if (Request.QueryString["BlockID"] == null)
        {
            //Your action has been canceled. 
        }
        else
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "alert",
            "Swal.fire({ " +
            "   title: 'Broadcast details has been cancelled as requested', " +
            "   confirmButtonText: 'OK', " +
            "   customClass: { " +
            "       confirmButton: 'handle-btn-success' " +
            "   } " +
            "}).then((result) => { " +
            "    window.location.href = '" + Request.Url.AbsolutePath + "'; " +
            "});", true);
        }
    }
     
    public int AddBroadcast()
    {
        K2b.ProjectID = Convert.ToInt32(ddlprojects.SelectedValue);
        K2b.Title = txtTitle.Text; 
        K2b.MessageContent = txtMessage.Text; 
        K2b.Addedby = Userid;
        int ret = 0;
        ret = K2b.AddBroadcast(K2b);
        return ret;
    }
      
    public void Clear()
    {
        ddlprojects.SelectedIndex = 0;
        txtMessage.Text = "";
        Response.Redirect(Request.Url.AbsolutePath);
    }
    private string NotifyBroadcastAPI()
    {
        string apiUrl = "https://dbadmin.key2h.com/api/broadcasts/notify"; // Replace with your API URL
        try
        {
            using (HttpClient client = new HttpClient())
            {
                string username = ConfigurationManager.AppSettings["ApiUsername"];
                string password = ConfigurationManager.AppSettings["ApiPassword"];
                string authHeader = Convert.ToBase64String(Encoding.ASCII.GetBytes(username + ":" + password));
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", authHeader);
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                
                HttpResponseMessage response = client.PostAsync(apiUrl, null).Result;
                if (response.IsSuccessStatusCode)
                {
                    // Log the API response for debugging
                    string apiResponse = response.Content.ReadAsStringAsync().Result;
                    // Pass the API response message to the client-side popup
                    string message = "Notification sent successfully: {apiResponse}";
                    return apiResponse;
                }
                else
                {
                    string errorMessage = "Error: {response.StatusCode} - {response.ReasonPhrase}";
                    // Show error message in the label
                    lblError.Text = errorMessage;
                    return errorMessage;
                }
            }
        }
        catch (Exception ex)
        {
            string exceptionMessage = "Exception: {ex.Message}";
            // Show exception message in the label
            lblError.Text = exceptionMessage;
            return exceptionMessage;
        }
    }

}