using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace WorkScheduleData.Models
{
    [Index(nameof(PlacementContractId), Name = "IX_Shifts_PlacementContractID")]
    public partial class Shift
    {
        public Shift()
        {
            Schedules = new HashSet<Schedule>();
        }

        [Key]
        [Column("ShiftID")]
        public int ShiftId { get; set; }
        [Column("PlacementContractID")]
        public int PlacementContractId { get; set; }
        public int DayOfWeek { get; set; }
        public TimeSpan StartTime { get; set; }
        [Column("timeSpan")]
        public TimeSpan TimeSpan { get; set; }
        public byte NumberOfEmployees { get; set; }
        public bool Active { get; set; }
        [StringLength(100)]
        public string Notes { get; set; }

        [ForeignKey(nameof(PlacementContractId))]
        [InverseProperty("Shifts")]
        public virtual PlacementContract PlacementContract { get; set; }
        [InverseProperty(nameof(Schedule.Shift))]
        public virtual ICollection<Schedule> Schedules { get; set; }
    }
}
