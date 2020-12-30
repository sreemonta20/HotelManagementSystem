using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HotelManagementSystem.UI
{
    public partial class CustomerHistoryReport : System.Web.UI.Page
    {
        #region Variable Declaration
        string _data;
        #endregion

        #region Constructor Overloading

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
                if (!Page.IsPostBack)
                {
                    rowDateRange.Visible = false;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void rbtLstReportBy_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (rbtLstReportBy.SelectedItem.Value == "By Name")
                {
                    rowReportByName.Visible = true;
                    rowDateRange.Visible = false;
                }
                else
                {
                    rowReportByName.Visible = false;
                    rowDateRange.Visible = true;
                }
             }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void btnCustomerReport_Click(object sender, EventArgs e)
        {
            try
            {
                if (rbtLstReportBy.SelectedItem.Value == "By Name")
                {
                    rowReportByName.Visible = true;
                    rowDateRange.Visible = false;
                    //_data = "&customerName=" + txtNameSearch.Text.Trim();
                    //_data += "&dateFrom=" + "";
                    //_data += "&dateTo=" + "";
                    
                    Session["customerName"] = txtNameSearch.Text.Trim();

                }
                else
                {
                    rowReportByName.Visible = false;
                    rowDateRange.Visible = true;
                    //_data = "&customerName=" + "";
                    //_data += "&dateFrom=" + DateRangePickerCustomer.DateFrom;
                    //_data += "&dateTo=" + DateRangePickerCustomer.DateTo;
                    
                    Session["dateFrom"] = DateRangePickerCustomer.DateFrom;
                    Session["dateTo"] = DateRangePickerCustomer.DateTo;
                }
                //this.Response.Redirect("ReportViewer.aspx?customerHistoryInformation=" + _data);
                RegisterStartupScript("Click", "<script>window.open('./ReportViewer.aspx');</script>");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion


        
    }
}