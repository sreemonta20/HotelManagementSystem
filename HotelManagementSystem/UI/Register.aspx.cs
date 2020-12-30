using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using HotelManagementSystem.BLL;
using System.Web.SessionState;
namespace HotelManagementSystem.UI
{
    public partial class Register : System.Web.UI.Page
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

            protected void btnRegister_Click(object sender, EventArgs e)
            {

                try
                {

                    if (Page.IsValid)
                    {
                        string name = txtFirstName.Text.Trim() + " " + txtLastName.Text.Trim();
                        string firstName = txtFirstName.Text.Trim();
                        string lastName = txtLastName.Text.Trim();
                        string userEmail = txtEmail.Text.Trim();
                        string address = txtAddress.Text.Trim();
                        string userName = txtUserName.Text.Trim();
                        string password = txtPassword.Text.Trim();
                        string conPassword = txtConfirmPassword.Text.Trim();
                        string userType = "User";

                        if (password != conPassword)
                        {
                            FailureInfoShow();
                            lblInvalid.Text = "Please put a confirm passowrd";

                        }

                        if (!oUserManager.CheckRegisterUser(name, firstName, lastName, userEmail, address, userName, password, userType))
                        {
                            FailureInfoShow();
                            lblInvalid.Text = "user Name already exist";
                        }
                        else
                        {
                            SuccessInfoShow();
                        }
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