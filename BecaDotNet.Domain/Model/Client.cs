using System.Collections.Generic;

namespace BecaDotNet.Domain.Model
{
    public class Client : IdentifiedEntity
    {
        public string ClientName { get; set; }
        public long Cnpj { get; set; }
        public string ContactName { get; set; }
        public ICollection<Project> Projects { get; set; }
    }
}
