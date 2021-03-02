using System;
using Api.Entities;
using Shared.Enums;

namespace Api
{
    public static class PriceCalculator
    {
        private static readonly int _marginPercentage = 40;

        public static int CalculateForEvent(EventEntity eventEntity)
        {
            var price = 0;

            switch (eventEntity.MarketingCostType)
            {
                case CostType.Cheap:
                    price += 8;
                    break;
                case CostType.Moderate:
                    price += 10;
                    break;
                case CostType.Expensive:
                    price += 12;
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }

            switch (eventEntity.VenueCostType)
            {
                case CostType.Cheap:
                    price += 4;
                    break;
                case CostType.Moderate:
                    price += 6;
                    break;
                case CostType.Expensive:
                    price += 10;
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }

            if (eventEntity is ConferenceEntity conf)
            {
                price += conf.BadgeCosts;
                price += conf.CateringCosts;
            }

            if (eventEntity is MultiDayConferenceEntity multiDayconf)
            {
                switch (multiDayconf.AccomodationCostType)
                {
                    case CostType.Cheap:
                        price += 50;
                        break;
                    case CostType.Moderate:
                        price += 80;
                        break;
                    case CostType.Expensive:
                        price += 110;
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }

                if (multiDayconf.NumberOfDays < 3)
                    price += price * multiDayconf.NumberOfDays;
                if (multiDayconf.NumberOfDays >= 3 && multiDayconf.NumberOfDays < 6)
                    price += 200;
                if (multiDayconf.NumberOfDays >= 6)
                    price += 360;
            }
            else if (eventEntity is ConcertEntity concert)
            {
                price += concert.ArtistCosts / concert.Capacity;
                switch (concert.ArtistCostType)
                {
                    case CostType.Cheap:
                        price += 5;
                        break;
                    case CostType.Moderate:
                        price += 8;
                        break;
                    case CostType.Expensive:
                        price += 11;
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
            }
            else if (eventEntity is SportsGameEntity sportsGame)
            {
                if (sportsGame.Capacity < 100)
                    price += sportsGame.NumberOfPlayers * sportsGame.CostsPerPlayer / sportsGame.Sold;
                if (sportsGame.Capacity >= 100 && (sportsGame.Capacity < 150 || sportsGame.CostsPerPlayer > 1000))
                    price += 100;
                if (sportsGame.Capacity >= 150)
                    price += sportsGame.NumberOfPlayers * sportsGame.CostsPerPlayer / 200;
            }

            price = price + price / 100 * _marginPercentage;
            return price;
        }
    }
}