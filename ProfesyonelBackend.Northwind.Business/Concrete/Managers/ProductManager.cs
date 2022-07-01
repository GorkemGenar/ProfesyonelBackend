using ProfesyonelBackend.Core.Aspects.Postsharp.AuthorizationAspects;
using ProfesyonelBackend.Core.Aspects.Postsharp.CacheAspects;
using ProfesyonelBackend.Core.Aspects.Postsharp.LogAspects;
using ProfesyonelBackend.Core.Aspects.Postsharp.PerformanceAspects;
using ProfesyonelBackend.Core.Aspects.Postsharp.TransactionAspects;
using ProfesyonelBackend.Core.Aspects.Postsharp.ValidationAspects;
using ProfesyonelBackend.Core.CrossCuttingConcerns.Caching.Microsoft;
using ProfesyonelBackend.Core.CrossCuttingConcerns.Logging.Log4Net.Loggers;
using ProfesyonelBackend.Core.CrossCuttingConcerns.Validation.FluentValidation;
using ProfesyonelBackend.Northwind.Business.Abstract;
using ProfesyonelBackend.Northwind.Business.ValidationRules.FluentValidation;
using ProfesyonelBackend.Northwind.DataAccess.Abstract;
using ProfesyonelBackend.Northwind.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Transactions;

namespace ProfesyonelBackend.Northwind.Business.Concrete.Managers
{

    public class ProductManager : IProductService
    {
        IProductDal _productDal;

        public ProductManager(IProductDal productDal)
        {
            _productDal = productDal;
        }

        [TransactionScopeAspect]
        [FluentValidationAspect(typeof(ProductValidator))]
        public void TransactionalOperation(Product product1, Product product2)
        {
            using (TransactionScope scope = new TransactionScope())
            {
                _productDal.Add(product1);
                /*
                 .
                 .
                 Business Codes
                 .
                 .
                */
                _productDal.Update(product2);
            }
        }

        [FluentValidationAspect(typeof(ProductValidator))]
        [CacheRemoveAspect(typeof(MemoryCacheManager))]
        public Product Add(Product product)
        {
            return _productDal.Add(product);
        }

        [CacheAspect(typeof(MemoryCacheManager),60)]
        [LogAspect(typeof(DatabaseLogger))]
        [PerformanceCounterAspect(1)]
        [SecuredOperationAspect(Roles = "Admin,Editor")]
        public List<Product> GetAll()
        {
            Thread.Sleep(5000);
            return _productDal.GetList();
        }

        public Product GetById(int id)
        {
            return _productDal.Get(p => p.ProductId == id);
        }

        public Product Update(Product product)
        {
            return _productDal.Update(product);
        }
    }
}
