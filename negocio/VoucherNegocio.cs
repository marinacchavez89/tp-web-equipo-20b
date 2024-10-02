using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using dominio;

namespace negocio
{
    public class VoucherNegocio
    {
        public bool validarVoucher(Voucher voucher)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta("SELECT COUNT(*) FROM Vouchers WHERE CodigoVoucher = @CodigoVoucher AND IdCliente IS NULL AND FechaCanje IS NULL AND IdArticulo IS NULL");
                datos.setearParametro("@CodigoVoucher", voucher.CodigoVoucher);

                int cantidad = (int)datos.ejecutarScalar();

                if (cantidad == 0)
                {
                    return true;                   
                }
                else
                {
                    return false;
                }               

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }
    }
}
