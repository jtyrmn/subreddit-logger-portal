namespace subreddit_logger_portal.Models;

public class ListingsDatabaseSettings
{
    public string ConnectionString { get; set; } = null!;

    public string DatabaseName { get; set; } = null!;

    public string ListingsCollectionName { get; set; } = null!;
}