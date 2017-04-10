using GoogleMapJsonDeserialize;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;


namespace GeoCoderInformation
{
    public class GeocoderInfo
    {
        private readonly string _query;
        public GeocoderInfo(string Query)
        {
            _query = Query;
        }
        private GoogleGeoCodeResponse _results;
        private void GetGeoInfo()
        {
            string url = "http://maps.google.com/maps/api/geocode/json?address=" + _query + "&sensor=false";
            string JsonText;
            var request = WebRequest.Create(url);
            request.ContentType = "application/json; charset=utf-8";
            var response = (HttpWebResponse)request.GetResponse();
            using (var sr = new StreamReader(response.GetResponseStream()))
            { JsonText = sr.ReadToEnd(); }

            GoogleGeoCodeResponse results = JsonConvert.DeserializeObject<GoogleGeoCodeResponse>(JsonText);
            _results = results;
        }

        public GoogleGeoCodeResponse GetGeocodeResponse()
        {
            GetGeoInfo();
            return _results;
        }

    }

}

/// <summary>
/// Kullanış
/// </summary>
/*
            GeocoderInfo asd = new GeocoderInfo("Sakarya Üniversitesi");
            GoogleGeoCodeResponse qwe= asd.GetGeocodeResponse();
            foreach (var item in qwe.results)
            {
                foreach (var item2 in item.address_components)
                {
                     Console.WriteLine("Name = " + item2.long_name + "           kordinat = " + item.geometry.location.lat + "   " + item.geometry.location.lng);
                }  
            }
*/
