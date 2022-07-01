using ProfesyonelBackend.Core.DataAccess.NHibernate;
using ProfesyonelBackend.Northwind.DataAccess.Abstract;
using ProfesyonelBackend.Northwind.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProfesyonelBackend.Northwind.DataAccess.Concrete.NHibernate
{
    class NhCategoryDal : NhEntityRepositoryBase<Category>, ICategoryDal
    {
        public NhCategoryDal(NHibernateHelper nHibernateHelper) : base(nHibernateHelper)
        {

        }
    }
}
