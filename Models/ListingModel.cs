using System.ComponentModel.Design;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace subreddit_logger_portal.Models;

/*
    an document directly from the listings database
*/
public class ListingModel
{

    public string? Id { get; set; }

    public ListingMetaDataModel? MetaData { get; set; }

    public List<ListingEntryModel>? Entries { get; set; }


    //the nested "listing" portion of the document
    public class ListingMetaDataModel
    {
        public string? ContentType { get; set; }
        public string? ListingId { get; set; }
        public string? Title { get; set; }
        public ulong? DateCreated { get; set; }
        public ulong? DateQueried { get; set; }
    }

    //a container for a single entry of many under "entries"
    public class ListingEntryModel
    {
        public uint? Upvotes { get; set; }
        public uint? Comments { get; set; }
        public ulong? DateQueried { get; set; }
    }

    /*
        pb.RedditContent is the generated class that the gRPC framework returns
        data from the database service as. It is 1 to 1 with ListingModel and
        we need to convert retrieved pb.RedditContent data to ListingModel for
        it to be easy to work with (views require ListingModels as the @Model
        for example.) 
    */
    public static explicit operator ListingModel(pb.RedditContent r) {
        ListingMetaDataModel metadata = new ListingMetaDataModel{
            ContentType = r.MetaData.ContentType,
            DateCreated = r.MetaData.DateCreated,
            DateQueried = r.MetaData.DateQueried,
            Title = r.MetaData.Title,
            ListingId = r.MetaData.Id
        };  
        var entries = from e in r.Entries select new ListingEntryModel{Comments = e.Comments, Upvotes = e.Upvotes, DateQueried = e.DateQueried};

        ListingModel listing = new ListingModel{
            Id = r.Id,
            MetaData = metadata,
            Entries = entries.ToList()
        };
        return listing;
    }
}