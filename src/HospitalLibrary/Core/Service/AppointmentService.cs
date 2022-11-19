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

        public AppointmentService(IAppointmentRepository appointmentRepository)
        {
            _appointmentRepository = appointmentRepository;
        }

        public AppointmentService(IAppointmentRepository appointmentRepository, IVacationRepository vacationRepository,IWorkTimeRepository workTimeRepository)
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

        public void Update(Appointment appointment)
        {
            if (IsAppointmentValid(appointment))
            {
                _appointmentRepository.Update(appointment);
            }
        }

        private bool IsAppointmentValid(Appointment appointment)
        {
            return IsAppointmentAvailable(appointment) && IsDoctorOnVacation(appointment) && IsDoctorAvailable(appointment) && !IsWeekend(appointment.Start);
        }

        public void Delete(Appointment appointment)
        {
            _appointmentRepository.Delete(appointment);
        }

        public IEnumerable<Appointment> GetAll()
        {
            return _appointmentRepository.GetAll();
        }

        public Appointment GetById(int id)
        {
            return _appointmentRepository.GetById(id);
        }

        private bool IsAppointmentAvailable(Appointment appointment)
        {
            bool isAvailable = true;
            foreach (var a in _appointmentRepository.GetAll().ToList())
            {
                if (a.Start == appointment.Start)
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
                if (appointment.Start >= vacation.StartDate && appointment.Start <= vacation.EndDate)
                {
                    isAvailable = false;
                    break;
                }
            }
            return isAvailable;
        }

        private bool IsDoctorAvailable(Appointment appointment)
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
            return appointment.Start >= workTime.StartDate && appointment.Start <= workTime.EndDate && appointment.Start.TimeOfDay >= workTime.StartTime && appointment.Start.TimeOfDay <= workTime.EndTime;
        }

        private static bool IsWeekend(DateTime date)
        {
            return date.DayOfWeek.Equals(DayOfWeek.Saturday) || date.DayOfWeek.Equals(DayOfWeek.Sunday);
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
        //Start functions in user story Create VacationRequest
        public List<Appointment> GetAppointmentInVacationDateRange(int? doctorId, DateTime startDate, DateTime endDate)
        {
            List<Appointment> doctorAppointments = GetDoctorAppointments((int)doctorId);
            List<Appointment> doctorAppointmentsInVacationDate = new List<Appointment>();

            foreach (Appointment appointment in doctorAppointments)
            {
                if (appointment.Start > startDate && appointment.Start < endDate)
                {
                    doctorAppointmentsInVacationDate.Add(appointment);
                }
            }
            return doctorAppointmentsInVacationDate;
        }

        public bool IsDoctorScheduled(Appointment appointment, int doctorId)
        {
            List<Appointment> appointments = _appointmentRepository.GetAll().ToList();

            foreach (Appointment app in appointments)
            {
                if (app.Start == appointment.Start && app.DoctorId != doctorId)
                {
                    return true;
                }
            }
            return false;
        }

        public void MakeTransfer(Appointment appointment,int doctorId)
        {
            appointment.DoctorId = doctorId;
            _appointmentRepository.Update(appointment);
        }
        
        public bool ChangeAppointmentDoctor(List<Appointment> appointmentsInVacationDate)
        {
            List<Doctor> doctors = new List<Doctor>(); //treba da budu svi dobavljeni
            List<Appointment> transeferedAppointments = new List<Appointment>();
            List<Appointment> appointmentsForFunction = appointmentsInVacationDate;

            foreach(Doctor doctor in doctors)
            {
                foreach(Appointment appointment in appointmentsInVacationDate)
                {
                    
                    if(IsDoctorScheduled(appointment,doctor.DoctorId) == true)
                    {
                        transeferedAppointments.Add(appointment);
                        appointmentsForFunction.Remove(appointment);
                    }
                    if (appointmentsInVacationDate.Count == 0)
                    {
                        foreach (Appointment appointment1 in transeferedAppointments)
                        {
                            MakeTransfer(appointment1, doctor.DoctorId);
                        }
                        return true;
                    }
                    else
                    {
                        appointmentsForFunction = appointmentsInVacationDate;
                    }
                }
            }
            return false;
        }
    }
}

