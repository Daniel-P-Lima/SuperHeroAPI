using SuperHeroAPI.Entities;

namespace SuperHeroAPI.Interfaces;

public interface ISuperHeroService
{
    Task<List<SuperHero>> GetAllSuperHeroesService();
    Task<SuperHero> GetSuperHeroById(int id);
    Task<SuperHero> CreateSuperHero(SuperHero newHero);
    Task<SuperHero> UpdateSuperHeroService(SuperHero updatedHero);
    Task<bool> DeleteSuperHero(int id);
}
