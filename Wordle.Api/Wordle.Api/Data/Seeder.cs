namespace Wordle.Api.Data;

public static class Seeder
{
    public static void Seed(AppDbContext context)
    {
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
}
