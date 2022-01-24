using Vacation.Entities;

namespace Vacation.Repositories{
    public interface IPlannedRepository{
        IEnumerable<PlannedVacation> GetPlannedVacations();

        PlannedVacation GetPlannedVacation(Guid id);

        void CreatePlannedVacation(PlannedVacation vacation);

        void UpdatePlannedVacation(PlannedVacation vacation);
        void DeletePlannedVacation(Guid id);
    }
}