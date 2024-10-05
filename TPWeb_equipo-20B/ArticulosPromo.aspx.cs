using dominio;
using negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TPWeb_equipo_20B
{
    public partial class ArticulosPromo : System.Web.UI.Page
    {
        public List<Articulo> ListaArticulo {  get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {

            if(!IsPostBack)
            {
            ArticuloNegocio negocio = new ArticuloNegocio();
                ListaArticulo = negocio.listar();
                repetidorPremios.DataSource = ListaArticulo;
                repetidorPremios.DataBind();
            }
        }
        protected void btnSeleccionarPremio_Command(object sender, CommandEventArgs e)  
        {
            int idArticulo = int.Parse((e.CommandArgument).ToString());
            Session["IdArticulo"] = idArticulo;
            string codigoVoucher = Session["Voucher"].ToString();
            Session["Voucher"] = codigoVoucher;
            Response.Redirect($"RegistroCliente.aspx?articuloId={idArticulo}&voucher={codigoVoucher}", false);
        }

    }
}