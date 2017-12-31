<<<<<<< HEAD
﻿using Microsoft.EntityFrameworkCore;
using RufaPoint.Core;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Reflection;
using System.Text;
=======
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using RufaPoint.Core;
using RufaPoint.Data.Mapping;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using System.Data.Common;
using System.Data;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore.Diagnostics;
>>>>>>> 2e885519c792b00b6562bc7d426d77be57e39220

namespace RufaPoint.Data
{
    /// <summary>
    /// Object context
    /// </summary>
    public class AppObjectContext : DbContext, IDbContext
    {
        #region Ctor
<<<<<<< HEAD
        string connectionString { get; set; }
=======
        string connectionString;
>>>>>>> 2e885519c792b00b6562bc7d426d77be57e39220
        /// <summary>
        /// Ctor
        /// </summary>
        /// <param name="nameOrConnectionString">Connecting string</param>
<<<<<<< HEAD
        public AppObjectContext(string nameOrConnectionString)// : base(nameOrConnectionString)
=======
        public AppObjectContext(string nameOrConnectionString)
>>>>>>> 2e885519c792b00b6562bc7d426d77be57e39220
        {
            connectionString = nameOrConnectionString;
        }

<<<<<<< HEAD
=======
        public AppObjectContext(DbContextOptions<AppObjectContext> options) : base(options)
        {
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=RufaPoint;Trusted_Connection=True;")
                .ConfigureWarnings(warnings => warnings.Throw(CoreEventId.IncludeIgnoredWarning));
            // optionsBuilder.UseSqlServer(connectionString);
        }
>>>>>>> 2e885519c792b00b6562bc7d426d77be57e39220
        #endregion

        #region Utilities

        /// <summary>
        /// On model creating
        /// </summary>
        /// <param name="modelBuilder">Model builder</param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
<<<<<<< HEAD
            //dynamically load all configuration
            //System.Type configType = typeof(LanguageMap);   //any of your configuration classes here
            //var typesToRegister = Assembly.GetAssembly(configType).GetTypes()

            var typesToRegister = Assembly.GetExecutingAssembly().GetTypes()
            .Where(type => !string.IsNullOrEmpty(type.Namespace))
            .Where(type => type.BaseType != null && type.BaseType.IsGenericType &&
                type.BaseType.GetGenericTypeDefinition() == typeof(Mapping.NopEntityTypeConfiguration<>));
            foreach (var type in typesToRegister)
            {
                dynamic configurationInstance = Activator.CreateInstance(type);
                //Pekmez modelBuilder.Configurations.Add(configurationInstance);
=======
            var typesToRegister = Assembly.GetExecutingAssembly().GetTypes()
            .Where(type => !string.IsNullOrEmpty(type.Namespace))
            .Where(type => type.BaseType != null && type.BaseType.IsGenericType &&
                type.BaseType.GetGenericTypeDefinition() == typeof(NopEntityTypeConfiguration<>));
            foreach (var type in typesToRegister)
            {
                dynamic configurationInstance = Activator.CreateInstance(type);
>>>>>>> 2e885519c792b00b6562bc7d426d77be57e39220
                modelBuilder.ApplyConfiguration(configurationInstance);
            }
            //...or do it manually below. For example,
            //modelBuilder.Configurations.Add(new LanguageMap());

            base.OnModelCreating(modelBuilder);
        }

        /// <summary>
        /// Attach an entity to the context or return an already attached entity (if it was already attached)
        /// </summary>
        /// <typeparam name="TEntity">TEntity</typeparam>
        /// <param name="entity">Entity</param>
        /// <returns>Attached entity</returns>
        protected virtual TEntity AttachEntityToContext<TEntity>(TEntity entity) where TEntity : BaseEntity, new()
        {
            //little hack here until Entity Framework really supports stored procedures
            //otherwise, navigation properties of loaded entities are not loaded until an entity is attached to the context
            var alreadyAttached = Set<TEntity>().Local.FirstOrDefault(x => x.Id == entity.Id);
            if (alreadyAttached == null)
            {
                //attach new entity
                Set<TEntity>().Attach(entity);
                return entity;
            }

            //entity is already loaded
            return alreadyAttached;
        }

        #endregion

        #region Methods

