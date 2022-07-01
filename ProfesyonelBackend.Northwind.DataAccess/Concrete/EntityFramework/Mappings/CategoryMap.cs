using ProfesyonelBackend.Northwind.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProfesyonelBackend.Northwind.DataAccess.Concrete.EntityFramework.Mappings
{
    public class CategoryMap : EntityTypeConfiguration<Category>
    {
        public CategoryMap()
        {
            ToTable(@"Categories", @"dbo"); // Hangi tabloya eşitlenicekse (şema (dbo) ile birlikte)
            HasKey(x => x.CategoryId); // PrimaryKey eşitleme

            //Class daki property'leri, kolonlarla eşitleme
            Property(x => x.CategoryId).HasColumnName("CategoryID");
            Property(x => x.CategoryName).HasColumnName("CategoryName");
        }
    }
}
