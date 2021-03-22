using AssignmentsManager.Application.Entities.Assignments;
using AssignmentsManager.Application.InputModels.Assignments;
using AssignmentsManager.Application.ViewModels.Assignments;
using AssignmentsManager.Core.Entities.Assignments;
using AutoMapper;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AssignmentsManager.Application.Services.Assignments
{
    public class AssignmentService : IAssignmentService
    {
        private readonly IAssignmentRepository _assignmentRepository;
        private readonly IMapper _mapper;

        public AssignmentService(IAssignmentRepository assignmentRepository, IMapper mapper)
        {
            _assignmentRepository = assignmentRepository;
            _mapper = mapper;
        }

        public async Task<int> CreateAssignment(CreateAssignmentInputModel createAssignmentInputModel)
        {
            var mapInputModelToEntity = _mapper.Map<CreateAssignmentInputModel, Assignment>(createAssignmentInputModel);

            var createAssignmentCallback = await Task.FromResult(_assignmentRepository.CreateAssignment(mapInputModelToEntity));

            return createAssignmentCallback.Result;
        }

        public async Task<List<AssignmentViewModel>> GetAll()
        {
            var assignmentsListCallback = await Task.FromResult(_assignmentRepository.GetAll());
            
            var mappedEntitiesToViewModelsList = _mapper.Map<List<Assignment>, List<AssignmentViewModel>>(assignmentsListCallback.Result);
            
            return mappedEntitiesToViewModelsList;
        }

        public async Task<AssignmentViewModel> GetById(int id)
        {
            var assignmentCallback = await Task.FromResult(_assignmentRepository.GetById(id));

            var mappedEntityToViewModel = _mapper.Map<Assignment, AssignmentViewModel>(assignmentCallback.Result);

            return mappedEntityToViewModel;
        }

        public async Task<List<AssignmentViewModel>> GetDone()
        {
            var doneAssignmentsListCallback = await Task.FromResult(_assignmentRepository.GetDone());

            var mappedEntitiesToViewModelsList = _mapper.Map<List<Assignment>, List<AssignmentViewModel>>(doneAssignmentsListCallback.Result);

            return mappedEntitiesToViewModelsList;
        }

        public async Task<List<AssignmentViewModel>> GetNotDoneYet()
        {
            var notDoneYetAssignmentsListCallback = await Task.FromResult(_assignmentRepository.GetNotDoneYet());

            var mappedEntitiesToViewModelsList = _mapper.Map<List<Assignment>, List<AssignmentViewModel>>(notDoneYetAssignmentsListCallback.Result);

            return mappedEntitiesToViewModelsList;
        }

        public async Task<int> DeleteAssignment(int id)
        {
            var assignmentCallback = await Task.FromResult(_assignmentRepository.GetById(id));

            // TODO: Refatorar tipo de retorno.
            if (assignmentCallback.Result == null)
                return 0;

            var deleteAssignmentCallback = await Task.FromResult(_assignmentRepository.DeleteAssignment(assignmentCallback.Result));

            return deleteAssignmentCallback.Result;
        }

        public async Task<int> UpdateAssignment(UpdateAssignmentInputModel updateAssignmentInputModel)
        {
            var assignmentCallback = await Task.FromResult(_assignmentRepository.GetById(updateAssignmentInputModel.Id));

            // TODO: Refatorar tipo de retorno.
            if (assignmentCallback.Result == null)
                return 0;

            var mapInputModelToEntity = _mapper.Map<UpdateAssignmentInputModel, Assignment>(updateAssignmentInputModel);

            var updateAssignmentCallback = await Task.FromResult(_assignmentRepository.UpdateAssignment(mapInputModelToEntity));

            return updateAssignmentCallback.Result;
        }
    }
}
