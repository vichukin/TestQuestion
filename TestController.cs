using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace TestQuestion.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestController : ControllerBase
    {
        [HttpPost("Delete/{id}")]
        public void Delete(uint id)
        {
            User user = _context.Users.FirstOrDefault(user => user.Id == id);
            if(user == null) return NotFound("Wrong id");
            _context.Users.Remove(user);
            _context.SaveChanges();
            Debug.WriteLine($"The User with login={user.login} has been deleted");
            return Ok();
        }
    }
    //Trzeba było sprawdzić czy istnieje użytkownik z takim Id
}
