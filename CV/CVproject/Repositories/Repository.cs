using CVproject.Data;
using CVproject.Models;
using Microsoft.EntityFrameworkCore;

namespace CVproject.Repositories
{
    public class Repository<T> : IRepository<T> where T : BaseEntity
    {
        DataDbContext dbContext;
        DbSet<T> dbSet;

        public Repository(DataDbContext dbContext)
        {
            this.dbContext=dbContext;
            dbSet = dbContext.Set<T>();
        }

        public void Add(T Entity)
        {
            Entity.CreateDate = DateTime.Now;
            Entity.IsActivate = true;
            dbSet.Add(Entity);
            dbContext.SaveChanges();
        }

        public void ChangeStatus(int id)
        {
            var Entity = Find(id);

            Entity.IsActivate = !Entity.IsActivate;
            dbSet.Update(Entity);
            dbContext.SaveChanges();
        }

        public void Delete(int id)
        {
            var categoryx = Find(id);
            dbSet.Remove(categoryx);
            dbContext.SaveChanges();
        }

        public T Find(int id)
        {
            return dbSet.FirstOrDefault(x => !x.IsDeleted && x.Id == id);
        }

        public void Update(int id, T Entity)
        {
            var oldEntity = dbSet.Find(Entity.Id);
            Entity.EditDate = DateTime.Now;
            Entity.CreateDate= oldEntity.CreateDate;
            Entity.DeleteDate = oldEntity.DeleteDate;
            Entity.IsDeleted = false;
            Entity.IsActivate = true;
            dbSet.Update(Entity);
            dbContext.SaveChanges();
        }

        public List<T> View()
        {
            return dbSet.Where(x => !x.IsDeleted).ToList();
        }

        public List<T> ViewClient()
        {
            return dbSet.Where(x => !x.IsDeleted && x.IsActivate).ToList();
        }
    }
}
