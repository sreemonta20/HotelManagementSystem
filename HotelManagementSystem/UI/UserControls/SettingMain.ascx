<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="SettingMain.ascx.cs" Inherits="HotelManagementSystem.UI.UserControls.SettingMain" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<%@ Implements Interface="System.Web.UI.WebControls.WebParts.IWebPart" %>

<link href="../App_Themes/MSN_Blue/default.css" rel="stylesheet" type="text/css" />

<ul id="Ul1" class="menutextindent" runat="server">
    
    <li id="li4" runat="server">
        <asp:LinkButton ID="lnkCustomerRegistration" runat="server" CssClass="menutextindent" 
            ToolTip="Customer Registration" onclick="lnkCustomerRegistration_Click">Customer Registration</asp:LinkButton>
    </li>
    <li id="li5" runat="server">
        <asp:LinkButton ID="lnkServiceForm" runat="server" CssClass="menutextindent" 
            ToolTip="Service Form" onclick="lnkServiceForm_Click">Service Form</asp:LinkButton>
    </li>
    <li id="li6" runat="server">
        <asp:LinkButton ID="lnkCustomerCheckOut" runat="server" CssClass="menutextindent" 
            ToolTip="Customer Check Out" onclick="lnkCustomerCheckOut_Click">Customer Check Out</asp:LinkButton>
    </li>
    <li id="li7" runat="server">
        <asp:LinkButton ID="lnkManagementIncomeReport" runat="server" CssClass="menutextindent" 
            ToolTip="Income Report" onclick="lnkManagementIncomeReport_Click">Income Report</asp:LinkButton>
    </li>
    <li id="li8" runat="server">
        <asp:LinkButton ID="lnkCustomerHistoryReport" runat="server" CssClass="menutextindent" 
            ToolTip="Customer History Report" onclick="lnkCustomerHistoryReport_Click">Customer History Report</asp:LinkButton>
    </li>
    <li id="li1" runat="server">
        <asp:LinkButton ID="lnkAdminPanel" runat="server" CssClass="menutextindent" 
            ToolTip="Admin Panel" onclick="lnkAdminPanel_Click">Admin Panel</asp:LinkButton>
    </li>
    
    <li id="li2" runat="server">
        <asp:LinkButton ID="lnkChangePassword" runat="server" CssClass="menutextindent" 
            ToolTip="Change Password" onclick="lnkChangePassword_Click">Change Password</asp:LinkButton>
    </li> 
     
</ul>