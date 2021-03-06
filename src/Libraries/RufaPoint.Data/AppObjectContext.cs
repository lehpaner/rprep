using Microsoft.EntityFrameworkCore;
using RufaPoint.Core;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Reflection;
using System.Text;

namespace RufaPoint.Data
{
    /// <summary>
    /// Object context
    /// </summary>
    public class AppObjectContext : DbContext, IDbContext
    {
        #region Ctor

        string connectionString { get; set; }
        int dbtype { get; set; }
        /// <summary>
        /// Ctor
        /// </summary>
        /// <param name="nameOrConnectionString">Connecting string</param>
        public AppObjectContext(string nameOrConnectionString, int db_type=0)
        {
            connectionString = nameOrConnectionString;
            dbtype = db_type;
        }

        public AppObjectContext(DbContextOptions<AppObjectContext> options) : base(options)
        {

        }
        /// <summary>
        /// On config handler to define storage type
        /// </summary>
        /// <param name="optionsBuilder"></param>
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //TBD make configurable
            if (dbtype == 0)
            {
                optionsBuilder.UseSqlServer(@"Data Source=localhost; Initial Catalog=rufa; Integrated Security=True; Persist Security Info=False");
            }
            else if (dbtype == 1)
            {
                optionsBuilder.UseInMemoryDatabase(@"Data.sdf");
            }
            else if (dbtype == 2)
            {
                optionsBuilder.UseSqlite(@"Data.db");
            }

            else throw new Exception("Database Provider has to be defined");
        }
        #endregion

        #region Utilities

        /// <summary>
        /// On model creating
        /// </summary>
        /// <param name="modelBuilder">Model builder</param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

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

            //this.GetService<IDatabaseProviderServices>()
            //return ((IObjectContextAdapter)this).ObjectContext.CreateDatabaseScript();
            return this.CreateDatabaseScript();
        }

        /// <summary>
        /// Get DbSet
        /// </summary>
        /// <typeparam name="TEntity">Entity type</typeparam>
        /// <returns>DbSet</returns>
        public new DbSet<TEntity> Set<TEntity>() where TEntity : BaseEntity
        {
            return base.Set<TEntity>();
        }
        
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

            //var result = Database.SqlQuery<TEntity>(commandText, parameters).ToList();
            var result = this.SqlQuery<TEntity>(commandText, parameters).ToList();
            /*Pekmez
            //performance hack applied as described here - https://www.nopcommerce.com/boards/t/25483/fix-very-important-speed-improvement.aspx
            var acd = Configuration.AutoDetectChangesEnabled;
            
            try
            {
                IConfiguration.AutoDetectChangesEnabled = false;

                for (var i = 0; i < result.Count; i++)
                    result[i] = AttachEntityToContext(result[i]);
            }
            finally
            {
                Configuration.AutoDetectChangesEnabled = acd;
            }

            */
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
            //return Database.SqlQuery<TElement>(sql, parameters);
            return this.SqlQuery<TElement>(sql, parameters);
        }
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

            this.Detach(entity);
           // ((IObjectContextAdapter)this).ObjectContext.Detach(entity);

        }

        #endregion

        #region Properties

        bool pce;

        /// <summary>
        /// Gets or sets a value indicating whether proxy creation setting is enabled (used in EF)
        /// </summary>
        public virtual bool ProxyCreationEnabled
        {
            get
            {
                return false;//Pekmez Configuration.ProxyCreationEnabled;
            }
            set
            {
            //    Configuration.ProxyCreationEnabled = value;0
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether auto detect changes setting is enabled (used in EF)
        /// </summary>

        bool adce;

        public virtual bool AutoDetectChangesEnabled
        {
            get
            {

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

