using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
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

        public SpCrud AlquilarPelicula(int codPelicula, int codUsuario, double precio)
        {
            SpCrud res = new SpCrud(){
                NroError = -1,
                MessageError = string.Empty
            };
            try
            {
                List<SqlParameter> parametros =  new List<SqlParameter>(){
                    new SqlParameter("@cod_pelicula",codPelicula),
                    new SqlParameter("@cod_usuario",codUsuario),
                    new SqlParameter("@precio",precio),
                };
     
                var data = _context.SpCrud
                            .FromSqlRaw("EXEC [dbo].[AlquilarPelicula] @cod_pelicula = @cod_pelicula, @cod_usuario = @cod_usuario, @precio=@precio",parametros.ToArray()).ToList();
                
                if(data.Count > 0)
                    res = data[0];
                
                return res;
            }
            catch(Exception ex)
            {
                return new SpCrud(){
                    NroError = -1,
                    MessageError = ex.Message
                };
            }
        }

        public SpCrud AsignarGeneroAPelicula(int codPelicula, int codGenero)
        {
            SpCrud res = new SpCrud(){
                NroError = -1,
                MessageError = string.Empty
            };
            try
            {
                List<SqlParameter> parametros =  new List<SqlParameter>(){
                    new SqlParameter("@cod_pelicula",codPelicula),
                    new SqlParameter("@cod_genero",codGenero),
                };
     
                var data = _context.SpCrud
                            .FromSqlRaw("EXEC [dbo].SpAsignarGeneroAPelicula @cod_pelicula = @cod_pelicula, @cod_genero = @cod_genero",parametros.ToArray()).ToList();
                
                if(data.Count > 0)
                    res = data[0];
                
                return res;
            }
            catch(Exception ex)
            {
                return new SpCrud(){
                    NroError = -1,
                    MessageError = ex.Message
                };
            }
        }

        public SpCrud BorrarPelicula(int cod_pelicula)
        {
            SpCrud res = new SpCrud(){
                NroError = -1,
                MessageError = string.Empty
            };
            try
            {
                List<SqlParameter> parametros =  new List<SqlParameter>(){
                    new SqlParameter("@cod_pelicula",cod_pelicula),
                };
     
                var data = _context.SpCrud
                            .FromSqlRaw("EXEC [dbo].SpBorrarPelicula @cod_pelicula = @cod_pelicula",parametros.ToArray()).ToList();
                
                if(data.Count > 0)
                    res = data[0];
                
                return res;
            }
            catch(Exception ex)
            {
                return new SpCrud(){
                    NroError = -1,
                    MessageError = ex.Message
                };
            }
        }

        public SpCrud DevolverPelicula(int codAlquilerPelicula)
        {
           SpCrud res = new SpCrud(){
                NroError = -1,
                MessageError = string.Empty
            };
            try
            {
                List<SqlParameter> parametros =  new List<SqlParameter>(){
                    new SqlParameter("@cod_alquiler_pelicula",codAlquilerPelicula),
                };
     
                var data = _context.SpCrud
                            .FromSqlRaw("EXEC [dbo].[SpDevolverPelicula] @cod_alquiler_pelicula = @cod_alquiler_pelicula",parametros.ToArray()).ToList();
                
                if(data.Count > 0)
                    res = data[0];
                
                return res;
            }
            catch(Exception ex)
            {
                return new SpCrud(){
                    NroError = -1,
                    MessageError = ex.Message
                };
            }
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

        public SpCrud GuardarPelicula(string descripcion, int stockAlquiler, int stockVenta, double precioAlquiler, double precioVenta)
        {
            SpCrud res = new SpCrud(){
                NroError = -1,
                MessageError = string.Empty
            };
            try
            {
                List<SqlParameter> parametros =  new List<SqlParameter>(){
                    new SqlParameter("@descripcion",descripcion),
                    new SqlParameter("@stock_alquiler",stockAlquiler),
                    new SqlParameter("@stock_venta",stockVenta),
                    new SqlParameter("@precio_alquiler",precioAlquiler),
                    new SqlParameter("@precio_venta",precioVenta),
                };

                var data = _context.SpCrud
                            .FromSqlRaw("EXEC [dbo].[SpCrearPelicula] @descripcion = @descripcion, @stock_alquiler = @stock_alquiler, @stock_venta = @stock_venta, @precio_alquiler = @precio_alquiler, @precio_venta = @precio_venta",parametros.ToArray()).ToList();
                
                if(data.Count > 0)
                    res = data[0];
                
                return res;
            }
            catch(Exception ex)
            {
                return new SpCrud(){
                    NroError = -1,
                    MessageError = ex.Message
                };
            }
        }

        public SpCrud ModificarPelicula(int cod_pelicula, string descripcion, int stockAlquiler, int stockVenta, double precioAlquiler, double precioVenta)
        {
            SpCrud res = new SpCrud(){
                NroError = -1,
                MessageError = string.Empty
            };
            try
            {
                List<SqlParameter> parametros =  new List<SqlParameter>(){
                    new SqlParameter("@cod_pelicula",cod_pelicula),
                    new SqlParameter("@descripcion",descripcion),
                    new SqlParameter("@stock_alquiler",stockAlquiler),
                    new SqlParameter("@stock_venta",stockVenta),
                    new SqlParameter("@precio_alquiler",precioAlquiler),
                    new SqlParameter("@precio_venta",precioVenta),
                };

                var data = _context.SpCrud
                            .FromSqlRaw("EXEC [dbo].[SpModificarPelicula] @descripcion = @descripcion, @stock_alquiler = @stock_alquiler, @stock_venta = @stock_venta, @precio_alquiler = @precio_alquiler, @precio_venta = @precio_venta",parametros.ToArray()).ToList();
                
                if(data.Count > 0)
                    res = data[0];
                
                return res;
            }
            catch(Exception ex)
            {
                return new SpCrud(){
                    NroError = -1,
                    MessageError = ex.Message
                };
            }
        }

        public SpCrud VenderPelicula(int codPelicula, int codUsuario, double precio)
        {
            SpCrud res = new SpCrud(){
                NroError = -1,
                MessageError = string.Empty
            };
            try
            {
                List<SqlParameter> parametros =  new List<SqlParameter>(){
                    new SqlParameter("@cod_pelicula",codPelicula),
                    new SqlParameter("@cod_usuario",codUsuario),
                    new SqlParameter("@precio",precio),
                };
     
                var data = _context.SpCrud
                            .FromSqlRaw("EXEC [dbo].[SpVenderPelicula] @cod_pelicula = @cod_pelicula, @cod_usuario = @cod_usuario, @precio=@precio",parametros.ToArray()).ToList();
                
                if(data.Count > 0)
                    res = data[0];
                
                return res;
            }
            catch(Exception ex)
            {
                return new SpCrud(){
                    NroError = -1,
                    MessageError = ex.Message
                };
            }
        }
    }
}