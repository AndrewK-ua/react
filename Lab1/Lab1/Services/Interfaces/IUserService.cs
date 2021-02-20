using System.Threading.Tasks;
using Lab1.ViewModels;

namespace Lab1.Services.Interfaces
{
    public interface IUserService
    {
        Task<AuthorizedUserViewModel> LoginAsync(UserLoginViewModel userLoginViewModel);

        Task<AuthorizedUserViewModel> RegisterAsync(UserRegisterViewModel userRegisterViewModel);
    }
}
