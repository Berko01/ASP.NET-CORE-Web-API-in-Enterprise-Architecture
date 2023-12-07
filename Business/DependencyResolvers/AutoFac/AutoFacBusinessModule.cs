using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autofac;
using Business.Abstract;
using Business.Concrete;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;

namespace Business.DependencyResolvers.AutoFac
{
	public class AutoFacBusinessModule:Module
	{
		protected override void Load(ContainerBuilder builder)
		{
			builder.RegisterType<ProductManager>().As<IProductService>();
			builder.RegisterType<EfProductDal>().As<IProductDal>();


		}
	}
}
