using CVproject.Models;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.EntityFrameworkCore;

namespace CVproject.Data.Interceptors
{
    public class SoftDeleteInterceptor : SaveChangesInterceptor
    {

        public override InterceptionResult<int> SavingChanges(DbContextEventData eventData, InterceptionResult<int> result)
        {
            var dbContext = eventData.Context;

            if (dbContext == null)
            {
                return new InterceptionResult<int>();
            }

            foreach (var item in dbContext.ChangeTracker.Entries<BaseEntity>())
            {
                if (item.State == EntityState.Deleted)
                {

                    item.State = EntityState.Modified;
                    item.Entity.DeleteDate = DateTime.Now;
                    item.Entity.IsDeleted = true;


                }

            }
            return base.SavingChanges(eventData, result);
        }

    }
}
