using System;
using System.Collections.Generic;

namespace TestCrud.models.db.TestCrud;

public partial class TGenero
{
    public int CodGenero { get; set; }

    public string? TxtDesc { get; set; }

    public virtual ICollection<TPelicula> CodPeliculas { get; } = new List<TPelicula>();
}
