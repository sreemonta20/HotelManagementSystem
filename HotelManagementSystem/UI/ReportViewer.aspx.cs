using HotelManagementSystem.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Data.SqlClient;
using Microsoft.Reporting.WebForms;
using System.Data;

namespace HotelManagementSystem.UI
{
    public partial class ReportViewer : System.Web.UI.Page
    {
        #region Variable Declaration
        DBConnection oDBConnection = new DBConnection();
        string customerCode, roomCode, queryString;
        #endregion

        #region Constructor Overloading

        #endregion

        #region All Methods

            protected void Page_Load(object sender, EventArgs e)
            {
                if (!IsPostBack)
                {
                   // LoadDataInReport();
                    if (Session["roomCode"] != null && Session["customerCode"] != null)
                    {
                        rptViewerHMS.Reset();
                        ReportParameter[] rptParams = new ReportParameter[] { 
                        new ReportParameter("RoomCode", Convert.ToString(Session["roomCode"])), 
                        new ReportParameter("CustomerCode", Convert.ToString(Session["customerCode"])) 
                        };


                        DataTable oDataTable = ShowCustomerServiceReport(Convert.ToString(Session["roomCode"]), Convert.ToString(Session["customerCode"]));
                        rptViewerHMS.LocalReport.ReportPath = Server.MapPath("~/UI/Reports/CustomerServices.rdl");
                        ReportDataSource oReportDataSource = new ReportDataSource("DataSet1", oDataTable);
                        rptViewerHMS.LocalReport.DataSources.Clear();
                        rptViewerHMS.LocalReport.DataSources.Add(oReportDataSource);
                        rptViewerHMS.LocalReport.SetParameters(rptParams);
                        rptViewerHMS.LocalReport.Refresh();
                    }
                    else if (Session["customerName"] != null)
                    {
                        rptViewerHMS.Reset();
                        ReportParameter[] rptParams = new ReportParameter[] {
                        new ReportParameter("CustomerName", Convert.ToString(Session["customerName"]))
                        };

                        DataTable oDataTable = ShowCustomerHistoryByNameReport(Convert.ToString(Session["customerName"]));
                        rptViewerHMS.LocalReport.ReportPath = Server.MapPath("~/UI/Reports/CustomerHistoryByName.rdl");
                        ReportDataSource oReportDataSource = new ReportDataSource("DataSet1", oDataTable);
                        rptViewerHMS.LocalReport.DataSources.Clear();
                        rptViewerHMS.LocalReport.DataSources.Add(oReportDataSource);
                        rptViewerHMS.LocalReport.SetParameters(rptParams);
                        rptViewerHMS.LocalReport.Refresh();
                    }
                    else if (Session["dateFrom"] != null && Session["dateTo"] != null)
                    {
                        rptViewerHMS.Reset();
                        ReportParameter[] rptParams = new ReportParameter[] { 
                        new ReportParameter("DateFrom", Convert.ToString(Session["dateFrom"])), 
                        new ReportParameter("DateTo", Convert.ToString(Session["dateTo"]))
                        };


                        DataTable oDataTable = ShowCustomerHistoryByDateReport(Convert.ToString(Session["dateFrom"]), Convert.ToString(Session["dateTo"]));
                        rptViewerHMS.LocalReport.ReportPath = Server.MapPath("~/UI/Reports/CustomerHistoryByDate.rdl");
                        ReportDataSource oReportDataSource = new ReportDataSource("DataSet1", oDataTable);
                        rptViewerHMS.LocalReport.DataSources.Clear();
                        rptViewerHMS.LocalReport.DataSources.Add(oReportDataSource);
                        rptViewerHMS.LocalReport.SetParameters(rptParams);
                        rptViewerHMS.LocalReport.Refresh();
                    }
                    else if (Session["reportType"] != null)
                    {
                        rptViewerHMS.Reset();
                        ReportParameter[] rptParams = new ReportParameter[] { 
                        new ReportParameter("DateFrom", Convert.ToString(Session["MdateFrom"])), 
                        new ReportParameter("DateTo", Convert.ToString(Session["MdateTo"]))
                        };


                        DataTable oDataTable = ShowIncomeByDateReport(Convert.ToString(Session["MdateFrom"]), Convert.ToString(Session["MdateTo"]));
                        if (Session["reportType"] == "RoomWiseDetails")
                        {
                            rptViewerHMS.LocalReport.ReportPath = Server.MapPath("~/UI/Reports/RoomServiceWiseDetailsIncome.rdl");
                        }
                        else if (Session["reportType"] == "RoomWiseSummary")
                        {
                            rptViewerHMS.LocalReport.ReportPath = Server.MapPath("~/UI/Reports/RoomServiceWiseSummaryIncome.rdl");
                        }
                        else
                        {
                            rptViewerHMS.LocalReport.ReportPath = Server.MapPath("~/UI/Reports/FoodServiceWiseSummaryIncome.rdl");
                        }
                        
                        ReportDataSource oReportDataSource = new ReportDataSource("DataSet1", oDataTable);
                        rptViewerHMS.LocalReport.DataSources.Clear();
                        rptViewerHMS.LocalReport.DataSources.Add(oReportDataSource);
                        rptViewerHMS.LocalReport.SetParameters(rptParams);
                        rptViewerHMS.LocalReport.Refresh();
                    }


                }
                
            }
            //private void LoadDataInReport()
            //{
            //    rptViewerHMS.Reset();

