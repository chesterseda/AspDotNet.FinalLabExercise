using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using WorkScheduleData.Models;

#nullable disable

namespace WorkScheduleData.Data
{
    public partial class WorkScheduleContext : DbContext
    {
        public WorkScheduleContext()
        {
        }

        public WorkScheduleContext(DbContextOptions<WorkScheduleContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Employee> Employees { get; set; }
        public virtual DbSet<EmployeeSkill> EmployeeSkills { get; set; }
        public virtual DbSet<Location> Locations { get; set; }
        public virtual DbSet<PlacementContract> PlacementContracts { get; set; }
        public virtual DbSet<Schedule> Schedules { get; set; }
        public virtual DbSet<Shift> Shifts { get; set; }
        public virtual DbSet<Skill> Skills { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=DMMBQG3;Database=WorkSchedule;User Id=sa;Password=lastgam3counts");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Employee>(entity =>
            {
                entity.Property(e => e.HomePhone)
                    .IsUnicode(false)
                    .IsFixedLength(true);
            });

            modelBuilder.Entity<EmployeeSkill>(entity =>
            {
                entity.HasOne(d => d.Skills)
                    .WithMany(p => p.EmployeeSkills)
                    .HasForeignKey(d => d.SkillsId)
                    .HasConstraintName("FK_EmployeeSkills_Skills_SkillsID1");
            });

            modelBuilder.Entity<Location>(entity =>
            {
                entity.Property(e => e.Phone)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.Province).IsFixedLength(true);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
