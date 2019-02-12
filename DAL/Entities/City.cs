using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities
{
    public class City
    {
        public City()
        {
            this.Companies = new List<Company>();
            this.Listings = new List<Listing>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public List<Company> Companies { get; set; }
        public List<Listing> Listings { get; set; }
    }
}
