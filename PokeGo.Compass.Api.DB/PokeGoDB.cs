namespace PokeGo.Compass.Api.DB
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class PokeGoDB : DbContext
    {
        public PokeGoDB()
            : base("name=PokeGoDB")
        {
        }

        public virtual DbSet<Device> Devices { get; set; }
        public virtual DbSet<User> Users { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Device>()
                .HasOptional(e => e.User)
                .WithRequired(e => e.Device);

            modelBuilder.Entity<User>()
                .Property(e => e.Password)
                .IsFixedLength();

            modelBuilder.Entity<User>()
                .Property(e => e.LastPokeGoAuthKey)
                .IsFixedLength();
        }
    }
}
