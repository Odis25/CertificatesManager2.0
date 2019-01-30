using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;

namespace CertificatesModel.Domain.UsersModel
{
    public class Users : BindingList<User> // IEnumerable<User>
    {
        public Users(List<User> list) : base(list)
        {

        }
        //protected BindingList<User> _bindingList;
        //protected List<User> _users;

        //public Users()
        //{
        //    _users = new List<User>();
        //    _bindingList = new BindingList<User>();
        //}

        //public Users(List<User> users)
        //{
        //    _users = users;
        //    _bindingList = new BindingList<User>(_users);
        //}

        //public IEnumerator<User> GetEnumerator()
        //{
        //    //return _users.GetEnumerator();
        //    return _bindingList.GetEnumerator();
        //}

        //IEnumerator IEnumerable.GetEnumerator()
        //{
        //    return GetEnumerator();
        //}

        //public static implicit operator Users(List<User> v)
        //{
        //    return new Users(v);
        //}

        //// Поиск элемента
        //public User Find(Predicate<User> p)
        //{
        //    return _users.Find(p);
        //}

        //// Удаление элемента
        //public void Remove(User user)
        //{
        //    _users.Remove(user);
        //    _bindingList.Remove(user);
        //}
    }
}
