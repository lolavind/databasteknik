using Microsoft.AspNetCore.Mvc;
using databasteknik.models;

namespace databasteknik.Controllers;

public class AccountController : Controller
{
    // Hårdkodad demo-användare
    private static User demoUser = new User
    {
        UserId = 1,
        UserName = "test",
        Password = "1234"
    };

    [HttpGet]
    public IActionResult Login()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Login(string username, string password)
    {
		// Kontrollera användarnamn och lösenord mot demo-användaren
        if(username == demoUser.UserName && password == demoUser.Password)
        {
            // Spara användarnamnet i session
            HttpContext.Session.SetString("CurrentUser", demoUser.UserName);

			// Vid lyckad inloggning, omdirigera till spellistor
            return RedirectToAction("MyPlaylists", "Playlist");
        }

		// Om inloggningen misslyckas, visa ett felmeddelande
        ViewBag.Error = "Fel användarnamn eller lösenord";
        return View();
    }

    public IActionResult Logout()
	{
		// Rensar sessionen
		HttpContext.Session.Clear();

		// Omdirigera till inloggningssidan
		return RedirectToAction("Login");
	}
}