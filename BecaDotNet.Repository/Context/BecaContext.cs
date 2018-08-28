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
            modelBuilder.Entity<Project>().
                HasRequired(c => c.Client).
                WithMany(m => m.Projects).
                HasForeignKey(f=>f.ClientId).
                WillCascadeOnDelete(false);
            
        } 

        private void ProcessConfiguration(DbModelBuilder builder)
        {
            builder.Configurations.Add(new UserEntityConfig());
            builder.Configurations.Add(new UserTypeEntityConfig());
            builder.Configurations.Add(new UserTypeUserEntityConfig());
            builder.Configurations.Add(new ClientEntityConfig());
            builder.Configurations.Add(new ProjectEntityConfig());
            builder.Configurations.Add(new ProjectUserEntityConfig());
        }

        public DbSet<User> Users { get; set; }
        public DbSet<UserType> UserTypes { get; set; }
        public DbSet<UserTypeUser> UserTypeUsers { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<ProjectUser> ProjectUsers { get; set; }
    }
}
