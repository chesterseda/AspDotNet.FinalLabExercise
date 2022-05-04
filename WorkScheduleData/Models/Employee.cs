﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace WorkScheduleData.Models
{
    public partial class Employee: BaseEntity
    {
        public Employee()
        {
            EmployeeSkills = new HashSet<EmployeeSkill>();
            Schedules = new HashSet<Schedule>();
        }

        [Key]
        [Column("EmployeeID")]
        public int EmployeeId { get; set; }
        [Required]
        [StringLength(50)]
        public string FirstName { get; set; }
        [Required]
        [StringLength(50)]
        public string LastName { get; set; }
        [Required]
        [StringLength(12)]
        public string HomePhone { get; set; }
        public bool Active { get; set; }

        [InverseProperty(nameof(EmployeeSkill.Employee))]
        public virtual ICollection<EmployeeSkill> EmployeeSkills { get; set; }
        [InverseProperty(nameof(Schedule.Employee))]
        public virtual ICollection<Schedule> Schedules { get; set; }
    }
}
