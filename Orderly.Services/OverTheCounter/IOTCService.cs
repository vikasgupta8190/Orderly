using Orderly.Core.Domain.OverTheCounter;
using Orderly.Models.Comman;
using Orderly.Models.OTC;

using System.Collections.Generic;
using System.Threading.Tasks;

namespace Orderly.Services.OverTheCounter
{
    public interface IOTCService
    {
        Task<IList<OTC>> GetAll();
        Task<OTC> GetById(int Id);
        Task InsertOrUpdateOTC(OTCModel otcModel);
        Task<IPagedList<OTC>> GetAll(int userId, int pageIndex, int pageSize);
        Task ArchiveOTC(int hours);
        Task<List<int>> GetAssignedTokenIds(int userId);
    }
}
