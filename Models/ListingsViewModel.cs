namespace subreddit_logger_portal.Models;


/*
    container for passing multiple listings into a View
*/
public class ListingsViewModel
{
    public List<ListingModel> Listings { get; }

    public ListingsViewModel(List<ListingModel> listings)
    {
        this.Listings = listings;
    }
}