﻿using System;
using System.Collections.Generic;
using HospitalLibrary.Core.Model;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace HospitalLibrary.Migrations
{
    public partial class AddPhysicianScheduleTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Allergens",
                columns: table => new
                {
                    AllergenId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Allergens", x => x.AllergenId);
                });

            migrationBuilder.CreateTable(
                name: "BloodRequests",
                columns: table => new
                {
                    BloodRequestId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    BloodType = table.Column<int>(type: "integer", nullable: false),
                    QuantityInLiters = table.Column<double>(type: "double precision", nullable: false),
                    ReasonForRequest = table.Column<string>(type: "text", nullable: true),
                    FinalDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    DoctorId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BloodRequests", x => x.BloodRequestId);
                });

            migrationBuilder.CreateTable(
                name: "Bloods",
                columns: table => new
                {
                    BloodId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    BloodType = table.Column<int>(type: "integer", nullable: false),
                    QuantityInLiters = table.Column<double>(type: "double precision", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bloods", x => x.BloodId);
                });

            migrationBuilder.CreateTable(
                name: "BloodUsageEvidencies",
                columns: table => new
                {
                    BloodUsageEvidencyId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    BloodType = table.Column<int>(type: "integer", nullable: false),
                    QuantityUsedInMililiters = table.Column<double>(type: "double precision", nullable: false),
                    ReasonForUsage = table.Column<string>(type: "text", nullable: true),
                    DateOfUsage = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    DoctorId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BloodUsageEvidencies", x => x.BloodUsageEvidencyId);
                });

            migrationBuilder.CreateTable(
                name: "Equipment",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    RoomId = table.Column<int>(type: "integer", nullable: false),
                    EquipmentType = table.Column<int>(type: "integer", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: true),
                    Quantity = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Equipment", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Feedbacks",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Privatisation = table.Column<bool>(type: "boolean", nullable: false),
                    Textt = table.Column<string>(type: "text", nullable: true),
                    User = table.Column<string>(type: "text", nullable: true),
                    Date = table.Column<string>(type: "text", nullable: true),
                    IsDisplayedPublic = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Feedbacks", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MedicalRecords",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    BloodType = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MedicalRecords", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Medicines",
                columns: table => new
                {
                    MedicineId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: true),
                    Manufacturer = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Medicines", x => x.MedicineId);
                });

            migrationBuilder.CreateTable(
                name: "Notifications",
                columns: table => new
                {
                    NotificationId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    PatientId = table.Column<int>(type: "integer", nullable: false),
                    DoctorId = table.Column<int>(type: "integer", nullable: false),
                    Message = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Notifications", x => x.NotificationId);
                });

            migrationBuilder.CreateTable(
                name: "Patients",
                columns: table => new
                {
                    PatientId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Surname = table.Column<string>(type: "text", nullable: false),
                    Email = table.Column<string>(type: "text", nullable: false),
                    Password = table.Column<string>(type: "text", nullable: false),
                    IsAccountActivated = table.Column<bool>(type: "boolean", nullable: false),
                    MedicalRecord = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Patients", x => x.PatientId);
                });

            migrationBuilder.CreateTable(
                name: "Rooms",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Number = table.Column<string>(type: "text", nullable: false),
                    FloorId = table.Column<int>(type: "integer", nullable: false),
                    BuildingId = table.Column<string>(type: "text", nullable: true),
                    Description = table.Column<string>(type: "text", nullable: true),
                    Type = table.Column<int>(type: "integer", nullable: false),
                    X = table.Column<int>(type: "integer", nullable: false),
                    Y = table.Column<int>(type: "integer", nullable: false),
                    Width = table.Column<int>(type: "integer", nullable: false),
                    Height = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rooms", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Specializations",
                columns: table => new
                {
                    SpecializationId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Specializations", x => x.SpecializationId);
                });

            migrationBuilder.CreateTable(
                name: "Symptoms",
                columns: table => new
                {
                    SymptomId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Symptoms", x => x.SymptomId);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Username = table.Column<string>(type: "text", nullable: false),
                    Password = table.Column<string>(type: "text", nullable: false),
                    Role = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserId);
                });

            migrationBuilder.CreateTable(
                name: "VacationRequests",
                columns: table => new
                {
                    VacationRequestId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    StartDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    EndDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    DoctorId = table.Column<int>(type: "integer", nullable: false),
                    Status = table.Column<int>(type: "integer", nullable: false),
                    Urgency = table.Column<string>(type: "text", nullable: true),
                    Reason = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VacationRequests", x => x.VacationRequestId);
                });

            migrationBuilder.CreateTable(
                name: "AllergenMedicalRecord",
                columns: table => new
                {
                    AllergensAllergenId = table.Column<int>(type: "integer", nullable: false),
                    MedicalRecordsId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AllergenMedicalRecord", x => new { x.AllergensAllergenId, x.MedicalRecordsId });
                    table.ForeignKey(
                        name: "FK_AllergenMedicalRecord_Allergens_AllergensAllergenId",
                        column: x => x.AllergensAllergenId,
                        principalTable: "Allergens",
                        principalColumn: "AllergenId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AllergenMedicalRecord_MedicalRecords_MedicalRecordsId",
                        column: x => x.MedicalRecordsId,
                        principalTable: "MedicalRecords",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Beds",
                columns: table => new
                {
                    BedId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Label = table.Column<string>(type: "text", nullable: true),
                    IsAvailable = table.Column<bool>(type: "boolean", nullable: false),
                    RoomId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Beds", x => x.BedId);
                    table.ForeignKey(
                        name: "FK_Beds_Rooms_RoomId",
                        column: x => x.RoomId,
                        principalTable: "Rooms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Doctors",
                columns: table => new
                {
                    DoctorId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Surname = table.Column<string>(type: "text", nullable: false),
                    SpecializationId = table.Column<int>(type: "integer", nullable: false),
                    RoomId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Doctors", x => x.DoctorId);
                    table.ForeignKey(
                        name: "FK_Doctors_Rooms_RoomId",
                        column: x => x.RoomId,
                        principalTable: "Rooms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Doctors_Specializations_SpecializationId",
                        column: x => x.SpecializationId,
                        principalTable: "Specializations",
                        principalColumn: "SpecializationId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "InpatientTreatments",
                columns: table => new
                {
                    InpatientTreatmentId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    PatientId = table.Column<int>(type: "integer", nullable: false),
                    ReasonForAdmission = table.Column<string>(type: "text", nullable: true),
                    RoomId = table.Column<int>(type: "integer", nullable: false),
                    BedId = table.Column<int>(type: "integer", nullable: false),
                    DateOfAdmission = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InpatientTreatments", x => x.InpatientTreatmentId);
                    table.ForeignKey(
                        name: "FK_InpatientTreatments_Beds_BedId",
                        column: x => x.BedId,
                        principalTable: "Beds",
                        principalColumn: "BedId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_InpatientTreatments_Patients_PatientId",
                        column: x => x.PatientId,
                        principalTable: "Patients",
                        principalColumn: "PatientId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_InpatientTreatments_Rooms_RoomId",
                        column: x => x.RoomId,
                        principalTable: "Rooms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DoctorPatient",
                columns: table => new
                {
                    DoctorsDoctorId = table.Column<int>(type: "integer", nullable: false),
                    PatientsPatientId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DoctorPatient", x => new { x.DoctorsDoctorId, x.PatientsPatientId });
                    table.ForeignKey(
                        name: "FK_DoctorPatient_Doctors_DoctorsDoctorId",
                        column: x => x.DoctorsDoctorId,
                        principalTable: "Doctors",
                        principalColumn: "DoctorId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DoctorPatient_Patients_PatientsPatientId",
                        column: x => x.PatientsPatientId,
                        principalTable: "Patients",
                        principalColumn: "PatientId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PhysicianSchedules",
                columns: table => new
                {
                    PhysicianScheduleId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    DoctorId = table.Column<int>(type: "integer", nullable: false),
                    WorkTimes = table.Column<List<WorkTime>>(type: "jsonb", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PhysicianSchedules", x => x.PhysicianScheduleId);
                    table.ForeignKey(
                        name: "FK_PhysicianSchedules_Doctors_DoctorId",
                        column: x => x.DoctorId,
                        principalTable: "Doctors",
                        principalColumn: "DoctorId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "InpatientTreatmentTherapies",
                columns: table => new
                {
                    InpatientTreatmentTherapyId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    InpatientTreatmentId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InpatientTreatmentTherapies", x => x.InpatientTreatmentTherapyId);
                    table.ForeignKey(
                        name: "FK_InpatientTreatmentTherapies_InpatientTreatments_InpatientTr~",
                        column: x => x.InpatientTreatmentId,
                        principalTable: "InpatientTreatments",
                        principalColumn: "InpatientTreatmentId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Appointments",
                columns: table => new
                {
                    AppointmentId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Start = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    PatientId = table.Column<int>(type: "integer", nullable: true),
                    PhysicianScheduleId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Appointments", x => x.AppointmentId);
                    table.ForeignKey(
                        name: "FK_Appointments_Patients_PatientId",
                        column: x => x.PatientId,
                        principalTable: "Patients",
                        principalColumn: "PatientId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Appointments_PhysicianSchedules_PhysicianScheduleId",
                        column: x => x.PhysicianScheduleId,
                        principalTable: "PhysicianSchedules",
                        principalColumn: "PhysicianScheduleId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Vacations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    StartDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    EndDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    PhysicianScheduleId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vacations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Vacations_PhysicianSchedules_PhysicianScheduleId",
                        column: x => x.PhysicianScheduleId,
                        principalTable: "PhysicianSchedules",
                        principalColumn: "PhysicianScheduleId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "BloodTherapies",
                columns: table => new
                {
                    BloodTherapyId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    BloodType = table.Column<int>(type: "integer", nullable: false),
                    QuantityInLiters = table.Column<double>(type: "double precision", nullable: false),
                    Start = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    End = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    InpatientTreatmentTherapyId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BloodTherapies", x => x.BloodTherapyId);
                    table.ForeignKey(
                        name: "FK_BloodTherapies_InpatientTreatmentTherapies_InpatientTreatme~",
                        column: x => x.InpatientTreatmentTherapyId,
                        principalTable: "InpatientTreatmentTherapies",
                        principalColumn: "InpatientTreatmentTherapyId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "MedicineTherapies",
                columns: table => new
                {
                    MedicineTherapyId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    MedicineId = table.Column<int>(type: "integer", nullable: false),
                    Dosage = table.Column<string>(type: "text", nullable: true),
                    Start = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    End = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    InpatientTreatmentTherapyId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MedicineTherapies", x => x.MedicineTherapyId);
                    table.ForeignKey(
                        name: "FK_MedicineTherapies_InpatientTreatmentTherapies_InpatientTrea~",
                        column: x => x.InpatientTreatmentTherapyId,
                        principalTable: "InpatientTreatmentTherapies",
                        principalColumn: "InpatientTreatmentTherapyId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_MedicineTherapies_Medicines_MedicineId",
                        column: x => x.MedicineId,
                        principalTable: "Medicines",
                        principalColumn: "MedicineId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Allergens",
                columns: new[] { "AllergenId", "Name" },
                values: new object[,]
                {
                    { 1, "Peanuts" },
                    { 2, "Dust" },
                    { 3, "Fungal spores" },
                    { 4, "Insect and mite feces" },
                    { 5, "Insect bites and stinges (their venom)" },
                    { 6, "Pollen" },
                    { 7, "Milk and/or dairy products" },
                    { 8, "Eggs" },
                    { 9, "Wheat" }
                });

            migrationBuilder.InsertData(
                table: "Beds",
                columns: new[] { "BedId", "IsAvailable", "Label", "RoomId" },
                values: new object[,]
                {
                    { 1, false, "201B1", null },
                    { 2, true, "201B2", null },
                    { 3, true, "201B3", null }
                });

            migrationBuilder.InsertData(
                table: "BloodRequests",
                columns: new[] { "BloodRequestId", "BloodType", "DoctorId", "FinalDate", "QuantityInLiters", "ReasonForRequest" },
                values: new object[,]
                {
                    { 3, 7, 1, new DateTime(2022, 12, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), 3.5, "Heart surgery" },
                    { 2, 0, 1, new DateTime(2022, 11, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), 3.0, "Heart surgery" },
                    { 1, 5, 1, new DateTime(2022, 12, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), 2.5, "Heart surgery" }
                });

            migrationBuilder.InsertData(
                table: "BloodUsageEvidencies",
                columns: new[] { "BloodUsageEvidencyId", "BloodType", "DateOfUsage", "DoctorId", "QuantityUsedInMililiters", "ReasonForUsage" },
                values: new object[,]
                {
                    { 6, 5, new DateTime(2022, 12, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 1100.0, "Hearth surgery" },
                    { 5, 3, new DateTime(2022, 5, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 180.0, "Hearth surgery" },
                    { 4, 0, new DateTime(2022, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 700.0, "Hearth surgery" },
                    { 3, 6, new DateTime(2022, 11, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 450.0, "Hearth surgery" },
                    { 2, 3, new DateTime(2022, 11, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 300.0, "Hearth surgery" },
                    { 1, 0, new DateTime(2022, 12, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 200.0, "Hearth surgery" }
                });

            migrationBuilder.InsertData(
                table: "Bloods",
                columns: new[] { "BloodId", "BloodType", "QuantityInLiters" },
                values: new object[,]
                {
                    { 3, 2, 4.0 },
                    { 4, 4, 4.0 },
                    { 2, 0, 4.0 },
                    { 8, 5, 4.0 },
                    { 7, 3, 4.0 },
                    { 6, 1, 4.0 },
                    { 5, 7, 4.0 },
                    { 1, 6, 4.0 }
                });

            migrationBuilder.InsertData(
                table: "Equipment",
                columns: new[] { "Id", "EquipmentType", "Name", "Quantity", "RoomId" },
                values: new object[,]
                {
                    { 7, 1, "Defibrillator", 2, 3 },
                    { 6, 1, "Scalpel", 4, 3 },
                    { 5, 1, "Wheelchairs", 2, 2 },
                    { 10, 1, "Tounge depressor", 12, 5 },
                    { 4, 1, "Scissors", 10, 2 },
                    { 1, 1, "Syringe", 50, 1 },
                    { 2, 1, "Tounge depressor", 32, 1 },
                    { 8, 1, "Ultrasound ", 1, 4 },
                    { 3, 1, "Gloves", 50, 2 },
                    { 9, 1, "CT scanner", 2, 4 }
                });

            migrationBuilder.InsertData(
                table: "Feedbacks",
                columns: new[] { "Id", "Date", "IsDisplayedPublic", "Privatisation", "Textt", "User" },
                values: new object[,]
                {
                    { 3, "25.10.2022", false, false, "Awful.", "Огњен" },
                    { 2, "25.10.2022", false, false, "It's okay... I guess.", "Немања" },
                    { 1, "25.10.2022", false, false, "Awesome clinic!", "Милош" }
                });

            migrationBuilder.InsertData(
                table: "MedicalRecords",
                columns: new[] { "Id", "BloodType" },
                values: new object[,]
                {
                    { 9, 3 },
                    { 4, 2 },
                    { 1, 0 },
                    { 2, 6 },
                    { 3, 5 },
                    { 5, 7 },
                    { 6, 1 },
                    { 7, 4 },
                    { 8, 7 }
                });

            migrationBuilder.InsertData(
                table: "Medicines",
                columns: new[] { "MedicineId", "Manufacturer", "Name" },
                values: new object[,]
                {
                    { 3, "Hemofarm", "Caffetin" },
                    { 2, "Hemofarm", "Bromazepam" },
                    { 1, "Galenika", "Aspirin" }
                });

            migrationBuilder.InsertData(
                table: "Patients",
                columns: new[] { "PatientId", "Email", "IsAccountActivated", "MedicalRecord", "Name", "Password", "Surname" },
                values: new object[,]
                {
                    { 2, "proba1@gmail.com", false, 2, "Marko", "123", "Markovic" },
                    { 3, "proba2@gmail.com", false, 3, "Aleksa", "123", "Aleksic" },
                    { 1, "proba@gmail.com", false, 1, "Pera", "123", "Peric" },
                    { 9, "proba8@gmail.com", false, 9, "Aleksa", "123", "Aleksic" },
                    { 8, "proba7@gmail.com", false, 8, "Marko", "123", "Markovic" },
                    { 7, "proba6@gmail.com", false, 7, "Pera", "123", "Peric" },
                    { 6, "proba5@gmail.com", false, 6, "Aleksa", "123", "Aleksic" },
                    { 5, "proba4@gmail.com", false, 5, "Marko", "123", "Markovic" },
                    { 4, "proba3@gmail.com", false, 4, "Pera", "123", "Peric" }
                });

            migrationBuilder.InsertData(
                table: "Rooms",
                columns: new[] { "Id", "BuildingId", "Description", "FloorId", "Height", "Number", "Type", "Width", "X", "Y" },
                values: new object[,]
                {
                    { 29, "B", "neki opis2", 1, 250, "206B", 0, 283, 358, 530 },
                    { 30, "B", "neki opis1", 1, 250, "207B", 0, 282, 706, 270 },
                    { 31, "B", "neki opis2", 1, 250, "208B", 0, 282, 706, 530 },
                    { 32, "B", "neki opis", 2, 250, "301B", 0, 485, 10, 10 },
                    { 33, "B", "neki opis1", 2, 250, "302B", 0, 480, 505, 10 },
                    { 37, "B", "neki opis2", 2, 250, "306B", 0, 283, 358, 530 },
                    { 35, "B", "neki opis", 2, 250, "304B", 0, 283, 10, 530 },
                    { 36, "B", "neki opis1", 2, 250, "305B", 0, 283, 358, 270 },
                    { 28, "B", "neki opis1", 1, 250, "205B", 0, 283, 358, 270 },
                    { 38, "B", "neki opis1", 2, 250, "307B", 0, 282, 706, 270 },
                    { 39, "B", "neki opis2", 2, 250, "308B", 0, 282, 706, 530 },
                    { 34, "B", "neki opis2", 2, 250, "303B", 0, 283, 10, 270 },
                    { 27, "B", "neki opis", 1, 250, "204B", 0, 283, 10, 530 },
                    { 6, "A", "neki opis3", 1, 250, "201A", 0, 380, 10, 10 },
                    { 25, "B", "neki opis1", 1, 250, "202B", 0, 480, 505, 10 },
                    { 9, "A", "neki opis4", 1, 250, "204A", 0, 170, 220, 270 },
                    { 10, "A", "neki opis5", 1, 250, "205A", 0, 170, 220, 530 },
                    { 11, "A", "neki opis6", 2, 250, "301A", 0, 380, 10, 10 },
                    { 12, "A", "neki opis7", 2, 250, "302A", 0, 170, 10, 270 },
                    { 13, "A", "neki opis8", 2, 250, "303A", 0, 170, 10, 530 },
                    { 5, "A", "neki opis1", 0, 250, "105A", 0, 170, 220, 530 },
                    { 4, "A", "neki opis", 0, 250, "104A", 0, 170, 220, 270 },
                    { 3, "A", "neki opis2", 0, 250, "103A", 0, 170, 10, 530 },
                    { 26, "B", "neki opis2", 1, 250, "203B", 0, 283, 10, 270 },
                    { 2, "A", "neki opis1", 0, 250, "102A", 0, 170, 10, 270 },
                    { 1, "A", "neki opis", 0, 250, "101A", 0, 380, 10, 10 },
                    { 8, "A", "neki opis5", 1, 250, "203A", 0, 170, 10, 530 },
                    { 7, "A", "neki opis4", 1, 250, "202A", 0, 170, 10, 270 },
                    { 14, "A", "neki opis7", 2, 250, "304A", 0, 170, 220, 270 },
                    { 15, "A", "neki opis8", 2, 250, "305A", 0, 170, 220, 530 },
                    { 16, "B", "neki opis", 0, 250, "101B", 0, 485, 10, 10 },
                    { 17, "B", "neki opis1", 0, 250, "102B", 0, 480, 505, 10 },
                    { 18, "B", "neki opis2", 0, 250, "103B", 0, 283, 10, 270 },
                    { 19, "B", "neki opis", 0, 250, "104B", 0, 283, 10, 530 },
                    { 20, "B", "neki opis1", 0, 250, "105B", 0, 283, 358, 270 },
                    { 21, "B", "neki opis2", 0, 250, "106B", 0, 283, 358, 530 },
                    { 22, "B", "neki opis1", 0, 250, "107B", 0, 282, 706, 270 },
                    { 23, "B", "neki opis2", 0, 250, "108B", 0, 282, 706, 530 },
                    { 24, "B", "neki opis", 1, 250, "201B", 0, 485, 10, 10 }
                });

            migrationBuilder.InsertData(
                table: "Specializations",
                columns: new[] { "SpecializationId", "Name" },
                values: new object[,]
                {
                    { 3, "Family medicine" },
                    { 1, "Anesthesiology" },
                    { 2, "Dermatology" }
                });

            migrationBuilder.InsertData(
                table: "Symptoms",
                columns: new[] { "SymptomId", "Name" },
                values: new object[,]
                {
                    { 3, "Elevated body temperature" },
                    { 2, "Sore throat" },
                    { 1, "High blood presure" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserId", "Password", "Role", "Username" },
                values: new object[] { 1, "password", 0, "username" });

            migrationBuilder.InsertData(
                table: "VacationRequests",
                columns: new[] { "VacationRequestId", "DoctorId", "EndDate", "Reason", "StartDate", "Status", "Urgency" },
                values: new object[,]
                {
                    { 2, 4, new DateTime(2022, 12, 22, 12, 49, 16, 847, DateTimeKind.Local).AddTicks(6733), "Tired", new DateTime(2022, 12, 17, 12, 49, 16, 847, DateTimeKind.Local).AddTicks(6710), 2, "Urgent" },
                    { 1, 4, new DateTime(2022, 12, 17, 12, 49, 16, 847, DateTimeKind.Local).AddTicks(4189), "Tired", new DateTime(2022, 12, 12, 12, 49, 16, 841, DateTimeKind.Local).AddTicks(1098), 1, "NoUrgent" },
                    { 3, 4, new DateTime(2022, 12, 27, 12, 49, 16, 847, DateTimeKind.Local).AddTicks(6744), "Tired", new DateTime(2022, 12, 22, 12, 49, 16, 847, DateTimeKind.Local).AddTicks(6739), 0, "NoUrgent" }
                });

            migrationBuilder.InsertData(
                table: "Doctors",
                columns: new[] { "DoctorId", "Name", "RoomId", "SpecializationId", "Surname" },
                values: new object[,]
                {
                    { 2, "Mika", 2, 1, "Mikic" },
                    { 3, "Aleksa", 1, 2, "Santic" },
                    { 1, "Ognjen", 1, 3, "Nikolic" },
                    { 4, "Nikola", 1, 3, "Peric" }
                });

            migrationBuilder.InsertData(
                table: "InpatientTreatments",
                columns: new[] { "InpatientTreatmentId", "BedId", "DateOfAdmission", "PatientId", "ReasonForAdmission", "RoomId" },
                values: new object[] { 1, 1, new DateTime(2022, 11, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Headache", 21 });

            migrationBuilder.InsertData(
                table: "InpatientTreatmentTherapies",
                columns: new[] { "InpatientTreatmentTherapyId", "InpatientTreatmentId" },
                values: new object[] { 1, 1 });

            migrationBuilder.CreateIndex(
                name: "IX_AllergenMedicalRecord_MedicalRecordsId",
                table: "AllergenMedicalRecord",
                column: "MedicalRecordsId");

            migrationBuilder.CreateIndex(
                name: "IX_Appointments_PatientId",
                table: "Appointments",
                column: "PatientId");

            migrationBuilder.CreateIndex(
                name: "IX_Appointments_PhysicianScheduleId",
                table: "Appointments",
                column: "PhysicianScheduleId");

            migrationBuilder.CreateIndex(
                name: "IX_Beds_RoomId",
                table: "Beds",
                column: "RoomId");

            migrationBuilder.CreateIndex(
                name: "IX_BloodTherapies_InpatientTreatmentTherapyId",
                table: "BloodTherapies",
                column: "InpatientTreatmentTherapyId");

            migrationBuilder.CreateIndex(
                name: "IX_DoctorPatient_PatientsPatientId",
                table: "DoctorPatient",
                column: "PatientsPatientId");

            migrationBuilder.CreateIndex(
                name: "IX_Doctors_RoomId",
                table: "Doctors",
                column: "RoomId");

            migrationBuilder.CreateIndex(
                name: "IX_Doctors_SpecializationId",
                table: "Doctors",
                column: "SpecializationId");

            migrationBuilder.CreateIndex(
                name: "IX_InpatientTreatments_BedId",
                table: "InpatientTreatments",
                column: "BedId");

            migrationBuilder.CreateIndex(
                name: "IX_InpatientTreatments_PatientId",
                table: "InpatientTreatments",
                column: "PatientId");

            migrationBuilder.CreateIndex(
                name: "IX_InpatientTreatments_RoomId",
                table: "InpatientTreatments",
                column: "RoomId");

            migrationBuilder.CreateIndex(
                name: "IX_InpatientTreatmentTherapies_InpatientTreatmentId",
                table: "InpatientTreatmentTherapies",
                column: "InpatientTreatmentId");

            migrationBuilder.CreateIndex(
                name: "IX_MedicineTherapies_InpatientTreatmentTherapyId",
                table: "MedicineTherapies",
                column: "InpatientTreatmentTherapyId");

            migrationBuilder.CreateIndex(
                name: "IX_MedicineTherapies_MedicineId",
                table: "MedicineTherapies",
                column: "MedicineId");

            migrationBuilder.CreateIndex(
                name: "IX_Patients_Email",
                table: "Patients",
                column: "Email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_PhysicianSchedules_DoctorId",
                table: "PhysicianSchedules",
                column: "DoctorId");

            migrationBuilder.CreateIndex(
                name: "IX_Vacations_PhysicianScheduleId",
                table: "Vacations",
                column: "PhysicianScheduleId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AllergenMedicalRecord");

            migrationBuilder.DropTable(
                name: "Appointments");

            migrationBuilder.DropTable(
                name: "BloodRequests");

            migrationBuilder.DropTable(
                name: "Bloods");

            migrationBuilder.DropTable(
                name: "BloodTherapies");

            migrationBuilder.DropTable(
                name: "BloodUsageEvidencies");

            migrationBuilder.DropTable(
                name: "DoctorPatient");

            migrationBuilder.DropTable(
                name: "Equipment");

            migrationBuilder.DropTable(
                name: "Feedbacks");

            migrationBuilder.DropTable(
                name: "MedicineTherapies");

            migrationBuilder.DropTable(
                name: "Notifications");

            migrationBuilder.DropTable(
                name: "Symptoms");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "VacationRequests");

            migrationBuilder.DropTable(
                name: "Vacations");

            migrationBuilder.DropTable(
                name: "Allergens");

            migrationBuilder.DropTable(
                name: "MedicalRecords");

            migrationBuilder.DropTable(
                name: "InpatientTreatmentTherapies");

            migrationBuilder.DropTable(
                name: "Medicines");

            migrationBuilder.DropTable(
                name: "PhysicianSchedules");

            migrationBuilder.DropTable(
                name: "InpatientTreatments");

            migrationBuilder.DropTable(
                name: "Doctors");

            migrationBuilder.DropTable(
                name: "Beds");

            migrationBuilder.DropTable(
                name: "Patients");

            migrationBuilder.DropTable(
                name: "Specializations");

            migrationBuilder.DropTable(
                name: "Rooms");
        }
    }
}
