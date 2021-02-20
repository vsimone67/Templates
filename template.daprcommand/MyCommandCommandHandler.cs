using System;
using System.Threading;
using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using Dapr.Client;
using Microsoft.Extensions.Options;

namespace MyNamespace.Application.Commands
{
    public class MyCommandCommandHandler : IRequestHandler<MyCommandCommand>
    {
        private readonly ILogger<MyCommandCommandHandler> _logger;
        private readonly IMapper _mapper;
        private readonly DaprClient _daprClient;
        private readonly IOptions<MyOptions> _settings;

        public MyCommandCommandHandler(ILogger<MyCommandCommandHandler> logger, IMapper mapper, DaprClient daprClient, IOptions<MyOptions> settings)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _daprClient = daprClient ?? throw new ArgumentNullException(nameof(daprClient));
            _settings = settings ?? throw new ArgumentNullException(nameof(settings));
        }

        public async Task<Unit> Handle(MyCommandCommand request, CancellationToken cancellationToken)
        {
            _logger.LogDebug($"Sending Topic: {_settings.Value.MyTopic}, PubSub Name: {_settings.Value.MyPubSub}");

            await _daprClient.PublishEventAsync(_settings.Value.MyPubSub, _settings.Value.MyTopic, request.MyName);

            _logger.LogDebug($"Topic: {_settings.Value.MyTopic} sent");
            return new Unit();
        }

    }
}
