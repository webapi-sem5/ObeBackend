using Microsoft.EntityFrameworkCore;
using ObeSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ObeSystem.Repository
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }
        public DbSet<Assessment> Assessments { get; set; }
        public DbSet<Lolist> Lolists { get; set; }
        public DbSet<Student> Students { get; set; }

        public DbSet<Polist> Polists { get; set; }

        public DbSet<User> Users { get; set; }
        public DbSet<Module> Modules { get; set; }
        public DbSet<Grade> Grades { get; set; }
        public DbSet<Threshold> Thresholds { get; set; }
        
        public DbSet<AssessmentLo> AssessmentLos { get; set; }

        public DbSet<LolistPo> LolistPos { get; set; }

        public DbSet<AssessmentStudent> AssessmentStudents { get; set; }

        public DbSet<StudentLolist> StudentLolists { get; set; }


        //public DbSet<User> Users { get; set; }







        protected override void OnModelCreating(ModelBuilder builder)
        {
            


            builder.Entity<AssessmentLo>(x => x.HasKey(ua =>
            new { ua.LolistId, ua.AssessmentId }));

            builder.Entity<AssessmentLo>()
                .HasOne(u => u.Lolist)
                .WithMany(a => a.AssessmentLos)
                .HasForeignKey(u => u.LolistId)
                .OnDelete(DeleteBehavior.Cascade);


            builder.Entity<AssessmentLo>()
                .HasOne(u => u.Assessment)
                .WithMany(a => a.AssessmentLos)
                .HasForeignKey(u => u.AssessmentId)
               .OnDelete(DeleteBehavior.Cascade);


            //builder.Entity<Lolist>()
            //    .HasOne(u => u.Module)
            //    .WithMany(a => a.Lolists)
            //    .HasForeignKey(u => u.ModuleId)
            //    .OnDelete(DeleteBehavior.Cascade);

            builder.Entity<LolistPo>(x => x.HasKey(ua =>
            new { ua.LolistId, ua.PolistId }));

            builder.Entity<LolistPo>()
                .HasOne(u => u.Lolist)
                .WithMany(a => a.LolistPos)
                .HasForeignKey(u => u.LolistId)
               .OnDelete(DeleteBehavior.Cascade);

            builder.Entity<LolistPo>()
              .HasOne(u => u.Polist)
              .WithMany(a => a.LolistPos)
              .HasForeignKey(u => u.PolistId);

            builder.Entity<AssessmentStudent>(x => x.HasKey(ua =>
            new { ua.AssessmentId, ua.StudentId }));

            builder.Entity<AssessmentStudent>()
                .HasOne(u => u.Student)
                .WithMany(a => a.AssessmentStudents)
                .HasForeignKey(u => u.StudentId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Entity<AssessmentStudent>()
              .HasOne(u => u.Assessment)
              .WithMany(a => a.AssessmentStudents)
              .HasForeignKey(u => u.AssessmentId)
               .OnDelete(DeleteBehavior.Cascade);



            builder.Entity<StudentLolist>(x => x.HasKey(ua =>
            new { ua.StudentId, ua.LolistId }));

            builder.Entity<StudentLolist>()
                .HasOne(u => u.Student)
                .WithMany(a => a.StudentLolists)
                .HasForeignKey(u => u.StudentId)
                .OnDelete(DeleteBehavior.Cascade);


            builder.Entity<StudentLolist>()
               .HasOne(u => u.Lolist)
               .WithMany(a => a.StudentLolists)
               .HasForeignKey(u => u.LolistId)
              .OnDelete(DeleteBehavior.Cascade);

            builder.Entity<Assessment>()
                .HasOne(e => e.Module)
                .WithMany(s => s.Assessments)
                .OnDelete(DeleteBehavior.Cascade);



            //builder.Entity<Module>()
            //       .HasOne(s => s.Thresholds);

            //builder.Entity<Module>()
            //     .HasOne(s => s.Grade);

            // builder.Entity<Module>()
            // .HasOne(a => a.Threshold)
            // .WithOne(b => b.Module)
            // .HasForeignKey<Threshold>(b => b.ModuleId);

            // builder.Entity<Module>()
            //.HasOne(a => a.Grade)
            //.WithOne(b => b.Module)
            //.HasForeignKey<Threshold>(b => b.ModuleId);







        }

    }
}
