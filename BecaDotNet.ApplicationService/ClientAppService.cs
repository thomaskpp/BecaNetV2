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
            throw new System.NotImplementedException();
        }

        public bool Delete(int id)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<Client> FindBy(Client filter)
        {
            throw new System.NotImplementedException();
        }

        public Client Get(int id)
        {
            var result = rep.GetSingle(id);
            return result;
        }

        public Client Update(Client toUpdate)
        {
            throw new System.NotImplementedException();
        }
    }
}
