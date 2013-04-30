using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    public class Route
    {
        private List<WayPoint> _wayPointList;
        private string _totaleDuur;
        private string _totaleKM;

        public Route()
        {

        }
        public Route(List<WayPoint> lijst, string totaleDuur, string totaleKM)
        {
            this._wayPointList = lijst;
            this._totaleDuur = totaleDuur;
            this._totaleKM = totaleKM;
        }

        public List<WayPoint> WayPointList { get { return this._wayPointList; } set { this._wayPointList = value; } }
        public String TotaleDuur { get { return this._totaleDuur; } set { this._totaleDuur = value; } }
        public String TotaleKM { get { return this._totaleKM; } set { this._totaleKM = value; } }
    }
}
