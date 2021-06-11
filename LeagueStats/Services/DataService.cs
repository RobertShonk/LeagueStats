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

        // Summoner only "exists" if they have at least 20 matches to their name.
        public bool SummonerExists(string summonerName)
        {
            var matches = from match in _ctx.Matches
                          join participant in _ctx.Participants on match.InfoId equals participant.InfoId
                          where participant.SummonerName == summonerName
                          select match;
            var matchList = matches.ToList<Match>();

            if (matchList.Count() < 20)
            {
                return false;
            }

            return true;
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
                        orderby info.GameCreation descending
                        select info;
            List<Info> infoList = infos.ToList<Info>();

            // for each info in infos get list of participants with p.InfoId == i.InfoId
            foreach (var info in infoList)
            {
                // gets all participants by infoId
                info.Participants = _ctx.Participants.Where(p => p.InfoId == info.InfoId).ToList<Participant>();

                foreach (var participant in info.Participants)
                {
                    participant.Perks = new Perk();

                    // get participants perkId
                    // use perkId to get StatPerksId, read Defense, Offense, Flex into StatPerks
                    var statPerks = from statP in _ctx.StatPerks
                                    join p in _ctx.Participants on statP.StatPerksId equals p.PerksPerkId
                                    where p.SummonerName == summonerName
                                    select new StatPerks() { Defense = statP.Defense, Offense = statP.Offense, Flex = statP.Flex };
                    var theStatPerk = statPerks.FirstOrDefault();

                    participant.Perks.StatPerks = theStatPerk;

                    // now get List<Style>
                    // first query for List<Selection> by participant.PerksPerkId
                    // count is 6, 4 are "primaryStyle", the other 2 are "subStyle"
                    // primaryStyle has count of 4, secondary has count of 2;
                    var qSelections = from s in _ctx.Selections
                                      join style in _ctx.Styles on s.StyleId equals style.StyleId
                                      where style.PerkId == participant.PerksPerkId
                                      select new Selection() { StyleId = s.StyleId, Perk = s.Perk, Var1 = s.Var1, Var2 = s.Var2, Var3 = s.Var3 };
                    var theSelections = qSelections.ToList<Selection>();


                    // List<Style>
                    var qStyles = from s in _ctx.Styles
                                  where s.PerkId == participant.PerksPerkId
                                  select new Style() { StyleId = s.StyleId, Description = s.Description, StyleNumber = s.StyleNumber, Selections = new List<Selection>() };
                    var theStyles = qStyles.ToList<Style>();                    

                    // for every selection check if styleid matches style.styleid then add selection to that List<style>
                    foreach (var selection in theSelections)
                    {
                        foreach (var style in theStyles)
                        {
                            if (selection.StyleId == style.StyleId)
                            {
                                style.Selections.Add(selection);
                            }
                        }
                    }

                    participant.Perks.Styles = theStyles;
                    
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