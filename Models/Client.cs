﻿using System.ComponentModel.DataAnnotations;

namespace RepairServiceApp.Models
{
    public class Client
    {
        [Key]
        public Guid Id { get; set; }

        public string FullName { get; set; } = string.Empty;

        public string PhoneNumber { get; set; } = string.Empty;

        public string Email { get; set; } = string.Empty;

        public string Address { get; set; } = string.Empty;
    }
}