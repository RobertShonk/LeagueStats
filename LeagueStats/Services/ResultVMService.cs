using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using System.Linq;
using System.Threading.Tasks;
using LeagueStats.Models;
using LeagueStats.Data.Entities;

namespace LeagueStats.Services {
    public class ResultVMService : IResultVMService {

        public void SetUserMatchInfo(List<MatchDto> matches, string summonerName)
        {
            foreach (var match in matches)
            {
                foreach (var participant in match.Info.Participants)
                {
                    if (participant.SummonerName == summonerName)
                    {
                        match.SummonersChampionName = participant.ChampionName;
                        match.TeamId = participant.TeamId;
                        match.Win = participant.Win;
                        match.Kills = participant.Kills;
                        match.Deaths = participant.Deaths;
                        match.Assists = participant.Assists;
                        match.TotalMinionsKilled = participant.TotalMinionsKilled;
                        match.Summoner1Id = participant.Summoner1Id;
                        match.Summoner2Id = participant.Summoner2Id;

                        // convert match.Info.GameDuration to min:seconds format for viewmodel
                        TimeSpan timeSpan = TimeSpan.FromMilliseconds(match.Info.GameDuration);
                        match.GameDuration = string.Format("{0:D2}m:{1:D2}s", timeSpan.Minutes, timeSpan.Seconds);

                        // save summoner spell names to vm for img src in view
                        SetUserSummonerSpellsUrls(match);
                        SetUserItemsUrls(match, participant);

                        // Deserialize runesReforged.json and send object to GetPerkUrl for MatchPerkUrls.
                        string json = System.IO.File.ReadAllText(@"C:\Users\rshon\source\repos\LeagueStats\LeagueStats\App_Data\runesReforged.json");

                        dynamic runesReforged = JsonConvert.DeserializeObject<List<PrimaryRune>>(json);
                        // Perks
                        match.Perk1Url = GetPerkUrl(runesReforged, participant, 0);
                        match.Perk2Url = GetPerkUrl(runesReforged, participant, 1);

                        match.KillParticipation = (CalcKillParticipation(CalcTotalTeamKills(match.Info.Participants, match.TeamId), participant))*100;
                        match.KillParticipation = Math.Ceiling(match.KillParticipation);

                        break;
                    }
                }
            }
        }

        public void SetUserSummonerSpellsUrls(MatchDto match)
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
        public void SetUserItemsUrls(MatchDto match, Participant participant)
        {
            match.ItemUrlList.Add("/images/item/" + participant.Item0 + ".png");
            match.ItemUrlList.Add("/images/item/" + participant.Item1 + ".png");
            match.ItemUrlList.Add("/images/item/" + participant.Item2 + ".png");
            match.ItemUrlList.Add("/images/item/" + participant.Item3 + ".png");
            match.ItemUrlList.Add("/images/item/" + participant.Item4 + ".png");
            match.ItemUrlList.Add("/images/item/" + participant.Item5 + ".png");
            match.ItemUrlList.Add("/images/item/" + participant.Item6 + ".png");
        }
        public int GetRankedSoloIndex(List<League> leagues)
        {
            if (leagues[0].QueueType == "RANKED_SOLO_5x5")
            {
                return 0;
            }

            return 1;
        }

        // These take the total of ALL PLAYERS not just of one team. fix this...
        // have to save users teamId number and use that to add up participants kills
        // who have that id number.
        public int CalcTotalTeamKills(List<Participant> participants, int teamId)
        {
            int totalKills = 0;

            foreach (var participant in participants)
            {
                if (participant.TeamId == teamId)
                {
                    totalKills = totalKills + participant.Kills;
                }              
            }

            return totalKills;
        }

        public double CalcKillParticipation(int totalTeamKills, Participant participant)
        {
            return (double)(participant.Kills + participant.Assists) / (double)totalTeamKills;
        }

        public string GetPerkUrl(List<PrimaryRune> primaryRunes, Participant participant, int index)
        {
            PrimaryRune rune = new PrimaryRune();
            string url = "";
            if (participant.Perks.Styles[index].Description == "primaryStyle")
            {
                //rune = primaryRunes.FirstOrDefault(r => r.Id == participant.Perks.Styles[0].Selections[0].Perk);
                //rune = primaryRunes.Where(r => r.Id == participant.Perks.Styles[0].Selections[0].Perk).FirstOrDefault();
                foreach (PrimaryRune r in primaryRunes)
                {
                    foreach (var slotR in r.Slots)
                    {
                        foreach (var runeS in slotR.Runes)
                        {
                            if (runeS.Id == participant.Perks.Styles[0].Selections[0].Perk)
                            {
                                url = runeS.Icon;
                                break;
                            }
                        }
                    }
                }
            }
            else
            {
                rune = primaryRunes.FirstOrDefault(r => r.Id == participant.Perks.Styles[1].StyleNumber);
                url = rune.Icon;
                //rune = primaryRunes.Where(r => r.Id == participant.Perks.Styles[1].StyleNumber).FirstOrDefault();
            }

            return "/images/" + url;
        }
    }
}
