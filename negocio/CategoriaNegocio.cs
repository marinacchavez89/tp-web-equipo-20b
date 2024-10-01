using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using dominio;

namespace negocio
{
    public class CategoriaNegocio
    {
        public List<Categoria> listar()
        {
            List<Categoria> lista = new List<Categoria>();
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta("SELECT Id, Descripcion FROM CATEGORIAS");
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    Categoria aux = new Categoria();
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

        public void agregar(Categoria categoria)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta("SELECT COUNT(*) FROM CATEGORIAS WHERE Descripcion = @descripcion");
                datos.setearParametro("@descripcion", categoria.Descripcion);

                int cantidad = (int)datos.ejecutarScalar();

                if (cantidad > 0)
                {
                    throw new Exception($"Ya existe una categoria con la descripción '{categoria.Descripcion}' en la base de datos.");
                }
                else
                {
                    datos.setearConsulta("INSERT INTO CATEGORIAS (Descripcion) VALUES(@Descripcion)");
                    datos.setearParametro("@Descripcion", categoria.Descripcion);
                    datos.ejecutarAccion();
                }                
            }
            catch (Exception ex)
            {
                throw new Exception("Error al agregar la categoria: " + ex.Message);
            }
            finally
            {
                datos.cerrarConexion();
            }
        }

        public void modificar(Categoria categoria)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("SELECT COUNT(*) FROM CATEGORIAS WHERE Descripcion = @descripcion AND Id <> @id");
                datos.setearParametro("@descripcion", categoria.Descripcion);
                datos.setearParametro("@id", categoria.Id);

                int cantidad = (int)datos.ejecutarScalar();

                if (cantidad > 0)
                {
                    throw new Exception($"Ya existe una categoría con la descripción '{categoria.Descripcion}' en la base de datos.");
                }
                else
                {
                    datos.setearConsulta("UPDATE CATEGORIAS SET Descripcion = @Descripcion WHERE Id = @id");
                    datos.setearParametro("@Descripcion", categoria.Descripcion);
                    datos.setearParametro("@id", categoria.Id);
                    datos.ejecutarAccion();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al modificar la categoría: " + ex.Message);
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
                datos.setearConsulta("delete from CATEGORIAS where Id = @id");
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
