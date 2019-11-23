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
            var entry = this._context.Entry(entity);
            if (entry.State != EntityState.Detached)
            {
                entry.State = EntityState.Added;
            }
            else
            {
                this.DbSet.Add(entity);
            }
        }

        public IQueryable<TEnt> GetAll()
        {
            return this.Entities.AsQueryable();
        }

        public TEnt Attach(TEnt entity)
        {
            return this._context.Set<TEnt>().Attach(entity);
        }

        public void Dispose()
        {
            this._context.Dispose();
        }

        public TEnt GetById(int id)
        {
            return this.Entities.Find(id);
        }

        public void Remove(TEnt entity)
        {
            var entry = this._context.Entry(entity);
            if (entry.State != EntityState.Deleted)
            {
                entry.State = EntityState.Deleted;
            }
            else
            {
                this.DbSet.Attach(entity);
                this.DbSet.Remove(entity);
            }
        }

        public void RemoveById(int id)
        {
            var entity = this.GetById(id);

            if (entity != null)
            {
                this.Remove(entity);
            }
        }

        public void SaveChanges()
        {
            
            this._context.SaveChanges();
        }

        public void Update(TEnt entity)
        {
            var entry = this._context.Entry(entity);
            if (entry.State == EntityState.Detached)
            {
                this.DbSet.Attach(entity);
            }

            entry.State = EntityState.Modified;
           }

    }
}
