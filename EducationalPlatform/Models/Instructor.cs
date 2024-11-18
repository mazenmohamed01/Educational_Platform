using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace EducationalPlatform.Models;

public partial class Instructor
{
    public int Id { get; set; }

    public string? FullName { get; set; }

    public string? Email { get; set; }

    public string? Password { get; set; }

    public DateTime? JoinDate { get; set; }

    public string? Gender { get; set; }
    [NotMapped]
    public IFormFile? clientFile { get; set; }
    public string? Image { get; set; }

    public string? IsDelete { get; set; }

    public virtual ICollection<Course> Courses { get; set; } = new List<Course>();
}
