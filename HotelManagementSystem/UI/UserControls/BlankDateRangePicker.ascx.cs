using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;

namespace HotelManagementSystem.UI.UserControls
{
    public partial class BlankDateRangePicker : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //txtDateFrom.Text = DateTime.Now.ToString("MM/dd/yyyy");
                //txtDateTo.Text = DateTime.Now.ToString("MM/dd/yyyy");
                txtDateFrom.Text = "";
                txtDateTo.Text = "";
            }

        }

        public String DateFrom
        {
            get
            {
                if (txtDateFrom.Text == "")
                {
                    return "";
                }
                else
                {
                    return DateTime.Parse(txtDateFrom.Text).ToString("MM/dd/yyyy");
                }
            }
            set
            {
                txtDateFrom.Text = DateTime.Parse(value).ToString("MM/dd/yyyy");
            }
        }

        public String DateTo
        {
            get
            {
                if (txtDateTo.Text == "")
                {
                    return "";
                }
                else
                {
                    return DateTime.Parse(txtDateTo.Text).ToString("MM/dd/yyyy");
                }
            }
            set
            {
                txtDateTo.Text = DateTime.Parse(value).ToString("MM/dd/yyyy");
            }
        }

        public String FYDateFrom
        {
            get
            {
                string _FYDateFrom;
                if (System.DateTime.Now.Month < 3)
                {
                    _FYDateFrom = DateTime.Parse("03/01/" + (System.DateTime.Now.Year - 1).ToString()).ToString("MM/dd/yyyy");
                }
                else
                {
                    _FYDateFrom = DateTime.Parse("03/01/" + (System.DateTime.Now.Year).ToString()).ToString("MM/dd/yyyy");
                }
                return DateTime.Parse(_FYDateFrom).ToString("MM/dd/yyyy");
            }
        }

        public String FYDateTo
        {
            get
            {
                string _FYDateTo;
                if (System.DateTime.Now.Month < 3)
                {
                    _FYDateTo = DateTime.Parse("03/01/" + (System.DateTime.Now.Year).ToString()).AddDays(-1).ToString("MM/dd/yyyy");
                }
                else
                {
                    _FYDateTo = DateTime.Parse("03/01/" + (System.DateTime.Now.Year + 1).ToString()).AddDays(-1).ToString("MM/dd/yyyy");
                }
                return DateTime.Parse(_FYDateTo).ToString("MM/dd/yyyy");
            }
        }

    }
}
