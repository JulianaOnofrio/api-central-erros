﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using ErrorMonitoring.API.DTOs;
using ErrorMonitoring.Dominio.Entidades;
using ErrorMonitoring.Dominio.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ErrorMonitoring.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventsController : Controller
    {
        private readonly IEventsService _eventsService;
        private readonly IMapper _mapper;
        
        public EventsController(IEventsService eventService, IMapper mapper)
        {
            _eventsService = eventService;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<IEnumerable<EventsDTO>> GetAll() 
        {
            var _events = _eventsService.Events().ToList();
            if (_events != null){

                var retorno = _mapper.Map<List<EventsDTO>>(_events);
                return Ok(retorno);
            
            }else{
                return NoContent();
            }
        }

        // GET: EventsController/Details/5
        [HttpGet("{id}", Name = "Get")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<EventsDTO> GetById(int id) {

            var _events = _eventsService.EventById(id);

            if (_events != null)
            {
                var retorno = _mapper.Map<EventsDTO>(_events);
                return Ok(retorno);
            }
            else
            {
                return NoContent();
            }
        }

        // GET: EventsController/Create
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<EventsDTO> Post([FromBody] EventsDTO events)
        {
            var value = _mapper.Map<Events>(events);
            var _events = _eventsService.Salvar(value); 

            if (_events != null)
            {
                return Ok(_mapper.Map<EventsDTO>(_events));
            } else {
                return NoContent();
            }
        }

        // POST: EventsController/Edit/5
        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<EventsDTO> Put([FromBody] EventsDTO events)
        {
            var value = _mapper.Map<Events>(events);
            var _events = _eventsService.Atualizar(value);

            if (_events != null)
            {
                return Ok(_mapper.Map<EventsDTO>(_events));
            }
            else
            {
                return NoContent();
            }
        }

        // POST: EventsController/Delete/
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult Delete(int id)
        {
            var retorno = _eventsService.Deletar(id);

            if (retorno)
            {
                return Ok("Deletado com sucesso!");
            }
            else
            {
                return NoContent();
            }
        }

    }
}
