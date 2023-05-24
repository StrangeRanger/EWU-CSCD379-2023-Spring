using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Wordle.Api.Data;

namespace Wordle.Api.Services;

public class LeaderboardService
{
    private readonly AppDbContext _db;

    public LeaderboardService(AppDbContext db)
    {
        _db = db;
    }

    public async Task<IEnumerable<Player>> GetTopTenScores()
    {
        var highScore = await _db.Players.Take(10)
                            .OrderByDescending(player => player.AverageSecondsPerGame)
                            .ToListAsync();
        return highScore;
    }

    // Retrieve a the stats of a specified player, passed by name as parameter
    public async Task<IEnumerable<Player>> GetPlayerStats(string playerName)
    {
        var player =
            await _db.Players.Select(p => p).Where(p => p.PlayerName == playerName).ToListAsync();

        if (player == null)
        {
            throw new ArgumentNullException("Player is null");
        }

        return player;
    }

    public async Task<Player> CreateAsync(string name)
    {
        Player player = new() { PlayerName = name, PlayerId = Guid.NewGuid() };
        _db.Players.Add(player);
        await _db.SaveChangesAsync();
        return player;
    }

    private async Task<Player> UpdatePlayer(string playerName, int timeInSeconds, double attempts)
    {
        var player =
            await _db.Players.FirstOrDefaultAsync(player => player.PlayerName == playerName);
        player!.GameCount += 1;
        player.TotalSecondsPerGame += timeInSeconds;
        player.TotalAttempts += attempts;
        player.AverageAttempts = player.TotalAttempts / player.GameCount;
        player.AverageSecondsPerGame = player.TotalSecondsPerGame / player.GameCount;

        return player;
    }
}
