using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Script.Serialization;

public class ShodanWebApi
{
    private readonly string API_KEY = "59Cg2DHRU1MbS2UKTyDQcwrfpEYaPUEl";
    private readonly IPAddress IP;
    private JavaScriptSerializer json_parser = new JavaScriptSerializer();
    private WebClient web_client = new WebClient();

    public ShodanWebApi(IPAddress ip)
    {
        IP = ip;
    }

    private Dictionary<string, object> SendRequest()
    {
        Stream response = web_client.OpenRead("https://api.shodan.io/shodan/host/" + IP + "?key=" + API_KEY);
        StreamReader reader = new StreamReader(response);
        string data = reader.ReadToEnd();
        reader.Close();
        Dictionary<string, object> result = json_parser.Deserialize<Dictionary<string, object>>(data);
        if (result.ContainsKey("error"))
        {
            throw new System.ArgumentException((string)result["error"]);
        }
        return result;
    }

    public Dictionary<string, object> Post() { return SendRequest(); }
}


public class SeeResult
{
    private readonly IPAddress _IP;
    public SeeResult(IPAddress _ip) { _IP = _ip; }
    public Dictionary<string, object> SearchResult()
    {
        ShodanWebApi Webapi = new ShodanWebApi(_IP);
        return Webapi.Post();
    }
}