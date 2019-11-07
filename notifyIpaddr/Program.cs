using System;
using System.Net;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.Json;

namespace notifyIpaddr
{    
    class Program
    {
        
        static void Main(string[] args)
        {
            //Console.WriteLine("Hello World!");
            ConfigureService.Configure();            
        }
    }
}
