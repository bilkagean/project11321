using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace api.Controllers
{
    //this class is for getting user datas all by id from database
   [Authorize]
    public class UsersController : BaseApiController
    {
        private readonly Data.DataContext _context;
        public UsersController(Data.DataContext context)
        {
            _context = context;

        }

        [HttpGet]
       
        public async Task<ActionResult<IEnumerable<Entities.AppUser>>> GetUsers()
        {
            var users = _context.Users.ToListAsync();
            return await users;    
        }
  
        [HttpGet("{id}")]
        public async Task<ActionResult<Entities.AppUser>> GetUser(int id)
        {
            var user = _context.Users.FindAsync(id);
            return await user;

        }
    }
}