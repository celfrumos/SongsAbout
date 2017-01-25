namespace SongsAbout.Web.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
    using System.Collections.Generic;
    using Entities;

    public partial class DataContext : DbContext
    {
        public DataContext()
            : base("name=DataContext")
        {
        }

        public virtual DbSet<User> Users { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .Property(e => e.u_name)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.u_email)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.u_bio)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.u_profile_pic);

        }
    }
}
