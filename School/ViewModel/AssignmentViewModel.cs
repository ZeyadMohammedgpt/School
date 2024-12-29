using School.Models.Entity;

namespace School.ViewModel
{
    public class AssignmentViewModel
    {
        public int Id { get; set; }
        public int TeacherId { get; set; }
        public int SubjectsId { get; set; }

        public DateTime AssignedDate { get; set; }

        public List<Teacher> Teachers { get; set; }
        public List<Subjects> Subjects { get; set; }
    }
}
