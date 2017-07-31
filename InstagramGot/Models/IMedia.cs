using System.Collections.Generic;

namespace InstagramGot.Models
{
    public interface IMedia
    {
        IMinifiedUser CreatedBy { get; set; }
        int CommentsCount { get; set; }
        long CreatedTimeUnixMiliseconds { get; set; }
        string Id { get; set; }
        string ImageLowResolutionUrl { get; set; }
        string ImageStandardResolutionUrl { get; set; }
        string ImageThumbnailUrl { get; set; }
        int LikesCount { get; set; }
        ILocation Location { get; set; }
        string MediaUrl { get; set; }
        string Text { get; set; }
        List<IMinifiedUser> UsersInPhoto { get; set; }
        List<string> Tags { get; set; }
    }
}