using System;
using Shared.Dtos;
using Shared.Enums;

namespace ExperimentsWithRecords
{
    public record EventPriceDtoToo(int Id, DateTimeOffset Date, string Name, EventType EventType,
    string Venue, int PercentageSold, int TicketPrice)
    : EventPriceDto(Id, Date, Name, EventType, Venue, PercentageSold, TicketPrice);

    class Program
    { 
        static void Main(string[] args)
        {
            var now = DateTimeOffset.Now;
            EventPriceDto dto = new(1, now, "Test", EventType.Concert, "Music hall", 80, 100);
            EventPriceDtoToo dto2 = new(1, now, "Test", EventType.Concert, "Music hall", 80, 100);
            var e = dto == dto2;

            DtoBase dto3 = dto with { Name = "Concert" };
            var isEventPrice = dto3 is EventPriceDto;
        }
    }
}