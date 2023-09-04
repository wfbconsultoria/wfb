<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="MasterReport.aspx.vb" Inherits="Reports.MasterReport" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Master Report</title>
</head>
<body>
    <form id="frmMaster" runat="server">
        <div>

            <asp:SqlDataSource ID="SqlDataSource1" runat="server"></asp:SqlDataSource>

        </div>
    </form>
</body>
</html>
