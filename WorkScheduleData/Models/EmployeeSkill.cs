using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace WorkScheduleData.Models
{
    [Index(nameof(EmployeeId), Name = "IX_EmployeeSkills_EmployeeID")]
    [Index(nameof(SkillsId), Name = "IX_EmployeeSkills_SkillsID1")]
    public partial class EmployeeSkill: BaseEntity
    {
        [Key]
        [Column("EmployeeSkillsID")]
        public int EmployeeSkillsId { get; set; }
        [Column("EmployeeID")]
        public int EmployeeId { get; set; }
        public int Level { get; set; }
        public int? YearsOfExperience { get; set; }
        [Column(TypeName = "money")]
        public decimal HourlyWage { get; set; }
        [Column("SkillsID")]
        public int? SkillsId { get; set; }

        [ForeignKey(nameof(EmployeeId))]
        [InverseProperty("EmployeeSkills")]
        public virtual Employee Employee { get; set; }
        [ForeignKey(nameof(SkillsId))]
        [InverseProperty(nameof(Skill.EmployeeSkills))]
        public virtual Skill Skills { get; set; }
    }
}
