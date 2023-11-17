using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DomainLayer.Model
{
    public class ApplyLeave
    {
        [Key]
        public int Id { get; set; }
        public int UserId { get; set; }

        public string? ManagerName { get; set; }

        public string? EmployeeName { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public string? LeaveType { get; set; }

        public string? Reason { get; set; }

        public string? status { get; set; }
    }

  
    }

