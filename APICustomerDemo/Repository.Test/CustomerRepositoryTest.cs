using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Repository.Test
{
    [TestClass]
    public class CustomerRepositoryTest
    {
        [TestMethod]
        public void CustomerNotNullWithValidId()
        {
            //Arrange
            var rep = new CustomerRepository();
            //Act
            var actual = rep.GetCustomerById("702010");
            //Assert
            Assert.IsNotNull(actual);


        }


        [TestMethod]
        public void CustomerWithCriteriaNotNull()
        {
            //Arrange
            var rep = new CustomerRepository();
            //Act
            var actual = rep.GetCustomersListWithCriteria();
            //Assert
            Assert.IsNotNull(actual);


        }
    }
}
