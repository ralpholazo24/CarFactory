using CarFactory.BusinessLogic;
using CarFactory.Models;
using CarFactory_Domain;
using CarFactory_Domain.Engine;
using CarFactory_Factory;
using CarFactory_Paint;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Drawing;

namespace UnitTests
{
    [TestClass]
    public class PainterTests
    {
        [TestMethod]
        public void Painter_PaintJobTest()
        {
            var singleColor = new SingleColorPaintJob(Color.Aqua);
            var painter = new Painter();
            var car = new Car(new Chassis("", true), new Engine(new EngineBlock(10), "Test"), new Interior(), new Wheel[4]);
            painter.PaintCar(car, singleColor);
            var job = (SingleColorPaintJob)car.PaintJob;
            job.Color.Should().Be(Color.Aqua);
            job.AreInstructionsUnlocked().Should().BeTrue();
        }


        [TestMethod]
        public void StripePaintJobTest()
        {
            var carPaintSpecificationInputModel = new CarPaintSpecificationInputModel()
            {
                Type = "Stripe",
                BaseColor = "Blue",
                StripeColor = "Orange",
                DotColor = null
            };
            var paintJob = CarFactoryBusinessLogic.GetPaintJob(carPaintSpecificationInputModel);
            var painter = new Painter();
            var car = new Car(new Chassis("", true), new Engine(new EngineBlock(10), "Test"), new Interior(), new Wheel[4]);
            painter.PaintCar(car, paintJob);
            var job = (StripedPaintJob)car.PaintJob;
            job.BaseColor.Should().Be(Color.Blue);
            job.StripeColor.Should().Be(Color.Orange);            
            job.AreInstructionsUnlocked().Should().BeTrue();
        }

        [TestMethod]
        public void DottedPaintJobTest()
        {
            var carPaintSpecificationInputModel = new CarPaintSpecificationInputModel()
            {
                Type = "Dots",
                BaseColor = "Pink",
                StripeColor = null,
                DotColor = "red"
            };
            var paintJob = CarFactoryBusinessLogic.GetPaintJob(carPaintSpecificationInputModel);
            var painter = new Painter();
            var car = new Car(new Chassis("", true), new Engine(new EngineBlock(10), "Test"), new Interior(), new Wheel[4]);
            painter.PaintCar(car, paintJob);
            var job = (DottedPaintJob)car.PaintJob;
            job.BaseColor.Should().Be(Color.Pink);
            job.DotColor.Should().Be(Color.Red);
            job.AreInstructionsUnlocked().Should().BeTrue();
        }

        [TestMethod]
        public void SpeakersTest()
        {
            var speakers = new List<Speaker>();
            speakers.Add(new Speaker() { IsSubWoofer = true, NumberOfSpeakers = 2 });
            speakers.Add(new Speaker() { IsSubWoofer = false, NumberOfSpeakers = 2 });
            
            var interior = new Interior()
            {
                FrontWindowSpeakers = speakers
            };

            var car = new Car(new Chassis("", true), new Engine(new EngineBlock(10), "Test"), interior, new Wheel[4]);
            car.Interior.FrontWindowSpeakers.Should().HaveCountLessOrEqualTo(2);
        }
    }
}
