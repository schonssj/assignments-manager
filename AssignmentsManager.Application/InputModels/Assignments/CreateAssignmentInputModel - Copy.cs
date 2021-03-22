using System.ComponentModel.DataAnnotations;

namespace AssignmentsManager.Application.InputModels.Assignments
{
    public class CreateAssignmentInputModel
    {
        [Required]
        public string Title { get; set; }
        [Required]
        public string Description { get; set; }
        public bool HasBeenDone { get; set; }
    }
}
