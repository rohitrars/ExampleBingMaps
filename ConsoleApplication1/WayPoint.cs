using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    public class WayPoint
    {
        private Adres plaats;
        private String _kmVanOorsprongNaarWayPoint;
        private String _kmVanVorigeWayPoinstNaarHuidigWayPoint;
        private String _tijdVanOorsprongNaarWayPoint;
        private String _tijdVanVorigWayPointNaarHuidigWayPoint;

        public WayPoint()
        {
           
        }

        public WayPoint(string kmVanVorigeWayPoinstNaarHuidigWayPoint, string tijdVanVorigWayPointNaarHuidigWayPoint)
        {
            this._kmVanVorigeWayPoinstNaarHuidigWayPoint = kmVanVorigeWayPoinstNaarHuidigWayPoint;
            this._tijdVanVorigWayPointNaarHuidigWayPoint = tijdVanVorigWayPointNaarHuidigWayPoint;
            this.KmVanOorsprongNaarWayPoint = "0";
            this.TijdVanOorsprongNaarWayPoint = "0";
        }
        public WayPoint(string kmVanOorsprongNaarWayPoint, string kmVanVorigeWayPoinstNaarHuidigWayPoint, string tijdVanOorsprongNaarWayPoint, string _tijdVanVorigWayPointNaarHuidigWayPoint)
        {
            this._kmVanOorsprongNaarWayPoint = kmVanOorsprongNaarWayPoint;
            this._kmVanVorigeWayPoinstNaarHuidigWayPoint = kmVanVorigeWayPoinstNaarHuidigWayPoint;
            this._tijdVanOorsprongNaarWayPoint = tijdVanOorsprongNaarWayPoint;
            this._tijdVanVorigWayPointNaarHuidigWayPoint = _tijdVanVorigWayPointNaarHuidigWayPoint;
        }

        public String KmVanOorsprongNaarWayPoint { get { return this._kmVanOorsprongNaarWayPoint; } set { this._kmVanOorsprongNaarWayPoint = value; } }
        public String KmVanVorigeWayPoinstNaarHuidigWayPoint { get { return this._kmVanVorigeWayPoinstNaarHuidigWayPoint; } set { this._kmVanVorigeWayPoinstNaarHuidigWayPoint = value; } }
        public String TijdVanOorsprongNaarWayPoint { get { return this._tijdVanOorsprongNaarWayPoint; } set { this._tijdVanOorsprongNaarWayPoint = value; } }
        public String TijdVanVorigWayPointNaarHuidigWayPoint { get { return this._tijdVanVorigWayPointNaarHuidigWayPoint; } set { this._tijdVanVorigWayPointNaarHuidigWayPoint = value; } }
        public Adres Plaats { get { return this.plaats; } set { this.plaats = value; } }
    }
}
