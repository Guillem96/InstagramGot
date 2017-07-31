using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InstagramGot.Models
{
    internal class MinifiedUser : IMinifiedUser
    {
        public long Id { get; set; }
        public string Username { get; set; }
        public string ProfileImageUrl { get; set; }
        public string FullName { get; set; }

        public bool Equals(IMinifiedUser other)
        {
            return Id == other.Id;
        }

        public override string ToString()
        {
            return "Minidied User: " + Username;
        }
    }
}
