﻿namespace QubitWith.Auth.Data.Models.Common.Interfaces
{
    public interface IAuditable
    {
        public int? CreatedBy { get; set; }
        public DateTime CreatedAt { get; set; }
        public int? UpdatedBy { get; set; }
        public DateTime UpdatedAt { get; set; }

    }
}
