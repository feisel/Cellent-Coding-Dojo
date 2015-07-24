using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;

namespace ccdService.DB
{
    public class PictureContext : DbContext
    {

        public PictureContext() : base("PictureContext")
        {
        }

        public DbSet<Picture> Pictures { get; set; }
        public DbSet<PictureDetails> PictureDetails { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            modelBuilder.Entity<PictureDetails>()
                .HasKey(e => e.ID);

            modelBuilder.Entity<Picture>()
                      .HasOptional(s => s.Details) // Mark StudentAddress is optional for Student
                      .WithRequired(ad => ad.Picture); // Create inverse relationship
            

            /*
            // Configure StudentId as PK for StudentAddress
            modelBuilder.Entity<StudentAddress>()
                .HasKey(e => e.StudentId);

            // Configure StudentId as FK for StudentAddress
            modelBuilder.Entity<Student>()
                        .HasOptional(s => s.StudentAddress) // Mark StudentAddress is optional for Student
                        .WithRequired(ad => ad.Student); // Create inverse relationship
                        */
        }


        
    }



}