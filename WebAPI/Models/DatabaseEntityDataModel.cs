namespace WebAPI
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class DatabaseEntityDataModel : DbContext
    {
        public DatabaseEntityDataModel()
            : base("name=DatabaseEntityDataModel")
        {
        }

        public virtual DbSet<FacilitiesBooked> FacilitiesBooked { get; set; }
        public virtual DbSet<Facility> Facility { get; set; }
        public virtual DbSet<Organizer> Organizer { get; set; }
        public virtual DbSet<Place> Place { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Facility>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<Facility>()
                .HasMany(e => e.FacilitiesBooked)
                .WithRequired(e => e.Facility)
                .HasForeignKey(e => e.Fk_Facility)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Organizer>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<Organizer>()
                .Property(e => e.Email)
                .IsUnicode(false);

            modelBuilder.Entity<Organizer>()
                .Property(e => e.Phone)
                .IsUnicode(false);

            modelBuilder.Entity<Organizer>()
                .HasMany(e => e.FacilitiesBooked)
                .WithRequired(e => e.Organizer)
                .HasForeignKey(e => e.Fk_Organizer)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Place>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<Place>()
                .Property(e => e.City)
                .IsUnicode(false);

            modelBuilder.Entity<Place>()
                .HasMany(e => e.Facility)
                .WithRequired(e => e.Place)
                .HasForeignKey(e => e.Fk_Place)
                .WillCascadeOnDelete(false);
        }
    }
}
