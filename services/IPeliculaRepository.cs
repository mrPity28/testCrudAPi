using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestCrud.models.db.TestCrud.StoreProcedure;
namespace TestCrud.services
{
    public interface IPeliculaRepository
    {
        IEnumerable<SpObtenerPeliculasConStockVentaAlquiler> GetPeliculasConStockDeVenta();
        IEnumerable<SpObtenerPeliculasConStockVentaAlquiler> GetPeliculasConStockDeAlquiler();
    }
}