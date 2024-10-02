<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="TPWeb_equipo_20B.Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
   <div class="container">
    <div class="row justify-content-center">        
        <div class="col-12 col-md-6 text-center">            
            <h1>¡Bienvenido/a!</h1>
            <p>Te encuentras en la web para canjear tu voucher</p>

            <div class="mb-3">
                <div class="form-group">
                    <label for="txtCodigoVoucher" class="form-label">Ingresa el código de tu voucher</label>
                    <asp:TextBox CssClass="form-control" ID="txtCodigoVoucher" aria-describedby="codigoHelp" runat="server" />
                    <!--<asp:RequiredFieldValidator ID="rfvCodigoVoucher" runat="server" ControlToValidate="txtCodigoVoucher" ErrorMessage="El código del voucher es obligatorio." CssClass="text-danger" Display="Dynamic" ForeColor="Red" />--> 
                    <asp:Label ID="lblErrorVoucher" runat="server" CssClass="text-danger" ForeColor="Red" Visible="false"></asp:Label>
                </div>
            </div>    

            <asp:Button ID="btnSiguiente" Text="Siguiente" CssClass="btn btn-primary" OnClick="btnSiguiente_Click" runat="server" />
        </div>
    </div>
</div>
   
</asp:Content>
