using CyberSportsPortal.Data.Model.Views;
using System.Collections.Generic;
using System.Linq;

namespace CyberSportsPortal.Core.Services;

public class PlayerTasksService
{
    public List<PlayerView> FilterPlayers(List<PlayerView> players, string filter)
    {
        if (string.IsNullOrWhiteSpace(filter))
        {
            return players;
        }

        filter = filter.Trim();

        return players.FindAll(p => p.NickName.Contains(filter, System.StringComparison.OrdinalIgnoreCase)
            || p.CombinedName.Contains(filter, System.StringComparison.OrdinalIgnoreCase));
    }
}