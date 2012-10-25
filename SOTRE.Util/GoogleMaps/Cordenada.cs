using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SOTRE.Util.GoogleMaps
{
    public struct Cordenada
    {
        public double latitude;
        public double longitude;

        public Cordenada(double latitude, double longitude)
        {
            this.latitude = latitude;
            this.longitude = longitude;
        }

        public double Latitude
        {
            get
            {
                return latitude;
            }
            set
            {
                this.latitude = value;
            }
        }

        public double Longitude
        {
            get
            {
                return longitude;
            }
            set
            {
                this.longitude = value;
            }
        }

    }
}
