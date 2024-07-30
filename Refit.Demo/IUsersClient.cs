using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Refit.Demo
{
    public interface IUsersClient
    {
        [Get("/users")]
        Task<IEnumerable<User>> GetAll(); 

        [Get("/users/{id}")]
        Task<User> GetUser(int id);

        [Post("/users")]
        Task<User> CreateUser([Body] User user);

        [Put("/users/{id}")]
        Task<User> UpdateUser(int id, [Body] User user);

        [Delete("/users/{id}")]
        Task DeleteUser(int id);
    }
}
