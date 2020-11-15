using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using template.Service.Application.Dto;

namespace template.Service.Persistence.DbService
{
    public class DatabaseService : IDatabaseService
    {
        public async Task<List<MyDto>> GetData()
        {
            await Task.FromResult(1);
            return new List<MyDto>();
        }
    }
}