            //    if (Request.QueryString["customerServiceInformation"] != null)
            //    {
            //        string customerCode = Request.QueryString["customerCode"].ToString();
            //        string roomCode = Request.QueryString["roomCode"].ToString();


            //        ReportParameter[] rptParams = new ReportParameter[] { 
            //        new ReportParameter("RoomCode", customerCode), 
            //        new ReportParameter("CustomerCode", roomCode) 
            //        };


            //        DataTable oDataTable = ShowCustomerServiceReport(customerCode, roomCode);
            //        rptViewerHMS.LocalReport.ReportPath = Server.MapPath("~/UI/Reports/CustomerServices.rdl");
            //        ReportDataSource oReportDataSource = new ReportDataSource("DataSet1", oDataTable);
            //        rptViewerHMS.LocalReport.DataSources.Clear();
            //        rptViewerHMS.LocalReport.DataSources.Add(oReportDataSource);
            //        rptViewerHMS.LocalReport.SetParameters(rptParams);
            //        rptViewerHMS.LocalReport.Refresh();
            //    }
            //    if (Request.QueryString["customerHistoryInformation"] != null)
            //    {
            //        string customerName = Request.QueryString["customerName"].ToString();
            //        string dateFrom = Request.QueryString["dateFrom"].ToString();
            //        string dateTo = Request.QueryString["dateTo"].ToString();


            //        ReportParameter[] rptParams = new ReportParameter[] { 
            //        new ReportParameter("DateFrom", dateFrom), 
            //        new ReportParameter("DateTo", dateTo),
            //        new ReportParameter("CustomerName", customerName) 
            //        };


            //        DataTable oDataTable = ShowCustomerHistoryReport(dateFrom, dateTo, customerName);
            //        rptViewerHMS.LocalReport.ReportPath = Server.MapPath("~/UI/Reports/CustomerHistory.rdl");
            //        ReportDataSource oReportDataSource = new ReportDataSource("DataSet1", oDataTable);
            //        rptViewerHMS.LocalReport.DataSources.Clear();
            //        rptViewerHMS.LocalReport.DataSources.Add(oReportDataSource);
            //        rptViewerHMS.LocalReport.SetParameters(rptParams);
            //        rptViewerHMS.LocalReport.Refresh();
            //    }
                
            //    //rptViewerHMS.Reset();
            //    //ReportParameter[] rptParams = new ReportParameter[] { 
            //    //    new ReportParameter("RoomCode", Convert.ToString(Session["roomCode"])), 
            //    //    new ReportParameter("CustomerCode", Convert.ToString(Session["customerCode"])) 
            //    //    };


