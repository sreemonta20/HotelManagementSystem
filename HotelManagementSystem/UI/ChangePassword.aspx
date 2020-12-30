<%@ Page Title="" Language="C#" MasterPageFile="~/UI/Site.Master" AutoEventWireup="true" CodeBehind="ChangePassword.aspx.cs" Inherits="HotelManagementSystem.UI.ChangePassword" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table class="tblmas" width="100%">
  <tr><td>  
        <table width="100%">
        <tr>
            <td style="height: 21px" ></td>
        </tr>
        
        <tr>
            <td style="text-align: center" class="pageheader">
                Change Password</td>
        </tr>
        
    </table>
    <br />
    
        <span style="font-size: medium">Log on as:</span>&nbsp;
    <asp:Label ID="Lbllogon" runat="server" Text="" Width="108px" 
            Font-Size="Small" Font-Bold="True" ForeColor="#41519A"></asp:Label><br />
    <br />
     <table class="tbl" border="0" cellpadding="4" cellspacing="0" style="border-collapse: collapse; width: 100%;">
                <tr>
                    <td style="text-align: center">
                      <table align="center" border="2" cellpadding="2" style="border-bottom-color:#6B7EBF; border-left-color:#6B7EBF; border-color:#6B7EBF;width: 400px;" cellspacing="0" >
                        <tr><td>
                        <table id="chtab" style="border-color:Black; width: 395px;" border="0" 
                                cellpadding="0" cellspacing="0">
                            <tr>
                                <td align="center" colspan="4" style="font-weight: bold; font-size: 0.9em; color: white;
                                    background-color: #5d7b9d; height: 17px;">
                                    Change Your Password</td>
                            </tr>
                            <tr>
                                <td align="center" style="width: 15px">
                                    &nbsp;</td>
                                <td align="center" colspan="2">
                                    &nbsp;</td>
                                <td>
                                    &nbsp;</td>
                            </tr>
                            <tr>
                                <td align="left" style="width: 15px">
                                    &nbsp;</td>
                                <td align="left" style="width: 188px">
                                    <asp:Label ID="lblCurrentPassword" runat="server" AssociatedControlID="txtCurrentPassword">Current 
                                    Password</asp:Label></td>
                                <td align="left" style="width: 10px">
                                    :</td>
                                <td align="left">
                                    <asp:TextBox ID="txtCurrentPassword" runat="server" Font-Size="0.8em" 
                                        TextMode="Password" CssClass="txtbox"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="CurrentPasswordRequired" runat="server" ControlToValidate="txtCurrentPassword"
                                        ErrorMessage="Password is required." ToolTip="Password is required." 
                                        ValidationGroup="VgChangePassword">*</asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td align="left" style="width: 15px">
                                    &nbsp;</td>
                                <td align="left" colspan="2">
                                    &nbsp;</td>
                                <td>
                                    &nbsp;</td>
                            </tr>
                            <tr align="left">
                                <td align="left" style="width: 15px">
                                    &nbsp;</td>
                                <td align="left" style="width: 188px">
                                    <asp:Label ID="lblNewPassword" runat="server" AssociatedControlID="txtNewPassword">New 
                                    Password</asp:Label></td>
                                <td align="left" style="width: 10px">
                                    :</td>
                                <td>
                                    <asp:TextBox ID="txtNewPassword" runat="server" Font-Size="0.8em" 
                                        TextMode="Password" CssClass="txtbox"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="NewPasswordRequired" runat="server" ControlToValidate="txtNewPassword"
                                        ErrorMessage="New Password is required." ToolTip="New Password is required."
                                        ValidationGroup="VgChangePassword">*</asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr align="left">
                                <td align="left" style="width: 15px">
                                    &nbsp;</td>
                                <td align="left" colspan="2">
                                    &nbsp;</td>
                                <td>
                                    &nbsp;</td>
                            </tr>
                            <tr>
                                <td align="left" style="width: 15px">
                                    &nbsp;</td>
                                <td align="left" style="width: 188px">
                                    <asp:Label ID="lblConfirmNewPassword" runat="server" AssociatedControlID="txtConfirmNewPassword">Confirm 
                                    New Password</asp:Label></td>
                                <td align="left" style="width: 10px">
                                    :</td>
                                <td align="left">
                                    <asp:TextBox ID="txtConfirmNewPassword" runat="server" Font-Size="0.8em" 
                                        TextMode="Password" CssClass="txtbox"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="ConfirmNewPasswordRequired" runat="server" ControlToValidate="txtConfirmNewPassword"
                                        ErrorMessage="Confirm New Password is required." ToolTip="Confirm New Password is required."
                                        ValidationGroup="VgChangePassword">*</asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td align="left" style="width: 15px">
                                    &nbsp;</td>
                                <td align="left" colspan="2">
                                    &nbsp;</td>
                                <td>
                                    &nbsp;</td>
                            </tr>
                            <tr>
                                <td align="center" style="width: 15px">
                                    &nbsp;</td>
                                <td align="center" colspan="3">
                                    <asp:CompareValidator ID="CompareNewPassword" runat="server" ControlToCompare="txtNewPassword"
                                        ControlToValidate="txtConfirmNewPassword" Display="Dynamic" ErrorMessage="Confirm Password must match the New Password."
                                        ValidationGroup="VgChangePassword"></asp:CompareValidator>
                                </td>
                            </tr>
                            <tr>
                                <td align="center" style="color: red; width: 15px;">
                                    &nbsp;</td>
                                <td id="failureText" align="center" colspan="3" style="color: red" runat="server" visible="false">
                                    <asp:Literal ID="txtFailure"  runat="server" EnableViewState="False"></asp:Literal>
                                </td>
                                <td id="successText" align="center" colspan="3" style="color: greenyellow" runat="server" visible="false">
                                    <asp:Literal ID="txtSuccess"  runat="server" EnableViewState="False"></asp:Literal>
                                </td>
                            </tr>
                            <tr>
                                <td align="center" style="color: red; width: 15px;">
                                    &nbsp;</td>
                                <td align="center" colspan="3" style="color: red">
                                    &nbsp;</td>
                            </tr>
                            <tr>
                                <td align="right" style="width: 15px">
                                    &nbsp;</td>
                                <td align="center" colspan="3">
                                    <asp:Button ID="btnChangePassword" runat="server" 
                                        CommandName="ChangePassword" Text="Change Password" 
                                        ValidationGroup="VgChangePassword" OnClick="btnChangePassword_Click" 
                                        CssClass="btn" Width="130px" />
                                </td>
                            </tr>
                            <tr>
                                <td align="right" style="width: 15px">
                                    &nbsp;</td>
                                <td align="right" colspan="2">
                                    &nbsp;</td>
                                <td>
                                    &nbsp;</td>
                            </tr>
                            </table>
                        
                        </td></tr>
                      </table>
                      
                    </td>
                </tr>
            </table>
   
   </td></tr>
  <tr><td>  
        &nbsp;</td></tr>
  </table> 
</asp:Content>
