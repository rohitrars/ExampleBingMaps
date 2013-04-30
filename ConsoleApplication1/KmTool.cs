using System;
using System.Net;
using System.Runtime.Serialization.Json;
using BingMapsRESTService.Common.JSON;
using System.Windows;
using System.Collections.Generic;
using System.Collections;

namespace ConsoleApplication1
{
    class KmTool
    {
        private List<Adres> _adresLijst;
        private List<WayPoint> waypoints;
        private Route route;
        static string BingMapsKey = "PUT YOUR KEY HERE";

        public KmTool(List<Adres> adreslijst)
        {
            this._adresLijst = adreslijst;
            waypoints = new List<WayPoint>();
            route = new Route();
            calculate();
        }

        private void calculate()
        {
           
            //1. Alle adressen overlopen en er telkens 2 pakken  van de uitkomst van die 2 maakte dan een waypoint
            WayPoint wp0 = new WayPoint();
            wp0.KmVanOorsprongNaarWayPoint = "0";
            wp0.KmVanVorigeWayPoinstNaarHuidigWayPoint = "0";
            wp0.TijdVanOorsprongNaarWayPoint = "0";
            wp0.TijdVanVorigWayPointNaarHuidigWayPoint = "0";
            wp0.Plaats = _adresLijst[0];
            waypoints.Add(wp0);
            for (int i = 0; i < this._adresLijst.Count-1; i++ )
            {
                Adres a1 = _adresLijst[i];
                Adres a2 = _adresLijst[i + 1];
                try
                {
                    string locationsRequest = CreateRoute(a1,a2);
                    string output = "";
                    Response locationsResponse = MakeRequest(locationsRequest);
                    output = ProcessResponse(locationsResponse);
                    string[] words = output.Split(':');
                    WayPoint p = new WayPoint(words[0], words[1]);
                    p.Plaats = a2;
                    waypoints.Add(p);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    Console.Read();
                }
            }
            //nog ne for loop da elke waypoint met waypoint 0 vergelijkt 
            for (int i = 1; i < waypoints.Count; i++) {
                WayPoint w = waypoints[i];
                double kmw1 = Double.Parse(w.KmVanVorigeWayPoinstNaarHuidigWayPoint);
                double tijdw1 = Double.Parse(w.TijdVanVorigWayPointNaarHuidigWayPoint);
                double kmw0 = Double.Parse(waypoints[i - 1].KmVanVorigeWayPoinstNaarHuidigWayPoint);
                double tijdw0 = Double.Parse(waypoints[i - 1].TijdVanVorigWayPointNaarHuidigWayPoint);
                double totKm = kmw0 + kmw1;
                double totMin = tijdw0 + tijdw1;
                w.KmVanOorsprongNaarWayPoint = "" + totKm;
                w.TijdVanOorsprongNaarWayPoint = "" + totMin;
            }
            printAlleTussenDingenUit();
            MakeTheRoute();
            ToonRitInfo();
        }

        public static String CreateRoute(Adres adres1, Adres adres2)
        {
            string url = "http://dev.virtualearth.net/REST/V1/Routes/Driving?";
            url += "wp.0=";
            if (adres1.Straat != null)
                url += adres1.Straat + "%20";
            if (adres1.Nummer != null)
                url += adres1.Nummer + "%20";
            if (adres1.Postcode != null)
                url += adres1.Postcode + "%20";
            if (adres1.Gemeente != null)
                url += adres1.Gemeente;
            url += "&wp.1=";
            if (adres2.Straat != null)
                url += adres2.Straat + "%20";
            if (adres2.Nummer != null)
                url += adres2.Nummer + "%20";
            if (adres2.Postcode != null)
                url += adres2.Postcode + "%20";
            if (adres2.Gemeente != null)
                url += adres2.Gemeente;
            url += "&key=" + BingMapsKey;
            return (url);
        }

        public static Response MakeRequest(string requestUrl)
        {
            try
            {
                HttpWebRequest request = WebRequest.Create(requestUrl) as HttpWebRequest;
                using (HttpWebResponse response = request.GetResponse() as HttpWebResponse)
                {
                    if (response.StatusCode != HttpStatusCode.OK)
                        throw new Exception(String.Format(
                        "Server error (HTTP {0}: {1}).",
                        response.StatusCode,
                        response.StatusDescription));
                    DataContractJsonSerializer jsonSerializer = new DataContractJsonSerializer(typeof(Response));
                    object objResponse = jsonSerializer.ReadObject(response.GetResponseStream());
                    Response jsonResponse
                    = objResponse as Response;
                    return jsonResponse;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return null;
            }

        }

        static public string ProcessResponse(Response locationsResponse)
        {
            string output = "";
            BingMapsRESTService.Common.JSON.Route route = (BingMapsRESTService.Common.JSON.Route)locationsResponse.ResourceSets[0].Resources[0];
            string km = route.TravelDistance.ToString();
            string minuten = "" + route.TravelDuration / 60;
            output = km +":"+ minuten;
            return output;
        }

        public void printAlleTussenDingenUit() { 
            foreach(WayPoint w in waypoints){
                Console.WriteLine(w.KmVanOorsprongNaarWayPoint + " " + w.KmVanVorigeWayPoinstNaarHuidigWayPoint + " " + w.TijdVanOorsprongNaarWayPoint + " " + w.TijdVanVorigWayPointNaarHuidigWayPoint);
                Console.WriteLine("Adres : " + w.Plaats.Straat + " " + w.Plaats.Nummer + " " + w.Plaats.Postcode + " " + w.Plaats.Gemeente);
            }
            Console.ReadLine();
        }

        private void MakeTheRoute() {
            this.route.WayPointList = this.waypoints;
            this.route.TotaleKM = this.waypoints[waypoints.Count - 1].KmVanOorsprongNaarWayPoint;
            this.route.TotaleDuur = this.waypoints[waypoints.Count - 1].TijdVanOorsprongNaarWayPoint;
        }

        private void ToonRitInfo() {
            Console.WriteLine("Totale km = " + route.TotaleKM + "km  [[[]]] Totale duur : " + route.TotaleDuur + " min");
            Console.ReadKey();
        }
    }
}
