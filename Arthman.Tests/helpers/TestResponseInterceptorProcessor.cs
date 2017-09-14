using System;
using System.Collections.Generic;
using System.Linq;
using Nancy;
using Nancy.Responses;
using Nancy.Responses.Negotiation;

namespace Arthman.Tests.helpers
{
    //used to intercept the response object, so we don't have to deal with jsons in tests
    // ReSharper disable once ClassNeverInstantiated.Global
    public sealed class TestResponseInterceptorProcessor : IResponseProcessor
    {
        private readonly Action<object> _responseSetterAction;
        private readonly ISerializer _serializer;

        public TestResponseInterceptorProcessor(IEnumerable<ISerializer> serializers, Action<object> responseSetterAction)
        {
            _responseSetterAction = responseSetterAction;
            _serializer = serializers.First();
        }

        public ProcessorMatch CanProcess(MediaRange requestedMediaRange, dynamic model, NancyContext context)
        {
            return new ProcessorMatch
            {
                ModelResult = MatchResult.DontCare,
                RequestedContentTypeResult = MatchResult.ExactMatch
            };
        }

        public Response Process(MediaRange requestedMediaRange, dynamic model, NancyContext context)
        {
            _responseSetterAction(model);
            return new JsonResponse(model, _serializer, context.Environment);
        }

        public IEnumerable<Tuple<string, MediaRange>> ExtensionMappings
        {
            get { return new List<Tuple<string, MediaRange>>(); }
        }
    }
}