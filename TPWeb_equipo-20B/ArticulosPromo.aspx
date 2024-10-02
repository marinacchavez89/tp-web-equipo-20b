<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="ArticulosPromo.aspx.cs" Inherits="TPWeb_equipo_20B.ArticulosPromo" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1 class="text-center my-4">Elegí tu premio</h1>
    <div class="container">
        <div class="row">
            <asp:Repeater ID="repetidorPremios" runat="server">
                <ItemTemplate>
                    <div class="col-md-4 mb-4">
                        <div class="card">
                           <!-- hay que iterar la lista de imagenes-->
                             <div class="row">
                                <asp:Repeater ID="repetidorImagenes" runat="server" DataSource='<%# Eval("ImagenArticulo") %>'>
                                    <ItemTemplate>
                                        <div class="col-6 mb-2">
                                            <img src='<%# Eval("ImagenUrl") %>' class="img-thumbnail" alt="imagen del articulo" style="width: 100%; height: auto;" />
                                        </div>
                                    </ItemTemplate>
                                </asp:Repeater>
                            </div>
                        </div>
                        <div>
                            <div class="card-body">
                                <h5 class="card-titile"></h5>
                                <p class="card-text"><!--variable "descripcion"--></p>
<asp:Button ID="btnSeleccionarPremio" runat="server" Text="QUIERO ESTE!"  />

                            </div>
                        </div>

                    </div>
                </ItemTemplate>
            </asp:Repeater>

        </div>
    </div>
</asp:Content>
