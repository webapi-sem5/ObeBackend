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
    [Migration("20210529200647_in")]
    partial class @in
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.1");

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("ObeSystem.Models.AppUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers");
                });

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

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("ObeSystem.Models.AppUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("ObeSystem.Models.AppUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ObeSystem.Models.AppUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("ObeSystem.Models.AppUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
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
