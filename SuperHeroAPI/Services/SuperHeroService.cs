using Microsoft.EntityFrameworkCore;
using SuperHeroAPI.Data;
using SuperHeroAPI.Entities;
using SuperHeroAPI.Interfaces;

namespace SuperHeroAPI.Services;

public class SuperHeroService(DataContext _context) : ISuperHeroService
{
   public async Task<List<SuperHero>> GetAllSuperHeroesService()
    {
        var heroes = await _context.SuperHeroes.ToListAsync();
        if (heroes == null || heroes.Count == 0)
        {
            return null;
        }
        return heroes;
    }
    public async Task<SuperHero> GetSuperHeroById(int id)
    {
        var hero = await _context.SuperHeroes.FindAsync(id);
        if (hero == null)
        {
            return null;
        }
        return hero;
    }
    public async Task<SuperHero> CreateSuperHero(SuperHero newHero)
    {
        _context.SuperHeroes.Add(newHero);
        await _context.SaveChangesAsync();
        return newHero;
    }
    public async Task<SuperHero> UpdateSuperHeroService(SuperHero updatedHero)
    {
        var hero = await _context.SuperHeroes.FindAsync(updatedHero.Id);
        if (hero == null)
        {
            return null;
        }

        hero.Name = updatedHero.Name;
        hero.FirstName = updatedHero.FirstName;
        hero.LastName = updatedHero.LastName;
        hero.Place = updatedHero.Place;

        await _context.SaveChangesAsync();

        return hero;
    } 

    public async Task<bool> DeleteSuperHero(int id)
    {
        var hero = await _context.SuperHeroes.FindAsync(id);
        if (hero == null)
        {
            return false;
        }
        _context.SuperHeroes.Remove(hero);
        await _context.SaveChangesAsync();
        return true;
    }
}
