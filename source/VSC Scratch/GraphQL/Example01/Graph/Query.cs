using HotChocolate;
using Example01.Data;
using System.Linq;

namespace Example01.Graph
{
    public class Query
    {
        public IQueryable<Product> GetProducts([Service] ApplicationDbContext context) => context.Products;
    }
}