namespace Vacation.Entities
{
    public record Destination
    {
        public Guid id {get; init;}
        public string City { get; init; } = "Null";
        public string Continent { get; init; } = "Null";
        public string Country { get; init; } = "Null";
        public decimal Jan { get; init; }
        public decimal Feb { get; init; }
        public decimal Mar { get; init; }
        public decimal Apr { get; init; }
        public decimal May { get; init; }
        public decimal Jun { get; init; }
        public decimal Jul { get; init; }
        public decimal Aug { get; init; }
        public decimal Sep { get; init; }
        public decimal Oct { get; init; }
        public decimal Nov { get; init; }
        public decimal Dec { get; init; }
    }
}