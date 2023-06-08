using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ContactApp.Core.Entities;
using ContactApp.Core.Repository.SQLite;
using NotesForms.Services;
using NotesForms.Converters;
namespace NotesForms.Repository
{
    public class UserService : IUserService
    {
        public IList<User> GetAll()
        {
            return new List<User>();
        }

        /*public async Task<IList<User>> GetAllAsync()
        {
            var List = new List<User>();

            return await Task.FromResult( List );
        }*/

        public User GetByID(string userName)
        {
            var User = Connection.Instance.Table<User>().FirstOrDefault( u => u.UserName == userName );

            return User;
        }

        public bool Store(User Entity)
        {
            var result = Connection.Instance.Insert( Entity );

            if (result > 0) return true;
            else return false;

        }

        public bool Update(User entity)
        {
            Connection.Instance.Update( entity );
            return true;
        }
    }
}

