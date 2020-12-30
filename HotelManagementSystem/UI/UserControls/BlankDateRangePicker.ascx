<%@ Control Language="C#" AutoEventWireup="true" Codebehind="BlankDateRangePicker.ascx.cs" Inherits="HotelManagementSystem.UI.UserControls.BlankDateRangePicker" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>

<table border="0" cellpadding="0" cellspacing="0">
    <tr style="padding-bottom:5px;">
        <td align="left"><asp:TextBox CssClass="txtbox" ID="txtDateFrom" Font-Bold="false" Font-Size="X-Small" runat="server" Width="70px" Height="15px"  />&nbsp;
            <asp:ImageButton runat="Server" ID="imgbtnDateFrom" ImageUrl="~/Images/calender_icon.png" AlternateText="Click to show calendar" ImageAlign="AbsMiddle" Height="16px" 
                Width="16px" />
                          
            <ajaxToolkit:CalendarExtender ID="calExtDateFrom" runat="server" TargetControlID="txtDateFrom"  PopupButtonID="imgbtnDateFrom"  />
                         
        </td>
    </tr>  
    <tr style="padding-top:5px;">
        <td align="left"><asp:TextBox CssClass="txtbox" ID="txtDateTo" Font-Bold="false" Font-Size="X-Small" runat="server" Width="70px" Height="15px" />&nbsp;
            <asp:ImageButton runat="Server" ID="imgbtnDateTo" 
                ImageUrl="~/Images/calender_icon.png" 
                AlternateText="Click to show calendar" ImageAlign="AbsMiddle" Height="16px" 
                Width="16px" />
                       
            <ajaxToolkit:CalendarExtender ID="calExtDateTo" runat="server" TargetControlID="txtDateTo" PopupButtonID="imgbtnDateTo" />
            
        </td>
    </tr>       
</table>