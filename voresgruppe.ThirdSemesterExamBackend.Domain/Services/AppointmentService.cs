using System.Collections.Generic;
using System.IO;
using voresgruppe.ThirdSemesterExamBackend.Core.IServices;
using voresgruppe.ThirdSemesterExamBackend.Core.Models;
using voresgruppe.ThirdSemesterExamBackend.Domain.IRepositories;

namespace voresgruppe.ThirdSemesterExamBackend.Domain.Services
{
    public class AppointmentService : IAppointmentService
    {
        private readonly IAppointmentRepository _appointmentRepository;


        public AppointmentService(IAppointmentRepository appointmentRepository)
        {
            _appointmentRepository = appointmentRepository ?? throw new InvalidDataException("IAppointmentRepository in AppointmentService cannot be null");
        }

        public List<Appointment> GetAll()
        {
            return _appointmentRepository.FindAll();
        }

        public Appointment GetById(int id)
        {
            return _appointmentRepository.ReadById(id);
        }

        public List<Appointment> GetByCustomerId(int customerId)
        {
            return _appointmentRepository.FindByCustomerId(customerId);
        }

        public List<Appointment> GetByEmployeeId(int id)
        {
            return _appointmentRepository.FindByEmployeeId(id);
        }

        public bool DeleteAppointmentById(int id)
        {
            return _appointmentRepository.DeleteAppointmentById(id);
        }

        public Appointment CreateAppointment(Appointment app)
        {
            return _appointmentRepository.CreateAppointment(app);
        }

        public Appointment UpdateAppointment(int id, Appointment app)
        {
            return _appointmentRepository.UpdateAppointment(id, app);
        }

        public Customer GetCustomerById(int id)
        {
            return _appointmentRepository.GetCustomerById(id);
        }

        public Employee GetEmployeeById(int id)
        {
            return _appointmentRepository.GetEmployeeById(id);
        }
    }
}