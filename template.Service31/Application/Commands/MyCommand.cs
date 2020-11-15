using System;
using System.Collections.Generic;
using MediatR;
using template.Service.Application.Dto;

namespace template.Service.Application.Commands
{
    public class MyCommand : IRequest<MyDto>
    {

    }
}
