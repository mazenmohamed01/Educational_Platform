using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace EducationalPlatform.Models;

public partial class Category
{
    public int Id { get; set; }

    public string? CatName { get; set; }

    public string? Image { get; set; }
    [NotMapped]
    public IFormFile? clientFile { get; set; }

    public string? IsDelete { get; set; }

    public virtual ICollection<Course> Courses { get; set; } = new List<Course>();
}
