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
    public class PeliculaController : ControllerBase
    {
        private readonly ILogger<PeliculaController> _logger;
        private IPeliculaRepository _peliculaRepo;

        public PeliculaController(ILogger<PeliculaController> logger, IPeliculaRepository peliculaRepo )
        {
            _logger = logger;
            _peliculaRepo = peliculaRepo;
        }

        [HttpPost]
        public IActionResult GuardarPelicula([FromBody] BodyPeliculaDto value)
        {
            try
            {
                var res = _peliculaRepo.GuardarPelicula(value.TxtDesc,value.CantDisponiblesAlquiler,value.CantDisponiblesVenta,value.PrecioAlquiler,value.PrecioVenta);
                
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
                    Message = "no se pudo guardar la pelicula",
                    Success = false
                  }  
                );
            }
        }
        
        [HttpPut]
        public IActionResult ModificarPelicula([FromBody] BodyPeliculaDto value)
        {
            try
            {
                var res = _peliculaRepo.ModificarPelicula(value.CodPelicula,value.TxtDesc,value.CantDisponiblesAlquiler,value.CantDisponiblesVenta,value.PrecioAlquiler,value.PrecioVenta);
                
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
                    Message = "no se pudo modificar la pelicula",
                    Success = false
                  }  
                );
            }
        }
        
        [HttpPost("alquilar")]
        public IActionResult AlquilarPelicula([FromBody] BodyAlquilarVenderPeliculaDto value)
        {
            try 
            {
                var res = _peliculaRepo.AlquilarPelicula(value.cod_pelicula,value.cod_usuario,value.precio);
                
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
                    Message = "no se pudo alquilar la pelicula",
                    Success = false
                  }  
                );
            }
        }

        [HttpPost("vender")]
        public IActionResult VenderPelicula([FromBody] BodyAlquilarVenderPeliculaDto value)
        {
            try 
            {
                var res = _peliculaRepo.VenderPelicula(value.cod_pelicula,value.cod_usuario,value.precio);
                
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
                    Message = "no se pudo vender la pelicula",
                    Success = false
                  }  
                );
            }
        }

        [HttpPost("alquilar/devolver")]
        public IActionResult DevolverPelicula([FromBody] BodyDevolverPeliculaDto value)
        {
            try 
            {
                var res = _peliculaRepo.DevolverPelicula(value.CodAlquilerPelicula);
                
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
                    Message = "no se pudo devolver la pelicula",
                    Success = false
                  }  
                );
            }
        }

        [HttpDelete]
        public IActionResult BorrarPelicula([FromBody] int cod_pelicula)
        {
            try
            {
                var res = _peliculaRepo.BorrarPelicula(cod_pelicula);
                
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
                    Message = "no se pudo guardar la pelicula",
                    Success = false
                  }  
                );
            }
        }
        

        [HttpPost("genero/asignar")]
        public IActionResult AsignarGeneroAPelicula([FromBody] BodyPeliculaGeneroDto value)
        {
            try
            {
                var res = _peliculaRepo.AsignarGeneroAPelicula(value.CodPelicula,value.CodGenero);
                
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
                    Message = "no se pudo guardar la pelicula",
                    Success = false
                  }  
                );
            }
        }


        [HttpGet("stock/venta")]
        public IActionResult GetPeliculasStockVenta()
        {
            try
            {
                var peliculas = _peliculaRepo.GetPeliculasConStockDeVenta();

                if(peliculas.Count() > 0)
                    return Ok(
                        new Response(){
                            Data = peliculas,
                            Message = "",
                            Success = true      
                        }
                    );
                else 
                    return NoContent();
            }
            catch(Exception ex)
            {
                return BadRequest(
                    new Response(){
                            Data = null,
                            Message = "",
                            Success = false      
                        }
                );
            }
        }
        [HttpGet("stock/alquiler")]
        public IActionResult GetPeliculasStockAlquilerC()
        {
            try
            {
                var peliculas = _peliculaRepo.GetPeliculasConStockDeAlquiler();

                if(peliculas.Count() > 0)
                    return Ok(
                        new Response(){
                            Data = peliculas,
                            Message = "",
                            Success = true      
                        }
                    );
                else 
                    return NoContent();
            }
            catch(Exception ex)
            {
                return BadRequest(
                    new Response(){
                            Data = null,
                            Message = "",
                            Success = false      
                        }
                );
            }
        }

    }
}