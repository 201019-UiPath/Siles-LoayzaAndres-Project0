using System;
using StoreLib;
using Xunit;

namespace StoreTest
{
    public class ProductTest
    {
        [Fact]
        public void ProductShouldGenerateUniqueId()
        {
            //Arrange & Act
            Product product = new Product(2.99M, "apple", "This is an apple.", 100);

            //Assert
            //Console.WriteLine($"Product ID: {product.Id}");
            Assert.NotNull(product.Id);
        }
    }
}
