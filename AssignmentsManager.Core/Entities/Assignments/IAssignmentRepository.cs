using System.Collections.Generic;
using System.Threading.Tasks;

namespace AssignmentsManager.Core.Entities.Assignments
{
    public interface IAssignmentRepository
    {
        Task<Assignment> GetById(int id);
        Task<List<Assignment>> GetAll();
        Task<List<Assignment>> GetDone();
        Task<List<Assignment>> GetNotDoneYet();
        Task<int> CreateAssignment(Assignment assignment);
        Task<int> UpdateAssignment(Assignment assignment);
        Task<int> DeleteAssignment(Assignment assignment);
    }
}
