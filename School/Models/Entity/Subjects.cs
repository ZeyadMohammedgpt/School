namespace School.Models.Entity
{
    public class Subjects
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Grade { get; set; }
        public TimeOnly Duration { get; set; }

        public ICollection<Assignment> Assignments { get; set; }

    }
}
