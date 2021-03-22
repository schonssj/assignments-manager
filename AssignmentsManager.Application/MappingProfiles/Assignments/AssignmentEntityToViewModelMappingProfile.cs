using AssignmentsManager.Application.ViewModels.Assignments;
using AssignmentsManager.Core.Entities.Assignments;
using AutoMapper;

namespace AssignmentsManager.Application.MappingProfiles.Assignments
{
    public class AssignmentEntityToViewModelMappingProfile : Profile
    {
        public AssignmentEntityToViewModelMappingProfile() => CreateMap<Assignment, AssignmentViewModel>();
    }
}
