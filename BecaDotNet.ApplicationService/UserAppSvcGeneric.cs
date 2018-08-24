using System;
using System.Collections.Generic;
using BecaDotNet.Domain.Model;
using BecaDotNet.Domain.Service;
using BecaDotNet.Repository;

namespace BecaDotNet.ApplicationService
{
    public class UserAppSvcGeneric : IGenericService<User>
    {
        private UserRepositoryGeneric rep = new UserRepositoryGeneric();

        public User Create(User toCreate)
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
            throw new System.NotImplementedException();
        }

        public IEnumerable<User> FindBy(User filter)
        {
            throw new System.NotImplementedException();
        }

        public User Get(int id)
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

        public User Update(User toUpdate)
        {
            throw new System.NotImplementedException();
        }

        public User Authenticate(string login, string password)
        {
            return rep.Authenticate(login, password);
        }
    }
}
