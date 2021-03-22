namespace AssignmentsManager.Application.ViewModels.Assignments
{
    public class AssignmentViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public bool HasBeenDone { get; set; }
    }
}
