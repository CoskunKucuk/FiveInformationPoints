using Neo4jClient;
using Neo4jClient.Transactions;
using System;
using System.Linq;

public class GetroSocialMedia
{
    public string name { get; set; }
    public string description { get; set; }
}
public class GetroCoordinate
{
    public string Geo_lat { get; set; }
    public string Geo_lon { get; set; }
}
public class GetroRoot
{
    public string name { get; set; }
}
public class Getro { public string text { get; set; } }


public class CreateGraph
{
    public CreateGraph() { }

    private const string Db_id = "neo4j";
    private const string DB_pass = "741852";
    private const string uri = "http://localhost:7474/db/data";

    public void CreateRootNode()
    {
        var graphClient = new GraphClient(new Uri(uri), Db_id, DB_pass);
        graphClient.Connect();
        ITransaction trans = graphClient.BeginTransaction();
        var membersQuery = graphClient.Cypher
           .Match("(n:Root {name :'FIP', Creator : 'Coskun Kucuk'})")
           .Return(n => n.As<GetroRoot>()).Results;
        if (membersQuery.Count() == 0)
        {
            graphClient.Cypher.Create("(n:Root {name :'FIP', Creator : 'Coskun Kucuk'})").ExecuteWithoutResults();
            trans.Commit();
        }
    }
    public void CreateRelationRoot_Company(Company_Node CompNode)
    {
        var graphClient = new GraphClient(new Uri(uri), Db_id, DB_pass);
        graphClient.Connect();
        ITransaction trans = graphClient.BeginTransaction();

        var membersQuery = graphClient.Cypher
            .Match("(c:" + CompNode.name.Replace(" ","") + "{comp_host: '" + CompNode.comp_host + "'})")
            .Return(c => c.As<GetroRoot>()).Results;

        if (membersQuery.Count() == 0)
        {
            graphClient.Cypher
                    .Match("(n:Root)")
                    .Create("n-[:Company]->(c:" + CompNode.name.Replace(" ", "") + " { CompanyData })")
                    .WithParam("CompanyData", CompNode)
                    .ExecuteWithoutResults();
            trans.Commit();
        }

    }
    public void CreateRelationCompany_Facebook(Facebook_Node FbNode, Company_Node CompNode)
    {
        GraphClient graphClient = new GraphClient(new Uri(uri), Db_id, DB_pass);
        graphClient.Connect();
        ITransaction trans = graphClient.BeginTransaction();
        var NodeQuery = graphClient.Cypher
            .Match("(f:Facebook {name : '" + FbNode.name + "',fb_url : '" + FbNode.fb_url + "'})")
            .Return(f => f.As<GetroSocialMedia>()).Results;
        if (NodeQuery.Count() == 0)
        {
            graphClient.Cypher
           .Match("(c:" + CompNode.name.Replace(" ", "") + ")")
           .Create("c-[:Facebook]->(f:Facebook { FacebookData })")
           .WithParam("FacebookData", FbNode)
           .ExecuteWithoutResults();
            trans.Commit();
        }
    }
    public void CreateRelationCompany_Twitter(Twitter_Node TwNode, Company_Node CompNode)
    {
        var graphClient = new GraphClient(new Uri(uri), Db_id, DB_pass);
        graphClient.Connect();
        ITransaction trans = graphClient.BeginTransaction();

        var NodeQuery = graphClient.Cypher
           .Match("(t:Twitter {name : '" + TwNode.name + "',tw_url : '" + TwNode.tw_url + "'})")
           .Return(t => t.As<GetroSocialMedia>()).Results;
        if (NodeQuery.Count() == 0)
        {
            graphClient.Cypher
           .Match("(c:" + CompNode.name.Replace(" ", "") + ")")
           .Create("c-[:Twitter]->(t:Twitter { TwitterData })")
           .WithParam("TwitterData", TwNode)
           .ExecuteWithoutResults();
            trans.Commit();
        }
    }
    public void CreateRelationCompany_Linkedin(Linkedin_Node LinNode, Company_Node CompNode)
    {
        var graphClient = new GraphClient(new Uri(uri), Db_id, DB_pass);
        graphClient.Connect();
        ITransaction trans = graphClient.BeginTransaction();

        var NodeQuery = graphClient.Cypher
           .Match("(l:Linkedin {name : '" + LinNode.name + "',lin_url : '" + LinNode.lin_url + "'})")
           .Return(l => l.As<GetroSocialMedia>()).Results;
        if (NodeQuery.Count() == 0)
        {
            graphClient.Cypher
           .Match("(c:" + CompNode.name.Replace(" ", "") + ")")
           .Create("c-[:Linkedin]->(l:Linkedin { LinkedinData })")
           .WithParam("LinkedinData", LinNode)
           .ExecuteWithoutResults();
            trans.Commit();
        }
    }
    public void CreateRelationCompany_GooglePlus(GooglePlus_Node GpNode, Company_Node CompNode)
    {
        var graphClient = new GraphClient(new Uri(uri), Db_id, DB_pass);
        graphClient.Connect();
        ITransaction trans = graphClient.BeginTransaction();

        var NodeQuery = graphClient.Cypher
           .Match("(gp:GooglePlus  {name : '" + GpNode.name + "',gp_url : '" + GpNode.gp_url + "'})")
           .Return(gp => gp.As<GetroSocialMedia>()).Results;
        if (NodeQuery.Count() == 0)
        {
            graphClient.Cypher
           .Match("(c:" + CompNode.name.Replace(" ", "") + ")")
           .Create("c-[:GooglePlus]->(gp:GooglePlus { GooglePlusData })")
           .WithParam("GooglePlusData", GpNode)
           .ExecuteWithoutResults();
            trans.Commit();
        }
    }
    public void CreateRelationCompany_Reddit(Reddit_Node RedNode, Company_Node CompNode)
    {
        var graphClient = new GraphClient(new Uri(uri), Db_id, DB_pass);
        graphClient.Connect();
        ITransaction trans = graphClient.BeginTransaction();

        var NodeQuery = graphClient.Cypher
          .Match("(r:Reddit  {name : '" + RedNode.name + "',red_url : '" + RedNode.red_url + "'})")
          .Return(r => r.As<GetroSocialMedia>()).Results;
        if (NodeQuery.Count() == 0)
        {
            graphClient.Cypher
           .Match("(c:" + CompNode.name.Replace(" ", "") + ")")
           .Create("c-[:Reddit]->(r:Reddit { RedditData })")
           .WithParam("RedditData", RedNode)
           .ExecuteWithoutResults();
            trans.Commit();
        }
    }
    public void CreateRelationCompany_GoogleNews(GoogleNews_Node GnNode, Company_Node CompNode)
    {
        var graphClient = new GraphClient(new Uri(uri), Db_id, DB_pass);
        graphClient.Connect();
        ITransaction trans = graphClient.BeginTransaction();

        var NodeQuery = graphClient.Cypher
        .Match("(gn:GoogleNews  {name : '" + GnNode.name + "',gn_url : '" + GnNode.gn_url + "'})")
        .Return(gn => gn.As<GetroSocialMedia>()).Results;
        if (NodeQuery.Count() == 0)
        {
            graphClient.Cypher
           .Match("(c:" + CompNode.name.Replace(" ", "") + ")")
           .Create("c-[:GoogleNews]->(gn:GoogleNews { GoogleNewsData })")
           .WithParam("GoogleNewsData", GnNode)
           .ExecuteWithoutResults();
            trans.Commit();
        }
    }
    public void CreateRelationCompany_Wikipedia(Wikipedia_Node WikiNode, Company_Node CompNode)
    {
        var graphClient = new GraphClient(new Uri(uri), Db_id, DB_pass);
        graphClient.Connect();
        ITransaction trans = graphClient.BeginTransaction();

        var NodeQuery = graphClient.Cypher
       .Match("(w:Wikipedia  {name : '" + WikiNode.name + "',description : '" + WikiNode.description + "'})")
       .Return(w => w.As<GetroSocialMedia>()).Results;
        if (NodeQuery.Count() == 0)
        {
            graphClient.Cypher
           .Match("(c:" + CompNode.name.Replace(" ", "") + ")")
           .Create("c-[:Wikipedia]->(w:Wikipedia { WikipediaData })")
           .WithParam("WikipediaData", WikiNode)
           .ExecuteWithoutResults();
            trans.Commit();
        }
    }
    public void CreateRelationCompany_Geocode(Geocode_Node GeoNode, Company_Node CompNode, GeoLongitude lon, GeoLatitude lat)
    {
        var graphClient = new GraphClient(new Uri(uri), Db_id, DB_pass);
        graphClient.Connect();
        ITransaction trans = graphClient.BeginTransaction();

        var NodeQuery = graphClient.Cypher
     .Match("(geo:Geocode   {name : '" + GeoNode.name + "'})")
     .Return(geo => geo.As<GetroSocialMedia>()).Results;
        if (NodeQuery.Count() == 0)
        {
            graphClient.Cypher
           .Match("(c:" + CompNode.name.Replace(" ", "") + ")")
           .Create("c-[:Geocode]->(geo:Geocode { GeocodeData })")
           .WithParam("GeocodeData", GeoNode)
           .ExecuteWithoutResults();

        }
        trans.Commit();
        CreateRelationCoordinateLongitude(GeoNode, lon, lat);

    }
    private void CreateRelationCoordinateLongitude(Geocode_Node GeoNode, GeoLongitude lon, GeoLatitude lat)
    {
        var graphClient = new GraphClient(new Uri(uri), Db_id, DB_pass);
        graphClient.Connect();
        ITransaction trans = graphClient.BeginTransaction();

        var NodeQuery = graphClient.Cypher
         .Match("(ln:Longitude    {Geo_lon : '" + lon.Geo_lon + "'})")
         .Return(ln => ln.As<GetroCoordinate>()).Results;
        if (NodeQuery.Count() == 0)
        {
            graphClient.Cypher
                .Match("(geo:Geocode { name : '" + GeoNode.name + "'})")
                .Create("geo-[:longitude]->(ln:Longitude { LongitudeData })")
                .WithParam("LongitudeData", lon)
                .ExecuteWithoutResults();
        }
        trans.Commit();
        CreateRelationCoordinateLatitude(GeoNode, lat);
    }
    private void CreateRelationCoordinateLatitude(Geocode_Node GeoNode, GeoLatitude lat)
    {
        var graphClient = new GraphClient(new Uri(uri), Db_id, DB_pass);
        graphClient.Connect();
        ITransaction trans = graphClient.BeginTransaction();
        var NodeQuery2 = graphClient.Cypher
          .Match("(lt:Latitude   {Geo_lat : '" + lat.Geo_lat + "'})")
          .Return(lt => lt.As<GetroCoordinate>()).Results;
        if (NodeQuery2.Count() == 0)
        {
            graphClient.Cypher
           .Match("(geo:Geocode { name: '"+ GeoNode.name+"'})")
           .Create("geo-[:latitude]->(lt:Latitude{ LatitudeData })")
           .WithParam("LatitudeData", lat)
           .ExecuteWithoutResults();
        }
        trans.Commit();
    }
    public void CreateRelationCompany_Whois(Whois_Node WiNode, Company_Node CompNode)
    {
        var graphClient = new GraphClient(new Uri(uri), Db_id, DB_pass);
        graphClient.Connect();
        ITransaction trans = graphClient.BeginTransaction();

        var NodeQuery = graphClient.Cypher
            .Match("(wh:Whois  {WhoisText : '" + WiNode.WhoisText + "'})")
            .Return(wh => wh.As<Getro>()).Results;
        if (NodeQuery.Count() == 0)
        {
            graphClient.Cypher
           .Match("(c:" + CompNode.name.Replace(" ", "") + ")")
           .Create("c-[:Whois]->(wh:Whois{ WhoisData })")
           .WithParam("WhoisData", WiNode)
           .ExecuteWithoutResults();
            trans.Commit();
        }
    }
    public void CreateRelationCompany_Shodan(Shodan_Node ShNode, Company_Node CompNode)
    {
        var graphClient = new GraphClient(new Uri(uri), Db_id, DB_pass);
        graphClient.Connect();
        ITransaction trans = graphClient.BeginTransaction();

        var NodeQuery = graphClient.Cypher
          .Match("(sh:Shodan  {name : '" + ShNode.name + "'})")
          .Return(sh => sh.As<Getro>()).Results;
        if (NodeQuery.Count() == 0)
        {
            graphClient.Cypher
       .Match("(c:" + CompNode.name.Replace(" ", "") + ")")
       .Create("c-[:Shodan]->(sh:Shodan{ ShodanData })")
       .WithParam("ShodanData", ShNode)
       .ExecuteWithoutResults();
            trans.Commit();
        }
    }

