using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using dominio;

namespace negocio
{
    public class MarcaNegocio
    {
        public List<Marca> listar()
        {
            List<Marca> lista = new List<Marca>();
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta("SELECT Id, Descripcion FROM MARCAS");
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    Marca aux = new Marca();
                    aux.Id = (int)datos.Lector["Id"];
                    aux.Descripcion = (string)datos.Lector["Descripcion"];

                    lista.Add(aux);
                }

                return lista;
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

        public void agregar(Marca marca)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta("SELECT COUNT(*) FROM MARCAS WHERE Descripcion = @descripcion");
                datos.setearParametro("@descripcion", marca.Descripcion);

                int cantidad = (int)datos.ejecutarScalar();

                if (cantidad > 0)
                {
                    throw new Exception($"Ya existe una marca con la descripción '{marca.Descripcion}' en la base de datos.");
                }
                else
                {
                    datos.setearConsulta("INSERT INTO MARCAS (Descripcion) VALUES(@Descripcion)");
                    datos.setearParametro("@Descripcion", marca.Descripcion);
                    datos.ejecutarAccion();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al agregar la marca: " + ex.Message);
            }
            finally
            {
                datos.cerrarConexion();
            }
        }

        public void modificar(Marca marca)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("SELECT COUNT(*) FROM MARCAS WHERE Descripcion = @descripcion AND Id <> @id");
                datos.setearParametro("@descripcion", marca.Descripcion);
                datos.setearParametro("@id", marca.Id);

                int cantidad = (int)datos.ejecutarScalar();

                if (cantidad > 0)
                {
                    throw new Exception($"Ya existe una marca con la descripción '{marca.Descripcion}' en la base de datos.");
                }
                else
                {
                    datos.setearConsulta("UPDATE MARCAS SET Descripcion = @Descripcion Where Id = @id");
                    datos.setearParametro("@Descripcion", marca.Descripcion);
                    datos.setearParametro("@id", marca.Id);
                    datos.ejecutarAccion();
                }
                
            }
            catch (Exception ex)
            {
                throw new Exception("Error al modificar la marca: " + ex.Message);
            }
            finally
            {
                datos.cerrarConexion();
            }
        }

        public void eliminar(int id)
        {
            try
            {
                AccesoDatos datos = new AccesoDatos();
                datos.setearConsulta("delete from MARCAS where Id = @id");
                datos.setearParametro("id", id);
                datos.ejecutarAccion();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
