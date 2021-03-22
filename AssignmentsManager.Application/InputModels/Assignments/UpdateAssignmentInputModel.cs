using System.ComponentModel.DataAnnotations;

namespace AssignmentsManager.Application.InputModels.Assignments
{
    public class UpdateAssignmentInputModel
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public bool HasBeenDone { get; set; }
    }
}
