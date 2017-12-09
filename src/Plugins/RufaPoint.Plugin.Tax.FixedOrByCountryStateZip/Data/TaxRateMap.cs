using RufaPoint.Data.Mapping;
using RufaPoint.Plugin.Tax.FixedOrByCountryStateZip.Domain;

namespace RufaPoint.Plugin.Tax.FixedOrByCountryStateZip.Data
{
    public partial class TaxRateMap : NopEntityTypeConfiguration<TaxRate>
    {
        public TaxRateMap()
        {
            this.ToTable("TaxRate");
            this.HasKey(tr => tr.Id);
            this.Property(tr => tr.Percentage).HasPrecision(18, 4);
        }
    }
}