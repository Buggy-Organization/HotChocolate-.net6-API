﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace GraphQLDemo.Models;

public class Employee
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int EmployeeId
    {
        get;
        set;
    }
    [Required]
    public string Name
    {
        get;
        set;
    }
    [Required]
    [EmailAddress]
    public string Email
    {
        get;
        set;
    }
    [Required]
    [Range(minimum: 20, maximum: 50)]
    public int Age
    {
        get;
        set;
    }
    public int DepartmentId
    {
        get;
        set;
    }
    public Department Department
    {
        get;
        set;
    }
}  

