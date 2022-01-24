using Microsoft.AspNetCore.Mvc;
using Vacation.Repositories;
using Vacation.Entities;
using Vacation.Dtos;
using Microsoft.AspNetCore.Cors;

namespace Vacation.Controllers{
    [EnableCors("Policy")]
    [ApiController]
    [Route("destinations")]
    public class DestinationsController: ControllerBase{
        private readonly  IDestinationsRepository  Destinationrepository;
        public DestinationsController(IDestinationsRepository Destinationrepository ){
            this.Destinationrepository = Destinationrepository;
        }
        [EnableCors("Policy")]
        [HttpGet]
        public IEnumerable<Destination> GetDestinations(){
            var destinations = Destinationrepository.GetDestinations();
            return destinations;
        }
        [HttpGet("filtered")]
        public IEnumerable<Destination> GetDestination(string month, decimal min, decimal max){
            var destinations = Destinationrepository.GetFilteredDestinations(month, min, max);
            return destinations;
        }
        [HttpPost]
        public ActionResult<Destination> CreateDestination(CreateDestinationDto destination){
            Destination newDestination = new(){
                id = Guid.NewGuid(),
                City = destination.City,
                Country = destination.Country,
                Continent = destination.Continent,
                Jan = destination.Jan,
                Feb = destination.Feb,
                Mar = destination.Mar,
                Apr = destination.Apr,
                May = destination.May,
                Jun = destination.Jun,
                Jul = destination.Jul,
                Aug = destination.Aug,
                Sep = destination.Sep,
                Oct = destination.Oct,
                Nov = destination.Nov,
                Dec = destination.Dec,
            };
            Destinationrepository.CreateDestination(newDestination);
            return CreatedAtAction(nameof(GetDestinations), new {city = destination.City}, destination);
        }
    }
}