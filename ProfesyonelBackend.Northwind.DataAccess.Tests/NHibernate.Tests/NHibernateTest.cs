using Microsoft.VisualStudio.TestTools.UnitTesting;
using ProfesyonelBackend.Northwind.DataAccess.Concrete.NHibernate;
using ProfesyonelBackend.Northwind.DataAccess.Concrete.NHibernate.Helpers;
using System;

namespace ProfesyonelBackend.Northwind.DataAccess.Tests.NHibernate.Tests
{
    [TestClass]
    public class NHibernateTest
    {
        [TestMethod]
        public void GetAll_returns_all_products()
        {
            NhProductDal productDal = new NhProductDal(new SqlServerHelper());

            var result = productDal.GetList();

            Assert.AreEqual(80, result.Count);
        }

        [TestMethod]
        public void GetAll_with_parameter_returns_filtered_products()
        {
            NhProductDal productDal = new NhProductDal(new SqlServerHelper());

            var result = productDal.GetList(p => p.ProductName.Contains("ab"));

            Assert.AreEqual(4, result.Count);
        }
    }
}
