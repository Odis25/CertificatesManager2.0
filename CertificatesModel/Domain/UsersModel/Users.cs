using System;
using System.Collections;
using System.Collections.Generic;

namespace CertificatesModel.Domain.UsersModel
{
    public class Users : IEnumerable<User>
    {

        protected List<User> _users;

        public Users()
        {
            _users = new List<User>();
        }

        public Users(List<User> users)
        {
            _users = users;
        }

        public IEnumerator<User> GetEnumerator()
        {
            return _users.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public static implicit operator Users(List<User> v)
        {
            return new Users(v);
        }
    }
}
