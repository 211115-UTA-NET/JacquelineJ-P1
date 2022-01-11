using Microsoft.VisualStudio.TestTools.UnitTesting;
//using Moq;
using Project1WebApp.Controllers;
//using Project1WebApp.Models;
//using Project1WebApp.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Assert = Microsoft.VisualStudio.TestTools.UnitTesting.Assert;

namespace Project1WebApp.Controllers.Tests
{
    [TestClass()]
    public class StoreControllerTests
    {
  //      private readonly StoreController storeContoller;
  //      private readonly Mock<IStoreRepository> _storeRepository = new Mock<IStoreRepository>();
  //      public StoreControllerTests()
  //      {
  //          storeContoller = new StoreController(_storeRepository.Object);
  //      }
        //private readonly IStoreRepository _storeRepository { get; set; } =null;


       // [Fact]            
        [TestMethod()]
        public void GetStoreByIdTest()
        {
            /*            
            var storeId = 122;            
            var result = _storeRepository.getStores(storeId);            
            Assert.Equals(expected: );
            */

            //Arrange
            //  var storeId = 122;


            // _storeRepository.Setup(x => x.getStore(storeId));//.Returns(StoreModel);
            //ACT
            // var result = storeContoller.GetStoreById(storeId);
            //Assert
            // Assert.Equals(storeId, result);
            Assert.Fail();
        }

        [TestMethod()]
        public void AddStoreTest()
        {
            Assert.Fail();
        }
    }
}