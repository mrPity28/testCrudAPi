using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestCrud.dto
{
    public class BodyAlquilarVenderPeliculaDto
    {
        public int cod_pelicula { get; set; }
        public int cod_usuario { get; set; }
        public double precio { get; set; }
    }
}