using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hans.MongoDB
{
    public class Repository<T>
    {
        private MongoClient _mongoClient;
        private IMongoDatabase _mongoDatabase;
        private IMongoCollection<T> _collection;

        public Repository(string collection)
        {
            _mongoClient = new MongoClient("mongodb://localhost/Personal");
            _mongoDatabase = _mongoClient.GetDatabase("Northwind");
            _collection = _mongoDatabase.GetCollection<T>(collection);
        }

        public async Task<T> Get(System.Linq.Expressions.Expression<Func<T, bool>> where)
        {
            return await _collection.Find(where).SingleAsync();
        }

        public async Task Save(T instance)
        {
            await _collection.InsertOneAsync(instance);
        }

        public async Task Delete(System.Linq.Expressions.Expression<Func<T, bool>> where)
        {
            await _collection.DeleteOneAsync(where);
        }

        public async Task Update(System.Linq.Expressions.Expression<Func<T, bool>> where, T instance)
        {
            await _collection.ReplaceOneAsync(where, instance);
        }

        public async Task<IList<T>> FindAll()
        {
            return await _collection.Find("{}").ToListAsync();
        }

        public async Task<IList<T>> FindAllBy(System.Linq.Expressions.Expression<Func<T, bool>> where)
        {
            return await _collection.Find(where).ToListAsync();
        }
    }
}
