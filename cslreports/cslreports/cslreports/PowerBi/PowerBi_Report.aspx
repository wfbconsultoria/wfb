<%@ Page Title="DashBoad" Language="vb" AutoEventWireup="false" MasterPageFile="~/Master.Master" CodeBehind="PowerBi_Report.aspx.vb" Inherits="cslreports.PowerBi_Report" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="BodyContent" runat="server">
    
    <div class="row">
        <a href="../Default.aspx">Início</a>&nbsp;
        <a href="PowerBi/PowerBi_Menu.aspx"> Menu de DashBoads</a>
    </div>


    <script src="http://code.jquery.com/jquery-1.8.3.min.js" type="text/javascript"></script>
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.3.1/jquery.min.js"></script>
    <script type="text/jscript">
        function injectJS() {
            var frame = $('iframe');
            var contents = frame.contents();
            var body = contents.find('body').attr("oncontextmenu", "return false");
            var body = contents.find('body').append('<div>New Div</div>');
        }
    </script>

    <script type="text/jscript">
        function disableContextMenu() {
            window.frames["myFrame"].document.oncontextmenu = function () { alert("No way!"); return false; };
            // Or use this
            // document.getElementById("fraDisabled").contentWindow.document.oncontextmenu = function(){alert("No way!"); return false;};;    
        }
    </script>


    <script src="a.js"> </script>
    <input type="button" value="Disable Context Menu" onclick="disableContextMenu();"><br><br>
   
        <iframe width="500" height="500" src="javascript:;" id="myframe" frameborder="2" allowFullScreen="true"  onload="injectJS()"></iframe>


    <script>
        $("html").contextmenu(function (e) {
            e.preventDefault();
        });
    </script>
   
    <%--<script type="text/javascript">
    function protegerframe() {
        alert('não é possivel exibir o codigo fonte deste frame');
        }

        var myConfObj = {
            iframeMouseOver: false
        }
        window.addEventListener('blur', function () {
            if (myConfObj.iframeMouseOver) {
                
                document.getElementById('btn').focus();
            }
        });

        document.getElementById('myframe').addEventListener('mouseover', function () {
            myConfObj.iframeMouseOver = true;
        });
        document.getElementById('myframe').addEventListener('mouseout', function () {
            myConfObj.iframeMouseOver = false;
        });

        //function checkFocus() {
        //    if (document.activeElement == document.getElementsByTagName("iframe")[0]) {
        //        alert('iframe has focus');
        //    } else {
               
        //    }
        //}

        //window.setInterval(checkFocus, 1000); 
   
    </script>--%>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="FooterContent" runat="server">
</asp:Content>
