using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TestCrud.dto;
using TestCrud.services;

namespace TestCrud.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class GeneroController : ControllerBase
    {
        private readonly ILogger<PeliculaController> _logger;
        private IGeneroRepository _generoRepo;


        public GeneroController(ILogger<PeliculaController> logger, IGeneroRepository generoRepo)
        {
            _logger = logger;
            _generoRepo = generoRepo;
        }

        [HttpPost]
        public IActionResult GuardarGenero([FromBody] string descripcion)
        {
            try
            {
                var res = _generoRepo.GuardarGenero(descripcion);
                
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
                    Message = "no se pudo guardar el genero",
                    Success = false
                  }  
                );
            }
        }

    }
}