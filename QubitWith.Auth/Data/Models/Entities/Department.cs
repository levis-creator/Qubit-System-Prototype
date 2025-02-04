﻿using QubitWith.Auth.Data.Models.Common;
using System.ComponentModel.DataAnnotations;

namespace QubitWith.Auth.Data.Models.Entities
{
    public class Department : Auditable
    {
        [Required(ErrorMessage = "Department Name is required.")]
        public string DepartmentName { get; set; } = string.Empty;
        [Required(ErrorMessage = "Department Code is required.")]
        public string DepartmentCode { get; set; } = string.Empty;
        public ICollection<Course>? Courses { get; set; } = [];
    }
}
