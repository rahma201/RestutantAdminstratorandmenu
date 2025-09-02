using Microsoft.EntityFrameworkCore;
using Pro2.Models;

namespace Pro2.Repositories
{
    public class Repository<T> : IRepository<T> where T : BaseEntity
    {
        Pro2Context db;
        DbSet<T> set;
        public Repository(Pro2Context db)
        {
            this.db = db;
            this.set = db.Set<T>();
        }

        public void Add(T entity)
        {
            set.Add(entity);

            db.SaveChanges();
        }

        public void ChangeStatus(int Id)
        {
            var entity = Find(Id);
            entity.IsActive = !entity.IsActive;
            Update(entity);
        }

        public void Delete(int Id)
        {
            var entity = Find(Id);
            set.Remove(entity);
            db.SaveChanges();
        }

        public T Find(int Id)
        {
            return set.FirstOrDefault(x => x.Id == Id && !x.IsDeleted);
        }

        public void Update(T entity)
        {
            set.Update(entity);
            db.SaveChanges();
        }

        public List<T> ViewClient()
        {
            return set.Where(x => !x.IsDeleted && x.IsActive).ToList();
        }
        public List<T> View()
        {
            return set.Where(x => !x.IsDeleted).ToList();
        }
    }
}
