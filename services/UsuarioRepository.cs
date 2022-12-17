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
    public class UsuarioRepository : IUsuarioRepository
    {
       private readonly TestCrudContext _context;

        public UsuarioRepository(TestCrudContext context)
        {
            _context = context;
        }

        public SpCrud CrearUsuario(string usuario, string password, string nombre, string apellido, string nro_doc)
        {
            SpCrud res = new SpCrud(){
                NroError = -1,
                MessageError = string.Empty
            };
            try
            {
                List<SqlParameter> parametros =  new List<SqlParameter>(){
                    new SqlParameter("@user",usuario),
                    new SqlParameter("@password",password),
                    new SqlParameter("@nombre",nombre),
                    new SqlParameter("@apellido",apellido),
                    new SqlParameter("@nro_doc",nro_doc),
                };
     
                var data = _context.SpCrud
                            .FromSqlRaw("EXEC [dbo].[CrearUsuario] @user = @user, @password = @password, @nombre = @nombre, @apellido = @apellido, @nro_doc = @nro_doc ",parametros.ToArray()).ToList();
                
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

        public IEnumerable<TUser> GetUsuarios()
        {
            return _context.TUsers.ToList();
        }

        public TUser Login(string user, string password)
        {
            try
            {
                var userLoged = _context.TUsers.Where(u => u.TxtUser == user && u.TxtPassword == password).FirstOrDefault();
                
                return userLoged;
            }
            catch(Exception ex)
            {
                return null;
            }
        }
    }
}