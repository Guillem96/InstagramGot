using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InstagramGot.Models
{
    internal class Media : IMedia
    {
        private IMinifiedUser createdBy;
        private string imageThumbnailUrl;
        private string imageLowResolutionUrl;
        private string imageStandardResolutionUrl;
        private long createdTimeUnixMiliseconds;
        private long id;
        private string text;
        private int likesCount;
        private int commentsCount;
        private string mediaUrl;
        // TODO:Tags
        private List<IMinifiedUser> usersInPhoto;
        private ILocation location;

        public string ImageThumbnailUrl { get => imageThumbnailUrl; set => imageThumbnailUrl = value; }
        public string ImageLowResolutionUrl { get => imageLowResolutionUrl; set => imageLowResolutionUrl = value; }
        public string ImageStandardResolutionUrl { get => imageStandardResolutionUrl; set => imageStandardResolutionUrl = value; }
        public long CreatedTimeUnixMiliseconds { get => createdTimeUnixMiliseconds; set => createdTimeUnixMiliseconds = value; }
        public long Id { get => id; set => id = value; }
        public string Text { get => text; set => text = value; }
        public int LikesCount { get => likesCount; set => likesCount = value; }
        public int CommentsCount { get => commentsCount; set => commentsCount = value; }
        public string MediaUrl { get => mediaUrl; set => mediaUrl = value; }
        public ILocation Location { get => location; set => location = value; }
        public IMinifiedUser CreatedBy { get => createdBy; set => createdBy = value; }
        public List<IMinifiedUser> UsersInPhoto { get => usersInPhoto; set => usersInPhoto = value; }
    }
}
