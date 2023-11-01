﻿using System.ComponentModel.DataAnnotations;

namespace jsgriddynamic.Models
{
    public class Employee
    {
        [Key]
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Email { get; set; }
        public long Phone { get; set; }
        public int Age { get; set; }
        public string? Gender { get; set; }
        public string? Country { get; set; }

        public string? State { get; set; }
        public string? City { get; set; }
        public string? PostalCode { get; set; }

    }
}
