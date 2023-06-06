using System;
using System.Threading.Tasks;

namespace NotesForms.Services
{
    public interface IAuthAPI
    {
        Task GetToken();
    }
}
