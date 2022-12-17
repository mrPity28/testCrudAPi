using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestCrud.models.db.TestCrud.StoreProcedure
{
    public class SpPeliculasAlquiladas
    {
        public int Id { get; set; }        
        public string Pelicula { get; set; }        
        public string Usuario { get; set; }        
        public DateTime Fecha { get; set; }        
    }
}