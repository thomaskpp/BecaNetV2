using System;
using System.Collections.Generic;
using BecaDotNet.Domain.Model;
using BecaDotNet.Domain.Service;
using BecaDotNet.Repository;

namespace BecaDotNet.ApplicationService
{
    public class ClientAppService : IGenericService<Client>
    {
        ClientRepository rep = new ClientRepository();

        public Client Create(Client toCreate)
        {
            try
            {
                rep.Create(toCreate);
                rep.Save();
                return toCreate;
            }
            catch (Exception ex)
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
            catch (Exception ex)
            {
                return false;
            }
        }

        public IEnumerable<Client> FindBy(Client filter)
        {
            try
            {
                if (filter == null)
                    filter = new Client();

                var result = rep.FindBy(f =>
               f.Cnpj.ToString().Contains(filter.Cnpj == 0 ? f.Cnpj.ToString() : filter.Cnpj.ToString()) &&
               f.ClientName.Contains(string.IsNullOrEmpty(filter.ClientName) ? f.ClientName : filter.ClientName));
                return result;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public Client Get(int id)
        {
            var result = rep.GetSingle(id);
            return result;
        }

        public Client Update(Client toUpdate)
        {
            try
            {
                var current = rep.GetSingle(toUpdate.Id);
                current.ContactName = toUpdate.ContactName;
                rep.Update(current);
                rep.Save();
                return current;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}
