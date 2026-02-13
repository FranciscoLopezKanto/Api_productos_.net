using CrudMongoApi.Config;
using CrudMongoApi.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace CrudMongoApi.Services;

public class ProductService
{
    private readonly IMongoCollection<Product> _products;

    public ProductService(IOptions<MongoDbSettings> settings)
    {
        var cfg = settings.Value;

        var client = new MongoClient(cfg.ConnectionString);
        var db = client.GetDatabase(cfg.DatabaseName);

        _products = db.GetCollection<Product>(cfg.CollectionName);
    }

    public async Task<List<Product>> GetAllAsync() =>
        await _products.Find(_ => true).ToListAsync();

    public async Task<Product?> GetByIdAsync(string id) =>
        await _products.Find(x => x.Id == id).FirstOrDefaultAsync();

    public async Task<Product> CreateAsync(Product p)
    {
        p.Id = null; // asegura insert
        await _products.InsertOneAsync(p);
        return p;
    }

    public async Task<bool> UpdateAsync(string id, Product p)
    {
        p.Id = id;
        var result = await _products.ReplaceOneAsync(x => x.Id == id, p);
        return result.ModifiedCount > 0;
    }

    public async Task<bool> DeleteAsync(string id)
    {
        var result = await _products.DeleteOneAsync(x => x.Id == id);
        return result.DeletedCount > 0;
    }
}