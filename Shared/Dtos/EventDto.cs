using System;
using Shared.Enums;

namespace Shared.Dtos
{
    public record EventDto(int Id, DateTimeOffset Date, string Name, 
        EventType EventType, string Venue, int Capacity, int Sold);

    public record ConferenceDto(int Id, DateTimeOffset Date, string Name, EventType EventType, string Venue, int Capacity,
        int Sold, int BadgeCosts, int CateringCosts) : EventDto(Id, Date, Name, EventType, Venue, Capacity, Sold);

    public record MultiDayConferenceDto(int Id, DateTimeOffset Date, string Name, EventType EventType, string Venue, int Capacity,
        int Sold, int BadgeCosts, int CateringCosts, int NumberOfDays) :
        ConferenceDto(Id, Date, Name, EventType, Venue, BadgeCosts, CateringCosts, Capacity, Sold);

    public record ConcertDto(int Id, DateTimeOffset Date, string Name, EventType EventType, string Venue, int Capacity,
        int Sold, int ArtistCosts) : EventDto(Id, Date, Name, EventType, Venue, Capacity, Sold);

    public record SportsGameDto(int Id, DateTimeOffset Date, string Name, EventType EventType, string Venue, int Capacity,
        int Sold, int NumberOfPlayers) : EventDto(Id, Date, Name, EventType, Venue, Capacity, Sold);
}