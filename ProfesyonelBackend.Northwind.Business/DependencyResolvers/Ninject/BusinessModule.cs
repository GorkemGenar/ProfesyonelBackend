using Ninject.Modules;
using ProfesyonelBackend.Core.DataAccess;
using ProfesyonelBackend.Core.DataAccess.EntityFramework;
using ProfesyonelBackend.Core.DataAccess.NHibernate;
using ProfesyonelBackend.Northwind.Business.Abstract;
using ProfesyonelBackend.Northwind.Business.Concrete.Managers;
using ProfesyonelBackend.Northwind.DataAccess.Abstract;
using ProfesyonelBackend.Northwind.DataAccess.Concrete.EntityFramework;
using ProfesyonelBackend.Northwind.DataAccess.Concrete.NHibernate.Helpers;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProfesyonelBackend.Northwind.Business.DependencyResolvers.Ninject
{
    public class BusinessModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IProductService>().To<ProductManager>().InSingletonScope();

            Bind<IProductDal>().To<EfProductDal>();

            Bind(typeof(IQueryableRepository<>)).To(typeof(EfQueryableRepository<>));

            Bind<DbContext>().To<NorthwindContext>();

            Bind<NHibernateHelper>().To<SqlServerHelper>();
        }
    }
}