using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dominio
{
    public class Imagen
    {
        public int Id { get; set; }

        [DisplayName("URL Imagen")]
        public string ImagenUrl { get; set; }
        public override string ToString()
        {
            return ImagenUrl;
        }
    }
}