    public void CreateRelationShodan_org(Shodan_Node ShNode, Shodan_Node.SmallNodes_Org org)
    {
        var graphClient = new GraphClient(new Uri(uri), Db_id, DB_pass);
        graphClient.Connect();
        ITransaction trans = graphClient.BeginTransaction();

        var NodeQuery = graphClient.Cypher
          .Match("(sn:Org {org : '" + org.org + "'})")
          .Return(sn => sn.As<Getro>()).Results;
        if (NodeQuery.Count() == 0)
        {
            graphClient.Cypher
       .Match("(sh: Shodan{name : '" + ShNode.name + "'})")
       .Create("sh-[:ORG]->(sn:Org{ OrgData })")
       .WithParam("OrgData", org)
       .ExecuteWithoutResults();
            trans.Commit();
        }

    }
    public void CreateRelationShodan_Isp(Shodan_Node ShNode, Shodan_Node.SmallNodes_Isp isp)
    {
        var graphClient = new GraphClient(new Uri(uri), Db_id, DB_pass);
        graphClient.Connect();
        ITransaction trans = graphClient.BeginTransaction();

        var NodeQuery = graphClient.Cypher
          .Match("(sn:Isp {isp : '" + isp.isp + "'})")
          .Return(sn => sn.As<Getro>()).Results;
        if (NodeQuery.Count() == 0)
        {
            graphClient.Cypher
       .Match("(sh: Shodan {name:'" + ShNode.name + "'})")
       .Create("sh-[:ISP]->(sn:Isp{ ispData })")
       .WithParam("ispData", isp)
       .ExecuteWithoutResults();
            trans.Commit();
        }

    }
    public void CreateRelationShodan_LastUpdate(Shodan_Node ShNode, Shodan_Node.SmallNodes_LastUp LastUp)
    {
        var graphClient = new GraphClient(new Uri(uri), Db_id, DB_pass);
        graphClient.Connect();
        ITransaction trans = graphClient.BeginTransaction();

        var NodeQuery = graphClient.Cypher
          .Match("(sn:LastUpdate {last_update : '" + LastUp.last_update+ "'})")
          .Return(sn => sn.As<Getro>()).Results;
        if (NodeQuery.Count() == 0)
        {
            graphClient.Cypher
       .Match("(sh:Shodan {name:'" + ShNode.name + "'})")
       .Create("sh-[:LastUpdate]->(sn:LastUp{ LastUp })")
       .WithParam("LastUp", LastUp)
       .ExecuteWithoutResults();
            trans.Commit();
        }

    }
    public void CreateRelationShodan_CountryName(Shodan_Node ShNode, Shodan_Node.SmallNodes_CountryName CountryName)
    {
        var graphClient = new GraphClient(new Uri(uri), Db_id, DB_pass);
        graphClient.Connect();
        ITransaction trans = graphClient.BeginTransaction();

        var NodeQuery = graphClient.Cypher
          .Match("(sn:country_name {country_name : '" + CountryName.country_name + "'})")
          .Return(sn => sn.As<Getro>()).Results;
        if (NodeQuery.Count() == 0)
        {
            graphClient.Cypher
       .Match("(sh:Shodan {name: '" + ShNode.name + "'})")
       .Create("sh-[:COUNTRY]->(sn:CountryName{ CountryName })")
       .WithParam("CountryName", CountryName)
       .ExecuteWithoutResults();
            trans.Commit();
        }
    }

