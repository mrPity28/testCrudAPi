using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestCrud.models.db.TestCrud;
using TestCrud.models.db.TestCrud.StoreProcedure;
namespace TestCrud.services
{
    public interface IPeliculaRepository
    {
        TPelicula GetPelicula(int cod_pelicula);
        IEnumerable<TPelicula> GetPeliculas();
        IEnumerable<SpObtenerPeliculasConStockVentaAlquiler> GetPeliculasConStockDeVenta();
        IEnumerable<SpObtenerPeliculasConStockVentaAlquiler> GetPeliculasConStockDeAlquiler();
        IEnumerable<SpRecaudadoPorPelicula> GetRecaudadoPorPelicula();
        IEnumerable<SpPeliculasAlquiladas> GetPeliculaAlquiladaPorDevolver();
        SpCrud GuardarPelicula(string descripcion, int stockAlquiler, int stockVenta, double precioAlquiler, double precioVenta);
        SpCrud ModificarPelicula(int cod_pelicula, string descripcion, int stockAlquiler, int stockVenta, double precioAlquiler, double precioVenta);
        SpCrud BorrarPelicula(int cod_pelicula);
        SpCrud AsignarGeneroAPelicula(int codPelicula, int codGenero);
        SpCrud AlquilarPelicula(int codPelicula, int codUsuario, double precio);
        SpCrud VenderPelicula(int codPelicula, int codUsuario, double precio);
        SpCrud DevolverPelicula(int codAlquilerPelicula);
    }
}