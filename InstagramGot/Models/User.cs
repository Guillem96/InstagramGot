using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InstagramGot.Models
{
    internal class User : IUser
    {
        private long id;
        private string username;
        private string profilePicture;
        private string fullName;
        private string bio;
        private string website;
        private int media;
        private int follows;
        private int followedBy;

        /// <summary>
        /// User identifier.
        /// </summary>
        public long Id { get => id; set => id = value; }

        /// <summary>
        /// Get the user username.
        /// </summary>
        public string Username { get => username; set => username = value; }

        /// <summary>
        /// Get profile image url.
        /// </summary>
        public string ProfilePictureUrl { get => profilePicture; set => profilePicture = value; }

        /// <summary>
        /// Get user full name. Including first name and last name.
        /// </summary>
        public string FullName { get => fullName; set => fullName = value; }

        /// <summary>
        /// Get user description.
        /// </summary>
        public string Bio { get => bio; set => bio = value; }

        /// <summary>
        /// Get url of user's webpage. Null if he don't own one.
        /// </summary>
        public string Website { get => website; set => website = value; }

        /// <summary>
        /// Number of posts.
        /// </summary>
        public int Media { get => media; set => media = value; }

        /// <summary>
        /// Number of follows
        /// </summary>
        public int Follows { get => follows; set => follows = value; }

        /// <summary>
        /// Number of followers.
        /// </summary>
        public int FollowedBy { get => followedBy; set => followedBy = value; }

        public User ()
        {
            
        }

        public override string ToString()
        {
            return "User: " + FullName + " - " + Username;
        }
    }
}
