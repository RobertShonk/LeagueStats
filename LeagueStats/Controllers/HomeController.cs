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

        public async Task<IActionResult> ResultTest(string summonerName, bool update)
        {
            ResultVM vm = new ResultVM();

            if (_dataService.SummonerExists(summonerName) && update == false)
            {
                // If the user does exist in database, read user info
                // and load viewmodel.
                var matches = _dataService.GetMatchesBySummonerName(summonerName);

                vm.Matches = matches;

                // need to get Summoner and League data somehow (api call for now since Summoner not being saved by db).
                vm.Summoner = await _riotService.GetSummonerAsync(summonerName);

                if (vm.Summoner == null)
                {
                    return View("SummonerNotFound");
                }

                vm.Leagues = await _riotService.GetLeagueAsync(vm.Summoner.Id);

                _resultVMService.SetUserMatchInfo(vm.Matches, vm.Summoner.Name);
                vm.RankedSoloDuoIndex = _resultVMService.GetRankedSoloIndex(vm.Leagues);
                vm.WinRate = ((double)vm.Leagues[vm.RankedSoloDuoIndex].Wins / ((double)vm.Leagues[vm.RankedSoloDuoIndex].Wins + (double)vm.Leagues[vm.RankedSoloDuoIndex].Losses)) * 100;
                vm.WinRate = Math.Ceiling(vm.WinRate);
                vm.RankedIconUrl = "/images/ranked-emblems/Emblem_" + vm.Leagues[vm.RankedSoloDuoIndex].Tier + ".png";
                // ^^^ ViewModel is complete ^^^

                ViewBag.showContent = "true";

                return View(vm);
            }
            else if (update == true)
            {
                // If user hits update, use summonerName to call riotApi for relevant data
                // and add to database.
                
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
                // ^^^ ViewModel is complete ^^^
                // Now "give" Matches.Info and Matches.Metadata to MatchesDto (map from dto to entity).
                List<Data.Entities.Match> matches = new List<Data.Entities.Match>();
                foreach (var match in vm.Matches)
                {
                    matches.Add(new Data.Entities.Match() { Info = match.Info, Metadata = match.Metadata });
                }
                // Add to database.
                _dataService.AddMatches(matches);
                ViewBag.showContent = "true";


                return View(vm);
            }
            else
            {
                // If user doesn't exist and update is false then display
                // basic webpage telling them to click update.
                ViewBag.showContent = "false";
                ViewBag.summonerName = summonerName;

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
