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
    public partial class CustomerBookingUI : System.Web.UI.Page
    {
        #region Variable Declaration

        CustomerBookingUIManager manager = new CustomerBookingUIManager();
        List<RoomTypeDetails> RoomTypeDetailsList = new List<RoomTypeDetails>();
        List<RoomService> RoomServiceList = new List<RoomService>();
        List<Booking> BookingList = new List<Booking>();
        Booking oBooking = new Booking();
        string saveIndication;

        #endregion

        #region Method Overloading

        #endregion

        #region All Methods
            protected void Page_Load(object sender, EventArgs e)
            {
                try
                {
                    if (Session["login"] == null)
                    {
                        if (!Page.IsPostBack)
                        {
                            InitializeCombo();
                            ddlRoomTypeName_SelectedIndexChanged(sender, e);
                            GetNextBookingCode();
                            lblErrorMsgBook.Visible = false;
                        }
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

            private string GetNextBookingCode()
            {
                int bookingCode;
                try
                {
                    bookingCode = manager.GetNextBookingCode();
                    return bookingCode.ToString("BC-000");
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }


            protected void btnBook_Click(object sender, EventArgs e)
            {
                try
                {
                    if (ddlRoomTypeName.SelectedItem.Text == null || ddlRoomTypeName.SelectedItem.Text == "")
                    {
                        lblErrorMsgBook.Text = "please select a room type";
                    }
                    else if (lblRoomRent.Text == "")
                    {
                        lblErrorMsgBook.Text = "rent not found";
                    }
                    else if (ddlRoomCode.SelectedItem.Text == null || ddlRoomCode.SelectedItem.Text == "")
                    {
                        lblErrorMsgBook.Text = "please select a Room";
                    }
                    else
                    {
                        oBooking.BookingCode = GetNextBookingCode();
                        oBooking.RoomCode = ddlRoomCode.SelectedValue;
                        oBooking.BookingDate = DateTime.Now;
                        oBooking.BookingEndDate = oBooking.BookingDate.AddDays(1);
                        oBooking.CustomerName = txtCustomerName.Text;
                        oBooking.Address = txtCustomerAddress.Text;
                        oBooking.ContactNo = txtCustomerPhone.Text;
                        oBooking.EmailAddress = txtCustomerEmail.Text;
                        oBooking.Remark = txtPuposeOfJourney.Text;

                    }
                    saveIndication = manager.BookRoom(oBooking);
                    if (saveIndication == "null")
                    {
                        lblErrorMsgBook.Visible = true;
                        lblErrorMsgBook.Text = saveIndication;
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
        #endregion
    }
}