using Microsoft.AspNetCore.Mvc;

using databasteknik.models;

namespace databasteknik.Controllers;

public class MusicController : Controller
{
    private static List<Song> Songs = new List<Song>();
	/* {
		new Song { SongId = 1, Title = "Bohemian Rhapsody", Length = 354 },
		new Song { SongId = 2, Title = "Stairway to Heaven", Length = 482 },
		new Song { SongId = 3, Title = "Hotel California", Length = 390 }
	}; */
	

    public IActionResult Home()
    {
        ViewBag.Meddelande = "Välkommen till musikappen";
        return View();
    }

    public IActionResult NewSong()
    {
        return View();
    }

    [HttpPost]
    public IActionResult NewSong(Song Song)
    {
        Songs.Add(Song);

        HttpContext.Session.SetString("SenasteLåt", Song.Title);

        return RedirectToAction("ShowSongs");
    }

    public IActionResult ShowSongs()
    {
        ViewData["AntalLåtar"] = Songs.Count;

        return View(Songs);
    }
}