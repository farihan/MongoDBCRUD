using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hans.MongoDB
{
    public class Repository<T>
    {
        private IMongoCollection<T> Collection { get; set; }

        public Repository(string collection)
        {
            var connectionstring = string.Empty;

            if (!string.IsNullOrEmpty(ConfigurationManager.AppSettings.Get("MONGOLAB_URI")))
                connectionstring = ConfigurationManager.AppSettings.Get("MONGOLAB_URI");
            else
                connectionstring = ConfigurationManager.ConnectionStrings["MONGOLAB_URI"].ConnectionString;
            
            var url = new MongoUrl(connectionstring);
            var client = new MongoClient(url);
            var server = client.GetDatabase(url.DatabaseName);

            Collection = server.GetCollection<T>(collection);
        }

        public async Task<T> Get(System.Linq.Expressions.Expression<Func<T, bool>> where)
        {
            return await Collection.Find(where).SingleAsync();
        }

        public async Task Save(T instance)
        {
            await Collection.InsertOneAsync(instance);
        }

        public async Task Delete(System.Linq.Expressions.Expression<Func<T, bool>> where)
        {
            await Collection.DeleteOneAsync(where);
        }

        public async Task Update(System.Linq.Expressions.Expression<Func<T, bool>> where, T instance)
        {
            await Collection.ReplaceOneAsync(where, instance);
        }

        public async Task<IList<T>> FindAll()
        {
            return await Collection.Find("{}").ToListAsync();
        }

        public async Task<IList<T>> FindAllBy(System.Linq.Expressions.Expression<Func<T, bool>> where)
        {
            return await Collection.Find(where).ToListAsync();
        }
    }
}
