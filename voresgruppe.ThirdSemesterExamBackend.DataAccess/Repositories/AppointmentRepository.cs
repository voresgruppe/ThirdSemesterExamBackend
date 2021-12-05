﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using voresgruppe.ThirdSemesterExamBackend.Core.Models;
using voresgruppe.ThirdSemesterExamBackend.DataAccess.Entities;
using voresgruppe.ThirdSemesterExamBackend.DataAccess.Entities.EntityUtils;
using voresgruppe.ThirdSemesterExamBackend.Domain.IRepositories;

namespace voresgruppe.ThirdSemesterExamBackend.DataAccess.Repositories
{
    public class AppointmentRepository : IAppointmentRepository
    {
        private MainDbContext _ctx;
        private AppointmentEntityUtils _appointmentEntityUtils;
        private CustomerEntityUtils _customerEntityUtils = new CustomerEntityUtils();
        private EmployeeEntityUtils _employeeEntityUtils = new EmployeeEntityUtils();

        public AppointmentRepository(MainDbContext ctx)
        {
            _ctx = ctx ?? throw new InvalidDataException("AppointmentRepository need a DBcontext");
            _appointmentEntityUtils = new AppointmentEntityUtils(_ctx);
        }

        public List<Appointment> FindAll()
        {
            return _ctx.Appointment
                .Select(ae => _appointmentEntityUtils.EntityToAppointment(ae))
                .ToList();
        }

        public Appointment ReadById(int id)
        {
            return _appointmentEntityUtils.EntityToAppointment(_ctx.Appointment.Find(id));
        }

        public List<Appointment> FindByCustomerId(int customerId)
        {
            return _ctx.Appointment
                .Where(ae => ae.CustomerId.Equals(customerId))
                .Select(ae=> _appointmentEntityUtils.EntityToAppointment(ae))
                .ToList();
        }
        
        public List<Appointment> FindByEmployeeId(int id)
        {
            return _ctx.Appointment
                .Where(ae => ae.EmployeeId.Equals(id))
                .Select(ae=> _appointmentEntityUtils.EntityToAppointment(ae))
                .ToList();
        }

        public bool DeleteAppointmentById(int id)
        {
            var app = _ctx.Appointment.Find(id);
            _ctx.Appointment.Remove(app);
            _ctx.SaveChanges();
            return true;
        }

        public Appointment CreateAppointment(Appointment app)
        {
            var ae = _ctx.Appointment.Add(new AppointmentEntity()
            {
                AppointmentTime = DateTime.Parse(app.AppointmentTime),
                CustomerId = app.Customer.Id,
                EmployeeId = app.Employee.Id
            }).Entity;
            Appointment appointment = _appointmentEntityUtils.EntityToAppointment(ae);
            /*var  c = _customerEntityUtils.EntityToCustomer(_ctx.Customer.Find(app.CustomerId));
            appointment.Employee = _employeeEntityUtils.EntityToAdmin(_ctx.Employee.Find(app.EmployeeId));*/
            _ctx.SaveChanges();
            
            return appointment;
        }

        public Appointment UpdateAppointment(int id, Appointment app)
        {
            AppointmentEntity ae = _ctx.Appointment.Find(id);
            ae.AppointmentTime = DateTime.Parse(app.AppointmentTime);
            ae.CustomerId = app.Customer.Id;
            AppointmentEntity returnEntity = _ctx.Appointment.Update(ae).Entity;
            _ctx.SaveChanges();
            return _appointmentEntityUtils.EntityToAppointment(returnEntity);
        }

        public Customer GetCustomerById(int id)
        {
            return _customerEntityUtils.EntityToCustomer(_ctx.Customer.Find(id));
        }

        public Employee GetEmployeeById(int id)
        {
            return _employeeEntityUtils.EntityToAdmin(_ctx.Employee.Find(id));
        }
    }
}