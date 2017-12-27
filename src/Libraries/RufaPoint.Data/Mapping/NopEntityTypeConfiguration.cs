using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace RufaPoint.Data.Mapping
{
    /// <summary>
    /// Entity configuration
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public abstract class NopEntityTypeConfiguration<T> : IEntityTypeConfiguration<T> where T : class
    {
        /// <summary>
        /// Ctor
        /// </summary>
        protected NopEntityTypeConfiguration()
        {
            PostInitialize();
        }

        /// <summary>
        /// Developers can override this method in custom partial classes
        /// in order to add some custom initialization code to constructors
        /// </summary>
        protected virtual void PostInitialize()
        {
            
        }
        protected virtual void DoConfig(EntityTypeBuilder<T> builder)
        {
            throw new System.NotImplementedException();
        }
        void IEntityTypeConfiguration<T>.Configure(EntityTypeBuilder<T> builder)
        {
            DoConfig(builder);
           
        }
    }
}