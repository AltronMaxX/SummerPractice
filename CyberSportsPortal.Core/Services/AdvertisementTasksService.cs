using System;
using CyberSportsPortal.Data.Model.Views;
using System.Collections.Generic;
using System.Linq;

namespace CyberSportsPortal.Core.Services;

public class AdvertisementTasksService
{
    public List<KeyValuePair<int, int>> GetProbabilities(List<AdvertisingCompanyView> companies)
    {
        if (companies == null || companies.Count == 0)
            return new List<KeyValuePair<int, int>>();

        decimal totalSum = 0m;
        var yearlyPayments = new Dictionary<int, decimal>();
        var result = new List<KeyValuePair<int, int>>();

        foreach (var company in companies)
        {
            if (company.PaymentInfo == null)
            {
                yearlyPayments[company.Id] = 0m;
                continue;
            }

            decimal companySum = company.PaymentInfo
                .Where(info => info.PaymentDate.Year == DateTime.Now.Year)
                .Sum(info => info.PaymentSum);

            yearlyPayments[company.Id] = companySum;
            totalSum += companySum;
        }

        if (totalSum == 0)
        {
            foreach (var company in companies)
            {
                result.Add(new KeyValuePair<int, int>(company.Id, 1));
            }
            return result;
        }

        foreach (var company in companies)
        {
            decimal companySum = yearlyPayments[company.Id];
        
            decimal probability = (companySum / totalSum) * 100m;
        
            int probInt = (int)Math.Floor(probability);

            if (probInt < 1)
                probInt = 1;

            result.Add(new KeyValuePair<int, int>(company.Id, probInt));
        }

        return result;
    }
}