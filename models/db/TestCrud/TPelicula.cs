using System;
using System.Collections.Generic;

namespace TestCrud.models.db.TestCrud;

public partial class TPelicula
{
    public int CodPelicula { get; set; }

    public string? TxtDesc { get; set; }

    public int? CantDisponiblesAlquiler { get; set; }

    public int? CantDisponiblesVenta { get; set; }

    public decimal? PrecioAlquiler { get; set; }

    public decimal? PrecioVenta { get; set; }

    public virtual ICollection<TAlquilerPelicula> TAlquilerPeliculas { get; } = new List<TAlquilerPelicula>();

    public virtual ICollection<TVentaPelicula> TVentaPeliculas { get; } = new List<TVentaPelicula>();

    public virtual ICollection<TGenero> CodGeneros { get; } = new List<TGenero>();
}
