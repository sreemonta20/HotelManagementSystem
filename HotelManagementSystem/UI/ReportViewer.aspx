<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ReportViewer.aspx.cs" Inherits="HotelManagementSystem.UI.ReportViewer" %>
 
<%@ Register assembly="Microsoft.ReportViewer.WebForms, Version=11.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91" namespace="Microsoft.Reporting.WebForms" tagprefix="rsweb" %>
 
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>HMS Solutions::- Hotel Management System</title>
</head>
<body>
    <form id="form2" runat="server">
    <div>
    
    <%--<asp:ScriptManager ID="scrptManagerHMS"  runat="server">
    </asp:ScriptManager>
    <rsWeb:ReportViewer ID="rptViewerHMS" runat="server" Width="900">
      
    </rsWeb:ReportViewer>--%>
    
        <asp:ScriptManager ID="scrptManagerHMS" runat="server">
        </asp:ScriptManager>
        <rsweb:ReportViewer ID="rptViewerHMS" runat="server" Width="100%">
        </rsweb:ReportViewer>
        <br />
    
    </div>
    </form>
</body>
</html>