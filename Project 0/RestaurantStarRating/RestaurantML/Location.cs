using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantML
{
    public class Location
    {
        public string sContry { get; set; }
        public string sState { get; set; }
        public string sZipcode { get; set; }
        public Location()
        {
            sContry = "";
            sState = "";
            sZipcode = "";
        }
    }
}
