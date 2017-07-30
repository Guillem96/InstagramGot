using InstagramGot.Models;

namespace InstagramGot.JsonController
{
    interface IJsonRelationshipController
    {
        IRelationship MapjsonToRelationship(string json);
    }
}