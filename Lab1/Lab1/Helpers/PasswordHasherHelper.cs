using Lab1.Database.Models;
using Microsoft.AspNetCore.Identity;

namespace Lab1.Helpers
{
    public static class PasswordHasherHelper
    {
        public static string HashPassword(string password)
        {
            var passwordHasher = new PasswordHasher<UserEntity>();
            var hashedPassword = passwordHasher.HashPassword(user: null, password: password);

            return hashedPassword;
        }

        public static bool VerifyPassword(string password, string storedPasswordHash)
        {
            var isVerified = false;

            var passwordHasher = new PasswordHasher<UserEntity>();
            var result = passwordHasher.VerifyHashedPassword(user: null,
                hashedPassword: storedPasswordHash, providedPassword: password);

            if (result == PasswordVerificationResult.Success ||
                result == PasswordVerificationResult.SuccessRehashNeeded)
            {
                isVerified = true;
            }

            return isVerified;
        }
    }
}
