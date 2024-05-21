using MambaPractica.DAL;
using MambaPractica.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace MambaPractica.Controllers
{
	public class HomeController(MambaContext _context) : Controller
	{
		

		public async Task<IActionResult> Index()
		{
			List<Team> teams = await _context.Teams.ToListAsync();
			return View(teams);
		}

		
	}
}
