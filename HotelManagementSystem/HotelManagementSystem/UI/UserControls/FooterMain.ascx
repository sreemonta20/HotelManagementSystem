<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="FooterMain.ascx.cs" Inherits="HotelManagementSystem.UI.UserControls.FooterMain" %>
<!--Begin Footer-->
<div  class="footerwrap">
<br />
<img src="../../Images/returntop.gif" alt="return to top" align="middle" border="0" /><a class="dt2" title="Return to top of the page" href="javascript:scroll(0,0)">Return to top</a>
<br />
<span class="content2">
Copyright ©2015 HMS Solutions Ltd. All rights reserved. </span>
<br />
  <asp:HyperLink id="Powered" cssClass="dt2" ToolTip="Visit our portal website" NavigateURL="http://www.sreebhowmik.herobo.com"  onclick="window.open(this.href,'popupwindow','width=400,height=400,titlebar=yes,toolbar=yes,scrollbars,resizable'); return false;" runat="server"> Powered By HMS Solutions Ltd. </asp:HyperLink>
 </div>
<!--End Footer-->
