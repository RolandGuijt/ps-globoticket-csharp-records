using System;
using System.ComponentModel.DataAnnotations;
using Shared.Enums;

namespace Web.ViewModels
{
    public abstract class ViewModelBase
    {
        public int Id { get; set; }

        [Required] public DateTimeOffset Date { get; set; }

        [Required] public string Name { get; set; }

        public EventType EventType { get; set; }
        public string Venue { get; set; }
    }

    public class EventPriceViewModel : ViewModelBase
    {
        public int PercentageSold { get; set; }
        public int TicketPrice { get; set; }
    }

    public class EventViewModel : ViewModelBase
    {
        public EventViewModel()
        {
            Date = DateTimeOffset.Now.AddMonths(1);
            EventType = EventType.Unknown;
        }

        public CostType VenueCostType { get; set; }
        public CostType MarketingCostType { get; set; }
        public int Capacity { get; set; }
        public int Sold { get; set; }
        public virtual string ApiEndpoint => string.Empty;
    }

    public class ConferenceViewModel : EventViewModel
    {
        public int BadgeCosts { get; set; }
        public int CateringCosts { get; set; }
        public override string ApiEndpoint => "/conference";
    }

    public class MultiDayConferenceViewModel : ConferenceViewModel
    {
        public int NumberOfDays { get; set; }
        public CostType AccomodationCostType { get; set; }
        public override string ApiEndpoint => "/multidayconference";
    }

    public class ConcertViewModel : EventViewModel
    {
        public int ArtistCosts { get; set; }
        public CostType ArtistCostType { get; set; }
        public override string ApiEndpoint => "/concert";
    }

    public class SportsGameViewModel : EventViewModel
    {
        public int NumberOfPlayers { get; set; }
        public int CostsPerPlayer { get; set; }
        public override string ApiEndpoint => "/sportsgame";
    }
}