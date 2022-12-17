using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestCrud.models.db.TestCrud.StoreProcedure
{
    public class SpRecaudadoPorPelicula
    {
        public string Pelicula { get; set; }
        public int cantAlquilada { get; set; }
        public int cantVendida { get; set; }
        public double precio_alquiler { get; set; }
        public double precio_venta { get; set; }
    }
}