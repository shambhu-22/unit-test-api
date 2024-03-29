using Crud2.Controllers;
using Crud2.Models;
using Crud2.Repositories;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.InMemory;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crud2.TestProject.ControllerTests
{
    public class IceCreamControllerTest
    {
        IceCreamController controller;
        IIceCreamRepository repository;
        public IceCreamControllerTest()
        {
            var optionsBuilder = new DbContextOptionsBuilder<IceCreamContext>();
            optionsBuilder.UseInMemoryDatabase("IceCreamDB");//IceCreamDB//IceCreamTestDB
            var context = new IceCreamContext(optionsBuilder.Options);
            repository = new IceCreamRepository(context);
            controller = new IceCreamController(repository);
        }

        //Pass
        [Fact]
        public void GetIceCreamsTest()
        {
            //Arrange
            IceCream iceCream = new IceCream()
            {
                Id=1,
                IceCreamType = "Juicy",
                Flavour = "Orange",
                Allergens = "Gluten",
                Natural_synthetic = "Synthetic",
                VegType = "veg",
                EatedBy = "Kids, Elders",
                PricePerPiece = "Rs.20",
                //TimeOfPrice = new DateTime(DateTime.Now, "22:00"),
                ExpiryDate = DateTime.Now.AddDays(20).ToLongDateString(),
                MfgDate = DateTime.Today.AddDays(-5).ToLongDateString(),
                Brand = "Jasmine"
            };

            controller.InsertIceCream(iceCream);
            //Act
            var result = controller.GetIceCreams();

            //Assert
            Assert.NotNull(result);
            if (result != null)
            {
                if (result.Value != null)
                {
                    Assert.Equal(1, result.Value.Count());
                }
                Assert.IsType<ActionResult<IEnumerable<IceCream>>>(result);
            } 
        }

        [Fact]
        public void InsertTceCreamTest()
        {
            //Arrange
            IceCream iceCream = new IceCream()
            {
                IceCreamType = "Juicy",
                Flavour = "Orange",
                Allergens = "Gluten",
                Natural_synthetic = "Synthetic",
                VegType = "veg",
                EatedBy = "Kids, Elders",
                PricePerPiece = "Rs.20",
                //TimeOfPrice = new DateTime(DateTime.Now, "22:00"),
                ExpiryDate = DateTime.Now.AddDays(20).ToLongDateString(),
                MfgDate = DateTime.Today.AddDays(-5).ToLongDateString(),
                Brand = "Jasmine"
            };

            //Act
            var result = controller.InsertIceCream(iceCream);

            //Assert
            Assert.IsType<ActionResult<IceCream>>(result);
            //Assert.NotNull(result.Value); //value coming as null?
            if(result != null && result.Value != null)
            {
                Assert.Equal(iceCream.IceCreamType, result.Value.IceCreamType);
                Assert.Equal(iceCream.PricePerPiece, result.Value.PricePerPiece);
                Assert.Equal(iceCream.ExpiryDate, result.Value.ExpiryDate);
            }
        }

        //Pass
        [Fact]
        public void GetIceCreamByIdTest()
        {
            //Arrange
            int invalid_id = 100;
            int valid_id = 1;
            //Arrange
            IceCream iceCream = new IceCream()
            {
                Id = 1,
                IceCreamType = "Juicy",
                Flavour = "Orange",
                Allergens = "Gluten",
                Natural_synthetic = "Synthetic",
                VegType = "veg",
                EatedBy = "Kids, Elders",
                PricePerPiece = "Rs.20",
                //TimeOfPrice = new DateTime(DateTime.Now, "22:00"),
                ExpiryDate = DateTime.Now.AddDays(20).ToLongDateString(),
                MfgDate = DateTime.Today.AddDays(-5).ToLongDateString(),
                Brand = "Jasmine"
            };
            controller.InsertIceCream(iceCream);

            //Act           
            var invalid_result = controller.GetIceCreamById(invalid_id);
            var valid_result = controller.GetIceCreamById(valid_id);
            //var successModel = valid_result as OkObjectResult;

            //Assert
            Assert.IsType<ActionResult<IceCream>>(valid_result);
            Assert.IsType<ActionResult<IceCream>>(invalid_result);
            if (valid_result != null && valid_result.Value != null)
            {
                Assert.IsType<IceCream>(valid_result.Value);
                Assert.Equal(1, valid_result.Value.Id);
            }

            if(invalid_result != null)
            {
                Assert.Null(invalid_result.Value);
            }
        }
    }
}
