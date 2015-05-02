namespace Timebanks.NZ.DAL.MySql.EntityFramework
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class TimebanksNZ : DbContext
    {
        public TimebanksNZ()
            : base("name=TimebanksNZ")
        {
        }

        public virtual DbSet<category> categories { get; set; }
        public virtual DbSet<country> countries { get; set; }
        public virtual DbSet<member> members { get; set; }
        public virtual DbSet<offer_need> offer_need { get; set; }
        public virtual DbSet<timebank> timebanks { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<category>()
                .Property(e => e.name)
                .IsUnicode(false);

            modelBuilder.Entity<country>()
                .Property(e => e.name)
                .IsUnicode(false);

            modelBuilder.Entity<country>()
                .Property(e => e.abbreviation)
                .IsUnicode(false);

            modelBuilder.Entity<member>()
                .Property(e => e.first_name)
                .IsUnicode(false);

            modelBuilder.Entity<member>()
                .Property(e => e.last_name)
                .IsUnicode(false);

            modelBuilder.Entity<member>()
                .Property(e => e.street_address_1)
                .IsUnicode(false);

            modelBuilder.Entity<member>()
                .Property(e => e.street_address_2)
                .IsUnicode(false);

            modelBuilder.Entity<member>()
                .Property(e => e.suburb)
                .IsUnicode(false);

            modelBuilder.Entity<member>()
                .Property(e => e.city)
                .IsUnicode(false);

            modelBuilder.Entity<member>()
                .Property(e => e.postcode)
                .IsUnicode(false);

            modelBuilder.Entity<member>()
                .Property(e => e.mobile_phone)
                .IsUnicode(false);

            modelBuilder.Entity<member>()
                .Property(e => e.home_phone)
                .IsUnicode(false);

            modelBuilder.Entity<member>()
                .Property(e => e.work_phone)
                .IsUnicode(false);

            modelBuilder.Entity<member>()
                .Property(e => e.primary_email)
                .IsUnicode(false);

            modelBuilder.Entity<member>()
                .Property(e => e.secondary_email)
                .IsUnicode(false);

            modelBuilder.Entity<offer_need>()
                .Property(e => e.title)
                .IsUnicode(false);

            modelBuilder.Entity<offer_need>()
                .Property(e => e.description)
                .IsUnicode(false);

            modelBuilder.Entity<timebank>()
                .Property(e => e.name)
                .IsUnicode(false);

            modelBuilder.Entity<timebank>()
                .Property(e => e.url)
                .IsUnicode(false);

            modelBuilder.Entity<timebank>()
                .Property(e => e.Address_1)
                .IsUnicode(false);

            modelBuilder.Entity<timebank>()
                .Property(e => e.Address_2)
                .IsUnicode(false);

            modelBuilder.Entity<timebank>()
                .Property(e => e.suburb)
                .IsUnicode(false);

            modelBuilder.Entity<timebank>()
                .Property(e => e.city)
                .IsUnicode(false);

            modelBuilder.Entity<timebank>()
                .Property(e => e.Postcode)
                .IsUnicode(false);
        }
    }
}
