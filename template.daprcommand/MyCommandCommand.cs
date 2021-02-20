using System;
using MediatR;

namespace MyNamespace.Application.Commands
{
    public class MyCommandCommand : IRequest
    {
        public MyProperty MyName { get; set; }
    }
}