            //    //DataTable oDataTable = ShowCustomerServiceReport(Convert.ToString(Session["roomCode"]), Convert.ToString(Session["customerCode"]));
            //    //rptViewerHMS.LocalReport.ReportPath = Server.MapPath("~/UI/Reports/CustomerServices.rdl");
            //    //ReportDataSource oReportDataSource = new ReportDataSource("DataSet1", oDataTable);
            //    //rptViewerHMS.LocalReport.DataSources.Clear();
            //    //rptViewerHMS.LocalReport.DataSources.Add(oReportDataSource);
            //    //rptViewerHMS.LocalReport.SetParameters(rptParams);
            //    //rptViewerHMS.LocalReport.Refresh();
            //}
            private DataTable ShowCustomerServiceReport(string roomCode, string customerCode)
            {
                DataTable oDataTable = new DataTable();
                SqlCommand oSqlCommand = new SqlCommand();
                queryString = "spRptCustomerServices";
                try
                {
                    oSqlCommand = oDBConnection.CreateSqlCommand(queryString);
                    oSqlCommand.CommandType = CommandType.StoredProcedure;

                    SqlParameter paramRoomCode = new SqlParameter("@RoomCode", roomCode);
                    SqlParameter paramCustomerCode = new SqlParameter("@CustomerCode", customerCode);


                    oSqlCommand.Parameters.Add(paramRoomCode);
                    oSqlCommand.Parameters.Add(paramCustomerCode);
                    SqlDataAdapter oSqlDataAdapter = new SqlDataAdapter(oSqlCommand);
                    oSqlDataAdapter.Fill(oDataTable);
                    

                }

                catch (Exception ex)
                {
                    throw ex;
                }
                
                return oDataTable;
            }

            private DataTable ShowCustomerHistoryByNameReport(string customerName)
            {
                DataTable oDataTable = new DataTable();
                SqlCommand oSqlCommand = new SqlCommand();
                queryString = "spRptCustomerHistoryByName";
                try
                {
                    oSqlCommand = oDBConnection.CreateSqlCommand(queryString);
                    oSqlCommand.CommandType = CommandType.StoredProcedure;

                    
                    SqlParameter paramCustomerName = new SqlParameter("@CustomerName", customerName);


                    
                    oSqlCommand.Parameters.Add(paramCustomerName);
                    SqlDataAdapter oSqlDataAdapter = new SqlDataAdapter(oSqlCommand);
                    oSqlDataAdapter.Fill(oDataTable);


                }

                catch (Exception ex)
                {
                    throw ex;
                }

                return oDataTable;
            }

            private DataTable ShowCustomerHistoryByDateReport(string dateFrom, string dateTo)
            {
                DataTable oDataTable = new DataTable();
                SqlCommand oSqlCommand = new SqlCommand();
                queryString = "spRptCustomerHistoryByDate";
                try
                {
                    oSqlCommand = oDBConnection.CreateSqlCommand(queryString);
                    oSqlCommand.CommandType = CommandType.StoredProcedure;

                    SqlParameter paramDateFrom = new SqlParameter("@DateFrom", dateFrom);
                    SqlParameter paramDateTo = new SqlParameter("@DateTo", dateTo);

                    oSqlCommand.Parameters.Add(paramDateFrom);
                    oSqlCommand.Parameters.Add(paramDateTo);
                    SqlDataAdapter oSqlDataAdapter = new SqlDataAdapter(oSqlCommand);
                    oSqlDataAdapter.Fill(oDataTable);


                }

                catch (Exception ex)
                {
                    throw ex;
                }

                return oDataTable;
            }

            private DataTable ShowIncomeByDateReport(string dateFrom, string dateTo)
            {
                DataTable oDataTable = new DataTable();
                SqlCommand oSqlCommand = new SqlCommand();
                if (Session["reportType"] == "RoomWiseDetails")
                {
                    queryString = "spRptRoomServiceWiseIncomeDetails";
                }
                else if (Session["reportType"] == "RoomWiseSummary")
                {
                    queryString = "spRptRoomServiceWiseIncomeSummary";
                }
                else
                {
                    queryString = "spRptFoodServiceWiseIncomeSummary";
                }
                try
                {
                    oSqlCommand = oDBConnection.CreateSqlCommand(queryString);
                    oSqlCommand.CommandType = CommandType.StoredProcedure;

                    SqlParameter paramDateFrom = new SqlParameter("@DateFrom", dateFrom);
                    SqlParameter paramDateTo = new SqlParameter("@DateTo", dateTo);

                    oSqlCommand.Parameters.Add(paramDateFrom);
                    oSqlCommand.Parameters.Add(paramDateTo);
                    SqlDataAdapter oSqlDataAdapter = new SqlDataAdapter(oSqlCommand);
                    oSqlDataAdapter.Fill(oDataTable);


                }

                catch (Exception ex)
                {
                    throw ex;
                }

                return oDataTable;
            }

        #endregion


        
    }
}