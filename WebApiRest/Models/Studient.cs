using System;
using System.Collections.Generic;

namespace WebApiRest.Models;

public partial class Studient
{
    public int IdStudent { get; set; }

    public string? FirstName { get; set; }

    public string? LastName { get; set; }

    public DateTime? AdmissionDate { get; set; }

    public string? Career { get; set; }

    public DateTime? RegisterDate { get; set; }
}
