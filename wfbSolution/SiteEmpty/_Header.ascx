<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="_Header.ascx.vb" Inherits="SiteEmpty._Header" %>
<%@ Register Src="~/_Header_Buttons.ascx" TagPrefix="uc1" TagName="_Header_Buttons" %>

    <br />
    <nav class="navbar navbar-dark" style="background-color: #0082C3;">
        <div class="navbar-brand text-uppercase"><span class="d-none d-md-block"><strong>DECATHLON Chapeira Digital&nbsp</strong></span><%:ConfigurationManager.AppSettings("Loja") %></div>
        <button class="navbar-toggler" type="button" data-toggle="collapse" data-target="#navbarsExample01" aria-controls="navbarsExample01" aria-expanded="false" aria-label="Toggle navigation">
            <span class="navbar-toggler-icon"></span>
        </button>
        <div class="collapse navbar-collapse" id="navbarsExample01">
            
            <ul class="navbar-nav mr-auto">
                <li class="nav-item active">
                    <a class="nav-link text-uppercase" href="Default.aspx">Início</a>
                </li>
                <li class="nav-item active">
                    <a class="nav-link text-uppercase" href="Lojas.aspx">Lojas</a>
                </li>
            </ul>
            <br />
            <uc1:_Header_Buttons runat="server" id="_Header_Buttons" />
        </div>
    </nav>
    

