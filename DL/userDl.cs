using Entities;
using System;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace DL
{
    public class userDl : IuserDl
    {
        Production_aaContext Production_aaContext;
        public userDl(Production_aaContext Production_aaContext)
        {
            this.Production_aaContext = Production_aaContext;
        }

        public async Task<User> Get(string email, int password)
        {
            User users = Production_aaContext.Users
                .Where(user => user.Email == email && user.Password == password)
                .FirstOrDefault();
            if (users == null)
                return null;
            return users;
        }


        public async Task<User> Post(User user)
        {
            await Production_aaContext.Users.AddAsync(user);
            await Production_aaContext.SaveChangesAsync();
            return user;

        }

        public async Task<User> Put(User user, int id)
        {
            var curront_user = await Production_aaContext.Users.FindAsync(id);
            Production_aaContext.Entry(curront_user).CurrentValues.SetValues(user);
            await Production_aaContext.SaveChangesAsync();
            return curront_user;
        }
    }
        
    }
