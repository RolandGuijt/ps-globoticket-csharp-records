using Shared.Dtos;
using Web.ViewModels;

namespace Web.Mappers
{
    public class EventMapper
    {
        public EventPriceViewModel ConvertPriceDtoToViewModel(EventPriceDto dto)
        {
            var (id, date, name, eventType, venue, percentageSold, price) = dto;

            return new EventPriceViewModel
            {
                Id = id,
                Date = date,
                Name = name,
                EventType = eventType,
                Venue = venue,
                PercentageSold = percentageSold,
                TicketPrice = price
            };
        }

        public void CopyBaseProperties(EventViewModel source, EventViewModel destination)
        {
            destination.Date = source.Date;
            destination.Name = source.Name;
            destination.EventType = source.EventType;
            destination.Venue = source.Venue;
            destination.VenueCostType = source.VenueCostType;
            destination.MarketingCostType = source.MarketingCostType;
            destination.Capacity = source.Capacity;
            destination.Sold = source.Sold;
        }

        public ConferenceDto ConvertConferenceViewModelToDto(ConferenceViewModel viewModel)
        {
            return new(viewModel.Id, viewModel.Date, viewModel.Name, viewModel.EventType, viewModel.Venue,
                viewModel.VenueCostType, viewModel.MarketingCostType, viewModel.Capacity, viewModel.Sold,
                viewModel.BadgeCosts, viewModel.CateringCosts);
        }

        public MultiDayConferenceDto ConvertMultiDayConferenceViewModelToDto(MultiDayConferenceViewModel viewModel)
        {
            return new(viewModel.Id, viewModel.Date, viewModel.Name, viewModel.EventType,
                viewModel.Venue, viewModel.VenueCostType, viewModel.MarketingCostType, viewModel.Capacity,
                viewModel.Sold, viewModel.BadgeCosts,
                viewModel.CateringCosts, viewModel.NumberOfDays, viewModel.AccomodationCostType);
        }

        public ConcertDto ConvertConcertViewModelToDto(ConcertViewModel viewModel)
        {
            return new(viewModel.Id, viewModel.Date, viewModel.Name, viewModel.EventType, viewModel.Venue,
                viewModel.VenueCostType, viewModel.MarketingCostType, viewModel.Capacity, viewModel.Sold,
                viewModel.ArtistCosts, viewModel.ArtistCostType);
        }

        public SportsGameDto ConvertSportsGameViewModelToDto(SportsGameViewModel viewModel)
        {
            return new(viewModel.Id, viewModel.Date, viewModel.Name, viewModel.EventType, viewModel.Venue,
                viewModel.VenueCostType, viewModel.MarketingCostType, viewModel.Capacity, viewModel.Sold,
                viewModel.NumberOfPlayers, viewModel.CostsPerPlayer);
        }
    }
}