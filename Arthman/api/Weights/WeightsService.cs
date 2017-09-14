using System.Threading.Tasks;

namespace Arthman.api.Weights
{
    public interface IWeightsService
    {
        Task<string> AddWeightAsync(CreateWeightRequest createWeightRequest);
    }

    public class WeightsService : IWeightsService
    {
        public async Task<string> AddWeightAsync(CreateWeightRequest createWeightRequest)
        {
            //TODO: create a weights repository and inject it and call the Create method
            //TODO: hit Event Store!!! <- this what we are after 
            return string.Empty;                
        }
    }
}
