using CarFactory.Models;
using CarFactory_Domain;
using CarFactory_Factory;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;

namespace CarFactory.BusinessLogic
{
    public class CarFactoryBusinessLogic
    {
        public static IEnumerable<CarSpecification> TransformToDomainObjects(BuildCarInputModel carsSpecs)
        {
            var wantedCars = new List<CarSpecification>();
            foreach (var spec in carsSpecs.Cars)
            {
                var paint = GetPaintJob(spec.Specification.Paint);
                var numberOfDoors = GetNumberOfDoors(spec.Specification.NumberOfDoors);
                var frontWindowSpeakers = GetFrontWindowSpeakers(spec.Specification.FrontWindowSpeakers);
                var doorSpeakers = new CarSpecification.SpeakerSpecification[0]; //TODO: Let people install door speakers
                var wantedCar = new CarSpecification(paint, spec.Specification.Manufacturer, numberOfDoors, doorSpeakers, frontWindowSpeakers, spec.Amount);
                wantedCars.Add(wantedCar);
            }
            return wantedCars;
        }

        public static PaintJob GetPaintJob(CarPaintSpecificationInputModel paintSpec)
        {
            PaintJob? paint = null;
            var baseColor = Color.FromName(paintSpec.BaseColor);
            switch (paintSpec.Type.ToLower())
            {
                case "single":
                    paint = new SingleColorPaintJob(baseColor);
                    break;
                case "stripe":
                case "stripes":
                    paint = new StripedPaintJob(baseColor, Color.FromName(paintSpec.StripeColor));
                    break;
                case "dot":
                case "dots":
                    paint = new DottedPaintJob(baseColor, Color.FromName(paintSpec.DotColor));
                    break;
                default:
                    throw new ArgumentException(string.Format("Unknown paint type %", paintSpec.Type));
            }
            return paint;
        }

        private static int GetNumberOfDoors(int numberOfDoors)
        {
            if (numberOfDoors % 2 == 0)
            {
                throw new ArgumentException("Must give an odd number of doors");
            }
            return numberOfDoors;
        }

        private static IEnumerable<CarSpecification.SpeakerSpecification> GetFrontWindowSpeakers(SpeakerSpecificationInputModel[] frontWindowSpeakers)
        {
            return frontWindowSpeakers.Select(s => new CarSpecification.SpeakerSpecification { IsSubWoofer = s.IsSubWoofer, NumberOfSpeakers = s.NumberOfSpeakers });
        }
    }
}
