<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="RegistroExitoso.aspx.cs" Inherits="TPWeb_equipo_20B.RegistroExitoso" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <div style="display: flex; justify-content: center;">

     <div class="card  mb-3" style="width: 18rem; text-align: center; justify-content: center">
         <img src="https://segundamanolarevista.com/wp-content/uploads/2020/09/Check-thankyou-page-segunda-mano-la-revista.png" class="card-img-top" alt="Error">
         <div class="card-body">
             <h5 class="card-title">¡Registro exitoso!</h5>
             <asp:Label Text="" ID="lblErrorVoucher" runat="server" CssClass="card-text" />
             <div style="padding: 20px;">
                 <a href="Default.aspx" class="btn btn-secondary">Volver</a>
             </div>
         </div>
     </div>
 </div>
</asp:Content>
