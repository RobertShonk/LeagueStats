using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using LeagueStats.Models;
using LeagueStats.Services;

namespace LeagueStats.Controllers {
    public class HomeController : Controller {

        private readonly ILogger<HomeController> _logger;

        private readonly IRiotService _riotService;
        private readonly IResultVMService _resultVMService;

        public HomeController(ILogger<HomeController> logger, IRiotService riotService, IResultVMService resultVMService)
        {
            _logger = logger;
            this._riotService = riotService;
            this._resultVMService = resultVMService;
        }

        public IActionResult Index()
        {
            return View();
        }

        // my stuff
        public async Task<IActionResult> Result(string summonerName)
        {
            ResultVM vm = new ResultVM();
            // -> GetSummoner -> GetLeague, GetMatchIds, GetMatches
            vm.Summoner = await _riotService.GetSummonerAsync(summonerName);

            if (vm.Summoner == null)
            {
                return View("SummonerNotFound");
            }
            else
            {
                vm.Leagues = await _riotService.GetLeagueAsync(vm.Summoner.Id);
                vm.MatchIds = await _riotService.GetMatchIdsAsync(vm.Summoner.Puuid);
                vm.Matches = await _riotService.GetMatchesAsync(vm.MatchIds);
            }

            _resultVMService.SetUserMatchInfo(vm.Matches, vm.Summoner.Name);
            vm.RankedSoloDuoIndex = _resultVMService.GetRankedSoloIndex(vm.Leagues);

            return View(vm);
        }

        public IActionResult SummonerNotFound()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
