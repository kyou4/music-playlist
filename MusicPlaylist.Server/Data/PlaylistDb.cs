namespace MusicPlaylist.Server.Data;

using Microsoft.EntityFrameworkCore;
using MusicPlaylist.Server.Models;

public class PlaylistDb : DbContext
{
    public PlaylistDb(DbContextOptions<PlaylistDb> options)
        : base(options) { }

    public DbSet<Playlist> Playlists { get; set; }
    public DbSet<Track> Tracks { get; set; }
}
