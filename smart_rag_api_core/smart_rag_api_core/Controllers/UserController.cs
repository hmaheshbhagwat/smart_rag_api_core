using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Client;
using smart_rag_api_core.Data;
using smart_rag_api_core.Models;
using smart_rag_api_core.Models.Data;
using smart_rag_api_core.Models.DTO;

namespace smart_rag_api_core.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly RagDBContext dbContext;

        public UserController(RagDBContext dbContext)
        {
            this.dbContext = dbContext;
        }
        [HttpGet]
        public IActionResult AllUsers()
        {
            var userDTOs = dbContext.Users.Select(user => new UserDTO
            {
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email
            }).ToList();  
            return Ok(userDTOs);
        }
        
        [HttpGet("{id:Guid}")]
        public IActionResult GetUserByID([FromRoute] Guid id)
        {
            var user = dbContext.Users.FirstOrDefault(x => x.Id == id);
            var userDTO = new UserDTO
            {
               
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email
               
            };
            if (user == null)
            {
                return NotFound();
            }
            return Ok(userDTO);
        }

        [HttpPost]

        public IActionResult CreateUser([FromBody] UserDTO userDTO)
        {
          var user = new User
          {
              FirstName = userDTO.FirstName,
              LastName = userDTO.LastName,
              Email = userDTO.Email,
              Password = "defaultpassword",
              Id = new Guid()
          };
          dbContext.Users.Add(user);
          dbContext.SaveChanges();
          return CreatedAtAction(nameof(GetUserByID), new { id = user.Id }, user);
        }

        [HttpPut]
        [Route("{id:Guid}")]
        public IActionResult Update([FromRoute] Guid id, [FromBody] UserDTO userDTO)
        {
            var user = dbContext.Users.FirstOrDefault(x => x.Id == id);
            if(user == null)
            {
                return NotFound();
            }

            user.FirstName = userDTO.FirstName;
            user.LastName = userDTO.LastName;
            user.Email = userDTO.Email;
            dbContext.SaveChanges();

            var returnDTO = new UserDTO() { FirstName = user.FirstName, LastName = user.LastName, Email = user.Email };
            return Ok(returnDTO);
        }


        [HttpDelete]
        [Route("{id:Guid}")]
        public IActionResult RemoveUser([FromRoute] Guid id)
        {
            var user = dbContext.Users.FirstOrDefault(x => x.Id == id);
            if(user == null)
            {
                return NotFound();
            }
            dbContext.Users.Remove(user);
            dbContext.SaveChanges();
            return Ok();
        }
    }
}
