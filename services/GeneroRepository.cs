using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using TestCrud.models.db;
using TestCrud.models.db.TestCrud;
using TestCrud.models.db.TestCrud.StoreProcedure;

namespace TestCrud.services
{
    public class GeneroRepository : IGeneroRepository
    {
        private readonly TestCrudContext _context;

        public GeneroRepository(TestCrudContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<TGenero>> BuscarGeneros()
        {
            return await _context.TGeneros.ToListAsync();
        }

        public SpCrud GuardarGenero(string descripcion)
        {
            SpCrud res = new SpCrud(){
                NroError = -1,
                MessageError = string.Empty
            };
            try
            {
                List<SqlParameter> parametros =  new List<SqlParameter>(){
                    new SqlParameter("@descripcion",descripcion),
                };
     
                var data = _context.SpCrud
                            .FromSqlRaw("EXEC [dbo].SpCrearGenero @descripcion = @descripcion",parametros.ToArray()).ToList();
                
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