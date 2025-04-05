using BCrypt.Net;

namespace TakeLeaveMngSystem.Application
{
    public static class Helper
    {
        //hash string
        public static string Hash(string? input)
        {
            return BCrypt.Net.BCrypt.HashPassword(input, workFactor: 12);
        }

        //vefify
        public static bool Verify(string hash, string currrentInput)
        {
            return BCrypt.Net.BCrypt.Verify(currrentInput, hash);
        }
    }
}
