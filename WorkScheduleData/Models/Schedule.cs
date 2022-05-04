using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace WorkScheduleData.Models
{
    [Index(nameof(EmployeeId), Name = "IX_Schedules_EmployeeID")]
    [Index(nameof(ShiftId), Name = "IX_Schedules_ShiftID")]
    public partial class Schedule
    {
        [Key]
        [Column("ScheduleID")]
        public int ScheduleId { get; set; }
        public DateTime Day { get; set; }
        [Column("ShiftID")]
        public int ShiftId { get; set; }
        [Column("EmployeeID")]
        public int EmployeeId { get; set; }
        [Column(TypeName = "decimal(11, 2)")]
        public decimal HourlyWage { get; set; }
        public bool Overtime { get; set; }

        [ForeignKey(nameof(EmployeeId))]
        [InverseProperty("Schedules")]
        public virtual Employee Employee { get; set; }
        [ForeignKey(nameof(ShiftId))]
        [InverseProperty("Schedules")]
        public virtual Shift Shift { get; set; }
    }
}
