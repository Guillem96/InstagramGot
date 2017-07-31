using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InstagramGot.Models
{
    internal class Media : IMedia, IEquatable<IMedia>
    {
        private IMinifiedUser createdBy;
        private string imageThumbnailUrl;
        private string imageLowResolutionUrl;
        private string imageStandardResolutionUrl;
        private long createdTimeUnixMiliseconds;
        private string id;
        private string text;
        private int likesCount;
        private int commentsCount;
        private string mediaUrl;
        private List<string> tags;
        private List<IMinifiedUser> usersInPhoto;
        private ILocation location;

        public string ImageThumbnailUrl { get => imageThumbnailUrl; set => imageThumbnailUrl = value; }
        public string ImageLowResolutionUrl { get => imageLowResolutionUrl; set => imageLowResolutionUrl = value; }
        public string ImageStandardResolutionUrl { get => imageStandardResolutionUrl; set => imageStandardResolutionUrl = value; }
        public long CreatedTimeUnixMiliseconds { get => createdTimeUnixMiliseconds; set => createdTimeUnixMiliseconds = value; }
        public string Id { get => id; set => id = value; }
        public string Text { get => text; set => text = value; }
        public int LikesCount { get => likesCount; set => likesCount = value; }
        public int CommentsCount { get => commentsCount; set => commentsCount = value; }
        public string MediaUrl { get => mediaUrl; set => mediaUrl = value; }
        public ILocation Location { get => location; set => location = value; }
        public IMinifiedUser CreatedBy { get => createdBy; set => createdBy = value; }
        public List<IMinifiedUser> UsersInPhoto { get => usersInPhoto; set => usersInPhoto = value; }
        public List<string> Tags { get => tags; set => tags = value; }

        public bool Equals(IMedia other)
        {
            return createdBy.Equals(other.CreatedBy) &&
                ImageLowResolutionUrl.Equals(other.ImageLowResolutionUrl) &&
                ImageStandardResolutionUrl.Equals(other.ImageStandardResolutionUrl) &&
                ImageThumbnailUrl.Equals(other.ImageThumbnailUrl) &&
                CreatedTimeUnixMiliseconds == other.CreatedTimeUnixMiliseconds &&
                id.Equals(other.Id) &&
                Text.Equals(other.Text) &&
                LikesCount == other.LikesCount &&
                commentsCount == other.CommentsCount &&
                MediaUrl.Equals(other.MediaUrl) &&
                Location.Equals(other.Location) &&
                UsersInPhoto.Equals(other.UsersInPhoto) &&
                Tags.Equals(other);
        }

        public override string ToString()
        {
            return "Media: " + CreatedBy.Username;
        }
    }
}
