using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace dominio
{
    public class Articulo
    {
        public int Id { get; set; }

        [DisplayName("Código")]
        public string Codigo { get; set; }

        [DisplayName("Nombre")]
        public string Nombre { get; set; }

        [DisplayName("Descripción")]
        public string Descripcion { get; set; }

        [DisplayName("Marca")]
        public Marca TipoMarca { get; set; }

        [DisplayName("Categoría")]
        public Categoria TipoCategoria { get; set; }
        public List<Imagen> ImagenArticulo { get; set; }
        public decimal Precio { get; set; }
        
    }
}
