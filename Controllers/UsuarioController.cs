using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using TestCrud.dto;
using TestCrud.services;

namespace TestCrud.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsuarioController : ControllerBase
    {
        private readonly ILogger<PeliculaController> _logger;
        private IUsuarioRepository _usuarioRepository;
        private readonly IMapper _maper;

        public UsuarioController(ILogger<PeliculaController> logger, IUsuarioRepository usuarioRepository, IMapper mapper )
        {
            _logger = logger;
            _usuarioRepository = usuarioRepository;
            _maper = mapper;
        }

        [HttpGet]
        public IActionResult GetUsuarios()
        {
            try
            {
                var user = _usuarioRepository.GetUsuarios();
                if(user.Count() > 0)
                    return Ok(
                        new Response(){
                            Data = _maper.Map<List<UsuarioDto>>(user)
                        }
                    );
                else 
                     return NoContent();
            }
            catch(Exception ex)
            {
                return BadRequest(
                  new Response(){
                    Message = "Error en el servidor",
                    Success = false
                  }  
                );
            }
        }
        [HttpPost]
        public IActionResult CrearUsuario([FromBody] BodyCrearUsuarioDto value)
        {
           try
            {
                var res = _usuarioRepository.CrearUsuario(value.Usuario, value.Password, value.Nombre, value.Apellido, value.Nro_doc);
                
                if(res.NroError == 0)
                    return Ok(new Response(){
                        Message = res.MessageError,
                        Success = true
                    });
                else 
                    return BadRequest(
                        new Response(){
                           Message = res.MessageError,
                            Success = true
                        }
                    );
            }
            catch(Exception ex)
            {
                return BadRequest(
                  new Response(){
                    Message = "Error en el servidor",
                    Success = false
                  }  
                );
            }
        }
        
        [HttpPost("login")]
        public IActionResult Login([FromBody] LoginDto value)
        {
            try
            {
                var res = _usuarioRepository.Login(value.User, value.Password);
                
                if(res != null)
                    return Ok(new Response(){
                        Message = "Usuario",
                        Success = true,
                        Data = _maper.Map<UsuarioDto>(res)
                    });
                else 
                    return BadRequest(
                        new Response(){
                           Message = "Usuario o clave invalidos",
                            Success = true
                        }
                    );
            }
            catch(Exception ex)
            {
               return BadRequest(
                  new Response(){
                    Message = "Error en el servidor",
                    Success = false
                  }  
                );
            }
        }

    }
}