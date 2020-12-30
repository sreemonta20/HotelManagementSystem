using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HotelManagementSystem.UI
{
    public partial class Home : System.Web.UI.Page
    {
        #region Variable Declaration

        #endregion

        #region Method Overloading

        #endregion

        #region All Methods
            protected void Page_Load(object sender, EventArgs e)
            {
                if (Session.Count == 0)
                {
                    bookingLinkButton.Visible = true;
                }
                else
                {
                    bookingLinkButton.Visible = false;
                }
            }
        #endregion
        
    }
}