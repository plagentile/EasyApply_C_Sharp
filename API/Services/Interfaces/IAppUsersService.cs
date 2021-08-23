using System.Threading.Tasks;

namespace API.Services.Interfaces
{
    public interface IAppUsersService{
        Task<bool> UserExists(string username);
    }
}