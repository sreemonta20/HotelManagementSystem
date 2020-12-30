<%@ Page Title="" Language="C#" MasterPageFile="~/UI/Site.Master" AutoEventWireup="true" CodeBehind="CustomerHistoryReport.aspx.cs" Inherits="HotelManagementSystem.UI.CustomerHistoryReport" %>

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
                        <td style="width: 150px">
                            <asp:RadioButtonList ID="rbtLstReportBy" runat="server" RepeatDirection="Vertical" RepeatLayout="Flow" CssClass="floatleft width150" 
                            OnSelectedIndexChanged="rbtLstReportBy_SelectedIndexChanged" AutoPostBack="true">
                                <asp:ListItem Text="By Name" Value="By Name" Selected="True"></asp:ListItem>
                                <asp:ListItem Text="By Date Range" Value="By Date Range"></asp:ListItem>
                            </asp:RadioButtonList>
                        </td>
                        <td style="width: 19px">&nbsp;</td>
                        <td>
                            <%--<asp:RadioButton ID="customerNameRadioButton" runat="server"
                                AutoPostBack="True" GroupName="aa"
                                OnCheckedChanged="customerNameRadioButton_CheckedChanged" Text="By Name" />
                            <br />
                            <asp:RadioButton ID="dateRangeRadioButton" runat="server" AutoPostBack="True"
                                Checked="True" GroupName="aa"
                                OnCheckedChanged="dateRangeRadioButton_CheckedChanged" Text="By Date Range" />
                            <br />--%>
                        </td>
                        <td>&nbsp;</td>
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
                    <tr id="rowReportByName" runat="server">
                        <td style="width: 64px">&nbsp;</td>
                        <td style="width: 111px">
                            <asp:Label ID="lblNameSearch" runat="server" Text="Name (Like)"></asp:Label>
                        </td>
                        <td style="width: 19px">::</td>
                        <td>
                            <asp:TextBox ID="txtNameSearch" runat="server" CssClass="txtbox"></asp:TextBox>
                        </td>
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
