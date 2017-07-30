using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InstagramGot.Models
{
    public enum OutgoingRelationshipStatus { None, Follows, Requested }
    public enum IngoingRelationshipStatus { None, BlockedByYou, FollowedBy, RequestedBy }

    class Relationship : IRelationship
    {
        /// <summary>
        /// Your relationship to the user.
        /// </summary>
        public OutgoingRelationshipStatus OutgoingRelation { get; set; }

        /// <summary>
        /// A user's relationship to you
        /// </summary>
        public IngoingRelationshipStatus IngoingRelation { get; set; }

        public Relationship(string outgoing, string incoming)
        {
            switch (outgoing)
            {
                case "none":
                    OutgoingRelation = OutgoingRelationshipStatus.None;
                    break;
                case "follows":
                    OutgoingRelation = OutgoingRelationshipStatus.Follows;
                    break;
                case "requested":
                    OutgoingRelation = OutgoingRelationshipStatus.Requested;
                    break;
            }

            switch (outgoing)
            {
                case "none":
                    IngoingRelation = IngoingRelationshipStatus.None;
                    break;
                case "followed_by":
                    IngoingRelation = IngoingRelationshipStatus.FollowedBy;
                    break;
                case "requested_by":
                    IngoingRelation = IngoingRelationshipStatus.FollowedBy;
                    break;
                case "blocked_by_you":
                    IngoingRelation = IngoingRelationshipStatus.FollowedBy;
                    break;
            }
        }
    }
}
