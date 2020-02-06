using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bandymas.Services
{
    public interface IUserService
    {
        Task<bool> ValidateCredentials(string userName, string password, out User user);
    }

   public class User 
    {   
        public User(string userName)
        {
            UserName = userName;
        }

        public string UserName { get; }
    }
}
