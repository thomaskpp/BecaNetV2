using BecaDotNet.Domain.Model;
using BecaDotNet.Domain.Service;
using BecaDotNet.Repository;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BecaDotNet.ApplicationService
{
    public class ProjectAppService : IGenericService<Project>
    {
        private ProjectRepository rep = new ProjectRepository();
        public Project Create(Project toCreate)
        {
            try
            {
                rep.Create(toCreate);
                rep.Save();
                return toCreate;
            }
            catch (Exception wz)
            {
                return null;
            }
        }

        public bool Delete(int id)
        {
            try
            {
                rep.Delete(id);
                rep.Save();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public IEnumerable<Project> FindBy(Project filter)
        {
            if (filter == null)
                filter = new Project { ClientId = 0 };
            try
            {
                var result = rep.FindBy(f => f.ClientId ==
                (filter.ClientId == 0 ? f.ClientId : filter.ClientId)
                ).ToList();
                return result;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public Project Get(int id)
        {
            try
            {
                return rep.GetSingle(id);
            }
            catch
            {
                return null;
            }
        }

        public Project Update(Project toUpdate)
        {
            try
            {
                var currentEntity = rep.GetSingle(toUpdate.Id);
                currentEntity.ProjectName = toUpdate.ProjectName;
                currentEntity.StartDate = toUpdate.StartDate;
                currentEntity.EndDate = toUpdate.EndDate.HasValue &&
                    toUpdate.EndDate.Value.Date == DateTime.MinValue.Date ?
                    null : toUpdate.EndDate;

                rep.Update(currentEntity);
                rep.Save();
                return currentEntity;
            }
            catch
            {
                return null;
            }
        }
    }
}
