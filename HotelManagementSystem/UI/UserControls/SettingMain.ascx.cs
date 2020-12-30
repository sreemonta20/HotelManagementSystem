using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;

namespace HotelManagementSystem.UI.UserControls
{
    public partial class SettingMain : System.Web.UI.UserControl, IWebPart
    {
        private string _catalogiconimageurl;
        private string _description;
        private string _subtitle;
        private string _title;
        private string _titleiconimageurl;
        private string _titleurl;

        string IWebPart.CatalogIconImageUrl
        {
            get { return _catalogiconimageurl; }
            set { _catalogiconimageurl = value; }
        }
        string IWebPart.Description
        {
            get { return _description; }
            set { _description = value; }
        }
        string IWebPart.Subtitle
        {
            get { return _subtitle; }
        }
        string IWebPart.Title
        {
            get { return _title; }
            set { _title = value; }
        }
        string IWebPart.TitleIconImageUrl
        {
            get { return _titleiconimageurl; }
            set { _titleiconimageurl = value; }
        }

        string IWebPart.TitleUrl
        {
            get { return _titleurl; }
            set { _titleurl = value; }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            //PNL.Visible = true;

            _title = "  Process List";
            _description = "";
            _titleiconimageurl = "~/Images/menuicon.jpg";

            if (!Page.IsPostBack)
            {
                if (Session.Count == 0)
                {
                    Ul1.Visible = false;
                    
                }
                else if (Session["UserType"].ToString() != "Admin")
                {
                    li1.Visible = false;
                    li7.Visible = false;
                }
                //li2.Visible = false;
                //li5.Visible = false;
                //li6.Visible = false;
                //li7.Visible = false;
                //li8.Visible = false;
            }

        }

        protected void lnkCustomerRegistration_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/UI/CustomerRegistration.aspx");
        }

        protected void lnkServiceForm_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/UI/ServiceForm.aspx");
        }

        protected void lnkCustomerCheckOut_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/UI/CustomerCheckOut.aspx");
        }

        protected void lnkManagementIncomeReport_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/UI/ManagementIncomeReport.aspx");
        }

        protected void lnkCustomerHistoryReport_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/UI/CustomerHistoryReport.aspx");
        }

        protected void lnkAdminPanel_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/UI/AdminPanel.aspx");
        }

        protected void lnkChangePassword_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/UI/ChangePassword.aspx");
        }

        //protected void lnkLogout_Click(object sender, EventArgs e)
        //{
        //    Response.Redirect("~/UI/UserLogInUI.aspx");
        //}







        
    }
}