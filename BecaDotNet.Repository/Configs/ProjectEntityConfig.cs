using BecaDotNet.Domain.Model;

namespace BecaDotNet.Repository.Configs
{
    public class ProjectEntityConfig : BaseIdentifiedEntityConfig<Project>
    {
        public ProjectEntityConfig()
        {
            this.ToTable("TB_PROJECT");
            this.Property(p => p.ProjectName).HasColumnName("PROJECT_NAME").HasColumnType("varchar").HasMaxLength(200).IsRequired();
            this.Property(p => p.StartDate).HasColumnName("START_DATE").HasColumnType("datetime").IsRequired();
            this.Property(p => p.EndDate).HasColumnName("END_DATE").HasColumnType("datetime").IsOptional();
            this.Property(p => p.ClientId).HasColumnName("CLIENT_ID").HasColumnType("int").IsRequired();
        }
    }
}
