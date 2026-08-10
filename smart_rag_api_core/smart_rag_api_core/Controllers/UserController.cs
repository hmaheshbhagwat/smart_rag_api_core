using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using smart_rag_api_core.Data;
using smart_rag_api_core.Models;
using smart_rag_api_core.Models.Data;
using smart_rag_api_core.Models.DTO;
using smart_rag_api_core.Repositories;

namespace smart_rag_api_core.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IMapper mapper;
        private readonly IUserRepository userRepository;

        public UserController(RagDBContext dbContext, IUserRepository userRepository, IMapper mapper)
        {
            this.mapper = mapper;
            this.userRepository = userRepository;
        }
        [HttpGet]
        public async Task<IActionResult> AllUsersAsync()
        {
            var users = await userRepository.AllUsersAsync();
            var userDTOs = mapper.Map<List<UserDTO>>(users);
            return Ok(userDTOs);
        }

        [HttpGet("{id:Guid}")]
        public async Task<IActionResult> GetUserByID([FromRoute] Guid id)
        {
            var user = await userRepository.GetUserByIdAsync(id);
            var userDTO = mapper.Map<UserDTO>(user);
            if (user == null)
            {
                return NotFound();
            }
            return Ok(userDTO);
        }

        [HttpPost]

        public async Task<IActionResult> CreateUserAsync([FromBody] UserDTO userDTO)
        {
            var user = mapper.Map<User>(userDTO);
            await userRepository.CreateUserAsync(user);
            return CreatedAtAction(nameof(GetUserByID), new { id = user.Id }, user);
        }

        [HttpPut]
        [Route("{id:Guid}")]
        public async Task<IActionResult> UpdateAsync([FromRoute] Guid id, [FromBody] UserDTO userDTO)
        {
            var user = mapper.Map<User>(userDTO);
            user = await userRepository.UpdateAsync(id, user);
            if (user == null)
            {
                return NotFound();
            }
            var returnDTO = mapper.Map<UserDTO>(user);
            return Ok(returnDTO);
        }


        [HttpDelete]
        [Route("{id:Guid}")]
        public async Task<IActionResult> RemoveUserAsync([FromRoute] Guid id)
        {

            var user = await userRepository.DeleteAsync(id);
            if (user == null)
            {
                return NotFound();
            }
            return Ok();
        }
    }
}
