using negocio;
using dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


namespace TPWeb_equipo_20B
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnSiguiente_Click(object sender, EventArgs e)
        {
            Voucher voucher = new Voucher();
            voucher.CodigoVoucher = txtCodigoVoucher.Text;

            VoucherNegocio voucherNegocio = new VoucherNegocio();

            bool resultado = voucherNegocio.validarVoucher(voucher);

            if (resultado) 
            {
                string script = "alert('El código del voucher ya ha sido canjeado o no existe.');";
                ClientScript.RegisterStartupScript(this.GetType(), "alert", script, true);
            }
            else
            {
                Response.Redirect("ArticulosPromo.aspx", false);
            }


        }
    }
}