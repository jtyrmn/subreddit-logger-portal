using Microsoft.Extensions.Options;
using subreddit_logger_portal.Models;

namespace subreddit_logger_portal.Services;

/*
    ListingService handles everything to do with listings, such as holding an
    instance of the listings database service
*/

public class ListingsService
{
    private readonly ListingsDatabaseHandler database;

    /*
        Max amount of listings displayed on a page before loading another page

        shouldn't be here; this service deals with listings, not the listings
        website page. I should've split this into a ListingsService and
        ListingsPageService or something but that will take some refactoring and
        is a problem for future me. TODO:
    */
    private readonly int numListingsPerPage;

    public ListingsService(IOptions<ListingsDatabaseSettings> listingsDatabaseSettings)
    {
        // TODO: validate that listingsDatabaseSettings contains non-null values

        database = new ListingsDatabaseHandler(listingsDatabaseSettings.Value.Address);
        numListingsPerPage = (int)listingsDatabaseSettings.Value.NumListingsPerPage;
    }

    public async Task<ListingModel> GetOne(string id) => await database.GetOne(id);
    public async Task<List<ListingModel>> GetMany(int skip) => await database.GetMany(numListingsPerPage, skip);
}