
using Microsoft.VisualBasic;
using MongoDB.Driver;
using subreddit_logger_portal.Models;
/*
Object to manage a connection to the listings database.
Primarily created for the ListingsService service.
*/

public class ListingsDatabaseHandler
{
    private readonly IMongoCollection<ListingModel> collection;

    public ListingsDatabaseHandler(string connectionString, string databaseName, string collectionName) {
        MongoClient client = new MongoClient(connectionString);
        IMongoDatabase database = client.GetDatabase(databaseName);
        collection = database.GetCollection<ListingModel>(collectionName);
    }

    //get every listing. Probably should only use this for testing
    public async Task<List<ListingModel>?> GetAll()
    {
        return await collection.Find(_ => true).ToListAsync();
    }

    //get a listing by ID
    public async Task<ListingModel?> Get(string id) {
        return await collection.Find(
            Builders<ListingModel>.Filter.Eq("_id", id)
        ).FirstOrDefaultAsync();
    }
}