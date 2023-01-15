using System.ComponentModel.DataAnnotations;

namespace subreddit_logger_portal.Models;

/*
    container for passing multiple listings into a View
*/
public class SingleListingViewModel
{
    public ListingModel Listing { get; }

    public SingleListingViewModel(ListingModel listing)
    {
        this.Listing = listing;
    }
}