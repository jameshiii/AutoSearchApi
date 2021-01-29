using AutoMapper;
using AutoSearchApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;

namespace AutoSearchApi.Test
{
    [TestClass]
    public class VehicleController
    {
        private VehicleContext _context = null;
        private IMapper _mapper = null;

        [TestInitialize]
        public void Setup()
        {
            //create in memory database
            var options = new DbContextOptionsBuilder<VehicleContext>()
            .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
            .Options;

            // insert temp records
            _context = new VehicleContext(options);

            _context.Vehicles.Add(new Vehicle()
            {
                Price = 101m,
                Color = "purple",
                Mileage = 1,
                Model = "yugo",
                Status = Vehicle.VehicleStatus.Active
            });

            _context.SaveChanges();
            
            var mapperConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new AutoMapperProfile());
            });

            _mapper = mapperConfig.CreateMapper();
        }

        [TestMethod]
        public void GetVehiclesDealerOne()
        {   
            var result = new Controllers.VehicleController(_context, _mapper).GetVehicles("dealer 1").Result.Value.ToList();
            var vehicle = result[0] as ViewModels.Dealer1Vehicle;

            Assert.IsNotNull(result);
            Assert.IsTrue(result.Any());
            Assert.IsNotNull(vehicle);
            Assert.AreEqual(1, result.Count);
            Assert.AreEqual(1, vehicle.Id);
            Assert.AreEqual(101m, vehicle.Price);
            Assert.AreEqual("For Sale", vehicle.Status);
        }

        [TestMethod]
        public void GetVehiclesDealerTwo()
        {
            var result = new Controllers.VehicleController(_context, _mapper).GetVehicles("dealer 2").Result.Value.ToList();
            var vehicle = result[0] as ViewModels.Dealer2Vehicle;

            Assert.IsNotNull(result);
            Assert.IsTrue(result.Any());
            Assert.IsNotNull(vehicle);
            Assert.AreEqual(1, result.Count);
            Assert.AreEqual(1, vehicle.Id);
            Assert.AreEqual(101m, vehicle.Price);
            Assert.AreEqual("Active", vehicle.Status);
        }

        [TestMethod]
        public void GetVehiclesBadDealer()
        {
            var result = new Controllers.VehicleController(_context, _mapper).GetVehicles("bad").Result.Result as BadRequestObjectResult;

            Assert.IsNotNull(result);
            Assert.AreEqual(400, result.StatusCode);
            Assert.AreEqual("Invalid dealer provided in Vehicle request.", result.Value);
        }
    }
}
