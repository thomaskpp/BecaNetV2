using System;

namespace BecaDotNet.Domain.Model
{
    public class ProjectUser : IdentifiedEntity
    {
        public User User { get; set; }
        public int UserId { get; set; }
        public Project Project { get; set; }
        public int ProjectId { get; set; }
        public DateTime UserProjectStartDate { get; set; }
        public DateTime? UserProjectEndDate { get; set; }
    }
}
