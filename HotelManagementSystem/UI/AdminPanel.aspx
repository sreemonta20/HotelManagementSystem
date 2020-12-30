<%@ Page Title="" Language="C#" MasterPageFile="~/UI/Site.Master" AutoEventWireup="true" CodeBehind="AdminPanel.aspx.cs" Inherits="HotelManagementSystem.UI.AdminPanel" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:UpdatePanel ID="upAdminPanel" runat="server">
        <ContentTemplate>
            <cc1:CollapsiblePanelExtender ID="cpeBookCustomerRoomProcess" runat="Server" TargetControlID="panelContentCustomerBookProcess" Collapsed="True" CollapsedSize="0"
                ExpandedSize="310"
                ExpandControlID="panelTitleCustomerBookProcess" CollapseControlID="panelTitleCustomerBookProcess" AutoCollapse="False" AutoExpand="False" SuppressPostBack="True"
                CollapsedText="Show Details..." ExpandedText="Hide Details" ImageControlID="imgCustomerBookProcess" ExpandedImage="~/Images/customerBookProcessColapse.png"
                CollapsedImage="~/Images/customerBookProcessExpand.png">
            </cc1:CollapsiblePanelExtender>
            <div id="allAPDiv" style="width: 100%;">
                <div id="customerBookProcessAPDiv" style="width: 50%; float: left;">
                    <asp:Panel ID="panelTitleCustomerBookProcess" runat="server" Height="25px" Width="405px">
                        <img id="imgCustomerBookProcess" src="../Images/customerBookProcessColapse.png" alt="imgCustomerBookProcess" />
                    </asp:Panel>
                    <asp:Panel ID="panelContentCustomerBookProcess" runat="server" Height="250px" Width="415px">
                        <div style='width: 300px; margin-top: 10px; margin-bottom: 10px; margin-left: 20px; margin-right: 10px; padding-top: 10px; padding-bottom: 10px; 
                        padding-right: 10px; padding-left: 10px; border-top-width: 0px; border-bottom-width: 0px; border-left-width: 2px; border-right-width: 2px; 
                        border-style: none; border-color: #cccccc;'>
                            <asp:Button ID="btnCustomerBookProcess" runat="server" CssClass="btn" Text="Process"
                                Width="61px" OnClick="btnCustomerBookProcess_Click" /><br />
                            <asp:Label ID="lblMsgCustomerBookProcessOk" runat="server" Visible="false" Font-Bold="False" Font-Names="Verdana" ForeColor="#00ccff" Text=""></asp:Label>
                            <asp:Label ID="lblMsgCustomerBookProcessErr" runat="server" Visible="false" Font-Bold="False" Font-Names="Verdana" ForeColor="Red" Text=""></asp:Label>
                        </div>
                    </asp:Panel>
                </div>
                <div id="otherAPDiv" style="width: 40%; float: right;"></div>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
