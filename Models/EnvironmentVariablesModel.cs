namespace subreddit_logger_portal.Models;

/*
    This class stores all the environment variables that are retrieved from
    the host and used in this program.
*/

public class EnvironmentVariablesModel {

    public string? SUBREDDIT_LOGGER_DATABASE_LOCATION {get; set;} // connection string to database

    public int? NUM_DISPLAY_LISTINGS {get; set;} // how many listings to be displayed on the manylistings page at a time
}