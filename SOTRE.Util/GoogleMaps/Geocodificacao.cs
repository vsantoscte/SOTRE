using System;
using System.Collections.Generic;
using System.Text;
using System.Web;
using System.Net;
using System.Security.Policy; 

namespace SOTRE.Util.GoogleMaps
{
    public static class Geocodificacao
    {
        private const string _googleUrl = "http://maps.google.com/maps/geo?q=";
        private const string _googleKey = "AIzaSyAhvE2if0BG8wIUNvTC5-oWBQtsM4PYM5Q";
        private const string _outputType = "csv"; // Available options: csv, xml, kml, json

        private static Uri GetGeocodeUrl(string address)
        {
            address = HttpUtility.UrlEncode(address);
            return new Uri(String.Format("{0}{1}&output={2}&key={3}", _googleUrl, address, _outputType, _googleKey));
        }

        /// <summary>
        /// Gets a Coordinate from a address.
        /// </summary>
        /// <param name="address">An address.
        /// <remarks>
        /// <example>1600 Amphitheatre Parkway Mountain View, CA 94043</example>
        /// </remarks>
        /// </param>
        /// <returns>A spatial coordinate that contains the latitude and longitude of the address.</returns>
        public static Cordenada GetCordenadas(string address)
        {
            WebClient client = new WebClient();
            Uri uri = GetGeocodeUrl(address);


            /* The first number is the status code, 
            * the second is the accuracy, 
            * the third is the latitude, 
            * the fourth one is the longitude.
            */
            string[] geocodeInfo = client.DownloadString(uri).Split(',');

            return new Cordenada(Convert.ToDouble(geocodeInfo[2]), Convert.ToDouble(geocodeInfo[3]));
        }

        public static double DistanceTo(this Cordenada from, Cordenada to)
        {
            // Haversine Formula...  
            var dLat1InRad = from.Latitude * (Math.PI / 180.0);
            var dLong1InRad = from.Longitude * (Math.PI / 180.0);
            var dLat2InRad = to.Latitude * (Math.PI / 180.0);
            var dLong2InRad = to.Longitude * (Math.PI / 180.0);

            var dLongitude = dLong2InRad - dLong1InRad;
            var dLatitude = dLat2InRad - dLat1InRad;

            // Intermediate result a.  
            var a = Math.Pow(Math.Sin(dLatitude / 2.0), 2.0) +
                    Math.Cos(dLat1InRad) * Math.Cos(dLat2InRad) *
                    Math.Pow(Math.Sin(dLongitude / 2.0), 2.0);

            // Intermediate result c (great circle distance in Radians).  
            var c = 2.0 * Math.Atan2(Math.Sqrt(a), Math.Sqrt(1.0 - a));

            // Unit of measurement  
            var radius = 6371;
            return radius * c;
        }
    }
}
