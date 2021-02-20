using System;
using System.Threading.Tasks;
using AutoMapper;
using Lab1.Database.Infrastructure;
using Lab1.Database.Models;
using Lab1.Helpers;
using Lab1.Services.Interfaces;
using Lab1.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace Lab1.Services
{
    public class UserService : IUserService
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public UserService(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<AuthorizedUserViewModel> LoginAsync(UserLoginViewModel userLoginViewModel)
        {
            var userEntity = await _context.Users
                .AsNoTracking()
                .FirstOrDefaultAsync(u => u.Login == userLoginViewModel.Login);

            bool isPasswordVerified = PasswordHasherHelper
                .VerifyPassword(userLoginViewModel.Password, userEntity.PasswordHash);

            if (!isPasswordVerified)
            {
                throw new ArgumentException();
            }

            var token = JsonWebTokenHelper.GenerateJsonWebToken(userEntity.Id, userEntity.Login);

            var authorizedUserViewModel = new AuthorizedUserViewModel()
            {
                JwtToken = token,
                Email = userEntity.Login
            };

            return authorizedUserViewModel;
        }

        public async Task<AuthorizedUserViewModel> RegisterAsync(UserRegisterViewModel userRegisterViewModel)
        {
            if (userRegisterViewModel.Password != userRegisterViewModel.PasswordConfirmation)
            {
                throw new ArgumentException();
            }

            var userEntity = _mapper.Map<UserEntity>(userRegisterViewModel);
            userEntity.PasswordHash = PasswordHasherHelper.HashPassword(userRegisterViewModel.Password);

            await _context.Users.AddAsync(userEntity);
            await _context.SaveChangesAsync();

            var loginViewModel = new UserLoginViewModel()
            {
                Login = userRegisterViewModel.Login,
                Password = userRegisterViewModel.Password
            };

            var authorizedUserViewModel = await LoginAsync(loginViewModel);

            return authorizedUserViewModel;
        }
    }
}
