using Arthman.Models;
using System.Threading.Tasks;
using MongoDB.Driver;
using MongoDB.Bson;

namespace Arthman.MongoDb
{
    //TODO: repository base class with generics
    public interface IWeightsRepository
    {
        Task<string> CreateAsync(WeightEntry weightEntry);
    }

    public class WeightsRepository : IWeightsRepository
    {
        //TODO: should be a base repo ..
        private IMongoCollection<WeightEntry> _collection { get; set; }

        public WeightsRepository(IMongoContext mongoContext)
        {
            _collection = mongoContext.Database.GetCollection<WeightEntry>("weights");
        }

        public async Task<string> CreateAsync(WeightEntry weightEntry)
        {
            weightEntry.Id = ObjectId.GenerateNewId().ToString();
            await _collection.InsertOneAsync(weightEntry);
            return weightEntry.Id;
        }
    }
}
