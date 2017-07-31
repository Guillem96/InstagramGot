using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InstagramGot.Models
{
    class Tag : ITag
    {
        public int MediaCount { get; set; }
        public string Name { get; set; }

        public override string ToString()
        {
            return "Tag: " + Name;
        }
    }
}
