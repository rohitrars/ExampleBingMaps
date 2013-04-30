using System;
using System.Net;
using System.Runtime.Serialization.Json;
using BingMapsRESTService.Common.JSON;
using System.Windows;
using ConsoleApplication1;
using System.Collections.Generic;



namespace RESTServicesJSONParserExample
{
    class Program
    {
        static void Main(string[] args)
        {
            Adres a1 = new Adres("Pastoor Tilemansstraat","4","3051","sint-joris-weert");
            Adres a2 = new Adres("interleuvenlaan","15","3001","Heverlee");
            Adres a3 = new Adres("naamsesteenweg", "355", "3001", "Heverlee");
            List<Adres> lijst = new List<Adres>();
            lijst.Add(a1); lijst.Add(a2); lijst.Add(a3);
            KmTool k = new KmTool(lijst);
        }

    }
}