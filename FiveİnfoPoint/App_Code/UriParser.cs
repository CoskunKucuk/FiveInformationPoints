using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for UriParser
/// </summary>
public class UriParser
{
    private readonly string _url;
    public UriParser(string URL)
    {
        _url = URL;
    }
    public string host;
    public string path;
    public string[] pathsegments;
    public string querystring;
    public string AbsoluteUri;
    public string DnsSafeHost;
    public string ost;
    
    public void UriParse()
    {
        Uri myUri = new Uri(_url);
        host = myUri.Authority;
        path = myUri.PathAndQuery;
        pathsegments = myUri.Segments;
        querystring = myUri.Query;
        AbsoluteUri= myUri.AbsoluteUri;
        DnsSafeHost =myUri.DnsSafeHost;
        ost=myUri.Host;
        
        
    }
}