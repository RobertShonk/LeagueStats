using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Net.Http;
using Microsoft.Extensions.Configuration;
using LeagueStats.Models;


namespace LeagueStats.Services {
    public class RiotService : IRiotService {

        //store api_key in secrets later.
        private readonly string API_KEY;
        private readonly string SUMMONER_URL = "https://na1.api.riotgames.com/lol/summoner/v4/summoners/by-name/";
        private readonly string LEAGUE_URL = "https://na1.api.riotgames.com/lol/league/v4/entries/by-summoner/";
        private readonly string MATCHids_URL = "https://americas.api.riotgames.com/lol/match/v5/matches/by-puuid/";
        private readonly string MATCH_URL = "https://americas.api.riotgames.com/lol/match/v5/matches/";
        private readonly HttpClient _client;

        public RiotService (HttpClient httpClient, IConfiguration config)
        {
            this._client = httpClient;
            this.API_KEY = config["LeagueStats:ApiKey"];
        }

        public async Task<Summoner> GetSummonerAsync(string summonerName)
        {
            string url = SUMMONER_URL + summonerName + "?api_key=" + API_KEY;
            Summoner summoner = null;

            /*HttpResponseMessage response = await _client.GetAsync(url);
            if (response.IsSuccessStatusCode)
            {
                summoner = await response.Content.ReadAsAsync<Summoner>();
            }*/

            try
            {

                HttpResponseMessage response = await _client.GetAsync(url);
                if (response.IsSuccessStatusCode)
                {
                    summoner = await response.Content.ReadAsAsync<Summoner>();
                }

            } catch(HttpRequestException e)
            {
                Console.WriteLine("[RiotService] GetSummonerAsync(): " + e.Message);
            }

            return summoner;
        }

        public async Task<List<League>> GetLeagueAsync(string id)
        {
            string url = LEAGUE_URL + id + "?api_key=" + API_KEY;
            List<League> leagues = null;

            /*HttpResponseMessage response = await _client.GetAsync(url);
            if (response.IsSuccessStatusCode)
            {
                leagues = await response.Content.ReadAsAsync<List<League>>();
            }*/

            try
            {
                HttpResponseMessage response = await _client.GetAsync(url);
                if (response.IsSuccessStatusCode)
                {
                    leagues = await response.Content.ReadAsAsync<List<League>>();
                }

            } catch(HttpRequestException e)
            {
                Console.WriteLine("[RiotService] GetLeagueAsync(): " + e.Message);
            }

            return leagues;
        }

        public async Task<List<string>> GetMatchIdsAsync(string puuid)
        {
            string url = MATCHids_URL + puuid + "/ids?start=0&count=20&api_key=" + API_KEY;
            List<string> matchIds = null;

            /*HttpResponseMessage response = await _client.GetAsync(url);
            if (response.IsSuccessStatusCode)
            {
                matchIds = await response.Content.ReadAsAsync<List<string>>();
            }*/

            try
            {
                HttpResponseMessage response = await _client.GetAsync(url);
                if (response.IsSuccessStatusCode)
                {
                    matchIds = await response.Content.ReadAsAsync<List<string>> ();
                }
            } catch (HttpRequestException e)
            {
                Console.WriteLine("[RiotService] GetMatchIdsAsync: " + e.Message);
            }

            return matchIds;
        }

        public async Task<List<Match>> GetMatchesAsync(List<string> matchIds)
        {
            List<Match> matches = new List<Match>();
            Match match = null;
            HttpResponseMessage response = null;

            foreach (string matchId in matchIds)
            {
                /*response = await _client.GetAsync(MATCH_URL + matchId + "?api_key=" + API_KEY);

                if (response.IsSuccessStatusCode)
                {
                    match = await response.Content.ReadAsAsync<Match>();
                    matches.Add(match);
                }*/

                try
                {
                    response = await _client.GetAsync(MATCH_URL + matchId + "?api_key=" + API_KEY);
                    if (response.IsSuccessStatusCode)
                    {
                        matches.Add(await response.Content.ReadAsAsync<Match>());
                    }
                } catch (HttpRequestException e)
                {
                    Console.WriteLine("[RiotService] GetMatchesAsync(): " + e.Message);
                }
            }

            return matches;
        }

    }
}
