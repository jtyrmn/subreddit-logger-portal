namespace subreddit_logger_portal.Models;

public class ListingsDatabaseSettings
{
    public string? Address { get; set; } // internet address of subreddit-logger-database service

    // parameters for ManyListings page
    // how many listings to be displayed on a page at once
    public int? NumListingsPerPage { get; set; }
}