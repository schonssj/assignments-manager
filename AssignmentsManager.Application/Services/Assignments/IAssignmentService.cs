using AssignmentsManager.Application.InputModels.Assignments;
using AssignmentsManager.Application.ViewModels.Assignments;
using AssignmentsManager.Core.Entities.Assignments;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AssignmentsManager.Application.Entities.Assignments
{
    public interface IAssignmentService
    {
        Task<AssignmentViewModel> GetById(int id);
        Task<List<AssignmentViewModel>> GetAll();
        Task<List<AssignmentViewModel>> GetDone();
        Task<List<AssignmentViewModel>> GetNotDoneYet();
        Task<int> CreateAssignment(CreateAssignmentInputModel assignment);
        Task<int> UpdateAssignment(UpdateAssignmentInputModel assignment);
        Task<int> DeleteAssignment(int id);
    }
}
