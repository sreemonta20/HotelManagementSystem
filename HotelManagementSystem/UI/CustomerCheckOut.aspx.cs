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
    public partial class CustomerCheckOut : System.Web.UI.Page
    {
        #region Variable Declaration
            CustomerCheckOutManager manager = new CustomerCheckOutManager();
            List<RoomServiceToCustomer> RoomServiceToCustomerList = new List<RoomServiceToCustomer>();
            Customer oCustomer = new Customer();
            bool checkResult;
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
                        InitializeCombo();
                        lblErrorMsgCustReg.Visible = false;

                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }

            private void InitializeCombo()
            {
                try
                {
                    GetAllRoomCodeByRegisteredCustomer();

                }
                catch (Exception ex)
                {
                    throw ex;
                }

            }

            private void GetAllRoomCodeByRegisteredCustomer()
            {
                try
                {
                    RoomServiceToCustomerList = manager.GetRoomCodesWithCustomer();
                    ddlRoomCode.DataSource = RoomServiceToCustomerList;
                    ddlRoomCode.DataTextField = "RoomCode";
                    ddlRoomCode.DataValueField = "RoomCode";
                    ddlRoomCode.DataBind();
                    ddlRoomCode.Items.Insert(0, "");

                }
                catch (Exception ex)
                {
                    throw ex;
                }

            }

            protected void ddlRoomCode_SelectedIndexChanged(object sender, EventArgs e)
            {
                try
                {
                    if (ddlRoomCode.SelectedItem.Text != "")
                    {
                        oCustomer = manager.GetCustomerByRoomCode(ddlRoomCode.SelectedValue);
                        lblCustomerCode.Text = oCustomer.CustomerCode;
                        lblCustomerName.Text = oCustomer.CustomerName;
                    }
                    else
                    {
                        ddlRoomCode.Text = "";
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                    
            }

            protected void btnCheckOut_Click(object sender, EventArgs e)
            {
                try
                {
                    checkResult = manager.CustomerCheckOut(lblCustomerCode.Text, ddlRoomCode.SelectedValue);
                    if (checkResult)
                    {
                        lblStatus.Text = "Customer checked out successfully.";
                        Session["customerCode"] = lblCustomerCode.Text;
                        Session["roomCode"] = ddlRoomCode.SelectedValue;
                        lblCustomerCode.Text = "";
                        lblCustomerName.Text = "";
                        RegisterStartupScript("Click", "<script>window.open('./ReportViewer.aspx');</script>");
                        //_data = "&customerCode=" + Convert.ToString(Session["customerCode"]);
                        //_data += "&roomCode=" + Convert.ToString(Session["roomCode"]);
                        //this.Response.Redirect("ReportViewer.aspx?customerServiceInformation=" + _data);
                        checkResult = manager.CheckActiveInactive(Convert.ToString(Session["customerCode"]), Convert.ToString(Session["roomCode"]));
                        if (checkResult)
                        {

                        }
                        else
                        {
                            lblErrorMsgCustReg.Visible = true;
                            lblErrorMsgCustReg.Text = "Customer can't be Inactive";
                        }
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