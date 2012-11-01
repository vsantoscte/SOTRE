using System;
using System.Linq;
using System.Net;
using System.Web;
using System.Xml;
using System.Xml.Linq;
using SOTRE.Domain;

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

            return new Cordenada(Util.ConverterCordenadasToDouble(geocodeInfo[2]), Util.ConverterCordenadasToDouble(geocodeInfo[3]));
        }

        public static Viagem ObterDistanciaEDuracao(Cordenada origem, Cordenada destino)
        {
            WebRequest webrequest = WebRequest.Create(string.Format("http://maps.google.es/maps/api/directions/xml?origin={0},{1}&destination={2},{3}&sensor=true", origem.Latitude.ToString().Replace(",", "."), origem.Longitude.ToString().Replace(",", "."), destino.Latitude.ToString().Replace(",", "."), destino.Longitude.ToString().Replace(",", ".")));

            XmlTextReader reader = new XmlTextReader(webrequest.GetResponse().GetResponseStream());

            XElement xdoc = XElement.Load(reader);

            Viagem viagem = new Viagem();

            viagem.cd_distancia = Convert.ToInt64(xdoc.Elements("route").Elements("leg").Elements("distance").Elements("value").First().Value);
            viagem.cd_duracao = Convert.ToInt64(xdoc.Elements("route").Elements("leg").Elements("duration").Elements("value").First().Value);

            return viagem;

        }
    }
}
