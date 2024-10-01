<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="TPWeb_equipo_20B.Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>¡Bienvenido/a!</h1>
    <p>Te encuentras en la web para canjear tu voucher</p>

    <div class="mb-3">
        <label for="exampleInputCodigo" class="form-label">Ingresa el código de tu voucher</label>
        <input class="form-control" id="exampleInputCodigo" aria-describedby="codigoHelp">
        <div id="codigoHelp" class="form-text">No compartas el código de tu voucher con nadie.</div>
    </div>
    <%--<button type="submit" class="btn btn-primary">Siguiente</button>--%>
    <asp:Button ID="btnSiguiente" Text="Siguiente" cssclass="btn btn-primary" OnClick="btnSiguiente_Click" runat="server" />
</asp:Content>
