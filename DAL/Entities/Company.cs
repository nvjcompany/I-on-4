using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities
{
    public class Company
    {
        public int Id { get; set; }

        public string OwnerId { get; set; }
        [Index(IsUnique = true)]
        [ForeignKey("OwnerId")]
        public User Owner { get; set; }

        
        public int? CityId { get; set; }
        [ForeignKey("CityId")]
        public City City { get; set; }

        public string Bulstat { get; set; }
        public string Logo { get; set; }
    }
}
