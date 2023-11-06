<%@ Page Language="VB" AutoEventWireup="false" CodeFile="Default.aspx.vb" Inherits="_Default" %>

<%@ Register Src="~/_head.ascx" TagPrefix="uc1" TagName="_head" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <uc1:_head runat="server" ID="_head" />
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <button class="mdc-button foo-button">
                <div class="mdc-button__ripple"></div>
                <span class="mdc-button__label">Button</span>
            </button>
        </div>
    </form>
</body>
</html>
