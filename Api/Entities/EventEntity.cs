using System;
using Shared.Enums;

namespace Api.Entities
{
    public class EventEntity
    {
        public int Id { get; set; }
        public DateTimeOffset Date { get; set; }
        public string Name { get; set; }
        public virtual EventType EventType => EventType.Unknown;
        public int Capacity { get; set; }
        public int Sold { get; set; }
        public string Venue { get; set; }
        public CostType VenueCostType { get; set; }
        public CostType MarketingCostType { get; set; }
    }

    public class ConferenceEntity : EventEntity
    {
        public int BadgeCosts { get; set; }
        public int CateringCosts { get; set; }
        public override EventType EventType => EventType.Conference;
    }

    public class MultiDayConferenceEntity : ConferenceEntity
    {
        public int NumberOfDays { get; set; }
        public CostType AccomodationCostType { get; set; }
        public override EventType EventType => EventType.MultiDayConference;
    }

    public class ConcertEntity : EventEntity
    {
        public int ArtistCosts { get; set; }
        public CostType ArtistCostType { get; set; }
        public override EventType EventType => EventType.Concert;
    }

    public class SportsGameEntity : EventEntity
    {
        public int NumberOfPlayers { get; set; }
        public int CostsPerPlayer { get; set; }
        public override EventType EventType => EventType.SportsGame;
    }
}