using CarFactory_Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CarFactory.Models
{
    public class BuildCarInputModel
    {
        public IEnumerable<BuildCarInputModelItem> Cars { get; set; }
    }

    public class BuildCarInputModelItem
    {
        [Required]
        public int Amount { get; set; } // QUESTION: Is this a price or number of orders?
        [Required]
        public CarSpecificationInputModel Specification { get; set; }
    }

    public class CarPaintSpecificationInputModel
    {
        public string Type { get; set; }
        public string BaseColor { get; set; }
        public string? StripeColor { get; set; }
        public string? DotColor { get; set; }
    }

    public class CarSpecificationInputModel
    {
        public int NumberOfDoors { get; set; }
        public CarPaintSpecificationInputModel Paint { get; set; }
        public Manufacturer Manufacturer { get; set; }
        public SpeakerSpecificationInputModel[] FrontWindowSpeakers { get; set; }
        public SpeakerSpecificationInputModel[] DoorSpeakers { get; set; }
    }

    public class SpeakerSpecificationInputModel
    {
        public bool IsSubWoofer { get; set; }
        public int? NumberOfSpeakers { get; set; }
    }

    public class BuildCarOutputModel
    {
        public long RunTime { get; set; }
        public IEnumerable<Car> Cars { get; set; }
    }
}
