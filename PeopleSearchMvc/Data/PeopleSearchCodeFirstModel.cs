namespace PeopleSearchMvc.Data
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class PeopleSearchCodeFirstModel : DbContext
    {
        public PeopleSearchCodeFirstModel()
            : base("name=PeopleSearchCodeFirstModel1")
        {
        }

        public virtual DbSet<Person> People { get; set; }
        public virtual DbSet<Address> Addresses { get; set; }
        public virtual DbSet<Interest> Interests { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Person>()
                .Property(e => e.FirstName)
                .IsUnicode(false);

            modelBuilder.Entity<Person>()
                .Property(e => e.LastName)
                .IsUnicode(false);

            modelBuilder.Entity<Person>()
                .Property(e => e.AvatarUrl)
                .IsUnicode(false);

            modelBuilder.Entity<Person>()
                .HasMany(e => e.Addresses)
                .WithRequired(e => e.Person)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Person>()
                .HasMany(e => e.Interests)
                .WithRequired(e => e.Person)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Address>()
                .Property(e => e.Address1)
                .IsUnicode(false);

            modelBuilder.Entity<Interest>()
                .Property(e => e.Interest1)
                .IsUnicode(false);
        }
    }
}
