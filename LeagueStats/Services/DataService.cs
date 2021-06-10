using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LeagueStats.Data;
using LeagueStats.Data.Entities;
using LeagueStats.Models;
using Microsoft.EntityFrameworkCore;

namespace LeagueStats.Services {
    public class DataService : IDataService {

        private readonly LeagueStatsContext _ctx;

        public DataService(LeagueStatsContext ctx)
        {
            this._ctx = ctx;
        }
        public bool SummonerExists(string summonerName)
        {
            var exists = _ctx.Participants.Where(p => p.SummonerName == summonerName).Any();

            return exists;
        }

        public void AddMatches(List<Match> matches)
        {
            foreach (var match in matches)
            {
                if (_ctx.Metadatas.Where(m => m.MatchId == match.Metadata.MatchId).Any())
                {
                    // if the m.MatchId == match.Metada.MatchId then the match is already in db.
                    // if so then do nothing.
                }
                else
                {
                    _ctx.Matches.Add(match);
                    _ctx.SaveChanges();
                }
            }
        }

        // This currently returns ALL matches by summonerName.
        // should return a fixed amount, maybe 20, in the future.
        public List<MatchDto> GetMatchesBySummonerName(string summonerName)
        {

            var infos = from info in _ctx.Infos
                        join participant in _ctx.Participants on info.InfoId equals participant.InfoId
                        where participant.SummonerName == summonerName
                        select info;
            List<Info> infoList = infos.ToList<Info>();

            // for each info in infos get list of participants with p.InfoId == i.InfoId
            foreach (var info in infoList)
            {
                info.Participants = _ctx.Participants.Where(p => p.InfoId == info.InfoId).ToList<Participant>();

                foreach (var participant in info.Participants)
                {
                    // query for whole perk object then set equal to p.perks
                }
            }

            var metadatas = from metadata in _ctx.Metadatas
                            join participant in _ctx.Participants on metadata.MetadataId equals participant.InfoId
                            where participant.SummonerName == summonerName
                            select metadata;
            List<Metadata> metadataList = metadatas.ToList<Metadata>();

            List < MatchDto > matches = new List<MatchDto>();

            for (int i = 0; i < 20; i++)
            {
                matches.Add(new MatchDto() { Info = infoList[i], Metadata = metadataList[i]});
            }

            return matches;
        }
    }
}
