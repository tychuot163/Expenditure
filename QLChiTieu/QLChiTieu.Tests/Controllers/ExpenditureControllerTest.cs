
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using QLChiTieu.Models;
using QLChiTieu.Controllers;
namespace QLChiTieu.Tests.Controllers
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestIndex()
        {
            var db = new QLChiTieuEntities();
            var controller = new ChiTieuController();
            var result = controller.Index() as ViewResult;
            Assert.IsNotNull(result);
            var model = result.Model as List<Expenditure>;

            Assert.AreEqual(db.Expenditures.Count(),
                (model.Count));
        }
         [TestMethod]
        public void TestEditG()
        {
            var controller = new ChiTieuController();
            var result0 = controller.Edit(0);
            Assert.IsInstanceOfType(result0, typeof(HttpNotFoundResult));

            var db = new QLChiTieuEntities();
            var item = db.Expenditures.First();
            var result1 = controller.Edit(item.id) as ViewResult;
            Assert.IsNotNull(result1);
            var model = result1.Model as Expenditure;
            Assert.AreEqual(item.id, model.id);

        }
         [TestMethod]
         public void TestCreateG()
         {

             var controller = new ChiTieuController();

             var result = controller.Create() as ViewResult;

             Assert.IsNotNull(result);
         }
    }
}
