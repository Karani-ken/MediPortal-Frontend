﻿using System.ComponentModel.DataAnnotations;

namespace MediPortal_Client.Models.Appointment
{
    public class AppointmentRequestDto
    {
        public Guid AppointmentId { get; set; }
        [Required]
        public Guid HospitalId { get; set; }

        [Required]
        public string AppointmentType { get; set; } = string.Empty;

        [Required]
        public Guid DoctorId { get; set; }


        [Required]
        public DateTime AppointmentDate { get; set; }

        [Required]
        public string Slot { get; set; } = string.Empty;
        [Required]
        public string Symptoms { get; set; } = string.Empty;

        public string? AppointmentStatus { get; set; } = string.Empty;
    }
}
