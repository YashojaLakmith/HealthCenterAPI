using System.Data;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;

using WebAPI.Abstractions.API;
using WebAPI.DataTransferObjects.Appointment;
using WebAPI.DataTransferObjects.Common;
using WebAPI.EF;
using WebAPI.Extensions;
using WebAPI.Schema;

namespace WebAPI.Services;

public class AppointmentServices
{
    private readonly ApplicationDbContext _context;
    private readonly IUserExtractor _userExtractor;

    public AppointmentServices(IUserExtractor userExtractor, ApplicationDbContext context)
    {
        _userExtractor = userExtractor;
        _context = context;
    }

    public async Task CreateAppointmentAsync(NewAppointment newAppointment)
    {
        var patient = await _context.PatientBase.FirstOrDefaultAsync(p => p.PatientId == newAppointment.UserId);
        var session = await _context.Sessions.FirstOrDefaultAsync(s => s.SessionId ==  newAppointment.SessionId);
        
        if(patient is null || session is null)
        {
            return;
        }

        var appointment = Appointment.CreateAppointment(patient, session);
        var transaction = await CreateTransactionAsync();
        try
        {
            await _context.AddAsync(appointment);
            await _context.SaveChangesAsync();
            await transaction.CommitAsync();
        }
        catch (Exception)
        {
            await transaction.RollbackAsync();
            throw;
        }
    }

    public async Task MarkUserArrivedForAppointmentAsync(string appointmentId)
    {
        var appointment = await _context.Appointments.FirstOrDefaultAsync(a => a.AppointmentId.Equals(appointmentId));
        if(appointment is null)
        {
            return;
        }

        appointment.MarkPatientArrived();
        await _context.SaveChangesAsync();
    }

    public async Task MarkUserUserBeingServedAsync(string appointmentId)
    {
        var appointment = await _context.Appointments.FirstOrDefaultAsync(a => a.AppointmentId.Equals(appointmentId));
        if (appointment is null)
        {
            return;
        }

        appointment.MarkPatientBeingServed();
        await _context.SaveChangesAsync();
    }

    public async Task MarkUserWasServedAsync(string appointmentId)
    {
        var appointment = await _context.Appointments.FirstOrDefaultAsync(a => a.AppointmentId.Equals(appointmentId));
        if (appointment is null)
        {
            return;
        }

        appointment.MarkCompletedServing();
        await _context.SaveChangesAsync();
    }

    public async Task CancelAppointmentAsync(string appointmentId)
    {
        using var transaction = await CreateTransactionAsync();
        try
        {
            var appointment = await _context.Appointments.FindAsync(appointmentId);
            if (appointment is null)
            {
                return;
            }

            _context.Remove(appointment);
            await _context.SaveChangesAsync();
            await transaction.CommitAsync();
        }
        catch (Exception)
        {
            await transaction.RollbackAsync();
            throw;
        }
    }

    public async Task<List<AppointmentListItem_Patient>> ListForPatientAsync(Pagination pagination)
    {
        var patientId = _userExtractor.GetUserId();
        return await _context.Appointments
            .AsNoTracking()
            .Include(apointment => apointment.Patient)
            .Include(appointment => appointment.Session)
            .Where(appointment => appointment.Patient.PatientId.Equals(patientId))
            .OrderBy(appointment => appointment.Session.SessionStart)
            .Skip(pagination.ResultsPerPage * (pagination.PageNumber) - 1)
            .Take(pagination.ResultsPerPage)
            .Select(appointment => appointment.ToListItem_Patient())
            .ToListAsync();
    }

    public async Task<AppointmentDetailView_Server?> DetailViewByServerAsync(string appointmentId)
    {
        return await _context.Appointments
            .AsNoTracking()
            .Include(appointment => appointment.Session)
            .ThenInclude(session => session.Doctor)
            .Include(appointment => appointment.Session)
            .ThenInclude(session => session.Room)
            .Include(appointment => appointment.Patient)
            .Where(appointment => appointment.AppointmentId.Equals(appointmentId))
            .Select(appointment => appointment.ToDetailView_Server())
            .FirstOrDefaultAsync();
    }

    public async Task<AppointmentDetaiView_Patient?> DetailViewForPatientAsync(string appointmentId)
    {
        return await _context.Appointments
            .AsNoTracking()
            .Include(appointment => appointment.Session)
            .ThenInclude(session => session.Doctor)
            .Include(appointment => appointment.Session)
            .ThenInclude(session => session.Doctor)
            .Where(appointment => appointment.AppointmentId.Equals(appointmentId))
            .Select(appointment => appointment.ToDetailView_Patient())
            .FirstOrDefaultAsync();
    }

    public async Task<List<AppointmentListItem_Server>> ListForServerAsync(Pagination pagination)
    {
        return await _context.Appointments
            .AsNoTracking()
            .Include(appointment => appointment.Patient)
            .Include(appointment => appointment.Session)
            .OrderBy(appointment => appointment.Session.SessionStart)
            .Skip(pagination.ResultsPerPage * (pagination.PageNumber - 1))
            .Take(pagination.ResultsPerPage)
            .Select(appointment => appointment.ToListItem_Server())
            .ToListAsync();
    }

    private Task<IDbContextTransaction> CreateTransactionAsync()
    {
        return _context.Database.BeginTransactionAsync(IsolationLevel.Serializable);
    }
}
