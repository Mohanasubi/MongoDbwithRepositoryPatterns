namespace ASP.MongoDb.API.Repository
{
    public interface IRepository<T> where T : class
    {
        //retrives all documents of type T from the database
        Task<IEnumerable<T>> GetAllAsync();
        //retrieves a single document of type T by its id from the database

        Task<T?> GetByIdAsync(string id);
        //creates a new document of type T in the database
        Task CreateAsync(T entity);
        //updates an existing document of type T in the database by its id
        Task UpdateAsync(string id, T entity);
        //deletes a document of type T from the database by its id
        Task DeleteAsync(string id);
    }
    
}
