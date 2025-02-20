using NUnit.Framework;
using Microsoft.EntityFrameworkCore;
using Data;
using Data.Entities;
using Web.Controllers;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace Test
{
    [TestFixture]
    public class ProductControllerTests
    {
        [Test]
        public async Task Index_ReturnsAViewResultWithProducts()
        {
            var options = new DbContextOptionsBuilder<ShopContext>()
                .UseInMemoryDatabase("TestDb")
                .Options;
            using var context = new ShopContext(options);

            context.Products.Add(new ProductEntity { Id = 1, Name = "Test Product", Price = 99.99M });
            context.SaveChanges();

            var controller = new ProductController(context);

            var result = await controller.Index();

        }
    }
}
