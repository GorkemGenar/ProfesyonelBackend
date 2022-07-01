using ProfesyonelBackend.Core.DataAccess;
using ProfesyonelBackend.Northwind.Entities.ComplexTypes;
using ProfesyonelBackend.Northwind.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProfesyonelBackend.Northwind.DataAccess.Abstract
{
    public interface IProductDal:IEntityRepository<Product>
    {
        List<ProductDetails> GetProductDetails();
    }
}
