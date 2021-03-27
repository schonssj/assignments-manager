using AssignmentsManager.Application.InputModels.Assignments;
using AssignmentsManager.Core.Entities.Assignments;
using AutoMapper;

namespace AssignmentsManager.Application.MappingProfiles.Assignments
{
    public class UpdateAssignmentInputModelToEntityMappingProfile : Profile
    {
        public UpdateAssignmentInputModelToEntityMappingProfile() => CreateMap<UpdateAssignmentInputModel, Assignment>();
    }
}
