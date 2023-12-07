using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Concrete.EntityFramework.Contexts
{
	public class NorthwindContext:DbContext
	{
		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
            optionsBuilder.UseSqlServer(@"Data Source=BEKOPC\SQLEXPRESS;Initial Catalog=Northwind;Integrated Security=True; trustServerCertificate=true");
		}

		public DbSet<Product> Products { get; set; }

	}
}
