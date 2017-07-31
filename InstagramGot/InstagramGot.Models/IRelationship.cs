namespace InstagramGot.Models
{
    public interface IRelationship
    {
        IngoingRelationshipStatus IngoingRelation { get; set; }
        OutgoingRelationshipStatus OutgoingRelation { get; set; }
    }
}