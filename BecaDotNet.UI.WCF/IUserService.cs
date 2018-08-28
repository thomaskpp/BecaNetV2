using BecaDotNet.Domain.Model;
using System.Collections.Generic;
using System.ServiceModel;

namespace BecaDotNet.UI.WCF
{
    [ServiceContract]
    public interface IUserService
    {
        [OperationContract]
        IEnumerable<User> GetUserFiltered(string name, int userTypeId);
    }
}
