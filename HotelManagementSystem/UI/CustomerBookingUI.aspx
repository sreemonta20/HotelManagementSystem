<%@ Page Title="" Language="C#" MasterPageFile="~/UI/Site.Master" AutoEventWireup="true" CodeBehind="CustomerBookingUI.aspx.cs" Inherits="HotelManagementSystem.UI.CustomerBookingUI" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <script type="text/javascript">
        alert("Please note that you will be allowed maximum 1 day to hold the booked room.");
    </script>

    <table style="width: 100%" class="tblmas">

        <tr>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td class="pageheader">Customer Booking</td>
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

                            <asp:DropDownList ID="ddlRoomTypeName" runat="server" OnSelectedIndexChanged="ddlRoomTypeName_SelectedIndexChanged" AutoPostBack="true"
                                CssClass="txtbox" Width="150px">
                            </asp:DropDownList>

                        </td>

                        <td style="width: 111px">Room Rent (TK)</td>
                        <td>
                            <asp:UpdatePanel ID="UpdtPnlRoomRent" runat="server" UpdateMode="Conditional">
                                <Triggers>
                                    <asp:AsyncPostBackTrigger ControlID="ddlRoomTypeName" EventName="SelectedIndexChanged" />
                                </Triggers>
                                <ContentTemplate>
                                    <asp:Label ID="lblRoomRent" runat="server">0</asp:Label>
                                </ContentTemplate>

                            </asp:UpdatePanel>
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
                            <asp:UpdatePanel ID="UpdtPnlRoomCode" runat="server" UpdateMode="Conditional">
                                <Triggers>
                                    <asp:AsyncPostBackTrigger ControlID="ddlRoomTypeName" EventName="SelectedIndexChanged" />
                                </Triggers>
                                <ContentTemplate>
                                    <asp:DropDownList ID="ddlRoomCode" runat="server" CssClass="txtbox"
                                        Width="150px">
                                    </asp:DropDownList>
                                </ContentTemplate>

                            </asp:UpdatePanel>
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
                        <td style="width: 111px">
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="txtCustomerName" ErrorMessage="*"></asp:RequiredFieldValidator>

                        </td>
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
                        <td style="width: 111px">
                           <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtCustomerAddress" ErrorMessage="*"></asp:RequiredFieldValidator>

                        </td>
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
                        <td style="width: 111px">
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtCustomerPhone" ErrorMessage="*"></asp:RequiredFieldValidator>

                        </td>
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
                        <td style="width: 111px"><asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtCustomerEmail" ErrorMessage="*"></asp:RequiredFieldValidator></td>
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
                        <td style="width: 111px"><asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtPuposeOfJourney" ErrorMessage="*"></asp:RequiredFieldValidator></td>
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
                                    <td style="width: 85px">
                                        <asp:Button ID="btnBook" runat="server" CssClass="btn" Text="Book room"
                                            Width="77px" OnClick="btnBook_Click" />
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
                            <asp:UpdatePanel ID="updtpnlBook" runat="server" UpdateMode="Conditional">
                                <Triggers>
                                    <asp:AsyncPostBackTrigger ControlID="btnBook" EventName="Click" />

                                </Triggers>
                                <ContentTemplate>
                                    <asp:Label ID="lblStatus" runat="server" Font-Size="Small" Font-Bold="True"></asp:Label>
                                </ContentTemplate>

                            </asp:UpdatePanel>

                            <asp:Label ID="lblErrorMsgBook" runat="server" Font-Bold="False" Font-Names="Verdana" ForeColor="Red" Text=""></asp:Label>
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
