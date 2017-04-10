using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for GetData
/// </summary>
public class GetData
{
    
    public GetData(string CompanyName)
    {
       
    }

    

    public class _Facebook_Node
    {
        public string name { get; set; }
        public string fb_url { get; set; }
    }
    public class _Company_Node
    {
        public string name { get; set; }
        public string comp_ip { get; set; }
        public string comp_host { get; set; }
    }
    public class _Twitter_Node
    {
        public string name { get; set; }
        public string tw_url { get; set; }
    }
    public class _Linkedin_Node
    {
        public string name { get; set; }
        public string lin_url { get; set; }
    }
    public class _GooglePlus_Node
    {
        public string name { get; set; }
        public string gp_url { get; set; }
    }
    public class _Reddit_Node
    {
        public string name { get; set; }
        public string red_url { get; set; }
    }
    public class _GoogleNews_Node
    {
        public string name { get; set; }
        public string gn_url { get; set; }
    }
    public class _Wikipedia_Node
    {
        public string name { get; set; }
        public string description { get; set; }
    }
    public class _Geocode_Node
    {
        public string name { get; set; }
    }
    public class _Whois_Node
    {
        public string[] WhoisText { set; get; }
    }
    public class _Shodan_Node
    {
        public string name { get; set; }
        public class _SmallNodes_Org
        {
            public string org { get; set; }
        }
        public class _SmallNodes_Isp
        {
            public string isp { get; set; }
        }
        public class _SmallNodes_LastUp
        {
            public string last_update { get; set; }
        }
        public class _SmallNodes_CountryName
        {
            public string country_name { get; set; }
        }
        public class _SmallNodes_IPsTR
        {
            public string ip_str { get; set; }
        }
        public class _SmallNodes_ASN
        {
            public string asn { get; set; }
        }
        public class _SmallNodes_Ports
        {
            public string ports { get; set; }
        }
        public class _SmallNodes_Hosts
        {
            public string hosts { get; set; }
        }
    }
    public class _GeoLongitude
    {
        public string Geo_lon { get; set; }
    }
    public class _GeoLatitude
    {
        public string Geo_lat { get; set; }
    }
}