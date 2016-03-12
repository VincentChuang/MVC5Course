using System;
using System.Linq;
using System.Collections.Generic;
	
namespace MVC5Course.Models
{   
	public  class ProductRepository : EFRepository<Product>, IProductRepository
	{

        public override IQueryable<Product> All() {
            return base.All().Where(x => x.isDelete == false);
        }

        public IQueryable<Product> All(bool isAll) {
            if (isAll) {
                return base.All();
            } else {
                return this.All();
            }
        }

        public Product Find(int id) {
            return base.All().FirstOrDefault(x => x.ProductId == id);
        }

	}

	public  interface IProductRepository : IRepository<Product>
	{

	}
}