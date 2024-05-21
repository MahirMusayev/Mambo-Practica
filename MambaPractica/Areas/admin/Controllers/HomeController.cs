using MambaPractica.DAL;
using MambaPractica.Models;
using MambaPractica.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace MambaPractica.Areas.admin.Controllers
{
	[Area("admin")]
	public class HomeController(MambaContext _context) : Controller
	{
		public async Task<IActionResult> Index()
		{
			List<Team> teams = await _context.Teams.ToListAsync();
			return View(teams);
		}
		public async Task<IActionResult> Create()
		{

			return View();
		}
		[HttpPost]
		public async Task<IActionResult> Create(CreateMambaVm cm)
		{
			if (!ModelState.IsValid) return View(cm);
			await _context.Teams.AddAsync(new Team
			{
				Name = cm.Name,
				profession = cm.profession,
				ImageUrl = cm.ImageUrl,
				Icons = cm.Icons,
			});
			await _context.SaveChangesAsync();
			return RedirectToAction(nameof(Index));
		}
		public async Task<IActionResult> Update(int? id)
		{
			if (id == null || id < 1) return BadRequest();
			Team team = await _context.Teams.FirstOrDefaultAsync(t => t.Id == id);
			if (team == null) return NotFound();
			return View(team);
		}
		[HttpPost]
		public async Task<IActionResult> Update(int? id, Team tm)
		{
			if (id == null || id < 1) return BadRequest();
			Team team = await _context.Teams.FirstOrDefaultAsync(t => t.Id == id);
			if (team == null) return NotFound();
			team.Name = tm.Name;
			team.profession = tm.profession;
			team.ImageUrl = tm.ImageUrl;
			team.Icons = tm.Icons;
			await _context.SaveChangesAsync();
			return RedirectToAction(nameof(Index));
		}
		public async Task<IActionResult> Delete(int? id)
		{
			if (id == null || id < 1) return BadRequest();
			var team = await _context.Teams.FindAsync(id);
			if (team == null) return NotFound();
			_context.Remove(team);
			await _context.SaveChangesAsync();
			return RedirectToAction(nameof(Index));

		}
	}
}
