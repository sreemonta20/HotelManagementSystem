using HotelManagementSystem.BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.SessionState;

namespace HotelManagementSystem.UI
{
    public partial class UserLogin : System.Web.UI.Page
    {
        #region Variable Declaration
        UserManager oUserManager = new UserManager();
        #endregion

        #region Constructor Overloading

        #endregion

        #region All Methods

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                Session.Clear();
            }
            this.SetFocus(txtUserName);
            HideAll();
        }

        protected void LoginButton_Click(object sender, EventArgs e)
        {
            string userName = txtUserName.Text.Trim();
            string password = txtPassword.Text.Trim();
            string userType;
            try
            {

                if (!oUserManager.CheckAuthenticateUser(userName, password))
                {
                    FailureInfoShow();
                    lblInvalid.Text = "incorrect Username/password";
                }
                else
                {

                    userType = oUserManager.GetUserType(userName, password);
                    Session["login"] = userName;
                    Session["password"] = password;
                    //if (userType == "")
                    //{
                    //    Session["UserType"] = "User";
                    //}
                    //else
                    //{
                    //    Session["UserType"] = userType;
                    //}
                    if (userType != "")
                    {
                    
                        Session["UserType"] = userType;
                    }
                    
                    Response.Redirect("./CustomerRegistration.aspx");
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void HideAll()
        {
            colImageFailure.Visible = false;
            imgRegFailure.Visible = false;
            colImageSuccess.Visible = false;
            imgRegSuccess.Visible = false;
            colFailureMsg.Visible = false;
            lblInvalid.Visible = false;
            colSuccessMsg.Visible = false;
            lblRegSuccess.Visible = false;
        }
        private void FailureInfoShow()
        {
            colImageFailure.Visible = true;
            imgRegFailure.Visible = true;
            colFailureMsg.Visible = true;
            lblInvalid.Visible = true;
        }
        private void SuccessInfoShow()
        {
            colImageSuccess.Visible = true;
            imgRegSuccess.Visible = true;
            colSuccessMsg.Visible = true;
            lblRegSuccess.Visible = true;
        }

        #endregion



    }
}