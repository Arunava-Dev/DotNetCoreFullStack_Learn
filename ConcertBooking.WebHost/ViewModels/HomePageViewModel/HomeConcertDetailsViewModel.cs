﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConcertBooking.WebHost.ViewModels.HomePageViewModel
{
    public class HomeConcertDetailsViewModel
    {
        public int ConcertId { get; set; }
        public string ConcertName { get; set; }
        public DateTime Date { get; set; }
        public string Description { get; set; }
        public string ArtistName { get; set; }
        public string ArtistImage { get; set; }
        public string VenueName { get; set; }
        public string VenueAddress { get; set; }
        public string ConcertImage { get; set; }
        
    }
}
