using Microsoft.AspNetCore.Mvc;

namespace subreddit_logger_portal.Controllers;

public class ListingsController : Controller
{

    public string Index(string id = "n/a")
    {
        return $"id is {id}";
    }
}
