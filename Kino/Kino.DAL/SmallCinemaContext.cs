using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace Kino.DAL
{
    public partial class SmallCinemaContext : DbContext
    {
        public SmallCinemaContext()
            : base("name=SmallCinemaContext")
        {
        }

        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<Film> Films { get; set; }
        public virtual DbSet<Member> Members { get; set; }
        public virtual DbSet<MemberHistory> MemberHistories { get; set; }
        public virtual DbSet<Revenue> Revenues { get; set; }
        public virtual DbSet<RevenueItem> RevenueItems { get; set; }
        public virtual DbSet<RevenueM2M> RevenueM2M { get; set; }
        public virtual DbSet<Seating> Seatings { get; set; }
        public virtual DbSet<sysdiagram> sysdiagrams { get; set; }
        public virtual DbSet<Ticket> Tickets { get; set; }
        public virtual DbSet<Viewing> Viewings { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customer>()
                .HasMany(e => e.Tickets)
                .WithRequired(e => e.Customer)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Customer>()
                .HasMany(e => e.Members)
                .WithRequired(e => e.Customer)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Film>()
                .Property(e => e.Title)
                .IsUnicode(false);

            modelBuilder.Entity<Film>()
                .Property(e => e.Genre)
                .IsUnicode(false);

            modelBuilder.Entity<Film>()
                .HasMany(e => e.Viewings)
                .WithRequired(e => e.Film)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Member>()
                .Property(e => e.FirstName)
                .IsUnicode(false);

            modelBuilder.Entity<Member>()
                .Property(e => e.LastName)
                .IsUnicode(false);

            modelBuilder.Entity<Member>()
                .Property(e => e.HomeAddress)
                .IsUnicode(false);

            modelBuilder.Entity<Member>()
                .Property(e => e.ContactTel)
                .IsUnicode(false);

            modelBuilder.Entity<Member>()
                .Property(e => e.ContactEmail)
                .IsUnicode(false);

            modelBuilder.Entity<Member>()
                .HasMany(e => e.MemberHistories)
                .WithRequired(e => e.Member)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<MemberHistory>()
                .HasMany(e => e.RevenueM2M)
                .WithRequired(e => e.MemberHistory)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Revenue>()
                .HasMany(e => e.Tickets)
                .WithRequired(e => e.Revenue)
                .HasForeignKey(e => e.PurchaseId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<RevenueItem>()
                .Property(e => e.ItemName)
                .IsUnicode(false);

            modelBuilder.Entity<RevenueItem>()
                .Property(e => e.ItemSize)
                .IsUnicode(false);

            modelBuilder.Entity<RevenueItem>()
                .HasMany(e => e.RevenueM2M)
                .WithRequired(e => e.RevenueItem)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Seating>()
                .HasMany(e => e.Tickets)
                .WithRequired(e => e.Seating)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Viewing>()
                .HasMany(e => e.Tickets)
                .WithRequired(e => e.Viewing)
                .WillCascadeOnDelete(false);
        }
    }
}
