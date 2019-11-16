using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Unigo.Data;

namespace Unigo.Repo
{
    public class GenericRepo<TEnt> : IRepository<TEnt> where TEnt: class
    {

        protected IDBContext _context { get; set; }
        protected IDbSet<TEnt> DbSet { get; set; }

        private IDbSet<TEnt> Entities
        {
            get
            {
                if (DbSet == null)
                {
                    DbSet = _context.Set<TEnt>();
                }
                return DbSet;
            }
        }

        public GenericRepo(IDBContext context)
        {
            if (context == null)
            {
                throw new ArgumentException("An instance of DbContext is required to use this repository.", "_context");
            }

            this._context = context;
            this.DbSet = this._context.Set<TEnt>();
        }


        public void Add(TEnt entity)
        {
            throw new NotImplementedException();
        }

        public IQueryable<TEnt> GetAll()
        {
            if(!(this.Entities.AsQueryable() == null))
            {
                return this.Entities.AsQueryable();

            }

            IQueryable<TEnt> empty = Enumerable.Empty<TEnt>().AsQueryable();
            return empty;
        }

        public void Attach(TEnt entity)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public TEnt GetById(int id)
        {
            return this.Entities.Find(id);
        }

        public void Remove(TEnt entity)
        {
            throw new NotImplementedException();
        }

        public void RemoveById(int id)
        {
            throw new NotImplementedException();
        }

        public void SaveChanges()
        {
            throw new NotImplementedException();
        }

        public void Update(TEnt entity)
        {
            throw new NotImplementedException();
        }
    }
}
