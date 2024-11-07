using System;
using System.Collections.Generic;

namespace GraphQLApiDemo.Model;

public partial class UserDetail
{
    public string EmpCode { get; set; } = null!;

    public string? FirstName { get; set; }

    public string? LastName { get; set; }

    public string? MobileNo { get; set; }

    public string? EmailId { get; set; }

    public DateOnly? Dob { get; set; }

    public string? Address { get; set; }

    public string? Department { get; set; }

    public string? JobTitle { get; set; }

    public string? Company { get; set; }

    public string? CompanyAddress { get; set; }

    public string? CompanyImage { get; set; }

    public string? Grade { get; set; }
}
