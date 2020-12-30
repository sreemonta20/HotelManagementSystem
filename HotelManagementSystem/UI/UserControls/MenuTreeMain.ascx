<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="MenuTreeMain.ascx.cs" Inherits="HotelManagementSystem.UI.UserControls.MenuTreeMain" %>
<%@ Implements Interface="System.Web.UI.WebControls.WebParts.IWebPart" %>


<table id="tblmenu" runat="server"  >
    <tr>
        <td style="padding-right: 10px" valign="top">
             
            <asp:TreeView ID="MenuTreeView" runat="server"  
                OnSelectedNodeChanged="MenuTreeView_SelectedNodeChanged" ImageSet="Simple" 
                ExpandDepth="0" NodeIndent="10">
                <ParentNodeStyle Font-Bold="False" />
                <HoverNodeStyle Font-Underline="True" ForeColor="#DD5555" />
                <SelectedNodeStyle Font-Underline="True" HorizontalPadding="0px" 
                    VerticalPadding="0px" ForeColor="#DD5555" />
                    
                <DataBindings>                
                      <asp:TreeNodeBinding  DataMember="hotelmanagement" TargetField="Tergate" TextField="Text" ToolTipField="Tooltip" ValueField="ID" />
                      
                </DataBindings>
                 
                <NodeStyle Font-Names="Verdana" Font-Size="8pt" ForeColor="Black" 
                    HorizontalPadding="0px" NodeSpacing="0px" VerticalPadding="0px" />
            </asp:TreeView>
             
        </td>
    </tr>
</table>