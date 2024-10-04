using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TPWeb_equipo_20B
{
    public partial class RegistroCliente : System.Web.UI.Page
    {
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

            }
        }
        protected void btnVerificar_Click (object sender, EventArgs e)
        {
            
        }
    }
}