<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="RegistroCliente.aspx.cs" Inherits="TPWeb_equipo_20B.RegistroCliente" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1 class="text-center my-4">Registro de Cliente</h1>
    <div class="container">
        <div class="row justify-content-center">
            <div class="col-md-8">
                <div class="card shadow-lg">
                    <div class="card-header bg-info text-white text-center">
                        Ingrese sus datos para participar
                    </div>
                    <div class="card-body">
                        <div class="mb-3">
                            <label for="txtDNI" class="form-label" >DNI</label>
                               <asp:TextBox ID="txtDNI" runat="server" CssClass="form-control" placeholder="Ingrese su DNI"></asp:TextBox>
                        </div>
                        <div>
                            <asp:Button ID="btnVerificar" runat="server" CssClass="btn btn-info" Text="Verificar" OnClick="btnVerificar_Click" />
                        </div>
                        <div class="mb-3">
                            <label for="txtNombre" class="form-label">Nombre:</label>
                              <asp:TextBox ID="txtNombre" runat="server" CssClass="form-control" Enabled="false" placeholder="Ingrese su Nombre"></asp:TextBox>
                        </div>
                          <div class="mb-3">
                            <label for="txtApellido" class="form-label">Apellido:</label>
                            <asp:TextBox ID="txtApellido" runat="server" CssClass="form-control" placeholder="Ingrese su apellido" Enabled="false"></asp:TextBox>
                        </div>

                        <div class="mb-3">
                            <label for="txtEmail" class="form-label">Email:</label>
                            <asp:TextBox ID="txtEmail" runat="server" CssClass="form-control" placeholder="Ingrese su email" Enabled="false"></asp:TextBox>
                        </div>

                          <div class="mb-3">
                            <label for="txtDireccion" class="form-label">Dirección:</label>
                            <asp:TextBox ID="txtDireccion" runat="server" CssClass="form-control" placeholder="Ingrese su dirección" Enabled="false"></asp:TextBox>
                        </div>

                        <div class="mb-3">
                            <label for="txtCiudad" class="form-label">Ciudad:</label>
                            <asp:TextBox ID="txtCiudad" runat="server" CssClass="form-control" placeholder="Ingrese su ciudad" Enabled="false"></asp:TextBox>
                        </div>

                        <div class="mb-3">
                            <label for="txtCodigoPostal" class="form-label">Código Postal:</label>
                            <asp:TextBox ID="txtCodigoPostal" runat="server" CssClass="form-control" placeholder="Ingrese su código postal" Enabled="false"></asp:TextBox>
                        </div>
                        <div class="text-center">
                            <asp:Button ID="btnParticipar" runat="server" Text="PARTICIPAR" CssClass="btn btn-succes" Enabled="false" />
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>


</asp:Content>
