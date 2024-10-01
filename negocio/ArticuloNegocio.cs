using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using dominio;

namespace negocio
{
    public class ArticuloNegocio
    {
        public List<Articulo> listar()
        {
            List<Articulo> lista = new List<Articulo>();
            AccesoDatos datos = new AccesoDatos();
            AccesoDatos datosImagenes = new AccesoDatos();


            try
            {
                datos.setearConsulta(@"SELECT a.Id, a.Codigo, a.Nombre, a.Descripcion,
                                      a.IdMarca, ISNULL(m.Descripcion, 'Sin Marca') AS Marca,
                                      a.IdCategoria, ISNULL(c.Descripcion, 'Sin Categoria') AS Categoria,
                                      a.Precio
                               FROM articulos AS a
                               LEFT JOIN marcas AS m ON m.Id = a.IdMarca
                               LEFT JOIN categorias AS c ON c.Id = a.IdCategoria");
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    Articulo aux = new Articulo();
                    aux.Id = (int)datos.Lector["Id"];
                    aux.Codigo = (string)datos.Lector["Codigo"];
                    aux.Nombre = (string)datos.Lector["Nombre"];
                    if (!(datos.Lector["Descripcion"] is DBNull))
                        aux.Descripcion = (string)datos.Lector["Descripcion"];
                    aux.TipoMarca = new Marca();
                    if (!(datos.Lector["IdMarca"] is DBNull))
                        aux.TipoMarca.Id = (int)datos.Lector["IdMarca"];
                    aux.TipoMarca.Descripcion = (string)datos.Lector["Marca"];             
                    aux.TipoCategoria = new Categoria();
                    if (!(datos.Lector["IdCategoria"] is DBNull))
                        aux.TipoCategoria.Id = (int)datos.Lector["IdCategoria"];
                    aux.TipoCategoria.Descripcion = (string)datos.Lector["Categoria"];
                    aux.Precio = (decimal)datos.Lector["Precio"];
                    aux.ImagenArticulo = new List<Imagen>();

                    lista.Add(aux);
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
            try
            {
                datosImagenes.setearConsulta("SELECT img.IdArticulo, img.ImagenUrl FROM imagenes AS img;");
                datosImagenes.ejecutarLectura();

                while (datosImagenes.Lector.Read())
                {
                    int idArticulo = (int)datosImagenes.Lector["IdArticulo"];
                    string imagenUrl = (string)datosImagenes.Lector["ImagenUrl"];

                    foreach (Articulo articulo in lista)
                    {
                        if(articulo.Id == idArticulo)
                        {
                            Imagen imagen = new Imagen { ImagenUrl = imagenUrl };
                            articulo.ImagenArticulo.Add(imagen);
                        }
                    }

                }
            }
            
            catch (Exception ex)
            {
                throw ex;
            }

            finally
            {
                datosImagenes.cerrarConexion();
            }

            return lista;
           
        }
        public void agregar(Articulo articulo)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta("SELECT COUNT(*) FROM ARTICULOS WHERE Codigo = @Codigo AND IdMarca = @idMarca AND IdCategoria = @idCategoria");
                datos.setearParametro("@Codigo", articulo.Codigo);
                datos.setearParametro("@idMarca", articulo.TipoMarca.Id);
                datos.setearParametro("@idCategoria", articulo.TipoCategoria.Id);

                int cantidad = (int)datos.ejecutarScalar();

                if (cantidad > 0)
                {
                    throw new Exception($"El artículo con Código '{articulo.Codigo}', Marca '{articulo.TipoMarca}', Categoria '{articulo.TipoCategoria}' ya existe en la base de datos.");
                }
                else
                {
                    datos.setearConsulta("INSERT INTO ARTICULOS (Codigo, Nombre, Descripcion, IdMarca, IdCategoria, Precio)values(@Codigo, @Nombre, @Descripcion, @idMarca, @idCategoria, @Precio)");
                    datos.setearParametro("@Codigo", articulo.Codigo);
                    datos.setearParametro("@Nombre", articulo.Nombre);
                    datos.setearParametro("@Descripcion", articulo.Descripcion);
                    datos.setearParametro("@idMarca", articulo.TipoMarca.Id);
                    datos.setearParametro("@idCategoria", articulo.TipoCategoria.Id);
                    datos.setearParametro("@Precio", articulo.Precio);
                    datos.ejecutarAccion();
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
        public void modificar(Articulo art)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("SELECT COUNT(*) FROM ARTICULOS WHERE Codigo = @Codigo AND IdMarca = @idMarca AND IdCategoria = @idCategoria AND Id <> @id");
                datos.setearParametro("@Codigo", art.Codigo);
                datos.setearParametro("@idMarca", art.TipoMarca.Id);
                datos.setearParametro("@idCategoria", art.TipoCategoria.Id);
                datos.setearParametro("@id", art.Id);


                int cantidad = (int)datos.ejecutarScalar();

                if (cantidad > 0)
                {
                    throw new Exception($"El artículo con Código '{art.Codigo}', Marca '{art.TipoMarca}', Categoria '{art.TipoCategoria}' ya existe en la base de datos.");
                }
                else
                {

                datos.setearConsulta("update ARTICULOS set Codigo = @codigo, Nombre = @nombre, Descripcion = @descripcion, IdMarca = @idMarca, IdCategoria = @idCategoria, Precio = @precio where Id = @id");
                datos.setearParametro("@codigo", art.Codigo);
                datos.setearParametro("@nombre", art.Nombre);
                datos.setearParametro("@descripcion", art.Descripcion);
                datos.setearParametro("@idMarca", art.TipoMarca.Id);
                datos.setearParametro("@idCategoria", art.TipoCategoria.Id);
                datos.setearParametro("@precio", art.Precio);
                datos.setearParametro("@id", art.Id);
                datos.ejecutarAccion();
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

        public void eliminar(int id)
        {
            try
            {
                AccesoDatos datos = new AccesoDatos();

                datos.setearConsulta("DELETE FROM IMAGENES WHERE IdArticulo = " + id);
                datos.ejecutarAccion();
                datos.cerrarConexion();

                datos.setearConsulta("delete from ARTICULOS where Id = @id");
                datos.setearParametro("id", id);
                datos.ejecutarAccion();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        
        }

        public List<Articulo> filtrar(string campo, string criterio, string filtro)
        {
            List<Articulo> lista = new List<Articulo>();
            AccesoDatos datos = new AccesoDatos();
            try
            {
                string consulta = @"
                                    SELECT a.Id, a.Codigo, a.Nombre, a.Descripcion, 
                                    a.IdMarca, ISNULL(m.Descripcion, 'Sin Marca') AS Marca, 
                                    a.IdCategoria, ISNULL(c.Descripcion, 'Sin Categoria') AS Categoria, 
                                    a.Precio
                                    FROM articulos AS a
                                    LEFT JOIN marcas AS m ON m.Id = a.IdMarca
                                    LEFT JOIN categorias AS c ON c.Id = a.IdCategoria
                                    WHERE ";
                switch (campo)
                {
                    case "Precio":
                        switch (criterio)
                        {
                            case "Mayor a":
                                consulta += "Precio > " + filtro;
                                break;
                            case "Menor a":
                                consulta += "Precio < " + filtro;
                                break;
                            default:
                                consulta += "Precio = " + filtro;
                                break;
                        }
                        break;

                    case "Código":
                        switch (criterio)
                        {
                            case "Comienza con":
                                consulta += "Codigo like '" + filtro + "%' ";
                                break;
                            case "Termina con":
                                consulta += "Codigo like '%" + filtro + "'";
                                break;
                            default:
                                consulta += "Codigo like '%" + filtro + "%'";
                                break;
                        }
                        break;

                    case "Nombre":
                        switch (criterio)
                        {
                            case "Comienza con":
                                consulta += "Nombre like '" + filtro + "%' ";
                                break;
                            case "Termina con":
                                consulta += "Nombre like '%" + filtro + "'";
                                break;
                            default:
                                consulta += "Nombre like '%" + filtro + "%'";
                                break;
                        }
                        break;
                    default:
                        break;
                }

                datos.setearConsulta(consulta);
                datos.ejecutarLectura();
                while (datos.Lector.Read())
                {
                    Articulo aux = new Articulo();
                    aux.Id = (int)datos.Lector["Id"];
                    aux.Codigo = (string)datos.Lector["Codigo"];
                    aux.Nombre = (string)datos.Lector["Nombre"];
                    if (!(datos.Lector["Descripcion"] is DBNull))
                        aux.Descripcion = (string)datos.Lector["Descripcion"];
                    aux.TipoMarca = new Marca();
                    if (!(datos.Lector["IdMarca"] is DBNull))
                        aux.TipoMarca.Id = (int)datos.Lector["IdMarca"];
                    aux.TipoMarca.Descripcion = (string)datos.Lector["Marca"];
                    aux.TipoCategoria = new Categoria();
                    if (!(datos.Lector["IdCategoria"] is DBNull))
                        aux.TipoCategoria.Id = (int)datos.Lector["IdCategoria"];
                    aux.TipoCategoria.Descripcion = (string)datos.Lector["Categoria"];
                    aux.Precio = (decimal)datos.Lector["Precio"];
                    aux.ImagenArticulo = new List<Imagen>();

                    lista.Add(aux);

                }

                return lista;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public void eliminarImagen(int idImagen)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("DELETE FROM imagenes WHERE Id = @idImagen");
                datos.setearParametro("@idImagen", idImagen);
                datos.ejecutarAccion();
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

        public List<Imagen> listarImagenesPorArticulo(int idArticulo)
        {
            List<Imagen> listaImagenes = new List<Imagen>();
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta("SELECT Id, ImagenUrl FROM imagenes WHERE IdArticulo = @idArticulo");
                datos.setearParametro("@idArticulo", idArticulo);
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    Imagen imagen = new Imagen();
                    imagen.Id = (int)datos.Lector["Id"];
                    imagen.ImagenUrl = (string)datos.Lector["ImagenUrl"];

                    listaImagenes.Add(imagen);
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

            return listaImagenes;

        }

     }
}
