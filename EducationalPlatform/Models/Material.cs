using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace EducationalPlatform.Models;

public partial class Material
{
    public int Id { get; set; }

    public string? FilePath { get; set; }
    [NotMapped]
    public IFormFile? clientFile { get; set; }
    public int? CoursId { get; set; }

    public string? LecuerNumber { get; set; }

    public virtual Course? Cours { get; set; }
}
