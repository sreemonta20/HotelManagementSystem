using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HotelManagementSystem.UI
{
    public partial class ManagementIncomeReport : System.Web.UI.Page
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
                //if (!Page.IsPostBack)
                //{
                //    rowDateRange.Visible = true;
                //}
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //protected void rbtLstReportBy_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        if (rbtLstReportBy.SelectedItem.Value == "RoomWiseDetails")
        //        {
        //            rowReportByName.Visible = true;
        //            rowDateRange.Visible = false;
        //        }
        //        else if (rbtLstReportBy.SelectedItem.Value == "RoomWiseSummary")
        //        {
        //            rowReportByName.Visible = false;
        //            rowDateRange.Visible = true;
        //        }
        //        else
        //        {

        //        }
        //     }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}

        protected void btnCustomerReport_Click(object sender, EventArgs e)
        {
            try
            {
                if (rbtLstReportBy.SelectedItem.Value == "RoomWiseDetails")
                {

                    Session["reportType"] = "RoomWiseDetails";
                    Session["MdateFrom"] = DateRangePickerCustomer.DateFrom;
                    Session["MdateTo"] = DateRangePickerCustomer.DateTo;

                }
                else if (rbtLstReportBy.SelectedItem.Value == "RoomWiseSummary")
                {

                    Session["reportType"] = "RoomWiseSummary";
                    Session["MdateFrom"] = DateRangePickerCustomer.DateFrom;
                    Session["MdateTo"] = DateRangePickerCustomer.DateTo;
                }
                else
                {
                    Session["reportType"] = "ServiceWiseSummary";
                    Session["MdateFrom"] = DateRangePickerCustomer.DateFrom;
                    Session["MdateTo"] = DateRangePickerCustomer.DateTo;
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