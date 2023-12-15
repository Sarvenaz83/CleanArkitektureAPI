using Castle.Core.Logging;
using Domain.Models;
using Infrastructure.Database.MySQLDatabase;
using Microsoft.Extensions.Logging;

namespace Infrastructure.Repositories.Animal.Birds
{
    public class BirdRepository : IBirdRepository
    {
        private readonly RealDatabase _realDatabase;
        private readonly ILogger<BirdRepository> _logger;

        public BirdRepository(RealDatabase realDatabase, ILogger<BirdRepository> logger)
        {
            _realDatabase = realDatabase;
            _logger = logger;
        }

        public Task<Bird> AddNewBird(Bird newBird, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<Bird> DeleteBirdById(Guid id, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<List<Bird>> GetAllBirds(CancellationToken cancellationToken)
        {
            try
            {
                List<Bird> allBirdsFromRealDatabase = _realDatabase.Birds.ToList();

                return Task.FromResult(allBirdsFromRealDatabase);
            }
            catch (Exception ex)
            {
                _logger.LogError("An error occured while getting all birds from the database.");
                throw new Exception("An error occured while getting all birds from the database", ex);
            }
        }

        public Task<Bird> GetBirdById(Guid id, CancellationToken cancellationToken)
        {
            try
            {
                Bird wantedBird = _realDatabase.Birds.FirstOrDefault(bird => bird.Id == id)!;

                return Task.FromResult(wantedBird);
            }
            catch (Exception ex)
            {
                _logger.LogError("An error occured while getting a bird by id from the database.");
                throw new Exception("An error occured while getting a bird by id from the database", ex);
            }
        }

        public Task<Bird> UpdateBirdById(Guid id, string newName, bool canToFly, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
