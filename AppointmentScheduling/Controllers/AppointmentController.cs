﻿using AppointmentScheduling.Services;
using AppointmentScheduling.Utility;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppointmentScheduling.Controllers
{
    [Authorize]
    public class AppointmentController : Controller
    {
        private readonly IAppointmentService _appointmentService;

        public AppointmentController(IAppointmentService appointmentService)
        {
            _appointmentService = appointmentService;
        }

        //[Authorize(Roles = Helper.Admin)] accessible for Admin only
        public IActionResult Index()
        {
            ViewBag.DoctorList = _appointmentService.GetDoctorList();
            ViewBag.PatientList = _appointmentService.GetPatientList();
            ViewBag.Duration = Helper.GetTimeDropDown();

            return View();
        }


    }
}
