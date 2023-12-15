using MongoDB.Driver;
using Labb3Database.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labb3Database.Data
{
    public class MongoCRUD
    {

        private IMongoDatabase db;
        public MongoCRUD(string database)
        {
            var client = new MongoClient("");
            db = client.GetDatabase(database);
        }

        public void CreateUser(string table, UserModel user)
        {
            var collection = db.GetCollection<UserModel>(table);
            collection.InsertOne(user);
        }
        public List<UserModel> GetAllUsers(string table)
        {
            var collection = db.GetCollection<UserModel>(table);
            return collection.Find(_ => true).ToList();
        }

        public UserModel GetUserById(string table, Guid id)
        {
            var collection = db.GetCollection<UserModel>(table);
            return collection.AsQueryable().ToList().Find(x => x.Id == id);
        }

        public bool UserExists(string table, string username, string password)
        {

            List<UserModel> users = new List<UserModel>();
            users = GetAllUsers(table);

            foreach (UserModel user in users)
            {
                if (user.UserName == username && user.Password == password)
                {
                    return true;
                }
            }

            return false;
        }
        public void AddUser(string table, UserModel user)
        {
            var collection = db.GetCollection<UserModel>(table);
            collection.InsertOne(user);
        }
    }
}
