using HotelManagementSystem.BLL;
using HotelManagementSystem.DAO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HotelManagementSystem.UI
{
    public partial class ServiceForm : System.Web.UI.Page
    {
        #region Variable Declaration
        ServiceFormManager manager = new ServiceFormManager();
            List<RoomServiceToCustomer> RoomServiceToCustomerList = new List<RoomServiceToCustomer>();
            List<FoodService> FoodServiceList = new List<FoodService>();
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
                    InitializeDataTable();
                    
                }
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

        private void GetAllFoodServiceForRegisteredCustomer()
        {
            try
            {
                FoodServiceList = manager.GetAllFoodService();
                ddlFoodService.DataSource = FoodServiceList;
                ddlFoodService.DataTextField = "FoodServiceName";
                ddlFoodService.DataValueField = "Price";
                ddlFoodService.DataBind();
                ddlFoodService.Items.Insert(0, "");

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
                GetAllFoodServiceForRegisteredCustomer();

            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        private void InitializeDataTable()
        {
            DataTable oDataTable = new DataTable();
            oDataTable.Columns.Add("Service", typeof(string));
            oDataTable.Columns.Add("Price", typeof(decimal));
            oDataTable.Columns.Add("Quantity", typeof(decimal));
            oDataTable.Columns.Add("Amount", typeof(decimal));
            ViewState["serviceCart"] = oDataTable;
        }

        protected void ddlRoomCode_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlRoomCode.Text != "")
            {
                Customer oCustomer = manager.GetCustomerByRoomCode(ddlRoomCode.SelectedItem.Text);
                lblCustomerCode.Text = oCustomer.CustomerCode;
            }
            else
                ddlRoomCode.Text = "";
        }

        protected void ddlFoodService_SelectedIndexChanged(object sender, EventArgs e)
        {
            lblUnitPrice.Text = ddlFoodService.SelectedValue;
        }

        protected void txtQuantity_TextChanged(object sender, EventArgs e)
        {
            lblAmount.Text = (Convert.ToDouble(lblUnitPrice.Text) * Convert.ToDouble(txtQuantity.Text)).ToString();
        }

        protected void btnAddService_Click(object sender, EventArgs e)
        {
            DataTable oDataTable = (DataTable)ViewState["serviceCart"];

            foreach (DataRow oDataRow in oDataTable.Rows)
            {
                if (oDataRow["Service"].ToString() == ddlFoodService.SelectedItem.Text)
                    return;
            }
            oDataTable.Rows.Add(ddlFoodService.SelectedItem.Text, Convert.ToDecimal(lblUnitPrice.Text), Convert.ToDecimal(txtQuantity.Text), Convert.ToDecimal(lblAmount.Text));
            gvServiceCart.DataSource = oDataTable;
            gvServiceCart.DataBind();
            ViewState["serviceCart"] = oDataTable;

            ClearTextBoxes();
            CalculateTotalAmount(oDataTable);
        }

        private void CalculateTotalAmount(DataTable oDataTable)
        {
            decimal totalAmount = 0;
            foreach (DataRow oDataRow in oDataTable.Rows)
                totalAmount += Convert.ToDecimal(oDataRow["Amount"]);
            lblTotalAmount.Text = totalAmount.ToString();
        }

        protected void saveButtonButton_Click(object sender, EventArgs e)
        {
            if (roomNumberDropDownList.Text == "" || serviceCartGridView.Rows.Count < 1)
                return;

            Customer customer = new Customer();
            customer.CustomerId = customerIdLabel.Text;
            Room room = new Room(customer, Convert.ToInt32(roomNumberDropDownList.Text));
            bool result = serviceGateway.SaveConsumedServices(room, (DataTable)ViewState["serviceCart"]);
            if (result)
                statusLabel.Text = "Consumed services saved successfully.";
            else
                statusLabel.Text = "Consumed services not saved";
        }

        private void ClearTextBoxes()
        {
            ddlFoodService.Text = "";
            lblUnitPrice.Text = "0";
            txtQuantity.Text = "";
            lblAmount.Text = "0";
        }

        #endregion
        
    }
}