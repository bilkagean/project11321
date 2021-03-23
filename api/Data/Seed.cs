using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using api.Entities;
using Microsoft.EntityFrameworkCore;

namespace api.Data
{
    public class Seed
    {
        public static async Task SeedUsers(DataContext context)
        {
          if(await context.Users.AnyAsync()) return;

          var userData = await System.IO.File.ReadAllTextAsync("Data/UserSeedData.json");
          var users = JsonSerializer.Deserialize<List<AppUser>>(userData);
        foreach(var user in users)
        {
            using var hmac = new HMACSHA512();
            user.userName = user.userName.ToLower();
            user.PasswordSalt = hmac.Key;
            user.PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes("password"));
           
           await context.Users.AddAsync(user);
        }
        await context.SaveChangesAsync();
        }
    }
}