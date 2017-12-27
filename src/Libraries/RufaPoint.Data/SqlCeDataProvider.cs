using System.Data.Common;
using System.Data.SqlClient;
using RufaPoint.Core.Data;
using RufaPoint.Data.Initializers;
using Microsoft.EntityFrameworkCore.Storage;
//using System.Data.SqlServerCe;

namespace RufaPoint.Data
{
    /// <summary>
    /// SQL Serevr Compact provider
    /// </summary>
    public class SqlCeDataProvider : IDataProvider
    {
        /// <summary>
        /// Initialize connection factory
        /// </summary>
        public virtual void InitConnectionFactory()
        {
            //Pekmez var connectionFactory = new SqlCeConnectionFactory("System.Data.SqlServerCe.4.0");
            //TODO fix compilation warning (below)
#pragma warning disable 0618
            //Pekmez Database.DefaultConnectionFactory = connectionFactory;
        }

        /// <summary>
        /// Initialize database
        /// </summary>
        public virtual void InitDatabase()
        {
            InitConnectionFactory();
            SetDatabaseInitializer();
        }

        /// <summary>
        /// Set database initializer
        /// </summary>
        public virtual void SetDatabaseInitializer()
        {
            var initializer = new CreateCeDatabaseIfNotExists<NopObjectContext>();
            //PekmezDatabase.SetInitializer(initializer);
        }

        /// <summary>
        /// A value indicating whether this data provider supports stored procedures
        /// </summary>
        public virtual bool StoredProceduredSupported
        {
            get { return false; }
        }

        /// <summary>
        /// A value indicating whether this data provider supports backup
        /// </summary>
        public bool BackupSupported
        {
            get { return false; }
        }

        /// <summary>
        /// Gets a support database parameter object (used by stored procedures)
        /// </summary>
        /// <returns>Parameter</returns>
        public virtual DbParameter GetParameter()
        {
            return new SqlParameter();
        }

        /// <summary>
        /// Maximum length of the data for HASHBYTES functions
        /// returns 0 if HASHBYTES function is not supported
        /// </summary>
        /// <returns>Length of the data for HASHBYTES functions</returns>
        public int SupportedLengthOfBinaryHash()
        {
            return 0; //HASHBYTES functions is missing in SQL CE
        }
    }
}
