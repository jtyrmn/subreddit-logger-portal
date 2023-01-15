namespace subreddit_logger_portal.Models;

/*
    container for passing multiple listings into a View
*/
public class ManyListingsViewModel
{
    public List<ListingModel> Listings { get; }

    public ManyListingsViewModel(List<ListingModel> listings)
    {
        this.Listings = listings;
    }
}