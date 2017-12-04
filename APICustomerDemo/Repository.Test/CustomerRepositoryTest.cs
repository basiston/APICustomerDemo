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
        public void CustomerWithFakeId()
        {
            //Arrange
            var rep = new CustomerRepository();
            //Act
            var actual = rep.GetCustomerById("1");
            //Assert
            Assert.IsNull(actual);
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

        [TestMethod]
        public void CustomerWithCriteriaCount()
        {
            //Arrange
            var rep = new CustomerRepository();
            var expected = 20;
            //Act
            var actual = rep.GetCustomersListWithCriteria();
            //Assert
            Assert.AreEqual(expected, actual.Count);
        }


        [TestMethod]
        public void CustomerUpdateTest()
        {
            //Arrange
            var rep = new CustomerRepository();
            var expected = "Y";
            //Act
            var actual = rep.UpdateCustomer("21671400", "Y").SamtykkeBank;
            //Assert
            Assert.AreEqual(expected, actual);
        }
    }
}