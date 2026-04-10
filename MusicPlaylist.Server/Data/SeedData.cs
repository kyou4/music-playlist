using Microsoft.EntityFrameworkCore;
using MusicPlaylist.Server.Models;

namespace MusicPlaylist.Server.Data;

public class SeedData
{
    public static void Initialize(IServiceProvider serviceProvider)
    {
        using var context = serviceProvider.GetRequiredService<PlaylistDb>();

        if (context is null)
        {
            throw new InvalidOperationException("PlaylistDb context not defined");
        }
        if (context.Playlists.Any())
        {
            return;
        }
        context.AddRange(
            new List<Playlist>()
            {
                new Playlist { Id = 1, Title = "Kpop" },
                new Playlist { Id = 2, Title = "Classical" },
            }
        );

        context.AddRange(
            new List<Track>()
            {
                new Track
                {
                    Id = 1,
                    Title = "Dlwlrma",
                    Artist = "IU",
                    PlaylistId = 1,
                },
                new Track
                {
                    Id = 2,
                    Title = "Ending Scene",
                    Artist = "IU",
                    PlaylistId = 1,
                },
                new Track
                {
                    Id = 3,
                    Title = "Through the Night",
                    Artist = "IU",
                    PlaylistId = 1,
                },
            }
        );
        context.SaveChanges();
    }
}
