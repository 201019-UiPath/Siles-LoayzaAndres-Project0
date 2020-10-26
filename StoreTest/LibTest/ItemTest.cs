using System;
using StoreLib;
using Xunit;

namespace StoreTest
{
    public class ItemTest
    {
        [Fact]
        public void ItemShouldGenerateUniqueId()
        {
            //Arrange & Act
            Item item = new Item(2.99M, "apple", "This is an apple.", 100);

            //Assert
            //Console.WriteLine($"Item ID: {item.Id}");
            Assert.NotNull(item.Id);
        }
    }
}
