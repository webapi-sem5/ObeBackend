﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ObeSystem.Repository;

namespace ObeSystem.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20210525090923_initial")]
    partial class initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.1");

            modelBuilder.Entity("ObeSystem.Models.Assessment", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Assessment_name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Assessment_type")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Marks")
                        .HasColumnType("int");

                    b.Property<Guid?>("ModuleId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Student_marks")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ModuleId");

                    b.ToTable("Assessments");
                });

            modelBuilder.Entity("ObeSystem.Models.AssessmentLo", b =>
                {
                    b.Property<Guid>("LolistId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("AssessmentId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("LolistId", "AssessmentId");

                    b.HasIndex("AssessmentId");

                    b.ToTable("AssessmentLos");
                });

            modelBuilder.Entity("ObeSystem.Models.AssessmentStudent", b =>
                {
                    b.Property<Guid>("AssessmentId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("StudentId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<float>("Assessment_marks")
                        .HasColumnType("real");

                    b.HasKey("AssessmentId", "StudentId");

                    b.HasIndex("StudentId");

                    b.ToTable("AssessmentStudents");
                });

            modelBuilder.Entity("ObeSystem.Models.Grade", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<float>("Gpa")
                        .HasColumnType("real");

                    b.Property<string>("Grade_type")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Higher_marks")
                        .HasColumnType("int");

                    b.Property<int>("Lower_marks")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Grades");
                });

            modelBuilder.Entity("ObeSystem.Models.Lolist", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Lo_code")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Lo_name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("ModuleId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<double>("Weight")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.HasIndex("ModuleId");

                    b.ToTable("Lolists");
                });

            modelBuilder.Entity("ObeSystem.Models.LolistPo", b =>
                {
                    b.Property<Guid>("LolistId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("PolistId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("LolistId", "PolistId");

                    b.HasIndex("PolistId");

                    b.ToTable("LolistPos");
                });

            modelBuilder.Entity("ObeSystem.Models.Module", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<Guid?>("GradeId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Lecturer")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Module_code")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Module_name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Semester")
                        .HasColumnType("int");

                    b.Property<Guid?>("ThresholdId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("GradeId");

                    b.HasIndex("ThresholdId");

                    b.ToTable("Modules");
                });

            modelBuilder.Entity("ObeSystem.Models.Polist", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("ModuleId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Po_code")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Po_name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Weight")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.HasIndex("ModuleId");

                    b.ToTable("Polists");
                });

            modelBuilder.Entity("ObeSystem.Models.Student", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Batch")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Registration_number")
                        .HasColumnType("nvarchar(max)");

                    b.Property<float>("Student_marks")
                        .HasColumnType("real");

                    b.HasKey("Id");

                    b.ToTable("Students");
                });

            modelBuilder.Entity("ObeSystem.Models.StudentLolist", b =>
                {
                    b.Property<Guid>("StudentId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("LolistId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<float>("Lo_marks")
                        .HasColumnType("real");

                    b.HasKey("StudentId", "LolistId");

                    b.HasIndex("LolistId");

                    b.ToTable("StudentLolists");
                });

            modelBuilder.Entity("ObeSystem.Models.Threshold", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Ca_marks")
                        .HasColumnType("int");

                    b.Property<int>("End_marks")
                        .HasColumnType("int");

                    b.Property<float>("Min_attendance")
                        .HasColumnType("real");

                    b.Property<float>("Min_ca_marks")
                        .HasColumnType("real");

                    b.Property<float>("Min_end_marks")
                        .HasColumnType("real");

                    b.Property<float>("Min_lo_marks")
                        .HasColumnType("real");

                    b.Property<float>("Min_po_marks")
                        .HasColumnType("real");

                    b.Property<float>("Min_total_marks")
                        .HasColumnType("real");

                    b.HasKey("Id");

                    b.ToTable("Thresholds");
                });

            modelBuilder.Entity("ObeSystem.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Phone")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Username")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("ObeSystem.Models.Assessment", b =>
                {
                    b.HasOne("ObeSystem.Models.Module", "Module")
                        .WithMany("Assessments")
                        .HasForeignKey("ModuleId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.Navigation("Module");
                });

            modelBuilder.Entity("ObeSystem.Models.AssessmentLo", b =>
                {
                    b.HasOne("ObeSystem.Models.Assessment", "Assessment")
                        .WithMany("AssessmentLos")
                        .HasForeignKey("AssessmentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ObeSystem.Models.Lolist", "Lolist")
                        .WithMany("AssessmentLos")
                        .HasForeignKey("LolistId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Assessment");

                    b.Navigation("Lolist");
                });

            modelBuilder.Entity("ObeSystem.Models.AssessmentStudent", b =>
                {
                    b.HasOne("ObeSystem.Models.Assessment", "Assessment")
                        .WithMany("AssessmentStudents")
                        .HasForeignKey("AssessmentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ObeSystem.Models.Student", "Student")
                        .WithMany("AssessmentStudents")
                        .HasForeignKey("StudentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Assessment");

                    b.Navigation("Student");
                });

            modelBuilder.Entity("ObeSystem.Models.Lolist", b =>
                {
                    b.HasOne("ObeSystem.Models.Module", "Module")
                        .WithMany("Lolists")
                        .HasForeignKey("ModuleId");

                    b.Navigation("Module");
                });

            modelBuilder.Entity("ObeSystem.Models.LolistPo", b =>
                {
                    b.HasOne("ObeSystem.Models.Lolist", "Lolist")
                        .WithMany("LolistPos")
                        .HasForeignKey("LolistId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ObeSystem.Models.Polist", "Polist")
                        .WithMany("LolistPos")
                        .HasForeignKey("PolistId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Lolist");

                    b.Navigation("Polist");
                });

            modelBuilder.Entity("ObeSystem.Models.Module", b =>
                {
                    b.HasOne("ObeSystem.Models.Grade", "Grade")
                        .WithMany("Modules")
                        .HasForeignKey("GradeId");

                    b.HasOne("ObeSystem.Models.Threshold", "Threshold")
                        .WithMany("Modules")
                        .HasForeignKey("ThresholdId");

                    b.Navigation("Grade");

                    b.Navigation("Threshold");
                });

            modelBuilder.Entity("ObeSystem.Models.Polist", b =>
                {
                    b.HasOne("ObeSystem.Models.Module", "Module")
                        .WithMany("Polists")
                        .HasForeignKey("ModuleId");

                    b.Navigation("Module");
                });

            modelBuilder.Entity("ObeSystem.Models.StudentLolist", b =>
                {
                    b.HasOne("ObeSystem.Models.Lolist", "Lolist")
                        .WithMany("StudentLolists")
                        .HasForeignKey("LolistId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ObeSystem.Models.Student", "Student")
                        .WithMany("StudentLolists")
                        .HasForeignKey("StudentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Lolist");

                    b.Navigation("Student");
                });

            modelBuilder.Entity("ObeSystem.Models.Assessment", b =>
                {
                    b.Navigation("AssessmentLos");

                    b.Navigation("AssessmentStudents");
                });

            modelBuilder.Entity("ObeSystem.Models.Grade", b =>
                {
                    b.Navigation("Modules");
                });

            modelBuilder.Entity("ObeSystem.Models.Lolist", b =>
                {
                    b.Navigation("AssessmentLos");

                    b.Navigation("LolistPos");

                    b.Navigation("StudentLolists");
                });

            modelBuilder.Entity("ObeSystem.Models.Module", b =>
                {
                    b.Navigation("Assessments");

                    b.Navigation("Lolists");

                    b.Navigation("Polists");
                });

            modelBuilder.Entity("ObeSystem.Models.Polist", b =>
                {
                    b.Navigation("LolistPos");
                });

            modelBuilder.Entity("ObeSystem.Models.Student", b =>
                {
                    b.Navigation("AssessmentStudents");

                    b.Navigation("StudentLolists");
                });

            modelBuilder.Entity("ObeSystem.Models.Threshold", b =>
                {
                    b.Navigation("Modules");
                });
#pragma warning restore 612, 618
        }
    }
}
