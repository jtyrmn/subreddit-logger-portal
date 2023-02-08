namespace subreddit_logger_portal.Models;

/*
    container for passing multiple listings into a View
*/
public class ManyListingsViewModel
{
    public List<ListingModel> Listings { get; }
    public int? skip {get; set;} // for pagination support

    public ManyListingsViewModel(List<ListingModel> listings, int? skip)
    {
        this.Listings = listings;
        this.skip = skip;
    }
}