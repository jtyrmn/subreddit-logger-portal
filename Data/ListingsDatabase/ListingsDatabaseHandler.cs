/*
Object to manage a connection to the listings database.
Primarily created for the ListingsService service.

Doesn't directly interface with the mongodb database, but with the
external subreddit-logger-database service instead
*/

using Grpc.Net.Client;
using System.Linq;
using subreddit_logger_portal.Models;
using subreddit_logger_portal.pb;

public class ListingsDatabaseHandler
{
    private readonly ListingsDatabase.ListingsDatabaseClient client;
    private readonly GrpcChannel _channel; // keep track of this so it can be closed later

    public ListingsDatabaseHandler(string address)
    {
        // connect to subreddit-logger-database service
        _channel = GrpcChannel.ForAddress(address);
        client = new ListingsDatabase.ListingsDatabaseClient(_channel);
    }

    /*
        get a single listing by it's listing ID (not metadata ID)
    */
    public async Task<ListingModel> GetOne(string id) {
        FetchListingRequest request = new FetchListingRequest{Id = id};
        RedditContent response = await client.FetchListingAsync(request);

        return (ListingModel)response;
    }

    /*
        implementation of "ManyListings" remote procedure call
    */
    public async Task<List<ListingModel>> GetMany(int count, int skip) {
        //TODO: simple input checking

        ManyListingsRequest request = new ManyListingsRequest{Limit = (uint)count, Skip = (uint)skip};
        ManyListingsResponse response = await client.ManyListingsAsync(request);

        var listings = from listing in response.Listings select (ListingModel)listing;
        return listings.ToList();
    }

    ~ListingsDatabaseHandler()
    {
        _channel.Dispose();
    }
}