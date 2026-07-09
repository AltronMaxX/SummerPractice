using CyberSportsPortal.Data.Model.Views;
using System.Collections.Generic;

namespace CyberSportsPortal.Core.Services;

public class AdvertisementTasksService
{
    public List<KeyValuePair<int, int>> GetProbabilities(List<AdvertisingCompanyView> companies)
    {
        return new List<KeyValuePair<int, int>>
        {
            new KeyValuePair<int, int>(1,50),
            new KeyValuePair<int, int>(2,50)
        };
    }
}