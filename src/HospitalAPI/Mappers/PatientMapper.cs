﻿using HospitalAPI.Dtos;
using HospitalLibrary.Core.Model;
using System.Collections.Generic;

namespace HospitalAPI.Mappers
{
    public class PatientMapper : IGenericMapper<Patient, PatientDTO>
    {
        public Patient ToModel(PatientDTO patientDTO) {
            Patient patient = new Patient();
            patient.PatientId = patientDTO.PatientId;
            patient.Name = patientDTO.Name;
            patient.Surname = patientDTO.Surname;
            patient.Email = patientDTO.Email;
            patient.Password = patientDTO.Password;
            patient.IsAccountActivated = patientDTO.IsAccountActivated;

            return patient;
        }

        public List<Patient> ToModel(List<PatientDTO> patientDTOs) {
            List<Patient> patients = new List<Patient>();
            foreach (var patientDTO in patientDTOs) 
            {
                Patient patient = new Patient();
                patient.PatientId = patientDTO.PatientId;
                patient.Name = patientDTO.Name;
                patient.Surname = patientDTO.Surname;
                patient.Email = patientDTO.Email;
                patient.Password = patientDTO.Password;
                patient.IsAccountActivated = patientDTO.IsAccountActivated;
                patients.Add(patient);
            }

            return patients;
        }

        public PatientDTO ToDTO(Patient patient) {
            PatientDTO patientDTO = new PatientDTO();
            patientDTO.PatientId = patient.PatientId;
            patientDTO.Name = patient.Name;
            patientDTO.Surname = patient.Surname;
            patientDTO.Email = patient.Email;
            patientDTO.Password= patient.Password;
            patientDTO.IsAccountActivated = patient.IsAccountActivated;

            return patientDTO;
        }

        public List<PatientDTO> ToDTO(List<Patient> patients) {
            List<PatientDTO> patientDTOs = new List<PatientDTO>();
            foreach (var patient in patients) 
            {
                PatientDTO patientDTO = new PatientDTO();
                patientDTO.PatientId = patient.PatientId;
                patientDTO.Name = patient.Name;
                patientDTO.Surname = patient.Surname;
                patientDTO.Email = patient.Email;
                patientDTO.Password = patient.Password;
                patientDTO.IsAccountActivated = patient.IsAccountActivated;

                patientDTOs.Add(patientDTO);
            }

            return patientDTOs;
        }
    }
}
