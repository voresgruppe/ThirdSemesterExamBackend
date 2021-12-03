using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using voresgruppe.ThirdSemesterExamBackend.Core.IServices;
using voresgruppe.ThirdSemesterExamBackend.Core.Models;
using voresgruppe.ThirdSemesterExamBackend.Domain.Services;

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
            return _appointmentService.GetById(id);
        }

        
        [HttpGet(nameof(GetByCustomer)+"{id}")]
        public ActionResult<List<Appointment>> GetByCustomer(int id)
        {
            return _appointmentService.GetByCustomerId(id);
        }

        [HttpDelete]
        public ActionResult<bool> DeleteById(int id)
        {
            return _appointmentService.DeleteAppointmentById(id);
        }

        [HttpPost]
        public ActionResult<Appointment> CreateAppointment([FromBody] Appointment app)
        {
            Appointment createdApp = _appointmentService.CreateAppointment(app);
            return Created($"https://localhost/api/products/{createdApp}", createdApp);
        }

        [HttpPut]
        public ActionResult<Appointment> UpdateAppointment(int id, Appointment appointment)
        {
            var app = new Appointment()
            {
                AppointmentTime = appointment.AppointmentTime,
                Customer = appointment.Customer
            };
            Appointment updateAppointment = _appointmentService.UpdateAppointment(id, app);
            return Created($"https://localhost/api/products/{updateAppointment}", updateAppointment);
        }
    }
}