        /// <summary>
        /// Create database script
        /// </summary>
        /// <returns>SQL to generate database</returns>
        public string CreateDatabaseScript()
        {
<<<<<<< HEAD

            return ((IObjectContextAdapter)this).ObjectContext.CreateDatabaseScript();
=======
            //this.GetService<IDatabaseProviderServices>()
            //return ((IObjectContextAdapter)this).ObjectContext.CreateDatabaseScript();
            return this.CreateDatabaseScript();
>>>>>>> 2e885519c792b00b6562bc7d426d77be57e39220
        }

        /// <summary>
        /// Get DbSet
        /// </summary>
        /// <typeparam name="TEntity">Entity type</typeparam>
        /// <returns>DbSet</returns>
<<<<<<< HEAD
        public new IDbSet<TEntity> Set<TEntity>() where TEntity : BaseEntity
        {
            return base.Set<TEntity>();
        }

=======
        public new DbSet<TEntity> Set<TEntity>() where TEntity : BaseEntity
        {
            return base.Set<TEntity>();
        }
        
>>>>>>> 2e885519c792b00b6562bc7d426d77be57e39220
        /// <summary>
        /// Execute stores procedure and load a list of entities at the end
        /// </summary>
        /// <typeparam name="TEntity">Entity type</typeparam>
        /// <param name="commandText">Command text</param>
        /// <param name="parameters">Parameters</param>
        /// <returns>Entities</returns>
        public IList<TEntity> ExecuteStoredProcedureList<TEntity>(string commandText, params object[] parameters) where TEntity : BaseEntity, new()
        {
            //add parameters to command
            if (parameters != null && parameters.Length > 0)
            {
                for (var i = 0; i <= parameters.Length - 1; i++)
                {
                    var p = parameters[i] as DbParameter;
                    if (p == null)
                        throw new Exception("Not support parameter type");

                    commandText += i == 0 ? " " : ", ";

                    commandText += "@" + p.ParameterName;
                    if (p.Direction == ParameterDirection.InputOutput || p.Direction == ParameterDirection.Output)
                    {
                        //output parameter
                        commandText += " output";
                    }
                }
            }

<<<<<<< HEAD
            var result = Database.SqlQuery<TEntity>(commandText, parameters).ToList<TEntity>();

            //performance hack applied as described here - https://www.nopcommerce.com/boards/t/25483/fix-very-important-speed-improvement.aspx
            var acd = Configuration.AutoDetectChangesEnabled;
            try
            {
                Configuration.AutoDetectChangesEnabled = false;
=======
            //var result = Database.SqlQuery<TEntity>(commandText, parameters).ToList();
            var result = this.SqlQuery<TEntity>(commandText, parameters).ToList();
            /*Pekmez
            //performance hack applied as described here - https://www.nopcommerce.com/boards/t/25483/fix-very-important-speed-improvement.aspx
            var acd = Configuration.AutoDetectChangesEnabled;
            
            try
            {
                IConfiguration.AutoDetectChangesEnabled = false;
>>>>>>> 2e885519c792b00b6562bc7d426d77be57e39220

                for (var i = 0; i < result.Count; i++)
                    result[i] = AttachEntityToContext(result[i]);
            }
            finally
            {
                Configuration.AutoDetectChangesEnabled = acd;
            }
<<<<<<< HEAD

=======
            */
>>>>>>> 2e885519c792b00b6562bc7d426d77be57e39220
            return result;
        }

        /// <summary>
        /// Creates a raw SQL query that will return elements of the given generic type.  The type can be any type that has properties that match the names of the columns returned from the query, or can be a simple primitive type. The type does not have to be an entity type. The results of this query are never tracked by the context even if the type of object returned is an entity type.
        /// </summary>
        /// <typeparam name="TElement">The type of object returned by the query.</typeparam>
        /// <param name="sql">The SQL query string.</param>
        /// <param name="parameters">The parameters to apply to the SQL query string.</param>
        /// <returns>Result</returns>
        public IEnumerable<TElement> SqlQuery<TElement>(string sql, params object[] parameters)
        {
<<<<<<< HEAD
            return Database.SqlQuery<TElement>(sql, parameters);
        }

=======
            //return Database.SqlQuery<TElement>(sql, parameters);
            return this.SqlQuery<TElement>(sql, parameters);
        }
    
>>>>>>> 2e885519c792b00b6562bc7d426d77be57e39220
        /// <summary>
        /// Executes the given DDL/DML command against the database.
        /// </summary>
        /// <param name="sql">The command string</param>
        /// <param name="doNotEnsureTransaction">false - the transaction creation is not ensured; true - the transaction creation is ensured.</param>
        /// <param name="timeout">Timeout value, in seconds. A null value indicates that the default value of the underlying provider will be used</param>
        /// <param name="parameters">The parameters to apply to the command string.</param>
        /// <returns>The result returned by the database after executing the command.</returns>
        public int ExecuteSqlCommand(string sql, bool doNotEnsureTransaction = false, int? timeout = null, params object[] parameters)
        {
            int? previousTimeout = null;
<<<<<<< HEAD
           
            if (timeout.HasValue)
            {
            //    //store previous timeout
                previousTimeout = Database.GetCommandTimeout();
                Database.SetCommandTimeout(timeout);
                //    ((IObjectContextAdapter)this).ObjectContext.CommandTimeout = timeout;
            }
                //Start pekmez
                //var transactionalBehavior = doNotEnsureTransaction
                //    ? TransactionalBehavior.DoNotEnsureTransaction
                //    : TransactionalBehavior.EnsureTransaction;
                var result = Database.ExecuteSqlCommand(/*transactionalBehavior,*/ sql, parameters);
                //End pekmez
                if (timeout.HasValue)
                {
                    //    //Set previous timeout back
                    Database.SetCommandTimeout(previousTimeout);
                    //    ((IObjectContextAdapter)this).ObjectContext.CommandTimeout = previousTimeout;
                }
            
=======
            /*
            if (timeout.HasValue)
            {
                //store previous timeout
                previousTimeout = ((IObjectContextAdapter) this).ObjectContext.CommandTimeout;
   
                ((IObjectContextAdapter) this).ObjectContext.CommandTimeout = timeout;
            }
            */
            var transactionalBehavior = doNotEnsureTransaction; // ? TransactionalBehavior.DoNotEnsureTransaction : TransactionalBehavior.EnsureTransaction;

            var result = Database.ExecuteSqlCommand(sql, parameters);
            /*
            if (timeout.HasValue)
            {
                //Set previous timeout back
                ((IObjectContextAdapter) this).ObjectContext.CommandTimeout = previousTimeout;
            }
            */
>>>>>>> 2e885519c792b00b6562bc7d426d77be57e39220
            return result;
        }

