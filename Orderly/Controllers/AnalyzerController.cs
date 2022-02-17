using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using Orderly.Factories.Analyzer;
using Orderly.Models.Analyzer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Orderly.Controllers
{
    [Authorize]
    public class AnalyzerController : Controller
    {
        #region Properties
        private readonly IAnalyzerModelFactory _analyzerModelFactory;
        #endregion

        public AnalyzerController(IAnalyzerModelFactory analyzerModelFactory)
        {
            _analyzerModelFactory = analyzerModelFactory;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult DistributionTransactions(string txHash, int networkId, int id)
        {
            ViewBag.TxHash = txHash;
            ViewBag.NetworkId = networkId;
            ViewBag.Id = id;
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> InvestmentAnalyerList(InvestmentAnalyzerSearchModel searchModel)
        {
            var model = await _analyzerModelFactory.PrepareInvestmentAnalyzerListModelAsync(searchModel);
            if (model.Data.Any())
            {
                model.WholeTimeInvestedAmount = model.Data.Sum(x => x.InvestedAmount);
                model.CurrentAmountOfInvestedAmt = model.Data.Sum(x => x.CurrentAmountOfInvestedAmount);
                model.profitLossOnInvestment = await CalculateProfitLoss(model.WholeTimeInvestedAmount, model.CurrentAmountOfInvestedAmt);
            }
            return Json(model);
        }

        private async Task<string> CalculateProfitLoss(decimal investedAmount, decimal currentAmountOfInvestedAmount)
        {
            var result = ((currentAmountOfInvestedAmount - investedAmount) * 100) / investedAmount;
            return Convert.ToString(Math.Round(result, 2)) + "%";
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> InvestmentDistributionList(DistributionTransactionSearchModel searchModel, string txHash, int networkId)
        {
            searchModel.NetworkId = networkId;
            searchModel.TransactionLink = txHash;
            var model = await _analyzerModelFactory.PrepareInvestmentDistributionListModelAsync(searchModel);
            return Json(model);
        }

        public async Task<IActionResult> GetFiltersData(int type)
        {
            bool isSuccess = true;
            object optionData = new object();
            try
            {
                optionData = await _analyzerModelFactory.GetFiltersData(type);
            }
            catch (Exception ex)
            {
                isSuccess = false;
            }
            return Json(new { success = isSuccess, result = optionData });
        }

        [HttpGet]    
        public async Task<IActionResult> GetAnalyzerMapData(string dateRange)
        {
            var model = await _analyzerModelFactory.PrepareGraphDataAsync(dateRange);           
            return Json( model);
        }
    }
}
