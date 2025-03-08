using System.Threading.Tasks;

namespace HamburguesitoNet.Application.Common.Interfaces.Services
{
    public interface IUserService
    {
        public string GetUser();
        public Task CreateAdminUserAsync();
    }
}
