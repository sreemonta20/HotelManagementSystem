using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.SessionState;
using HotelManagementSystem.BLL;
using HotelManagementSystem.DAO;

namespace HotelManagementSystem.UI
{
    public partial class CustomerRegistration : System.Web.UI.Page
    {
        #region Variable Declaration

        CustomerRegistrationManager manager = new CustomerRegistrationManager();
        List<RoomTypeDetails> RoomTypeDetailsList = new List<RoomTypeDetails>();
        List<RoomService> RoomServiceList = new List<RoomService>();
        int customerCode, roomServiceToCustID;
        //int roomServiceToCustID;
        List<Customer> CustomerList = new List<Customer>();
        Customer oCustomer = new Customer();
        RoomServiceToCustomer oRoomServiceToCustomer = new RoomServiceToCustomer();
        string saveIndication;

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
                        ddlRoomTypeName_SelectedIndexChanged(sender, e);
                        GetNextCustomerCode();
                        ddlCustomerCode.Visible = false;
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
                    RoomTypeDetailsList = manager.GetAllRoomTypeDetails();
                    ddlRoomTypeName.DataSource = RoomTypeDetailsList;
                    ddlRoomTypeName.DataTextField = "RoomTypeName";
                    ddlRoomTypeName.DataValueField = "RoomCost";
                    ddlRoomTypeName.DataBind();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                
            }

