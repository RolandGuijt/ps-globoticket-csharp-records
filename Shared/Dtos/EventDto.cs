using System;
using Shared.Enums;

namespace Shared.Dtos
{
    public record DtoBase (int Id, DateTimeOffset Date, string Name, EventType EventType, string Venue);

    public record EventPriceDto(int Id, DateTimeOffset Date, string Name, EventType EventType, string Venue,
        int PercentageSold, int TicketPrice) : DtoBase(
        Id, Date, Name, EventType, Venue);

    public record EventDto(int Id, DateTimeOffset Date, string Name, EventType EventType, string Venue,
        CostType VenueCostType, CostType MarketingCostType, int Capacity,
        int Sold) : DtoBase(
        Id, Date, Name, EventType, Venue);

    public record ConferenceDto(int Id, DateTimeOffset Date, string Name, EventType EventType, string Venue,
        CostType VenueCostType, CostType MarketingCostType, int Capacity,
        int Sold, int BadgeCosts, int CateringCosts) : EventDto(
        Id, Date, Name, EventType, Venue, VenueCostType, MarketingCostType, Capacity, Sold);

    public record MultiDayConferenceDto(int Id, DateTimeOffset Date, string Name, EventType EventType, string Venue,
        CostType VenueCostType, CostType MarketingCostType, int Capacity,
        int Sold, int BadgeCosts, int CateringCosts,
        int NumberOfDays, CostType AccomodationCostType) :
        ConferenceDto(
            Id, Date, Name, EventType, Venue, VenueCostType, MarketingCostType, BadgeCosts,
            CateringCosts, Capacity, Sold);

    public record ConcertDto(int Id, DateTimeOffset Date, string Name, EventType EventType, string Venue,
        CostType VenueCostType, CostType MarketingCostType, int Capacity,
        int Sold, int ArtistCosts, CostType ArtistCostType) : EventDto(Id, Date, Name, EventType, Venue,
        VenueCostType, MarketingCostType, Capacity, Sold);

    public record SportsGameDto(int Id, DateTimeOffset Date, string Name, EventType EventType, string Venue,
        CostType VenueCostType, CostType MarketingCostType, int Capacity,
        int Sold, int NumberOfPlayers, int CostsPerPlayer) : EventDto(Id, Date, Name, EventType, Venue,
        VenueCostType, MarketingCostType, Capacity, Sold);
}