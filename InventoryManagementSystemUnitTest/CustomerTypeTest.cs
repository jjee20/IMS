using InfastructureLayer.DataAccess.Data;
using System.Collections.Generic;

namespace InventoryManagementSystemUnitTest
{
    public class CustomerTypeTest
    {
        [Fact]
        public void Update()
        {
            var options = new DbContextOptionsBuilder<ApplicationDataContext>()
                .UseInMemoryDatabase(databaseName: "TestDatabase")
                .Options;
            var dbContext = new ApplicationDataContext(options);
            var mockDbSet = new Mock<DbSet<CustomerType>>();
            var customerType = new CustomerType { /* initialize properties */ };

            mockDbSet.Setup(x => x.Find(It.IsAny<object[]>())).Returns(customerType);
            dbContext.CustomerType = mockDbSet.Object;

            var repository = new CustomerTypeRepository(dbContext);

            // Act
            repository.Update(customerType);

            // Assert
            mockDbSet.Verify(db => db.Attach(customerType), Times.Once);
            mockDbSet.Verify(db => db.Update(customerType), Times.Once);
            dbContext.SaveChanges();
        }
    }
}