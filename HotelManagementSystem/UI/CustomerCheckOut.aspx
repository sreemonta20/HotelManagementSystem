<%@ Page Title="" Language="C#" MasterPageFile="~/UI/Site.Master" AutoEventWireup="true" CodeBehind="CustomerCheckOut.aspx.cs" Inherits="HotelManagementSystem.UI.CustomerCheckOut" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table style="width: 100%" class="tblmas">
        <tr>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="pageheader">
                Customer Check Out</td>
        </tr>
        <tr>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td>
                <table style="width: 100%" class="tbl">
                    <tr>
                        <td style="width: 67px">
                            &nbsp;</td>
                        <td style="width: 143px">
                            Room Number</td>
                        <td style="width: 14px">
                            ::</td>
                        <td>
                            <asp:DropDownList ID="ddlRoomCode" runat="server" 
                                AutoPostBack="True" CssClass="txtbox" 
                                onselectedindexchanged="ddlRoomCode_SelectedIndexChanged" 
                                Width="149px">
                            </asp:DropDownList>
                        </td>
                        <td>
                            &nbsp;</td>
                        <td>
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td style="width: 67px; height: 10px;">
                            </td>
                        <td style="width: 143px; height: 10px;">
                            </td>
                        <td style="width: 14px; height: 10px;">
                            </td>
                        <td style="height: 10px">
                            </td>
                        <td style="height: 10px">
                            </td>
                        <td style="height: 10px">
                            </td>
                    </tr>
                    <tr>
                        <td style="width: 67px">
                            &nbsp;</td>
                        <td style="width: 143px">
                            Customer ID</td>
                        <td style="width: 14px">
                            ::</td>
                        <td>
                            <asp:Label ID="lblCustomerCode" runat="server"></asp:Label>
                        </td>
                        <td>
                            &nbsp;</td>
                        <td>
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td style="width: 67px; height: 10px;">
                            </td>
                        <td style="width: 143px; height: 10px;">
                            </td>
                        <td style="width: 14px; height: 10px;">
                            </td>
                        <td style="height: 10px">
                            </td>
                        <td style="height: 10px">
                            </td>
                        <td style="height: 10px">
                            </td>
                    </tr>
                    <tr>
                        <td style="width: 67px">
                            &nbsp;</td>
                        <td style="width: 143px">
                            Customer Name</td>
                        <td style="width: 14px">
                            ::</td>
                        <td>
                            <asp:Label ID="lblCustomerName" runat="server"></asp:Label>
                        </td>
                        <td>
                            &nbsp;</td>
                        <td>
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td style="width: 67px">
                            &nbsp;</td>
                        <td style="width: 143px">
                            &nbsp;</td>
                        <td style="width: 14px">
                            &nbsp;</td>
                        <td>
                            &nbsp;</td>
                        <td>
                            &nbsp;</td>
                        <td>
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td style="width: 67px">
                            &nbsp;</td>
                        <td style="width: 143px">
                            &nbsp;</td>
                        <td style="width: 14px">
                            &nbsp;</td>
                        <td>
                            <asp:Button ID="btnCheckOut" runat="server" CssClass="btn" 
                                onclick="btnCheckOut_Click" Text="Check Out" />
                        </td>
                        <td>
                            &nbsp;</td>
                        <td>
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td style="width: 67px">
                            &nbsp;</td>
                        <td style="width: 143px">
                            &nbsp;</td>
                        <td style="width: 14px">
                            &nbsp;</td>
                        <td>
                            &nbsp;</td>
                        <td>
                            &nbsp;</td>
                        <td>
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td style="width: 67px">
                            &nbsp;</td>
                        <td colspan="3">
                            <asp:Label ID="lblStatus" runat="server" Font-Bold="True"></asp:Label><asp:Label ID="lblErrorMsgCustReg" runat="server" Font-Bold="False" Font-Names="Verdana" ForeColor="Red" Text=""></asp:Label>
                        </td>
                        <td>
                            &nbsp;</td>
                        <td>
                            &nbsp;</td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td>
                &nbsp;</td>
        </tr>
    </table>
</asp:Content>
