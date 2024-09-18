using System;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ProEventos.API.Models;

namespace ProEventos.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EventoController : ControllerBase
    {
        public IEnumerable<Evento> _evento = new Evento[]{
                new Evento(){
                    EventoId = 1,
                    Tema = "Angular 11",
                    Local = "SP",
                    Lote = "Primeiro",
                    QtdPessoas = 250,
                    DataEvento = DateTime.Now.AddDays(2).ToString()
                },
                new Evento(){
                    EventoId = 2,
                    Tema = "Python 12",
                    Local = "BH",
                    Lote = "Terceiro",
                    QtdPessoas = 40,
                    DataEvento = DateTime.Now.AddDays(5).ToString()
                }
        };

        public EventoController(ILogger<EventoController> logger)
        {
        }

        [HttpGet]
        public IEnumerable<Evento> Get()
        {
            return _evento;
        }

        [HttpGet("{id}")]
        public ActionResult<Evento> GetById(int id)
        {
            var evento = _evento.FirstOrDefault(e => e.EventoId == id);

            if (evento == null)
            {
                return NotFound();
            }

            return Ok(evento);
        }
    }
}