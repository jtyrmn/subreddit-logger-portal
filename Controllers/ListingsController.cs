using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.TagHelpers;
using Microsoft.AspNetCore.Server.IIS.Core;
using subreddit_logger_portal.Models;
using subreddit_logger_portal.Services;

namespace subreddit_logger_portal.Controllers;

// /listings endpoint
public class ListingsController : Controller
{
    private readonly ListingsService _listingsService;
    private readonly ILogger<ListingsController> _logger;

    public ListingsController(ListingsService listingsService, ILogger<ListingsController> logger)
    {
        this._listingsService = listingsService;
        this._logger = logger;
    }

    // get a single specific listing
    public async Task<IActionResult> Single(string? id) {
        if(!String.IsNullOrEmpty(id)) {
            ListingModel listing = await _listingsService.GetOne(id);
            return View("Single", new SingleListingViewModel(listing));
        } else {
            throw new Exception("missing id");
        }
        
    }

    // generic page of many listings
    public async Task<IActionResult> Index(int? skip)
    {   
        List<ListingModel> listings = await _listingsService.GetMany(skip ?? 0);
        return View("Many", new ManyListingsViewModel(listings));
    }
}
