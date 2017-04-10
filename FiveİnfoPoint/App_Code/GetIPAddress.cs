using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;


public class GetIPAddress
{
    private readonly string HostName;
    public GetIPAddress(string hostName)
    {
        HostName = hostName;
    }

    public IPAddress[] GetIP() {
        IPAddress[] addresslist = Dns.GetHostAddresses(HostName);
        return addresslist;
        
    } 
}