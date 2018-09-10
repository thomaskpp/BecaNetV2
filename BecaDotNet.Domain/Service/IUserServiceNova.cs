using BecaDotNet.Domain.Model;

namespace BecaDotNet.Domain.Service
{
    public interface IUserServiceNova
    {
        User Authenticate(string login, string password);
    }
}
