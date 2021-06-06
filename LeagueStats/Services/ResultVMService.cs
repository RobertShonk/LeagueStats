using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LeagueStats.Models;

namespace LeagueStats.Services {
    public class ResultVMService : IResultVMService {
        public void SetUserMatchInfo(List<Match> matches, string summonerName)
        {
            foreach (var match in matches)
            {
                foreach (var participant in match.Info.Participants)
                {
                    if (participant.SummonerName == summonerName)
                    {
                        match.SummonersChampionName = participant.ChampionName;
                        match.Win = participant.Win;
                        match.Summoner1Id = participant.Summoner1Id;
                        match.Summoner2Id = participant.Summoner2Id;
                        // save summoner spell names to vm for img src in view
                        SetUserSummonerSpellsUrls(match);
                        SetUserItemsUrls(match, participant);

                        break;
                    }
                }
            }
        }

        public void SetUserSummonerSpellsUrls(Match match)
        {
            if (match.Summoner1Id == 1)
            {
                match.Summoner1ImageUrl = "/images/spell/SummonerBoost.png";
            }
            else if (match.Summoner1Id == 3)
            {
                match.Summoner1ImageUrl = "/images/spell/SummonerExhaust.png";
            }
            else if (match.Summoner1Id == 4)
            {
                match.Summoner1ImageUrl = "/images/spell/SummonerFlash.png";
            }
            else if (match.Summoner1Id == 6)
            {
                match.Summoner1ImageUrl = "/images/spell/SummonerHaste.png";
            }
            else if (match.Summoner1Id == 7)
            {
                match.Summoner1ImageUrl = "/images/spell/SummonerHeal.png";
            }
            else if (match.Summoner1Id == 11)
            {
                match.Summoner1ImageUrl = "/images/spell/SummonerSmite.png";
            }
            else if (match.Summoner1Id == 12)
            {
                match.Summoner1ImageUrl = "/images/spell/SummonerTeleport.png";
            }
            else if (match.Summoner1Id == 13)
            {
                match.Summoner1ImageUrl = "/images/spell/SummonerMana.png";
            }
            else if (match.Summoner1Id == 14)
            {
                match.Summoner1ImageUrl = "/images/spell/SummonerDot.png";
            }
            else if (match.Summoner1Id == 21)
            {
                match.Summoner1ImageUrl = "/images/spell/SummonerBarrier.png";
            }
            else if (match.Summoner1Id == 32)
            {
                match.Summoner1ImageUrl = "/images/spell/SummonerSnowball.png";
            }
            else
            {
                match.Summoner1ImageUrl = "/images/spell/LuluE.png";
            }

            // Summoner2Id
            if (match.Summoner2Id == 1)
            {
                match.Summoner2ImageUrl = "/images/spell/SummonerBoost.png";
            }
            else if (match.Summoner2Id == 3)
            {
                match.Summoner2ImageUrl = "/images/spell/SummonerExhaust.png";
            }
            else if (match.Summoner2Id == 4)
            {
                match.Summoner2ImageUrl = "/images/spell/SummonerFlash.png";
            }
            else if (match.Summoner2Id == 6)
            {
                match.Summoner2ImageUrl = "/images/spell/SummonerHaste.png";
            }
            else if (match.Summoner2Id == 7)
            {
                match.Summoner2ImageUrl = "/images/spell/SummonerHeal.png";
            }
            else if (match.Summoner2Id == 11)
            {
                match.Summoner2ImageUrl = "/images/spell/SummonerSmite.png";
            }
            else if (match.Summoner2Id == 12)
            {
                match.Summoner2ImageUrl = "/images/spell/SummonerTeleport.png";
            }
            else if (match.Summoner2Id == 13)
            {
                match.Summoner2ImageUrl = "/images/spell/SummonerMana.png";
            }
            else if (match.Summoner2Id == 14)
            {
                match.Summoner2ImageUrl = "/images/spell/SummonerDot.png";
            }
            else if (match.Summoner2Id == 21)
            {
                match.Summoner2ImageUrl = "/images/spell/SummonerBarrier.png";
            }
            else if (match.Summoner2Id == 32)
            {
                match.Summoner2ImageUrl = "/images/spell/SummonerSnowball.png";
            }
            else
            {
                match.Summoner2ImageUrl = "/images/spell/LuluE.png";
            }
        }
        public void SetUserItemsUrls(Match match, Participant participant)
        {
            match.Item0 = participant.Item0;
            match.Item1 = participant.Item1;
            match.Item2 = participant.Item2;
            match.Item3 = participant.Item3;
            match.Item4 = participant.Item4;
            match.Item5 = participant.Item5;
            match.Item6 = participant.Item6;
        }

    }
}
