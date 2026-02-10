using BCrypt.Net;

namespace Transport_Management_Systems_Portal_REST_API.Utilities
{
    public static class PasswordHashingUtility
    {
        public static string HashPassword(string password)
        {
            return BCrypt.Net.BCrypt.HashPassword(password);
        }

        public static bool VerifyPassword(string password, string hash)
        {
            return BCrypt.Net.BCrypt.Verify(password, hash);
        }
    }
}