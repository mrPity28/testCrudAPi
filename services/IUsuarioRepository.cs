using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestCrud.models.db.TestCrud;
using TestCrud.models.db.TestCrud.StoreProcedure;

namespace TestCrud.services
{
    public interface IUsuarioRepository
    {
        SpCrud CrearUsuario(string usuario, string password, string nombre, string apellido, string nro_doc);
        TUser Login(string user, string password);
    }
}