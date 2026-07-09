using System;
using CyberSportsPortal.Data.Model.Views;
using System.Collections.Generic;
using System.Linq;
using CyberSportsPortal.Data;

namespace CyberSportsPortal.Core.Services;
public class TeamTasksService(CyberSportsContext context)
{
    private readonly CyberSportsContext _context = context;

    public int GetTeamIncomeForYear(int teamId, int year)
    {
        var team = _context.Teams.First(x => x.Id == teamId);
        var income = 0;
        foreach (var result in team.TeamTournamentResults)
        {
            if (result != null)
            {
                if (result.Tournament.StartDate.Year == year || result.Tournament.EndDate.Year == year)
                {
                    var place = result.Place.GetValueOrDefault(0);
                    if  (place == 0)
                        continue;
                    income += result.Tournament.TournamentPrizes.ToList()[place - 1].Prize;
                }
            }
        }
        return income;
    }

    public List<RatingView> GetNewRatings(List<MatchHistoryView> matches, List<RatingView> oldRatings)
    {
        return oldRatings;
    }
}