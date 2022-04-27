using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantML
{
    public class Location
    {
        public string Contry { get; set; }
        public string State { get; set; }
        public string Zipcode { get; set; }
        public Location()
        {
            Contry = "";
            State = "";
            Zipcode = "";
        }
    }
}
