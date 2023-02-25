using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VarietyStoreAPI.Models;

namespace VarietyStoreAPI.Repositories.Interfaces {
    public interface IUserRepositorie {
        Task<List<User>> GetAllUsers();
        Task<User> GetById(int id);
        Task<User> Add(User user);
        Task<User> Update(User user, int id);
        Task<bool> Delete(int id);
    }
}
