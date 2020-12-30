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
    public partial class AdminPanel : System.Web.UI.Page
    {
        #region Variable Declaration
            AdminPanelManager manager = new AdminPanelManager();

        #endregion

        #region Constructor overloading


        #endregion

        #region All Methods
            protected void Page_Load(object sender, EventArgs e)
            {
                if (Session["login"] == null)
                {
                    Response.Redirect("UserLogin.aspx");
                }
            }

            protected void btnCustomerBookProcess_Click(object sender, EventArgs e)
            {
                bool status = false;
                int bookingRoomCount = 0;
                try
                {
                    List<RoomService> oRoomServiceList = manager.GetAllBookedRoomNumbers();
                    if (oRoomServiceList != null && oRoomServiceList.Count != 0)
                    {
                        foreach (RoomService oRoomService in oRoomServiceList)
                        {
                            bookingRoomCount++;
                            status = manager.FreeDataFromBookingTblByRoomCode(oRoomService.RoomCode);
                            if (status)
                            {
                                status = manager.UpdateRoomStatusAfterFreeingBookingTable(oRoomService.RoomCode);
                                
                            }
                        }
                        if (status == true)
                        {
                            lblMsgCustomerBookProcessOk.Visible = true;
                            if (bookingRoomCount > 1)
                            {
                                lblMsgCustomerBookProcessOk.Text = bookingRoomCount  + " rooms found and freed";
                            }
                            else
                            {
                                lblMsgCustomerBookProcessOk.Text = bookingRoomCount + " room found and freed";
                            }
                        }

                    }
                    else
                    {
                        lblMsgCustomerBookProcessOk.Visible = true;
                        lblMsgCustomerBookProcessOk.Text = "no new booked process found";
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