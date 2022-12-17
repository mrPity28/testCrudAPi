using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using TestCrud.dto;
using TestCrud.models.db.TestCrud;

namespace TestCrud.configmmaper
{
    public class ConfigMapper : Profile
    {
        public ConfigMapper()
        {
            CreateMap<TUser , UsuarioDto>();
        }
    }
}