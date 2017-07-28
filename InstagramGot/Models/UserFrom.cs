using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InstagramGot.Models
{
    internal class UserFrom : IUserFrom
    {
        public long Id { get; set; }
        public string Username { get; set; }
        public string ProfileImageUrl { get; set; }
    }
}
