using Shared.Dtos;
using Web.ViewModels;

namespace Web.Mappers
{
    public class EventMapper
    {
        public EventViewModel ConvertDtoToViewModel(EventDto dto)
        {
            return new EventViewModel
            {
                Id = dto.Id,
                Date = dto.Date,
                Name = dto.Name,
                EventType = dto.EventType,
                Venue = dto.Venue,
                Capacity = dto.Capacity,
                Sold = dto.Sold
            };
        }

        public void CopyBaseProperties(EventViewModel source, EventViewModel destination)
        {
            destination.Date = source.Date;
            destination.Name = source.Name;
            destination.EventType = source.EventType;
            destination.Venue = source.Venue;
            destination.Capacity = source.Capacity;
            destination.Sold = source.Sold;
        }

        public ConferenceDto ConvertConferenceViewModelToDto(ConferenceViewModel viewModel)
        {
            return new(viewModel.Id, viewModel.Date, viewModel.Name, viewModel.EventType, viewModel.Venue,
                viewModel.Capacity, viewModel.Sold, viewModel.BadgeCosts, viewModel.CateringCosts);
        }

        public MultiDayConferenceDto ConvertMultiDayConferenceViewModelToDto(MultiDayConferenceViewModel viewModel)
        {
            return new(viewModel.Id, viewModel.Date, viewModel.Name, viewModel.EventType,
                viewModel.Venue, viewModel.Capacity, viewModel.Sold, viewModel.BadgeCosts, viewModel.CateringCosts, viewModel.NumberOfDays);
        }

        public ConcertDto ConvertConcertViewModelToDto(ConcertViewModel viewModel)
        {
            return new(viewModel.Id, viewModel.Date, viewModel.Name, viewModel.EventType, viewModel.Venue,
                viewModel.Capacity, viewModel.Sold, viewModel.ArtistCosts);
        }

        public SportsGameDto ConvertSportsGameViewModelToDto(SportsGameViewModel viewModel)
        {
            return new(viewModel.Id, viewModel.Date, viewModel.Name, viewModel.EventType, viewModel.Venue,
                viewModel.Capacity, viewModel.Sold, viewModel.NumberOfPlayers);
        }
    }
}