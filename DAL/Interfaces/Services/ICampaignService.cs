﻿using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces.Services
{
    public interface ICampaignService : IMaintanable<Campaign>
    {
        /// <summary>
        /// Get active campaign if exists. Else return null.
        /// </summary>
        /// <returns></returns>
        Task<Campaign> GetActiveCampaign();
    }
}