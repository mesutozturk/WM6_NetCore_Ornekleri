using Kuzey.BLL.Repository.Abstracts;
using Kuzey.DAL;
using Kuzey.Models.Entities;

namespace Kuzey.BLL.Repository
{
    public class CategoryRepo : RepositoryBase<Category, int>
    {
        private readonly MyContext _dbContext;
        public CategoryRepo(MyContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }
    }
}
