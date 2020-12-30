using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.SessionState;
namespace HotelManagementSystem.UI
{
    public partial class Site : System.Web.UI.MasterPage
    {
        #region Variable Declaration

        #endregion

        #region Constructor Overloading

        #endregion

        #region All Methods

            protected void Page_Load(object sender, EventArgs e)
            {
                if (!IsPostBack == true)
                {
                    try
                    {
                        if (Session["login"] != null)
                        {
                            lblLogin.Text = "Welcome " + Session["login"].ToString();
                            lblLogin.Visible = true;
                            lnkLogin.Text = "Logout";
                        }
                        else
                        {
                            lblLogin.Visible = true;
                            lnkLogin.Text = "Login";
                        }
                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }
                }
            }

            protected void lnkLogin_Click(object sender, EventArgs e)
            {
                try
                {
                    if (lnkLogin.Text == "Login")
                    {
                        Response.Redirect("~/UI/UserLogin.aspx");
                    }
                    else
                    {
                        Session.Clear();
                        Response.Redirect("~/UI/Home.aspx");
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }

        #endregion

    }
}