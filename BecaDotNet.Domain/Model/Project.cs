using System;
using System.Collections.Generic;

namespace BecaDotNet.Domain.Model
{
    public class Project : IdentifiedEntity
    {
        public string ProjectName { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public Client Client { get; set; }
        public int ClientId { get; set; }
    }
}
