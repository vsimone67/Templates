using System.Collections.Generic;
using System.Threading.Tasks;
using template.Service.Application.Dto;

namespace template.Service.Persistence.DbService
{
    public interface IDatabaseService
    {
        Task<List<MyDto>> GetData();
    }
}
