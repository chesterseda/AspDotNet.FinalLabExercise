using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace WorkScheduleData.Models
{
    [Index(nameof(LocationId), Name = "IX_PlacementContracts_LocationID")]
    public partial class PlacementContract
    {
        public PlacementContract()
        {
            Shifts = new HashSet<Shift>();
        }

        [Key]
        [Column("PlacementContractID")]
        public int PlacementContractId { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime StartDate { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime EndDate { get; set; }
        [Column("LocationID")]
        public int LocationId { get; set; }

        [ForeignKey(nameof(LocationId))]
        [InverseProperty("PlacementContracts")]
        public virtual Location Location { get; set; }
        [InverseProperty(nameof(Shift.PlacementContract))]
        public virtual ICollection<Shift> Shifts { get; set; }
    }
}
