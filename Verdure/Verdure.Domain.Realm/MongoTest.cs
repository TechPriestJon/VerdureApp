using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using Realms;
using System.Collections.Generic;

namespace Verdure.Domain.Realm
{
    public class MongoTest : RealmObject
    {
        //        [PrimaryKey]
        //        [MapTo("_id")]
        //        public ObjectId Id { get; set; } = ObjectId.GenerateNewId();


        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [MapTo("_partition")]
        public string Partition { get; set; }
//        [MapTo("assignee")]
//        public User Assignee { get; set; }
        [MapTo("name")]
        [Required]
        public string Name { get; set; }
        [MapTo("status")]
        [Required]
        public string Status { get; set; }
        //[MapTo("listofnumbers")]
        //public IList<int> ListOfNumbers { get; set; }
    }
    public enum TaskStatus
    {
        Open,
        InProgress,
        Complete
    }
}