using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SuperHeroAPI.Data;
using SuperHeroAPI.Entities;

namespace SuperHeroAPI.Controllers;




[ApiController]
[Route("api/[controller]")]
public class SuperHeroController : ControllerBase
{
    private readonly DataContext _context;

    public SuperHeroController(DataContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<List<SuperHero>>> Get()
    {
        var heroes = await _context.SuperHeroes.ToListAsync();

        return Ok(heroes);
    }

    [HttpGet("{id}")]
    public ActionResult<SuperHero> GetSuperHero(int id)
    {
        var hero = _context.SuperHeroes.Find(id);
        if (hero == null)
            return NotFound("Hero not found.");

        return Ok(hero);

    }

    [HttpPost]
    public async Task<ActionResult<SuperHero>> CreateSuperHero(SuperHero newHero)
    {
        _context.SuperHeroes.Add(newHero);
        _context.SaveChanges();

        return NoContent();
    }

    [HttpPut]
    public async Task<ActionResult<SuperHero>> UpdateSuperHero(SuperHero updatedHero)
    {
        var hero = await _context.SuperHeroes.FindAsync(updatedHero.Id);
        if (hero == null)
        {
            return NotFound("Hero not found.");
        }

        hero.Name = updatedHero.Name;
        hero.FirstName = updatedHero.FirstName;
        hero.LastName = updatedHero.LastName;
        hero.Place = updatedHero.Place;

        await _context.SaveChangesAsync();

        return Ok(hero);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<SuperHero>> DeleteSuperHero(int id)
    {
        var hero = await _context.SuperHeroes.FindAsync(id);
        if (hero == null)
        {
            return NotFound("Hero not found.");
        }

        _context.SuperHeroes.Remove(hero);

        await _context.SaveChangesAsync();

        return Ok();
    }
}
