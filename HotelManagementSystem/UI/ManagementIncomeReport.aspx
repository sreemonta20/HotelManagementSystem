<%@ Page Title="" Language="C#" MasterPageFile="~/UI/Site.Master" AutoEventWireup="true" CodeBehind="ManagementIncomeReport.aspx.cs" Inherits="HotelManagementSystem.UI.ManagementIncomeReport" %>

<%--<%@ Register src="UserControls/BlankDateRangePicker.ascx" tagname="BlankDateRangePicker" tagprefix="uc1" %>--%>
<%@ Register TagPrefix="Acme" TagName="DateRangePicker" Src="~/UI/UserControls/BlankDateRangePicker.ascx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <table style="width: 100%" class="tblmas">
        <tr>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td class="pageheader">Customer Information Report</td>
        </tr>
        <tr>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td>
                <table style="width: 100%" class="tbl">
                    <tr>
                        <td style="width: 64px">&nbsp;</td>
                        <td colspan="3">
                            <asp:RadioButtonList ID="rbtLstReportBy" runat="server" RepeatDirection="Vertical" RepeatLayout="Flow" CssClass="floatleft width150">
                                <asp:ListItem Text="Income Details (Room Rent)" Value="RoomWiseDetails" Selected="True"></asp:ListItem>
                                <asp:ListItem Text="Income Summary (Room Rent)" Value="RoomWiseSummary"></asp:ListItem>
                                <asp:ListItem Text="Income Summary (Service)" Value="ServiceWiseSummary"></asp:ListItem>
                            </asp:RadioButtonList>
                        </td>
                        <td>&nbsp;</td>
                    </tr>
                    <tr>
                        <td style="width: 64px">&nbsp;</td>
                        <td style="width: 111px">&nbsp;</td>
                        <td style="width: 19px">&nbsp;</td>
                        <td>&nbsp;</td>
                        <td>&nbsp;</td>
                        <td>&nbsp;</td>
                    </tr>
                    <tr id="rowDateRange" runat="server">
                        <td style="width: 64px; height: 10px;"></td>
                        <td  colspan="3">

                            <table border="0" cellpadding="0" cellspacing="0" width="90%">
                                <tr>
                                    <td class="fieldname" style="width: 110px;">
                                        <asp:Label ID="lblDateFrom" runat="server"  Text="Date From :" />
                                        &nbsp; </td>
                                    <td align="left" rowspan="2" valign="middle">
                                        
                                        <Acme:DateRangePicker ID="DateRangePickerCustomer" runat="server" />
                                    </td>
                                </tr>
                                <tr>
                                    <td class="fieldname" style="width: 110px;">
                                        <asp:Label ID="lblDateTo" runat="server"  Text="Date To :" />
                                        &nbsp; </td>
                                </tr>
                            </table>

                        </td>
                        <td>&nbsp;</td>
                    </tr>
                    
                    <tr>
                        <td style="width: 64px">&nbsp;</td>
                        <td style="width: 111px">&nbsp;</td>
                        <td style="width: 19px">&nbsp;</td>
                        <td>&nbsp;</td>
                        <td>&nbsp;</td>
                        <td>&nbsp;</td>
                    </tr>
                    <tr>
                        <td style="width: 64px">&nbsp;</td>
                        <td style="width: 111px">&nbsp;</td>
                        <td style="width: 19px">&nbsp;</td>
                        <td>
                            <asp:Button ID="btnCustomerReport" runat="server" CssClass="btn" Text="Report"
                                Width="99px" OnClick="btnCustomerReport_Click" />
                        </td>
                        <td>&nbsp;</td>
                        <td>&nbsp;</td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td>&nbsp;</td>
        </tr>
    </table>

</asp:Content>
