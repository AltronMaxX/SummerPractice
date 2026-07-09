using CyberSportsPortal.Data.Model.Views;
using System.Collections.Generic;

namespace CyberSportsPortal.Core.Services;

public class TeamTasksService
{
    public int GetTeamIncomeForYear(TeamView team, int year)
    {
        return 100;
    }

    public List<RatingView> GetNewRatings(List<MatchHistoryView> matches, List<RatingView> oldRatings)
    {
        return oldRatings;
    }
}