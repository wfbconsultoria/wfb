<%@ Page Language="VB" AutoEventWireup="false" CodeFile="Default.aspx.vb" Inherits="_Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1" />
    <link href="Content/bootstrap.min.css" rel="stylesheet" />
    <title>Alert Control</title>
</head>
<body class="container">
    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server" />
        <br />
        <h1>AMG ANGELS - Alert Control</h1>

        
            <asp:Button CssClass="btn btn-success btn-lg" ID="cmdResetAll" runat="server" Text="Liberar Todos Postos" />
            <asp:Button CssClass="btn btn-danger btn-lg" ID="cmdAlertAll" runat="server" Text="Alertar Todos Postos" />
        
        <br /><br />
        <div class="row">
            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <ContentTemplate>
                    <div id="divContent" runat="server">

                        <table class="table table-striped">

                            <tr>
                                <td>
                                    <asp:Literal ID="P01_STATUS" runat="server"></asp:Literal></td>
                                <td>
                                    <asp:Literal ID="P01_LOCAL" runat="server"></asp:Literal></td>
                                <td>
                                    <asp:Literal ID="P01_ALERTA" runat="server"></asp:Literal></td>

                                <%If Val(P01_STATUS.Text) = 1 Then %>
                                <td class="text-center">
                                    <img src="Images/SQUARE_RED.png" />
                                </td>
                                <%Else %>
                                <td class="text-center">
                                    <img src="Images/SQUARE_GREEN.png" /></td>
                                <%End If %>
                            </tr>

                            <tr>
                                <td>
                                    <asp:Literal ID="P02_STATUS" runat="server"></asp:Literal></td>
                                <td>
                                    <asp:Literal ID="P02_LOCAL" runat="server"></asp:Literal></td>
                                <td>
                                    <asp:Literal ID="P02_ALERTA" runat="server"></asp:Literal></td>

                                <%If Val(P02_STATUS.Text) = 1 Then %>
                                <td class="text-center">
                                    <img src="Images/SQUARE_RED.png" />
                                </td>
                                <%Else %>
                                <td class="text-center">
                                    <img src="Images/SQUARE_GREEN.png" /></td>
                                <%End If %>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Literal ID="P03_STATUS" runat="server"></asp:Literal></td>
                                <td>
                                    <asp:Literal ID="P03_LOCAL" runat="server"></asp:Literal></td>
                                <td>
                                    <asp:Literal ID="P03_ALERTA" runat="server"></asp:Literal></td>
                                <%If Val(P03_STATUS.Text) = 1 Then %>
                                <td class="text-center">
                                    <img src="Images/SQUARE_RED.png" />
                                </td>
                                <%Else %>
                                <td class="text-center">
                                    <img src="Images/SQUARE_GREEN.png" /></td>
                                <%End If %>
                            </tr>

                            <tr>
                                <td>
                                    <asp:Literal ID="P04_STATUS" runat="server"></asp:Literal></td>
                                <td>
                                    <asp:Literal ID="P04_LOCAL" runat="server"></asp:Literal></td>
                                <td>
                                    <asp:Literal ID="P04_ALERTA" runat="server"></asp:Literal></td>
                                <%If Val(P04_STATUS.Text) = 1 Then %>
                                <td class="text-center">
                                    <img src="Images/SQUARE_RED.png" />
                                </td>
                                <%Else %>
                                <td class="text-center">
                                    <img src="Images/SQUARE_GREEN.png" /></td>
                                <%End If %>
                            </tr>

                            <tr>
                                <td>
                                    <asp:Literal ID="P05_STATUS" runat="server"></asp:Literal></td>
                                <td>
                                    <asp:Literal ID="P05_LOCAL" runat="server"></asp:Literal></td>
                                <td>
                                    <asp:Literal ID="P05_ALERTA" runat="server"></asp:Literal></td>
                                <%If Val(P05_STATUS.Text) = 1 Then %>
                                <td class="text-center">
                                    <img src="Images/SQUARE_RED.png" />
                                </td>
                                <%Else %>
                                <td class="text-center">
                                    <img src="Images/SQUARE_GREEN.png" /></td>
                                <%End If %>
                            </tr>

                            <tr>
                                <td>
                                    <asp:Literal ID="P06_STATUS" runat="server"></asp:Literal></td>
                                <td>
                                    <asp:Literal ID="P06_LOCAL" runat="server"></asp:Literal></td>
                                <td>
                                    <asp:Literal ID="P06_ALERTA" runat="server"></asp:Literal></td>
                                <%If Val(P06_STATUS.Text) = 1 Then %>
                                <td class="text-center">
                                    <img src="Images/SQUARE_RED.png" />
                                </td>
                                <%Else %>
                                <td class="text-center">
                                    <img src="Images/SQUARE_GREEN.png" /></td>
                                <%End If %>
                            </tr>

                            <tr>
                                <td>
                                    <asp:Literal ID="P07_STATUS" runat="server"></asp:Literal></td>
                                <td>
                                    <asp:Literal ID="P07_LOCAL" runat="server"></asp:Literal></td>
                                <td>
                                    <asp:Literal ID="P07_ALERTA" runat="server"></asp:Literal></td>
                                <%If Val(P07_STATUS.Text) = 1 Then %>
                                <td class="text-center">
                                    <img src="Images/SQUARE_RED.png" />
                                </td>
                                <%Else %>
                                <td class="text-center">
                                    <img src="Images/SQUARE_GREEN.png" /></td>
                                <%End If %>
                            </tr>

                            <tr>
                                <td>
                                    <asp:Literal ID="P08_STATUS" runat="server"></asp:Literal></td>
                                <td>
                                    <asp:Literal ID="P08_LOCAL" runat="server"></asp:Literal></td>
                                <td>
                                    <asp:Literal ID="P08_ALERTA" runat="server"></asp:Literal></td>
                                <%If Val(P08_STATUS.Text) = 1 Then %>
                                <td class="text-center">
                                    <img src="Images/SQUARE_RED.png" />
                                </td>
                                <%Else %>
                                <td class="text-center">
                                    <img src="Images/SQUARE_GREEN.png" /></td>
                                <%End If %>
                            </tr>

                            <tr>
                                <td>
                                    <asp:Literal ID="P09_STATUS" runat="server"></asp:Literal></td>
                                <td>
                                    <asp:Literal ID="P09_LOCAL" runat="server"></asp:Literal></td>
                                <td>
                                    <asp:Literal ID="P09_ALERTA" runat="server"></asp:Literal></td>
                                <%If Val(P09_STATUS.Text) = 1 Then %>
                                <td class="text-center">
                                    <img src="Images/SQUARE_RED.png" />
                                </td>
                                <%Else %>
                                <td class="text-center">
                                    <img src="Images/SQUARE_GREEN.png" /></td>
                                <%End If %>
                            </tr>

                            <tr>
                                <td>
                                    <asp:Literal ID="P10_STATUS" runat="server"></asp:Literal></td>
                                <td>
                                    <asp:Literal ID="P10_LOCAL" runat="server"></asp:Literal></td>
                                <td>
                                    <asp:Literal ID="P10_ALERTA" runat="server"></asp:Literal></td>
                                <%If Val(P10_STATUS.Text) = 1 Then %>
                                <td class="text-center">
                                    <img src="Images/SQUARE_RED.png" />
                                </td>
                                <%Else %>
                                <td class="text-center">
                                    <img src="Images/SQUARE_GREEN.png" /></td>
                                <%End If %>
                            </tr>

                            <tr>
                                <td>
                                    <asp:Literal ID="P11_STATUS" runat="server"></asp:Literal></td>
                                <td>
                                    <asp:Literal ID="P11_LOCAL" runat="server"></asp:Literal></td>
                                <td>
                                    <asp:Literal ID="P11_ALERTA" runat="server"></asp:Literal></td>
                                <%If Val(P11_STATUS.Text) = 1 Then %>
                                <td class="text-center">
                                    <img src="Images/SQUARE_RED.png" />
                                </td>
                                <%Else %>
                                <td class="text-center">
                                    <img src="Images/SQUARE_GREEN.png" /></td>
                                <%End If %>
                            </tr>

                            <tr>
                                <td>
                                    <asp:Literal ID="P12_STATUS" runat="server"></asp:Literal></td>
                                <td>
                                    <asp:Literal ID="P12_LOCAL" runat="server"></asp:Literal></td>
                                <td>
                                    <asp:Literal ID="P12_ALERTA" runat="server"></asp:Literal></td>
                                <%If Val(P12_STATUS.Text) = 1 Then %>
                                <td class="text-center">
                                    <img src="Images/SQUARE_RED.png" />
                                </td>
                                <%Else %>
                                <td class="text-center">
                                    <img src="Images/SQUARE_GREEN.png" /></td>
                                <%End If %>
                            </tr>

                            <tr>
                                <td>
                                    <asp:Literal ID="P13_STATUS" runat="server"></asp:Literal></td>
                                <td>
                                    <asp:Literal ID="P13_LOCAL" runat="server"></asp:Literal></td>
                                <td>
                                    <asp:Literal ID="P13_ALERTA" runat="server"></asp:Literal></td>
                                <%If Val(P13_STATUS.Text) = 1 Then %>
                                <td class="text-center">
                                    <img src="Images/SQUARE_RED.png" />
                                </td>
                                <%Else %>
                                <td class="text-center">
                                    <img src="Images/SQUARE_GREEN.png" /></td>
                                <%End If %>
                            </tr>

                            <tr>
                                <td>
                                    <asp:Literal ID="P14_STATUS" runat="server"></asp:Literal></td>
                                <td>
                                    <asp:Literal ID="P14_LOCAL" runat="server"></asp:Literal></td>
                                <td>
                                    <asp:Literal ID="P14_ALERTA" runat="server"></asp:Literal></td>
                                <%If Val(P14_STATUS.Text) = 1 Then %>
                                <td class="text-center">
                                    <img src="Images/SQUARE_RED.png" />
                                </td>
                                <%Else %>
                                <td class="text-center">
                                    <img src="Images/SQUARE_GREEN.png" /></td>
                                <%End If %>
                            </tr>

                            <tr>
                                <td>
                                    <asp:Literal ID="P15_STATUS" runat="server"></asp:Literal></td>
                                <td>
                                    <asp:Literal ID="P15_LOCAL" runat="server"></asp:Literal></td>
                                <td>
                                    <asp:Literal ID="P15_ALERTA" runat="server"></asp:Literal></td>
                                <%If Val(P15_STATUS.Text) = 1 Then %>
                                <td class="text-center">
                                    <img src="Images/SQUARE_RED.png" />
                                </td>
                                <%Else %>
                                <td class="text-center">
                                    <img src="Images/SQUARE_GREEN.png" /></td>
                                <%End If %>
                            </tr>

                        </table>

                    </div>
                    <asp:Timer ID="Timer1" runat="server" Interval="1000" OnTick="Timer1_Tick" />
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
        <script src="Scripts/bootstrap.bundle.min.js"></script>
    </form>

</body>
</html>
