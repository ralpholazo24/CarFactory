using CarFactory_Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarFactory_Factory
{
    public class CarSpecification
    {
        public readonly int Amount;
        public readonly int NumberOfDoors;
        public readonly PaintJob PaintJob;
        public readonly Manufacturer Manufacturer;
        public readonly IEnumerable<SpeakerSpecification> DoorSpeakers;
        public readonly IEnumerable<SpeakerSpecification> FrontWindowSpeakers;

        public CarSpecification(PaintJob paint, Manufacturer manufacturer, int numberOfDoors, IEnumerable<SpeakerSpecification> doorSpeakers, IEnumerable<SpeakerSpecification> dashboardSpeakers, int amount)
        {
            Amount = amount;
            PaintJob = paint;
            Manufacturer = manufacturer;
            NumberOfDoors = numberOfDoors;
            DoorSpeakers = doorSpeakers;
            FrontWindowSpeakers = dashboardSpeakers;
        }

        public class SpeakerSpecification
        {
            public bool IsSubWoofer;
            public int? NumberOfSpeakers;
        }
    }
}
