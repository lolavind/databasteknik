using Microsoft.AspNetCore.Mvc;
using databasteknik.models;

namespace databasteknik.Controllers;

public class PlaylistController : Controller
{
	// Skapar statisk lista med spellistor
	private static List<Playlist> playlists = CreateDemoPlaylists();

	// Skapar demo-spellistor (lista med spellistor)
	public static List<Playlist> CreateDemoPlaylists()
	{
		return new List<Playlist>
		{
			new Playlist
			{
				PlaylistId = 1,
				PlaylistName = "Music I like",
				Songs = new List<Song>
				{
					new Song { SongId = 1, Title = "The Giver", Length = new TimeSpan(0,3,23) },
					new Song { SongId = 2, Title = "Love Me Not", Length = new TimeSpan(0,3,33) },
					new Song { SongId = 5, Title = "Eternity", Length = new TimeSpan(0,3,10) },
					new Song { SongId = 6, Title = "WHERE IS MY HUSBAND!", Length = new TimeSpan(0,3,17) }
				}
			},
			new Playlist
			{
				PlaylistId = 2,
				PlaylistName = "2025 Hits",
				Songs = new List<Song>
				{
					new Song { SongId = 3, Title = "Harness Your Hopes", Length = new TimeSpan(0,3,27) },
					new Song { SongId = 4, Title = "So Easy (To Fall In Love)", Length = new TimeSpan(0,2,49) }
				}
			}
		};
	}

	// Visa alla spellistor
	public IActionResult MyPlaylists()
	{
		if (HttpContext.Session.GetString("CurrentUser") == null)
			return RedirectToAction("Login", "Account");

		ViewBag.Title = "Mina Spellistor";

		// Skicka modellen (listan med spellistor) till vyn
		return View(playlists);
	}

	// Inspektera en spellista och dess låtar
	public IActionResult Inspect(int id)
	{
		if (HttpContext.Session.GetString("CurrentUser") == null)
			return RedirectToAction("Login", "Account");

		// För varje spellista p, kolla om p.PlaylistId matchar det id som skickats in i URL:en.
		// Om ingen spellista matchar, returnera null.
		var playlist = playlists.FirstOrDefault(p => p.PlaylistId == id);

		// Om ingen spellista hittas, omdirigera tillbaka till MyPlaylists
		if (playlist == null)
			return RedirectToAction("MyPlaylists");

		// Skicka antalet låtar i spellistan till vyn
		ViewData["SongCount"] = playlist.Songs.Count;

		return View(playlist);
	}

	// Ta bort en spellista
	public IActionResult DeletePlaylist(int id)
	{
		var playlist = playlists.FirstOrDefault(p => p.PlaylistId == id);

		if (playlist != null)
			playlists.Remove(playlist);

		return RedirectToAction("MyPlaylists");
	}

	// Ta bort en låt
	public IActionResult DeleteSong(int playlistId, int songId)
	{
		// För varje spellista p, kolla om p.PlaylistId matchar det id som skickats in i URL:en.
		// Om ingen spellista matchar, returnera null.
		var playlist = playlists.FirstOrDefault(p => p.PlaylistId == playlistId);

		// Om en spellista hittas, leta upp låten i spellistan som matchar det songId som skickats in i URL:en.
		if (playlist != null)
		{
			var song = playlist.Songs.FirstOrDefault(s => s.SongId == songId);

			if (song != null)
				playlist.Songs.Remove(song);
		}

		return RedirectToAction("Inspect", new { id = playlistId });
	}
}