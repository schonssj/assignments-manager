namespace AssignmentsManager.Core.Entities.Assignments
{
    public class Assignment
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public bool HasBeenDone { get; set; }
    }
}
