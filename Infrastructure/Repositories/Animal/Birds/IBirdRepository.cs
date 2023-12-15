using Domain.Models;

namespace Infrastructure.Repositories.Animal.Birds
{
    public interface IBirdRepository
    {
        Task<List<Bird>> GetAllBirds(CancellationToken cancellationToken);
        Task<Bird> GetBirdById(Guid id, CancellationToken cancellationToken);
        Task<Bird> AddNewBird(Bird newBird, CancellationToken cancellationToken);
        Task<Bird> DeleteBirdById(Guid id, CancellationToken cancellationToken);
        Task<Bird> UpdateBirdById(Guid id, string newName, bool canToFly, CancellationToken cancellationToken);

    }
}
