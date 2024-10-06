using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using negocio;
using dominio;

namespace TPWeb_equipo_20B
{
    public partial class RegistroCliente : System.Web.UI.Page
    {
        private int idArticuloSeleccionado;
        private string codigoVoucher;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                txtNombre.Enabled = false;
                txtApellido.Enabled = false;
                txtEmail.Enabled = false;
                txtDireccion.Enabled = false;
                txtCiudad.Enabled = false;
                txtCodigoPostal.Enabled = false;
                btnParticipar.Enabled = false;

                idArticuloSeleccionado = (int)Session["IdArticulo"];
                codigoVoucher = Session["Voucher"].ToString();
            }
        }
        protected void btnVerificar_Click (object sender, EventArgs e)
        {
            string dniIngresado = txtDNI.Text.Trim();
            
            if (string.IsNullOrEmpty(dniIngresado))
            {
                lblErrorDNI.Text = "Por favor, ingrese un número de DNI.";
                lblErrorDNI.Visible = true;
                return;
            }
            else
            {
                lblErrorDNI.Visible = false;
            }
            
            ClienteNegocio negocio = new ClienteNegocio();
            List<Cliente> clienteEncontrado = negocio.findClienteByDni(txtDNI.Text);

            LimpiarCampos();

            if (clienteEncontrado.Count == 0)
            {
                txtNombre.Enabled = true;
                txtApellido.Enabled = true;
                txtEmail.Enabled = true;
                txtDireccion.Enabled = true;
                txtCiudad.Enabled = true;
                txtCodigoPostal.Enabled = true;
                btnParticipar.Enabled = true;
            }
            else
            {
                Cliente cliente = clienteEncontrado[0];

                txtNombre.Text = cliente.Nombre;
                txtApellido.Text = cliente.Apellido;
                txtEmail.Text = cliente.Email;
                txtDireccion.Text = cliente.Direccion;
                txtCiudad.Text = cliente.Ciudad;
                txtCodigoPostal.Text = cliente.CodigoPostal.ToString();

                btnParticipar.Enabled = true;
            }
        }

        private void LimpiarCampos()
        {
            
            txtNombre.Text = string.Empty;
            txtApellido.Text = string.Empty;
            txtEmail.Text = string.Empty;
            txtDireccion.Text = string.Empty;
            txtCiudad.Text = string.Empty;
            txtCodigoPostal.Text = string.Empty;

            
            txtNombre.Enabled = false;
            txtApellido.Enabled = false;
            txtEmail.Enabled = false;
            txtDireccion.Enabled = false;
            txtCiudad.Enabled = false;
            txtCodigoPostal.Enabled = false;

            
            btnParticipar.Enabled = false;
        }
        protected void btnParticipar_Click(object sender, EventArgs e)
        {
            try
            {
                Cliente cliente = new Cliente
                {
                    Dni = txtDNI.Text,
                    Nombre = txtNombre.Text,
                    Apellido = txtApellido.Text,
                    Email = txtEmail.Text,
                    Direccion = txtDireccion.Text,
                    Ciudad = txtCiudad.Text,
                    CodigoPostal = int.Parse(txtCodigoPostal.Text)
                };

                
                if (string.IsNullOrEmpty(cliente.Email))
                {
                    lblError.Text = "El correo electrónico es obligatorio.";
                    lblError.Visible = true;
                    return;
                }

                ClienteNegocio negocio = new ClienteNegocio();

                int idClienteRegistrado;

                List<Cliente> clienteEncontrado = negocio.findClienteByDni(cliente.Dni);
                if(clienteEncontrado.Count == 0)
                {
                idClienteRegistrado = negocio.registrarCliente(cliente);

                }
                else
                {
                    idClienteRegistrado = clienteEncontrado[0].Id;
                }

                string codigoVoucher = Session["Voucher"].ToString();
                int idArticulo = (int)Session["IdArticulo"];

                negocio.RegistrarCanjeVoucher(codigoVoucher, idClienteRegistrado, DateTime.Now, idArticulo);

                // Enviar correo con Mailtrap
                if (!string.IsNullOrEmpty(cliente.Email))
                {
                    EmailService emailService = new EmailService();
                    emailService.armarCorreo(cliente.Email, "Participación en el sorteo",
                        "<h1>¡Gracias por haber participado en el sorteo!</h1> <br> La inscripción al sorteo fue exitosa.");
                    emailService.enviarEmail();
                }

                LimpiarCampos();

                Response.Redirect("RegistroExitoso.aspx", false);
            }
            catch (Exception ex)
            {
                lblError.Text = "Error al registrar al Cliente: " + ex.Message;
                lblError.Visible = true;
            }
        }
    }
}