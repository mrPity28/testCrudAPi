using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TestCrud.models.db;
using TestCrud.models.db.TestCrud.StoreProcedure;

namespace TestCrud.services
{
    public class PeliculaRepository : IPeliculaRepository
    {
        private readonly TestCrudContext _context;

        public PeliculaRepository(TestCrudContext context)
        {
            _context = context;
        }

        public IEnumerable<SpObtenerPeliculasConStockVentaAlquiler> GetPeliculasConStockDeAlquiler()
        {
            List<SpObtenerPeliculasConStockVentaAlquiler> data = new List<SpObtenerPeliculasConStockVentaAlquiler>();
            try
            {
                data = _context.SpObtenerPeliculasConStockVentaAlquilers
                    .FromSqlRaw("EXEC [dbo].[SpObtenerPeliculasConStockAlquiler]").ToList();
                return data;
            }
            catch(Exception ex)
            {
                return data;
            }
        }

        public IEnumerable<SpObtenerPeliculasConStockVentaAlquiler> GetPeliculasConStockDeVenta()
        {
            List<SpObtenerPeliculasConStockVentaAlquiler> data = new List<SpObtenerPeliculasConStockVentaAlquiler>();
            try
            {
                data = _context.SpObtenerPeliculasConStockVentaAlquilers
                            .FromSqlRaw("EXEC [dbo].[SpObtenerPeliculasConStockVenta]").ToList();
                return data;
            }
            catch(Exception ex)
            {
                return data;
            }
        }
    }
}