using Datalayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datalayer.repository
{
    public class Repository
    {
        Datacontext datacontext = new Datacontext();

        public void addUser(User user)
        {
            datacontext.Users.Add(user);
        }

        public void addFriend(Friend friend)
        {
            datacontext.Friends.Add(friend);
        }

        public void saveUser()
        {
            datacontext.SaveChanges();
        }



    }
}
