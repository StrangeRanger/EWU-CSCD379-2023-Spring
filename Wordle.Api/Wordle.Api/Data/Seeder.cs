namespace Wordle.Api.Data;

public static class Seeder
{
    public static void Seed(AppDbContext context)
    {
        SeedPlayers(context);
        SeedWords(context);
    }

    public static void SeedWords(AppDbContext db)
    {
        if (!db.Words.Any())
        {
            var wordLines = System.IO.File.ReadAllLines("Content/Words.csv");
            foreach (var line in wordLines)
            {
                var parts = line.Split(',');
                var word = new Word() { Text = parts[0], IsCommon = bool.Parse(parts[1]) };
                db.Words.Add(word);
            }
            db.SaveChanges();
        }
    }

    public static void SeedPlayers(AppDbContext db)
    {
        if (!db.Players.Any())
        {
            db.Players.Add(new Player { PlayerName = "John", AverageAttempts = 3.2,
                AverageSecondsPerGame = 120, GameCount = 12,
                PlayerId = Guid.NewGuid() });
            db.Players.Add(new Player { PlayerName = "Mary", AverageAttempts = 2.5,
                AverageSecondsPerGame = 90, GameCount = 34,
                PlayerId = Guid.NewGuid()});
            db.Players.Add(new Player { PlayerName = "Bob", AverageAttempts = 2.8,
                AverageSecondsPerGame = 80, GameCount = 45,
                PlayerId = Guid.NewGuid()});
            db.Players.Add(new Player { PlayerName = "Susan", AverageAttempts = 2.7,
                AverageSecondsPerGame = 70, GameCount = 23,
                PlayerId = Guid.NewGuid() });
            db.SaveChanges();
        }
    }
}