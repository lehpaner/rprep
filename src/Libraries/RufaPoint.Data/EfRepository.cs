using System;
using System.Collections.Generic;
using System.Linq;
using RufaPoint.Core;
using RufaPoint.Core.Data;
using Microsoft.EntityFrameworkCore;

namespace RufaPoint.Data
{
    /// <summary>
    /// Entity Framework repository
    /// </summary>
    public partial class EfRepository<T> : IRepository<T> where T : BaseEntity
    {
        #region Fields

        private readonly IDbContext _context;
        private DbSet<T> _entities;

        #endregion

        #region Ctor

        /// <summary>
        /// Ctor
        /// </summary>
        /// <param name="context">Object context</param>
        public EfRepository(IDbContext context)
        {
            this._context = context;
        }

        #endregion

        #region Utilities

        /// <summary>
        /// Get full error
        /// </summary>
        /// <param name="exc">Exception</param>
        /// <returns>Error</returns>
        protected string GetFullErrorText(/*DbEntityValidation*/Exception exc)
        {
            /*
            var msg = string.Empty;
            foreach (var validationErrors in exc.EntityValidationErrors)
                foreach (var error in validationErrors.ValidationErrors)
                    msg += $"Property: {error.PropertyName} Error: {error.ErrorMessage}" + Environment.NewLine;
            return msg;
            */
            return exc.Message;
        }

        /// <summary>
        /// Rollback of entity changes and return full error message
        /// </summary>
        /// <param name="dbEx">Exception</param>
        /// <returns>Error</returns>
        protected string GetFullErrorTextAndRollbackEntityChanges(/*DbEntityValidation*/Exception dbEx)
        {
            var fullErrorText = GetFullErrorText(dbEx);
            /*
            foreach (var entry in dbEx.EntityValidationErrors.Select(error => error.Entry))
            {
                if (entry == null)
                    continue;

                //rollback of entity changes
                entry.State = EntityState.Unchanged;
            }
            */
            _context.SaveChanges();
            return fullErrorText;
        }

        #endregion

        #region Methods

        /// <summary>
        /// Get entity by identifier
        /// </summary>
        /// <param name="id">Identifier</param>
        /// <returns>Entity</returns>
        public virtual T GetById(object id)
        {
            //see some suggested performance optimization (not tested)
            //http://stackoverflow.com/questions/11686225/dbset-find-method-ridiculously-slow-compared-to-singleordefault-on-id/11688189#comment34876113_11688189
           // return Entities.Find(id);
            return _entities.Find(id);
        }

        /// <summary>
        /// Insert entity
        /// </summary>
        /// <param name="entity">Entity</param>
        public virtual void Insert(T entity)
        {
            try
            {
                if (entity == null)
                    throw new ArgumentNullException(nameof(entity));

                // Entities.Add(entity);
                _entities.Add(entity);
                _context.SaveChanges();
            }
            catch (/*DbEntityValidation*/Exception dbEx)
            {
                //ensure that the detailed error text is saved in the Log
                throw new Exception(GetFullErrorTextAndRollbackEntityChanges(dbEx), dbEx);
            }
        }

        /// <summary>
        /// Insert entities
        /// </summary>
        /// <param name="entities">Entities</param>
        public virtual void Insert(IEnumerable<T> entities)
        {
            try
            {
                if (entities == null)
                    throw new ArgumentNullException(nameof(entities));

                foreach (var entity in entities)
                    _entities.Add(entity);
                // Entities.Add(entity);

                _context.SaveChanges();
            }
            catch (/*DbEntityValidation*/Exception dbEx)
            {
                //ensure that the detailed error text is saved in the Log
                throw new Exception(GetFullErrorTextAndRollbackEntityChanges(dbEx), dbEx);
            }
        }

        /// <summary>
        /// Update entity
        /// </summary>
        /// <param name="entity">Entity</param>
        public virtual void Update(T entity)
        {
            try
            {
                if (entity == null)
                    throw new ArgumentNullException(nameof(entity));

                _context.SaveChanges();
            }
            catch (/*DbEntityValidation*/Exception dbEx)
            {
                //ensure that the detailed error text is saved in the Log
                throw new Exception(GetFullErrorTextAndRollbackEntityChanges(dbEx), dbEx);
            }
        }

        /// <summary>
        /// Update entities
        /// </summary>
        /// <param name="entities">Entities</param>
        public virtual void Update(IEnumerable<T> entities)
        {
            try
            {
                if (entities == null)
                    throw new ArgumentNullException(nameof(entities));

                _context.SaveChanges();
            }
            catch (/*DbEntityValidation*/Exception dbEx)
            {
                //ensure that the detailed error text is saved in the Log
                throw new Exception(GetFullErrorTextAndRollbackEntityChanges(dbEx), dbEx);
            }
        }

        /// <summary>
        /// Delete entity
        /// </summary>
        /// <param name="entity">Entity</param>
        public virtual void Delete(T entity)
        {
            try
            {
                if (entity == null)
                    throw new ArgumentNullException(nameof(entity));
                _entities.Remove(entity);
                //Entities.Remove(entity);

                _context.SaveChanges();
            }
            catch (/*DbEntityValidation*/Exception dbEx)
            {
                //ensure that the detailed error text is saved in the Log
                throw new Exception(GetFullErrorTextAndRollbackEntityChanges(dbEx), dbEx);
            }
        }

        /// <summary>
        /// Delete entities
        /// </summary>
        /// <param name="entities">Entities</param>
        public virtual void Delete(IEnumerable<T> entities)
        {
            try
            {
                if (entities == null)
                    throw new ArgumentNullException(nameof(entities));

                foreach (var entity in entities)
                    _entities.Remove(entity);
                //Entities.Remove(entity);

                _context.SaveChanges();
            }
            catch (/*DbEntityValidation*/Exception dbEx)
            {
                //ensure that the detailed error text is saved in the Log
                throw new Exception(GetFullErrorTextAndRollbackEntityChanges(dbEx), dbEx);
            }
        }
        
        #endregion

        #region Properties

        /// <summary>
        /// Gets a table
        /// </summary>
        public virtual IQueryable<T> Table
        {
            get
            {
                return _entities;
                //return Entities;
            }
        }

        /// <summary>
        /// Gets a table with "no tracking" enabled (EF feature) Use it only when you load record(s) only for read-only operations
        /// </summary>
        public virtual IQueryable<T> TableNoTracking
        {
            get
            {
                return _entities.AsNoTracking();
               // return Entities.AsNoTracking();
            }
        }

        /// <summary>
        /// Entities
        /// </summary>
        //protected virtual IDbSet<T> Entities
        //{
        //    get
        //    {
        //        if (_entities == null)
        //            _entities = _context.Set<T>();
        //        return _entities;
        //    }
        //}

        #endregion
    }
}