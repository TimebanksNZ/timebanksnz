using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimebanksNZ.DAL.Entities
{
    public class Timebank
    {
        public int IdTimebank { get; set; }
        public string Name { get; set; }
        public string Url { get; set; }
        public double GeoLat { get; set; }
        public double GeoLong { get; set; }
        public string Suburb { get; set; }
        public string City { get; set; }
        public bool? IsMemberTimebankNZ { get; set; }
        public int IdCountry { get; set; }
        public int IdTheme { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string Postcode { get; set; }
    }
}
