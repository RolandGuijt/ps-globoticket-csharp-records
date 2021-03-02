using System.Linq;
using Api.Entities;
using Api.Mappers;
using Api.Repositories;
using Microsoft.AspNetCore.Mvc;
using Shared.Dtos;

namespace Api.Controllers
{
    [ApiController]
    [Route("event")]
    public class EventController : Controller
    {
        private readonly EventMapper _eventMapper;
        private readonly EventRepository _eventRepository;

        public EventController(EventRepository eventRepository, EventMapper eventMapper)
        {
            _eventRepository = eventRepository;
            _eventMapper = eventMapper;
        }

        [HttpGet]
        public IActionResult GetEvents()
        {
            var eventEntities = _eventRepository.GetAll();

            if (!eventEntities.Any())
                return NoContent();

            var eventDtos = eventEntities.Select(e => _eventMapper.ConvertEntityToPriceDto(e));
            return Ok(eventDtos);
        }

        [HttpGet("{eventId}")]
        public IActionResult GetEvent(int eventId)
        {
            var eventEntity = _eventRepository.GetById(eventId);

            if (eventEntity == null)
                return NotFound();

            var eventDto = _eventMapper.ConvertEntityToPriceDto(eventEntity);
            return Ok(eventDto);
        }

        [HttpPost("/conference")]
        public IActionResult AddConference(ConferenceDto conferenceDto)
        {
            var entity = new ConferenceEntity();
            _eventMapper.FillConferenceEntityWithDto(conferenceDto, entity);
            _eventRepository.AddEvent(entity);
            return CreatedAtAction("GetEvent", new {eventId = entity.Id}, entity);
        }

        [HttpPost("/multidayconference")]
        public IActionResult AddMultiDayConference(MultiDayConferenceDto conferenceDto)
        {
            var entity = new MultiDayConferenceEntity();
            _eventMapper.FillMultiDayConferenceEntityWithDto(conferenceDto, entity);
            _eventRepository.AddEvent(entity);
            return CreatedAtAction("GetEvent", new {eventId = entity.Id}, entity);
        }

        [HttpPost("/concert")]
        public IActionResult AddConcert(ConcertDto concertDto)
        {
            var entity = new ConcertEntity();
            _eventMapper.FillConcertEntityWithDto(concertDto, entity);
            _eventRepository.AddEvent(entity);
            return CreatedAtAction("GetEvent", new {eventId = entity.Id}, entity);
        }

        [HttpPost("/sportsgame")]
        public IActionResult AddSportsGame(SportsGameDto sportsGameDto)
        {
            var entity = new SportsGameEntity();
            _eventMapper.FillSportsGameEntityWithDto(sportsGameDto, entity);
            _eventRepository.AddEvent(entity);
            return CreatedAtAction("GetEvent", new {eventId = entity.Id}, entity);
        }
    }
}