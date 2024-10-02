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
                    //throw new Exception($"El voucher con Código '{voucher.CodigoVoucher}', ya fue canjeado.");
                }
                else
                {
                    return false;
                }
                //else
                //{
                //    datos.setearConsulta("INSERT INTO ARTICULOS (Codigo, Nombre, Descripcion, IdMarca, IdCategoria, Precio)values(@Codigo, @Nombre, @Descripcion, @idMarca, @idCategoria, @Precio)");
                //    datos.setearParametro("@Codigo", articulo.Codigo);
                //    datos.setearParametro("@Nombre", articulo.Nombre);
                //    datos.setearParametro("@Descripcion", articulo.Descripcion);
                //    datos.setearParametro("@idMarca", articulo.TipoMarca.Id);
                //    datos.setearParametro("@idCategoria", articulo.TipoCategoria.Id);
                //    datos.setearParametro("@Precio", articulo.Precio);
                //    datos.ejecutarAccion();
                //}

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
