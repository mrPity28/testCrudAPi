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