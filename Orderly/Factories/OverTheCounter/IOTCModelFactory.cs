using Orderly.Models.Comman;
using Orderly.Models.OTC;
using System.Threading.Tasks;

namespace Orderly.Factories.OverTheCounter
{
    public interface IOTCModelFactory
    {
        Task<OTCModel> PrepareOTCModel(int userId, int Id = 0);
        Task<OTCListModel> PrepareOTCListModel(int userId, OTCSearchModel searchModel);
    }
}
