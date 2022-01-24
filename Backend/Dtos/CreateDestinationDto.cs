namespace Vacation.Dtos{
    public record CreateDestinationDto{
        
        
        public string City { get; set; }
        
        public string Continent { get; set; }
        
        public string Country { get; set; }
        
        public decimal Jan { get; set; }
        
        public decimal Feb { get; set; }
        
        public decimal Mar { get; set; }
        
        public decimal Apr { get; set; }
        
        public decimal May { get; set; }
        
        public decimal Jun { get; set; }
        
        public decimal Jul { get; set; }
        
        public decimal Aug { get; set; }
        
        public decimal Sep { get; set; }
        
        public decimal Oct { get; set; }
        
        public decimal Nov { get; set; }
        
        public decimal Dec { get; set; }
    }
}