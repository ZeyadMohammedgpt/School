using System.ComponentModel.DataAnnotations.Schema;

namespace School.Models.Entity;

public class Assignment
{
    public int Id { get; set; }
    public int TeacherId { get; set; }
    public int SubjectsId { get; set; }

    public Subjects Subjects { get; set; }
    public Teacher Teacher { get; set; }

    public DateTime AssignedDate { get; set; }
    
}

