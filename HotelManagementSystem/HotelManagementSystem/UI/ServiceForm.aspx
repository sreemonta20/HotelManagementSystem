<%@ Page Title="" Language="C#" MasterPageFile="~/UI/Site.Master" AutoEventWireup="true" CodeBehind="ServiceForm.aspx.cs" Inherits="HotelManagementSystem.UI.ServiceForm" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table style="width: 100%" class="tblmas">
        <tr>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="pageheader">
                Service</td>
        </tr>
        <tr>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td align="center">
                <table style="width : 100%" class="tbl" >
                    <tr>
                        <td style="width: 53px">
                            &nbsp;</td>
                        <td style="width: 158px">
                            Room Number</td>
                        <td style="width: 16px">
                            ::</td>
                        <td style="width: 181px">
                            <asp:DropDownList ID="ddlRoomCode" runat="server" CssClass="txtbox" 
                                Width="149px" AutoPostBack="True" 
                                onselectedindexchanged="ddlRoomCode_SelectedIndexChanged">
                            </asp:DropDownList>
                        </td>
                        <td style="width: 242px">
                            &nbsp;</td>
                        <td>
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td style="width: 53px; height: 10px">
                            </td>
                        <td style="width: 158px; height: 10px">
                            </td>
                        <td style="width: 16px; height: 10px">
                            </td>
                        <td style="height: 10px; width: 181px">
                            </td>
                        <td style="height: 10px; width: 242px">
                            </td>
                        <td style="height: 10px">
                            </td>
                    </tr>
                    <tr>
                        <td style="width: 53px">
                            &nbsp;</td>
                        <td style="width: 158px">
                            Customer Id</td>
                        <td style="width: 16px">
                            ::</td>
                        <td style="width: 181px">
                            <asp:Label ID="lblCustomerCode" runat="server"></asp:Label>
                        </td>
                        <td style="width: 242px">
                            &nbsp;</td>
                        <td>
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td style="width: 53px; height: 10px">
                            </td>
                        <td style="width: 158px; height: 10px">
                            </td>
                        <td style="width: 16px; height: 10px">
                            </td>
                        <td style="height: 10px; width: 181px">
                            </td>
                        <td style="height: 10px; width: 242px">
                            </td>
                        <td style="height: 10px">
                            </td>
                    </tr>
                    <tr>
                        <td style="width: 53px">
                            &nbsp;</td>
                        <td colspan="4">
                            <table style="width: 100%" border="1px" cellpadding="0" cellspacing="0">
                                <tr>
                                    <td style="width: 168px; height: 20px">
                                        &nbsp; Services</td>
                                    <td style="height: 20px; width: 134px">
                                        &nbsp; Unit Price (Tk)</td>
                                    <td style="height: 20px; width: 180px">
                                        &nbsp; Quantity</td>
                                    <td style="height: 20px">
                                        &nbsp; Amount (Tk)</td>
                                </tr>
                                <tr>
                                    <td style="height: 27px; width: 168px">
                                        &nbsp;
                                        <asp:DropDownList ID="ddlFoodService" runat="server" CssClass="txtbox" 
                                            Width="149px" AutoPostBack="True" 
                                            onselectedindexchanged="ddlFoodService_SelectedIndexChanged">
                                        </asp:DropDownList>
                                    </td>
                                    <td style="height: 27px; width: 134px">
                                        &nbsp;
                                        <asp:Label ID="lblUnitPrice" runat="server" Text="0"></asp:Label>
&nbsp; </td>
                                    <td style="height: 27px; width: 180px">
                                        &nbsp;
                                        <asp:TextBox ID="txtQuantity" runat="server" CssClass="txtbox" Width="85px" 
                                            AutoPostBack="True" ontextchanged="txtQuantity_TextChanged"></asp:TextBox>
                                    </td>
                                    <td style="height: 27px">
                                        &nbsp;
                                        <asp:Label ID="lblAmount" runat="server" Text="0"></asp:Label>
                                    </td>
                                </tr>
                            </table>
                        </td>
                        <td>
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td style="width: 53px; height: 10px">
                            </td>
                        <td style="width: 158px; height: 10px">
                            </td>
                        <td style="width: 16px; height: 10px">
                            </td>
                        <td style="width: 181px; height: 10px">
                            </td>
                        <td style="height: 10px; width: 242px">
                            </td>
                        <td style="height: 10px">
                            </td>
                    </tr>
                    <tr>
                        <td style="width: 53px">
                            &nbsp;</td>
                        <td style="width: 158px">
                            &nbsp;</td>
                        <td style="width: 16px">
                            &nbsp;</td>
                        <td style="width: 181px">
                            &nbsp;</td>
                        <td style="width: 242px" align="right">
                            <asp:Button ID="btnAddService" runat="server" CssClass="btn" Text="Add to Cart" 
                                onclick="btnAddService_Click" />
                        </td>
                        <td>
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td style="width: 53px">
                            &nbsp;</td>
                        <td style="width: 158px">
                            &nbsp;</td>
                        <td style="width: 16px">
                            &nbsp;</td>
                        <td style="width: 181px">
                            &nbsp;</td>
                        <td style="width: 242px">
                            &nbsp;</td>
                        <td>
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td style="width: 53px; height: 146px;">
                            </td>
                        <td colspan="4" style="height: 146px">
                            <asp:GridView ID="gvServiceCart" runat="server" 
                                 Width="595px" SkinID="GridView">
                            </asp:GridView>
                        </td>
                        <td style="height: 146px">
                            </td>
                    </tr>
                    <tr>
                        <td style="width: 53px">
                            &nbsp;</td>
                        <td style="width: 158px">
                            &nbsp;</td>
                        <td style="width: 16px">
                            &nbsp;</td>
                        <td style="width: 181px">
                            &nbsp;</td>
                        <td style="width: 242px">
                            &nbsp;</td>
                        <td>
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td style="width: 53px">
                            &nbsp;</td>
                        <td style="width: 158px">
                            &nbsp;</td>
                        <td style="width: 16px">
                            &nbsp;</td>
                        <td style="width: 181px">
                            Total Amount (Tk) ::</td>
                        <td style="width: 242px">
                            <table style="width: 100%">
                                <tr>
                                    <td style="width: 88px" align="left">
                                        <asp:Label ID="lblTotalAmount" runat="server" Text="0"></asp:Label>
                                    </td>
                                    <td align="right">
                                        <asp:Button ID="btnSave" runat="server" CssClass="btn" Text="Save" 
                                            onclick="btnSave_Click" />
                                    </td>
                                </tr>
                            </table>
                        </td>
                        <td>
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td style="width: 53px">
                            &nbsp;</td>
                        <td style="width: 158px">
                            &nbsp;</td>
                        <td style="width: 16px">
                            &nbsp;</td>
                        <td style="width: 181px">
                            &nbsp;</td>
                        <td style="width: 242px">
                            &nbsp;</td>
                        <td>
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td style="width: 53px">
                            &nbsp;</td>
                        <td colspan="4">
                            <asp:Label ID="lblStatus" runat="server" Font-Bold="True" Font-Size="Small"></asp:Label>
                        </td>
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
