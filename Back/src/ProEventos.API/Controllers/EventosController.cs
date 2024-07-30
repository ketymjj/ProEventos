using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using ProEventos.Domain;
using ProEventos.Application.Contratos;
using System.Threading.Tasks;
using System;
using Microsoft.AspNetCore.Http;
using ProEventos.Application.Dtos;



namespace ProEventos.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EventosController : ControllerBase
    {

        private readonly IEventoService _eventoService;

        public EventosController(IEventoService eventoService )
        {
            _eventoService = eventoService;
          
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
           try
           {
               var eventos = await _eventoService.GetAllEventosAsync(true);
               if(eventos == null) 
               //return NotFound("Nenhum evento encontrado.");
               return NoContent();

               return Ok(eventos);
           }
           catch (Exception ex)
           {
            return this.StatusCode(StatusCodes.Status500InternalServerError,
            $"Erro ao tentar recuperar eventos. Erro: {ex.Message}");

           }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
           try
           {
               var evento = await _eventoService.GetEventoByIdAsync(id);
               if(evento == null) 
               //return NotFound("Evento por Id não encontrads");
               return NoContent();

               return Ok(evento);
           }
           catch (Exception ex)
           {
            return this.StatusCode(StatusCodes.Status500InternalServerError,
            $"Erro ao tentar recuperar eventos. Erro: {ex.Message}");

           }
        }

         [HttpGet("{tema}/tema")]
        public async Task<IActionResult> GetByTema(string tema)
        {
           try
           {
               var evento = await _eventoService.GetAllEventosByTemaAsync(tema);
               if(evento == null) 
               //return NotFound("Evento por temas não encontrados.");
               return NoContent();

               return Ok(evento);
           }
           catch (Exception ex)
           {
            return this.StatusCode(StatusCodes.Status500InternalServerError,
            $"Erro ao tentar recuperar eventos. Erro: {ex.Message}");

           }
        }

        [HttpPost]
        public async Task<IActionResult> Post(EventoDto model)
        {
           try
           {
               var evento = await _eventoService.AddEvento(model);
               if(evento == null) 
               //return BadRequest("Erro ao tentar adicionar evento.");
               return NoContent();

               return Ok(evento);
           }
           catch (Exception ex)
           {
            return this.StatusCode(StatusCodes.Status500InternalServerError,
            $"Erro ao tentar adicionar eventos. Erro: {ex.Message}");

           }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, EventoDto model)
        {
           try
           {
               var evento = await _eventoService.UpdateEvento(id, model);
               if(evento == null) 
               //return BadRequest("Erro ao tentar adicionar evento.");
               return NoContent();

               return Ok(evento);
           }
           catch (Exception ex)
           {
            return this.StatusCode(StatusCodes.Status500InternalServerError,
            $"Erro ao tentar atualizar eventos. Erro: {ex.Message}");

           }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
           try
           {
              if(await _eventoService.DeleteEvento(id))
                return Ok("Deletado");
              else
                 return BadRequest("Evento não deletado");

             //Outro jeito de deletar 
            // return  await _eventoService.DeleteEvento(id) ? 
                                        //Ok("Deletado")  
                                        //: BadRequest("Evento não deletado");
           // throw new Exception("Ocorreu um problema não especifico ao tentar deletar Evento");
              
           }
           catch (Exception ex)
           {
            return this.StatusCode(StatusCodes.Status500InternalServerError,
            $"Erro ao tentar deletar evento. Erro: {ex.Message}");

           }
        }
    }
}
