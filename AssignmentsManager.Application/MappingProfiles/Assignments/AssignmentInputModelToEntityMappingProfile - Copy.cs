using AssignmentsManager.Application.InputModels.Assignments;
using AssignmentsManager.Core.Entities.Assignments;
using AutoMapper;

namespace AssignmentsManager.Application.MappingProfiles.Assignments
{
    public class AssignmentInputModelToEntityMappingProfile : Profile
    {
        public AssignmentInputModelToEntityMappingProfile()
        {
            CreateMap<CreateAssignmentInputModel, Assignment>()
                .ForMember(destination => destination.Id, source => source.Ignore())
                .ForMember(destination => destination.HasBeenDone, source => source.MapFrom(source => source.HasBeenDone == true ? 1 : 0));
        }
    }
}
