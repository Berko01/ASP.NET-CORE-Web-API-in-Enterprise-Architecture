using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;

namespace Business.Concrete
{
	public class ProductManager : IProductService
	{
		private IProductDal _productDal;

		public ProductManager(IProductDal productDal)
		{
			_productDal = productDal;
		}

		public List<Product> GetList()
		{
			return _productDal.GetList().ToList();
		}

		public List<Product> GetListByCategory(int categoryId)
		{
			return _productDal.GetList(p => p.CategoryId == categoryId).ToList();
		}

		public void Add(Product product)
		{
			//Business Codes
			_productDal.Add(product);
		}

		public void Delete(Product product)
		{
			_productDal.Delete(product);
		}

		public void Update(Product product)
		{
			_productDal.Update(product);
		}

		public Product GetById(int productId)
		{
			return _productDal.Get(p => p.ProductId == productId);
		}
	}
}
