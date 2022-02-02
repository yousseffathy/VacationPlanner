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
        public async Task<IEnumerable<Destination>> GetDestinationsAsync(){
            var destinations = await Destinationrepository.GetDestinationsAsync();
            return destinations;
        }
        [HttpGet("filtered")]
        public async Task<IEnumerable<Destination> >GetDestinationAsync(string month, decimal min, decimal max){
            var destinations = await Destinationrepository.GetFilteredDestinationsAsync(month, min, max);
            return destinations;
        }
        [HttpPost]
        public async Task<ActionResult<Destination>> CreateDestinationAsync(CreateDestinationDto destination){
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
            await Destinationrepository.CreateDestinationAsync(newDestination);
            return CreatedAtAction(nameof(GetDestinationsAsync), new {city = destination.City}, destination);
        }
    }
}