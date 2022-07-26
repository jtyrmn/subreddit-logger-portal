using Microsoft.Extensions.Options;
using subreddit_logger_portal.Models;

namespace subreddit_logger_portal.Services;

/*
    ListingService handles everything to do with listings, such as holding a 
    database instance or TODO: retrieving listings from cache
*/

public class ListingsService
{
    private readonly ListingsDatabaseHandler database;

    public ListingsService(IOptions<ListingsDatabaseSettings> listingsDatabaseSettings)
    {
        database = new ListingsDatabaseHandler(
            listingsDatabaseSettings.Value.ConnectionString,
            listingsDatabaseSettings.Value.DatabaseName,
            listingsDatabaseSettings.Value.ListingsCollectionName
        );
    }

    //following functions are just wrappers around database member

    public async Task<List<ListingModel>?> GetAll() => await database.GetAll();
    public async Task<ListingModel?> Get(string id) => await database.Get(id);
}