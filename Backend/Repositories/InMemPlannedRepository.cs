using Vacation.Entities;
namespace Vacation.Repositories
{
    public class InMemPlannedRepository : IPlannedRepository {
        private readonly List<PlannedVacation> vacations = new(){
            new PlannedVacation{ id= Guid.NewGuid(), City = "Cairo", Continent = "Africa", Country = "Egypt", Start = DateTimeOffset.UtcNow, End = DateTimeOffset.UtcNow},
            new PlannedVacation{ id= Guid.NewGuid(), City = "Alexandria", Continent = "Africa", Country = "Egypt", Start = DateTimeOffset.UtcNow, End = DateTimeOffset.UtcNow}
        };

        public void CreatePlannedVacation(PlannedVacation vacation)
        {
            vacations.Add(vacation);
        }

        public void DeletePlannedVacation(Guid id)
        {
            var index = vacations.FindIndex(existingVacation => existingVacation.id == id);
            vacations.RemoveAt(index);
        }

        public PlannedVacation GetPlannedVacation(Guid id)
        {
            return vacations.Where(vacation => vacation.id == id).SingleOrDefault();
        }

        public IEnumerable<PlannedVacation> GetPlannedVacations(){
            return vacations;
        }

        public void UpdatePlannedVacation(PlannedVacation vacation)
        {
            var index = vacations.FindIndex(existingVacation => existingVacation.id == vacation.id);
            vacations[index] = vacation;
        }
    }
}