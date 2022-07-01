using Microsoft.VisualStudio.TestTools.UnitTesting;
using ProfesyonelBackend.Northwind.DataAccess.Concrete.EntityFramework;
using System;

namespace ProfesyonelBackend.Northwind.DataAccess.Tests.EntityFramework.Tests
{
    [TestClass]
    public class EntityFrameworkTest
    {
        [TestMethod]
        public void GetAll_returns_all_products()
        {
            EfProductDal productDal = new EfProductDal();

            var result = productDal.GetList();

            Assert.AreEqual(80, result.Count);
        }

        [TestMethod]
        public void GetAll_with_parameter_returns_filtered_products()
        {
            EfProductDal productDal = new EfProductDal();

            var result = productDal.GetList(p => p.ProductName.Contains("ab"));

            Assert.AreEqual(4, result.Count);
        }
    }
}
