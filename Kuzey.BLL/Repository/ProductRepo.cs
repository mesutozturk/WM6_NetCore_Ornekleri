using Kuzey.BLL.Repository.Abstracts;
using Kuzey.DAL;
using Kuzey.Models.Entities;

namespace Kuzey.BLL.Repository
{
    public class ProductRepo : RepositoryBase<Product, string>
    {
        private readonly MyContext _dbContext;
        public ProductRepo(MyContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }
    }
}
