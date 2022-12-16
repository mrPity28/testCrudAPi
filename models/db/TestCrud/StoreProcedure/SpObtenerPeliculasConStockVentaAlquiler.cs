using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestCrud.models.db.TestCrud.StoreProcedure
{
    public class SpObtenerPeliculasConStockVentaAlquiler
    {
        public int Cod_Pelicula { get; set; }

        public string? Txt_Desc { get; set; }

        public int? Cant_Disponibles_Alquiler { get; set; }

        public int? Cant_Disponibles_Venta { get; set; }

        public decimal? Precio_Alquiler { get; set; }

        public decimal? Precio_Venta { get; set; }
    }
}