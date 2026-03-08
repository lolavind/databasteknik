using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using databasteknik.Models;
using databasteknik.models;

namespace databasteknik.Controllers;

public class UserController : Controller
{
    static IList<User> usersList = new List<User>
    {
        new User { UserId = 1, UserName = "newuser1", Email = "bla@gmail.com", Password = "password123" },
		new User { UserId = 2, UserName = "newuser2", Email = "bla@gmail.com", Password = "password123" },
		new User { UserId = 3, UserName = "newuser3", Email = "bla@gmail.com", Password = "password123" }
    };
    /* public IActionResult Index()
    {
        return View();
    } */

	//Get users
	public IActionResult Users()
	{
		//Fetch students from DB
		return View(usersList);
	}

}
