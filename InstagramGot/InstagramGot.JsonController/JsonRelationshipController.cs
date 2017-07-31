using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InstagramGot.JsonController
{
    class JsonRelationshipController : IJsonRelationshipController
    {
        public Models.IRelationship MapjsonToRelationship(string json)
        {
            JObject jObject = JObject.Parse(json);
            JToken jRelation = jObject["data"];

            return new Models.Relationship(jRelation["outgoing_status"].ToString(), 
                                            jRelation["incoming_status"].ToString());
        }
    }
}
