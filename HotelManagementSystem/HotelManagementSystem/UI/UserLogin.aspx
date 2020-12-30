<%@ Page Title="" Language="C#" MasterPageFile="~/UI/Site.Master" AutoEventWireup="true" CodeBehind="UserLogin.aspx.cs" Inherits="HotelManagementSystem.UI.UserLogin" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table width="100%" class="tblmas" border="0" cellpadding="0" cellspacing="0">
        <tr>
            <td>


                <table style="width: 100%">
                    <tr>
                        <td>&nbsp;</td>
                    </tr>
                    <tr>
                        <td>
                            <marquee style="Z-INDEX: 114; LEFT: 230px; WIDTH: 720px; POSITION: absolute; TOP: 160px; HEIGHT: 18px"
                                behavior="scroll"><FONT face="Verdana" size="2" color="#6B7EBF"><STRONG> 
				         Please Enter User ID and Password For Login Now! ......</STRONG> </FONT></marquee>
                            <%--<marquee behavior="scroll" direction="left">Your scrolling text goes here</marquee>--%>
                          
                        </td>
                    </tr>
                    <tr>
                        <td style="height: 16px"></td>
                    </tr>
                    <tr>
                        <td>&nbsp;</td>
                    </tr>
                    <tr>
                        <td>&nbsp;</td>
                    </tr>
                    <tr>
                        <td style="height: 16px"></td>
                    </tr>
                </table>

                <table width="100%">
                    <tr>
                        <td align="center">
                            <table align="center" border="2" cellpadding="2" style="border-bottom-color: #6B7EBF; border-left-color: #6B7EBF; border-color: #6B7EBF;"
                                cellspacing="0">
                                <tr>
                                    <td>
                                        <asp:Panel ID="Panel1" runat="server" DefaultButton="LoginButton">

                                            <table class="tbl" border="0" cellpadding="0" cellspacing="0">
                                                <tr>
                                                    <td class="pageheader" colspan="8">
                                                        <b>User Login</b></td>
                                                </tr>
                                                <tr>
                                                    <td style="width: 1px" rowspan="10" width="1px">&nbsp;</td>
                                                    <td class="tbl" style="width: 4px">&nbsp;</td>
                                                    <td class="tbl" style="width: 108px">&nbsp;</td>
                                                    <td style="width: 18px">&nbsp;</td>
                                                    <td style="width: 208px">&nbsp;</td>
                                                    <td style="width: 4px">&nbsp;</td>
                                                    <td style="width: 36px">&nbsp;</td>
                                                    <td style="width: 1px" rowspan="10" width="1px">&nbsp;</td>
                                                </tr>
                                                <tr>
                                                    <td class="tbl" style="width: 4px; height: 5px;">&nbsp;</td>
                                                    <td class="tbl" style="width: 108px; height: 5px;"></td>
                                                    <td style="width: 18px; height: 5px;"></td>
                                                    <td style="width: 208px; height: 5px;"></td>
                                                    <td style="width: 4px; height: 5px;"></td>
                                                    <td style="height: 5px; width: 36px;"></td>
                                                </tr>
                                                <tr>
                                                    <td style="width: 4px" align="left">&nbsp;</td>
                                                    <td style="width: 108px" align="left">User ID</td>
                                                    <td style="width: 18px">:</td>
                                                    <td style="width: 208px">
                                                        <asp:TextBox ID="txtUserName" runat="server" CssClass="txtbox" Width="206px"></asp:TextBox>
                                                    </td>
                                                    <td style="width: 4px">&nbsp;</td>
                                                    <td style="width: 36px">
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server"
                                                            ControlToValidate="txtUserName" ErrorMessage="*"></asp:RequiredFieldValidator>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td style="width: 4px; height: 5px">&nbsp;</td>
                                                    <td style="width: 108px; height: 5px"></td>
                                                    <td style="width: 18px; height: 5px"></td>
                                                    <td style="height: 5px; width: 208px"></td>
                                                    <td style="height: 5px; width: 4px"></td>
                                                    <td style="height: 5px; width: 36px;"></td>
                                                </tr>
                                                <tr>
                                                    <td style="width: 4px" align="left">&nbsp;</td>
                                                    <td style="width: 108px" align="left">Password</td>
                                                    <td style="width: 18px">:</td>
                                                    <td style="width: 208px">
                                                        <asp:TextBox ID="txtPassword" runat="server" CssClass="txtbox" Width="206px"
                                                            TextMode="Password"></asp:TextBox>
                                                    </td>
                                                    <td style="width: 4px">&nbsp;</td>
                                                    <td style="width: 36px">
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server"
                                                            ControlToValidate="txtPassword" ErrorMessage="*"></asp:RequiredFieldValidator>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td style="width: 4px">&nbsp;</td>
                                                    <td style="width: 108px">&nbsp;</td>
                                                    <td style="width: 18px">&nbsp;</td>
                                                    <td style="width: 208px">&nbsp;</td>
                                                    <td style="width: 4px">&nbsp;</td>
                                                    <td style="width: 36px">&nbsp;</td>
                                                </tr>
                                                <tr>
                                                    <td style="width: 4px">&nbsp;</td>
                                                    <td align="left" colspan="3">
                                                        <asp:CheckBox ID="CheckBox1" runat="server" Font-Size="Smaller"
                                                            ForeColor="Black" Text="Remember me, when I login next time." />
                                                    </td>
                                                    <td style="width: 4px">&nbsp;</td>
                                                    <td style="width: 36px">&nbsp;</td>
                                                </tr>
                                                <tr>
                                                    <td style="width: 4px">&nbsp;</td>
                                                    <td style="width: 108px">&nbsp;</td>
                                                    <td style="width: 18px">&nbsp;</td>
                                                    <td align="right" style="width: 208px">&nbsp;
                                        <asp:Button ID="loginButton" runat="server" CssClass="btn" Text="Login"
                                            Width="61px" OnClick="LoginButton_Click" />
                                                    </td>
                                                    <td style="width: 4px">&nbsp;</td>
                                                    <td style="width: 36px">&nbsp;</td>
                                                </tr>
                                                <tr>
                                                    <td style="width: 4px; height: 6px;"></td>
                                                    <td style="width: 108px; height: 6px;"></td>
                                                    <td style="width: 18px; height: 6px;"></td>
                                                    <td style="width: 208px; height: 6px;"></td>
                                                    <td style="width: 4px; height: 6px;"></td>
                                                    <td style="width: 36px; height: 6px;"></td>
                                                </tr>
                                                <tr>
                                                    <td style="width: 4px">&nbsp;</td>
                                                    <td colspan="5">
                                                        <table style="width: 100%">
                                                            <tr id="rowRegFailureMsg">
                                                                <td style="width: 29px" id="colImageFailure" runat="server">
                                                                    <asp:Image ID="imgRegFailure" runat="server" ImageUrl="~/Images/warning[1].gif" />
                                                                </td>
                                                                <td style="width: 29px; background-color: yellowgreen" id="colImageSuccess" runat="server">
                                                                    <asp:Image ID="imgRegSuccess" runat="server" ImageUrl="~/Images/success.png" />
                                                                </td>
                                                                <td align="left" id="colFailureMsg" runat="server">

                                                                    <asp:Label ID="lblInvalid" runat="server" Font-Bold="False"
                                                                        Font-Names="Verdana" ForeColor="Red"
                                                                        Text=""></asp:Label>

                                                                </td>
                                                                <td align="left" style="background-color: yellowgreen;" id="colSuccessMsg" runat="server">

                                                                    <asp:Label ID="lblRegSuccess" runat="server" Font-Bold="False"
                                                                        Font-Names="Verdana" ForeColor="seagreen"
                                                                        Text="you're logged in!"></asp:Label>

                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </td>
                                                </tr>
                                            </table>
                                        </asp:Panel>
                                    </td>
                                </tr>
                            </table>

                            <br />
                            <br />
                        </td>
                    </tr>
                </table>

            </td>
        </tr>
    </table>
    <table style="width: 100%">
        <tr>
            <td align="center">
                <br />
                <br />
                <br />
            </td>
        </tr>
    </table>
</asp:Content>
