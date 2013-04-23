using System.Collections.Generic;
using System.Linq;
using System.Web.Security;
using SpeedLord.Interfaces.Repositories;
using SpeedLord.Dto;

namespace SpeedLord.Repositories.Fake
{
    public class FakeAccountRepository : IAccountRepository
    {
        private IList<User> _users;

        public FakeAccountRepository()
        {
            _users = new List<User>
                         {
                             new User {UserName = "eric", Password = "test"}
                         };
        }

        public bool LoginUser(string userName, string password)
        {
            if(_users.All(i => i.UserName != userName) || _users.First(i=> i.UserName == userName).Password != password)
                return false;

            return true;
        }

        public bool RegisterUser(string userName, string password, string matchPassword)
        {
            if (_users.Any(i => i.UserName == userName)) //username exists
                throw new MembershipCreateUserException(MembershipCreateStatus.DuplicateEmail);

            if (password != matchPassword)
                throw new MembershipCreateUserException(MembershipCreateStatus.InvalidPassword);

            _users.Add(new User{ UserName = userName, Password = password});

            return true;
        }


        public bool ChangePassword(string userName, string password, string matchPassword)
        {
            if (_users.All(i => i.UserName != userName)) //username exists check
                throw new MembershipCreateUserException(MembershipCreateStatus.InvalidUserName);

            var usr = _users.First(i => i.UserName == userName);
            usr.Password = password;

            return true;
        }
    }
}
