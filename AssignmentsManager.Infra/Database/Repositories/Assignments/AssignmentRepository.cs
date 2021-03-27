using AssignmentsManager.Core.Entities.Assignments;
using AssignmentsManager.Infra.Database.Context;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AssignmentsManager.Infra.Database.Repositories.Assignments
{
    public class AssignmentRepository : IAssignmentRepository
    {
        private readonly AssignmentsManagerContext _assignmentsManagerContext;

        public AssignmentRepository(AssignmentsManagerContext assignmentsManagerContext) => _assignmentsManagerContext = assignmentsManagerContext;

        public async Task<List<Assignment>> GetAll() => await _assignmentsManagerContext.Assignment.ToListAsync();

        public async Task<List<Assignment>> GetDone() => await _assignmentsManagerContext.Assignment.Where(a => a.HasBeenDone).ToListAsync();

        public async Task<List<Assignment>> GetNotDoneYet() => await _assignmentsManagerContext.Assignment.Where(a => !a.HasBeenDone).ToListAsync();

        public async Task<Assignment> GetById(int id) => await _assignmentsManagerContext.Assignment.FirstOrDefaultAsync(a => a.Id == id);

        public async Task<int> CreateAssignment(Assignment assignment)
        {
            _assignmentsManagerContext.Assignment.Add(assignment);
            return await _assignmentsManagerContext.SaveChangesAsync();
        }
        
        public async Task<int> UpdateAssignment(Assignment assignment)
        {
            var findAssignment = await _assignmentsManagerContext.Assignment.FirstOrDefaultAsync(a => a.Id == assignment.Id);

            if (findAssignment == null)
                return 0;

            _assignmentsManagerContext.Entry(findAssignment).State = EntityState.Detached;
            _assignmentsManagerContext.Assignment.Update(assignment);
            return await _assignmentsManagerContext.SaveChangesAsync();
        }
        
        public async Task<int> DeleteAssignment(Assignment assignment)
        {
            _assignmentsManagerContext.Assignment.Remove(assignment);
            return await _assignmentsManagerContext.SaveChangesAsync();
        }
    }
}
