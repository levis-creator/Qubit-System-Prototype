﻿namespace QubitWith.Auth.Data.Models.Dtos
{
    public class CourseDisplayDto : BaseDto
    {
        public string CourseName { get; set; } = string.Empty;
        public string CourseCode { get; set; } = string.Empty;
        public string DepartmentName { get; set; } = string.Empty;
    }
}
