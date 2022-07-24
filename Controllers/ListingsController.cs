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

    public async Task<IActionResult> Index(string id = "n/a")
    {
        //for the meantime, just grab and display everything
        List<ListingModel> listings = await listingsService.GetAll();
        return View(new ListingsViewModel(listings));
    }
}
