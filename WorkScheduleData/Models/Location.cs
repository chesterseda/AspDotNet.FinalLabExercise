using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace WorkScheduleData.Models
{
    public partial class Location
    {
        public Location()
        {
            PlacementContracts = new HashSet<PlacementContract>();
        }

        [Key]
        [Column("LocationID")]
        public int LocationId { get; set; }
        [Required]
        [StringLength(50)]
        public string Name { get; set; }
        [Required]
        [StringLength(50)]
        public string Street { get; set; }
        [Required]
        [StringLength(50)]
        public string City { get; set; }
        [Required]
        [StringLength(2)]
        public string Province { get; set; }
        [StringLength(50)]
        public string Contact { get; set; }
        [Required]
        [StringLength(12)]
        public string Phone { get; set; }
        public bool Active { get; set; }

        [InverseProperty(nameof(PlacementContract.Location))]
        public virtual ICollection<PlacementContract> PlacementContracts { get; set; }
    }
}
