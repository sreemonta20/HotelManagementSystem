<%@ Page Language="C#" MasterPageFile="~/UI/Site.Master" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="HotelManagementSystem.UI.Home" Title="BASIS Solutions::- Hotel Management System" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

    <table style="width: 100%" class="tblmas">
        <tr>
            <td style="width: 11px">
                &nbsp;</td>
            <td style="width: 805px">
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td colspan="3" align="center">
                <h1>
                    Welcome to Pan Pacific Sonargaon Dhaka</h1>
            </td>
        </tr>
        <tr>
            <td style="width: 11px">
                &nbsp;</td>
            <td style="width: 805px">
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td style="width: 11px">
                &nbsp;</td>
            <td style="width: 805px" class="tbl">
            <p style="text-align:justify">
                Pan Pacific Sonargaon Dhaka is located right in the heart of Dhaka city and 
                offers convenient access to many interesting sights within close vicinity.<br />
                <br />
                The completion of an extensive refurbishment of the guestrooms and recreation 
                facilities has brought new standards of quality and service experience to 
                Dhaka.&nbsp; Unveiling elegant interiors surrounded by warm tropical colours, the new 
                guestrooms are outfitted with upgraded facilities such as flat-screen LCD 
                televisions, broadband internet access and cable television channels.<br />
                <br />
                Additionally, the Health Club is enhanced with an outdoor landscaped pool set 
                amidst plush greenery to offer a refreshing retreat. A children’s pool is also 
                available to provide an enjoyable time with your family.<br />
                <br />
                Welcome to Pan Pacific Sonargaon Dhaka.&nbsp; Allow us to show you the very best of 
                our service because we genuinely care.
                <asp:LinkButton ID="bookingLinkButton" runat="server" BorderWidth="0px" 
                    Font-Bold="True" Font-Italic="True" Font-Strikeout="False" 
                    Font-Underline="True" PostBackUrl="~/UI/CustomerBookingUI.aspx">Book Now!</asp:LinkButton>
             </p></td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td style="width: 11px">
                &nbsp;</td>
            <td style="width: 805px">
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td style="width: 11px">
                </td>
            <td style="width: 805px">
                </td>
            <td>
                </td>
        </tr>
    </table>

</asp:Content>
