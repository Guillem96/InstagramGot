using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InstagramGot.Parameters
{
    public class UsersQueryParameters : IUsersQueryParameters
    {
        public int? Count {get;set; }
        public long Id { get; set; }
    }
}
