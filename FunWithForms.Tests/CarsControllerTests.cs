using FunWithForms.Controllers;
using FunWithForms.Models;
using Microsoft.AspNetCore.Mvc;
using NSubstitute;
using System;
using System.Collections.Generic;
using Xunit;

namespace FunWithForms.Tests
{
    public class CarsControllerTests
    {
        private Car car;
        private ICarRepository carsRepo;
        private CarsController underTest;

        public CarsControllerTests()
        {
            car = new Car();
            carsRepo = Substitute.For<ICarRepository>();
            underTest = new CarsController(carsRepo);
        }
        [Fact]
        public void Create_Creates_Car()
        {

            underTest.Create(car);

            carsRepo.Received().Create(car);
        }
        [Fact]
        public void Create_Redirects_To_Index_After_Creating()
        {
            var result = underTest.Create(car);

            // Assert.IsType<RedirectToActionResult>(result);
            // The line below will blow up if result is not of type RedirectToActionResult, so we don't need to check it.
            var redirectResult = (RedirectToActionResult)result;
            Assert.Same("Index", redirectResult.ActionName);
        }
        [Fact]
        public void Index_Passes_All_Cars_ToView()
        {
            var expectedCars = new List<Car>();
            carsRepo.GetAll().Returns(expectedCars);

            var result = underTest.Index();
            var model = ((ViewResult)result).Model;

            Assert.Same(expectedCars, model);
        }
        [Fact]
        public void Details_Passes_Correct_Car_To_View()
        {
            var carId = 1;
            var expectedCar = new Car();
            carsRepo.GetById(carId).Returns(expectedCar);

            var result = underTest.Details(carId);
            var model = ((ViewResult)result).Model;

            Assert.Same(expectedCar, model);
        }
        [Fact]
        public void Delete_Passes_Correct_Car_To_View()
        {
            var carId = 1;
            var expectedCar = new Car();
            carsRepo.GetById(carId).Returns(expectedCar);

            var result = underTest.Delete(carId);
            var model = ((ViewResult)result).Model;

            Assert.Same(expectedCar, model);
        }
        [Fact]
        public void Delete_Post_Deletes_The_Car()
        {
            var carId = 42;

            underTest.DeletePost(carId);

            carsRepo.Received().Delete(carId);
        }
        [Fact]
        public void Delete_Redirects_To_Index_After_Deleting()
        {
            var result = underTest.DeletePost(42);
            var redirectResult = (RedirectToActionResult)result;

            Assert.Same("Index", redirectResult.ActionName);
        }

        [Fact]
        public void Update_Passes_Existing_Car_To_View()
        {
            var carId = 42;
            var expectedCar = new Car();

            var result = underTest.Edit(carId);
            var model = ((ViewResult)result).Model;

            Assert.Same(expectedCar, model);
        }

        [Fact]
        public void Edit_Saves_Updated_Car()
        {

            underTest.Edit(car);

            carsRepo.Received().Update(car);
        }

        [Fact (Skip = "not yet")]
        public void Edit_Redirects_To_Index()
        {
          
        }








    }
}
