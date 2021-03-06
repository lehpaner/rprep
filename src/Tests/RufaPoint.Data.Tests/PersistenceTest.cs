﻿using Microsoft.EntityFrameworkCore;
using RufaPoint.Core;
using Xunit;

namespace RufaPoint.Data.Tests
{

    public abstract class PersistenceTest
    {
        protected AppObjectContext context;

        public PersistenceTest()
        {
            var options = new DbContextOptionsBuilder<AppObjectContext>()
                .UseQueryTrackingBehavior(QueryTrackingBehavior.TrackAll)
                .UseSqlServer(@"Data Source=localhost; Initial Catalog=rufa; Integrated Security=True; Persist Security Info=False")
                .Options;
            //var options = new DbContextOptionsBuilder<AppObjectContext>()
            //         .UseQueryTrackingBehavior(QueryTrackingBehavior.TrackAll)
            //         .UseInMemoryDatabase(System.Guid.NewGuid().ToString())
            //         .Options;
            context = new AppObjectContext(options);
        }

        protected string GetTestDbName()
        {
            var testDbName = "Data Source=" + System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location) + @"\\RufaPoint.Data.Tests.Db.sdf;Persist Security Info=False";
            return testDbName;
        }        
        
        /// <summary>
        /// Persistance test helper
        /// </summary>
        /// <typeparam name="T">Entity type</typeparam>
        /// <param name="entity">Entity</param>
        /// <param name="disposeContext">A value indicating whether to dispose context</param>
        protected T SaveAndLoadEntity<T>(T entity, bool disposeContext = true) where T : BaseEntity
        {
            context.Set<T>().Add(entity);
            context.SaveChanges();

            object id = entity.Id;

            if (disposeContext)
            {
                context.Dispose();
                context = new AppObjectContext(GetTestDbName());
            }

            var fromDb = context.Set<T>().Find(id);
            return fromDb;
        }
    }
}
