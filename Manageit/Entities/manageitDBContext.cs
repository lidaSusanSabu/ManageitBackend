using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Manageit.Entities
{
    public partial class manageitDBContext : DbContext
    {
        public manageitDBContext()
        {
        }

        public manageitDBContext(DbContextOptions<manageitDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Authentications> Authentications { get; set; }
        public virtual DbSet<ContactDetails> ContactDetails { get; set; }
        public virtual DbSet<Designation> Designation { get; set; }
        public virtual DbSet<EmployeeDetails> EmployeeDetails { get; set; }
        public virtual DbSet<Gender> Gender { get; set; }
        public virtual DbSet<ProjectAssignment> ProjectAssignment { get; set; }
        public virtual DbSet<ProjectDetails> ProjectDetails { get; set; }
        public virtual DbSet<TaskAssignment> TaskAssignment { get; set; }
        public virtual DbSet<TaskDetails> TaskDetails { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=.\\SQLExpress;Database=manageitDB;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Authentications>(entity =>
            {
                entity.HasKey(e => e.AuthId)
                    .HasName("pk_authentications");

                entity.ToTable("authentications");

                entity.Property(e => e.AuthId).HasColumnName("authId");

                entity.Property(e => e.EmpId).HasColumnName("empId");

                entity.Property(e => e.EmpPassword)
                    .HasColumnName("empPassword")
                    .HasMaxLength(8)
                    .IsUnicode(false);

                entity.HasOne(d => d.Emp)
                    .WithMany(p => p.Authentications)
                    .HasForeignKey(d => d.EmpId)
                    .HasConstraintName("fk_employee_authentications");
            });

            modelBuilder.Entity<ContactDetails>(entity =>
            {
                entity.ToTable("contactDetails");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.EmpId).HasColumnName("empId");

                entity.Property(e => e.MobileNumber)
                    .HasColumnName("mobileNumber")
                    .HasMaxLength(10);

                entity.HasOne(d => d.Emp)
                    .WithMany(p => p.ContactDetails)
                    .HasForeignKey(d => d.EmpId)
                    .HasConstraintName("fk_employee");
            });

            modelBuilder.Entity<Designation>(entity =>
            {
                entity.ToTable("designation");

                entity.Property(e => e.DesignationId).HasColumnName("designationId");

                entity.Property(e => e.Designation1)
                    .HasColumnName("designation")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<EmployeeDetails>(entity =>
            {
                entity.HasKey(e => e.EmpId)
                    .HasName("pk_employee");

                entity.ToTable("employeeDetails");

                entity.Property(e => e.EmpId).HasColumnName("empId");

                entity.Property(e => e.DesignationId).HasColumnName("designationId");

                entity.Property(e => e.FName)
                    .HasColumnName("fName")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.GenderId).HasColumnName("genderId");

                entity.Property(e => e.LName)
                    .HasColumnName("lName")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.Designation)
                    .WithMany(p => p.EmployeeDetails)
                    .HasForeignKey(d => d.DesignationId)
                    .HasConstraintName("fk_designation");

                entity.HasOne(d => d.Gender)
                    .WithMany(p => p.EmployeeDetails)
                    .HasForeignKey(d => d.GenderId)
                    .HasConstraintName("fk_gender");
            });

            modelBuilder.Entity<Gender>(entity =>
            {
                entity.ToTable("gender");

                entity.Property(e => e.GenderId).HasColumnName("genderId");

                entity.Property(e => e.Gender1)
                    .HasColumnName("gender")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<ProjectAssignment>(entity =>
            {
                entity.ToTable("projectAssignment");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.EmpId).HasColumnName("empId");

                entity.Property(e => e.EndPeriod)
                    .HasColumnName("endPeriod")
                    .HasColumnType("date");

                entity.Property(e => e.ProjectId).HasColumnName("projectId");

                entity.Property(e => e.StartPeriod)
                    .HasColumnName("startPeriod")
                    .HasColumnType("date");

                entity.HasOne(d => d.Emp)
                    .WithMany(p => p.ProjectAssignment)
                    .HasForeignKey(d => d.EmpId)
                    .HasConstraintName("fk_employee_project");

                entity.HasOne(d => d.Project)
                    .WithMany(p => p.ProjectAssignment)
                    .HasForeignKey(d => d.ProjectId)
                    .HasConstraintName("fk_projects_project");
            });

            modelBuilder.Entity<ProjectDetails>(entity =>
            {
                entity.HasKey(e => e.ProjectId)
                    .HasName("pk_projects");

                entity.ToTable("projectDetails");

                entity.Property(e => e.ProjectId).HasColumnName("projectId");

                entity.Property(e => e.ProjectDescription)
                    .HasColumnName("projectDescription")
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.ProjectName)
                    .HasColumnName("projectName")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TaskAssignment>(entity =>
            {
                entity.ToTable("taskAssignment");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.EmpId).HasColumnName("empId");

                entity.Property(e => e.ProjectId).HasColumnName("projectId");

                entity.Property(e => e.TaskId).HasColumnName("taskId");

                entity.HasOne(d => d.Emp)
                    .WithMany(p => p.TaskAssignment)
                    .HasForeignKey(d => d.EmpId)
                    .HasConstraintName("fk_employee_taskAssignment");

                entity.HasOne(d => d.Project)
                    .WithMany(p => p.TaskAssignment)
                    .HasForeignKey(d => d.ProjectId)
                    .HasConstraintName("fk_projects_taskAssignment");

                entity.HasOne(d => d.Task)
                    .WithMany(p => p.TaskAssignment)
                    .HasForeignKey(d => d.TaskId)
                    .HasConstraintName("fk_taskDetails_taskAssignment");
            });

            modelBuilder.Entity<TaskDetails>(entity =>
            {
                entity.HasKey(e => e.TaskId)
                    .HasName("pk_task");

                entity.ToTable("taskDetails");

                entity.Property(e => e.TaskId).HasColumnName("taskId");

                entity.Property(e => e.Deadline)
                    .HasColumnName("deadline")
                    .HasColumnType("date");

                entity.Property(e => e.TaskDetails1)
                    .HasColumnName("taskDetails")
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.TaskName)
                    .HasColumnName("taskName")
                    .HasMaxLength(60)
                    .IsUnicode(false);

                entity.Property(e => e.TaskStatus)
                    .HasColumnName("taskStatus")
                    .HasMaxLength(10)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
