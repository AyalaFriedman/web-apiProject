using DL;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BL
{
    public class userBL : IuserBL
    {
        IuserDl iuserDl;
        public userBL(IuserDl iuserDl)
        {
            this.iuserDl = iuserDl;
        }
        public async Task<User> Get(string email, int password)
        {
            User user = await iuserDl.Get(email, password);
            return user;
        }
        public async Task<User> Post(User user)
        {
            User user1 = await iuserDl.Post(user);
            return user1;
        }
        public async Task<User> Put(User user, int id)
        {
            await iuserDl.Put(user, id);
            return user;
        }

    }
}
