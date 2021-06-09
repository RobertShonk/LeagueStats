using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LeagueStats.Models;
using LeagueStats.Data.Entities;

namespace LeagueStats.Services {
    public interface IResultVMService {
        void SetUserMatchInfo(List<MatchDto> matches, string summonerName);
        void SetUserSummonerSpellsUrls(MatchDto match);
        void SetUserItemsUrls(MatchDto match, Participant participant);
        int GetRankedSoloIndex(List<League> leagues);
        int CalcTotalTeamKills(List<Participant> participants, int teamId);
        double CalcKillParticipation(int totalTeamKills, Participant participant);
        string GetPerkUrl(List<PrimaryRune> primaryRunes, Participant participant, int index);
    }
}
