using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Unigo.Repo
{

    // {TEnt} is set with the constraints as class
    public interface IRepository<TEnt> : IDisposable where TEnt : class
    {
        IQueryable<TEnt> GetAll();

        TEnt GetById(int id);

        void Add(TEnt entity);

        void Update(TEnt entity);

        //https://docs.microsoft.com/en-us/ef/ef6/saving/change-tracking/entity-state#attaching-an-existing-entity-to-the-context
        TEnt Attach(TEnt entity);

        void Remove(TEnt entity);

        void RemoveById(int id);

        void SaveChanges();
    }
}
