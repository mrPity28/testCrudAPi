using System;
using System.Collections.Generic;

namespace TestCrud.models.db.TestCrud;

public partial class TVentaPelicula
{
    public int Id { get; set; }

    public int? CodPelicula { get; set; }

    public int? CodUsuario { get; set; }

    public int CantidadPelicula { get; set; }

    public double PrecioVenta { get; set; }

    public double TotalPagado { get; set; }

    public DateTime FechaDeVenta { get; set; }

    public virtual TPelicula? CodPeliculaNavigation { get; set; }

    public virtual TUser? CodUsuarioNavigation { get; set; }
}
