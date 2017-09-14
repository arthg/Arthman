using Arthman.MongoDb;
using System.Threading.Tasks;
using Arthman.Models;

namespace Arthman.api.Weights
{
    public interface IWeightsService
    {
        Task<string> AddWeightAsync(CreateWeightRequest createWeightRequest);
    }

    public class WeightsService : IWeightsService
    {
        private IWeightsRepository _weightsRepository;

        public WeightsService(IWeightsRepository weightsRepository)
        {
            _weightsRepository = weightsRepository;
        }
          
        public async Task<string> AddWeightAsync(CreateWeightRequest createWeightRequest)
        {            
            //TODO: CreateWeightRequest -> WeightEntry mapper
            //TODO: hit Event Store!!! <- this what we are after 
            //TODO: there should be a workflow with activities .. Create + NotifyEvent + ..
            var newId = await _weightsRepository.CreateAsync(new WeightEntry { Weight = createWeightRequest.Weight });
            return newId;                
        }
    }
}
