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
        public IEnumerable<PlannedVacation> GetPlannedVacations(){
            var plannedVacations = PlannedRepository.GetPlannedVacations();
            return plannedVacations;
        }
        [HttpGet("{id}")]
        public PlannedVacation GetPlannedVacation(Guid id){
            var plannedVacation = PlannedRepository.GetPlannedVacation(id);
            return plannedVacation;
        }
        [EnableCors("Policy")]
        [HttpPost]
        public ActionResult<CreatePlannedVacationDto> CreatePlannedVacation(CreatePlannedVacationDto vacationDto){
            PlannedVacation vacation = new(){
                id = Guid.NewGuid(),
                City = vacationDto.City,
                Continent = vacationDto.Continent,
                Country = vacationDto.Country,
                Start = vacationDto.Start,
                End = vacationDto.End
            };
            PlannedRepository.CreatePlannedVacation(vacation);
            return CreatedAtAction(nameof(GetPlannedVacations), new {id = vacation.id}, vacation);
        }
        [EnableCors("Policy")]
        [HttpPut("{id}")]
        public ActionResult UpdatePlannedVacation(Guid id, UpdatePlannedVacationDto vacationDto){
            var existingPlannedVacation = PlannedRepository.GetPlannedVacation(id);
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
            PlannedRepository.UpdatePlannedVacation(updatedVacation);
            return NoContent();
        }
        [EnableCors("Policy")]
        [HttpDelete("{id}")]
        public ActionResult DelePlannedVacation(Guid id){
            var existingPlannedVacation = PlannedRepository.GetPlannedVacation(id);
            if (existingPlannedVacation is null){
                return NotFound();
            }
            PlannedRepository.DeletePlannedVacation(id);
            return NoContent();
        }
    }
}