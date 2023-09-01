using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using YourNamespace.Models;
using System.Linq;
using System.Threading.Tasks;
using YourProjectName.Data;



[Route("api/[controller]")]
[ApiController]
public class AppointmentsController : ControllerBase
{
    private readonly AppDbContext _context;

    public AppointmentsController(AppDbContext context)
    {
        _context = context;
    }

    // GET: api/Appointments
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Appointment>>> GetAppointments()
    {
        return await _context.Appointments.Include(a => a.Doctor).ToListAsync();
    }

    // GET: api/Appointments/5
    [HttpGet("{id}")]
    public async Task<ActionResult<Appointment>> GetAppointment(int id)
    {
        var appointment = await _context.Appointments.Include(a => a.Doctor).FirstOrDefaultAsync(a => a.Id == id);

        if (appointment == null)
        {
            return NotFound();
        }

        return appointment;
    }
    // POST: api/Appointments
    [HttpPost]
    public async Task<ActionResult<Appointment>> PostAppointment(Appointment appointment)
    {
        if (appointment.Date <= DateTime.Now)
        {
            return BadRequest("The appointment date and time cannot be in the past.");
        }

        if (AppointmentConflict(appointment.DoctorId, appointment.Date))
        {
            return BadRequest("An appointment already exists for this doctor at the specified time.");
        }

        _context.Appointments.Add(appointment);
        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(GetAppointment), new { id = appointment.Id }, appointment);
    }

    // PUT: api/Appointments/5
    [HttpPut("{id}")]
    public async Task<IActionResult> PutAppointment(int id, Appointment appointment)
    {
        if (appointment.Date <= DateTime.Now)
        {
            return BadRequest("The appointment date and time cannot be in the past.");
        }

        if (id != appointment.Id)
        {
            return BadRequest();
        }

        if (AppointmentConflict(appointment.DoctorId, appointment.Date, id))
        {
            return BadRequest("An appointment already exists for this doctor at the specified time.");
        }

        _context.Entry(appointment).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!AppointmentExists(id))
            {
                return NotFound();
            }
            else
            {
                throw;
            }
        }

        return NoContent();
    }


    // DELETE: api/Appointments/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteAppointment(int id)
    {
        var appointment = await _context.Appointments.FindAsync(id);
        if (appointment == null)
        {
            return NotFound();
        }

        _context.Appointments.Remove(appointment);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    private bool AppointmentExists(int id)
    {
        return _context.Appointments.Any(e => e.Id == id);
    }

    private bool AppointmentConflict(int doctorId, DateTime date, int? excludeId = null)
    {
        return _context.Appointments.Any(a => a.DoctorId == doctorId && a.Date == date && (!excludeId.HasValue || a.Id != excludeId.Value));
    }

}
