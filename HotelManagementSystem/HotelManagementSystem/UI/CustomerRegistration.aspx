<%@ Page Title="" Language="C#" MasterPageFile="~/UI/Site.Master" AutoEventWireup="true" CodeBehind="CustomerRegistration.aspx.cs" Inherits="HotelManagementSystem.UI.CustomerRegistration" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <script type="text/javascript">
        $(document).ready(function () {
            $("#<%=txtArrivalDate.ClientID %>").dynDateTime({
                showsTime: true,
                ifFormat: "%Y/%m/%d %H:%M",
                daFormat: "%l;%M %p, %e %m,  %Y",
                align: "BR",
                electric: false,
                singleClick: false,
                displayArea: ".siblings('.dtcDisplayArea')",
                button: ".next()"
            });
        });
    </script>
    <script type="text/javascript">
        $(document).ready(function () {
            $("#<%=txtDepartureDate.ClientID %>").dynDateTime({
                showsTime: true,
                ifFormat: "%Y/%m/%d %H:%M",
                daFormat: "%l;%M %p, %e %m,  %Y",
                align: "BR",
                electric: false,
                singleClick: false,
                displayArea: ".siblings('.dtcDisplayArea')",
                button: ".next()"
            });
        });
    </script>
    <table style="width: 100%" class="tblmas">
        <tr>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td class="pageheader">Customer Registration</td>
        </tr>
        <tr>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td>

                <table style="width: 100%" class="tbl">
                    <tr>
                        <td style="width: 64px">&nbsp;</td>
                        <td style="width: 132px">Room Type</td>
                        <td style="width: 8px">::</td>
                        <td style="width: 107px">
                            <asp:DropDownList ID="ddlRoomTypeName" runat="server" OnSelectedIndexChanged="ddlRoomTypeName_SelectedIndexChanged" AutoPostBack="True"
                                CssClass="txtbox" Width="150px">
                            </asp:DropDownList>
                        </td>
                        <td style="width: 111px">Room Rent (TK)</td>
                        <td>
                            <asp:Label ID="lblRoomRent" runat="server">0</asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 64px; height: 10px"></td>
                        <td style="width: 132px; height: 10px"></td>
                        <td style="width: 8px; height: 10px"></td>
                        <td style="width: 107px; height: 10px"></td>
                        <td style="height: 10px; width: 111px"></td>
                        <td style="height: 10px"></td>
                    </tr>
                    <tr>
                        <td style="width: 64px">&nbsp;</td>
                        <td style="width: 132px">Room Number</td>
                        <td style="width: 8px">::</td>
                        <td style="width: 107px">
                            <asp:DropDownList ID="ddlRoomCode" runat="server" CssClass="txtbox"
                                Width="150px">
                            </asp:DropDownList>
                        </td>
                        <td style="width: 111px">&nbsp;</td>
                        <td>&nbsp;</td>
                    </tr>
                    <tr>
                        <td style="width: 64px; height: 10px"></td>
                        <td style="width: 132px; height: 10px"></td>
                        <td style="width: 8px; height: 10px"></td>
                        <td style="width: 107px; height: 10px"></td>
                        <td style="height: 10px; width: 111px"></td>
                        <td style="height: 10px"></td>
                    </tr>
                    <tr>
                        <td style="width: 64px; height: 10px">&nbsp;</td>
                        <td style="width: 132px; height: 10px">&nbsp;</td>
                        <td style="width: 8px; height: 10px">&nbsp;</td>
                        <td style="width: 107px; height: 10px">
                            <asp:RadioButtonList ID="rbtLstCustomer" runat="server" AutoPostBack="True"
                                OnSelectedIndexChanged="rbtLstCustomer_SelectedIndexChanged" Width="180px">
                                <asp:ListItem Selected="True">New Customer</asp:ListItem>
                                <asp:ListItem>Existing Customer</asp:ListItem>
                            </asp:RadioButtonList>
                        </td>
                        <td style="height: 10px; width: 111px">&nbsp;</td>
                        <td style="height: 10px">&nbsp;</td>
                    </tr>
                    <tr>
                        <td style="width: 64px; height: 10px">&nbsp;</td>
                        <td style="width: 132px; height: 10px">&nbsp;</td>
                        <td style="width: 8px; height: 10px">&nbsp;</td>
                        <td style="width: 107px; height: 10px">&nbsp;</td>
                        <td style="height: 10px; width: 111px">&nbsp;</td>
                        <td style="height: 10px">&nbsp;</td>
                    </tr>
                    <tr>
                        <td style="width: 64px">&nbsp;</td>
                        <td style="width: 132px">Customer ID</td>
                        <td style="width: 8px">::</td>
                        <td style="width: 107px">
                            <asp:TextBox ID="txtCustomerCode" runat="server" CssClass="txtbox"
                                ReadOnly="True" Width="150px"></asp:TextBox>
                            <asp:DropDownList ID="ddlCustomerCode" runat="server"
                                AutoPostBack="True"
                                OnSelectedIndexChanged="ddlCustomerCode_SelectedIndexChanged"
                                Width="150px">
                            </asp:DropDownList>
                        </td>
                        <td style="width: 111px">&nbsp;</td>
                        <td>&nbsp;</td>
                    </tr>
                    <tr>
                        <td style="width: 64px; height: 10px"></td>
                        <td style="width: 132px; height: 10px"></td>
                        <td style="width: 8px; height: 10px"></td>
                        <td style="width: 107px; height: 10px"></td>
                        <td style="height: 10px; width: 111px"></td>
                        <td style="height: 10px"></td>
                    </tr>
                    <tr>
                        <td style="width: 64px">&nbsp;</td>
                        <td style="width: 132px">Customer Name</td>
                        <td style="width: 8px">::</td>
                        <td style="width: 107px">
                            <asp:TextBox ID="txtCustomerName" runat="server" CssClass="txtbox"
                                Width="218px"></asp:TextBox>
                        </td>
                        <td style="width: 111px">&nbsp;</td>
                        <td>&nbsp;</td>
                    </tr>
                    <tr>
                        <td style="width: 64px; height: 10px"></td>
                        <td style="width: 132px; height: 10px"></td>
                        <td style="width: 8px; height: 10px"></td>
                        <td style="width: 107px; height: 10px"></td>
                        <td style="height: 10px; width: 111px"></td>
                        <td style="height: 10px"></td>
                    </tr>
                    <tr>
                        <td style="width: 64px">&nbsp;</td>
                        <td style="width: 132px">Address</td>
                        <td style="width: 8px">::</td>
                        <td style="width: 107px">
                            <asp:TextBox ID="txtCustomerAddress" runat="server" CssClass="txtbox" Width="218px"></asp:TextBox>
                        </td>
                        <td style="width: 111px">&nbsp;</td>
                        <td>&nbsp;</td>
                    </tr>
                    <tr>
                        <td style="width: 64px; height: 10px"></td>
                        <td style="width: 132px; height: 10px"></td>
                        <td style="width: 8px; height: 10px"></td>
                        <td style="width: 107px; height: 10px"></td>
                        <td style="height: 10px; width: 111px"></td>
                        <td style="height: 10px"></td>
                    </tr>
                    <tr>
                        <td style="width: 64px">&nbsp;</td>
                        <td style="width: 132px">Phone</td>
                        <td style="width: 8px">::</td>
                        <td style="width: 107px">
                            <asp:TextBox ID="txtCustomerPhone" runat="server" CssClass="txtbox" Width="218px"></asp:TextBox>
                        </td>
                        <td style="width: 111px">&nbsp;</td>
                        <td>&nbsp;</td>
                    </tr>
                    <tr>
                        <td style="width: 64px; height: 10px"></td>
                        <td style="width: 132px; height: 10px"></td>
                        <td style="width: 8px; height: 10px"></td>
                        <td style="width: 107px; height: 10px"></td>
                        <td style="height: 10px; width: 111px"></td>
                        <td style="height: 10px"></td>
                    </tr>
                    <tr>
                        <td style="width: 64px">&nbsp;</td>
                        <td style="width: 132px">Email Address</td>
                        <td style="width: 8px">::</td>
                        <td style="width: 107px">
                            <asp:TextBox ID="txtCustomerEmail" runat="server" CssClass="txtbox" Width="218px"></asp:TextBox>
                        </td>
                        <td style="width: 111px">&nbsp;</td>
                        <td>&nbsp;</td>
                    </tr>
                    <tr>
                        <td style="width: 64px; height: 10px"></td>
                        <td style="width: 132px; height: 10px"></td>
                        <td style="width: 8px; height: 10px"></td>
                        <td style="width: 107px; height: 10px"></td>
                        <td style="width: 111px; height: 10px"></td>
                        <td style="height: 10px"></td>
                    </tr>
                    <tr>
                        <td style="width: 64px">&nbsp;</td>
                        <td style="width: 132px">Purpose of Journey</td>
                        <td style="width: 8px">::</td>
                        <td style="width: 107px">
                            <asp:TextBox ID="txtPuposeOfJourney" runat="server" CssClass="txtbox"
                                Width="218px"></asp:TextBox>
                        </td>
                        <td style="width: 111px">&nbsp;</td>
                        <td>&nbsp;</td>
                    </tr>
                    <tr>
                        <td style="width: 64px">&nbsp;</td>
                        <td style="width: 132px">Arrival Date</td>
                        <td style="width: 8px">::</td>
                        <td style="width: 107px">
                            <asp:TextBox ID="txtArrivalDate" runat="server" CssClass="txtbox"
                                Width="190px"></asp:TextBox><img id="imgArrivalDate" alt="" src="../App_Themes/MSN_Blue/Images/calender.png" />

                        </td>
                        <td style="width: 111px">&nbsp;</td>
                        <td>&nbsp;</td>
                    </tr>
                    <tr>
                        <td style="width: 64px">&nbsp;</td>
                        <td style="width: 132px">Departure Date</td>
                        <td style="width: 8px">::</td>
                        <td style="width: 107px">
                            <asp:TextBox ID="txtDepartureDate" runat="server" CssClass="txtbox"
                                Width="190px"></asp:TextBox><img id="imgDepartureDate" alt="" src="../App_Themes/MSN_Blue/Images/calender.png" />

                        </td>
                        <td style="width: 111px">&nbsp;</td>
                        <td>&nbsp;</td>
                    </tr>
                    <tr>
                        <td style="width: 64px">&nbsp;</td>
                        <td style="width: 132px"></td>
                        <td style="width: 8px">&nbsp;</td>
                        <td style="width: 107px"></td>
                        <td style="width: 111px">&nbsp;</td>
                        <td>&nbsp;</td>
                    </tr>
                    <tr>
                        <td style="width: 64px">&nbsp;</td>
                        <td style="width: 132px">&nbsp;</td>
                        <td style="width: 8px">&nbsp;</td>
                        <td style="width: 107px">
                            <table style="width: 144%">
                                <tr>
                                    <td style="width: 81px">
                                        <asp:Button ID="btnSaveCustomer" runat="server" CssClass="btn" Text="Save"
                                            Width="77px" OnClick="btnSaveCustomer_Click" />
                                    </td>
                                    <td>&nbsp;</td>
                                    <td>
                                        <asp:Button ID="btnClear" runat="server" CssClass="btn" Text="Clear"
                                            Width="77px" />
                                    </td>
                                </tr>
                            </table>
                        </td>
                        <td style="width: 111px">&nbsp;</td>
                        <td>&nbsp;</td>
                    </tr>
                    <tr>
                        <td style="width: 64px">&nbsp;</td>
                        <td style="width: 132px">&nbsp;</td>
                        <td style="width: 8px">&nbsp;</td>
                        <td style="width: 107px">&nbsp;</td>
                        <td style="width: 111px">&nbsp;</td>
                        <td>&nbsp;</td>
                    </tr>
                    <tr>
                        <td style="width: 64px">&nbsp;</td>
                        <td colspan="4">
                            <asp:Label ID="lblStatus" runat="server" Font-Size="Small" Font-Bold="True"></asp:Label>
                            <asp:Label ID="lblErrorMsgCustReg" runat="server" Font-Bold="False" Font-Names="Verdana" ForeColor="Red" Text=""></asp:Label>
                        </td>
                        <td>&nbsp;</td>
                    </tr>
                </table>

            </td>
        </tr>
        <tr>
            <td style="height: 21px">&nbsp;</td>
        </tr>
        <tr>
            <td>&nbsp;</td>
        </tr>
    </table>
</asp:Content>
