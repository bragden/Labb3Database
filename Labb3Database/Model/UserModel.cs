using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labb3Database.Model
{
    public class UserModel
    {
        [BsonId]
        public Guid Id { get; set; }

        public string UserName { get; set; }
        public string Password { get; set; }

        public UserModel(string username, string password)
        {
            UserName = username;
            Password = password;

        }
    }
}
