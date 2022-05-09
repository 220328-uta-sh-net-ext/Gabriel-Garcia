using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Reviews : IRestReviewsModel
    {

        public string Id { get; set; }
        public string ReviewerId { get; set; }
        public int Rate { get; set; }
        public string Review { get; set; }
        ~Reviews() { }
        public Reviews()
        {
            Id = "";
            ReviewerId = "";
            Rate = 0;
            Review = "";
        }
    }
}
