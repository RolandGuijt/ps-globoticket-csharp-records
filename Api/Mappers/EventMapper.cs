using Api.Entities;
using Shared.Dtos;

namespace Api.Mappers
{
    public class EventMapper
    {
        public EventDto ConvertEntityToDto(EventEntity entity)
        {
            return new(entity.Id, entity.Date, entity.Name, entity.EventType, entity.Venue, entity.Capacity, entity.Sold);
        }


        private void FillEventEntityWithDto(EventDto dto, EventEntity entity)
        {
            entity.Id = dto.Id;
            entity.Date = dto.Date;
            entity.Name = dto.Name;
            entity.Capacity = dto.Capacity;
            entity.Sold = dto.Sold;
            entity.Venue = dto.Venue;
        }

        public void FillConferenceEntityWithDto(ConferenceDto dto, ConferenceEntity entity)
        {
            FillEventEntityWithDto(dto, entity);
            entity.BadgeCosts = dto.BadgeCosts;
            entity.CateringCosts = dto.CateringCosts;
        }

        public void FillMultiDayConferenceEntityWithDto(MultiDayConferenceDto dto, MultiDayConferenceEntity entity)
        {
            FillConferenceEntityWithDto(dto, entity);
            entity.NumberOfDays = dto.NumberOfDays;
        }

        public void FillConcertEntityWithDto(ConcertDto dto, ConcertEntity entity)
        {
            FillEventEntityWithDto(dto, entity);
            entity.ArtistCosts = dto.ArtistCosts;
        }

        public void FillSportsGameEntityWithDto(SportsGameDto dto, SportsGameEntity entity)
        {
            FillEventEntityWithDto(dto, entity);
            entity.NumberOfPlayers = dto.NumberOfPlayers;
        }
    }
}