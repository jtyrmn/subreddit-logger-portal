using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace subreddit_logger_portal.Models;

/*
    an document directly from the listings database
*/
public class ListingModel
{

    [BsonId]
    public string? Id { get; set; }

    [BsonElement("listing")]
    public ListingMetaDataModel? MetaData { get; set;}

    [BsonElement("entries")]
    public List<ListingEntryModel>? Entries { get; set; }


    //the nested "listing" portion of the document
    [BsonIgnoreExtraElements]
    public class ListingMetaDataModel
    {
        [BsonElement("contenttype")]
        public string? ContentType { get; set; }

        [BsonElement("id")]
        public string? ListingId { get; set; }

        [BsonElement("title")]
        public string? Title { get; set; }

        [BsonElement("date")]
        public Int32? DateCreated { get; set; }

        [BsonElement("querydate")]
        public Int32? DateQueried { get; set; }
    }

    //a container for a single entry of many under "entries"
    [BsonIgnoreExtraElements]
    public class ListingEntryModel
    {
        [BsonElement("upvotes")]
        public int? Upvotes { get; set; }

        [BsonElement("comments")]
        public int? Comments { get; set; }

        [BsonElement("date")]
        public Int32? DateQueried { get; set; }
    }


}