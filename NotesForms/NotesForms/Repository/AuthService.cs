using System;
using System.Threading.Tasks;
using ContactApp.Core.Entities;
using ContactApp.Core.Repository.SQLite;
using NotesCarlos.Core.Models.API;
using NotesForms.Services;

namespace NotesForms.Repository
{
    public class AuthService : IAuthService
    {
        #region Props
        public User CurrentUser { get; set; }
        #endregion Props

        public Task<bool> RefreshAuth()
        {
            return Task.FromResult(false);
        }

        public async Task<bool> SignInAsync(string userName, string password)
        {
            //->DEBUG: Are there users
            //var userList = Connection.Instance.Table<User>().ToList();

            //foreach (var item in userList)
            //    Console.WriteLine("Item: " + item.UserName);

            var User = Connection.Instance.Table<User>().FirstOrDefault(u => u.UserName == userName);

            if (User == null) return await Task.FromResult( false );

            if ( User != null              &&
                User.UserName == userName &&
                User.PassWord == password)
            {
                CurrentUser = User;

                return await Task.FromResult( true );
            }

            return await Task.FromResult( false );
        }

        public async Task<bool> SignOutAsync()
        {
            CurrentUser = null;

            return await Task.FromResult(true);
        }
    }
}

