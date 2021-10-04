using DotNetEFAutoLot.DAL.EF;
using DotNetEFAutoLot.DAL.Models.Base;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNetEFAutoLot.DAL.Repositories
{
    public class BaseRepository<T> : IDisposable, IRepository<T> where T : EntityBase, new()
    {
        private readonly DbSet<T> table;
        private readonly AutoLotEntities db;
        private bool disposedValue;

        protected AutoLotEntities Context => db;

        public BaseRepository()
        {
            db = new AutoLotEntities();
            table = db.Set<T>();
        }

        public int Add(T entity)
        {
            table.Add(entity);

            return SaveChanges();
        }

        public int AddRange(IList<T> entities)
        {
            table.AddRange(entities);

            return SaveChanges();
        }

        public int Delete(int id, byte[] timeStamp) => Delete(new T { Id = id, Timestamp = timeStamp });

        public int Delete(T entity)
        {
            db.Entry(entity).State = EntityState.Deleted;

            return SaveChanges();
        }

        public List<T> ExecuteQuery(string sql) => table.SqlQuery(sql).ToList();

        public List<T> ExecuteQuery(string sql, object[] sqlParametersObjects) => table.SqlQuery(sql, sqlParametersObjects).ToList();

        public virtual List<T> GetAll() => table.ToList();

        public T GetOne(int? id) => table.Find(id);

        public int Save(T entity)
        {
            db.Entry(entity).State = EntityState.Modified;

            return SaveChanges();
        }

        internal int SaveChanges()
        {
            try
            {
                return db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                Console.WriteLine($"DbUpdateConcurrencyException {ex.Message}");
                throw;
            }
            catch (DbUpdateException ex)
            {
                Console.WriteLine($"DbUpdateException {ex.Message}");
                throw;
            }
            catch (CommitFailedException ex)
            {
                Console.WriteLine($"CommitFailedException {ex.Message}");
                throw;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception {ex.Message}");
                throw;
            }
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    db.Dispose();
                }

                // TODO: free unmanaged resources (unmanaged objects) and override finalizer
                // TODO: set large fields to null
                disposedValue = true;
            }
        }

        ~BaseRepository()
        {
            // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
            Dispose(disposing: false);
        }

        public void Dispose()
        {
            // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }
    }
}
