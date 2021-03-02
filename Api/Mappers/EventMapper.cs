using Api.Entities;
using Shared.Dtos;

namespace Api.Mappers
{
    public class EventMapper
    {
        public EventPriceDto ConvertEntityToPriceDto(EventEntity entity)
        {
            return new(entity.Id, entity.Date, entity.Name, entity.EventType, entity.Venue,
                entity.Capacity == 0 ? 0 : (int) (entity.Sold * 100.0 / entity.Capacity),
                PriceCalculator.CalculateForEvent(entity));
        }


        private void FillEventEntityWithDto(EventDto dto, EventEntity entity)
        {
            entity.Id = dto.Id;
            entity.Date = dto.Date;
            entity.Name = dto.Name;
            entity.Capacity = dto.Capacity;
            entity.Sold = dto.Sold;
            entity.Venue = dto.Venue;
            entity.VenueCostType = dto.VenueCostType;
            entity.MarketingCostType = dto.MarketingCostType;
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
            entity.AccomodationCostType = dto.AccomodationCostType;
        }

        public void FillConcertEntityWithDto(ConcertDto dto, ConcertEntity entity)
        {
            FillEventEntityWithDto(dto, entity);
            entity.ArtistCosts = dto.ArtistCosts;
            entity.ArtistCostType = dto.ArtistCostType;
        }

        public void FillSportsGameEntityWithDto(SportsGameDto dto, SportsGameEntity entity)
        {
            FillEventEntityWithDto(dto, entity);
            entity.NumberOfPlayers = dto.NumberOfPlayers;
            entity.CostsPerPlayer = dto.CostsPerPlayer;
        }
    }
}