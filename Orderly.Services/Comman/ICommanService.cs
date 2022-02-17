using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Orderly.Services.Comman
{
    public interface ICommanService
    {
        /// <summary>
        /// This method is to get the API key on the basis of network id
        /// </summary>
        /// <param name="networkId">NetworkId i.e. 1 for Bitcoin 2 for Eth.</param>
        /// <returns></returns>
        string GetApiByKey(int networkId, bool proAPI = false);

        /// <summary>
        /// get Up Down arrow html
        /// </summary>
        /// <param name="Direction"></param>
        /// <returns></returns>
        string getArrowHtmlbyDirection(int Direction);

        /// <summary>
        /// get current and last24 hrs price
        /// </summary>
        /// <param name="networkSymbol"></param>
        /// <param name="networkId"></param>
        /// <returns></returns>
        Task<Tuple<decimal, decimal>> GetCurrentAndLast24HrsPrice(string networkSymbol, int networkId);
    }
}
