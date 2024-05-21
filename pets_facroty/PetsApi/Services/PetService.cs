using MongoDB.Driver;
using PetsApi.Models;
using Microsoft.Extensions.Options;
using PetsApi.Settings;

namespace PetsApi.Services
{
    public class PetService
    {
        private readonly IMongoCollection<Pet> _petsCollection;

        public PetService(IOptions<PetStoreDatabaseSettings> petStoreDatabaseSettings)
        {
            var mongoClient = new MongoClient(petStoreDatabaseSettings.Value.ConnectionString);
            var mongoDatabase = mongoClient.GetDatabase(petStoreDatabaseSettings.Value.DatabaseName);
            _petsCollection = mongoDatabase.GetCollection<Pet>("Pets");
        }

        public async Task CreateAsync(Pet newPet) =>
            await _petsCollection.InsertOneAsync(newPet);
    }
}
