using System.ComponentModel.DataAnnotations.Schema;
using webapi.Models;

public class Appointment
{
    public int Id { get; set; }
    public int DoctorId { get; set; }
    public DateTime Date { get; set; }
    public virtual Doctor Doctor { get; set; }

}
