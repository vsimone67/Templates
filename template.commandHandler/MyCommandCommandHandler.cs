using System;
using System.Threading;
using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace MyNamespace.Application.Commands
{
    public class MyCommandCommandHandler : IRequestHandler<MyCommandCommand>
    {
        private readonly ILogger _logger;
        private readonly IMapper _mapper;

        public MyCommandCommandHandler(ILogger logger, IMapper mapper)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<Unit> Handle(MyCommandCommand request, CancellationToken cancellationToken)
        {            
            _logger.LogDebug("Handler Done...");
            return new Unit();
        }

    }
}
