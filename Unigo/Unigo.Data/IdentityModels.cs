﻿using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Unigo.Data
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit https://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
       
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {

        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public DbSet<Person> Persons { get; set; }
        public DbSet<Car> Cars { get; set; }
        public DbSet<Ride> Rides { get; set; }
        public DbSet<Destination> Destinations { get; set; }
        public DbSet<PersonRide> PersonRides { get; set; }
        public DbSet<Rating> Ratings { get; set; }
        public DbSet<StopPointRide> StopPointRides { get; set; }

        private static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

    }
}