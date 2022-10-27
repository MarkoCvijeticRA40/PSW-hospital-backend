﻿using HospitalLibrary.Core.Model;
using HospitalLibrary.Core.Repository;
using System;
using System.Collections.Generic;
using System.Linq;

namespace HospitalLibrary.Core.Service
{
    public class AppointmentService : IAppointmentService
    {
        private readonly IAppointmentRepository _appointmentRepository;
        private readonly IVacationRepository _vacationRepository;
        private readonly IWorkTimeRepository _workTimeRepository;

        public AppointmentService(IAppointmentRepository appointmentRepository, IVacationRepository vacationRepository, IWorkTimeRepository workTimeRepository)
        {
            _appointmentRepository = appointmentRepository;
            _vacationRepository = vacationRepository;
            _workTimeRepository = workTimeRepository;
        }
        public void Create(Appointment appointment)
        {
            if (IsAppointmentValid(appointment))
            {
                _appointmentRepository.Create(appointment);
            }
        }

        private bool IsAppointmentValid(Appointment appointment)
        {
            return IsAppointmentAvailable(appointment) && IsDoctorOnVacation(appointment) && IsDoctorAvailable(appointment);
        }

        public void Delete(Appointment appointment)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Appointment> GetAll()
        {
            return _appointmentRepository.GetAll();
        }

        public Appointment GetById(int id)
        {
            return _appointmentRepository.GetById(id);
        }

        public void Update(Appointment appointment)
        {
            throw new NotImplementedException();
        }


        public bool IsAppointmentAvailable(Appointment appointment)
        {
            bool isAvailable = true;
            foreach (var a in _appointmentRepository.GetAll().ToList())
            {
                if (a.DateTime == appointment.DateTime)
                {
                    isAvailable = false;
                    break;
                }
            }
            return isAvailable;
        }

        public bool IsDoctorOnVacation(Appointment appointment)
        {
            bool isAvailable = true;
            foreach (var vacation in _vacationRepository.GetAll().ToList())
            {
                if (appointment.DateTime >= vacation.StartDate && appointment.DateTime <= vacation.EndDate)
                {
                    isAvailable = false;
                    break;
                }
            }
            return isAvailable;
        }

        public bool IsDoctorAvailable(Appointment appointment)
        {
            bool isAvailable = false;
            foreach (var workTime in _workTimeRepository.GetAll().ToList())
            {
                if (IsDoctorWorking(appointment, workTime))
                {
                    isAvailable = true;
                    break;
                }
            }
            return isAvailable;
        }

        private static bool IsDoctorWorking(Appointment appointment, WorkTime workTime)
        {
            return appointment.DateTime >= workTime.StartDate && appointment.DateTime <= workTime.EndDate && appointment.DateTime.TimeOfDay >= workTime.StartTime && appointment.DateTime.TimeOfDay <= workTime.EndTime;
        }

        public List<Appointment> GetDoctorAppointments(int DoctorId)
        {
            List<Appointment> doctorAppointments = new List<Appointment>();
            List<Appointment> appointments = _appointmentRepository.GetAll().ToList();

            foreach (var appointment in appointments)
            {
                if (appointment.DoctorId == DoctorId)
                {
                    doctorAppointments.Add(appointment);
                }
            }
            return doctorAppointments;
        }
    }
}
