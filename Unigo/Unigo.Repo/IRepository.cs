using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Unigo.Repo
{
    // {TPk} value as int, so that we can implement Read/Write operations for 
    // model entity and use the int type for id parameter to read based on id
    // {TEnt} is set with the constraints as class
    interface IRepository<TEnt, in TPk> :IDisposable where TEnt : class
    {
        IQueryable<TEnt> All();

        TEnt GetById(TPk id);

        void Add(TEnt entity);

        void Update(TEnt entity);

        //https://docs.microsoft.com/en-us/ef/ef6/saving/change-tracking/entity-state#attaching-an-existing-entity-to-the-context
        void Attach(TEnt entity);

        void Remove(TEnt entity);

        void RemoveById(TPk id);

        void SaveChanges();
    }
}
