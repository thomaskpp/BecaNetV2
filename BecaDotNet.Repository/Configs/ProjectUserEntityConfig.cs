using BecaDotNet.Domain.Model;

namespace BecaDotNet.Repository.Configs
{
    public class ProjectUserEntityConfig : BaseIdentifiedEntityConfig<ProjectUser>
    {
        public ProjectUserEntityConfig()
        {
            ToTable("TB_PROJECT_USER");
            Property(p => p.UserProjectStartDate).HasColumnName("START_DATE").HasColumnType("datetime").IsRequired();
            Property(p => p.UserProjectEndDate).HasColumnName("END_DATE").HasColumnType("datetime").IsOptional();
            Property(p => p.UserId).HasColumnName("USER_ID").HasColumnType("int").IsRequired();
            Property(p => p.ProjectId).HasColumnName("PROJECT_ID").HasColumnType("int").IsRequired();
        }
    }
}
