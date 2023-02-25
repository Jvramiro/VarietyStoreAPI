using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VarietyStoreAPI.Models;
using VarietyStoreAPI.Repositories.Interfaces;

namespace VarietyStoreAPI.Controllers {
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase {

        private readonly IUserRepositorie _IUserRepositorie;
        public UserController(IUserRepositorie IUserRepositorie) {
            _IUserRepositorie = IUserRepositorie;
        }

        [HttpGet]
        public async Task<ActionResult<List<User>>> GetAllUsers() {
            List<User> users = await _IUserRepositorie.GetAllUsers();
            return Ok(users);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<List<User>>> GetUserById(int id) {
            User currentUser = await _IUserRepositorie.GetById(id);
            return Ok(currentUser);
        }

        [HttpPost]
        public async Task<ActionResult<User>> CreateUser([FromBody] User user) {
            User currentUser = await _IUserRepositorie.Add(user);
            return Ok(currentUser);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<User>> UpdateUser([FromBody] User user, int id) {
            user.id = id;
            User currentUser = await _IUserRepositorie.Update(user, id);
            return Ok(currentUser);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<User>> UpdateUser(int id) {
            bool isDeleted = await _IUserRepositorie.Delete(id);
            return Ok(isDeleted);
        }

    }
}
