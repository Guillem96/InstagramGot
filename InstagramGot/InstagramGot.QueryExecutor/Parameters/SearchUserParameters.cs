using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InstagramGot.Parameters
{
    public class SearchUserParameters : ISearchUserParameters
    {
        public string Query { get; set; }
        public int? Count { get; set; }
    }
}
