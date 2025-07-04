﻿using ConcertBooking.Entites;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace TechnolodyKeeda.ConcertBooking.Repositories
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser> //DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext>options):base(options) 
        {
            
        }
        public DbSet<Venue> Venues { get; set; }
        public DbSet<Concert> Concerts { get; set; }
        public DbSet<Artist> Artists { get; set; }
        public DbSet<Ticket> Tickets { get; set; }
        public DbSet<Booking> Bookings { get; set; }
    }
}
