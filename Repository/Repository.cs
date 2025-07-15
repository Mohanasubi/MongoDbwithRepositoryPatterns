
using ASP.MongoDb.API.Settings;
using Microsoft.Extensions.Options;
using MongoDB.Bson;
using MongoDB.Driver;

namespace ASP.MongoDb.API.Repository
{
    // Fix: Make the Repository class generic by adding a type parameter T.  
    public class Repository<T> : IRepository<T> where T : class
    {
        public readonly IMongoCollection<T> _collection;
        public Repository(IOptions<MongoDbSettings> settings)
        {
            //instance of mongodb client
            var client = new MongoClient(settings.Value.ConnectionString);

            //get the database name from settings
            var database= client.GetDatabase(settings.Value.DatabaseName);

            //get the collection name from the database
            _collection = database.GetCollection<T>(typeof(T).Name);


        }

        //method to Get all the objects
        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _collection.Find(emp => true).ToListAsync();
        }

        //get by id
        public async Task<T?> GetByIdAsync(string id)

        {
            return await _collection.Find(Builders<T>.Filter.Eq("Id", id)).FirstOrDefaultAsync();
        }
        //create a new object
        public async Task CreateAsync(T entity)
        {

            await _collection.InsertOneAsync(entity);

        }

        //method to delete a object
        public async Task DeleteAsync(string id)
        {  
           
            await _collection.DeleteOneAsync(Builders<T>.Filter.Eq("Id", id));
            
        }

        //method to update the object
        public async Task UpdateAsync(string id, T entity)
        {
           
            await _collection.ReplaceOneAsync(
                Builders<T>.Filter.Eq("Id", id),
                entity
            );
        }
    }
}
