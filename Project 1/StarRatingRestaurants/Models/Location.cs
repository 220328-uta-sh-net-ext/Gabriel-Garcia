using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Location : IRestLocationModel
    {
        public string Id { get; set; }
        public string Country { get; set; }
        public string State { get; set; }
        public string City { get; set; }
        public string Zipcode { get; set; }

        ~Location() { }
        public Location()
        {
            Id = "";
            Country = "";
            State = "";
            City = "";
            Zipcode = "";
        }
    }
}
