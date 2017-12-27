using RufaPoint.Core;
using RufaPoint.Core.Data;

namespace RufaPoint.Data
{
    /// <summary>
    /// Entity Framework data provider manager
    /// </summary>
    public partial class EfDataProviderManager : BaseDataProviderManager
    {
        /// <summary>
        /// Ctor
        /// </summary>
        /// <param name="settings">Data settings</param>
        public EfDataProviderManager(DataSettings settings):base(settings)
        {
        }

        /// <summary>
        /// Load data provider
        /// </summary>
        /// <returns>Data provider</returns>
        public override IDataProvider LoadDataProvider()
        {
            var providerName = Settings.DataProvider;
            if (string.IsNullOrWhiteSpace(providerName))
                throw new CoreException("Data Settings doesn't contain a providerName");

            switch (providerName.ToLowerInvariant())
            {
                case "sqlserver":
                    return new SqlServerDataProvider();
                case "sqlce":
                    return new SqlCeDataProvider();
                default:
                    throw new CoreException($"Not supported dataprovider name: {providerName}");
            }
        }
    }
}
