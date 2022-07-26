using Microsoft.AspNetCore.Mvc;
using subreddit_logger_portal.Models;
using subreddit_logger_portal.Services;

namespace subreddit_logger_portal.Controllers;

// /listings endpoint
public class ListingsController : Controller
{
    private readonly ListingsService listingsService;

    public ListingsController(ListingsService listingsService)
    {
        this.listingsService = listingsService;
    }

    public async Task<IActionResult> Index(string? id)
    {
        //if the url contains an ID
        if (id is not null)
        {
            ListingModel? listing = await listingsService.Get(id);
            //not found?
            if (listing is null)
            {
                Response.StatusCode = StatusCodes.Status404NotFound;
                return View("NotFound");
            }

            return View("SingleListing", listing);
        }
        else
        {
            //if no ID, return everything
            List<ListingModel> listings = await listingsService.GetAll();
            //not found?
            if (listings is null)
            {
                Response.StatusCode = StatusCodes.Status404NotFound;
                return View("NotFound");
            }

            return View("ManyListings", new ListingsViewModel(listings));
        }
    }
}
