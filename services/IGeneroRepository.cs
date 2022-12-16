using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestCrud.models.db.TestCrud;
using TestCrud.models.db.TestCrud.StoreProcedure;

namespace TestCrud.services
{
    public interface IGeneroRepository
    {
        SpCrud GuardarGenero(string descripcion); 
        Task<IEnumerable<TGenero>> BuscarGeneros(); 
    }
}