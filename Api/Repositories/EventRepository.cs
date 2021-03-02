using System;
using System.Collections.Generic;
using System.Linq;
using Api.Entities;

namespace Api.Repositories
{
    public class EventRepository
    {
        private static readonly List<EventEntity> Events = new()
        {
            new ConferenceEntity
            {
                Name = "Hackin' the Day",
                Venue = "Hotel Central Amsterdam",
                Date = DateTimeOffset.Now.AddMonths(1),
                BadgeCosts = 2,
                Capacity = 95,
                Sold = 10,
                CateringCosts = 30
            },
            new ConferenceEntity
            {
                Name = "Beginning Software Development",
                Venue = "Parisian Las Vegas",
                Date = DateTimeOffset.Now.AddDays(60),
                BadgeCosts = 6,
                Capacity = 543,
                Sold = 112,
                CateringCosts = 45
            },
            new MultiDayConferenceEntity
            {
                Name = "Pluralsight Live",
                Venue = "Salt Lake City Conference Center",
                Date = DateTimeOffset.Now.AddDays(90),
                BadgeCosts = 1,
                Capacity = 2499,
                Sold = 431,
                CateringCosts = 89
            },
            new ConcertEntity
            {
                Name = "A City in Concert",
                Venue = "City Dome Paris",
                Date = DateTimeOffset.Now.AddDays(120),
                ArtistCosts = 5492,
                Capacity = 5000,
                Sold = 4932
            },
            new SportsGameEntity
            {
                Name = "Chelsea vs Liverpool",
                Venue = "Wembley Stadium London",
                Date = DateTimeOffset.Now.AddDays(190),
                Capacity = 7400,
                Sold = 164,
                NumberOfPlayers = 25
            }
        };

        public List<EventEntity> GetAll()
        {
            return Events;
        }

        public EventEntity GetById(int id)
        {
            return Events.SingleOrDefault(e => e.Id == id);
        }

        public void AddEvent(EventEntity eventEntity)
        {
            eventEntity.Id = new Random(9999999).Next();
            Events.Add(eventEntity);
        }
    }
}