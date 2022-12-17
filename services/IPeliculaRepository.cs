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
        SpCrud GuardarPelicula(string descripcion, int stockAlquiler, int stockVenta, double precioAlquiler, double precioVenta);
        SpCrud ModificarPelicula(int cod_pelicula, string descripcion, int stockAlquiler, int stockVenta, double precioAlquiler, double precioVenta);
        SpCrud BorrarPelicula(int cod_pelicula);
        SpCrud AsignarGeneroAPelicula(int codPelicula, int codGenero);
        SpCrud AlquilarPelicula(int codPelicula, int codUsuario, double precio);
        SpCrud VenderPelicula(int codPelicula, int codUsuario, double precio);
        SpCrud DevolverPelicula(int codAlquilerPelicula);
    }
}