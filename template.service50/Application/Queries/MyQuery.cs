using System;
using System.Collections.Generic;
using MediatR;
using template.Service.Application.Dto;

namespace template.Service.Application.Queries
{
    public class MyQuery : IRequest<List<MyDto>>
    {

    }
}
