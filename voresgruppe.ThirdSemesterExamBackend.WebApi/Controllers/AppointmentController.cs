using System.Collections.Generic;
using System.IO;
using Microsoft.AspNetCore.Mvc;
using voresgruppe.ThirdSemesterExamBackend.Core.IServices;
using voresgruppe.ThirdSemesterExamBackend.Core.Models;

namespace voresgruppe.ThirdSemesterExamBackend.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppointmentController : ControllerBase
    {
        private readonly IAppointmentService _appointmentService;

        public AppointmentController(IAppointmentService appointmentService)
        {
            _appointmentService = appointmentService ??
                                  throw new InvalidDataException("AppointmentController needs IAppointmentService");
        }

        [HttpGet]
        public ActionResult<List<Appointment>> GetAll()
        {
            return _appointmentService.GetAll();
        }

        [HttpGet("{id}")]
        public ActionResult<Appointment> GetById(int id)
        {
            return Ok(_appointmentService.GetById(id));
        }

        
        [HttpGet(nameof(GetByCustomer)+"{id}")]
        public ActionResult<List<Appointment>> GetByCustomer(int id)
        {
            return _appointmentService.GetByCustomerId(id);
        }
        
        [HttpGet(nameof(GetByEmployee)+"{id}")]
        public ActionResult<List<Appointment>> GetByEmployee(int id)
        {
            return _appointmentService.GetByEmployeeId(id);
        }

        [HttpDelete]
        public ActionResult<bool> DeleteById(int id)
        {
            return _appointmentService.DeleteAppointmentById(id);
        }

        [HttpPost(nameof(CreateAppointment))]
        public ActionResult<Appointment> CreateAppointment(Appointment app)
        {
            Appointment createdApp = _appointmentService.CreateAppointment(app);
            return createdApp;
        }

        [HttpPut]
        public ActionResult<Appointment> UpdateAppointment(int id, Appointment appointment)
        {
            var app = new Appointment()
            {
                AppointmentTime = appointment.AppointmentTime,
                CustomerId = appointment.Id,
                EmployeeId = appointment.EmployeeId,
            };
            Appointment updateAppointment = _appointmentService.UpdateAppointment(id, app);
            return Created($"https://localhost/api/products/{updateAppointment}", updateAppointment);
        }
    }
}