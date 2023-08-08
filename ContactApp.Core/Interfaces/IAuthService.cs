using System;
using System.Threading.Tasks;
using ContactApp.Core.Entities;

namespace ContactApp.Core.Interfaces
{
    public interface IAuthService
    {
        User CurrentUser { get; }
        
        Task<bool> SignInAsync( string userName, string password);
        Task<bool> SignOutAsync();
        Task<bool> RefreshAuth();
    }
}
