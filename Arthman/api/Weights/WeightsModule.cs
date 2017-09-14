using Arthman.api.Common;
using Nancy;
using Nancy.ModelBinding;

namespace Arthman.api.Weights
{
    public class WeightsModule : NancyModule
    {
        public WeightsModule(IWeightsService weightsService)
            : base(RootUriStrings.Weights)
        {
            Post("/", async _ =>
            {
                //TODO: bind to CreateWeightRequestDto
                //TODO: validate DTO
                //TODO: map DTO -> BO
                var newWeightRequest = this.Bind<CreateWeightRequest>();
                var newId = await weightsService.AddWeightAsync(newWeightRequest);
                return Negotiate
                    .WithModel(new { id = newId })
                    .WithHeader("Location", RootUriStrings.Weights + newId)
                    .WithStatusCode(HttpStatusCode.Created);
            });
        }
    }
}
