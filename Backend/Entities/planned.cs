using System;
namespace Vacation.Entities
{
    public record PlannedVacation
    {
        public Guid id {get; init;}
        public string City { get; set; }
        public string Continent { get; set; }
        public string Country { get; set; }
        public DateTimeOffset Start {get; set;}
        public DateTimeOffset End {get; set;}
    }
}