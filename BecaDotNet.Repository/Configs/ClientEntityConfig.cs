using BecaDotNet.Domain.Model;

namespace BecaDotNet.Repository.Configs
{
    public class ClientEntityConfig : BaseIdentifiedEntityConfig<Client>
    {
        public ClientEntityConfig()
        {
            this.ToTable("TB_CLIENT");
            this.Property(p => p.ClientName).HasColumnName("CLIENT_NAME").HasColumnType("varchar").HasMaxLength(100).IsRequired();
            this.Property(p => p.Cnpj).HasColumnName("CNPJ").HasColumnType("bigint").IsRequired();
            this.Property(p => p.ContactName).HasColumnName("CONTACT_NAME").HasColumnType("varchar").HasMaxLength(400).IsRequired();
        }
    }
}
