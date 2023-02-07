using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace GraphQLDemo.Models;

public class Department
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int DepartmentId
    {
        get;
        set;
    }
    public string Name
    {
        get;
        set;
    }
    public ICollection<Employee> Employees
    {
        get;
        set;
    }
}  
