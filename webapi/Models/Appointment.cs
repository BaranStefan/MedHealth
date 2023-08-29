using YourNamespace.Models;

public class Appointment
{
    public int Id { get; set; }
    public int DoctorId { get; set; }
    public DateTime Date { get; set; }

    public required Doctor Doctor { get; set; } // Navigation property
}
