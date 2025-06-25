using Questao2.Aplication.Services;

class Program
{
    static async Task Main()
    {
        GolsServices _golsServices = new GolsServices();
        string teamName = "Paris Saint-Germain";
        int year = 2013;
        int totalGoals = await _golsServices.GetTotalScoredGoals(teamName, year);

        Console.WriteLine("Team " + teamName + " scored " + totalGoals + " goals in " + year);

        teamName = "Chelsea";
        year = 2014;
        totalGoals = await _golsServices.GetTotalScoredGoals(teamName, year);

        Console.WriteLine("Team " + teamName + " scored " + totalGoals + " goals in " + year);
    }
  
}