        /// <summary>
        /// Detach an entity
        /// </summary>
        /// <param name="entity">Entity</param>
        public void Detach(object entity)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));
<<<<<<< HEAD

          //Pekmez  ((IObjectContextAdapter)this).ObjectContext.Detach(entity);
=======
            this.Detach(entity);
           // ((IObjectContextAdapter)this).ObjectContext.Detach(entity);
>>>>>>> 2e885519c792b00b6562bc7d426d77be57e39220
        }

        #endregion

        #region Properties
<<<<<<< HEAD

=======
        bool pce;
>>>>>>> 2e885519c792b00b6562bc7d426d77be57e39220
        /// <summary>
        /// Gets or sets a value indicating whether proxy creation setting is enabled (used in EF)
        /// </summary>
        public virtual bool ProxyCreationEnabled
        {
            get
            {
<<<<<<< HEAD
                return false;//Pekmez Configuration.ProxyCreationEnabled;
            }
            set
            {
            //    Configuration.ProxyCreationEnabled = value;
=======

                return pce;// Configuration.ProxyCreationEnabled;
            }
            set
            {
               pce=/* Configuration.ProxyCreationEnabled =*/ value;
>>>>>>> 2e885519c792b00b6562bc7d426d77be57e39220
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether auto detect changes setting is enabled (used in EF)
        /// </summary>
<<<<<<< HEAD
=======
        bool adce;
>>>>>>> 2e885519c792b00b6562bc7d426d77be57e39220
        public virtual bool AutoDetectChangesEnabled
        {
            get
            {
<<<<<<< HEAD
                return false; //Pekmez Configuration.AutoDetectChangesEnabled;
            }
            set
            {
            //    Configuration.AutoDetectChangesEnabled = value;
            }
        }

        #endregion
    }
}
=======
                return adce;// Configuration.AutoDetectChangesEnabled;
            }
            set
            {
                adce=/*Configuration.AutoDetectChangesEnabled =*/ value;
            }
        } 

        #endregion
    }
}
>>>>>>> 2e885519c792b00b6562bc7d426d77be57e39220
