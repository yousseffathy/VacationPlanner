using Microsoft.AspNetCore.Mvc;
using Vacation.Repositories;
using Vacation.Entities;
using Vacation.Dtos;
using Microsoft.AspNetCore.Cors;

namespace Vacation.Controllers{
    [EnableCors("Policy")]
    [ApiController]
    [Route("planned")]
    public class PlannedController: ControllerBase{
        private readonly  IPlannedRepository  PlannedRepository;
        public PlannedController(IPlannedRepository PlannedRepository ){
            this.PlannedRepository = PlannedRepository;
        }
        [HttpGet]
        public async Task<IEnumerable<PlannedVacation>> GetPlannedVacationsAsync(){
            var plannedVacations = await PlannedRepository.GetPlannedVacationsAsync();
            return plannedVacations;
        }
        [HttpGet("{id}")]
        public async Task<PlannedVacation> GetPlannedVacationAsync(Guid id){
            var plannedVacation = await PlannedRepository.GetPlannedVacationAsync(id);
            return plannedVacation;
        }
        [EnableCors("Policy")]
        [HttpPost]
        public async Task<ActionResult<CreatePlannedVacationDto>> CreatePlannedVacationAsync(CreatePlannedVacationDto vacationDto){
            PlannedVacation vacation = new(){
                id = Guid.NewGuid(),
                City = vacationDto.City,
                Continent = vacationDto.Continent,
                Country = vacationDto.Country,
                Start = vacationDto.Start,
                End = vacationDto.End
            };
            await PlannedRepository.CreatePlannedVacationAsync(vacation);
            return CreatedAtAction(nameof(GetPlannedVacationsAsync), new {id = vacation.id}, vacation);
        }
        [EnableCors("Policy")]
        [HttpPut("{id}")]
        public async Task<ActionResult> UpdatePlannedVacationAsync(Guid id, UpdatePlannedVacationDto vacationDto){
            var existingPlannedVacation = await PlannedRepository.GetPlannedVacationAsync(id);
            if (existingPlannedVacation is null){
                return NotFound();
            }
            PlannedVacation updatedVacation = existingPlannedVacation with {
                City = vacationDto.City,
                Continent = vacationDto.Continent,
                Country = vacationDto.Country,
                Start = vacationDto.Start,
                End = vacationDto.End
            };
            await PlannedRepository.UpdatePlannedVacationAsync(updatedVacation);
            return NoContent();
        }
        [EnableCors("Policy")]
        [HttpDelete("{id}")]
        public async Task<ActionResult> DelePlannedVacationAsync(Guid id){
            var existingPlannedVacation = PlannedRepository.GetPlannedVacationAsync(id);
            if (existingPlannedVacation is null){
                return NotFound();
            }
            await PlannedRepository.DeletePlannedVacationAsync(id);
            return NoContent();
        }
    }
}