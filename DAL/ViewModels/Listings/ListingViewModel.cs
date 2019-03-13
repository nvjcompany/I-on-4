﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DAL.ViewModels.Listings
{
    public class ListingViewModel
    {
        public int Id { get; set; }
        [Required]
        [StringLength(255)]
        public string Title { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public int TotalPositions { get; set; }
        [Required]
        public DateTime RegisterFrom { get; set; }
        [Required]
        public DateTime RegisterTo { get; set; }
        [Required]
        public int? CityId { get; set; }
    }
}
