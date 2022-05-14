using System.Collections.Generic;
using System.Threading.Tasks;
using WowWeb.Shared;

namespace WowWeb.Client.Services
{
    public interface IGenreService
    {
        List<Genre> Genres { get; set; }

        Task GetGenres();
    }
}