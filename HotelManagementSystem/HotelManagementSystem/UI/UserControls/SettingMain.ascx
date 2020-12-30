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
        <asp:LinkButton ID="lnkIncomeReport" runat="server" CssClass="menutextindent" 
            ToolTip="Income Report" onclick="lnkIncomeReport_Click">Income Report</asp:LinkButton>
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
    
    <%--<li id="li3" runat="server">
        <asp:LinkButton ID="lnkLogout" runat="server" CssClass="menutextindent" 
            ToolTip="Log Out" onclick="lnkLogout_Click">Log Out</asp:LinkButton>
            
         <ajaxToolkit:ModalPopupExtender ID="ModalPopupExtender1" runat="server" BackgroundCssClass="modalBackground"
             CancelControlID="ButtonCancel" OkControlID="ButtonOk" PopupControlID="PNL" TargetControlID="lnkLogout">
         </ajaxToolkit:ModalPopupExtender>
         <ajaxToolkit:ConfirmButtonExtender ID="ConfirmButtonExtender2" runat="server" DisplayModalPopupID="ModalPopupExtender1"
             TargetControlID="lnkLogout">
         </ajaxToolkit:ConfirmButtonExtender>
            &nbsp;&nbsp;
         <asp:Panel ID="PNL" runat="server" Style="border-right: #415191 2px solid; padding-right: 20px;
             border-top: #415191 2px solid; display: none; padding-left: 20px; padding-bottom: 20px;
             border-left: #415191 2px solid; width: 200px; padding-top: 20px; border-bottom: #415191 2px solid;
             background-color: white" CssClass="tbl" Visible="False">
             <asp:Image ID="Image1" runat="server" Height="30px" 
                ImageUrl="~/Images/Ques.jpg" Width="30px" BackColor="White" />
                Are you sure, you want to Log Out?
             <br />
             <br />
             <div style="text-align: right">
                 <asp:Button ID="ButtonOk" runat="server"  Text="Yes" CssClass="btn2" Width="58px" />
                 <asp:Button ID="ButtonCancel" runat="server"  Text="No" CssClass="btn2" Width="56px"  />
             </div>
         </asp:Panel>  
                  
     </li>--%>  
</ul>