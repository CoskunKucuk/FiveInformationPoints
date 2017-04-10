
using GoogleSearchEngine;
using Neo4jClient;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.ServiceModel.Channels;
using Whois;

public partial class index2 : System.Web.UI.Page
{
    private const string Db_id = "neo4j";
    private const string DB_pass = "741852";
    private const string uri = "http://localhost:7474/db/data";
    protected void Page_Load(object sender, EventArgs e)
    {
        string CompanyName = Session["company"].ToString();
        id_ShoutKeyword.InnerHtml += CompanyName;
        //------------------------------------------------------------------------------------------
        CompanyName = CompanyName.ToLower();
        CompanyName = CompanyName.Replace('ö', 'o');
        CompanyName = CompanyName.Replace('ü', 'u');
        CompanyName = CompanyName.Replace('ğ', 'g');
        CompanyName = CompanyName.Replace('ş', 's');
        CompanyName = CompanyName.Replace('ı', 'i');

        //------------------------------------------------------------------------------------------

        var GSearch = new GoogleSearch(CompanyName);
        string URL = null;
        //istenilen şirketin url'sini alma http://companyname.com
        foreach (var item in GSearch.GoogleSearch_().Items)
        { URL = Server.HtmlEncode(item.Link); break;}
       
        //Host www.companyname.com
        UriParser up = new UriParser(URL);
        up.UriParse();
        string host = up.host.Remove(0,4);
       
         //IP ------------------------------------------------------------------------------------------------
         GetIPAddress ip = new GetIPAddress(host);
        IPAddress[] IP= ip.GetIP();

        // Company Bileşenlerini setleme ------------------------------------------------------------------------------------
        CreateGraph cg = new CreateGraph();
        cg.CreateRootNode();
        
        Company_Node comp = new Company_Node { name = CompanyName, comp_host = host, comp_ip = IP[0].ToString() };
        cg.CreateRelationRoot_Company(comp);
        Shodan_Node sh = new Shodan_Node { name = "Shodan"+CompanyName.Replace(" ","") };
        cg.CreateRelationCompany_Shodan(sh, comp);

        //ShodanApi----------------------------------------------------------------------------------------------------------------------------
        Dictionary<string, object> ShodanResults = new Dictionary<string, object>();
        SeeResult Shodan = new SeeResult(IP[0]);
        ShodanResults = Shodan.SearchResult();
        Shodan_Node.SmallNodes_Ports port = new Shodan_Node.SmallNodes_Ports();
       
        foreach (KeyValuePair<string, object> item in ShodanResults)
        {
            if(item.Key== "ports")
            {
                var obj = ((IEnumerable)item.Value).Cast<object>().ToList();
                foreach (var item2 in obj)
                         {
                        port.ports = item2.ToString();
                        cg.CreateRelationShodan_Ports(sh, port);
                    }
                    }
            }
        
      
      

        //string shodanResults = string.Join(Environment.NewLine, ShodanResults.Select(x => x.Key + " = " + x.Value).ToArray());
        
        Shodan_Node.SmallNodes_ASN _asn = new Shodan_Node.SmallNodes_ASN();
        Shodan_Node.SmallNodes_CountryName country = new Shodan_Node.SmallNodes_CountryName();
        Shodan_Node.SmallNodes_IPsTR ipStr = new Shodan_Node.SmallNodes_IPsTR();
        Shodan_Node.SmallNodes_Isp _isp = new Shodan_Node.SmallNodes_Isp();
        Shodan_Node.SmallNodes_LastUp lastup = new Shodan_Node.SmallNodes_LastUp();
        Shodan_Node.SmallNodes_Org org = new Shodan_Node.SmallNodes_Org();
        foreach (KeyValuePair<string,object> item in ShodanResults)
        {

            if (item.Key == "org") { org.org = item.Value.ToString(); cg.CreateRelationShodan_org(sh, org); }
            else if (item.Key == "isp") { _isp.isp = item.Value.ToString(); cg.CreateRelationShodan_Isp(sh, _isp); }
            else if (item.Key == "last_update") { lastup.last_update = item.Value.ToString(); cg.CreateRelationShodan_LastUpdate(sh, lastup); }
            else if (item.Key == "country_name") { country.country_name = item.Value.ToString(); cg.CreateRelationShodan_CountryName(sh, country); }
            else if (item.Key == "ip_str") { ipStr.ip_str = item.Value.ToString(); cg.CreateRelationShodan_IPsTR(sh, ipStr); }
            else if (item.Key == "asn") { _asn.asn = item.Value.ToString(); cg.CreateRelationShodan_ASN(sh, _asn); }
           
        }



        //Whois ------------------------------------------------------------------------------------------------------------------------------------
        var whois = new WhoisLookup().Lookup(host);
        Whois_Node who = new Whois_Node();

        who.WhoisText = whois.Text.ToArray(typeof(string)) as string[];
        cg.CreateRelationCompany_Whois(who, comp);

        //Geocoder------------------------------------------------------------------------------------------------------------------------------------
        GeoCoderInformation.GeocoderInfo GeoInfo = new GeoCoderInformation.GeocoderInfo(CompanyName);
         Geocode_Node geoname = new Geocode_Node();
         GeoLatitude _lat = new GeoLatitude();
         GeoLongitude _lon = new GeoLongitude();
        foreach (var item in GeoInfo.GetGeocodeResponse().results)
        {
            foreach (var item2 in item.address_components)
            {
                geoname.name = item2.long_name;
                _lat.Geo_lat = item.geometry.location.lat;
                _lon.Geo_lon = item.geometry.location.lng;
                
            }
            cg.CreateRelationCompany_Geocode(geoname, comp, _lon, _lat);
        }


        //WikiData---------------------------------------------------------------------------------------------------------------------

        GetWikiData.WikiData wiki = new GetWikiData.WikiData(CompanyName);
        wiki.GetWikiData();
        Wikipedia_Node wikinode = new Wikipedia_Node { name = wiki.Title.Replace("'", ""), description = wiki.Description.Replace("'","")};
        cg.CreateRelationCompany_Wikipedia(wikinode, comp);
        //Google Search --------------------------------------------------------------------------------------------------------------

        GoogleSearchEngine.GoogleSearch Gsearch = new GoogleSearchEngine.GoogleSearch(CompanyName);
        Facebook_Node fb = new Facebook_Node();
        foreach (var item in Gsearch.FacebookSearch().Items)
        {
            fb.name = item.Title.Replace("'", "");
            fb.fb_url = item.Link;
            cg.CreateRelationCompany_Facebook(fb, comp);
        }
        GooglePlus_Node _gp = new GooglePlus_Node();
        foreach (var item in Gsearch.GooglePlusSearch().Items)
        {
            _gp.name = item.Title.Replace("'", "");
            _gp.gp_url = item.Link;
            cg.CreateRelationCompany_GooglePlus(_gp, comp);
        }
        Linkedin_Node ln = new Linkedin_Node();
        foreach (var item in Gsearch.LinkedinSearch().Items)
        {
            ln.name = item.Title.Replace("'", "");
            ln.lin_url = item.Link;
            cg.CreateRelationCompany_Linkedin(ln, comp);
        }
        GoogleNews_Node _gn = new GoogleNews_Node();
        foreach (var item in Gsearch.NewsSearch().Items)
        {
            _gn.name = item.Title.Replace("'", "");
            _gn.gn_url = item.Link;
            cg.CreateRelationCompany_GoogleNews(_gn, comp);
        }
        Reddit_Node red = new Reddit_Node();
        foreach (var item in GSearch.RedditSearch().Items)
        {
            red.name = item.Title.Replace("'", "");
            red.red_url = item.Link;
            cg.CreateRelationCompany_Reddit(red, comp);
        }
        Twitter_Node tw = new Twitter_Node();
        foreach (var item in Gsearch.TwitterSearch().Items)
        {
            tw.name = item.Title.Replace("'", "");
            tw.tw_url = item.Link;
            cg.CreateRelationCompany_Twitter(tw, comp);
        }



        //-------------------GET NEO4J COMPANY DATA-----------------------------------


        
        var graphClient = new GraphClient(new Uri(uri), Db_id, DB_pass);
        graphClient.Connect();


        var FacebookQuery = graphClient.Cypher
             .Match("p=(c { name: '" + CompanyName + "' })-[:Facebook]->(f)")
             .Return(f => f.As<GetData._Facebook_Node>())
             .Results;

        foreach (var item in FacebookQuery) { facebookContent.InnerHtml += "<a href='" + item.fb_url + "' target='_blank'>" + item.fb_url + "</a><br>"; }

        var TwitterQuery = graphClient.Cypher
            .Match("p=(c{name:'" + CompanyName + "'}) -[:Twitter]->(t)")
            .Return(t => t.As<GetData._Twitter_Node>())
            .Results;

        foreach (var item in TwitterQuery) { twitterContent.InnerHtml += "<a href='" + item.tw_url + "' target='_blank'>" + item.tw_url + "</a><br>"; }

        var RedditQuery = graphClient.Cypher
            .Match("p=(c{name:'" + CompanyName + "'}) -[:Reddit]->(r)")
            .Return(r => r.As<GetData._Reddit_Node>())
            .Results;

        foreach (var item in RedditQuery)
        { redditContent.InnerHtml += "<a href='" + item.red_url + "' target='_blank'>" + item.red_url + "</a><br>"; }

        var LinkedinQuery = graphClient.Cypher
            .Match("p=(c{name:'" + CompanyName + "'})-[:Linkedin]->(l)")
            .Return(l => l.As<GetData._Linkedin_Node>())
            .Results;

        foreach (var item in LinkedinQuery) { linkedinContent.InnerHtml += "<a href='" + item.lin_url + "' target='_blank'>" + item.lin_url + "</a><br>"; }

        var GoogleNewsQuery = graphClient.Cypher
            .Match("p=(c{name:'" + CompanyName + "'})-[:GoogleNews]->(gn)")
            .Return(gn => gn.As<GetData._GoogleNews_Node>())
            .Results;

        foreach (var item in GoogleNewsQuery) { googlenewsContent.InnerHtml += "<a href='" + item.gn_url + "' target='_blank'>" + item.gn_url + "</a><br>"; }

        var GooglePlusQuery = graphClient.Cypher
            .Match("p=(c{name:'" + CompanyName + "'})-[:GooglePlus]->(gp)")
            .Return(gp => gp.As<GetData._GooglePlus_Node>())
            .Results;

        foreach (var item in GooglePlusQuery)
        { googleplusContent.InnerHtml += "<a href='" + item.gp_url + "' target='_blank'>" + item.gp_url + "</a><br>"; }

        var WhoisQuery = graphClient.Cypher
            .Match("p=(c{name:'" + CompanyName + "'})-[:Whois]->(wh)")
            .Return(wh => wh.As<GetData._Whois_Node>())
            .Results;

        foreach (var item in WhoisQuery) {  for (int i = 0; i < item.WhoisText.Length; i++) { whoisContent.InnerHtml += item.WhoisText[i] + "<br>"; } } 


        var WikipediaQuery = graphClient.Cypher
           .Match("p=(c{name:'" + CompanyName + "'})-[:Wikipedia]->(w)")
           .Return(w => w.As<GetData._Wikipedia_Node>())
           .Results;

        foreach (var item in WikipediaQuery)
        {
            if (item.description == "" || item.description == null) { wikipediaContent.InnerHtml += "No Records Found"; }
            else { wikipediaContent.InnerHtml += item.description; }
        }

        var ShodanORGQuery = graphClient.Cypher
            .Match("p=(sh {name:'Shodan" + CompanyName + "'})-[:ORG]->(Org)")
            .Return(Org => Org.As<GetData._Shodan_Node._SmallNodes_Org>())
            .Results;

        foreach (var item in ShodanORGQuery)
        {
            if (ShodanORGQuery.Count() == 0 )
            {
                orgContent.InnerHtml += "No Record Found!";
            }
            else { orgContent.InnerHtml += item.org + "<br>"; }
        }

        var ShodanISPQuery = graphClient.Cypher
            .Match("p=(sh {name:'Shodan" + CompanyName + "'})-[:ISP]->(isp)")
            .Return(isp => isp.As<GetData._Shodan_Node._SmallNodes_Isp>())
            .Results;

        foreach (var item in ShodanISPQuery)
        {
            if (ShodanISPQuery.Count() == 0 )
            {
                ispContent.InnerHtml += "No Record Found!";
            }
            else { ispContent.InnerHtml += item.isp + "<br>"; }
        }

        var ShodanLASTUPQuery = graphClient.Cypher
            .Match("p=(sh {name:'Shodan" + CompanyName + "'})-[:LastUpdate]->(LastUp)")
            .Return(LastUp => LastUp.As<GetData._Shodan_Node._SmallNodes_LastUp>())
            .Results;

        foreach (var item in ShodanLASTUPQuery)
        {
            if (ShodanLASTUPQuery.Count() == 0)
            {
                lastupContent.InnerHtml += "No Record Found!";
            }
            else { lastupContent.InnerHtml += item.last_update + "<br>"; }
        }

        var ShodanCOUNTRYQuery = graphClient.Cypher
            .Match("p=(sh {name:'Shodan" + CompanyName + "'})-[:COUNTRY]->(CountryName)")
            .Return(CountryName => CountryName.As<GetData._Shodan_Node._SmallNodes_CountryName>())
            .Results;

        foreach (var item in ShodanCOUNTRYQuery)
        {
            if (ShodanCOUNTRYQuery.Count() == 0)
            {
                countryContent.InnerHtml += "No Record Found!";
            }
            else { countryContent.InnerHtml += item.country_name + "<br>"; }
        }

        var ShodanIPSTRQuery = graphClient.Cypher
            .Match("p=(sh {name:'Shodan" + CompanyName + "'})-[:IPSTR]->(ip_str)")
            .Return(ip_str => ip_str.As<GetData._Shodan_Node._SmallNodes_IPsTR>())
            .Results;

        foreach (var item in ShodanIPSTRQuery)
        {
            if (ShodanIPSTRQuery.Count() == 0)
            {
                ipstrContent.InnerHtml += "No Record Found!";
            }
            else { ipstrContent.InnerHtml += item.ip_str + "<br>"; }
        }

        var ShodanASNQuery = graphClient.Cypher
            .Match("p=(sh {name:'Shodan" + CompanyName + "'})-[:ASN]->(asn)")
            .Return(asn => asn.As<GetData._Shodan_Node._SmallNodes_ASN>())
            .Results;

        foreach (var item in ShodanASNQuery)
        {
            if (ShodanASNQuery.Count() == 0)
            {
                asnContent.InnerHtml += "No Record Found!";
            }
            else { asnContent.InnerHtml += item.asn + "<br>"; }
        }

        var ShodanPORTQuery = graphClient.Cypher
            .Match("p=(sh {name:'Shodan" + CompanyName + "'})-[:OPEN_PORT]->(ports)")
            .Return(ports => ports.As<GetData._Shodan_Node._SmallNodes_Ports>())
            .Results;

        foreach (var item in ShodanPORTQuery)
        {
            if (ShodanPORTQuery.Count() == 0)
            {
                portContent.InnerHtml += "No Record Found!";
            }
            else { portContent.InnerHtml += item.ports + "<br>"; }
        }

        var GeocodeQuery = graphClient.Cypher
            .Match("p=(c{name:'" + CompanyName + "'})-[:Geocode]->(geo)")
            .Return(geo => geo.As<GetData._Geocode_Node>()).Results;
        foreach (var item in GeocodeQuery)
        {
            GeocodeContent.InnerHtml += "<h3>" + item.name + "</h3><br>";
            var GeoLonQuery = graphClient.Cypher.Match("(geo{name:'" + item.name + "'})-[:longitude]->(lon)").Return(lon => lon.As<GetData._GeoLongitude>()).Results;
            foreach (var itemLon in GeoLonQuery)
            {
                GeocodeContent.InnerHtml += "<b>Longitude</b>" + itemLon.Geo_lon + "&nbsp&nbsp&nbsp&nbsp";
            }
            var GeoLatQuery = graphClient.Cypher.Match("(geo{name:'" + item.name + "'})-[:latitude]->(lat)").Return(lat => lat.As<GetData._GeoLatitude>()).Results;
            foreach (var itemLat in GeoLatQuery)
            {
                GeocodeContent.InnerHtml += "<b>Latitude</b>" + itemLat.Geo_lat;
            }
        }
}
}