using CsvHelper.Configuration;
using SKU.Model;

namespace SKU.Mapping
{
    public class SkuMap : ClassMap<Sku>
    {
        public SkuMap()
        {
            Map(m => m.JanCode).Name("JanCode");
            Map(m => m.Name).Name("Name");
            Map(m => m.X).Name("X");
            Map(m => m.Y).Name("Y");
            Map(m => m.Z).Name("Z");
            Map(m => m.ImageURL).Name("ImageURL");
            Map(m => m.TimeStamp).Name("TimeStamp");
            Map(m => m.Shape).Name("Shape");
        }
    }
}
