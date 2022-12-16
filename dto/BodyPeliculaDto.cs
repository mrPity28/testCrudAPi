using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestCrud.dto
{
    public class BodyPeliculaDto
    {
        public int CodPelicula { get; set; }
        public string TxtDesc { get; set; }

        public int CantDisponiblesAlquiler { get; set; }

        public int CantDisponiblesVenta { get; set; }

        public double PrecioAlquiler { get; set; }

        public double PrecioVenta { get; set; }
    }
}