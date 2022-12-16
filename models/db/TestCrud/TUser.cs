using System;
using System.Collections.Generic;

namespace TestCrud.models.db.TestCrud;

public partial class TUser
{
    public int CodUsuario { get; set; }

    public string? TxtUser { get; set; }

    public string? TxtPassword { get; set; }

    public string? TxtNombre { get; set; }

    public string? TxtApellido { get; set; }

    public string? NroDoc { get; set; }

    public int? CodRol { get; set; }

    public int? SnActivo { get; set; }

    public virtual TRol? CodRolNavigation { get; set; }

    public virtual ICollection<TAlquilerPelicula> TAlquilerPeliculas { get; } = new List<TAlquilerPelicula>();

    public virtual ICollection<TVentaPelicula> TVentaPeliculas { get; } = new List<TVentaPelicula>();
}
