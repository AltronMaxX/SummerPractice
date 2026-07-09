using CyberSportsPortal.Data.Entities;
using CyberSportsPortal.Data.Model.Enums;
using CyberSportsPortal.Data.Model.Views;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CyberSportsPortal.Core.Services;

public class TournamentTasksService
{
    public string GetTournamentStatus(Tournament tournament)
    {
        var now = DateTimeOffset.Now;

        if (now < tournament.StartDate)
        {
            return "Не начался";
        }

        if (now > tournament.EndDate)
        {
            return "Окончен";
        }

        return "В процессе";
    }

    public int GetPlayersFromCountryCount(List<Player> players, Country country)
    {
        return players.FindAll(p => p.Country == country).Count();
    }

    public string GetTeamParticipantsNameString(List<string> teamNames)
    {
        return string.Join(", ", teamNames);
    }

    public int ComparePrizes(string prizeA, string prizeB)
    {
        int.TryParse(prizeA, out var pA);
        int.TryParse(prizeB, out var pB);
        return pA.CompareTo(pB);
    }

    public Dictionary<int, decimal> GetTournamentVictoryProbabilities(List<TeamWithVictoryProbabilities> teams, Dictionary<int, int> standings)
    {
        return new Dictionary<int, decimal>();
    }
}