using Microsoft.Extensions.Options;
using MongoDB.Driver;
using pruebaApiPSP.model;

namespace pruebaApiPSP.service;

public class PlayerService
{
    private readonly IMongoCollection<Player> _playerCollection;

    public PlayerService(
        IOptions<PlayerDatabaseSettings> playerDatabaseSetting)
    {
        var mongoClient = new MongoClient(
            playerDatabaseSetting.Value.ConnectionString);

        var mongoDatabase = mongoClient.GetDatabase(
            playerDatabaseSetting.Value.DatabaseName);

        _playerCollection = mongoDatabase.GetCollection<Player>(
            playerDatabaseSetting.Value.PlayersCollectionName);
    }

    public async Task<List<Player>> GetAsync() =>
        await _playerCollection.Find(_ => true).ToListAsync();

    public async Task<Player?> GetAsync(long id) =>
        await _playerCollection.Find(x => x.Id == id).FirstOrDefaultAsync();

    public async Task CreateAsync(Player newPlayer) =>
        await _playerCollection.InsertOneAsync(newPlayer);

    public async Task UpdateAsync(long id, Player updatedPlayer) =>
        await _playerCollection.ReplaceOneAsync(x => x.Id == id, updatedPlayer);

    public async Task RemoveAsync(long id) =>
        await _playerCollection.DeleteOneAsync(x => x.Id == id);
}