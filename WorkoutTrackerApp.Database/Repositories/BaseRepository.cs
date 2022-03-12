using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace WorkoutTrackerApp.Database.Repositories
{
    public abstract class BaseRepository<Entity> where Entity : class
    {
        protected WorkoutTrackerDbContext mDbContext;
        protected abstract DbSet<Entity> DbSet { get;}

        public BaseRepository(WorkoutTrackerDbContext dbContext)
        {
            mDbContext = dbContext;
        }

        public void SaveChanges()
        {
            mDbContext.SaveChanges();
        }
    }
}
