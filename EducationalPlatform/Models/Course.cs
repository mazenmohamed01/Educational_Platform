﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace EducationalPlatform.Models;

public partial class Course
{
    public int Id { get; set; }

    public string? Image { get; set; }

    public string? CourseName { get; set; }

    public string? Description { get; set; }
    [NotMapped]
    public IFormFile? clientFile { get; set; }
    public decimal? Price { get; set; }

    public string? Level { get; set; }

    public DateTime? CreationDate { get; set; }

    public string? Requirements { get; set; }

    public string? Content { get; set; }

    public int? CateId { get; set; }

    public int? InstructorId { get; set; }

    public int? Hours { get; set; }

    public string? IsDelete { get; set; }

    public virtual Category? Cate { get; set; }

    public virtual Instructor? Instructor { get; set; }

    public virtual ICollection<Material> Materials { get; set; } = new List<Material>();

    public virtual ICollection<Regestration> Regestrations { get; set; } = new List<Regestration>();
}
