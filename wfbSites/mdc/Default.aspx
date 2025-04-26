<%@ Page Language="VB" AutoEventWireup="false" CodeFile="Default.aspx.vb" Inherits="_Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />

    <!-- Material Design -->
    <link href="https://fonts.googleapis.com/css2?family=Roboto:wght@400;500;700&display=swap" rel="stylesheet" />
   
    <link href="https://unpkg.com/material-components-web@latest/dist/material-components-web.min.css" rel="stylesheet"/>
    <script src="https://unpkg.com/material-components-web@latest/dist/material-components-web.min.js"></script>

    <!-- Material Design -->

    <title>Material Design</title>
</head>
<body>
    <form id="form1" runat="server">
        <h1 class="md-typescale-display-medium">Hello Material!</h1>

        <label>Email
            <input type="email" name="email" required="required" />
        </label>
        
        <label>Subscribe
            <input type="checkbox" name="subscribe" />
        </label>

        <button type="reset">Reset</button>
        <button>Submit</button>


        <md-outlined-text-field label="Email" type="email" name="email" required></md-outlined-text-field>
  <label>
    Subscribe
    <md-checkbox name="subscribe"></md-checkbox>
  </label>

  <md-text-button type="reset">Reset</md-text-button>
  <md-outlined-button runat="server" id="cmd" name="cmd">Submit</md-outlined-button>






        <p class="md-typescale-body-medium">Check out these controls in a form!</p>
        <md-checkbox></md-checkbox>
        <div>
            <md-radio name="group"></md-radio>
            <md-radio name="group"></md-radio>
            <md-radio name="group"></md-radio>
        </div>
        <md-outlined-text-field label="Favorite color" value="Purple"></md-outlined-text-field>
        <md-outlined-button type="reset">Reset</md-outlined-button>

        <style>
            form {
                display: flex;
                flex-direction: column;
                align-items: flex-start;
                gap: 16px;
            }
        </style>
    </form>
</body>
</html>
