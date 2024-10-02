<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="TPWeb_equipo_20B.Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>¡Bienvenido/a!</h1>
    <p>Te encuentras en la web para canjear tu voucher</p>

    <div class="mb-3">
        <div class="col-3">
            <label for="txtCodigoVoucher" class="form-label">Ingresa el código de tu voucher</label>
            <asp:TextBox CssClass="form-control" ID="txtCodigoVoucher" aria-describedby="codigoHelp" runat="server" />
            <asp:RequiredFieldValidator ID="rfvCodigoVoucher" runat="server" ControlToValidate="txtCodigoVoucher" ErrorMessage="El código del voucher es obligatorio." CssClass="text-danger" Display="Dynamic" ForeColor="Red" />
        </div>
    </div>
    <asp:Button ID="btnSiguiente" Text="Siguiente" CssClass="btn btn-primary" OnClick="btnSiguiente_Click" runat="server" />
</asp:Content>
