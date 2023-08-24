﻿// Models/Doctor.cs
using System;

namespace YourNamespace.Models
{
    public class Doctor
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public required string Speciality { get; set; }
        public required string Phone { get; set; }
        public required string Mail { get; set; }
    }
}
