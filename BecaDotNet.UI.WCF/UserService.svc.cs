using System;
using System.Collections.Generic;
using BecaDotNet.ApplicationService;
using BecaDotNet.Domain.Model;

namespace BecaDotNet.UI.WCF
{
    public class UserService : IUserService
    {
        public IEnumerable<User> GetUserFiltered(string name, int userTypeId)
        {
            var svc = new UserAppSvcGeneric();
            var result = svc.FindBy(new User { Name = name, UserTypeId = userTypeId });
            return result;
        }
    }
}
