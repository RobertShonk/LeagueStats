using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LeagueStats.Models;
using LeagueStats.Data.Entities;

namespace LeagueStats.Services {
    public interface IResultVMService {
        void SetUserMatchInfo(List<Match> matches, string summonerName);
        void SetUserSummonerSpellsUrls(Match match);
        void SetUserItemsUrls(Match match, ParticipantDto participant);
        int GetRankedSoloIndex(List<League> leagues);
        int CalcTotalTeamKills(List<ParticipantDto> participants, int teamId);
        double CalcKillParticipation(int totalTeamKills, ParticipantDto participant);
        string GetPerkUrl(List<PrimaryRune> primaryRunes, ParticipantDto participant, int index);
    }
}
