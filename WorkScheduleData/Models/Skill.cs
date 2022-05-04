using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace WorkScheduleData.Models
{
    public partial class Skill: BaseEntity
    {
        public Skill()
        {
            EmployeeSkills = new HashSet<EmployeeSkill>();
        }

        [Key]
        [Column("SkillsID")]
        public int SkillsId { get; set; }
        [Required]
        public string Description { get; set; }
        public bool RequiresTicket { get; set; }

        [InverseProperty(nameof(EmployeeSkill.Skills))]
        public virtual ICollection<EmployeeSkill> EmployeeSkills { get; set; }
    }
}
