using System.Collections.Generic;
using APICustomerDemo.Controllers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Repository;
using Moq;
using Repository.Models;

namespace APICustomer.Test
{
    [TestClass]
    public class CustomerControllerTest
    {
        [TestMethod]
        public void TestGetCustomerWithCriteria()
        {
            //Arrange
            var mockRepository = new Mock<ICustomerRepository>();
            var controller = new CustomerController(mockRepository.Object);
            mockRepository.Setup(x => x.GetCustomersListWithCriteria())
                .Returns(new List<Kunde> {new Kunde{BankId=2323,PostNr="121"} });
            //Act
            var  actionResult = controller.Get();
   
            //Assert
            Assert.IsNotNull(actionResult);
            Assert.IsInstanceOfType(actionResult, typeof(List<Kunde>));
        }


        [TestMethod]
        public void TestNotFoundResponse()
        {
            //Arrange
            var mockRepository = new Mock<ICustomerRepository>();
            var controller = new CustomerController(mockRepository.Object);
            
            //Act
            var actionResult = controller.GetById("1");

            // Assert
            Assert.IsInstanceOfType(actionResult, typeof(NotFoundResult));
        }

        [TestMethod]
        public void TestOkResponse()
        {
            //Arrange
            var mockRepository = new Mock<ICustomerRepository>();
            var controller = new CustomerController(mockRepository.Object);
            mockRepository.Setup(x => x.GetCustomerById("123"))
                .Returns( new Kunde { BankId = 2323, PostNr = "121" } );
            //Act
            var actionResult = controller.GetById("123");

            // Assert
            Assert.IsInstanceOfType(actionResult, typeof(OkObjectResult));
        }

        [TestMethod]
        public void TestPutOkResponseCustomer()
        {
            //Arrange
            var mockRepository = new Mock<ICustomerRepository>();
            var controller = new CustomerController(mockRepository.Object);
            mockRepository.Setup(x => x.UpdateCustomer("123","Y"))
                .Returns(new Kunde { BankId = 2323, PostNr = "121", SamtykkeBank="Y",SamtykkeForsikring="Y" });
       
            //Act
            var actionResult = controller.Put("123","Y");
          
            // Assert
             Assert.IsInstanceOfType(actionResult, typeof(OkObjectResult));
        }
    }
}
