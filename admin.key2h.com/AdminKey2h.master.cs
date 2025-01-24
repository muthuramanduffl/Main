using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class adminkey2com_AdminKey2h : System.Web.UI.MasterPage
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
        string currentPage = Request.Url.AbsolutePath.ToLower();
        if (currentPage.Contains("add-project.aspx"))
        {
            tabProjects.Attributes["class"] = "nav-link active";
            subMenuAddProject.Attributes["class"] = "active";
            tab1.Attributes["class"] = "tab-pane fade active show";
            tab2.Attributes["class"] = "tab-pane fade";
            tab3.Attributes["class"] = "tab-pane fade";
            tab4.Attributes["class"] = "tab-pane fade";
            tab21.Attributes["class"] = "tab-pane fade";
        }
        else if (currentPage.Contains("view-project.aspx"))
        {
            tabProjects.Attributes["class"] = "nav-link active";
            subMenuViewProject.Attributes["class"] = "active";
            tab1.Attributes["class"] = "tab-pane fade active show";
            tab2.Attributes["class"] = "tab-pane fade";
            tab3.Attributes["class"] = "tab-pane fade";
            tab4.Attributes["class"] = "tab-pane fade";
            tab21.Attributes["class"] = "tab-pane fade";
        }
        else if (currentPage.Contains("view-project.aspx"))
        {
            tabProjects.Attributes["class"] = "nav-link active";
            subMenuViewProject.Attributes["class"] = "active";
            tab1.Attributes["class"] = "tab-pane fade active show";
            tab2.Attributes["class"] = "tab-pane fade";
            tab3.Attributes["class"] = "tab-pane fade";
            tab4.Attributes["class"] = "tab-pane fade";
            tab21.Attributes["class"] = "tab-pane fade";
        }
        else if (currentPage.Contains("view-project.aspx"))
        {
            tabProjects.Attributes["class"] = "nav-link active";
            subMenuViewProject.Attributes["class"] = "active";
            tab1.Attributes["class"] = "tab-pane fade active show";
            tab2.Attributes["class"] = "tab-pane fade";
            tab3.Attributes["class"] = "tab-pane fade";
            tab4.Attributes["class"] = "tab-pane fade";
            tab21.Attributes["class"] = "tab-pane fade";
        }
        else if (currentPage.Contains("view-project.aspx"))
        {
            tabProjects.Attributes["class"] = "nav-link active";
            subMenuViewProject.Attributes["class"] = "active";
            tab1.Attributes["class"] = "tab-pane fade active show";
            tab2.Attributes["class"] = "tab-pane fade";
            tab3.Attributes["class"] = "tab-pane fade";
            tab4.Attributes["class"] = "tab-pane fade";
            tab21.Attributes["class"] = "tab-pane fade";
        }
        else if (currentPage.Contains("view-project.aspx"))
        {
            tabProjects.Attributes["class"] = "nav-link active";
            subMenuViewProject.Attributes["class"] = "active";
            tab1.Attributes["class"] = "tab-pane fade active show";
            tab2.Attributes["class"] = "tab-pane fade";
            tab3.Attributes["class"] = "tab-pane fade";
            tab4.Attributes["class"] = "tab-pane fade";
            tab21.Attributes["class"] = "tab-pane fade";
        }
        else if (currentPage.Contains("view-project.aspx"))
        {
            tabProjects.Attributes["class"] = "nav-link active";
            subMenuViewProject.Attributes["class"] = "active";
            tab1.Attributes["class"] = "tab-pane fade active show";
            tab2.Attributes["class"] = "tab-pane fade";
            tab3.Attributes["class"] = "tab-pane fade";
            tab4.Attributes["class"] = "tab-pane fade";
            tab21.Attributes["class"] = "tab-pane fade";
        }
        else if (currentPage.Contains("add-block.aspx"))
        {
            tabProjects.Attributes["class"] = "nav-link active";
            subMenuAddBlock.Attributes["class"] = "active";
            tab1.Attributes["class"] = "tab-pane fade active show";
            tab2.Attributes["class"] = "tab-pane fade";
            tab3.Attributes["class"] = "tab-pane fade";
            tab4.Attributes["class"] = "tab-pane fade";
            tab21.Attributes["class"] = "tab-pane fade";
        }
        else if (currentPage.Contains("view-block.aspx"))
        {
            tabProjects.Attributes["class"] = "nav-link active";
            subMenuViewBlock.Attributes["class"] = "active";
            tab1.Attributes["class"] = "tab-pane fade active show";
            tab2.Attributes["class"] = "tab-pane fade";
            tab3.Attributes["class"] = "tab-pane fade";
            tab4.Attributes["class"] = "tab-pane fade";
            tab21.Attributes["class"] = "tab-pane fade";
        }
        else if (currentPage.Contains("add-flat.aspx"))
        {
            tabProjects.Attributes["class"] = "nav-link active";
            subMenuAddFlat.Attributes["class"] = "active";
            tab1.Attributes["class"] = "tab-pane fade active show";
            tab2.Attributes["class"] = "tab-pane fade";
            tab3.Attributes["class"] = "tab-pane fade";
            tab4.Attributes["class"] = "tab-pane fade";
            tab21.Attributes["class"] = "tab-pane fade";
        }
        else if (currentPage.Contains("view-flat.aspx"))
        {
            tabProjects.Attributes["class"] = "nav-link active";
            subMenuViewFlat.Attributes["class"] = "active";
            tab1.Attributes["class"] = "tab-pane fade active show";
            tab2.Attributes["class"] = "tab-pane fade";
            tab3.Attributes["class"] = "tab-pane fade";
            tab4.Attributes["class"] = "tab-pane fade";
            tab21.Attributes["class"] = "tab-pane fade";
        }
        else if (currentPage.Contains("add-flat.aspx"))
        {
            tabProjects.Attributes["class"] = "nav-link active";
            subMenuAddFlat.Attributes["class"] = "active";
            tab1.Attributes["class"] = "tab-pane fade active show";
            tab2.Attributes["class"] = "tab-pane fade";
            tab3.Attributes["class"] = "tab-pane fade";
            tab4.Attributes["class"] = "tab-pane fade";
            tab21.Attributes["class"] = "tab-pane fade";
        }
        else if (currentPage.Contains("view-flat.aspx"))
        {
            tabProjects.Attributes["class"] = "nav-link active";
            subMenuViewFlat.Attributes["class"] = "active";
            tab1.Attributes["class"] = "tab-pane fade active show";
            tab2.Attributes["class"] = "tab-pane fade";
            tab3.Attributes["class"] = "tab-pane fade";
            tab4.Attributes["class"] = "tab-pane fade";
            tab21.Attributes["class"] = "tab-pane fade";
        }

        else if (currentPage.Contains("flatbulkupload.aspx"))
        {
            tabProjects.Attributes["class"] = "nav-link active";
            subMenuBulkFlat.Attributes["class"] = "active";
            tab1.Attributes["class"] = "tab-pane fade active show";
            tab2.Attributes["class"] = "tab-pane fade";
            tab3.Attributes["class"] = "tab-pane fade";
            tab4.Attributes["class"] = "tab-pane fade";
            tab21.Attributes["class"] = "tab-pane fade";
        }
        else if (currentPage.Contains("add-project-progress.aspx"))
        {
            tabConstructionUpdates.Attributes["class"] = "nav-link active";
            subMenuAddPP.Attributes["class"] = "active";
            tab21.Attributes["class"] = "tab-pane fade active show";
            tab2.Attributes["class"] = "tab-pane fade";
            tab3.Attributes["class"] = "tab-pane fade";
            tab4.Attributes["class"] = "tab-pane fade";
            tab1.Attributes["class"] = "tab-pane fade";
        }
        else if (currentPage.Contains("view-project-progress.aspx"))
        {
            tabConstructionUpdates.Attributes["class"] = "nav-link active";
            subMenuViewPP.Attributes["class"] = "active";
            tab21.Attributes["class"] = "tab-pane fade active show";
            tab2.Attributes["class"] = "tab-pane fade";
            tab3.Attributes["class"] = "tab-pane fade";
            tab4.Attributes["class"] = "tab-pane fade";
            tab1.Attributes["class"] = "tab-pane fade";
        }
        else if (currentPage.Contains("add-flat-progress.aspx"))
        {
            tabConstructionUpdates.Attributes["class"] = "nav-link active";
            subMenuAddFPro.Attributes["class"] = "active";
            tab21.Attributes["class"] = "tab-pane fade active show";
            tab2.Attributes["class"] = "tab-pane fade";
            tab3.Attributes["class"] = "tab-pane fade";
            tab4.Attributes["class"] = "tab-pane fade";
            tab1.Attributes["class"] = "tab-pane fade";
        }
        else if (currentPage.Contains("view-flat-progress.aspx"))
        {
            tabConstructionUpdates.Attributes["class"] = "nav-link active";
            subMenuViewFPro.Attributes["class"] = "active";
            tab21.Attributes["class"] = "tab-pane fade active show";
            tab2.Attributes["class"] = "tab-pane fade";
            tab3.Attributes["class"] = "tab-pane fade";
            tab4.Attributes["class"] = "tab-pane fade";
            tab1.Attributes["class"] = "tab-pane fade";
        }

        else if (currentPage.Contains("add-cost-details.aspx"))
        {
            tabFlatBooking.Attributes["class"] = "nav-link active";
            subMenuAddCostDetails.Attributes["class"] = "active";
            tab2.Attributes["class"] = "tab-pane fade active show";
            tab1.Attributes["class"] = "tab-pane fade";
            tab3.Attributes["class"] = "tab-pane fade";
            tab4.Attributes["class"] = "tab-pane fade";
            tab21.Attributes["class"] = "tab-pane fade";
        }
        else if (currentPage.Contains("view-cost-details.aspx"))
        {
            tabFlatBooking.Attributes["class"] = "nav-link active";
            subMenuViewCostDetails.Attributes["class"] = "active";
            tab2.Attributes["class"] = "tab-pane fade active show";
            tab1.Attributes["class"] = "tab-pane fade";
            tab3.Attributes["class"] = "tab-pane fade";
            tab4.Attributes["class"] = "tab-pane fade";
            tab21.Attributes["class"] = "tab-pane fade";
        }
        else if (currentPage.Contains("add-flat-booking.aspx"))
        {
            tabFlatBooking.Attributes["class"] = "nav-link active";
            subMenuAddFB.Attributes["class"] = "active";
            tab2.Attributes["class"] = "tab-pane fade active show";
            tab1.Attributes["class"] = "tab-pane fade";
            tab3.Attributes["class"] = "tab-pane fade";
            tab4.Attributes["class"] = "tab-pane fade";
            tab21.Attributes["class"] = "tab-pane fade";
        }
        else if (currentPage.Contains("view-flat-booking.aspx"))
        {
            tabFlatBooking.Attributes["class"] = "nav-link active";
            subMenuViewFB.Attributes["class"] = "active";
            tab2.Attributes["class"] = "tab-pane fade active show";
            tab1.Attributes["class"] = "tab-pane fade";
            tab3.Attributes["class"] = "tab-pane fade";
            tab4.Attributes["class"] = "tab-pane fade";
            tab21.Attributes["class"] = "tab-pane fade";
        }
        else if (currentPage.Contains("add-payment-schedule.aspx"))
        {
            tabFlatBooking.Attributes["class"] = "nav-link active";
            subMenuAddPS.Attributes["class"] = "active";
            tab2.Attributes["class"] = "tab-pane fade active show";
            tab1.Attributes["class"] = "tab-pane fade";
            tab3.Attributes["class"] = "tab-pane fade";
            tab4.Attributes["class"] = "tab-pane fade";
            tab21.Attributes["class"] = "tab-pane fade";
        }
        else if (currentPage.Contains("view-payment-schedule.aspx"))
        {
            tabFlatBooking.Attributes["class"] = "nav-link active";
            subMenuViewPS.Attributes["class"] = "active";
            tab2.Attributes["class"] = "tab-pane fade active show";
            tab1.Attributes["class"] = "tab-pane fade";
            tab3.Attributes["class"] = "tab-pane fade";
            tab4.Attributes["class"] = "tab-pane fade";
            tab21.Attributes["class"] = "tab-pane fade";
        }
        else if (currentPage.Contains("add-kyc-docs.aspx"))
        {
            tabFlatBooking.Attributes["class"] = "nav-link active";
            subMenuAddKYC.Attributes["class"] = "active";
            tab2.Attributes["class"] = "tab-pane fade active show";
            tab1.Attributes["class"] = "tab-pane fade";
            tab3.Attributes["class"] = "tab-pane fade";
            tab4.Attributes["class"] = "tab-pane fade";
            tab21.Attributes["class"] = "tab-pane fade";
        }
        else if (currentPage.Contains("view-kyc-docs.aspx"))
        {
            tabFlatBooking.Attributes["class"] = "nav-link active";
            subMenuViewKYC.Attributes["class"] = "active";
            tab2.Attributes["class"] = "tab-pane fade active show";
            tab1.Attributes["class"] = "tab-pane fade";
            tab3.Attributes["class"] = "tab-pane fade";
            tab4.Attributes["class"] = "tab-pane fade";
            tab21.Attributes["class"] = "tab-pane fade";
        }
        else if (currentPage.Contains("add-payment-transaction.aspx"))
        {
            tabFlatBooking.Attributes["class"] = "nav-link active";
            subMenuAddPT.Attributes["class"] = "active";
            tab2.Attributes["class"] = "tab-pane fade active show";
            tab1.Attributes["class"] = "tab-pane fade";
            tab3.Attributes["class"] = "tab-pane fade";
            tab4.Attributes["class"] = "tab-pane fade";
            tab21.Attributes["class"] = "tab-pane fade";
        }
        else if (currentPage.Contains("view-payment-transaction.aspx"))
        {
            tabFlatBooking.Attributes["class"] = "nav-link active";
            subMenuViewPT.Attributes["class"] = "active";
            tab2.Attributes["class"] = "tab-pane fade active show";
            tab1.Attributes["class"] = "tab-pane fade";
            tab3.Attributes["class"] = "tab-pane fade";
            tab4.Attributes["class"] = "tab-pane fade";
            tab21.Attributes["class"] = "tab-pane fade";
        }
        else if (currentPage.Contains("add-demand.aspx"))
        {
            tabFlatBooking.Attributes["class"] = "nav-link active";
            subMenuAddD.Attributes["class"] = "active";
            tab2.Attributes["class"] = "tab-pane fade active show";
            tab1.Attributes["class"] = "tab-pane fade";
            tab3.Attributes["class"] = "tab-pane fade";
            tab4.Attributes["class"] = "tab-pane fade";
            tab21.Attributes["class"] = "tab-pane fade";
        }
        else if (currentPage.Contains("view-demand.aspx"))
        {
            tabFlatBooking.Attributes["class"] = "nav-link active";
            subMenuViewD.Attributes["class"] = "active";
            tab2.Attributes["class"] = "tab-pane fade active show";
            tab1.Attributes["class"] = "tab-pane fade";
            tab3.Attributes["class"] = "tab-pane fade";
            tab4.Attributes["class"] = "tab-pane fade";
            tab21.Attributes["class"] = "tab-pane fade";
        }
        else if (currentPage.Contains("view-CostPaymentDetails.aspx"))
        {
            tabFlatBooking.Attributes["class"] = "nav-link active";
            subCostPaymentDetails.Attributes["class"] = "active";
            tab2.Attributes["class"] = "tab-pane fade active show";
            tab1.Attributes["class"] = "tab-pane fade";
            tab3.Attributes["class"] = "tab-pane fade";
            tab4.Attributes["class"] = "tab-pane fade";
            tab21.Attributes["class"] = "tab-pane fade";
        }

        else if (currentPage.Contains("add-customization-work.aspx"))
        {
            tabCust.Attributes["class"] = "nav-link active";
            subMenuAddCW.Attributes["class"] = "active";
            tab3.Attributes["class"] = "tab-pane fade active show";
            tab1.Attributes["class"] = "tab-pane fade";
            tab4.Attributes["class"] = "tab-pane fade";
            tab2.Attributes["class"] = "tab-pane fade";
            tab21.Attributes["class"] = "tab-pane fade";
        }
        else if (currentPage.Contains("view-customization-work.aspx"))
        {
            tabCust.Attributes["class"] = "nav-link active";
            subMenuViewCW.Attributes["class"] = "active";
            tab3.Attributes["class"] = "tab-pane fade active show";
            tab1.Attributes["class"] = "tab-pane fade";
            tab4.Attributes["class"] = "tab-pane fade";
            tab2.Attributes["class"] = "tab-pane fade";
            tab21.Attributes["class"] = "tab-pane fade";
        }
        else if (currentPage.Contains("add-customization-demand.aspx"))
        {
            tabCust.Attributes["class"] = "nav-link active";
            subMenuAddCD.Attributes["class"] = "active";
            tab3.Attributes["class"] = "tab-pane fade active show";
            tab1.Attributes["class"] = "tab-pane fade";
            tab4.Attributes["class"] = "tab-pane fade";
            tab2.Attributes["class"] = "tab-pane fade";
            tab21.Attributes["class"] = "tab-pane fade";
        }
        else if (currentPage.Contains("view-customization-demand.aspx"))
        {
            tabCust.Attributes["class"] = "nav-link active";
            subMenuViewCD.Attributes["class"] = "active";
            tab3.Attributes["class"] = "tab-pane fade active show";
            tab1.Attributes["class"] = "tab-pane fade";
            tab4.Attributes["class"] = "tab-pane fade";
            tab2.Attributes["class"] = "tab-pane fade";
            tab21.Attributes["class"] = "tab-pane fade";
        }
        else if (currentPage.Contains("add-customization-transaction.aspx"))
        {
            tabCust.Attributes["class"] = "nav-link active";
            subMenuAddCT.Attributes["class"] = "active";
            tab3.Attributes["class"] = "tab-pane fade active show";
            tab1.Attributes["class"] = "tab-pane fade";
            tab4.Attributes["class"] = "tab-pane fade";
            tab2.Attributes["class"] = "tab-pane fade";
            tab21.Attributes["class"] = "tab-pane fade";
        }
        else if (currentPage.Contains("view-customization-transaction.aspx"))
        {
            tabCust.Attributes["class"] = "nav-link active";
            subMenuViewCT.Attributes["class"] = "active";
            tab3.Attributes["class"] = "tab-pane fade active show";
            tab1.Attributes["class"] = "tab-pane fade";
            tab4.Attributes["class"] = "tab-pane fade";
            tab2.Attributes["class"] = "tab-pane fade";
            tab21.Attributes["class"] = "tab-pane fade";
        }

        else if (currentPage.Contains("lead-source.aspx"))
        {
            tabMore.Attributes["class"] = "nav-link active";
            subMenuLS.Attributes["class"] = "active";
            tab4.Attributes["class"] = "tab-pane fade active show";
            tab1.Attributes["class"] = "tab-pane fade";
            tab3.Attributes["class"] = "tab-pane fade";
            tab2.Attributes["class"] = "tab-pane fade";
            tab21.Attributes["class"] = "tab-pane fade";
        }
        else if (currentPage.Contains("add-user.aspx"))
        {
            tabMore.Attributes["class"] = "nav-link active";
            subMenuAddUser.Attributes["class"] = "active";
            tab4.Attributes["class"] = "tab-pane fade active show";
            tab1.Attributes["class"] = "tab-pane fade";
            tab3.Attributes["class"] = "tab-pane fade";
            tab2.Attributes["class"] = "tab-pane fade";
            tab21.Attributes["class"] = "tab-pane fade";
        }
        else if (currentPage.Contains("view-users.aspx"))
        {
            tabMore.Attributes["class"] = "nav-link active";
            subMenuViewUser.Attributes["class"] = "active";
            tab4.Attributes["class"] = "tab-pane fade active show";
            tab1.Attributes["class"] = "tab-pane fade";
            tab3.Attributes["class"] = "tab-pane fade";
            tab2.Attributes["class"] = "tab-pane fade";
            tab21.Attributes["class"] = "tab-pane fade";
        }
        else if (currentPage.Contains("add-rm.aspx"))
        {
            tabMore.Attributes["class"] = "nav-link active";
            subMenuAddRM.Attributes["class"] = "active";
            tab4.Attributes["class"] = "tab-pane fade active show";
            tab1.Attributes["class"] = "tab-pane fade";
            tab3.Attributes["class"] = "tab-pane fade";
            tab2.Attributes["class"] = "tab-pane fade";
            tab21.Attributes["class"] = "tab-pane fade";
        }
        else if (currentPage.Contains("view-rm.aspx"))
        {
            tabMore.Attributes["class"] = "nav-link active";
            subMenuViewRM.Attributes["class"] = "active";
            tab4.Attributes["class"] = "tab-pane fade active show";
            tab1.Attributes["class"] = "tab-pane fade";
            tab3.Attributes["class"] = "tab-pane fade";
            tab2.Attributes["class"] = "tab-pane fade";
            tab21.Attributes["class"] = "tab-pane fade";
        }
        else if (currentPage.Contains("add-refer-content.aspx"))
        {
            tabMore.Attributes["class"] = "nav-link active";
            subMenuAddRC.Attributes["class"] = "active";
            tab4.Attributes["class"] = "tab-pane fade active show";
            tab1.Attributes["class"] = "tab-pane fade";
            tab3.Attributes["class"] = "tab-pane fade";
            tab2.Attributes["class"] = "tab-pane fade";
            tab21.Attributes["class"] = "tab-pane fade";
        }
        else if (currentPage.Contains("view-refer-content.aspx"))
        {
            tabMore.Attributes["class"] = "nav-link active";
            subMenuViewRC.Attributes["class"] = "active";
            tab4.Attributes["class"] = "tab-pane fade active show";
            tab1.Attributes["class"] = "tab-pane fade";
            tab3.Attributes["class"] = "tab-pane fade";
            tab2.Attributes["class"] = "tab-pane fade";
            tab21.Attributes["class"] = "tab-pane fade";
        }
        else if (currentPage.Contains("referral-list.aspx"))
        {
            tabMore.Attributes["class"] = "nav-link active";
            subMenuReflist.Attributes["class"] = "active";
            tab4.Attributes["class"] = "tab-pane fade active show";
            tab1.Attributes["class"] = "tab-pane fade";
            tab3.Attributes["class"] = "tab-pane fade";
            tab2.Attributes["class"] = "tab-pane fade";
            tab21.Attributes["class"] = "tab-pane fade";
        }
        else if (currentPage.Contains("add-whats-happening.aspx"))
        {
            tabMore.Attributes["class"] = "nav-link active";
            subMenuAddWH.Attributes["class"] = "active";
            tab4.Attributes["class"] = "tab-pane fade active show";
            tab1.Attributes["class"] = "tab-pane fade";
            tab3.Attributes["class"] = "tab-pane fade";
            tab2.Attributes["class"] = "tab-pane fade";
            tab21.Attributes["class"] = "tab-pane fade";
        }
        else if (currentPage.Contains("view-whats-happening.aspx"))
        {
            tabMore.Attributes["class"] = "nav-link active";
            subMenuViewWH.Attributes["class"] = "active";
            tab4.Attributes["class"] = "tab-pane fade active show";
            tab1.Attributes["class"] = "tab-pane fade";
            tab3.Attributes["class"] = "tab-pane fade";
            tab2.Attributes["class"] = "tab-pane fade";
            tab21.Attributes["class"] = "tab-pane fade";
        }
        else if (currentPage.Contains("add-specifications.aspx"))
        {
            tabMore.Attributes["class"] = "nav-link active";
            subMenuAddSpec.Attributes["class"] = "active";
            tab4.Attributes["class"] = "tab-pane fade active show";
            tab1.Attributes["class"] = "tab-pane fade";
            tab3.Attributes["class"] = "tab-pane fade";
            tab2.Attributes["class"] = "tab-pane fade";
            tab21.Attributes["class"] = "tab-pane fade";
        }
        else if (currentPage.Contains("view-specifications.aspx"))
        {
            tabMore.Attributes["class"] = "nav-link active";
            subMenuViewSpec.Attributes["class"] = "active";
            tab4.Attributes["class"] = "tab-pane fade active show";
            tab1.Attributes["class"] = "tab-pane fade";
            tab3.Attributes["class"] = "tab-pane fade";
            tab2.Attributes["class"] = "tab-pane fade";
            tab21.Attributes["class"] = "tab-pane fade";
        }
        else if (currentPage.Contains("add-floor-plan.aspx"))
        {
            tabMore.Attributes["class"] = "nav-link active";
            subMenuAddFP.Attributes["class"] = "active";
            tab4.Attributes["class"] = "tab-pane fade active show";
            tab1.Attributes["class"] = "tab-pane fade";
            tab3.Attributes["class"] = "tab-pane fade";
            tab2.Attributes["class"] = "tab-pane fade";
            tab21.Attributes["class"] = "tab-pane fade";
        }
        else if (currentPage.Contains("view-floor-plan.aspx"))
        {
            tabMore.Attributes["class"] = "nav-link active";
            subMenuViewFP.Attributes["class"] = "active";
            tab4.Attributes["class"] = "tab-pane fade active show";
            tab1.Attributes["class"] = "tab-pane fade";
            tab3.Attributes["class"] = "tab-pane fade";
            tab2.Attributes["class"] = "tab-pane fade";
            tab21.Attributes["class"] = "tab-pane fade";
        }
        else if (currentPage.Contains("add-broadcast.aspx"))
        {
            tabMore.Attributes["class"] = "nav-link active";
            subMenuAddBB.Attributes["class"] = "active";
            tab4.Attributes["class"] = "tab-pane fade active show";
            tab1.Attributes["class"] = "tab-pane fade";
            tab3.Attributes["class"] = "tab-pane fade";
            tab2.Attributes["class"] = "tab-pane fade";
            tab21.Attributes["class"] = "tab-pane fade";
        }
        else if (currentPage.Contains("view-broadcast.aspx"))
        {
            tabMore.Attributes["class"] = "nav-link active";
            subMenuViewBB.Attributes["class"] = "active";
            tab4.Attributes["class"] = "tab-pane fade active show";
            tab1.Attributes["class"] = "tab-pane fade";
            tab3.Attributes["class"] = "tab-pane fade";
            tab2.Attributes["class"] = "tab-pane fade";
            tab21.Attributes["class"] = "tab-pane fade";
        }
        else if (currentPage.Contains("add-notification.aspx"))
        {
            tabMore.Attributes["class"] = "nav-link active";
            subMenuAddNoti.Attributes["class"] = "active";
            tab4.Attributes["class"] = "tab-pane fade active show";
            tab1.Attributes["class"] = "tab-pane fade";
            tab3.Attributes["class"] = "tab-pane fade";
            tab2.Attributes["class"] = "tab-pane fade";
            tab21.Attributes["class"] = "tab-pane fade";
        }


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
