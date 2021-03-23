using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace KursovaiaRabota
{
    public partial class TourFirmContext : DbContext
    {
        public TourFirmContext()
            : base("name=TourFirmContext")
        {
        }

        public virtual DbSet<City> City { get; set; }
        public virtual DbSet<Client> Client { get; set; }
        public virtual DbSet<Country> Country { get; set; }
        public virtual DbSet<Hotel> Hotel { get; set; }
        public virtual DbSet<Sight> Sight { get; set; }
        public virtual DbSet<Tour> Tour { get; set; }
        public virtual DbSet<Tour_on_date> Tour_on_date { get; set; }
        public virtual DbSet<TourPurchase> TourPurchase { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<City>()
                .Property(e => e.city_name)
                .IsUnicode(false);

            modelBuilder.Entity<City>()
                .HasMany(e => e.Hotel)
                .WithRequired(e => e.City)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Client>()
                .Property(e => e.name)
                .IsUnicode(false);

            modelBuilder.Entity<Client>()
                .Property(e => e.Client_country)
                .IsUnicode(false);

            modelBuilder.Entity<Client>()
                .Property(e => e.email)
                .IsUnicode(false);

            modelBuilder.Entity<Client>()
                .Property(e => e.UserName)
                .IsUnicode(false);

            modelBuilder.Entity<Client>()
                .Property(e => e.password)
                .IsUnicode(false);

            modelBuilder.Entity<Client>()
                .Property(e => e.isAdmin)
                .IsUnicode(false);

            modelBuilder.Entity<Country>()
                .Property(e => e.country_name)
                .IsUnicode(false);

            modelBuilder.Entity<Hotel>()
                .Property(e => e.Hotel_name)
                .IsUnicode(false);

            modelBuilder.Entity<Sight>()
                .Property(e => e.Sight_name)
                .IsUnicode(false);

            modelBuilder.Entity<Tour>()
                .Property(e => e.Category)
                .IsUnicode(false);

            modelBuilder.Entity<Tour>()
                .Property(e => e.cost)
                .HasPrecision(19, 4);

            modelBuilder.Entity<Tour>()
                .Property(e => e.passage)
                .IsUnicode(false);

            modelBuilder.Entity<Tour>()
                .Property(e => e.residence)
                .IsUnicode(false);

            modelBuilder.Entity<Tour>()
                .Property(e => e.food)
                .IsUnicode(false);

            modelBuilder.Entity<Tour>()
                .HasMany(e => e.Tour_on_date)
                .WithRequired(e => e.Tour)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Tour_on_date>()
                .HasMany(e => e.TourPurchase)
                .WithOptional(e => e.Tour_on_date)
                .HasForeignKey(e => new { e.data, e.ID_tour });
        }
    }
}
