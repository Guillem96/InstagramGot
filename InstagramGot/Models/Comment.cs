using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InstagramGot.Models
{
    class Comment : IComment
    {
        private string text;
        private IMinifiedUser from;
        private long createdTimeUnixMiliseconds;
        private long id;

        public string Text { get => text; set => text = value; }
        public IMinifiedUser From { get => from; set => from = value; }
        public long CreatedTimeUnixMiliseconds { get => createdTimeUnixMiliseconds; set => createdTimeUnixMiliseconds = value; }
        public long Id { get => id; set => id = value; }

        public override string ToString()
        {
            return from.Username + " - " + text;
        }
    }
}
