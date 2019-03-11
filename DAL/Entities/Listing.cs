using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities
{
    public class Listing : IEntityWithId
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }


        public int CampaignId { get; set; }
        [ForeignKey("CampaignId")]
        public Campaign Campaign { get; set; }
        public int TotalPositions { get; set; }
        public DateTime RegisterFrom { get; set; }
        public DateTime RegisterTo { get; set; }


        public int? CityId { get; set; }
        [ForeignKey("CityId")]
        public City City { get; set; }


        public int CompanyId { get; set; }
        [ForeignKey("CompanyId")]
        public Company Company { get; set; }
    }
}
