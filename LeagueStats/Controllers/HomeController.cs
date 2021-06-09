using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using LeagueStats.Models;
using LeagueStats.Data.Entities;
using LeagueStats.Services;
using LeagueStats.Data;

namespace LeagueStats.Controllers {
    public class HomeController : Controller {

        private readonly ILogger<HomeController> _logger;

        private readonly IRiotService _riotService;
        private readonly IResultVMService _resultVMService;
        private readonly IDataService _dataService;

        public HomeController(ILogger<HomeController> logger, IRiotService riotService, IResultVMService resultVMService, IDataService dataService)
        {
            _logger = logger;
            this._riotService = riotService;
            this._resultVMService = resultVMService;
            this._dataService = dataService;
        }

        public IActionResult Index()
        {
            return View();
        }

        // my stuff
        public async Task<IActionResult> Result(string summonerName, bool update)
        {
            if (_dataService.SummonerExists(summonerName) && update == false)
            {
                // If the user does exist in database, read user info
                // and load viewmodel.

                return View("SummonerExists");
            }
            else if (update == true)
            {
                // If user hits update, use summonerName to call riotApi for relevant data
                // and add to database.
                return View("UpdateTrue");
            }
            else
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
                vm.WinRate = ((double)vm.Leagues[vm.RankedSoloDuoIndex].Wins / ((double)vm.Leagues[vm.RankedSoloDuoIndex].Wins + (double)vm.Leagues[vm.RankedSoloDuoIndex].Losses)) * 100;
                vm.WinRate = Math.Ceiling(vm.WinRate);
                vm.RankedIconUrl = "/images/ranked-emblems/Emblem_" + vm.Leagues[vm.RankedSoloDuoIndex].Tier + ".png";

                return View(vm);
            }
        }

        public IActionResult ResultTest(string summonerName, bool update)
        {
            if (_dataService.SummonerExists(summonerName) && update == false)
            {
                // If the user does exist in database, read user info
                // and load viewmodel.

                return View("SummonerExists");
            }
            else if (update == true)
            {
                // If user hits update, use summonerName to call riotApi for relevant data
                // and add to database.
                return View("UpdateTrue");
            }
            else
            {
                // If user doesn't exist and update is false then display
                // basic webpage telling them to click update.
                ViewBag.showContent = false;

                return View();
            }
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
