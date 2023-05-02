using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace dotNetApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {


        private static List<User> users = new List<User>
           {
               new User        {
                   ID = 1,
                   FirstName = "Test",
                   LastName = "Test",
                   Title = "Test"
               },
               new User        {
                   ID = 2,
                   FirstName = "Test2",
                   LastName = "Test2",
                   Title = "Test2"
               }
           };



        [HttpGet]

        public async Task<ActionResult<List<User>>> Get (){
         
            return Ok(users);
        }

        [HttpGet("{id}")]

        public async Task<ActionResult<User>> GetUser(int id)
        {
            var user = users.Find(U => U.ID == id );
            if (user == null)
                return BadRequest("User Not Found");

            return Ok(user);
        }

        [HttpPost]

        public async Task<ActionResult<List<User>>> Add([FromBody] User user)
        {
            users.Add(user);
            return Ok(users);
        }


        [HttpPut]

        public async Task<ActionResult<List<User>>> edit([FromBody] User userEdit)
        {
            var user = users.Find(U => U.ID == userEdit.ID);

            if (user == null)
                return BadRequest("User Not Found");

            user.FirstName = userEdit.FirstName;    
            user.LastName = userEdit.LastName;  
            user.Title = userEdit.Title;

            return Ok(users);
        }

        [HttpDelete("{id}")]

        public async Task<ActionResult<List<User>>> DeleteUser(int id)
        {
            var user = users.Find(U => U.ID == id);
            if (user == null)
                return BadRequest("User Not Found");
            users.Remove(user);
            return Ok(users);
        }


    }
}
