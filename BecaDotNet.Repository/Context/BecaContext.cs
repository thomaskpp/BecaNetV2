using BecaDotNet.Domain.Model;
using BecaDotNet.Repository.Configs;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace BecaDotNet.Repository.Context
{
    public class BecaContext : DbContext
    {
        public BecaContext() : base("DefaultConnString") { }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            this.ProcessConfiguration(modelBuilder);
        } 

        private void ProcessConfiguration(DbModelBuilder builder)
        {
            builder.Configurations.Add(new UserEntityConfig());
            builder.Configurations.Add(new UserTypeEntityConfig());
            builder.Configurations.Add(new UserTypeUserEntityConfig());
        }

        public DbSet<User> Users { get; set; }
        public DbSet<UserType> UserTypes { get; set; }
        public DbSet<UserTypeUser> UserTypeUsers { get; set; }
    }
}
