<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="RegistroCliente.aspx.cs" Inherits="TPWeb_equipo_20B.RegistroCliente" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1 class="text-center my-4">Completa tu registro</h1>
    <div class="container">
        <div class="row justify-content-center">
            <div class="col-md-8">
                <div class="card shadow-lg">
                    <div class="card-header bg-secondary text-white text-center">
                        Introduce tus datos para participar en el sorteo
                    </div>
                    <div class="card-body">
                        <div class="mb-3">
                            <label for="txtDNI" class="form-label">DNI</label>
                            <asp:TextBox ID="txtDNI" runat="server" CssClass="form-control" placeholder="Ingrese su DNI"></asp:TextBox>
                            <asp:RegularExpressionValidator 
                                ID="DniValidator" 
                                runat="server" 
                                ControlToValidate="txtDNI"
                                ValidationExpression="^\d+$" 
                                ErrorMessage="* Ingrese solo números." 
                                ForeColor="Red" 
                                CssClass="text-danger">
                            </asp:RegularExpressionValidator>                            
                        </div>
                        <div>
                            <asp:Button ID="btnVerificar" runat="server" CssClass="btn btn-secondary" Text="Verificar" OnClick="btnVerificar_Click" />
                        </div>
                        <br />
                        <div class="mb-3">
                            <label for="txtNombre" class="form-label">Nombre:</label>
                            <asp:TextBox ID="txtNombre" runat="server" CssClass="form-control" Enabled="false" placeholder="Ingrese su Nombre"></asp:TextBox>                           
                        </div>
                        <div class="mb-3">
                            <label for="txtApellido" class="form-label">Apellido:</label>
                            <asp:TextBox ID="txtApellido" runat="server" CssClass="form-control" placeholder="Ingrese su Apellido" Enabled="false"></asp:TextBox>                            
                        </div>

                        <div class="mb-3">
                            <label for="txtEmail" class="form-label">Email:</label>
                            <asp:TextBox ID="txtEmail" TextMode="Email" runat="server" CssClass="form-control" placeholder="Ingrese su Email" Enabled="false"></asp:TextBox>
                            <asp:RegularExpressionValidator 
                            ID="revEmail" 
                            runat="server" 
                            ControlToValidate="txtEmail" 
                            ErrorMessage="Formato de email no válido." 
                            CssClass="text-danger" 
                            Display="Dynamic" 
                            ForeColor="Red" 
                            ValidationExpression="^[^@\s]+@[^@\s]+\.[^@\s]+$" />                            
                        </div>

                        <div class="mb-3">
                            <label for="txtDireccion" class="form-label">Dirección:</label>
                            <asp:TextBox ID="txtDireccion" runat="server" CssClass="form-control" placeholder="Ingrese su Dirección" Enabled="false"></asp:TextBox>                           
                        </div>

                        <div class="mb-3">
                            <label for="txtCiudad" class="form-label">Ciudad:</label>
                            <asp:TextBox ID="txtCiudad" runat="server" CssClass="form-control" placeholder="Ingrese su Ciudad" Enabled="false"></asp:TextBox>                            
                        </div>

                        <div class="mb-3">
                            <label for="txtCodigoPostal" class="form-label">Código Postal:</label>
                            <asp:TextBox ID="txtCodigoPostal" runat="server" CssClass="form-control" placeholder="Ingrese su Código Postal" Enabled="false"></asp:TextBox>
                            <asp:RegularExpressionValidator 
                                ID="RegularExpressionValidator1" 
                                runat="server" 
                                ControlToValidate="txtCodigoPostal"
                                ValidationExpression="^\d+$" 
                                ErrorMessage="* Ingrese solo números." 
                                ForeColor="Red" 
                                CssClass="text-danger">
                            </asp:RegularExpressionValidator>                            
                        </div>
                        <div class="text-center">
                            <asp:Button ID="btnParticipar" runat="server" Text="¡PARTICIPAR!" CssClass="btn btn-outline-secondary" Enabled="false" OnClick="btnParticipar_Click" />
                            <asp:Label ID="lblExito" runat="server" CssClass="alert-alert-succes" Visible="false"></asp:Label>
                            <asp:Label ID="lblError" runat="server" CssClass="alert-alert-danger" Visible="false"></asp:Label>

                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>


</asp:Content>
