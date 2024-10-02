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
            lblErrorVoucher.Visible = false;

            if (string.IsNullOrWhiteSpace(txtCodigoVoucher.Text))
            {
                lblErrorVoucher.Text = "El código del voucher no puede estar vacío.";
                lblErrorVoucher.Visible = true;
                return;
            }

            Voucher voucher = new Voucher();
            voucher.CodigoVoucher = txtCodigoVoucher.Text;

            VoucherNegocio voucherNegocio = new VoucherNegocio();

            bool resultado = voucherNegocio.validarVoucher(voucher);            

            if (resultado)
            {
                lblErrorVoucher.Text = "El código del voucher ya ha sido canjeado o no existe.";
                lblErrorVoucher.Visible = true;
            }
            else
            {
                lblErrorVoucher.Visible = false;
                Response.Redirect("ArticulosPromo.aspx", false);
            }

        }
    }
}