    public void CreateRelationShodan_IPsTR(Shodan_Node ShNode, Shodan_Node.SmallNodes_IPsTR ipStr)
    {
        var graphClient = new GraphClient(new Uri(uri), Db_id, DB_pass);
        graphClient.Connect();
        ITransaction trans = graphClient.BeginTransaction();

        var NodeQuery = graphClient.Cypher
          .Match("(sn:ip_str {ip_str : '" + ipStr.ip_str + "'})")
          .Return(sn => sn.As<Getro>()).Results;
        if (NodeQuery.Count() == 0)
        {
            graphClient.Cypher
       .Match("(sh: Shodan {name :'" + ShNode.name + "'})")
       .Create("sh-[:IPSTR]->(sn:ip_str{ ipStr })")
       .WithParam("ipStr", ipStr)
       .ExecuteWithoutResults();
            trans.Commit();
        }

    }
    public void CreateRelationShodan_ASN(Shodan_Node ShNode, Shodan_Node.SmallNodes_ASN ASN)
    {
        var graphClient = new GraphClient(new Uri(uri), Db_id, DB_pass);
        graphClient.Connect();
        ITransaction trans = graphClient.BeginTransaction();

        var NodeQuery = graphClient.Cypher
          .Match("(sn:asn {asn : '" + ASN.asn + "'})")
          .Return(sn => sn.As<Getro>()).Results;
        if (NodeQuery.Count() == 0)
        {
            graphClient.Cypher
       .Match("(sh:Shodan {name:'" + ShNode.name + "'})")
       .Create("sh-[:ASN]->(sn:asn{ ASN })")
       .WithParam("ASN", ASN)
       .ExecuteWithoutResults();
            trans.Commit();
        }

    }
    public void CreateRelationShodan_Ports(Shodan_Node ShNode, Shodan_Node.SmallNodes_Ports ports)
    {
        var graphClient = new GraphClient(new Uri(uri), Db_id, DB_pass);
        graphClient.Connect();
        ITransaction trans = graphClient.BeginTransaction();

        var NodeQuery = graphClient.Cypher
          .Match("(sn:ports {ports : '" + ports.ports + "'})")
          .Return(sn => sn.As<Getro>()).Results;
        if (NodeQuery.Count() == 0)
        {
            graphClient.Cypher
       .Match("(sh: Shodan {name:'" + ShNode.name + "'})")
       .Create("sh-[:OPEN_PORT]->(sn:ports{ ports })")
       .WithParam("ports", ports)
       .ExecuteWithoutResults();
            trans.Commit();
        }

    }

    public void CreateRelationShodan_Hosts(Shodan_Node ShNode, Shodan_Node.SmallNodes_Hosts hosts)
    {
        var graphClient = new GraphClient(new Uri(uri), Db_id, DB_pass);
        graphClient.Connect();
        ITransaction trans = graphClient.BeginTransaction();

        var NodeQuery = graphClient.Cypher
          .Match("(sn:hosts {hosts : '" + hosts.hosts + "'})")
          .Return(sn => sn.As<Getro>()).Results;
        if (NodeQuery.Count() == 0)
        {
            graphClient.Cypher
       .Match("(sh:Shodan {name:'" + ShNode.name + "'})")
       .Create("sh-[:HOST]->(sn:hosts{ hosts })")
       .WithParam("hosts", hosts)
       .ExecuteWithoutResults();
            trans.Commit();
        }

    }

}