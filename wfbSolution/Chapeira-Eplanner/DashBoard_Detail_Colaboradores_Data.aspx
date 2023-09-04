<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Master.Master" CodeBehind="DashBoard_Detail_Colaboradores_Data.aspx.vb" Inherits="Chapeira_Eplanner.DashBoard_Detail_Colaboradores_Data" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeaderContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="BodyContent" runat="server">
    <div class="form-row">

        <div class="form-group col-sm-2">
            <label class="text-primary">Data</label>
            <input runat="server" type="date" id="txt_Data" name="txt_Data" class="form-control">
        </div>
        <div class="form-group col-sm-2">
            <label class="text-primary">Hora</label>
            <select runat="server" id="cmb_Horario" class="form-control">
                <option value="0">00:00</option>
                <option value="30">00:30</option>
                <option value="60">01:00</option>
                <option value="90">01:30</option>
                <option value="120">02:00</option>
                <option value="150">02:30</option>
                <option value="180">03:00</option>
                <option value="210">03:30</option>
                <option value="240">04:00</option>
                <option value="270">04:30</option>
                <option value="300">05:00</option>
                <option value="330">05:30</option>
                <option value="360">06:00</option>
                <option value="390">06:30</option>
                <option value="420">07:00</option>
                <option value="450">07:30</option>
                <option value="480">08:00</option>
                <option value="510">08:30</option>
                <option value="540">09:00</option>
                <option value="570">09:30</option>
                <option value="600">10:00</option>
                <option value="630">10:30</option>
                <option value="660">11:00</option>
                <option value="690">11:30</option>
                <option value="720">12:00</option>
                <option value="750">12:30</option>
                <option value="780">13:00</option>
                <option value="810">13:30</option>
                <option value="840">14:00</option>
                <option value="870">14:30</option>
                <option value="900">15:00</option>
                <option value="930">15:30</option>
                <option value="960">16:00</option>
                <option value="990">16:30</option>
                <option value="1020">17:00</option>
                <option value="1050">17:30</option>
                <option value="1080">18:00</option>
                <option value="1110">18:30</option>
                <option value="1140">19:00</option>
                <option value="1170">19:30</option>
                <option value="1200">20:00</option>
                <option value="1230">20:30</option>
                <option value="1260">21:00</option>
                <option value="1290">21:30</option>
                <option value="1320">22:00</option>
                <option value="1350">22:30</option>
                <option value="1380">23:00</option>
                <option value="1410">23:30</option>
                <option value="1440">24:00</option>
            </select>
        </div>
    </div>
</asp:Content>
