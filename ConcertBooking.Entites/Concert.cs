﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConcertBooking.Entites
{
    //Artist------------------(*)Concert
    //Venue--------------------(*)Concert
    public class Concert
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
        public string? ImageUrl { get; set; }
        public DateTime DateTime { get; set; }
        public int VenueId { get; set; }
        public Venue Venue { get; set; }
        public Artist Artist { get; set; }
        public int ArtistId { get; set; }
    }
}
