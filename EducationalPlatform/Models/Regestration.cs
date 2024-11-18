﻿using System;
using System.Collections.Generic;

namespace EducationalPlatform.Models;

public partial class Regestration
{
    public int StudentId { get; set; }

    public int CourseId { get; set; }

    public DateOnly? StarTdate { get; set; }

    public virtual Course Course { get; set; } = null!;

    public virtual Student Student { get; set; } = null!;
}
