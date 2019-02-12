using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities
{
    public class Campaign
    {
        public Campaign()
        {
            this.Listings = new List<Listing>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public bool IsActiveRegistration { get; set; }
        public List<Listing> Listings { get; set; }
    }
}
