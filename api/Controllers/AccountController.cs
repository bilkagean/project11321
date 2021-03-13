using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using api.DTOs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace api.Controllers
{
    //for login and logout or register
    public class AccountController : BaseApiController
    {
        private readonly Data.DataContext _context;
        private readonly Interfaces.ITokenService _tokenService;

        public AccountController(Data.DataContext context, Interfaces.ITokenService tokenService)
        {
            _tokenService = tokenService;

            _context = context;
        }
        [HttpPost("register")]
        public async Task<ActionResult<UserDto>> Register(RegisterDTO registerDTO)
        {
            if (await UserExists(registerDTO.userName)) return BadRequest("Username is taken");
            using var hmac = new HMACSHA512();

            var user = new Entities.AppUser
            {
                userName = registerDTO.userName.ToLower(),
                PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(registerDTO.Password)),
                PasswordSalt = hmac.Key
            };
            _context.Users.Add(user);
            await _context.SaveChangesAsync();

           
            return new UserDto{

                userName= user.userName,
                Token= _tokenService.CreateToken(user)
            };
        }

        [HttpPost("login")]
        public async Task<ActionResult<UserDto>> Login(LoginDTO loginDTO)//loginDto
        {
            //see if user is registered
            var user = await _context.Users
            .SingleOrDefaultAsync(x => x.userName.ToLower() == loginDTO.userName.ToLower());
            if (user == null) return Unauthorized("Invalid username");


            //looking for password
            using var hmac = new HMACSHA512(user.PasswordSalt);

            var computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(loginDTO.Password));

            for (int i = 0; i < computedHash.Length; i++)
            {
                if (computedHash[i] != user.PasswordHash[i]) return Unauthorized("Invalid password");
            }


            return new UserDto{

                userName= user.userName,
                Token= _tokenService.CreateToken(user)
            };


        }

        private async Task<bool> UserExists(string username)
        {
            return await _context.Users.AnyAsync(x => x.userName == username.ToLower());
        }
    }
}