            private void LoadRoomNumberByRoomType(string roomTypeName)
            {
                try
                {
                    RoomServiceList = manager.GetAllRoomNumbersByRoomType(roomTypeName);
                    ddlRoomCode.DataSource = RoomServiceList;
                    ddlRoomCode.DataTextField = "RoomCode";
                    ddlRoomCode.DataValueField = "RoomCode";
                    ddlRoomCode.DataBind();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                
            }

            protected void ddlRoomTypeName_SelectedIndexChanged(object sender, EventArgs e)
            {
                
                try
                {
                    lblRoomRent.Text = ddlRoomTypeName.SelectedValue;
                    LoadRoomNumberByRoomType(ddlRoomTypeName.SelectedItem.ToString());
                }
                catch (Exception ex)
                {
                    throw ex;
                }

            }   

            private void GetNextCustomerCode()
            {
                try
                {
                    customerCode = manager.GetNextCustomerCode();
                    txtCustomerCode.Text = customerCode.ToString("0000");
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }

            private string GetNextRoomServiceToCustID()
            {
                try
                {
                    roomServiceToCustID = manager.GetNextRoomServiceToCustID();
                    return roomServiceToCustID.ToString("0000");
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }

            protected void rbtLstCustomer_SelectedIndexChanged(object sender, EventArgs e)
            {
                try
                {
                    if (rbtLstCustomer.SelectedValue == "New Customer")
                    {
                        ddlCustomerCode.Visible = false;
                        txtCustomerCode.Visible = true;
                        GetNextCustomerCode();
                    }
                    else
                    {
                        
                        ddlCustomerCode.Visible = true;
                        txtCustomerCode.Visible = false;
                        CustomerList = manager.GetAllExistingCustomer();
                        ddlCustomerCode.Items.Clear();
                        ddlCustomerCode.Items.Add("");
                        foreach (Customer oCustomer in CustomerList)
                        {
                            ddlCustomerCode.Items.Add(oCustomer.CustomerCode);
                        }

                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }

            }

            protected void ddlCustomerCode_SelectedIndexChanged(object sender, EventArgs e)
            {
                CustomerList = manager.GetAllExistingCustomer();

                try
                {
                    if (CustomerList != null)
                    {
                        oCustomer = CustomerList.Find(item => item.CustomerCode == this.ddlCustomerCode.SelectedValue.ToString());
                        txtCustomerName.Text = oCustomer.CustomerName;
                        txtCustomerAddress.Text = oCustomer.Address;
                        txtCustomerPhone.Text = oCustomer.ContactNo;
                        txtCustomerEmail.Text = oCustomer.EmailAddress;
                        txtPuposeOfJourney.Text = oCustomer.Remark;
                    }

                }
                catch (Exception ex)
                {
                    throw ex;
                }
                
            }

            private void ClearInformation()
            {
                
                try
                {
                    txtCustomerName.Text = "";
                    txtCustomerAddress.Text = "";
                    txtCustomerPhone.Text = "";
                    txtCustomerEmail.Text = "";
                    txtPuposeOfJourney.Text = "";
                    InitializeCombo();
                    GetNextCustomerCode();
                    ddlCustomerCode.Visible = false;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }

            private void FunctionSave(bool newExist, Customer oCustomer, RoomServiceToCustomer oRoomServiceToCustomer)
            {
                try
                {
                    saveIndication = manager.SaveCustomerInRegisteredRoom(newExist, oCustomer, oRoomServiceToCustomer);
                    if (saveIndication == "null")
                    {
                        lblErrorMsgCustReg.Visible = true;
                        lblErrorMsgCustReg.Text = saveIndication;
                    }
                    else
                    {
                        lblStatus.Text = saveIndication;
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }

            }

            protected void btnSaveCustomer_Click(object sender, EventArgs e)
            {
                try
                {
                    if (rbtLstCustomer.SelectedValue == "New Customer")
                    {
                        oCustomer.CustomerCode = txtCustomerCode.Text;
                        oCustomer.UserCode = Convert.ToString(Session["login"]);
                        oCustomer.CustomerName = txtCustomerName.Text;
                        oCustomer.Address = txtCustomerAddress.Text;
                        oCustomer.ContactNo = txtCustomerPhone.Text;
                        oCustomer.EmailAddress = txtCustomerEmail.Text;
                        oCustomer.Remark = txtPuposeOfJourney.Text;
                        //if(ddlRoomTypeName)
                        if (ddlRoomTypeName.SelectedItem.Text == null || ddlRoomTypeName.SelectedItem.Text == "")
                        {
                            lblErrorMsgCustReg.Text = "please select a room type";
                        }
                        else if (lblRoomRent.Text == "")
                        {
                            lblErrorMsgCustReg.Text = "rent not found";
                        }
                        else if (ddlRoomCode.SelectedItem.Text == null || ddlRoomCode.SelectedItem.Text == "")
                        {
                            lblErrorMsgCustReg.Text = "please select a Room";
                        }
                        else
                        {
                            DateTime arrivalDate = DateTime.Parse(Request.Form[txtArrivalDate.UniqueID]);
                            DateTime departureDate = DateTime.Parse(Request.Form[txtDepartureDate.UniqueID]);
                            oRoomServiceToCustomer.RoomServiceToCustID = GetNextRoomServiceToCustID();
                            oRoomServiceToCustomer.CustomerCode = txtCustomerCode.Text;
                            oRoomServiceToCustomer.RoomCode = ddlRoomCode.SelectedValue;
                            oRoomServiceToCustomer.ArrivalDate = arrivalDate.ToString("yyyy-MM-dd HH:mm:ss");
                            oRoomServiceToCustomer.DepartureDate = departureDate.ToString("yyyy-MM-dd HH:mm:ss");
                            oRoomServiceToCustomer.TotalRoomRent = lblRoomRent.Text;
                            oRoomServiceToCustomer.PurposeOfArrival = txtPuposeOfJourney.Text;

                        }
                        FunctionSave(true, oCustomer, oRoomServiceToCustomer);
                        
                    }
                    else
                    {

                        DateTime arrivalDate = DateTime.Parse(Request.Form[txtArrivalDate.UniqueID]);
                        DateTime departureDate = DateTime.Parse(Request.Form[txtDepartureDate.UniqueID]);
                        oRoomServiceToCustomer.RoomServiceToCustID = GetNextRoomServiceToCustID();
                        oRoomServiceToCustomer.CustomerCode = ddlCustomerCode.SelectedValue;
                        oRoomServiceToCustomer.RoomCode = ddlRoomCode.SelectedValue;
                        oRoomServiceToCustomer.ArrivalDate = arrivalDate.ToString("yyyy-MM-dd HH:mm:ss");
                        oRoomServiceToCustomer.DepartureDate = departureDate.ToString("yyyy-MM-dd HH:mm:ss");
                        oRoomServiceToCustomer.TotalRoomRent = lblRoomRent.Text;
                        oRoomServiceToCustomer.PurposeOfArrival = txtPuposeOfJourney.Text;
                        FunctionSave(false, oCustomer, oRoomServiceToCustomer);
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