using System;

namespace webapi.Models
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
