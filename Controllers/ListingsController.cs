using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.TagHelpers;
using Microsoft.AspNetCore.Server.IIS.Core;
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

    public async Task<IActionResult> Index(string? id = "")
    {
        // is the path parameter specified?
        if (!String.IsNullOrWhiteSpace(id))
        {
            // specific listing
            ListingModel listing = await listingsService.GetOne(id);
            return View("Single", new SingleListingViewModel(listing));
        }
        else
        {
            // generic page of arbitrary listings
            List<ListingModel> listings = await listingsService.GetMany(0);
            return View("Many", new ManyListingsViewModel(listings));
        }
    }
}
