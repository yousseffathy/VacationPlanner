using System.ComponentModel.DataAnnotations;
namespace Vacation.Dtos{
    public record CreatePlannedVacationDto{
        
        [RequiredAttribute]
        public string City { get; set; }
        [RequiredAttribute]
        public string Continent { get; set; }
        [RequiredAttribute]
        public string Country { get; set; }
        [RequiredAttribute]
        public DateTimeOffset Start {get; set;}
        [RequiredAttribute]
        public DateTimeOffset End {get; set;}
    }
}