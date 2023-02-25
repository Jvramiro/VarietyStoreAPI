using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VarietyStoreAPI.Data;
using VarietyStoreAPI.Models;
using VarietyStoreAPI.Repositories.Interfaces;

namespace VarietyStoreAPI.Repositories {
    public class UserRepositorie : IUserRepositorie {

        private readonly ManagerSystemDBContext _dbContext;
        public UserRepositorie(ManagerSystemDBContext dbContext) {
            _dbContext = dbContext;
        }

        public async Task<User> GetById(int id) {
            return await _dbContext.Users.FirstOrDefaultAsync(x => x.id == id);
        }
        public async Task<List<User>> GetAllUsers() {
            return await _dbContext.Users.ToListAsync();
        }
        public async Task<User> Add(User user) {
            await _dbContext.Users.AddAsync(user);
            await _dbContext.SaveChangesAsync();

            return user;
        }
        public async Task<User> Update(User user, int id) {
            User currentUser = await GetById(id);

            if(currentUser == null) {
                throw new Exception($"User {id} not found");
            }

            currentUser.Username = string.IsNullOrEmpty(user.Username) ? currentUser.Username : user.Username;
            currentUser.Email = string.IsNullOrEmpty(user.Email) ? currentUser.Email : user.Email;
            currentUser.Password = string.IsNullOrEmpty(user.Password) ? currentUser.Password : user.Password;
            currentUser.Role = user.Role == 0 ? currentUser.Role : user.Role;

            _dbContext.Users.Update(currentUser);
            await _dbContext.SaveChangesAsync();

            return currentUser;
        }
        public async Task<bool> Delete(int id) {
            User currentUser = await GetById(id);

            if (currentUser == null) {
                throw new Exception($"User {id} not found");
            }

            _dbContext.Users.Remove(currentUser);
            await _dbContext.SaveChangesAsync();

            return true;
        }
    }
}
