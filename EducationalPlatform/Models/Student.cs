﻿using System;
using System.Collections.Generic;

namespace EducationalPlatform.Models;

public partial class Student
{
    public int Id { get; set; }

    public string? FullName { get; set; }

    public string? Email { get; set; }

    public string? Phone { get; set; }

    public DateTime? JoinDate { get; set; }

    public string? Password { get; set; }

    public string? Gender { get; set; }

    public DateOnly? BirthDay { get; set; }

    public string? IsDelete { get; set; }

    public virtual ICollection<Regestration> Regestrations { get; set; } = new List<Regestration>();
}
