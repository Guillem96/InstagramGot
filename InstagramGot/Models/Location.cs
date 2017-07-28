using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InstagramGot.Models
{
    internal class Location : ILocation
    {
        private double latitude;
        private double longitude;
        private string name;
        private long id;

        public double Latitude { get => latitude; set => latitude = value; }
        public double Longitude { get => longitude; set => longitude = value; }
        public string Name { get => name; set => name = value; }
        public long Id { get => id; set => id = value; }
    }
}
