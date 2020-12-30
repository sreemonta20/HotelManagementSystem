using HotelManagementSystem.BLL;
using HotelManagementSystem.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HotelManagementSystem.UI
{
    public partial class ChangePassword : System.Web.UI.Page
    {
        #region Variable Declaration
        User oUser = new User();
        UserManager oUserManager = new UserManager();
        #endregion

        #region Constructor overloading

        #endregion

        #region All Methods
            protected void Page_Load(object sender, EventArgs e)
            {

                try
                {
                    if (Session["login"] == null)
                    {
                        Response.Redirect("UserLogin.aspx");
                    }
                    
                    if(!Page.IsPostBack)
                    {
                        //failureText.Visible = false;
                        //successText.Visible = false;
                        InitializeLabel();
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }

            private void InitializeLabel()
            {
                try
                {
                    Lbllogon.Text = Session["login"].ToString();
                }
                catch(Exception ex)
                {
                    throw ex;
                }
            }

            protected void btnChangePassword_Click(object sender, EventArgs e)
            {
                
                string currentPass = txtCurrentPassword.Text;
                string usrName = Session["login"].ToString();
                try
                {
                    if (!oUserManager.CheckAuthenticateUser(usrName, currentPass))
                    {
                        failureText.Visible = true;
                        successText.Visible = false;
                        txtFailure.Text = "Your current password doesn't match";
                    }
                    else
                    {
                        if (Session["login"] != "")
                        {
                            oUser.UserName = Session["login"].ToString();
                            oUser.Password = txtNewPassword.Text;
                            bool result = oUserManager.ChangeUserPassword(oUser);
                            if (result)
                            {
                                successText.Visible = true;
                                failureText.Visible = false;
                                txtSuccess.Text = "Your password changes successfully.";
                                Session.Clear();
                                //Response.Redirect("~/UI/UserLogin.aspx");
                            }
                            else
                            {

                                failureText.Visible = true;
                                successText.Visible = false;
                                txtFailure.Text = "Error";
                            }
                        }
                        
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }

            //protected void ChangePasswordPushButton_Click(object sender, EventArgs e)
            //{
            //    User user = new User();
            //    UserGateway userGateway = new UserGateway();

            //    if (Session["userId"] != "")
            //    {
            //        user.UserId = Session["userId"].ToString();
            //        user.Password = newPasswordTextBox.Text;
            //        bool result = userGateway.ChangeUserPassword(user);
            //        if (result)
            //        {
            //            FailureText.Text = "Your password changes successfully.";
            //        }
            //        else
            //        {
            //            FailureText.Text = "Your Current Password is Wrong!";
            //        }
            //    }
            //}

        #endregion

        
    }
}