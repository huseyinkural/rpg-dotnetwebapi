using System.Threading.Tasks;
using rpg_webapi.Models;

namespace rpg_webapi.Data
{
    public interface IAuthRepository
    {
         Task<ServiceResponse<int>> Register(User user, string password);
         Task<ServiceResponse<string>> Login(string username, string password);
         Task<bool> UserExists(string username);
         
    }
}