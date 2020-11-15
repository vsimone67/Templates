using System;
using System.Threading;
using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.DependencyInjection;
using System.Threading.Tasks;
using MassTransit;

namespace MyNamespace.Application.Commands
{
    public class MyCommandCommandHandler : IRequestHandler<MyCommandCommand>
    {
        private readonly ILogger _logger;
        private readonly IMapper _mapper;
        private readonly ISendEndpointProvider _serviceBus;


        public MyCommandCommandHandler(IServiceProvider serviceProvider)
        {
            _logger = serviceProvider.GetService<ILogger<MyCommandCommandHandler>>();
            _mapper = serviceProvider.GetService<IMapper>();
            _serviceBus = serviceProvider.GetService<ISendEndpointProvider>();
        }

        public async Task<Unit> Handle(MyCommandCommand request, CancellationToken cancellationToken)
        {
            var mibToSubmit = new MibSubmitted() { FirstName = "MyFirstName", LastName = "MyLastName", Dob = new DateTime(2000, 01, 15) };
            await _serviceBus.Send(mibToSubmit);
            _logger.LogDebug("Mib Sent");
            return new Unit();
        }

    }
}
