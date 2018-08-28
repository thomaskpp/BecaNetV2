using BecaDotNet.Domain.Model;
using BecaDotNet.Domain.Service;
using System;
using System.Collections.Generic;

namespace BecaDotNet.ApplicationService
{
    public class ProjectAppService : IGenericService<Project>
    {
        public Project Create(Project toCreate)
        {
            throw new NotImplementedException();
        }

        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Project> FindBy(Project filter)
        {
            throw new NotImplementedException();
        }

        public Project Get(int id)
        {
            throw new NotImplementedException();
        }

        public Project Update(Project toUpdate)
        {
            throw new NotImplementedException();
        }
    }
}
