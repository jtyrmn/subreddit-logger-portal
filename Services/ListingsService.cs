using Microsoft.Extensions.Options;
using MongoDB.Driver;
using subreddit_logger_portal.Models;

/*
    ListingService manages the listings database connection
*/

public class ListingsService
{
    private readonly IMongoCollection<ListingModel> listingsCollection;

    public ListingsService(IOptions<ListingsDatabaseSettings> listingsDatabaseSettings)
    {
        MongoClient client = new MongoClient(listingsDatabaseSettings.Value.ConnectionString);
        IMongoDatabase database = client.GetDatabase(listingsDatabaseSettings.Value.DatabaseName);
        listingsCollection = database.GetCollection<ListingModel>(listingsDatabaseSettings.Value.ListingsCollectionName);
    }

    //every document
    public async Task<List<ListingModel>> GetAll()
    {
        return await listingsCollection.Find(_ => true).ToListAsync();
    }
}