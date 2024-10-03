<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="errorVoucher.aspx.cs" Inherits="TPWeb_equipo_20B.errorVoucher" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div style="display: flex; justify-content: center;">

        <div class="card  mb-3" style="width: 18rem; text-align: center; justify-content: center">
            <img src="https://us.123rf.com/450wm/alexwhite/alexwhite1505/alexwhite150506935/40220252-exclamaci%C3%B3n-signo-violeta-icono-de-se%C3%B1al-de-advertencia-s%C3%ADmbolo-de-alerta.jpg" class="card-img-top" alt="Error">
            <div class="card-body">
                <h5 class="card-title">El código del voucher es inexistente o ya fue canjeado</h5>
                <asp:Label Text="" ID="lblErrorVoucher" runat="server" CssClass="card-text" />
                <div style="padding: 20px;">
                    <a href="Default.aspx" class="btn btn-secondary">Volver</a>
                </div>
            </div>
        </div>
    </div>
    
</asp:Content>
