using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Unigo.Data
{
    public interface IDBContext
    {

        IDbSet<Person> Persons { get; set; }
        IDbSet<Car> Cars { get; set; }
        IDbSet<Ride> Rides { get; set; }
        IDbSet<Destination> Destinations { get; set; }
        IDbSet<PersonRide> PersonRides { get; set; }
        IDbSet<Rating> Ratings { get; set; }
        IDbSet<StopPointRide> StopPointRides { get; set; }

        DbSet<TEntity> Set<TEntity>() where TEntity : class;

        DbEntityEntry<TEntity> Entry<TEntity>(TEntity entity) where TEntity : class;
        int SaveChanges();

        void Dispose();
    }
}
