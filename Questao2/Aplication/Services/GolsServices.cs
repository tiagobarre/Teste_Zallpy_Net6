using Newtonsoft.Json;
using Questao2.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Questao2.Aplication.Services
{
    public class GolsServices
    {
        public GolsServices()
        {
                
        }

        public async Task<int> GetTotalScoredGoals(string team, int year)
        {

            int totalGoals = 0;

            // Soma gols como team1
            totalGoals += await SumGoals(team, year, isTeam1: true);

            // Soma gols como team2
            totalGoals += await SumGoals(team, year, isTeam1: false);

            return totalGoals;
        }

        private async Task<int> SumGoals(string team, int year, bool isTeam1)
        {
            int goals = 0;
            int page = 1;
            using HttpClient client = new HttpClient();
            string baseUrl = "https://jsonmock.hackerrank.com/api/football_matches";

            while (true)
            {
                // Monta URL com parâmetros
                string url = $"{baseUrl}?year={year}&page={page}";
                url += isTeam1 ? $"&team1={Uri.EscapeDataString(team)}" : $"&team2={Uri.EscapeDataString(team)}";

                var response = await client.GetStringAsync(url);

                var data = JsonConvert.DeserializeObject<ApiResponse>(response);

                foreach (var match in data.Data)
                {
                    int matchGoals = isTeam1 ? int.Parse(match.Team1Goals) : int.Parse(match.Team2Goals);
                    goals += matchGoals;
                }

                if (page >= data.TotalPages)
                    break;

                page++;
            }

            return goals;
        }
    }
}
