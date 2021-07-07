using Microsoft.AspNetCore.Mvc;
using API.Entities;
using API.Controllers.Data;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using MicrosoftEntityFrameworkCore;

namespace API.Controllers
{
    [ApiController]
    [Route("api/controller")]
    public class UsersController : ControllerBase
    {
        private readonly DataContext _context;
        public UsersController(DataContext context)
        {
            _context = context;

        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<AppUser>>> GetUsers()
        {
           return await _context.Users.ToListAsync();
        }
 
        [HttpGet("{id}")]
        public Task<ActionResult<AppUser>> GetUser(int id)
        {
          return await _context.Users.FindAsynch(id);

        }
    }
}